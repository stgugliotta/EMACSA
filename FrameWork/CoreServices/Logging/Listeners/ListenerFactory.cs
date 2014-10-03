using System;
using System.Collections.Generic;
using System.Text;
using Gobbi.CoreServices.Logging.Configuration;
using Gobbi.CoreServices.Logging.Instrumentation;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Logging.Listeners
{
    /// <summary>
    /// Genera instancias de listeners a partir de la configuración. 
    /// </summary>
    /// <remarks>No debe es llamada por el usuario explicitamente.</remarks>
    public static class ListenerFactory
    {
        private static object lockSyncObj = new object();
        private static Dictionary<string, CustomTraceListener> customTraceListeners =
            new Dictionary<string, CustomTraceListener>();

        /// <summary>
        /// Genera un Listener definido en configuración a partir de su nombre.
        /// </summary>
        /// <param name="name">Nombre de Listener en la configuración.</param>
        /// <returns>Un Listener pedido.</returns>
        public static CustomTraceListener CreateListener(string name)
        {
            try
            {
                
            LoggingConfigurationSection section = LoggingConfigurationSection.GetInstance();
            if (section == null)
                throw new GobbiTechnicalException ("", new  System.Configuration.ConfigurationErrorsException(
                    Resources.ERROR_LOGINFILTERFACTORY_CONFIGURATIONNOTFOUND));
            foreach (ListenerConfigurationElement lce in section.Listeners)
            {
                if (lce.Name == name)
                {
                    string[]  parameters = new string[] { lce.Name };
                    if (!string.IsNullOrEmpty(lce.InitializeData))

             parameters = new string[] { lce.Name , lce.InitializeData };

                    CustomTraceListener customTraceListener;
                    lock (lockSyncObj)
                    {
                        if (!customTraceListeners.ContainsKey(name))
                        {
                            customTraceListener =
                                (CustomTraceListener)
                                ConfigurableObjectFactory.Create(lce.Type, lce, parameters);
                            customTraceListeners.Add(name, customTraceListener);
                        }
                        else
                            customTraceListener = customTraceListeners[name];
                    }
                    return customTraceListener;
                }
            }
            throw new GobbiTechnicalException ("", new  System.Configuration.ConfigurationErrorsException(
                string.Format(Resources.ERROR_LOGINLISTENERFACTORY_CONFIGURATIONLISTENERNOTFOUND, name)));
            }
            catch 
            {
                InstrumentationProvider.ConfigurationFailure();
                return null;
            }
        }
    }
}
