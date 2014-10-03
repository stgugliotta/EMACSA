using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Gobbi.CoreServices.Configuration;

namespace Gobbi.CoreServices.ExceptionHandling.Configuration
{
    class ExceptionHandlingConfigurationSection : ConfigurationSection
    {
        #region Private Fields

        private static object lockSyncObject = new object();
        private static ExceptionHandlingConfigurationSection eHConfiguration = null;

        #endregion

        #region Ctor.

        internal static ExceptionHandlingConfigurationSection GetInstance()
        {
            lock (lockSyncObject)
            {
                if (eHConfiguration == null)
                {
                    eHConfiguration =
                        (ExceptionHandlingConfigurationSection)
                        Gobbi.CoreServices.Configuration.ConfigurationManager.GetSection(
                            Constants.ExceptionHandlingConfigurationSectionName);
                }
            }
            return eHConfiguration;
        }

        #endregion

        #region Properties

        [ConfigurationProperty("defaultPolicy")]
        public string DefaultPolicy
        {
            get { return (string)base["defaultPolicy"]; }
            set { base["defaultPolicy"] = value; }
        }


        [ConfigurationProperty("exceptionPolicies")]
        public GenericConfigurationElementCollection<ExceptionPolicyConfiguration> ExceptionPolicies
        {
            get { return (GenericConfigurationElementCollection<ExceptionPolicyConfiguration>)base["exceptionPolicies"]; }
            set { base["exceptionPolicies"] = value; }
        } 
        #endregion
    }
}
