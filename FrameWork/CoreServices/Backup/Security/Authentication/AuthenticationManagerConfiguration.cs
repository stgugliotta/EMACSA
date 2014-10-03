using System;
using System.Configuration;
using ar.com.telecom.eva.CoreServices.Configuration;
using System.ComponentModel;

namespace ar.com.telecom.eva.CoreServices.Security.Authentication
{
    class AuthenticationManagerConfiguration : DynamicConfigurationElement
    {
        [ConfigurationProperty("type")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type Type
        {
            get { return (Type)base["type"]; }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("DefaultDomain")]
        public string DefaultDomain
        {
            get { return (string)base["DefaultDomain"]; }
            set { base["DefaultDomain"] = value; }
        }

        [ConfigurationProperty("ApplicationUsername")]
        public string ApplicationUsername
        {
            get { return (string)base["ApplicationUsername"]; }
            set { base["ApplicationUsername"] = value; }
        }

        [ConfigurationProperty("ApplicationPassword")]
        public string ApplicationPassword
        {
            get { return (string)base["ApplicationPassword"]; }
            set { base["ApplicationPassword"] = value; }
        }

        [ConfigurationProperty("DefaultServer")]
        public string DefaultServer
        {
            get { return (string)base["DefaultServer"]; }
            set { base["DefaultServer"] = value; }
        }

        [ConfigurationProperty("AuthType")]
        public string AuthType
        {
            get { return (string)base["AuthType"]; }
            set { base["AuthType"] = value; }
        }
   }
}
