using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;

namespace ar.com.telecom.eva.CoreServices.Logging.Configuration
{
    class LoggingConfigurationSection : ConfigurationSection
    {
        #region Private Fields

        private static object lockSyncObject = new object();
        private static LoggingConfigurationSection loggingConfiguration = null;

        #endregion

        #region Ctor.

        internal static LoggingConfigurationSection GetInstance()
        {
            lock (lockSyncObject)
            {
                if (loggingConfiguration == null)
                {
                    loggingConfiguration =
                        (LoggingConfigurationSection)
                        ar.com.telecom.eva.CoreServices.Configuration.ConfigurationManager.GetSection(
                            Constants.LoggingConfigurationSectionName);
                }
            }
            return loggingConfiguration;
        }

        #endregion

        [ConfigurationProperty("loggingEnabled")]
        public bool LoggingEnabled
        {
            get { return (bool)base["loggingEnabled"]; }
            set { base["loggingEnabled"] = value; }
        }

        [ConfigurationProperty("performanceCountersEnabled", IsRequired= false, DefaultValue=true)]
        public bool PerformanceCountersEnabled
        {
            get { return (bool)base["performanceCountersEnabled"]; }
            set { base["performanceCountersEnabled"] = value; }
        }

        [ConfigurationProperty("tracingEnabled")]
        public bool TracingEnabled
        {
            get { return (bool)base["tracingEnabled"]; }
            set { base["tracingEnabled"] = value; }
        }

        [ConfigurationProperty("defaultCategory")]
        public string DefaultCategory
        {
            get { return (string)base["defaultCategory"]; }
            set { base["defaultCategory"] = value; }
        }

        [ConfigurationProperty("filters")]
        public GenericConfigurationElementCollection<FilterConfigurationElement> Filters
        {
            get { return (GenericConfigurationElementCollection<FilterConfigurationElement>)base["filters"]; }
            set { base["filters"] = value; }
        }

        [ConfigurationProperty("listeners")]
        public GenericConfigurationElementCollection<ListenerConfigurationElement> Listeners
        {
            get { return (GenericConfigurationElementCollection<ListenerConfigurationElement>)base["listeners"]; }
            set { base["listeners"] = value; }
        }

        [ConfigurationProperty("categorySources")]
        public GenericConfigurationElementCollection<LogSurceConfigurationElement> LogSources
        {
            get { return (GenericConfigurationElementCollection<LogSurceConfigurationElement>)base["categorySources"]; }
            set { base["categorySources"] = value; }
        }
    }
}
