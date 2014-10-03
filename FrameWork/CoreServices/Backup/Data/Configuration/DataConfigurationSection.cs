using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using ar.com.telecom.eva.CoreServices.Configuration;

namespace ar.com.telecom.eva.CoreServices.Data
{
    /// <summary>
    /// Permite el parseo de la sección XML de configuración.
    /// </summary>
    public class DataConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public DataConfigurationSection()
        {

        }

        /// <summary>
        /// Permite especificar origen de configuración predeterminado.
        /// </summary>
        [ConfigurationProperty("defaultDatabase")]
        public string DefaultDatabase
        {
            get { return (string)base["defaultDatabase"]; }
            set { base["defaultDatabase"] = value; }
        }

        /// <summary>
        /// Permite enumerar las secciones de configuración asociadas a un proveedor.
        /// </summary>
        [ConfigurationProperty("databases")]
        public GenericConfigurationElementCollection<DataConfigurationElement> Databases
        {
            get { return (GenericConfigurationElementCollection<DataConfigurationElement>)base["databases"]; }
            set { base["databases"] = value; }
        }

        
    }
}
