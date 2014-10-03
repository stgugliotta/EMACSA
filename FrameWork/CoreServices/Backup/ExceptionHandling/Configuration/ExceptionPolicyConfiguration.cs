using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using ar.com.telecom.eva.CoreServices.Configuration;

namespace ar.com.telecom.eva.CoreServices.ExceptionHandling.Configuration
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
