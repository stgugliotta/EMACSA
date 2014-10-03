using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.Common.Instrumentation
{
    static class Constants
    {
        public const string InstanceTotalName = "_Total";

        #region Data

        //Categoría
        public const string DataCategory = "EVA Core Services Data";
        public const string DataCategoryHelp = "Contadores de EVA Core Services Data";
        //Contadores
        public const string DataCommandExecutedTotalName = "# de comandos ejecutados";
        public const string DataCommandExecutedPerSecName = "# de comandos ejecutados por seg";
        public const string DataAverageCommandExecutedTotalName = "Tiempo promedio por comando ejecutado";
        public const string DataAverageCommandExecutedTotalBaseName = "Base de tiempo promedio comando ejecutado";
        public const string DataCommandFailedTotalName = "# de comandos fallados";
        public const string DataCommandFailedPerSecName = "# de comandos fallados por seg";
        public const string DataConnectionOpenedTotalName = "# de conexiones abiertas";
        public const string DataConnectionOpenedPerSecName = "# de conexiones abiertas por seg";
        public const string DataConnectionFailedTotalName = "# de nuevas conexiones falladas";
        public const string DataConnectionFailedPerSecName = "# de conexiones nuevas falladas por seg";

        #endregion

        #region Configuration
        //Categoría
        public const string ConfigurationCategory = "EVA Core Services Configuration";
        public const string ConfigurationCategoryHelp = "Contadores de EVA Core Services Configuration";
        //Contadores
        public const string ConfigurationConfigurationSectionRetrievedTotalName = "# de secciones de configuración cargadas";
        public const string ConfigurationConfigurationSectionRetrievedPerSecondName = "# de secciones de configuración cargadas por seg";
        public const string ConfigurationConfigurationSectionRetrieveFailedTotalName = "# de secciones de configuración que fallaron";
        public const string ConfigurationDynamicPropertyRetrievedTotalName = "# de propiedades dinámicas obtenidas";
        public const string ConfigurationDynamicPropertyRetrieveFailedTotalName = "# de propiedades dinámicas no obtenidas";

        #endregion

        #region ExceptionHandling

        //Categoría
        public const string ExceptionHandlingCategory = "EVA Core Services Exception Handling";
        public const string ExceptionHandlingCategoryHelp
            = "Contadores de EVA Core Services Exception Handling";
        //Contadores
        public const string ExceptionHandlingExceptionHandledTotalName
    = "# de excepción manejadas";
        public const string ExceptionHandlingExceptionHandledPerSecName
            = "# de excepción manejadas por seg";
        public const string ExceptionHandlingExceptionHandlerExecutedTotalName
            = "# de manejadores de excepción ejecutados";
        public const string ExceptionHandlingExceptionHandlerExecutedPerSecName
            = "# de manejadores de excepción ejecutados por seg";
        public const string ExceptionHandlingExceptionHandlingErrorOccurredInvalidConfigurationTotalName
            = "# de errores de manejadores de excepción";
        public const string ExceptionHandlingExceptionHandlingErrorOccurredInvalidConfigurationPerSecName
            = "# de errores de manejadores de excepción por seg";

        #endregion

        #region Logging
        //Categoría
        public const string LoggingCategory = "EVA Core Services Logging";
        public const string LoggingCategoryHelp
            = "Contadores de EVA Core Services Logging";
        //Contadores
        public const string LoggingFailureLoggingErrorTotalName = "# de fallos al escribir las entradas de log";
        public const string LoggingFailureLoggingErrorPerSecName = "# de fallos al escribir las entradas de log por seg";
        public const string LoggingConfigurationFailureTotalName = "# de fallos al acceder a configuración";
        public const string LoggingConfigurationFailurePerSecName = "# de fallos al acceder a configuración por seg";
        public const string LoggingLogEventRaisedTotalName = "# de entradas de log generadas";
        public const string LoggingLogEventRaisedPerSecName = "# de entradas de log generadas por seg";
        public const string LoggingThreadWriterStatusErrorTotalName =
            "# de de fallos del thread de escritura de entradas";
        public const string LoggingThreadWriterStatusErrorPerSecName =
            "# de de fallos del thread de escritura de entradas por seg";
        public const string LoggingTraceListenerEntryWrittenTotalName = 
            "# de entradas de log registradas en almacenamientos";
                public const string LoggingTraceListenerEntryWrittenPerSecName = 
            "# de entradas de log registradas en almacenamientos por seg";

        #endregion

        #region Caching
                //Categoría
        public const string CachingCategory = "EVA Core Services Caching";
        public const string CachingCategoryHelp
                    = "Contadores de EVA Core Services Caching";
                //Contadores
        public const string CachingCacheUpdatedTotalName = "# de actualizaciones a ítems de cache";
        public const string CachingCacheUpdatedPerSecName = "# de actualizaciones a ítems de cache por seg";
        public const string CachingCacheAccessedTotalName = "# de pedidos de ítems de cache";
        public const string CachingCacheAccessedPerSecName = "# de pedidos de ítems de cache por seg";
        public const string CachingCacheExpiredTotalName = "# de items de cache vencidos";
        public const string CachingcacheExpiredPerSecName = "# de items de cache vencidos por seg";
        public const string CachingCacheFailedTotalName = "# de fallos ocurridos en las intancias de cache";
        public const string CachingCacheFailedPerSecName = "# de fallos ocurridos en las intancias de cache por seg";
        public const string CachingCacheScavengedTotalName = "# de barridos en las instancias de cache";
        public const string CachingCacheScavengedPerSecName = "# de barridos en las instancias de cache por seg";

                #endregion
    }
}
