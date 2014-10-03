using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Logging.Instrumentation
{
    class LoggingPerformanceCounterManager: Common.Instrumentation.PerformanceCounterManager, IDisposable
    {
        #region Factory

        /// <summary>
        /// Variable privada para el manejo de la propiedad
        /// </summary>
        private readonly static LoggingPerformanceCounterManager _instance = new LoggingPerformanceCounterManager();

        /// <summary>
        /// Singleton para manejar una sola instancia
        /// </summary>
        public static LoggingPerformanceCounterManager Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region Private Vars

        private PerformanceCounter _traceListenerEntryWrittenTotal;
        private PerformanceCounter _traceListenerEntryWrittenPerSec;
        private PerformanceCounter _failureLoggingErrorTotal;
        private PerformanceCounter _failureLoggingErrorPerSec;
        private PerformanceCounter _configurationFailureTotal;
        private PerformanceCounter _configurationFailurePerSec;
        private PerformanceCounter _logEventRaisedTotal;
        private PerformanceCounter _logEventRaisedPerSec;
        private PerformanceCounter _threadWriterStatusErrorTotal;
        private PerformanceCounter _threadWriterStatusErrorPerSec;

        #endregion

        #region Constructors

        /// <summary>
        /// Este constructor crea las categorias necesaria para los performance counters
        /// </summary>
        /// <remarks>
        /// El constructor es privado por que los clinetes de esta clase solo acceden a una instancia a través de la propiedad <seealso cref="Instance"/>
        /// </remarks>
        private LoggingPerformanceCounterManager()
        {
            Common.Instrumentation.InstrumentationInstaller.CreateLoggingPerformanceCounters();

                        base.InitializePerformanceCounter(ref _traceListenerEntryWrittenTotal,
                                              Common.Instrumentation.Constants.
                                                  LoggingTraceListenerEntryWrittenTotalName,
                                                  Common.Instrumentation.Constants.LoggingCategory);

                        base.InitializePerformanceCounter(ref _traceListenerEntryWrittenPerSec,
                                              Common.Instrumentation.Constants.
                                                  LoggingTraceListenerEntryWrittenPerSecName,
                                                  Common.Instrumentation.Constants.LoggingCategory);

            base.InitializePerformanceCounter(ref _failureLoggingErrorTotal,
                                              Common.Instrumentation.Constants.
                                                  LoggingFailureLoggingErrorTotalName,
                                                  Common.Instrumentation.Constants.LoggingCategory);
            
            base.InitializePerformanceCounter(ref _failureLoggingErrorPerSec,
                                              Common.Instrumentation.Constants.
                                                  LoggingFailureLoggingErrorPerSecName,
                                                  Common.Instrumentation.Constants.LoggingCategory);

                        base.InitializePerformanceCounter(ref _configurationFailureTotal,
                                              Common.Instrumentation.Constants.
                                                  LoggingConfigurationFailureTotalName,
                                                  Common.Instrumentation.Constants.LoggingCategory);
            base.InitializePerformanceCounter(ref _configurationFailurePerSec,
                                              Common.Instrumentation.Constants.
                                                  LoggingConfigurationFailurePerSecName,
                                                  Common.Instrumentation.Constants.LoggingCategory);
                        base.InitializePerformanceCounter(ref _logEventRaisedTotal,
                                              Common.Instrumentation.Constants.
                                                  LoggingLogEventRaisedTotalName,
                                                  Common.Instrumentation.Constants.LoggingCategory);

                        base.InitializePerformanceCounter(ref _logEventRaisedPerSec,
                                              Common.Instrumentation.Constants.
                                                  LoggingLogEventRaisedPerSecName,
                                                  Common.Instrumentation.Constants.LoggingCategory);
            
                        base.InitializePerformanceCounter(ref _threadWriterStatusErrorTotal,
                                              Common.Instrumentation.Constants.
                                                  LoggingThreadWriterStatusErrorTotalName,
                                                  Common.Instrumentation.Constants.LoggingCategory);
            
                        base.InitializePerformanceCounter(ref _threadWriterStatusErrorPerSec,
                                              Common.Instrumentation.Constants.
                                                  LoggingThreadWriterStatusErrorPerSecName,
                                                  Common.Instrumentation.Constants.LoggingCategory);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementTraceListenerEntryWrittenCounter()
        {
            this.IncrementPerformanceCounter(_traceListenerEntryWrittenTotal);
            this.IncrementPerformanceCounter(_traceListenerEntryWrittenPerSec);
        }

                /// <summary>
        /// Incrementa el contador
        /// </summary>
        public void IncrementFailureLoggingErrorCounter()
        {
            this.IncrementPerformanceCounter(_failureLoggingErrorTotal);
            this.IncrementPerformanceCounter(_failureLoggingErrorPerSec);
        }

        
                /// <summary>
        /// Incrementa el contador
        /// </summary>
                public void IncrementConfigurationFailureCounter()
                {
                    this.IncrementPerformanceCounter(_configurationFailureTotal);
                    this.IncrementPerformanceCounter(_configurationFailurePerSec);
                }

        /// <summary>
        /// Incrementa el contador
        /// </summary>
                public void IncrementLogEventRaisedCounter()
        {
            this.IncrementPerformanceCounter(_logEventRaisedTotal);
            this.IncrementPerformanceCounter(_logEventRaisedPerSec);
        }

                        /// <summary>
        /// Incrementa el contador
        /// </summary>
                public void IncrementThreadWriterStatusErrorCounter()
        {
            this.IncrementPerformanceCounter(_threadWriterStatusErrorTotal);
            this.IncrementPerformanceCounter(_threadWriterStatusErrorPerSec);
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
            this.DisposePerformanceCounter(ref _traceListenerEntryWrittenTotal);
            this.DisposePerformanceCounter(ref _traceListenerEntryWrittenPerSec);
            this.DisposePerformanceCounter(ref _failureLoggingErrorTotal);
            this.DisposePerformanceCounter(ref _failureLoggingErrorPerSec);
            this.DisposePerformanceCounter(ref _configurationFailureTotal);
            this.DisposePerformanceCounter(ref _configurationFailurePerSec);
            this.DisposePerformanceCounter(ref _logEventRaisedTotal);
            this.DisposePerformanceCounter(ref _logEventRaisedPerSec);
            this.DisposePerformanceCounter(ref _threadWriterStatusErrorTotal);
            this.DisposePerformanceCounter(ref _threadWriterStatusErrorPerSec);

            if (disposing)
                GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destructor de la clase
        /// </summary>
        ~LoggingPerformanceCounterManager()
        {
            Dispose(false);
        }

        #endregion
    }
}
