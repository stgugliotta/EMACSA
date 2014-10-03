using System;
using System.Collections.Generic;
using System.Text;
using ar.com.telecom.eva.CoreServices.Caching.CacheItemExpirations;

namespace ar.com.telecom.eva.CoreServices.Caching
{
    /// <summary>
    /// Esta clase contiene toda la información de un ítem almacenado en cache. Almacena la clave y el valor
    /// especificada por el usuario, como así tambien, la información de limpieza utilizada por el bloque.
    /// </summary>
    public class CacheItem
    {
        // Información de provista por el usuario.
        private string key;
        private object data;

        // Información de limpieza provista por el usuario.
        private ICacheItemExpiration[] expirations;
        private CacheItemPriority scavengingPriority;

        // Información de limpieza interna.
        private DateTime lastAccessedTime;
        private bool willBeExpired;
        private bool eligibleForScavenging;

        /// <summary>
        /// Inicializa la un nuevo CacheItem.
        /// </summary>
        /// <param name="key">Clave identificatoria del CacheItem.</param>
        /// <param name="value">Valor a ser almacenado. Puede ser null.</param>
        /// <param name="scavengingPriority">Prioridad de limpieza del CacheItem. Uno de los valores de  <see cref="CacheItemPriority" />.</param>
        /// <param name="expirations">Un arreglo de objetos ICacheItemExpiration. Pueden ser 0 o más.</param>
        public CacheItem(string key, object value, CacheItemPriority scavengingPriority,  params ICacheItemExpiration[] expirations)
        {
            Initialize(key, value, scavengingPriority, expirations);

            TouchedByUserAction(false);
        }

        /// <summary>
        /// Incializa un nuevo CacheItem. Este constructor es para ser usado cuando se recupera el CacheItem desde el 
        /// almacenamiento  de resgusguardo. 
        /// </summary>
        /// <param name="lastAccessedTime">Fecha y hora que este cacheItem fue accedido por el usuario por última vez.
        /// </param>
        /// <param name="key">Clave identificatoria provistista por el usario. No puede ser null.</param>
        /// <param name="value">Valor a ser almacenado. Puede ser null.</param>
        /// <param name="scavengingPriority">Prioridad de limpieza del CacheItem. Uno de los valores de  <see cref="CacheItemPriority" />.</param>
        /// <param name="expirations">Un arreglo de objetos ICacheItemExpiration. Pueden ser 0 o más.</param>
        public CacheItem(DateTime lastAccessedTime, string key, object value, CacheItemPriority scavengingPriority,
            params ICacheItemExpiration[] expirations)
        {
            Initialize(key, value, scavengingPriority, expirations);

            TouchedByUserAction(false, lastAccessedTime);
            InitializeExpirations();
        }

        /// <summary>
        /// Reemplaza los los valores internos del CacheItem con los nuevos valores dados. Es usado cuando se agregan nuevos items
        /// dentro del cache, permite reemplazar los atributos sin tener que reemplazar el objeto en si.
        /// </summary>
        /// <param name="cacheItemData">Valor a ser almacenado. Puede ser null.</param>
        /// <param name="cacheItemPriority">Prioridad de limpieza del CacheItem. Uno de los valores de  <see cref="CacheItemPriority" />.</param>
        /// <param name="cacheItemExpirations">Un arreglo de objetos ICacheItemExpiration. Pueden ser 0 o más.</param>
        internal void Replace(object cacheItemData, CacheItemPriority cacheItemPriority, params ICacheItemExpiration[] cacheItemExpirations)
        {
            Initialize(this.key, cacheItemData, cacheItemPriority, cacheItemExpirations);
            TouchedByUserAction(false);
        }

        /// <summary>
        /// Obtiene el valor de <see cref="CacheItemPriority" /> asignado al CacheItem.
        /// </summary>
        internal CacheItemPriority ScavengingPriority
        {
            get { return scavengingPriority; }
        }

        /// <summary>
        /// Obtiene la fecha y hora del último acceso.
        /// </summary>
        /// <value>
        /// La fecha y hora del último acceso..
        /// </value>
        public DateTime LastAccessedTime
        {
            get { return lastAccessedTime; }
        }

        /// <summary>
        /// Para uso interno. True cuando el ítem ha vencido y será removido.
        /// </summary>
        internal bool WillBeExpired
        {
            get { return willBeExpired; }
            set { willBeExpired = value; }
        }

        /// <summary>
        /// Para uso interno. El valor debe ser true cuando es candidato para ser eliminado.
        /// </summary>
        internal bool EligibleForScavenging
        {
            get { return eligibleForScavenging && ScavengingPriority != CacheItemPriority.NotRemovable; }
        }

        /// <summary>
        /// Obtiene el valor almacenado.
        /// </summary>
        public object Value
        {
            get { return data; }
        }

        /// <summary>
        /// Obtiene la clave asociada
        /// </summary>
        public string Key
        {
            get { return key; }
        }

        /// <summary>
        /// Devuelve un arreglo con los objetos <see cref="ICacheItemExpiration"/> asociados.
        /// </summary>
        /// <returns>
        /// Un arreglo con los objetos <see cref="ICacheItemExpiration"/> asociados.
        /// </returns>
        public ICacheItemExpiration[] GetExpirations()
        {
            return (ICacheItemExpiration[])expirations.Clone();
        }

        /// <summary>
        /// Evalua los cacheItemExpirations asociados a este ítem para determinar si debe considerarse vencido.
        /// </summary>
        /// <returns>True si el ítem está vencido.</returns>
        public bool HasExpired()
        {
            foreach (ICacheItemExpiration expiration in expirations)
            {
                if (expiration.HasExpired())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Esté método se dispara cuando el usuario hace alguna acción con la instancia. Alarga la duración del ítem en la memoria.
        /// </summary>
        internal void TouchedByUserAction(bool objectRemovedFromCache)
        {
            TouchedByUserAction(objectRemovedFromCache, DateTime.Now);
        }

        /// <summary>
        /// Esté método se dispara cuando el usuario hace alguna acción con la instancia. Alarga la duración del ítem en la memoria.
        /// </summary>
        internal void TouchedByUserAction(bool objectRemovedFromCache, DateTime timestamp)
        {
            lastAccessedTime = timestamp;
            eligibleForScavenging = false;

            foreach (ICacheItemExpiration expiration in expirations)
            {
                expiration.Notify();
            }

            willBeExpired = objectRemovedFromCache ? false : HasExpired();
        }

        /// <summary>
        /// Indica a la instancia disponible para ser eliminado.
        /// </summary>
        public void MakeEligibleForScavenging()
        {
            eligibleForScavenging = true;
        }

        /// <summary>
        /// Indica a la instancia disponible no para ser eliminado.
        /// </summary>
        public void MakeNotEligibleForScavenging()
        {
            eligibleForScavenging = false;
        }

        private void InitializeExpirations()
        {
            foreach (ICacheItemExpiration expiration in expirations)
            {
                expiration.Initialize(this);
            }
        }

        private void Initialize(string cacheItemKey, object cacheItemData, CacheItemPriority cacheItemPriority, ICacheItemExpiration[] cacheItemExpirations)
        {
            key = cacheItemKey;
            data = cacheItemData;
            scavengingPriority = cacheItemPriority;
            if (cacheItemExpirations == null)
            {
                expirations = new ICacheItemExpiration[1] { new NeverExpired() };
            }
            else
            {
                expirations = cacheItemExpirations;
            }
        }

        internal void SetLastAccessedTime(DateTime specificAccessedTime)
        {
            lastAccessedTime = specificAccessedTime;
        }
    }
}
