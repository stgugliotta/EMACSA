using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;
using System.ComponentModel;

namespace ar.com.telecom.eva.CoreServices.ExceptionHandling.Configuration
{
    class ExceptionHandlerConfiguration : DynamicConfigurationElement
    {
        [ConfigurationProperty("type")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type Type
        {
            get { return (Type)base["type"]; }
            set { base["type"] = value; }
        }
    }
}
