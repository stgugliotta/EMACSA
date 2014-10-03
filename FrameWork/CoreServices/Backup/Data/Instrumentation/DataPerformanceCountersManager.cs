using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Data.Instrumentation
{
    class DataPerformanceCountersManager : Common.Instrumentation.PerformanceCounterManager, IDisposable
    {
        #region Factory

        /// <summary>
        /// Variable privada para el manejo de la propiedad
        /// </summary>
        private readonly static DataPerformanceCountersManager _instance = new DataPerformanceCountersManager();

        /// <summary>
        /// Singleton para manejar una sola instancia
        /// </summary>
        public static DataPerformanceCountersManager Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region Private Vars

        private PerformanceCounter _commandExecutedTotal;
        private PerformanceCounter _commandExecutedPerSec;
        private PerformanceCounter _averageCommandExecutedTotal;
        private PerformanceCounter _averageCommandExecutedTotalBase;
        private PerformanceCounter _commandFailedTotal;
        private PerformanceCounter _commandFailedPerSec;
        private PerformanceCounter _connectionOpenedTotal;
        private PerformanceCounter _connectionOpenedPerSec;
        private PerformanceCounter _connectionFailedTotal;
        private PerformanceCounter _connectionFailedPerSec;

        #endregion

        #region Constructors

        /// <summary>
        /// Este constructor crea las categorias necesaria para los performance counters
        /// </summary>
        /// <remarks>
        /// El constructor es privado por que los clinetes de esta clase solo acceden a una instancia atravez de la propiedad <seealso cref="Instance"/>
        /// </remarks>
        private DataPerformanceCountersManager()
        {
            Common.Instrumentation.InstrumentationInstaller.CreateDataPerformanceCounters();

            this.InitializePerformanceCounter(ref _commandExecutedTotal,
                                              Common.Instrumentation.Constants.DataCommandExecutedTotalName,
                                              Common.Instrumentation.Constants.DataCategory);

            this.InitializePerformanceCounter(ref _commandExecutedPerSec,
                                              Common.Instrumentation.Constants.DataCommandExecutedPerSecName,
                                              Common.Instrumentation.Constants.DataCategory);

            this.InitializePerformanceCounter(ref _averageCommandExecutedTotal,
                                              Common.Instrumentation.Constants.DataAverageCommandExecutedTotalName,
                                              Common.Instrumentation.Constants.DataCategory);


            this.InitializePerformanceCounter(ref _averageCommandExecutedTotalBase,
                                              Common.Instrumentation.Constants.DataAverageCommandExecutedTotalBaseName,
                                              Common.Instrumentation.Constants.DataCategory);

            this.InitializePerformanceCounter(ref _commandFailedTotal,
                                              Common.Instrumentation.Constants.DataCommandFailedTotalName,
                                              Common.Instrumentation.Constants.DataCategory);

            this.InitializePerformanceCounter(ref _commandFailedPerSec,
                                              Common.Instrumentation.Constants.DataCommandFailedPerSecName,
                                              Common.Instrumentation.Constants.DataCategory);

            this.InitializePerformanceCounter(ref _connectionOpenedTotal,
                                              Common.Instrumentation.Constants.DataConnectionOpenedTotalName,
                                              Common.Instrumentation.Constants.DataCategory);

            this.InitializePerformanceCounter(ref _connectionOpenedPerSec,
                                              Common.Instrumentation.Constants.DataConnectionOpenedPerSecName,
                                              Common.Instrumentation.Constants.DataCategory);

            this.InitializePerformanceCounter(ref _connectionFailedTotal,
                                              Common.Instrumentation.Constants.DataConnectionFailedTotalName,
                                              Common.Instrumentation.Constants.DataCategory);

            this.InitializePerformanceCounter(ref _connectionFailedPerSec,
                                  Common.Instrumentation.Constants.DataConnectionFailedPerSecName,
                                  Common.Instrumentation.Constants.DataCategory);

        }

        #endregion

        #region Public Methods

        internal void IncrementCommandExecutedCounter(long ticks)
        {
            base.IncrementPerformanceCounter(this._commandExecutedTotal);
            base.IncrementPerformanceCounter(this._commandExecutedPerSec);
            base.IncrementPerformanceCounter(this._averageCommandExecutedTotal, ticks);
            base.IncrementPerformanceCounter(this._averageCommandExecutedTotalBase);
        }

        internal void IncrementCommandFailedCounter()
        {
            base.IncrementPerformanceCounter(this._commandFailedTotal);
            base.IncrementPerformanceCounter(this._commandFailedPerSec);
        }

        internal void IncrementConnectionOpenedCounter()
        {
            base.IncrementPerformanceCounter(this._connectionOpenedTotal);
            base.IncrementPerformanceCounter(this._connectionOpenedPerSec);
        }

        internal void IncrementConnectionFailedCounter()
        {
            base.IncrementPerformanceCounter(this._connectionFailedTotal);
            base.IncrementPerformanceCounter(this._connectionOpenedPerSec);
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
            base.DisposePerformanceCounter(ref _commandExecutedTotal);
            base.DisposePerformanceCounter(ref _commandExecutedPerSec);
            base.DisposePerformanceCounter(ref _averageCommandExecutedTotal);
            base.DisposePerformanceCounter(ref _averageCommandExecutedTotalBase);
            base.DisposePerformanceCounter(ref _commandFailedTotal);
            base.DisposePerformanceCounter(ref _commandFailedPerSec);
            base.DisposePerformanceCounter(ref _connectionOpenedTotal);
            base.DisposePerformanceCounter(ref _connectionOpenedPerSec);
            base.DisposePerformanceCounter(ref _connectionFailedTotal);
            base.DisposePerformanceCounter(ref _connectionFailedPerSec);

            if (disposing)
                GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destructor de la clase
        /// </summary>
        ~DataPerformanceCountersManager()
        {
            Dispose(false);
        }

        #endregion
    }
}
