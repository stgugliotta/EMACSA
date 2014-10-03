using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
    /// <summary>
    /// Creado		: 2010-01-13
    /// Accion		: Implementacion de la Interface de la Entidad Configuration
    /// Objeto		: GOBBI_NUCLEO.dbo.cfg_application
    /// Descripcion	: 
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        #region IConfigurationService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ConfigurationDataContracts
        /// </summary>
        /// <value>ConfigurationDataContracts</value>
        public ConfigurationDataContracts Load(short idConfiguracion)
        {
            try
            {
                ConfigurationAdmin configurationAdmin = new ConfigurationAdmin();
                return (ConfigurationDataContracts)configurationAdmin.Load(idConfiguracion);
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - Load: ConfigurationService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ConfigurationDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ConfigurationDataContracts oConfiguration)
        {
            try
            {
                ConfigurationAdmin configurationAdmin = new ConfigurationAdmin();
                configurationAdmin.Delete((Configuration)oConfiguration);

            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  Delete : ConfigurationService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ConfigurationDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ConfigurationDataContracts oConfiguration)
        {
            try
            {
                ConfigurationAdmin configurationAdmin = new ConfigurationAdmin();
                configurationAdmin.Update((Configuration)oConfiguration);

            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  Update : ConfigurationService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ConfigurationDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ConfigurationDataContracts oConfiguration)
        {
            try
            {
                ConfigurationAdmin configurationAdmin = new ConfigurationAdmin();
                configurationAdmin.Insert((Configuration)oConfiguration);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  Insert : ConfigurationService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ConfigurationDataContracts
        /// </summary>
        /// <value>void</value>
        public ConfigurationDataContracts GetConfiguration(short idConfiguracion)
        {
            try
            {
                ConfigurationAdmin configurationAdmin = new ConfigurationAdmin();
                return (ConfigurationDataContracts)configurationAdmin.Load(idConfiguracion);
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  GetConfiguration : ConfigurationService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ConfigurationDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ConfigurationDataContracts> GetAllConfigurations()
        {
            try
            {
                ConfigurationAdmin configurationAdmin = new ConfigurationAdmin();
                List<Configuration> resultList = configurationAdmin.GetAllConfigurations();

                return resultList.ConvertAll<ConfigurationDataContracts>(
                    delegate(Configuration tempConfiguration) { return (ConfigurationDataContracts)tempConfiguration; });
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - GetAllConfigurations : ConfigurationService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}