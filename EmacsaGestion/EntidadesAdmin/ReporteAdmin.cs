using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Reporte 
    /// </summary>
    public class ReporteAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Reporte 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public Reporte Load(short id)
        {
            Reporte oReturn = new Reporte();
            try
            {
                using (DALReporte dalReporte = new DALReporte())
                {
                    oReturn = dalReporte.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Reporte
        /// </summary>
        /// <param name="oReporte"></param>
        public void Delete(Reporte oReporte)
        {
            try
            {
                using (DALReporte dalReporte = new DALReporte())
                {
                    dalReporte.Delete(oReporte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Reporte 
        /// </summary>
        /// <param name="oReporte"></param>
        public void Update(Reporte oReporte)
        {
            try
            {
                using (DALReporte dalReporte = new DALReporte())
                {
                    dalReporte.Update(oReporte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Reporte 
        /// </summary>
        /// <param name="oReporte"></param>
        public void Insert(Reporte oReporte)
        {
            try
            {
                using (DALReporte dalReporte = new DALReporte())
                {
                    dalReporte.Insert(oReporte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Reporte 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>      
        /// <returns></returns>
        public Reporte GetReporte(short id)
        {
            Reporte oReturn = new Reporte();
            try
            {
                using (DALReporte dalReporte = new DALReporte())
                {
                    oReturn = dalReporte.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Reporte
        /// de la tabla dbo.tbl_cfg_Reporte
        /// </summary>
        /// <returns></returns>
        public List<Reporte> GetAllReportes()
        {
            List<Reporte> lstReporte = new List<Reporte>();
            try
            {
                using (DALReporte dalReporte = new DALReporte())
                {
                    lstReporte = dalReporte.GetAllReportes();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReporte;

        }
    }
}
