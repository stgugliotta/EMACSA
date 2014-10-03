using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Logging
{
    internal static class Constants
    {
        public const string LoggingConfigurationSectionName = "Eva.Logging";

        /// <summary>
        /// Prioridad para mensajes de traza.
        /// </summary>
        public const int TracerPriority = 5;

        /// <summary>
        /// Identificador de evento para trazas.
        /// </summary>
        public const int TracerEventId = 1;

        /// <summary>
        /// Prioridad para mensajes de información.
        /// </summary>
        public const int InformationPriority = 10;

        /// <summary>
        /// Prioridad para mensajes de advertencia.
        /// </summary>
        public const int WarningPriority = 5;

        /// <summary>
        /// Prioridad para mensajes de error.
        /// </summary>
        public const int ErrorPriority = 1;

        /// <summary>
        /// Title for operation start Trace messages
        /// </summary>
        public const string TracerStartTitle = "Comienzo Tracer";

        /// <summary>
        /// Title for operation end Trace messages
        /// </summary>
        public const string TracerEndTitle = "Salida Tracer";

        public const string ApplicationSource = "EvaLogging";

        public const string FatalErrorDescription = "Hubo un error y no se pudo registrar la entrada de log: ";
    }
}
