using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Text;
using ar.com.telecom.eva.CoreServices.Logging.Configuration;

namespace ar.com.telecom.eva.CoreServices.Common.Instrumentation
{
    /// <summary>
    /// Genera los Performance counters. Al registrarse el assembly en el sistema.
    /// </summary>
    [RunInstaller(true)]
    public class InstrumentationInstaller : Installer
    {
        #region Constants

        private const string General = "Services Invocation Framework";

        #endregion

        #region Private Vars

        private System.ComponentModel.Container components;
        private static bool EnablePerformanceCounters;
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public InstrumentationInstaller()
        {
            LoggingConfigurationSection lcs = LoggingConfigurationSection.GetInstance();
            if (lcs != null)
                EnablePerformanceCounters = lcs.PerformanceCountersEnabled;
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        /// <summary>
        /// Descarga los objetos instanciados por la componente
        /// </summary>
        /// <param name="disposing">indica si se deben descargar los objetos</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (components != null)
                        components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion

        #region Events


        /// <summary>
        /// Crea los performance counters con sus categorías.
        /// </summary>
        /// <param name="stateSaver"> Es pasado por el sistema e indicia el estado de la instalación</param>
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            CreateCachingPerformanceCounters();
            CreateDataPerformanceCounters();
            CreateExceptionHandlingPerformanceCounters();
            CreateLoggingPerformanceCounters();

        }

        /// <summary>
        /// Elimina los performance counters con sus categorías.
        /// </summary>
        /// <param name="savedState">Es pasado por el sistema e indicia el estado de la instalación</param>
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            DeletePerformanceCounters();
        }

        #endregion


