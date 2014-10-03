using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;
using System.ComponentModel;

namespace ar.com.telecom.eva.CoreServices.ExceptionHandling.Configuration
{
    class ExceptionTypeConfiguration : ConfigurationNamedElement
    {

        [ConfigurationProperty("type")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type Type
        {
            get { return (Type)base["type"]; }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("exceptionHandlers")]
        public GenericConfigurationElementCollection<ExceptionHandlerConfiguration> ExceptionHandlers
        {
            get { return (GenericConfigurationElementCollection<ExceptionHandlerConfiguration>)base["exceptionHandlers"]; }
            set { base["exceptionHandlers"] = value; }
        }

        [ConfigurationProperty("postHandlingAction")]
        public PostHandlingAction PostHandlingAction
        {
            get { return (PostHandlingAction)base["postHandlingAction"]; }
            set { base["postHandlingAction"] = value; }
        }
    }
}
