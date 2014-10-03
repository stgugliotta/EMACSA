using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto LogFactura 
    /// </summary>
    public class LogFacturaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto LogFactura 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public LogFactura Load(int id)
        {
            LogFactura oReturn = new LogFactura();
            try
            {
                using (DALLogFactura dalLogFactura = new DALLogFactura())
                {
                    oReturn = dalLogFactura.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto LogFactura
        /// </summary>
        /// <param name="oLogFactura"></param>
        public void Delete(LogFactura oLogFactura)
        {
            try
            {
                using (DALLogFactura dalLogFactura = new DALLogFactura())
                {
                    dalLogFactura.Delete(oLogFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto LogFactura 
        /// </summary>
        /// <param name="oLogFactura"></param>
        public void Update(LogFactura oLogFactura)
        {
            try
            {
                using (DALLogFactura dalLogFactura = new DALLogFactura())
                {
                    dalLogFactura.Update(oLogFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto LogFactura 
        /// </summary>
        /// <param name="oLogFactura"></param>
        public void Insert(LogFactura oLogFactura)
        {
            try
            {
                using (DALLogFactura dalLogFactura = new DALLogFactura())
                {
                    dalLogFactura.Insert(oLogFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto LogFactura 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>     
        /// <returns></returns>
        public LogFactura GetLogFactura(int id)
        {
            LogFactura oReturn = new LogFactura();
            try
            {
                using (DALLogFactura dalLogFactura = new DALLogFactura())
                {
                    oReturn = dalLogFactura.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos LogFactura
        /// de la tabla dbo.LOG_Factura
        /// </summary>
        /// <returns></returns>
        public List<LogFactura> GetAllLogFacturas()
        {
            List<LogFactura> lstLogFactura = new List<LogFactura>();
            try
            {
                using (DALLogFactura dalLogFactura = new DALLogFactura())
                {
                    lstLogFactura = dalLogFactura.GetAllLogFacturas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLogFactura;

        }


        public List<LogFactura> GetAllLogFacturasByIdFactura(int idFactura)
        {
            List<LogFactura> lstLogFactura = new List<LogFactura>();
            try
            {
                using (DALLogFactura dalLogFactura = new DALLogFactura())
                {
                    lstLogFactura = dalLogFactura.GetAllLogFacturasByIdFactura(idFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLogFactura;

        }
    }
}
