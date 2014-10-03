using System;
using System.Collections.Generic;
using System.Text;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Configuration
{
    public class EvaConfigurationException : EvaException
    {
        public EvaConfigurationException(string message)
            : base(message, new Dictionary<string, object>(), null)
        {
        }

        public EvaConfigurationException(string message, Exception innerException)
            : base(message, new Dictionary<string, object>(), innerException)
        {
        }
    }
}
