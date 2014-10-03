using System.Configuration;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Properties;

namespace Gobbi.CoreServices.Caching.Configuration
{
    class CachingConfigurationSection: ConfigurationSection
    {
        #region Private Fields

        private static object lockSyncObject = new object();
        private static CachingConfigurationSection cachingConfigurationSection = null;

        #endregion

        internal static CachingConfigurationSection GetInstance()
        {
            lock (lockSyncObject)
            {
                if (cachingConfigurationSection == null)
                {
                    cachingConfigurationSection =
                        (CachingConfigurationSection)
                        Gobbi.CoreServices.Configuration.ConfigurationManager.GetSection(
                            Constants.CachingConfigurationSectionName);
                    //if (cachingConfigurationSection == null)
                    //    throw new ConfigurationErrorsException(
                    //        string.Format(Resources.ERROR_CONFIGURATIONNOTDEFINED,
                    //                      Constants.CachingConfigurationSectionName));
                }
            }
            return cachingConfigurationSection;
        }

        [ConfigurationProperty("defaultCacheManagerName")]
        public string DefaultCacheManagerName
        {
            get { return (string)base["defaultCacheManagerName"]; }
            set { base["defaultCacheManagerName"] = value; }
        }

        [ConfigurationProperty("cacheManagers")]
        public GenericConfigurationElementCollection<CacheManagerConfiguration> CacheManagers
        {
            get { return (GenericConfigurationElementCollection<CacheManagerConfiguration>)base["cacheManagers"]; }
            set { base["cacheManagers"] = value; }
        } 
    }
}
