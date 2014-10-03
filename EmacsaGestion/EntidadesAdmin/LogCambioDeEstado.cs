using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto LogCambioDeEstado 
    /// </summary>
    public class LogCambioDeEstadoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto LogCambioDeEstado 
        /// </summary>

        /// <returns></returns>
        public LogCambioDeEstado Load()
        {
            LogCambioDeEstado oReturn = new LogCambioDeEstado();
            try
            {
                using (DALLogCambioDeEstado dalLogCambioDeEstado = new DALLogCambioDeEstado())
                {
                    oReturn = dalLogCambioDeEstado.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto LogCambioDeEstado
        /// </summary>
        /// <param name="oLogCambioDeEstado"></param>
        public void Delete(LogCambioDeEstado oLogCambioDeEstado)
        {
            try
            {
                using (DALLogCambioDeEstado dalLogCambioDeEstado = new DALLogCambioDeEstado())
                {
                    dalLogCambioDeEstado.Delete(oLogCambioDeEstado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto LogCambioDeEstado 
        /// </summary>
        /// <param name="oLogCambioDeEstado"></param>
        public void Update(LogCambioDeEstado oLogCambioDeEstado)
        {
            try
            {
                using (DALLogCambioDeEstado dalLogCambioDeEstado = new DALLogCambioDeEstado())
                {
                    dalLogCambioDeEstado.Update(oLogCambioDeEstado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto LogCambioDeEstado 
        /// </summary>
        /// <param name="oLogCambioDeEstado"></param>
        public void Insert(LogCambioDeEstado oLogCambioDeEstado)
        {
            try
            {
                using (DALLogCambioDeEstado dalLogCambioDeEstado = new DALLogCambioDeEstado())
                {
                    dalLogCambioDeEstado.Insert(oLogCambioDeEstado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto LogCambioDeEstado 
        /// se deja por compatibilidad con Standares
        /// </summary>

        /// <returns></returns>
        public LogCambioDeEstado GetLogCambioDeEstado()
        {
            LogCambioDeEstado oReturn = new LogCambioDeEstado();
            try
            {
                using (DALLogCambioDeEstado dalLogCambioDeEstado = new DALLogCambioDeEstado())
                {
                    oReturn = dalLogCambioDeEstado.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos LogCambioDeEstado
        /// de la tabla dbo.tbl_logCambiosDeEstado
        /// </summary>
        /// <returns></returns>
        public List<LogCambioDeEstado> GetAllLogCambioDeEstados()
        {
            List<LogCambioDeEstado> lstLogCambioDeEstado = new List<LogCambioDeEstado>();
            try
            {
                using (DALLogCambioDeEstado dalLogCambioDeEstado = new DALLogCambioDeEstado())
                {
                    lstLogCambioDeEstado = dalLogCambioDeEstado.GetAllLogCambioDeEstados();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLogCambioDeEstado;

        }
    }
}
