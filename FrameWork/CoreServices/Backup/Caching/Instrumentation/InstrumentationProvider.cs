using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Caching.Instrumentation
{
    static class InstrumentationProvider
    {
        static CachingPerformanceCountersManager pcm;
        static InstrumentationProvider()
        {
            pcm = CachingPerformanceCountersManager.Instance;
        }

        public static void  CacheUpdated()
        {
            pcm.IncrementCacheUpdatedCounter();
        }

        public static void CacheAccessed()
        {
            pcm.IncrementCacheAccessedCounter();
        }

        public static void CacheExpired()
        {
            pcm.IncrementCacheExpiredCounter();
        }

        public static void CacheScavenged()
        {
            pcm.IncrementCacheScavengedCounter();
        }

        public static void CacheFailed()
        {
            pcm.IncrementCacheFailedCounter();
        }
    }
}
