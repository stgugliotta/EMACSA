using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.Caching.CacheItemExpirations
{
    /// <summary>
    /// Esta clase refleja una política de expiración que nunca expira.
    /// </summary>
    [Serializable]
    public class NeverExpired : ICacheItemExpiration
    {
        /// <summary>
        /// Inicializa una instancia.
        /// </summary>
        public NeverExpired()
        {

        }

        /// <summary>
        /// Siempre devuelve false
        /// </summary>
        /// <returns>Siempre false</returns>
        public bool HasExpired()
        {
            return false;
        }

        /// <summary>
        /// No usado
        /// </summary>
        public void Notify()
        {
        }

        /// <summary>
        /// No usado
        /// </summary>
        /// <param name="owningCacheItem">No usado</param>
        public void Initialize(CacheItem owningCacheItem)
        {
        }
    }
}
