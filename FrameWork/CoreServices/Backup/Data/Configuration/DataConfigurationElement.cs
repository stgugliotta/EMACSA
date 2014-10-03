using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using ar.com.telecom.eva.CoreServices.Configuration;

namespace ar.com.telecom.eva.CoreServices.Data
{
    /// <summary>
    /// Permite especificar un proveedor de configuración.
    /// </summary>
    public class DataConfigurationElement : DynamicConfigurationElement 
    {
        /// <summary>
        /// Incializa una nueva instancia.
        /// </summary>
        public DataConfigurationElement()
        {

        }

        /// <summary>
        /// Especifica el tipo del proveedor de configuración asociado.
        /// </summary>
        [ConfigurationProperty("type")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type Type
        {
            get { return (Type)base["type"]; }
            set { base["type"] = value; }
        }


    }
}
