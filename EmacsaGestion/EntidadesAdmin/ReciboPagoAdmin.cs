using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ReciboPago 
    /// </summary>
    public class ReciboPagoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto ReciboPago 
        /// </summary>
        /// <param name="idRecibo"></param>/// <param name="idPago"></param>		
        /// <returns></returns>
        public ReciboPago Load(int idRecibo, int idPago)
        {
            ReciboPago oReturn = new ReciboPago();
            try
            {
                using (DALReciboPago dalReciboPago = new DALReciboPago())
                {
                    oReturn = dalReciboPago.Load(idRecibo, idPago);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto ReciboPago
        /// </summary>
        /// <param name="oReciboPago"></param>
        public void Delete(ReciboPago oReciboPago)
        {
            try
            {
                using (DALReciboPago dalReciboPago = new DALReciboPago())
                {
                    dalReciboPago.Delete(oReciboPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto ReciboPago 
        /// </summary>
        /// <param name="oReciboPago"></param>
        public void Update(ReciboPago oReciboPago)
        {
            try
            {
                using (DALReciboPago dalReciboPago = new DALReciboPago())
                {
                    dalReciboPago.Update(oReciboPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto ReciboPago 
        /// </summary>
        /// <param name="oReciboPago"></param>
        public void Insert(ReciboPago oReciboPago)
        {
            try
            {
                using (DALReciboPago dalReciboPago = new DALReciboPago())
                {
                    dalReciboPago.Insert(oReciboPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto ReciboPago 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idRecibo"></param> /// <param name="idPago"></param>   
        /// <returns></returns>
        public ReciboPago GetReciboPago(int idRecibo, int idPago)
        {
            ReciboPago oReturn = new ReciboPago();
            try
            {
                using (DALReciboPago dalReciboPago = new DALReciboPago())
                {
                    oReturn = dalReciboPago.Load(idRecibo, idPago);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ReciboPago
        /// de la tabla dbo.TBL_Recibo_Pago
        /// </summary>
        /// <returns></returns>
        public List<ReciboPago> GetAllReciboPagos()
        {
            List<ReciboPago> lstReciboPago = new List<ReciboPago>();
            try
            {
                using (DALReciboPago dalReciboPago = new DALReciboPago())
                {
                    lstReciboPago = dalReciboPago.GetAllReciboPagos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReciboPago;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ReciboPago
        /// de la tabla dbo.TBL_Recibo_Pago
        /// </summary>
        /// <returns></returns>
        public List<ReciboPago> GetAllReciboPagosByIdRecibo(int idRecibo)
        {
            List<ReciboPago> lstReciboPago = new List<ReciboPago>();
            try
            {
                using (DALReciboPago dalReciboPago = new DALReciboPago())
                {
                    lstReciboPago = dalReciboPago.GetAllReciboPagosByIdRecibo(idRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReciboPago;

        }

    }
}
