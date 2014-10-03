using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Gobbi.CoreServices.Logging.Configuration;

namespace Gobbi.CoreServices.Common.Instrumentation
{
    internal abstract class PerformanceCounterManager
    {
        private const int instanceMaxNameLenght = 125;
        private readonly string _instanceName;

        protected PerformanceCounterManager()
        {
            _instanceName = AppDomain.CurrentDomain.FriendlyName;
            LoggingConfigurationSection lcs = LoggingConfigurationSection.GetInstance();
            if (lcs != null)
                this.EnablePerformanceCounters = lcs.PerformanceCountersEnabled;
        }

        #region Properties

        /// <summary>
        /// Variable privada para el manejo de la propiedad
        /// </summary>
        private bool _enablePerformanceCounters = true;

        /// <summary>
        /// Indica si publican o no los performance counters
        /// </summary>
        public bool EnablePerformanceCounters
        {
            get
            {
                return _enablePerformanceCounters;
            }
            set
            {
                _enablePerformanceCounters = value;
            }
        }

        protected string InstanceName
        {
            get { return _instanceName; }
        }

        #endregion

        protected void InitializePerformanceCounter(ref PerformanceCounter performanceCounter, string name, 
            string category)
        {
            //Solo si estan habilitados creo los performance counters (agregado Ricardo 10/01/2008)
            if (this.EnablePerformanceCounters)
            {
                performanceCounter = new PerformanceCounter();
                performanceCounter.CategoryName = category;
                performanceCounter.CounterName = name;
                performanceCounter.MachineName = ".";
                performanceCounter.ReadOnly = false;
            }
        }

        protected void IncrementPerformanceCounter(PerformanceCounter performanceCounter)
        {
            this.IncrementPerformanceCounter(performanceCounter, this.InstanceName, 1);
        }

        protected void IncrementPerformanceCounter(PerformanceCounter performanceCounter, long value)
        {
            this.IncrementPerformanceCounter(performanceCounter, this.InstanceName, value);
        }

        protected void IncrementPerformanceCounter(PerformanceCounter performanceCounter, string instanceName,
            long value)
        {
            try
            {
                //Solo si estan habilitados utilizo los performance counters
                if (this.EnablePerformanceCounters)
                {
                    //Primero incremento el contador total
                    performanceCounter.InstanceName = Constants.InstanceTotalName;
                    performanceCounter.IncrementBy(value);

                    //Despues configuro el nombre de la aplicación como nombre de la instancia e incremento los contadores
                    if (instanceName.Length > instanceMaxNameLenght)
                        instanceName = instanceName.Substring(instanceName.Length - instanceMaxNameLenght);
                    performanceCounter.InstanceName = instanceName;
                    performanceCounter.IncrementBy(value);
                }
            }
            catch
            {
            }
        }

        protected void DisposePerformanceCounter(ref PerformanceCounter performanceCounter)
        {
            if (performanceCounter != null)
            {
                performanceCounter.Dispose();
                performanceCounter = null;
            }
        }
    }
}
