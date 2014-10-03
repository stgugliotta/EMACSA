using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using ar.com.telecom.eva.CoreServices.Caching.BackingStorages;
using ar.com.telecom.eva.CoreServices.Caching.CacheItemExpirations;
using ar.com.telecom.eva.CoreServices.Caching.Scavenging;

namespace ar.com.telecom.eva.CoreServices.Caching.CacheManagers
{
    internal class CacheManager: ICacheManager, IDisposable
    {
        protected string name;
        protected RealCache realCache;
        protected BackgroundScavenger scheduler;
        protected ExpirationPollTimer pollTimer;


        internal CacheManager(string name)
        {
            this.name = name;
        }

        public void Initialize( int expirationPollFrequencyInSeconds, int maximumElementsInCacheBeforeScavenging,
            int numberToRemoveWhenScavenging, IBackingStore backingStore)
        {
            CacheCapacityScavengingPolicy scavengingPolicy =
                new CacheCapacityScavengingPolicy(maximumElementsInCacheBeforeScavenging);

            this.realCache = new RealCache(backingStore, scavengingPolicy);
            this.pollTimer = new ExpirationPollTimer();
            ExpirationTask expirationTask = new ExpirationTask(this.realCache);
            ScavengerTask scavengerTask =
                new ScavengerTask(numberToRemoveWhenScavenging, scavengingPolicy, this.realCache);
            this.scheduler = new BackgroundScavenger(expirationTask, scavengerTask);
            this.realCache.Initialize(scheduler);
            this.scheduler.Start();
            this.pollTimer.StartPolling(new TimerCallback(scheduler.ExpirationTimeoutExpired),
                                        expirationPollFrequencyInSeconds*1000);
        }

        ///<summary>
        /// <para> Retorna el número de items actualmente en la instancia de cache.</para>
        ///</summary>
        public int Count
        {
            get { return realCache.Count; }
        }

        ///<summary>
        /// <para> Retorna el item identificado por la clave</para>
        ///</summary>
        ///<param name="key">
        /// <para> Clave para obtener el valor de la cache.</para>
        /// </param>
        /// <exception cref="ArgumentNullException">La clave provista es nula.</exception>
        /// <exception cref="ArgumentException">La clave provista es una cadena vacía.</exception>
        public object this[string key]
        {
            get { return this.realCache[key]; }
            set { this.realCache[key] = value; }
        }

        ///<summary>
        /// <para> Retorna true si hay un ítem en la cache con clave provista. </para>
        ///</summary>
        ///<param name="key">
        /// <para>La clave a verificar.</para>
        /// </param>
        ///<returns>True si la clave provista está en el cache.</returns>
        public bool Contains(string key)
        {
            return realCache.Contains(key);
        }

        ///<summary>
        /// <para> Agrega un nuevo ítem a la cache si existe otro ítem con la misma clave lo reemplaza.
        /// Items agregados con éste método no expiran y su prioridad será <seealso cref="CacheItemPriority.Normal"/>. </para>
        ///</summary>
        ///<param name="key">
        /// <para> Clave identificatoria para este ítem.</para>
        /// </param>
        /// <exception cref="ArgumentNullException">La clave provista es nula.</exception>
        /// <exception cref="ArgumentException">La clave provista es una cadena vacía.</exception>
        ///<param name="value">
        /// <para> Valor a guardar en la cache. Puede ser nulo.</para>
        /// </param>
        /// <returns>
        /// True si el ítem existía previamente y fue reemplazado.
        /// </returns>
        public bool Add(string key, object value)
        {
            return this.realCache.Add(key, value);
        }

        /// <summary>
        /// <para> Agrega un nuevo ítem a la cache si existe otro ítem con la misma clave lo reemplaza.</para>
        /// </summary>
        /// <param name="key">
        /// <para> Clave identificatoria para este ítem.</para>
        /// </param>
        /// <exception cref="ArgumentNullException">La clave provista es nula.</exception>
        /// <exception cref="ArgumentException">La clave provista es una cadena vacía.</exception>
        /// <param name="value">
        /// <para> Valor a guardar en la cache. Puede ser nulo.</para>
        /// </param>
        /// <param name="scavengingPriority">Prioridad para permanecer en memoria. 
        /// Uno de los valores de <see cref="CacheItemPriority"/>.</param>
        /// <param name="expirations">Vencimiento del ítem. 
        /// Un arreglo de objetos <see cref="ICacheItemExpiration"/>.</param>
        /// <returns>True si el ítem existía previamente y fue reemplazado.</returns>
        public bool Add(string key, object value, CacheItemPriority scavengingPriority,
                        params ICacheItemExpiration[] expirations)
        {
            return this.realCache.Add(key, value, scavengingPriority, expirations);
        }

        ///<summary>
        /// <para> Remueve el ítem dado de la cache. Si no hay ningún ítem con la clave dada el método no hace nada.</para>
        ///</summary>
        ///<param name="key">
        /// <para> Clave identificatoria del ítem a remover.</para>
        /// </param>
        /// <exception cref="ArgumentNullException">La clave provista es nula.</exception>
        /// <exception cref="ArgumentException">La clave provista es una cadena vacía.</exception>
        public void Remove(string key)
        {
            this.realCache.Remove(key);
        }

        ///<summary>
        /// <para> Retorna el valor asociado a la clave dada.</para>
        ///</summary>
        ///<param name="key">
        /// <para> Clave del ítem a retornar del cache.</para>
        /// </param>
        ///<returns>
        /// <para> Valor almacenado en el cache.</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">La clave provista es nula.</exception>
        /// <exception cref="ArgumentException">La clave provista es una cadena vacía.</exception>
        public object GetData(string key)
        {
            return this.realCache.GetData(key);
        }

        ///<summary>
        /// <para> Retorna el valor asociado a la clave dada.</para>
        ///</summary>
        ///<param name="key">
        /// <para> Clave del ítem a retornar del cache.</para>
        /// </param>
        ///<typeparam name="T">
        /// <para> Tipo de valor almacenado en el ítem.</para>
        /// </typeparam>
        ///<returns>
        /// <para> Valor almacenado en el cache.</para> 
        /// </returns>
        /// <exception cref="ArgumentNullException">La clave provista es nula.</exception>
        /// <exception cref="ArgumentException">La clave provista es una cadena vacía.</exception>
        public T GetData<T>(string key)
        {
            return this.realCache.GetData<T>(key);
        }

        ///<summary>
        /// Retorna un <see cref="IDictionaryEnumerator"/> con los items de la cache. 
        ///</summary>
        ///<returns>
        /// <para> un <see cref="IDictionaryEnumerator"/> con los items de la cache. </para>
        /// </returns>
        public IDictionaryEnumerator Enumerator()
        {
            return this.realCache.Enumerator();
        }

        /// <summary>
        /// >Retorna una <see cref="Hashtable"/> conteniendo los ítems de cache actuales.
        /// </summary>
        public Hashtable CurrentCacheState
        {
            get { return this.realCache.CurrentCacheState; }
        }

        /// <summary>
        /// Retorna el nombre de la instancia de cache.
        /// </summary>
        public string Name
        {
            get { return name; }
        }


        /// <summary>
        /// No generado para uso público. Público por requerimientos de <see cref="IDisposable"/>. Si se llama éste método,
        /// la instancia de cache queda inútil.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            if (scheduler != null)
            {
                scheduler.Stop();
                scheduler = null;
            }
            if (pollTimer != null)
            {
                pollTimer.StopPolling();
                pollTimer = null;
            }
            if (realCache != null)
            {
                realCache.Dispose();
                realCache = null;
            }
        }
    }
}
