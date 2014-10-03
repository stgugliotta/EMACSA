using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto OtroPago 
    /// </summary>
    public class OtroPagoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto OtroPago 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public OtroPago Load(int id)
        {
            OtroPago oReturn = new OtroPago();
            try
            {
                using (DALOtroPago dalOtroPago = new DALOtroPago())
                {
                    oReturn = dalOtroPago.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto OtroPago
        /// </summary>
        /// <param name="oOtroPago"></param>
        public void Delete(OtroPago oOtroPago)
        {
            try
            {
                using (DALOtroPago dalOtroPago = new DALOtroPago())
                {
                    dalOtroPago.Delete(oOtroPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto OtroPago 
        /// </summary>
        /// <param name="oOtroPago"></param>
        public void Update(OtroPago oOtroPago)
        {
            try
            {
                using (DALOtroPago dalOtroPago = new DALOtroPago())
                {
                    dalOtroPago.Update(oOtroPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto OtroPago 
        /// </summary>
        /// <param name="oOtroPago"></param>
        public void Insert(OtroPago oOtroPago)
        {
            try
            {
                using (DALOtroPago dalOtroPago = new DALOtroPago())
                {
                    dalOtroPago.Insert(oOtroPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto OtroPago 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>    
        /// <returns></returns>
        public OtroPago GetOtroPago(int id)
        {
            OtroPago oReturn = new OtroPago();
            try
            {
                using (DALOtroPago dalOtroPago = new DALOtroPago())
                {
                    oReturn = dalOtroPago.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos OtroPago
        /// de la tabla dbo.TBL_OtroPago
        /// </summary>
        /// <returns></returns>
        public List<OtroPago> GetAllOtroPagos()
        {
            List<OtroPago> lstOtroPago = new List<OtroPago>();
            try
            {
                using (DALOtroPago dalOtroPago = new DALOtroPago())
                {
                    lstOtroPago = dalOtroPago.GetAllOtroPagos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOtroPago;

        }
    }
}
