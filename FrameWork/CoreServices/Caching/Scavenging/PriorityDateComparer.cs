using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.Caching.Scavenging
{
    /// <summary>
    /// Ordena los cacheItems para la limpieza.
    /// </summary>
    public class PriorityDateComparer : IComparer
    {
        private Hashtable unsortedItems;

        /// <summary>
        /// Incializa una nueva instancia con una lista de CacheItems desordenada.
        /// </summary>
        /// <param name="unsortedItems">
        /// Una lista de CacheItems desordenada.
        /// </param>
        public PriorityDateComparer(Hashtable unsortedItems)
        {
            this.unsortedItems = unsortedItems;
        }

        /// <summary>
        /// Compara dos objetos <see cref="CacheItem"/> y devuelve un valor indicando cuando uno en menor 
        /// que, igual a o mayor que el otro en order de prioridad y fecha y hora.
        /// </summary>
        /// <param name="x">
        /// Primer <see cref="CacheItem"/> a comparar.
        /// </param>
        /// <param name="y">
        /// Segundo <see cref="CacheItem"/> a comparar.
        /// </param>
        /// <returns>
        /// <list type="table">
        /// <listheader>
        /// <term>Valor</term>
        /// <description>Condición</description>
        /// </listheader>
        /// <item>
        /// <term>Menor que cero.</term>
        /// <description><paramref name="x"/> es menor que <paramref name="y"/></description>
        /// </item>
        /// <item>
        /// <term>cero.</term>
        /// <description><paramref name="x"/> es igual a <paramref name="y"/></description>
        /// </item>
        /// <item>
        /// <term>mayor que cero.</term>
        /// <description><paramref name="x"/> es mayor que <paramref name="y"/></description>
        /// </item>
        /// </list>
        /// </returns>
        public int Compare(object x, object y)
        {
            CacheItem leftCacheItem = (CacheItem)unsortedItems[(string)x];
            CacheItem rightCacheItem = (CacheItem)unsortedItems[(string)y];

            lock (rightCacheItem)
            {
                lock (leftCacheItem)
                {
                    if (rightCacheItem == null && leftCacheItem == null)
                    {
                        return 0;
                    }
                    if (leftCacheItem == null)
                    {
                        return -1;
                    }
                    if (rightCacheItem == null)
                    {
                        return 1;
                    }

                    return leftCacheItem.ScavengingPriority == rightCacheItem.ScavengingPriority
                        ? leftCacheItem.LastAccessedTime.CompareTo(rightCacheItem.LastAccessedTime)
                        : leftCacheItem.ScavengingPriority - rightCacheItem.ScavengingPriority;
                }
            }
        }
    }
}
