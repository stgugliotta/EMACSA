using System;
using System.Collections.Generic;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;
using System.Configuration;
using System.ComponentModel;
using ar.com.telecom.eva.CoreServices.Logging.Filters;

namespace ar.com.telecom.eva.CoreServices.Logging.Configuration
{
    internal class FilterConfigurationElement : DynamicConfigurationElement
    {

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
