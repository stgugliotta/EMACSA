using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;
using System.ComponentModel;

namespace ar.com.telecom.eva.CoreServices.Logging.Configuration
{
    class ListenerConfigurationElement : DynamicConfigurationElement
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

        [ConfigurationProperty("initializeData", IsRequired= false)]
        public string InitializeData
        {
            get { return (string)base["initializeData"]; }
            set { base["initializeData"] = value; }
        }


    }
}
