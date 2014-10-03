using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using ar.com.telecom.eva.CoreServices.Caching.BackingStorages;
using ar.com.telecom.eva.CoreServices.Caching.CacheItemExpirations;
using ar.com.telecom.eva.CoreServices.Caching.Instrumentation;
using ar.com.telecom.eva.CoreServices.Caching.Scavenging;
using ar.com.telecom.eva.CoreServices.Properties;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Caching.CacheManagers
{
    /// <summary>
    /// Contiene las operaciones que realmente se ejecutan con los ítems de cache.
    /// </summary>	
    public sealed class RealCache : IDisposable
    {
        private Hashtable inMemoryCache;
        private ICacheScavenger cacheScavenger;
        private IBackingStore backingStore;
        private CacheCapacityScavengingPolicy scavengingPolicy;

        private const string addInProgressFlag = "Dummy variable used to flag temp cache item added during Add";

        /// <summary>
        /// Incializa una nueva instancia de la clase <see cref="RealCache"/> con el almacenamiento de resguardo
        /// y la política de limpieza.
        /// </summary>
        /// <param name="backingStore">El almacenamiento de resguardo.</param>
        /// <param name="scavengingPolicy">La política de limpieza.</param>
        public RealCache(IBackingStore backingStore, CacheCapacityScavengingPolicy scavengingPolicy)
        {
            this.backingStore = backingStore;
            this.scavengingPolicy = scavengingPolicy;

            Hashtable initialItems = backingStore.Load();
            inMemoryCache = Hashtable.Synchronized(initialItems);

            InstrumentationProvider.CacheUpdated();
        }

        /// <summary>
        /// Obtiene la cantidad de objetos <see cref="CacheItem"/>.
        /// </summary>
        /// <value>
        /// la cantidad de objetos <see cref="CacheItem"/>.
        /// </value>
        public int Count
        {
            get { return inMemoryCache.Count; }
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
            get { return this.GetData(key); }
            set { this.Add(key, value); }
        }

        /// <summary>
        /// Obtiene un <see cref="IDictionaryEnumerator"/> con los ítems actuales de cache.
        /// </summary>
        /// <returns>
        /// un <see cref="IDictionaryEnumerator"/> con los ítems actuales de cache.
        /// </returns>
        public IDictionaryEnumerator Enumerator()
        {
            return ((Hashtable)inMemoryCache.Clone()).GetEnumerator(); 
        }

        /// <summary>
        /// Obtiene el cache actual.
        /// </summary>
        /// <returns>
        /// El cache actual.
        /// </returns>
        public Hashtable CurrentCacheState
        {
            get { return (Hashtable) inMemoryCache.Clone(); }
        }

        /// <summary>
        /// Determina si una clave particular está contenida en la instancia de cache.
        /// </summary>
        /// <param name="key">La clave a localizar.</param>
        /// <returns>
        /// <see langword="true"/> si la clave esta contenida en el cache; de lo contrario, <see langword="false"/>.
        /// </returns>
        public bool Contains(string key)
        {
            ValidateKey(key);

            return inMemoryCache.Contains(key);
        }

        /// <summary>
        /// Inicializa la instancia de cache con un basurero.
        /// </summary>
        /// <param name="cacheScavengerToUse">
        /// un objeto <see cref="ICacheScavenger"/>.
        /// </param>
        public void Initialize(ICacheScavenger cacheScavengerToUse)
        {
            this.cacheScavenger = cacheScavengerToUse;
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
            return Add(key, value, CacheItemPriority.Normal, null);
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
        public bool Add(string key, object value, CacheItemPriority scavengingPriority, params ICacheItemExpiration[] expirations)
        {
            ValidateKey(key);
            EnsureCacheInitialized();
            bool existingItem = false;
            CacheItem cacheItemBeforeLock;
            bool lockWasSuccessful = false;

            do
            {
                lock (inMemoryCache.SyncRoot)
                {
                    if ((existingItem = inMemoryCache.Contains(key)) == false)
                    {
                        cacheItemBeforeLock = new CacheItem(key, addInProgressFlag, CacheItemPriority.NotRemovable, null);
                        inMemoryCache[key] = cacheItemBeforeLock;
                    }
                    else
                    {
                        cacheItemBeforeLock = (CacheItem)inMemoryCache[key];
                    }

                    lockWasSuccessful = Monitor.TryEnter(cacheItemBeforeLock);
                }

                if (lockWasSuccessful == false)
                {
                    Thread.Sleep(0);
                }
            } while (lockWasSuccessful == false);

            try
            {
                cacheItemBeforeLock.TouchedByUserAction(true);

                CacheItem newCacheItem = new CacheItem(key, value, scavengingPriority, expirations);
                try
                {
                    backingStore.Add(newCacheItem);
                    cacheItemBeforeLock.Replace(value, scavengingPriority, expirations);
                    inMemoryCache[key] = cacheItemBeforeLock;
                }
                catch
                {
                    backingStore.Remove(key);
                    inMemoryCache.Remove(key);
                    throw;
                }

                if (scavengingPolicy.IsScavengingNeeded(inMemoryCache.Count))
                {
                    cacheScavenger.StartScavenging();
                }
                InstrumentationProvider.CacheUpdated();
            }
            finally
            {
                Monitor.Exit(cacheItemBeforeLock);
            }

            return existingItem;
        }


        /// <summary>
        /// Elimina un item de la cache por su clave.
        /// </summary>
        /// <param name="key">La clave del ítem a eliminar.</param>
        public void Remove(string key)
        {
            ValidateKey(key);

            CacheItem cacheItemBeforeLock = null;
            bool lockWasSuccessful;
            do
            {
                lock (inMemoryCache.SyncRoot)
                {
                    cacheItemBeforeLock = (CacheItem)inMemoryCache[key];

                    if (IsObjectInCache(cacheItemBeforeLock))
                    {
                        return;
                    }

                    lockWasSuccessful = Monitor.TryEnter(cacheItemBeforeLock);
                }

                if (lockWasSuccessful == false)
                {
                    Thread.Sleep(0);
                }
            } while (lockWasSuccessful == false);

            try
            {
                cacheItemBeforeLock.TouchedByUserAction(true);

                backingStore.Remove(key); 
                inMemoryCache.Remove(key);

                InstrumentationProvider.CacheUpdated();
            }
            finally
            {
                Monitor.Exit(cacheItemBeforeLock);
            }

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
            ValidateKey(key);
            CacheItem cacheItemBeforeLock = null;
            bool lockWasSuccessful = false;

            do
            {
                lock (inMemoryCache.SyncRoot)
                {
                    cacheItemBeforeLock = (CacheItem)inMemoryCache[key];
                    if (IsObjectInCache(cacheItemBeforeLock))
                    {
                        InstrumentationProvider.CacheAccessed();
                        return null;
                    }

                    lockWasSuccessful = Monitor.TryEnter(cacheItemBeforeLock);
                }

                if (lockWasSuccessful == false)
                {
                    Thread.Sleep(0);
                }
            } while (lockWasSuccessful == false);

            try
            {
                if (cacheItemBeforeLock.HasExpired())
                {
                    cacheItemBeforeLock.TouchedByUserAction(true);

                    backingStore.Remove(key); 
                    inMemoryCache.Remove(key);
                    InstrumentationProvider.CacheAccessed();
                    InstrumentationProvider.CacheUpdated();
                    InstrumentationProvider.CacheExpired();
                    return null;
                }

                backingStore.UpdateLastAccessedTime(cacheItemBeforeLock.Key, DateTime.Now); 
                cacheItemBeforeLock.TouchedByUserAction(false);

                InstrumentationProvider.CacheAccessed();
                return cacheItemBeforeLock.Value;
            }
            finally
            {
                Monitor.Exit(cacheItemBeforeLock);
            }
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
            return (T)this.GetData(key);
        }

        /// <summary>
        /// Vacía el cache.
        /// </summary>
        public void Flush()
        {
        RestartFlushAlgorithm:
            lock (inMemoryCache.SyncRoot)
            {
                foreach (string key in inMemoryCache.Keys)
                {
                    bool lockWasSuccessful = false;
                    CacheItem itemToRemove = (CacheItem)inMemoryCache[key];
                    try
                    {
                        if (lockWasSuccessful = Monitor.TryEnter(itemToRemove))
                        {
                            itemToRemove.TouchedByUserAction(true);
                        }
                        else
                        {
                            goto RestartFlushAlgorithm;
                        }
                    }
                    finally
                    {
                        if (lockWasSuccessful) Monitor.Exit(itemToRemove);
                    }
                }

                backingStore.Flush();
                inMemoryCache.Clear();
                InstrumentationProvider.CacheUpdated();
            }
        }

        private static void ValidateKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new EvaTechnicalException("", new  ArgumentException(Resources.ERROR_EMPTYPARAMETERNAME, "key"));
            }
        }

        private void EnsureCacheInitialized()
        {
            if (cacheScavenger == null)
            {
                throw new  EvaTechnicalException("", new InvalidOperationException(Resources.ERROR_REALCACHE_NOTINITIALIZED));
            }
        }

        private static bool IsObjectInCache(CacheItem cacheItemBeforeLock)
        {
            return cacheItemBeforeLock == null || Object.ReferenceEquals(cacheItemBeforeLock.Value, addInProgressFlag);
        }


        /// <summary>
        /// Descarga el almacenamiento de resguardo antes que el garbage collection.
        /// </summary>
        ~RealCache()
        {
            Dispose(false);
        }

        /// <summary>
        /// Descarga el almacenamiento de resguardo antes que el garbage collection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Descarga el almacenamiento de resguardo antes que el garbage collection.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true"/> si está descargando; de lo contrario, <see langword="false"/>.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                backingStore.Dispose();
                backingStore = null;
            }
        }

    }
}
