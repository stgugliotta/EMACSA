using System.Collections;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching.Instrumentation;

namespace Gobbi.CoreServices.Caching.Scavenging
{
    /// <summary>
    /// Representa una tarea para verificar el vencimiento de los CacheItems.
    /// </summary>
    public class ExpirationTask
    {
        private RealCache realCache;

        /// <summary>
        /// Incializa una instancia de la clase <see cref="ExpirationTask"/> con un objeto <see cref="RealCache"/>.
        /// </summary>
        /// <param name="realCache">Un objeto<see cref="RealCache"/>.</param>
        public ExpirationTask(RealCache realCache)
        {
            this.realCache = realCache;
        }

        /// <summary>
        /// Ejecuta los vencimientos de los cacheItems.
        /// </summary>
        public void DoExpirations()
        {
            Hashtable liveCacheRepresentation = realCache.CurrentCacheState;
            MarkAsExpired(liveCacheRepresentation);
            PrepareForSweep();
            int expiredItemsCount = SweepExpiredItemsFromCache(liveCacheRepresentation);

            if (expiredItemsCount > 0) InstrumentationProvider.CacheExpired();
        }

        /// <summary>
        /// Marca cada <see cref="CacheItem"/> como vencido. 
        /// </summary>
        /// <param name="liveCacheRepresentation">El conjunto de objetos <see cref="CacheItem"/> 
        /// marcados como vencidos.</param>
        /// <returns>
        /// El número de items marcados.
        /// </returns>
        public virtual int MarkAsExpired(Hashtable liveCacheRepresentation)
        {
            int markedCount = 0;
            foreach (CacheItem cacheItem in liveCacheRepresentation.Values)
            {
                lock (cacheItem)
                {
                    if (cacheItem.HasExpired())
                    {
                        markedCount++;
                        cacheItem.WillBeExpired = true;
                    }
                }
            }

            return markedCount;
        }

        /// <summary>
        /// Elimina los <see cref="CacheItem"/>s.
        /// </summary>
        /// <param name="liveCacheRepresentation">
        /// El conjunto de objetos <see cref="CacheItem"/> a eliminar.
        /// </param>
        /// <returns>La cantidad de items vencidos.</returns>
        public virtual int SweepExpiredItemsFromCache(Hashtable liveCacheRepresentation)
        {
            int expiredItems = 0;

            foreach (CacheItem cacheItem in liveCacheRepresentation.Values)
            {
                if (RemoveItemFromCache(cacheItem))
                    expiredItems++;
            }

            return expiredItems;
        }

        /// <summary>
        /// Prepara para eliminar los <see cref="CacheItem"/>s.
        /// </summary>
        public virtual void PrepareForSweep()
        {
        }

        private bool RemoveItemFromCache(CacheItem itemToRemove)
        {
            bool expired = false;

            lock (itemToRemove)
            {
                if (itemToRemove.WillBeExpired)
                {
                    try
                    {
                        expired = true;
                        realCache.Remove(itemToRemove.Key);
                    }
                    catch 
                    {
                        InstrumentationProvider.CacheFailed();
                    }
                }
            }

            return expired;
        }
    }
}

