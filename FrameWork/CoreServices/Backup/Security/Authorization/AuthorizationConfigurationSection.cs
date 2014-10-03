using System.Configuration;
using ar.com.telecom.eva.CoreServices.Configuration;
using ar.com.telecom.eva.CoreServices.Properties;

namespace ar.com.telecom.eva.CoreServices.Security.Authorization
{
    class AuthorizationConfigurationSection : ConfigurationSection
    {

        #region Private Fields

        private static object lockSyncObject = new object();
        private static AuthorizationConfigurationSection authorizationConfigurationSection = null;

        #endregion

        /// <summary>
        /// Retorna la instancia de la sección de configuración
        /// </summary>
        /// <returns>Sección de configuraciión para autenticación</returns>
        internal static AuthorizationConfigurationSection GetInstance()
        {
            lock (lockSyncObject)
            {
                if (authorizationConfigurationSection == null)
                {
                    authorizationConfigurationSection =
                        (AuthorizationConfigurationSection)
                        ar.com.telecom.eva.CoreServices.Configuration.ConfigurationManager.GetSection(
                            Constants.AuthorizationConfigurationSectionName);
                }
            }
            return authorizationConfigurationSection;
        }

        [ConfigurationProperty("defaultAuthorizationProviderName")]
        public string defaultAuthorizationProviderName
        {
            get { return (string)base["defaultAuthorizationProviderName"]; }
            set { base["defaultAuthorizationProviderName"] = value; }
        }

        [ConfigurationProperty("authorizationProviders")]
        public GenericConfigurationElementCollection<AuthorizationManagerConfiguration> authorizationManagers
        {
            get { return (GenericConfigurationElementCollection<AuthorizationManagerConfiguration>)base["authorizationProviders"]; }
            set { base["authorizationProviders"] = value; }
        }


    }
}

