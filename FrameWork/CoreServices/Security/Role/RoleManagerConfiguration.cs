using System;
using System.Configuration;
using Gobbi.CoreServices.Configuration;
using System.ComponentModel;

namespace Gobbi.CoreServices.Security.Role
{
    class RoleManagerConfiguration : DynamicConfigurationElement
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
