using System;
using System.Configuration;
using ar.com.telecom.eva.CoreServices.Security.Authorization;
//using ar.com.telecom.eva.CoreServices.Security.Authorization.Provider;
using ar.com.telecom.eva.CoreServices.Configuration;
using ar.com.telecom.eva.CoreServices.Properties;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;


namespace ar.com.telecom.eva.CoreServices.Security.Authorization
{
    ///<summary>
    /// Retorna distintas instancias de AuthorizationManager
    /// <remarks> Los distintos nombres de Authorization Manager están definidos y configurados 
    /// por la configuración del proyecto.</remarks>
    ///</summary>
    /// <example>
    /// Para instanciar una cacheManager específico: 
    /// <code>
    /// ICacheManager cacheManager = CacheFactory.GetCacheManager("cache1");
    /// </code>
    /// <para>Donde <em>cache1</em> está definido en la configuración.</para>
    /// </example>
    public static class AuthorizationProviderFactory
    {
        ///<summary>
        /// <para>Retorna la implementación de <see cref="IAuthorizationManager"/> por defecto. 
        /// El nombre de ésta instancia y su configuración está en la configuración del proyecto.</para>
        ///</summary>
        ///<returns>
        /// <para>  La instancia por defecto de AuthorizationManager.</para>
        /// </returns>
        public static IAuthorizationProvider GetAuthorizationProviderManager()
        {
            AuthorizationConfigurationSection authorizationConfigurationSection = AuthorizationConfigurationSection.GetInstance();
            if (authorizationConfigurationSection != null)
            {
                string defaultAuthorizationProviderManagerName = authorizationConfigurationSection.defaultAuthorizationProviderName;
                if (string.IsNullOrEmpty(defaultAuthorizationProviderManagerName))
                     throw new EvaTechnicalException ("", new   ConfigurationErrorsException(Resources.ERROR_AUTHENTICATORFACTORY_INVALIDDEFAULTCACHEMANAGERNAME));
                return GetAuthorizationProviderManager(defaultAuthorizationProviderManagerName);
            }
            else
            {
                ///TODO:Reemplazar por un mensaje de ausencia del cachemanager por defecto
                 throw new EvaTechnicalException ("", new  ConfigurationErrorsException(Resources.ERROR_AUTHENTICATORFACTORY_INVALIDDEFAULTCACHEMANAGERNAME));
            }
        }

        ///<summary>
        /// <para> Retorna la implementación pedida de <see cref="IAuthorizationManager"/>.</para>
        ///</summary>
        ///<param name="cacheManagerName"><para>Nombre de la implementación de <see cref="IAuthorizationManager"/> pedida, definida en la configuración.</para></param>
        ///<returns><para>La implementación de <see cref="IAuthorizationManager"/> pedida</para></returns>
        /// <exception cref="ArgumentException">authorizationProviderManagerName está vacío o es nulo</exception>
        public static IAuthorizationProvider GetAuthorizationProviderManager(string authorizationProviderManagerName)
        {
            if (string.IsNullOrEmpty(authorizationProviderManagerName))
                throw new EvaTechnicalException ("", new  ArgumentException(Resources.ERROR_EMPTYPARAMETERNAME, "authorizationProviderManagerName"));
            AuthorizationConfigurationSection authorizationConfigurationSection = AuthorizationConfigurationSection.GetInstance();
            AuthorizationManagerConfiguration authorizationManagerConfiguration =
                authorizationConfigurationSection.authorizationManagers[authorizationProviderManagerName];
            if (authorizationManagerConfiguration == null)
                 throw new EvaTechnicalException ("", new  ConfigurationErrorsException(
                    string.Format(Resources.ERROR_CONFIGURATIONNOTDEFINED, authorizationManagerConfiguration)));
            return (IAuthorizationProvider)ConfigurableObjectFactory.Create(
                                                    authorizationManagerConfiguration.Type, authorizationManagerConfiguration,
                                                        new object[] { authorizationProviderManagerName });
        }
    }
}