        internal static void CreateDataPerformanceCounters()
        {

            if (EnablePerformanceCounters)
            {
                //Si no existe la categoria para los contadores generales la creo
                if (!PerformanceCounterCategory.Exists(Constants.DataCategory))
                {
                    CounterCreationDataCollection counters = new CounterCreationDataCollection();

                    CounterCreationData commandExecutedTotal = new CounterCreationData();
                    commandExecutedTotal.CounterName = Constants.DataCommandExecutedTotalName;
                    commandExecutedTotal.CounterHelp = "Número total de comandos ejecutados";
                    commandExecutedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(commandExecutedTotal);

                    CounterCreationData commandExecutedPerSec = new CounterCreationData();
                    commandExecutedPerSec.CounterName = Constants.DataCommandExecutedPerSecName;
                    commandExecutedPerSec.CounterHelp = "Número de comandos ejecutados por segundo";
                    commandExecutedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(commandExecutedPerSec);

                    CounterCreationData averageCommandExecutedTotal = new CounterCreationData();
                    averageCommandExecutedTotal.CounterName = Constants.DataAverageCommandExecutedTotalName;
                    averageCommandExecutedTotal.CounterHelp = "Duración promedia de los comandos ejecutados";
                    averageCommandExecutedTotal.CounterType = PerformanceCounterType.AverageTimer32;
                    counters.Add(averageCommandExecutedTotal);

                    CounterCreationData averageCommandExecutedTotalBase = new CounterCreationData();
                    averageCommandExecutedTotalBase.CounterName = Constants.DataAverageCommandExecutedTotalBaseName;
                    averageCommandExecutedTotalBase.CounterHelp = "Base de duración promedio de los comandos ejecutados";
                    averageCommandExecutedTotalBase.CounterType = PerformanceCounterType.AverageBase;
                    counters.Add(averageCommandExecutedTotalBase);

                    CounterCreationData commandFailedTotal = new CounterCreationData();
                    commandFailedTotal.CounterName = Constants.DataCommandFailedTotalName;
                    commandFailedTotal.CounterHelp = "Número total de comandos que fallaron en su ejecución.";
                    commandFailedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(commandFailedTotal);

                    CounterCreationData commandFailedPerSec = new CounterCreationData();
                    commandFailedPerSec.CounterName = Constants.DataCommandFailedPerSecName;
                    commandFailedPerSec.CounterHelp = "Número de comandos que fallaron en su ejecución por segundo";
                    commandFailedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(commandFailedPerSec);

                    CounterCreationData connectionOpenedTotal = new CounterCreationData();
                    connectionOpenedTotal.CounterName = Constants.DataConnectionOpenedTotalName;
                    connectionOpenedTotal.CounterHelp = "Número total de conexiones abiertas";
                    connectionOpenedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(connectionOpenedTotal);

                    CounterCreationData connectionOpenedPerSec = new CounterCreationData();
                    connectionOpenedPerSec.CounterName = Constants.DataConnectionOpenedPerSecName;
                    connectionOpenedPerSec.CounterHelp = "Número de conexiones abiertas por segundo";
                    connectionOpenedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(connectionOpenedPerSec);

                    CounterCreationData connectionFailedTotal = new CounterCreationData();
                    connectionFailedTotal.CounterName = Constants.DataConnectionFailedTotalName;
                    connectionFailedTotal.CounterHelp =
                        "Número total de conexiones que fallaron al intentar abrirse";
                    connectionFailedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(connectionFailedTotal);

                    CounterCreationData connectionFailedPerSec = new CounterCreationData();
                    connectionFailedPerSec.CounterName = Constants.DataConnectionFailedPerSecName;
                    connectionFailedPerSec.CounterHelp =
                        "Número de conexiones que fallaron al intentar abrirse por segundo";
                    connectionFailedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(connectionFailedPerSec);

                    //Creo la categoria con los contadores previamente mencioandos
                    PerformanceCounterCategory.Create(Constants.DataCategory, Constants.DataCategoryHelp,
                        PerformanceCounterCategoryType.MultiInstance, counters);
                }
            }
        }
        /*
        internal static void CreateConfigurationPerformanceCounters()
        {
            //Si no existe la categoria para los contadores generales la creo
            if (!PerformanceCounterCategory.Exists(Constants.ConfigurationCategory))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection();

                CounterCreationData configurationSectionRetrievedTotal = new CounterCreationData();
                configurationSectionRetrievedTotal.CounterName = Constants.ConfigurationConfigurationSectionRetrievedTotalName;
                configurationSectionRetrievedTotal.CounterHelp =
                    "Número total de secciones configuración cargadas desde almacenamiento satisfactoriamente.";
                configurationSectionRetrievedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                counters.Add(configurationSectionRetrievedTotal);

                CounterCreationData configurationSectionRetrievedPerSecond = new CounterCreationData();
                configurationSectionRetrievedPerSecond.CounterName =
                    Constants.ConfigurationConfigurationSectionRetrievedPerSecondName;
                configurationSectionRetrievedPerSecond.CounterHelp =
                    "Número de secciones configuración cargadas desde almacenamiento satisfactoriamente por segundo.";
                configurationSectionRetrievedPerSecond.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                counters.Add(configurationSectionRetrievedPerSecond);

                CounterCreationData configurationSectionRetrieveFailedTotal = new CounterCreationData();
                configurationSectionRetrieveFailedTotal.CounterName =
                    Constants.ConfigurationConfigurationSectionRetrieveFailedTotalName;
                configurationSectionRetrieveFailedTotal.CounterHelp =
                    "Número total de secciones configuración que no se pudieron cargadas desde almacenamiento satisfactoriamente.";
                configurationSectionRetrieveFailedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                counters.Add(configurationSectionRetrieveFailedTotal);

                CounterCreationData dynamicPropertyRetrievedTotal = new CounterCreationData();
                dynamicPropertyRetrievedTotal.CounterName = Constants.ConfigurationDynamicPropertyRetrievedTotalName;
                dynamicPropertyRetrievedTotal.CounterHelp =
                    "Número total de propiedades dinámicas que se obtuvieron desde los elementos de configuración.";
                dynamicPropertyRetrievedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                counters.Add(dynamicPropertyRetrievedTotal);

                CounterCreationData dynamicPropertyRetrieveFailedTotal = new CounterCreationData();
                dynamicPropertyRetrieveFailedTotal.CounterName =
                    Constants.ConfigurationDynamicPropertyRetrieveFailedTotalName;
                dynamicPropertyRetrieveFailedTotal.CounterHelp =
                    "Número total de propiedades dinámicas que no se obtuvieron desde los elementos de configuración.";
                dynamicPropertyRetrieveFailedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                counters.Add(dynamicPropertyRetrieveFailedTotal);


                //Creo la categoria con los contadores previamente mencioandos
                PerformanceCounterCategory.Create(Constants.ConfigurationCategory, Constants.ConfigurationCategoryHelp, PerformanceCounterCategoryType.MultiInstance, counters);
            }

        }
        */
        internal static void CreateExceptionHandlingPerformanceCounters()
        {
            if (EnablePerformanceCounters)
            {
                //Si no existe la categoria para los contadores generales la creo
                if (!PerformanceCounterCategory.Exists(Constants.ExceptionHandlingCategory))
                {
                    CounterCreationDataCollection counters = new CounterCreationDataCollection();

                    CounterCreationData exceptionHandledTotal = new CounterCreationData();
                    exceptionHandledTotal.CounterName = Constants.ExceptionHandlingExceptionHandledTotalName;
                    exceptionHandledTotal.CounterHelp =
                        "Número total de excepciones manejadas";
                    exceptionHandledTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(exceptionHandledTotal);

                    CounterCreationData exceptionHandledPerSec = new CounterCreationData();
                    exceptionHandledPerSec.CounterName =
                        Constants.ExceptionHandlingExceptionHandledPerSecName;
                    exceptionHandledPerSec.CounterHelp =
                        "Número de excepciones manejadas por segundo";
                    exceptionHandledPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(exceptionHandledPerSec);

                    CounterCreationData exceptionHandlerExecutedTotal = new CounterCreationData();
                    exceptionHandlerExecutedTotal.CounterName = Constants.ExceptionHandlingExceptionHandlerExecutedTotalName;
                    exceptionHandlerExecutedTotal.CounterHelp =
                        "Número total de manejadores de excepción ejecutados";
                    exceptionHandlerExecutedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(exceptionHandlerExecutedTotal);

                    CounterCreationData exceptionHandlerExecutedPerSec = new CounterCreationData();
                    exceptionHandlerExecutedPerSec.CounterName =
                        Constants.ExceptionHandlingExceptionHandlerExecutedPerSecName;
                    exceptionHandlerExecutedPerSec.CounterHelp =
                        "Número de manejadores de excepción ejecutados por segundo";
                    exceptionHandlerExecutedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(exceptionHandlerExecutedPerSec);

                    CounterCreationData exceptionHandlingErrorOccurredInvalidConfigurationTotal = new CounterCreationData();
                    exceptionHandlingErrorOccurredInvalidConfigurationTotal.CounterName =
                        Constants.ExceptionHandlingExceptionHandlingErrorOccurredInvalidConfigurationTotalName;
                    exceptionHandlingErrorOccurredInvalidConfigurationTotal.CounterHelp =
                        "Número total de errores por configuración incorrecta de manejadores de excepción";
                    exceptionHandlingErrorOccurredInvalidConfigurationTotal.CounterType =
                        PerformanceCounterType.NumberOfItems32;
                    counters.Add(exceptionHandlingErrorOccurredInvalidConfigurationTotal);

                    CounterCreationData exceptionHandlingErrorOccurredInvalidConfigurationPerSec = new CounterCreationData();
                    exceptionHandlingErrorOccurredInvalidConfigurationPerSec.CounterName =
                        Constants.ExceptionHandlingExceptionHandlingErrorOccurredInvalidConfigurationPerSecName;
                    exceptionHandlingErrorOccurredInvalidConfigurationPerSec.CounterHelp =
                        "Número de errores por configuración incorrecta de manejadores de excepción por segundo";
                    exceptionHandlingErrorOccurredInvalidConfigurationPerSec.CounterType =
                        PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(exceptionHandlingErrorOccurredInvalidConfigurationPerSec);

                    //Creo la categoria con los contadores previamente mencioandos
                    PerformanceCounterCategory.Create(Constants.ExceptionHandlingCategory,
                                                      Constants.ExceptionHandlingCategoryHelp,
                                                      PerformanceCounterCategoryType.MultiInstance, counters);
                }
            }
        }

