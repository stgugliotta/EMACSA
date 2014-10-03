using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Logging.Instrumentation;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Logging.Listeners
{
    /// <summary>
    /// Implementación de <see cref="CustomTraceListener"/> para guardar registros en la base de datos.
    /// </summary>
    public class SQLCustomTraceListener : CustomTraceListener
    {
        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="name">Nombre de la instancia.</param>
        public SQLCustomTraceListener(string name)
            : base(name)
        {
        }
        private SqlConnection sqlConn;
        private string connStringName;

        /// <summary>
        /// Graba el la entrada de log.
        /// </summary>
        /// <param name="log">Entrada de log a grabar.</param>
        public override void Write(LogEntry log)
        {
            try
            {
                if (this.sqlConn == null)
                    initSqlConn();

                if (this.sqlConn.State!= ConnectionState.Open)
                                                 this.sqlConn.Open();
                SqlCommand sqlCommand = new SqlCommand(Constants.InsertStoreProcedureName, this.sqlConn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@ActivityId", System.Data.SqlDbType.NVarChar).Value = log.ActivityId.ToString();
                sqlCommand.Parameters.Add("@AppDomainName", System.Data.SqlDbType.NVarChar).Value = log.AppDomainName;
                sqlCommand.Parameters.Add("@Categories", System.Data.SqlDbType.NVarChar).Value = String.Join(",", log.Categories.ToArray());
                sqlCommand.Parameters.Add("@ErrorMessages", System.Data.SqlDbType.NVarChar).Value = log.ErrorMessages;
                sqlCommand.Parameters.Add("@EventId", System.Data.SqlDbType.Int).Value = log.EventId;
                sqlCommand.Parameters.Add("@ExtendedProperties", System.Data.SqlDbType.Xml).Value = SerializeExtendedProperties(log);
                sqlCommand.Parameters.Add("@LoggedSeverity", System.Data.SqlDbType.NVarChar).Value = log.LoggedSeverity;
                sqlCommand.Parameters.Add("@MachineName", System.Data.SqlDbType.NVarChar).Value = log.MachineName;
                sqlCommand.Parameters.Add("@ManagedThreadName", System.Data.SqlDbType.NVarChar).Value = log.ManagedThreadName;
                sqlCommand.Parameters.Add("@Message", System.Data.SqlDbType.NVarChar).Value = log.Message;
                sqlCommand.Parameters.Add("@Priority", System.Data.SqlDbType.Int).Value = log.Priority;
                sqlCommand.Parameters.Add("@ProcessId", System.Data.SqlDbType.NVarChar, 100).Value = log.ProcessId;
                sqlCommand.Parameters.Add("@ProcessName", System.Data.SqlDbType.NVarChar).Value = log.ProcessName;
                sqlCommand.Parameters.Add("@Severity", System.Data.SqlDbType.NVarChar).Value = log.Severity.ToString();
                sqlCommand.Parameters.Add("@TimeStamp", System.Data.SqlDbType.DateTime).Value = log.TimeStamp;
                sqlCommand.Parameters.Add("@Title", System.Data.SqlDbType.NVarChar).Value = log.Title;
                sqlCommand.Parameters.Add("@Win32ThreadId", System.Data.SqlDbType.NVarChar).Value = log.Win32ThreadId;
                sqlCommand.ExecuteNonQuery();
                this.sqlConn.Close();
                InstrumentationProvider.TraceListenerEntryWritten();
            }
            catch
            {
                InstrumentationProvider.FailureLoggingError();
                throw;
            }
        }

        static string SerializeExtendedProperties(LogEntry log)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableDictionary<string, object>));

            serializer.Serialize(writer, log.ExtendedProperties);

            return writer.GetStringBuilder().ToString();
        }

        /// <summary>
        /// Entrega al objeto su elemento de configuración.
        /// </summary>
        /// <param name="element">Elemento de configuración para el objeto.</param>
        public override void Configure(System.Configuration.ConfigurationElement element)
        {
            DynamicConfigurationElement dce = (DynamicConfigurationElement)element;
            this.connStringName = dce.GetPropertyValue("connStringName");
            if (string.IsNullOrEmpty(connStringName))
                throw new GobbiTechnicalException ("", new   System.Configuration.ConfigurationErrorsException(
                    Resources.ERROR_SQLCUSTOMTRACELISTENER_INVALIDCONFIGURATION));

            this.initSqlConn();
        }

        private void initSqlConn()
        {
            System.Configuration.ConnectionStringsSection connectionStringsSection =
                (System.Configuration.ConnectionStringsSection)ConfigurationManager.GetSection("connectionStrings");
            if (connectionStringsSection == null)
                 throw new GobbiTechnicalException ("", new   System.Configuration.ConfigurationErrorsException(
                    string.Format(Resources.ERROR_CONNECTIONSTRINGSSECTION_NULL, connStringName)));
            System.Configuration.ConnectionStringSettings connectionStringSettings =
                connectionStringsSection.ConnectionStrings[connStringName];
            if (string.IsNullOrEmpty(connectionStringSettings.ConnectionString))
                throw new GobbiTechnicalException ("", new  System.Configuration.ConfigurationErrorsException(
                    string.Format(Resources.ERROR_CONNECTIONSTRINGSSECTION_CONNECTIONSTRING_NULL, connStringName)));
            this.sqlConn = new SqlConnection(connectionStringSettings.ConnectionString);
        }
    }
}
