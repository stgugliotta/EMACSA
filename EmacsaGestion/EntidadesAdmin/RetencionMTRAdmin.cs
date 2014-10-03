using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto RetencionMTR 
    /// </summary>
    public class RetencionMTRAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto RetencionMTR 
        /// </summary>

        /// <returns></returns>
        public RetencionMTR Load()
        {
            RetencionMTR oReturn = new RetencionMTR();
            try
            {
                using (DALRetencionMTR dalRetencionMTR = new DALRetencionMTR())
                {
                    oReturn = dalRetencionMTR.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto RetencionMTR
        /// </summary>
        /// <param name="oRetencionMTR"></param>
        public void Delete(RetencionMTR oRetencionMTR)
        {
            try
            {
                using (DALRetencionMTR dalRetencionMTR = new DALRetencionMTR())
                {
                    dalRetencionMTR.Delete(oRetencionMTR);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto RetencionMTR 
        /// </summary>
        /// <param name="oRetencionMTR"></param>
        public void Update(RetencionMTR oRetencionMTR)
        {
            try
            {
                using (DALRetencionMTR dalRetencionMTR = new DALRetencionMTR())
                {
                    dalRetencionMTR.Update(oRetencionMTR);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto RetencionMTR 
        /// </summary>
        /// <param name="oRetencionMTR"></param>
        public void Insert(RetencionMTR oRetencionMTR)
        {
            try
            {
                using (DALRetencionMTR dalRetencionMTR = new DALRetencionMTR())
                {
                    dalRetencionMTR.Insert(oRetencionMTR);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto RetencionMTR 
        /// se deja por compatibilidad con Standares
        /// </summary>

        /// <returns></returns>
        public RetencionMTR GetRetencionMTR()
        {
            RetencionMTR oReturn = new RetencionMTR();
            try
            {
                using (DALRetencionMTR dalRetencionMTR = new DALRetencionMTR())
                {
                    oReturn = dalRetencionMTR.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos RetencionMTR
        /// de la tabla dbo.MTR_Retencion
        /// </summary>
        /// <returns></returns>
        public List<RetencionMTR> GetAllRetencionMTRs()
        {
            List<RetencionMTR> lstRetencionMTR = new List<RetencionMTR>();
            try
            {
                using (DALRetencionMTR dalRetencionMTR = new DALRetencionMTR())
                {
                    lstRetencionMTR = dalRetencionMTR.GetAllRetencionMTRs();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRetencionMTR;

        }
    }
}