        internal static void CreateLoggingPerformanceCounters()
        {
            if (EnablePerformanceCounters)
            {
                //Si no existe la categoria para los contadores generales la creo
                if (!PerformanceCounterCategory.Exists(Constants.LoggingCategory))
                {
                    CounterCreationDataCollection counters = new CounterCreationDataCollection();

                    CounterCreationData traceListenerEntryWrittenTotal = new CounterCreationData();
                    traceListenerEntryWrittenTotal.CounterName = Constants.LoggingTraceListenerEntryWrittenTotalName;
                    traceListenerEntryWrittenTotal.CounterHelp =
                        "Número total de registros creados por los TraceListener en los medio de almacenamieto";
                    traceListenerEntryWrittenTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(traceListenerEntryWrittenTotal);

                    CounterCreationData traceListenerEntryWrittenPerSec = new CounterCreationData();
                    traceListenerEntryWrittenPerSec.CounterName = Constants.LoggingTraceListenerEntryWrittenPerSecName;
                    traceListenerEntryWrittenPerSec.CounterHelp =
                        "Número total de registros creados por los TraceListener en los medio de almacenamieto por seg";
                    traceListenerEntryWrittenPerSec.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(traceListenerEntryWrittenPerSec);

                    CounterCreationData failureLoggingErrorTotal = new CounterCreationData();
                    failureLoggingErrorTotal.CounterName = Constants.LoggingFailureLoggingErrorTotalName;
                    failureLoggingErrorTotal.CounterHelp =
                        "Número total fallas de los TraceListener al escribir la entrada al medio de almacenamieto";
                    failureLoggingErrorTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(failureLoggingErrorTotal);

                    CounterCreationData failureLoggingErrorPerSec = new CounterCreationData();
                    failureLoggingErrorPerSec.CounterName = Constants.LoggingFailureLoggingErrorPerSecName;
                    failureLoggingErrorPerSec.CounterHelp =
                        "Número fallas de los TraceListener al escribir la entrada al medio de almacenamieto por segundo";
                    failureLoggingErrorPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(failureLoggingErrorPerSec);

                    CounterCreationData configurationFailureTotal = new CounterCreationData();
                    configurationFailureTotal.CounterName = Constants.LoggingConfigurationFailureTotalName;
                    configurationFailureTotal.CounterHelp =
                        "Número total de errores producidos al intentar obtener valores de configuración";
                    configurationFailureTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(configurationFailureTotal);

                    CounterCreationData configurationFailurePerSec = new CounterCreationData();
                    configurationFailurePerSec.CounterName = Constants.LoggingConfigurationFailurePerSecName;
                    configurationFailurePerSec.CounterHelp =
                        "Número de errores producidos al intentar obtener valores de configuración por segundo";
                    configurationFailurePerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(configurationFailurePerSec);

                    CounterCreationData logEventRaisedTotal = new CounterCreationData();
                    logEventRaisedTotal.CounterName = Constants.LoggingLogEventRaisedTotalName;
                    logEventRaisedTotal.CounterHelp =
                        "Número total de entradas de log generadas por la aplicación, antes de ser filtradas y almacenadas";
                    logEventRaisedTotal.CounterType =
                        PerformanceCounterType.NumberOfItems32;
                    counters.Add(logEventRaisedTotal);

                    CounterCreationData logEventRaisedPerSec = new CounterCreationData();
                    logEventRaisedPerSec.CounterName = Constants.LoggingLogEventRaisedPerSecName;
                    logEventRaisedPerSec.CounterHelp =
                        "Número de entradas de log generadas por la aplicación, antes de ser filtradas y almacenadas por segundo";
                    logEventRaisedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(logEventRaisedPerSec);

                    CounterCreationData threadWriterStatusErrorTotal = new CounterCreationData();
                    threadWriterStatusErrorTotal.CounterName = Constants.LoggingThreadWriterStatusErrorTotalName;
                    threadWriterStatusErrorTotal.CounterHelp =
                        "Número total de fallos producidos en el thread escrituras de entradas de log";
                    threadWriterStatusErrorTotal.CounterType =
                        PerformanceCounterType.NumberOfItems32;
                    counters.Add(threadWriterStatusErrorTotal);

                    CounterCreationData threadWriterStatusErrorPerSec = new CounterCreationData();
                    threadWriterStatusErrorPerSec.CounterName = Constants.LoggingThreadWriterStatusErrorPerSecName;
                    threadWriterStatusErrorPerSec.CounterHelp =
                        "Número total de fallos producidos en el thread escrituras de entradas de log";
                    threadWriterStatusErrorPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(threadWriterStatusErrorPerSec);

                    //Creo la categoria con los contadores previamente mencionados
                    PerformanceCounterCategory.Create(Constants.LoggingCategory,
                                                      Constants.LoggingCategoryHelp,
                                                      PerformanceCounterCategoryType.MultiInstance, counters);
                }
            }
        }

