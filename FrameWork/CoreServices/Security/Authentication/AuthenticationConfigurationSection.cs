using System.Configuration;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Properties;

namespace Gobbi.CoreServices.Security.Authentication
{
    class AuthenticationConfigurationSection : ConfigurationSection
    {

        #region Private Fields

        private static object lockSyncObject = new object();
        private static AuthenticationConfigurationSection authenticationConfigurationSection  = null;

        #endregion

        /// <summary>
        /// Retorna la instancia de la sección de configuración
        /// </summary>
        /// <returns>Sección de configuraciión para autenticación</returns>
        internal static AuthenticationConfigurationSection GetInstance()
        {
            lock (lockSyncObject)
            {
                if (authenticationConfigurationSection == null)
                {
                    authenticationConfigurationSection =
                        (AuthenticationConfigurationSection)
                        Gobbi.CoreServices.Configuration.ConfigurationManager.GetSection(
                            Constants.AuthenticationConfigurationSectionName);
                }
            }
            return authenticationConfigurationSection;
        }

        [ConfigurationProperty("defaultAuthenticatorManagerName")]
        public string defaultAuthenticatorManagerName
        {
            get { return (string)base["defaultAuthenticatorManagerName"]; }
            set { base["defaultAuthenticatorManagerName"] = value; }
        }

        [ConfigurationProperty("authenticationManagers")]
        public GenericConfigurationElementCollection<AuthenticationManagerConfiguration> authenticationManagers
        {
            get { return (GenericConfigurationElementCollection<AuthenticationManagerConfiguration>)base["authenticationManagers"]; }
            set { base["authenticationManagers"] = value; }
        } 


    }
}
