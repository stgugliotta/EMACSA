using System;
using System.Configuration;
using Gobbi.CoreServices.Configuration;
using System.ComponentModel;

namespace Gobbi.CoreServices.Caching.Configuration
{
    class CacheManagerConfiguration: DynamicConfigurationElement
    {
        [ConfigurationProperty("type")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type Type
        {
            get { return (Type)base["type"]; }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("expirationPollFrequencyInSeconds")]
        public int ExpirationPollFrequencyInSeconds
        {
            get { return (int)base["expirationPollFrequencyInSeconds"]; }
            set { base["expirationPollFrequencyInSeconds"] = value; }
        }

        [ConfigurationProperty("maximumElementsInCacheBeforeScavenging")]
        public int MaximumElementsInCacheBeforeScavenging
        {
            get { return (int)base["maximumElementsInCacheBeforeScavenging"]; }
            set { base["maximumElementsInCacheBeforeScavenging"] = value; }
        }

        [ConfigurationProperty("numberToRemoveWhenScavenging")]
        public int NumberToRemoveWhenScavenging
        {
            get { return (int)base["numberToRemoveWhenScavenging"]; }
            set { base["numberToRemoveWhenScavenging"] = value; }
        }
    }
}
