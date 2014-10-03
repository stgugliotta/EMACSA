using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Gobbi.CoreServices.ExceptionHandling.Instrumentation
{
    class ExceptionHandlingPerformanceCounterManager: Common.Instrumentation.PerformanceCounterManager, IDisposable
    {
        #region Factory

        /// <summary>
        /// Variable privada para el manejo de la propiedad
        /// </summary>
        private readonly static ExceptionHandlingPerformanceCounterManager _instance = new ExceptionHandlingPerformanceCounterManager();

        /// <summary>
        /// Singleton para manejar una sola instancia
        /// </summary>
        public static ExceptionHandlingPerformanceCounterManager Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region Private Vars

        private PerformanceCounter _exceptionHandledTotal;
        private PerformanceCounter _exceptionHandledPerSec;
        private PerformanceCounter _exceptionHandlerExecutedTotal;
        private PerformanceCounter _exceptionHandlerExecutedPerSec;
        private PerformanceCounter _exceptionHandlingErrorOccurredInvalidConfigurationTotal;
        private PerformanceCounter _exceptionHandlingErrorOccurredInvalidConfigurationPerSec;

        #endregion

        #region Constructors

        /// <summary>
        /// Este constructor crea las categorias necesaria para los performance counters
        /// </summary>
        /// <remarks>
        /// El constructor es privado por que los clientes de esta clase solo acceden a una instancia a través de la propiedad <seealso cref="Instance"/>
        /// </remarks>
        private ExceptionHandlingPerformanceCounterManager()
        {
            Common.Instrumentation.InstrumentationInstaller.CreateExceptionHandlingPerformanceCounters();

            base.InitializePerformanceCounter(ref _exceptionHandledTotal,
                                  Common.Instrumentation.Constants.
                                      ExceptionHandlingExceptionHandledTotalName,
                                      Common.Instrumentation.Constants.ExceptionHandlingCategory);

            base.InitializePerformanceCounter(ref _exceptionHandledPerSec,
                                  Common.Instrumentation.Constants.
                                      ExceptionHandlingExceptionHandledPerSecName,
                                      Common.Instrumentation.Constants.ExceptionHandlingCategory);

            base.InitializePerformanceCounter(ref _exceptionHandlerExecutedTotal,
                                              Common.Instrumentation.Constants.
                                                  ExceptionHandlingExceptionHandlerExecutedTotalName,
                                                  Common.Instrumentation.Constants.ExceptionHandlingCategory);

            base.InitializePerformanceCounter(ref _exceptionHandlerExecutedPerSec,
                                  Common.Instrumentation.Constants.
                                      ExceptionHandlingExceptionHandlerExecutedPerSecName,
                                      Common.Instrumentation.Constants.ExceptionHandlingCategory);

            base.InitializePerformanceCounter(ref _exceptionHandlingErrorOccurredInvalidConfigurationTotal,
                      Common.Instrumentation.Constants.
                          ExceptionHandlingExceptionHandlingErrorOccurredInvalidConfigurationTotalName,
                          Common.Instrumentation.Constants.ExceptionHandlingCategory);

            base.InitializePerformanceCounter(ref _exceptionHandlingErrorOccurredInvalidConfigurationPerSec,
          Common.Instrumentation.Constants.
              ExceptionHandlingExceptionHandlingErrorOccurredInvalidConfigurationPerSecName,
              Common.Instrumentation.Constants.ExceptionHandlingCategory);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementExceptionHandledCounter()
        {
            this.IncrementPerformanceCounter(_exceptionHandledTotal);
            this.IncrementPerformanceCounter(_exceptionHandledPerSec);
        }

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementExceptionHandlerExecutedCounter()
        {
            this.IncrementPerformanceCounter(_exceptionHandlerExecutedTotal);
            this.IncrementPerformanceCounter(_exceptionHandlerExecutedPerSec);
        }

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementExceptionHandlingErrorOccurredInvalidConfigurationCounter()
        {
            this.IncrementPerformanceCounter(_exceptionHandlingErrorOccurredInvalidConfigurationTotal);
            this.IncrementPerformanceCounter(_exceptionHandlingErrorOccurredInvalidConfigurationPerSec);
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
            this.DisposePerformanceCounter(ref _exceptionHandledTotal);
            this.DisposePerformanceCounter(ref _exceptionHandledPerSec);
            this.DisposePerformanceCounter(ref _exceptionHandlerExecutedTotal);
            this.DisposePerformanceCounter(ref _exceptionHandlerExecutedPerSec);
            this.DisposePerformanceCounter(ref _exceptionHandlingErrorOccurredInvalidConfigurationTotal);
            this.DisposePerformanceCounter(ref _exceptionHandlingErrorOccurredInvalidConfigurationPerSec);

            if (disposing)
                GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destructor de la clase
        /// </summary>
        ~ExceptionHandlingPerformanceCounterManager()
        {
            Dispose(false);
        }

        #endregion
    }
}
