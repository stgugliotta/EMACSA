using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Gobbi.CoreServices.ExceptionHandling;
using Gobbi.CoreServices.Properties;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace Gobbi.CoreServices.Configuration
{
    /// <summary>
    /// Implementa la lectura de <see cref="ConfigurationSection"/> desde una Base de Datos.
    /// </summary>
    public class SQLConfigurationSource : IConfigurationSource
    {
        #region Constantes
        /// <summary>
        /// Nombre del atributo de configuración con el path completo al archivo externo
        /// </summary>
        private const string CatalogNameConfigurationAttributeName = "catalogName";

        private const string GetStoredProcedure = "EvaConfiguration_GetSection";
        #endregion

        #region Private Fields
        /// <summary>
        /// Archivo externo de configuración
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Caché de secciones de configuración
        /// </summary>
        private Dictionary<string, SerializableConfigurationSection> configurationSectionCache = new Dictionary<string, SerializableConfigurationSection>();

        /// <summary>
        /// Objeto para Sincronizar acceso a la caché
        /// </summary>
        private object syncObject = new object();
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public SQLConfigurationSource()
        {

        }

        #region Properties

        /// <summary>
        /// Muestra la cadena de conexión a la base de datos.
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Inicializa el proveedor de configuración en función de parámetros de configuración.
        /// </summary>
        /// <param name="configurationElement">Elemento de configuración.</param>
        public void Init(ConfigurationSourceElement configurationElement)
        {
            if(configurationElement == null)
                throw new GobbiTechnicalException ("", new  ArgumentNullException("configurationElement"));

            string catalogName = configurationElement.GetPropertyValue(CatalogNameConfigurationAttributeName);
            if(string.IsNullOrEmpty(catalogName))
                throw new GobbiTechnicalException ("", new  ConfigurationErrorsException(Resources.ERROR_SQLCONFIGURATIONSOURCE_CATALOGNAMENOTSPECIFIED));

            ConnectionStringSettings connectionStringSettings = 
                System.Configuration.ConfigurationManager.ConnectionStrings[catalogName];

            if(connectionStringSettings == null)
                throw new GobbiTechnicalException ("", new ConfigurationErrorsException(string.Format(Resources.ERROR_SQLCONFIGURATIONSOURCE_CATALOGNAMENOTFOUND, catalogName)));
            
            connectionString = connectionStringSettings.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
                throw new GobbiTechnicalException ("", new  ConfigurationErrorsException(Resources.ERROR_SQLCONFIGURATIONSOURCE_CATALOGNAMENOTSPECIFIED));
        }
        
        /// <summary>
        /// <para> Dado el nombre de la sección retorna la sección de configuración correspondiente. </para>
        /// </summary>
        /// <param name="sectionName">Nombre de la sección.</param>
        /// <returns>La sección de configuración pedida.</returns>
        public object GetSection(string sectionName)
        {
            lock(syncObject)
            {
                if(this.configurationSectionCache.ContainsKey(sectionName))
                    return this.configurationSectionCache[sectionName];

                SerializableConfigurationSection configSection = GetSectionFromDatabase(sectionName);
                this.configurationSectionCache.Add(sectionName, configSection);

                return configSection;
            }
        }

        #endregion

        #region Private Methods

        private SerializableConfigurationSection GetSectionFromDatabase(string sectionName)
        {
            string xmlData;
            string configSectionType;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Create Instance of Connection and Command Object
                    SqlCommand getCommand = new SqlCommand(GetStoredProcedure, connection);
                    getCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameterSectionName = new SqlParameter(@"@SectionName", SqlDbType.NVarChar);
                    parameterSectionName.Value = sectionName;
                    getCommand.Parameters.Add(parameterSectionName);

                    // Execute the command
                    connection.Open();
                    using(SqlDataReader sqlReader = getCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if(!sqlReader.Read())
                            return null;

                        configSectionType = sqlReader.IsDBNull(0) ? null : sqlReader.GetString(0);
                        xmlData = sqlReader.IsDBNull(0) ? null : sqlReader.GetString(1);
                    }
                }
                catch(SqlException sqlException)
                {
                    string errorMessage = String.Format(Resources.ERROR_SQLDATABASE_NOTSQLCOMMAND, sectionName);
                    throw new ConfigurationErrorsException(errorMessage, sqlException);
                }
            }

            if(string.IsNullOrEmpty(xmlData))
                return null;

            SerializableConfigurationSection configSection =
                (SerializableConfigurationSection)Activator.CreateInstance(Type.GetType(configSectionType));

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CloseInput = true;
            using(System.IO.StringReader stringReader = new System.IO.StringReader(xmlData.Trim()))
            {
                using(XmlReader reader = XmlReader.Create(stringReader, settings))
                {
                    configSection.ReadXml(reader);
                    reader.Close();
                }
                stringReader.Close();
            }

            return configSection;
        }

        #endregion

        /// <summary>
        /// Permite configurar al objeto con su elemento de configuración correspondiente.
        /// </summary>
        /// <param name="element">Elemento de configuración.</param>
        public void Configure(ConfigurationElement element)
        {
            this.Init((ConfigurationSourceElement)element);
        }
    }
}
