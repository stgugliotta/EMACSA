using System;
using System.Collections;
using System.Text;
using ar.com.telecom.eva.CoreServices.Caching.CacheManagers;
using ar.com.telecom.eva.CoreServices.Caching.Instrumentation;
using ar.com.telecom.eva.CoreServices.Properties;

namespace ar.com.telecom.eva.CoreServices.Caching.Scavenging
{
    /// <summary>
    /// Representa una tarea para comenzar a limpiar ítems en una implementación de <see cref="RealCache"/>.
    /// </summary>
    public class ScavengerTask
    {
        private CacheCapacityScavengingPolicy scavengingPolicy;
        private readonly int numberToRemoveWhenScavenging;
        private RealCache cacheManager;

        /// <summary>
        /// Incializa una nueva instancia de <see cref="ScavengerTask"/>.
        /// </summary>
        /// <param name="numberToRemoveWhenScavenging">El número de ítems deben ser eliminados del cache cuando 
        /// se realiza una limpieza.</param>
        /// <param name="scavengingPolicy">La instancia de <see cref="CacheCapacityScavengingPolicy"/> a usar.</param>
        /// <param name="realCache">El <see cref="RealCache"/> a limpiar.</param>
        public ScavengerTask(int numberToRemoveWhenScavenging,
                               CacheCapacityScavengingPolicy scavengingPolicy,
                               RealCache realCache)
        {
            this.numberToRemoveWhenScavenging = numberToRemoveWhenScavenging;
            this.scavengingPolicy = scavengingPolicy;
            this.cacheManager = realCache;
        }

        /// <summary>
        /// Realiza la limpieza.
        /// </summary>
        public void DoScavenging()
        {
            if (NumberOfItemsToBeScavenged == 0) return;

            Hashtable liveCacheRepresentation = cacheManager.CurrentCacheState;

            int currentNumberItemsInCache = liveCacheRepresentation.Count;

            if (scavengingPolicy.IsScavengingNeeded(currentNumberItemsInCache))
            {
                ResetScavengingFlagInCacheItems(liveCacheRepresentation);
                SortedList scavengableItems = SortItemsForScavenging(liveCacheRepresentation);
                RemoveScavengableItems(scavengableItems);
            }
        }

        private static void ResetScavengingFlagInCacheItems(Hashtable liveCacheRepresentation)
        {
            foreach (CacheItem cacheItem in liveCacheRepresentation.Values)
            {
                lock (cacheItem)
                {
                    cacheItem.MakeEligibleForScavenging();
                }
            }
        }

        private static SortedList SortItemsForScavenging(Hashtable unsortedItemsInCache)
        {
            return new SortedList(unsortedItemsInCache, new PriorityDateComparer(unsortedItemsInCache));
        }

        private int NumberOfItemsToBeScavenged
        {
            get { return this.numberToRemoveWhenScavenging; }
        }

        private void RemoveScavengableItems(SortedList scavengableItems)
        {
            int scavengedItemCount = 0;
            foreach (CacheItem scavengableItem in scavengableItems.Values)
            {
                bool wasRemoved = RemoveItemFromCache(scavengableItem);
                if (wasRemoved)
                {
                    scavengedItemCount++;
                    if (scavengedItemCount == NumberOfItemsToBeScavenged)
                    {
                        break;
                    }
                }
            }
            InstrumentationProvider.CacheScavenged();
        }

        private bool RemoveItemFromCache(CacheItem itemToRemove)
        {
            lock (itemToRemove)
            {
                if (itemToRemove.EligibleForScavenging)
                {
                    try
                    {
                        cacheManager.Remove(itemToRemove.Key);
                        return true;
                    }
                    catch 
                    {
                        InstrumentationProvider.CacheFailed();
                    }
                }
            }

            return false;
        }
    }
}
