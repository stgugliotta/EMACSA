using System.Configuration;
using ar.com.telecom.eva.CoreServices.Configuration;
using ar.com.telecom.eva.CoreServices.Properties;

namespace ar.com.telecom.eva.CoreServices.Security.Role
{
    class RoleConfigurationSection : ConfigurationSection
    {

        #region Private Fields

        private static object lockSyncObject = new object();
        private static RoleConfigurationSection roleConfigurationSection  = null;

        #endregion

        /// <summary>
        /// Retorna la instancia de la sección de configuración
        /// </summary>
        /// <returns>Sección de configuraciión para autenticación</returns>
        internal static RoleConfigurationSection GetInstance()
        {
            lock (lockSyncObject)
            {
                if (roleConfigurationSection == null)
                {
                    roleConfigurationSection =
                        (RoleConfigurationSection)
                        ar.com.telecom.eva.CoreServices.Configuration.ConfigurationManager.GetSection(
                            Constants.RoleConfigurationSectionName);
                }
            }
            return roleConfigurationSection;
        }

        [ConfigurationProperty("defaultRoleManagerName")]
        public string defaultRoleManagerName
        {
            get { return (string)base["defaultRoleManagerName"]; }
            set { base["defaultRoleManagerName"] = value; }
        }

        [ConfigurationProperty("roleManagers")]
        public GenericConfigurationElementCollection<RoleManagerConfiguration> roleManagers
        {
            get { return (GenericConfigurationElementCollection<RoleManagerConfiguration>)base["roleManagers"]; }
            set { base["roleManagers"] = value; }
        } 


    }
}

