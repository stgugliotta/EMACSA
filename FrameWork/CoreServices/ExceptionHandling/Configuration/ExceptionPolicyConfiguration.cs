using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Gobbi.CoreServices.Configuration;

namespace Gobbi.CoreServices.ExceptionHandling.Configuration
{
    internal class ExceptionPolicyConfiguration : ConfigurationNamedElement
    {
        [ConfigurationProperty("exceptionTypes")]
        public GenericConfigurationElementCollection<ExceptionTypeConfiguration> ExceptionTypes
        {
            get { return (GenericConfigurationElementCollection<ExceptionTypeConfiguration>)base["exceptionTypes"]; }
            set { base["exceptionTypes"] = value; }
        }
    }
}
