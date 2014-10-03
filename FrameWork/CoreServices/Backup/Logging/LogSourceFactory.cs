using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;
using ar.com.telecom.eva.CoreServices.Logging.Configuration;
using ar.com.telecom.eva.CoreServices.Logging.Instrumentation;
using ar.com.telecom.eva.CoreServices.Logging.Listeners;
using ar.com.telecom.eva.CoreServices.Properties;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Logging
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
                 throw new EvaTechnicalException ("", new   System.Configuration.ConfigurationErrorsException(Resources.ERROR_LOGINFILTERFACTORY_CONFIGURATIONNOTFOUND));
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
