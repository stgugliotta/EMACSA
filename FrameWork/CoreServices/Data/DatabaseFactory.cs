using System;
using System.Collections.Generic;

using System.Data.Common;
using System.Text;
using Gobbi.CoreServices.Data.Databases;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Data
{
    ///<summary>
    /// <para> Contiene métodos estáticos para crear objetos Database</para>
    ///</summary>
    /// <example>
    /// <para> Instancia la base de datos predeterminada en la configuración.</para>
    /// <code>
    /// Database myDb = DatabaseFactory.CreateDatabase();
    /// </code>
    /// </example>
    public static class DatabaseFactory
    {
        #region Private Fields

        private static DataConfigurationSection dataConfiguration;
        private static bool dataConfigPedida = false;

        private static System.Configuration.ConnectionStringsSection connConfiguration;
        private static bool connConfigPedida = false;

        #endregion

        #region Public Methods

        ///<summary>
        /// <para>Retorna una instancia predeterminada de la clase Database.</para>
        ///</summary>
        /// <example>
        /// <code>
        /// Database miDb = DatabaseFactory.CreateDatabase();
        /// </code>
        /// </example>
        ///<returns>
        /// <para>Una instancia de Database. </para>
        /// </returns>
        ///<exception cref="System.Configuration.ConfigurationErrorsException">
        /// <para>An error occured while reading the configuration.</para>
        /// </exception>
        public static Database CreateDatabase()
        {
            DataConfigurationSection section = GetDataConfiguration();
            if (section == null)
                throw new GobbiTechnicalException ("", new System.Configuration.ConfigurationErrorsException("Falta la sección de configuración."));
            string defaultDatabaseName = section.DefaultDatabase;
            return CreateDatabase(defaultDatabaseName);
        }

        ///<summary>
        /// <para> Retorna una instancia específíca de la clase Database</para>
        ///</summary>
        /// <example>
        /// <code>
        /// Database dbSvc = DatabaseFactory.CreateDatabase("SQL_Cuentas");
        /// </code>
        /// </example>
        ///<param name="name">
        /// <para> Clave de configuración para instanciación</para>
        /// </param>
        ///<returns>
        /// <para> Una instancia de Database.</para>
        /// </returns>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">
        /// <para><paramref name="name"/> No está definida en configuración.</para> 
        /// <para>- o -</para>
        /// <para>Un error en la configuración.</para>
        /// <para>- o -</para>
        /// <para>Un error mientras se leía la configuración.</para>        
        /// </exception>
        /// <exception cref="System.Reflection.TargetInvocationException">
        /// <para>El constructor llamado arrojo una excepción.</para>
        /// </exception>
        public static Database CreateDatabase(string name)
        {
            DataConfigurationSection dataConfigurationSectionsection = GetDataConfiguration();
            DataConfigurationElement dce;
            
            //Si el mappingProvider está definido devuelvo el tipo configurado.
            if (dataConfigurationSectionsection != null && 
                (dce = dataConfigurationSectionsection.Databases[name]) != null && 
                dce.Type != null)
            {
                string[] parameters = new string[] { name };
                return (Database) Configuration.ConfigurableObjectFactory.Create(dce.Type, dce, parameters); 
            }
            System.Configuration.ConnectionStringsSection connectionStringsSection = GetConnectionStringsConfiguration();
            //Si el connectionStringSetting contiene el type devuelvo el asociado. y si no está definido devuelvo 
            if (connectionStringsSection != null && connectionStringsSection.ConnectionStrings[name] != null)
            {
                System.Configuration.ConnectionStringSettings connSettings =
                    connectionStringsSection.ConnectionStrings[name];
                
                if (string.IsNullOrEmpty(connSettings.ProviderName))
                {
                    return new SQLDatabase(name, connSettings.ConnectionString);
                }
                if (connSettings.ProviderName == Constants.SQLDatabaseProvider)
                {
                    return new SQLDatabase(name, connSettings.ConnectionString);
                }

                return new GenericDatabase(name, connSettings.ProviderName, connSettings.ConnectionString);
            }

           throw new GobbiTechnicalException ("", new System.Configuration.ConfigurationErrorsException(
                string.Format(Resources.ERROR_DATABASEFACTORY_BADCONFIGURATION, name)));
        }

        #endregion

        #region Private Methods

        private static System.Configuration.ConnectionStringsSection GetConnectionStringsConfiguration()
        {
            if (!connConfigPedida)
            {
                connConfigPedida = true;
                connConfiguration = (System.Configuration.ConnectionStringsSection)Gobbi.CoreServices.Configuration.ConfigurationManager.GetSection(Constants.ConnectionStringsSectionName);
            }
            return connConfiguration;
        }

        private static DataConfigurationSection GetDataConfiguration()
        {
            if (!dataConfigPedida)
            {
                dataConfigPedida = true;
                dataConfiguration = (DataConfigurationSection)Gobbi.CoreServices.Configuration.ConfigurationManager.GetSection(Constants.DataConfigurationSectionName);
            }
            return dataConfiguration;
        }

        #endregion
    }
}
