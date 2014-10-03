using System;
using System.Collections.Generic;
using System.Text;
using ar.com.telecom.eva.CoreServices.Logging.Configuration;
using ar.com.telecom.eva.CoreServices.Logging.Instrumentation;
using ar.com.telecom.eva.CoreServices.Properties;
using ar.com.telecom.eva.CoreServices.Configuration;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Logging.Filters
{
    /// <summary>
    /// Genera y administra todo los <see cref="ILogFilter"/>.
    /// </summary>
    public static class FilterFactory
    {
        private static ILogFilter[] filters;
        private static object syncObject = new object();

        #region Public Methods

        /// <summary>
        /// Retorna los filtros indicados en la confiugración.
        /// </summary>
        public static ILogFilter[] Filters
        {
            get { return filters; }
        }

        static FilterFactory()
        {
            lock (syncObject)
            { Init(); }
        }

        private static void Init()
        {
            try
            {
                List<ILogFilter> filterList = new List<ILogFilter>();
                LoggingConfigurationSection section = LoggingConfigurationSection.GetInstance();
                if (section == null)
                    throw new EvaTechnicalException ("", new  System.Configuration.ConfigurationErrorsException(
                        Resources.ERROR_LOGINFILTERFACTORY_CONFIGURATIONNOTFOUND));

                foreach (FilterConfigurationElement fce in section.Filters)
                {
                    string[] parameters = new string[] {fce.Name};
                    ILogFilter iLogFilter =
                        (ILogFilter) ConfigurableObjectFactory.Create(fce.Type, fce, parameters);
                    filterList.Add(iLogFilter);
                }

                filters = filterList.ToArray();
            }
            catch 
            {
                InstrumentationProvider.ConfigurationFailure();
            }
        }


        #endregion



    }
}
