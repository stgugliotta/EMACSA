using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto SubTipoRetencionMTR 
    /// </summary>
    public class SubTipoRetencionMTRAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto SubTipoRetencionMTR 
        /// </summary>

        /// <returns></returns>
        public SubTipoRetencionMTR Load()
        {
            SubTipoRetencionMTR oReturn = new SubTipoRetencionMTR();
            try
            {
                using (DALSubTipoRetencionMTR dalSubTipoRetencionMTR = new DALSubTipoRetencionMTR())
                {
                    oReturn = dalSubTipoRetencionMTR.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto SubTipoRetencionMTR
        /// </summary>
        /// <param name="oSubTipoRetencionMTR"></param>
        public void Delete(SubTipoRetencionMTR oSubTipoRetencionMTR)
        {
            try
            {
                using (DALSubTipoRetencionMTR dalSubTipoRetencionMTR = new DALSubTipoRetencionMTR())
                {
                    dalSubTipoRetencionMTR.Delete(oSubTipoRetencionMTR);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto SubTipoRetencionMTR 
        /// </summary>
        /// <param name="oSubTipoRetencionMTR"></param>
        public void Update(SubTipoRetencionMTR oSubTipoRetencionMTR)
        {
            try
            {
                using (DALSubTipoRetencionMTR dalSubTipoRetencionMTR = new DALSubTipoRetencionMTR())
                {
                    dalSubTipoRetencionMTR.Update(oSubTipoRetencionMTR);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto SubTipoRetencionMTR 
        /// </summary>
        /// <param name="oSubTipoRetencionMTR"></param>
        public void Insert(SubTipoRetencionMTR oSubTipoRetencionMTR)
        {
            try
            {
                using (DALSubTipoRetencionMTR dalSubTipoRetencionMTR = new DALSubTipoRetencionMTR())
                {
                    dalSubTipoRetencionMTR.Insert(oSubTipoRetencionMTR);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto SubTipoRetencionMTR 
        /// se deja por compatibilidad con Standares
        /// </summary>

        /// <returns></returns>
        public SubTipoRetencionMTR GetSubTipoRetencionMTR()
        {
            SubTipoRetencionMTR oReturn = new SubTipoRetencionMTR();
            try
            {
                using (DALSubTipoRetencionMTR dalSubTipoRetencionMTR = new DALSubTipoRetencionMTR())
                {
                    oReturn = dalSubTipoRetencionMTR.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos SubTipoRetencionMTR
        /// de la tabla dbo.MTR_SubTipoRetencion
        /// </summary>
        /// <returns></returns>
        public List<SubTipoRetencionMTR> GetAllSubTipoRetencionMTRs()
        {
            List<SubTipoRetencionMTR> lstSubTipoRetencionMTR = new List<SubTipoRetencionMTR>();
            try
            {
                using (DALSubTipoRetencionMTR dalSubTipoRetencionMTR = new DALSubTipoRetencionMTR())
                {
                    lstSubTipoRetencionMTR = dalSubTipoRetencionMTR.GetAllSubTipoRetencionMTRs();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstSubTipoRetencionMTR;

        }
    }
}
