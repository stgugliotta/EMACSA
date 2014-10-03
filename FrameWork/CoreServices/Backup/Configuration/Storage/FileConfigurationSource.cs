using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using ar.com.telecom.eva.CoreServices.Properties;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;


namespace ar.com.telecom.eva.CoreServices.Configuration
{
    /// <summary>
    /// Implementa la lectura de <see cref="ConfigurationSection"/> desde archivos del Sistema de Archivos.
    /// </summary>
    public class FileConfigurationSource : IConfigurationSource
    {
        #region Constants
        /// <summary>
        /// Nombre del atributo de configuración con el path completo al archivo externo
        /// </summary>
        private const string FileNameConfigurationAttributeName = "fileName";
        #endregion

        #region Private Fields
        /// <summary>
        /// Archivo externo de configuración
        /// </summary>
        private string fileName;

        /// <summary>
        /// Configuración externa
        /// </summary>
        private System.Configuration.Configuration externalConfiguration;
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public FileConfigurationSource()
        {

        }

        /// <summary>
        /// Inicializa el proveedor de configuración en función de parámetros de configuración.
        /// </summary>
        /// <param name="configurationElement">Elemento de configuración.</param>
        public void Init(ConfigurationSourceElement configurationElement)
        {
            if(configurationElement == null)
                throw new EvaTechnicalException ("", new   ArgumentNullException("configurationElement"));

            fileName = configurationElement.GetPropertyValue(FileNameConfigurationAttributeName);
            
            if(string.IsNullOrEmpty(fileName))
               throw new EvaTechnicalException ("", new ConfigurationErrorsException(Resources.ERROR_FILECONFIGURATIONSOURCE_FILENAME_NOTSPECIFIEDINCONFIGURATION));
            if(!File.Exists(fileName))
                throw new EvaTechnicalException ("", new FileNotFoundException(string.Format(Resources.ERROR_FILECONFIGURATIONSOURCE_FILENOTFOUND, fileName), fileName));

            externalConfiguration = SystemConfigurationManager.OpenExeConfiguration(fileName);
        }

        /// <summary>
        /// <para> Dado el nombre de la sección retorna la sección de configuración correspondiente. </para>
        /// </summary>
        /// <param name="sectionName">Nombre de la sección.</param>
        /// <returns>La sección de configuración pedida.</returns>
        public object GetSection(string sectionName)
        {
            return externalConfiguration.GetSection(sectionName);
        }

        /// <summary>
        /// Archivo externo de configuración
        /// </summary>
        public string FileName
        {
            get { return fileName; }
        }

        /// <summary>
        /// Permite configurar al objeto con su elemento de configuración correspondiente.
        /// </summary>
        /// <param name="element">Elemento de configuración.</param>
        public void Configure(ConfigurationElement element)
        {
            this.Init((ConfigurationSourceElement) element);
        }
    }
}
