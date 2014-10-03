using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Logging.Configuration;
using Gobbi.CoreServices.Logging.Instrumentation;
using Gobbi.CoreServices.Logging.Listeners;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Logging
{
    internal class LogSourceFactory
    {
        static object lockSyncObject = new object ();
        static Dictionary<string,LogSource> logSources = new Dictionary<string,LogSource>();

        public static Dictionary<string, LogSource> LogSources
        {
            get
            {
                return logSources;
            }
        }

        static LogSourceFactory()
        {
            lock (lockSyncObject)
            {
                Init();
            }
        }
        public static void Init()
        {
            try
            {
                
            LoggingConfigurationSection section = LoggingConfigurationSection.GetInstance();
            if (section == null)
                 throw new GobbiTechnicalException ("", new   System.Configuration.ConfigurationErrorsException(Resources.ERROR_LOGINFILTERFACTORY_CONFIGURATIONNOTFOUND));
            foreach (LogSurceConfigurationElement lsce in section.LogSources)
            {
                List<CustomTraceListener> listeners = new List<CustomTraceListener>();
                foreach (ConfigurationNamedElement cne in lsce.Listeners)
                {
                    listeners.Add(ListenerFactory.CreateListener(cne.Name));
                }
                LogSource logSource = new LogSource(lsce.Name, listeners, lsce.SourceLevels);
                logSources.Add(logSource.CategoryName, logSource);
            }
        }
            catch
            {
                InstrumentationProvider.ConfigurationFailure();
                
            }
        }
    }
}
