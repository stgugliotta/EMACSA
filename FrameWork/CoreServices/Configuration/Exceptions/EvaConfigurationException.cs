using System;
using System.Collections.Generic;
using System.Text;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Configuration
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
