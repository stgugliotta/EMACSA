using System;
using System.Collections.Generic;
using System.Text;
using Gobbi.CoreServices.Configuration;
using System.Configuration;
using System.ComponentModel;
using Gobbi.CoreServices.Logging.Filters;

namespace Gobbi.CoreServices.Logging.Configuration
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
