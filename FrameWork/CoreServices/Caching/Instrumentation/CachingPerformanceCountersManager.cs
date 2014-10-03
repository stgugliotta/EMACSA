using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Gobbi.CoreServices.Caching.Instrumentation
{
    internal class CachingPerformanceCountersManager: Common.Instrumentation.PerformanceCounterManager, IDisposable
    {
        #region Factory

        /// <summary>
        /// Variable privada para el manejo de la propiedad
        /// </summary>
        private readonly static CachingPerformanceCountersManager _instance = new CachingPerformanceCountersManager();

        /// <summary>
        /// Singleton para manejar una sola instancia
        /// </summary>
        public static CachingPerformanceCountersManager Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region Private Vars

        private PerformanceCounter _cacheUpdatedTotal;
        private PerformanceCounter _cacheUpdatedPerSec;
        private PerformanceCounter _cacheAccessedTotal;
        private PerformanceCounter _cacheAccessedPerSec;
        private PerformanceCounter _cacheExpiredTotal;
        private PerformanceCounter _cacheExpiredPerSec;
        private PerformanceCounter _cacheFailedTotal;
        private PerformanceCounter _cacheFailedPerSec;
        private PerformanceCounter _cacheScavengedTotal;
        private PerformanceCounter _cacheScavengedPerSec;

        #endregion

        #region Constructors

        /// <summary>
        /// Este constructor crea las categorias necesaria para los performance counters
        /// </summary>
        /// <remarks>
        /// El constructor es privado por que los clinetes de esta clase solo acceden a una instancia atravez de la propiedad <seealso cref="Instance"/>
        /// </remarks>
        private CachingPerformanceCountersManager()
        {
            Common.Instrumentation.InstrumentationInstaller.CreateCachingPerformanceCounters();

            base.InitializePerformanceCounter(ref _cacheUpdatedTotal,
                                              Common.Instrumentation.Constants.
                                                  CachingCacheUpdatedTotalName,
                                                  Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheUpdatedPerSec,
                                              Common.Instrumentation.Constants.CachingCacheUpdatedPerSecName,
                                                  Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheAccessedTotal,
                                  Common.Instrumentation.Constants.CachingCacheAccessedTotalName,
                                      Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheAccessedPerSec,
                      Common.Instrumentation.Constants.CachingCacheAccessedPerSecName,
                          Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheExpiredTotal,
                      Common.Instrumentation.Constants.CachingCacheExpiredTotalName,
                          Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheExpiredPerSec,
                      Common.Instrumentation.Constants.CachingcacheExpiredPerSecName,
                          Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheFailedTotal,
                      Common.Instrumentation.Constants.CachingCacheFailedTotalName,
                          Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheFailedPerSec,
          Common.Instrumentation.Constants.CachingCacheFailedPerSecName,
              Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheScavengedTotal,
          Common.Instrumentation.Constants.CachingCacheScavengedTotalName,
              Common.Instrumentation.Constants.CachingCategory);

            base.InitializePerformanceCounter(ref _cacheScavengedPerSec,
          Common.Instrumentation.Constants.CachingCacheScavengedPerSecName,
              Common.Instrumentation.Constants.CachingCategory);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementCacheUpdatedCounter()
        {
            this.IncrementPerformanceCounter(_cacheUpdatedTotal);
            this.IncrementPerformanceCounter(_cacheUpdatedPerSec);
        }

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementCacheAccessedCounter()
        {
            this.IncrementPerformanceCounter(_cacheAccessedTotal);
            this.IncrementPerformanceCounter(_cacheAccessedPerSec);
        }

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementCacheExpiredCounter()
        {
            this.IncrementPerformanceCounter(_cacheExpiredTotal);
            this.IncrementPerformanceCounter(_cacheExpiredPerSec);
        }

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementCacheFailedCounter()
        {
            this.IncrementPerformanceCounter(_cacheFailedTotal);
            this.IncrementPerformanceCounter(_cacheFailedPerSec);
        }

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementCacheScavengedCounter()
        {
            this.IncrementPerformanceCounter(_cacheScavengedTotal);
            this.IncrementPerformanceCounter(_cacheScavengedPerSec);
        }

        #endregion

          #region Dispose-Finalize Pattern

        /// <summary>
        /// Cuando se llama a ese metodo se produce la eliminacion del objeto en memoria
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Cuando se llama a ese metodo se produce la eliminacion del objeto en memoria
        /// </summary>
        /// <param name="disposing">Si es True elimina de memoria los recursos no manejados y llama GC.SuppressFinalize( this )</param>
        protected virtual void Dispose(bool disposing)
        {
            this.DisposePerformanceCounter(ref _cacheUpdatedTotal);
            this.DisposePerformanceCounter(ref _cacheUpdatedPerSec);
            this.DisposePerformanceCounter(ref _cacheAccessedTotal);
            this.DisposePerformanceCounter(ref _cacheAccessedPerSec);
            this.DisposePerformanceCounter(ref _cacheExpiredTotal);
            this.DisposePerformanceCounter(ref _cacheExpiredPerSec);
            this.DisposePerformanceCounter(ref _cacheFailedTotal);
            this.DisposePerformanceCounter(ref _cacheFailedPerSec);
            this.DisposePerformanceCounter(ref _cacheScavengedTotal);
            this.DisposePerformanceCounter(ref _cacheScavengedPerSec);

            if (disposing)
                GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destructor de la clase
        /// </summary>
        ~CachingPerformanceCountersManager()
        {
            Dispose(false);
        }

        #endregion
    }
}
