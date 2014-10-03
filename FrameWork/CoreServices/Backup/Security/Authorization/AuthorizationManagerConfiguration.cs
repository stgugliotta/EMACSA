using System;
using System.Configuration;
using ar.com.telecom.eva.CoreServices.Configuration;
using System.ComponentModel;

namespace ar.com.telecom.eva.CoreServices.Security.Authorization
{
    class AuthorizationManagerConfiguration : DynamicConfigurationElement
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
