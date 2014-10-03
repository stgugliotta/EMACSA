using System;
using System.Configuration;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching.Configuration;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Caching
{
    ///<summary>
    /// Retorna distintas instancias de CacheManager
    /// <remarks> Los distintos nombres de Cache Manager están definidos y configurados 
    /// por la configuración del proyecto.</remarks>
    ///</summary>
    /// <example>
    /// Para instanciar una cacheManager específico: 
    /// <code>
    /// ICacheManager cacheManager = CacheFactory.GetCacheManager("cache1");
    /// </code>
    /// <para>Donde <em>cache1</em> está definido en la configuración.</para>
    /// </example>

    public static class CacheFactory
    {
        ///<summary>
        /// <para>Retorna la implementación de <see cref="ICacheManager"/> por defecto. 
        /// El nombre de ésta instancia y su configuración está en la configuración del proyecto.</para>
        ///</summary>
        ///<returns>
        /// <para>  La instancia por defecto de CacheManager.</para>
        /// </returns>
        public static ICacheManager GetCacheManager()
        {
            CachingConfigurationSection cachingConfigurationSection = CachingConfigurationSection.GetInstance();
            if (cachingConfigurationSection != null)
            {
                string defaultCacheManagerName = cachingConfigurationSection.DefaultCacheManagerName;
                if (string.IsNullOrEmpty(defaultCacheManagerName))
                    throw new GobbiTechnicalException("", new ConfigurationErrorsException(Resources.ERROR_CACHEFACTORY_INVALIDDEFAULTCACHEMANAGERNAME));
                return GetCacheManager(defaultCacheManagerName);
            }
            else
            {
                ///TODO:Reemplazar por un mensaje de ausencia del cachemanager por defecto
                throw new GobbiTechnicalException("",new ConfigurationErrorsException(Resources.ERROR_CACHEFACTORY_INVALIDDEFAULTCACHEMANAGERNAME));
            }
        }

        ///<summary>
        /// <para> Retorna la implementación pedida de <see cref="ICacheManager"/>.</para>
        ///</summary>
        ///<param name="cacheManagerName"><para>Nombre de la implementación de <see cref="ICacheManager"/> pedida, definida en la configuración.</para></param>
        ///<returns><para>La implementación de <see cref="ICacheManager"/> pedida</para></returns>
        /// <exception cref="ArgumentException">cacheManagerName está vacío o es nulo</exception>
        public static ICacheManager GetCacheManager(string cacheManagerName)
        {
            if (string.IsNullOrEmpty(cacheManagerName))
                throw new GobbiTechnicalException("", new ArgumentException(Resources.ERROR_EMPTYPARAMETERNAME, "cacheManagerName"));
                    CachingConfigurationSection cachingConfigurationSection = CachingConfigurationSection.GetInstance();

                    CacheManagerConfiguration cacheManagerConfiguration =
                        cachingConfigurationSection.CacheManagers[cacheManagerName];
                    if (cacheManagerConfiguration == null)
                        throw new GobbiTechnicalException("", new ConfigurationErrorsException(
                            string.Format(Resources.ERROR_CONFIGURATIONNOTDEFINED, cacheManagerName)));
                    return  (ICacheManager) ConfigurableObjectFactory.Create(
                                                            cacheManagerConfiguration.Type, cacheManagerConfiguration,
                                                                new object[]{cacheManagerName} );
        }
    }
}
