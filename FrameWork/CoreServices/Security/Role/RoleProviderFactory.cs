using System;
using System.Configuration;
using Gobbi.CoreServices.Security.Role;
using Gobbi.CoreServices.Security.Role.Provider;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.Security;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Security.Role
{
    ///<summary>
    /// Retorna distintas instancias de RoleManager
    /// <remarks> Los distintos nombres de Role Manager están definidos y configurados 
    /// por la configuración del proyecto.</remarks>
    ///</summary>
    /// <example>
    /// Para instanciar una cacheManager específico: 
    /// <code>
    /// ICacheManager cacheManager = CacheFactory.GetCacheManager("cache1");
    /// </code>
    /// <para>Donde <em>cache1</em> está definido en la configuración.</para>
    /// </example>
    public static class RoleProviderFactory
    {
        ///<summary>
        /// <para>Retorna la implementación de <see cref="ICacheManager"/> por defecto. 
        /// El nombre de ésta instancia y su configuración está en la configuración del proyecto.</para>
        ///</summary>
        ///<returns>
        /// <para>  La instancia por defecto de CacheManager.</para>
        /// </returns>
        public static IRoleProvider GetRoleProviderManager()
        {
            RoleConfigurationSection roleConfigurationSection = RoleConfigurationSection.GetInstance();
            if (roleConfigurationSection != null)
            {
                string defaultRoleProviderManagerName = roleConfigurationSection.defaultRoleManagerName;
                if (string.IsNullOrEmpty(defaultRoleProviderManagerName))
                     throw new GobbiTechnicalException ("", new   ConfigurationErrorsException(Resources.ERROR_AUTHENTICATORFACTORY_INVALIDDEFAULTCACHEMANAGERNAME));
                return GetRoleProviderManager(defaultRoleProviderManagerName);
            }
            else
            {
                ///TODO:Reemplazar por un mensaje de ausencia del cachemanager por defecto
                 throw new GobbiTechnicalException ("", new   ConfigurationErrorsException(Resources.ERROR_AUTHENTICATORFACTORY_INVALIDDEFAULTCACHEMANAGERNAME));
            }
        }

        ///<summary>
        /// <para> Retorna la implementación pedida de <see cref="ICacheManager"/>.</para>
        ///</summary>
        ///<param name="cacheManagerName"><para>Nombre de la implementación de <see cref="ICacheManager"/> pedida, definida en la configuración.</para></param>
        ///<returns><para>La implementación de <see cref="ICacheManager"/> pedida</para></returns>
        /// <exception cref="ArgumentException">cacheManagerName está vacío o es nulo</exception>
        public static IRoleProvider GetRoleProviderManager(string roleProviderManagerName)
        {
            if (string.IsNullOrEmpty(roleProviderManagerName))
                 throw new GobbiTechnicalException ("", new   ArgumentException(Resources.ERROR_EMPTYPARAMETERNAME, "roleProviderManagerName"));
            RoleConfigurationSection roleConfigurationSection = RoleConfigurationSection.GetInstance();
            RoleManagerConfiguration roleManagerConfiguration =
                roleConfigurationSection.roleManagers[roleProviderManagerName];
            if (roleManagerConfiguration == null)
                throw new GobbiTechnicalException ("", new  ConfigurationErrorsException(
                    string.Format(Resources.ERROR_CONFIGURATIONNOTDEFINED, roleManagerConfiguration)));
            return (IRoleProvider)ConfigurableObjectFactory.Create(
                                                    roleManagerConfiguration.Type, roleManagerConfiguration,
                                                        new object[] { roleProviderManagerName });
        }
    }
}