        internal static void CreateCachingPerformanceCounters()
        {
            if (EnablePerformanceCounters)
            {
                //Si no existe la categoria para los contadores generales la creo
                if (!PerformanceCounterCategory.Exists(Constants.CachingCategory))
                {
                    CounterCreationDataCollection counters = new CounterCreationDataCollection();

                    CounterCreationData cachingCacheUpdatedTotal = new CounterCreationData();
                    cachingCacheUpdatedTotal.CounterName = Constants.CachingCacheUpdatedTotalName;
                    cachingCacheUpdatedTotal.CounterHelp =
                        "Número total de actualizaciones a ítems de las distintas instancias de cache";
                    cachingCacheUpdatedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(cachingCacheUpdatedTotal);

                    CounterCreationData cachingCacheUpdatedPerSec = new CounterCreationData();
                    cachingCacheUpdatedPerSec.CounterName = Constants.CachingCacheUpdatedPerSecName;
                    cachingCacheUpdatedPerSec.CounterHelp = "Número de actualizaciones a ítems  de cache por segundo";
                    cachingCacheUpdatedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(cachingCacheUpdatedPerSec);

                    CounterCreationData cacheAccessedTotal = new CounterCreationData();
                    cacheAccessedTotal.CounterName = Constants.CachingCacheAccessedTotalName;
                    cacheAccessedTotal.CounterHelp = "Número total de ítems de cache pedidos";
                    cacheAccessedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(cacheAccessedTotal);

                    CounterCreationData cacheAccessedPerSec = new CounterCreationData();
                    cacheAccessedPerSec.CounterName = Constants.CachingCacheAccessedPerSecName;
                    cacheAccessedPerSec.CounterHelp = "Número de ítems de cache pedidos por segundo";
                    cacheAccessedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(cacheAccessedPerSec);

                    CounterCreationData cacheExpiredTotal = new CounterCreationData();
                    cacheExpiredTotal.CounterName = Constants.CachingCacheExpiredTotalName;
                    cacheExpiredTotal.CounterHelp =
                        "Número total de ítems que fueron quitados por haber vencido";
                    cacheExpiredTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(cacheExpiredTotal);

                    CounterCreationData cacheExpiredPerSec = new CounterCreationData();
                    cacheExpiredPerSec.CounterName = Constants.CachingcacheExpiredPerSecName;
                    cacheExpiredPerSec.CounterHelp =
                        "Número total de ítems que fueron quitados por haber vencido por segundo";
                    cacheExpiredPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(cacheExpiredPerSec);

                    CounterCreationData cacheFailedTotal = new CounterCreationData();
                    cacheFailedTotal.CounterName = Constants.CachingCacheFailedTotalName;
                    cacheFailedTotal.CounterHelp =
                        "Número total fallos ocurridos en las intancias de cache";
                    cacheFailedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(cacheFailedTotal);

                    CounterCreationData cacheFailedPerSec = new CounterCreationData();
                    cacheFailedPerSec.CounterName = Constants.CachingCacheFailedPerSecName;
                    cacheFailedPerSec.CounterHelp =
                        "Número de fallos ocurridos en las intancias de cache por segundo";
                    cacheFailedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(cacheFailedPerSec);

                    CounterCreationData cacheScavengedTotal = new CounterCreationData();
                    cacheScavengedTotal.CounterName = Constants.CachingCacheScavengedTotalName;
                    cacheScavengedTotal.CounterHelp =
                        "Número total barridos de limpieza hechos a a las intancias de cache";
                    cacheScavengedTotal.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(cacheScavengedTotal);

                    CounterCreationData cacheScavengedPerSec = new CounterCreationData();
                    cacheScavengedPerSec.CounterName = Constants.CachingCacheScavengedPerSecName;
                    cacheScavengedPerSec.CounterHelp =
                        "Número total barridos de limpieza hechos a a las intancias de cache por segundo";
                    cacheScavengedPerSec.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                    counters.Add(cacheScavengedPerSec);

                    //Creo la categoria con los contadores previamente mencionados
                    PerformanceCounterCategory.Create(Constants.CachingCategory,
                                                      Constants.CachingCategoryHelp,
                                                      PerformanceCounterCategoryType.MultiInstance, counters);
                }
            }
        }

        internal static void  DeletePerformanceCounters(string categoryName)
        {
            if (EnablePerformanceCounters)
            {
                if (PerformanceCounterCategory.Exists(categoryName))
                    PerformanceCounterCategory.Delete(categoryName);
            }
        }

        internal static void DeletePerformanceCounters()
        {
            if (EnablePerformanceCounters)
            {
                DeletePerformanceCounters(Constants.CachingCategory);
                DeletePerformanceCounters(Constants.ConfigurationCategory);
                DeletePerformanceCounters(Constants.DataCategory);
                DeletePerformanceCounters(Constants.ExceptionHandlingCategory);
                DeletePerformanceCounters(Constants.LoggingCategory);
            }
        }


    }
}
