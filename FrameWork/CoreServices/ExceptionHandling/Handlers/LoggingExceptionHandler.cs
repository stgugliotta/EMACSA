using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Logging;

namespace Gobbi.CoreServices.ExceptionHandling.Handlers
{
    /// <summary>
    /// Genera entradas de log a partir de la excepción.
    /// </summary>
    public class LoggingExceptionHandler :IExceptionHandler
    {
        private int priority = Constants.LoggingException_DefaultPriority;
        private string title = Constants.LoggingException_DefaultTitle;
        private string category;

        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public LoggingExceptionHandler()
        {

        }

        /// <summary>
        /// A partir de la Excepción y del ID de instancia de manejo, genera una entrada en el log.
        /// </summary>
        /// <param name="ex">La <see cref="EvaException"/> a procesar.</param>
        /// <returns>Una <see cref="EvaException"/>.</returns>
        public EvaException HandleException(EvaException ex)
        {
            LogEntry log = new LogEntry();
            log.Severity = System.Diagnostics.TraceEventType.Error;
            Exception exToWrite = ex;
            StringBuilder sbMessage = new StringBuilder();
            while (exToWrite != null)
            {
                WriteExToString(exToWrite, sbMessage);
                exToWrite = exToWrite.InnerException;
            }
            log.Message = sbMessage.ToString();
            log.Priority = this.priority;
            log.Title = this.title;
            if (!string.IsNullOrEmpty(this.category))
                log.Categories.Add(this.category);
            //Not used for generate another exception.
            Logger.Write(log);
            return null;
        }

        private static void WriteExToString(Exception exToWrite, StringBuilder sbMessage)
        {
            string id = string.Empty;
            EvaException e = exToWrite as EvaException;
            if (e  != null)
            {
                id = e.HandlingInstanceID.ToString();
            }

            sbMessage.AppendLine(Constants.LoggingException_ID +" " + id );
            sbMessage.AppendLine(Constants.LoggingException_Exception + " " + exToWrite.GetType());
            sbMessage.AppendLine(Constants.LoggingException_Message + " " + exToWrite.Message);
            sbMessage.AppendLine(Constants.LoggingException_StackTrace+ " " + exToWrite.StackTrace);
            sbMessage.AppendLine(Constants.LoggingException_Context+":");
            if(e != null)
            {
                IEnumerator<KeyValuePair<string,object>> iEnumerator = e.Context.GetEnumerator();
                while (iEnumerator.MoveNext())
                {
                    sbMessage.AppendLine(iEnumerator.Current.Key + ": " + iEnumerator.Current.Value);
                }
            }
        }

        /// <summary>
        /// Incializa el objeto con su elemento de configuración.
        /// </summary>
        /// <param name="element">Elemento de configuración.</param> 
        public void Configure(ConfigurationElement element)
        {
            DynamicConfigurationElement dce = (DynamicConfigurationElement)element;
            string sPriority = dce.GetPropertyValue("priority");
            if (!string.IsNullOrEmpty(sPriority))
            {
                this.priority = Convert.ToInt32(sPriority);
            }
            string titleTemp = dce.GetPropertyValue("title");
            if (!string.IsNullOrEmpty(titleTemp))
                this.title = titleTemp;
            this.category = dce.GetPropertyValue("category");
        }
    }
}
