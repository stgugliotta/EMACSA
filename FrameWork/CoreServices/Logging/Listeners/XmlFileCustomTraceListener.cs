using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Logging.Instrumentation;
using Gobbi.CoreServices.Properties;

namespace Gobbi.CoreServices.Logging.Listeners
{
    /// <summary>
    /// Implementación de <see cref="CustomTraceListener"/> para guardar registros en la un archivo xml.
    /// </summary>
    public class XmlFileCustomTraceListener : CustomTraceListener
    {
        private string fileName;
        /// <summary>
        /// Nombre del archivo destino.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
        }

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="name">Nombre de la instancia.</param>
        public XmlFileCustomTraceListener(string name)
            :base(name)
        {

        }

        /// <summary>
        /// Graba el la entrada de log.
        /// </summary>
        /// <param name="log">Entrada de log a grabar.</param>
        public override void Write(LogEntry log)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(this.fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof (LogEntry));
                    serializer.Serialize(writer, log);
                    InstrumentationProvider.TraceListenerEntryWritten();
                }
            }
            catch 
            {
                InstrumentationProvider.FailureLoggingError();
            }
        }

        /// <summary>
        /// Entrega al objeto su elemento de configuración.
        /// </summary>
        /// <param name="element">Elemento de configuración para el objeto.</param>
        public override void Configure(System.Configuration.ConfigurationElement element)
        {
            DynamicConfigurationElement dce = (DynamicConfigurationElement)element;
            this.fileName = dce.GetPropertyValue("fileName");
        }
    }
}
