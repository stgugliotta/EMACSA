using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Configuration 
    /// </summary>
    public class ConfigurationAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Configuration 
        /// </summary>
        /// <param name="idConfiguracion"></param>		
        /// <returns></returns>
        public Configuration Load(short idConfiguracion)
        {
            Configuration oReturn = new Configuration();
            try
            {
                using (DALConfiguration dalConfiguration = new DALConfiguration())
                {
                    oReturn = dalConfiguration.Load(idConfiguracion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Configuration
        /// </summary>
        /// <param name="oConfiguration"></param>
        public void Delete(Configuration oConfiguration)
        {
            try
            {
                using (DALConfiguration dalConfiguration = new DALConfiguration())
                {
                    dalConfiguration.Delete(oConfiguration);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Configuration 
        /// </summary>
        /// <param name="oConfiguration"></param>
        public void Update(Configuration oConfiguration)
        {
            try
            {
                using (DALConfiguration dalConfiguration = new DALConfiguration())
                {
                    dalConfiguration.Update(oConfiguration);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Configuration 
        /// </summary>
        /// <param name="oConfiguration"></param>
        public void Insert(Configuration oConfiguration)
        {
            try
            {
                using (DALConfiguration dalConfiguration = new DALConfiguration())
                {
                    dalConfiguration.Insert(oConfiguration);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Configuration 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idConfiguracion"></param>   
        /// <returns></returns>
        public Configuration GetConfiguration(short idConfiguracion)
        {
            Configuration oReturn = new Configuration();
            try
            {
                using (DALConfiguration dalConfiguration = new DALConfiguration())
                {
                    oReturn = dalConfiguration.Load(idConfiguracion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Configuration
        /// de la tabla dbo.CFG_Application
        /// </summary>
        /// <returns></returns>
        public List<Configuration> GetAllConfigurations()
        {
            List<Configuration> lstConfiguration = new List<Configuration>();
            try
            {
                using (DALConfiguration dalConfiguration = new DALConfiguration())
                {
                    lstConfiguration = dalConfiguration.GetAllConfigurations();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstConfiguration;

        }
    }
}
