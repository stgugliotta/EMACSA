using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Pago 
    /// </summary>
    public class PagoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Pago 
        /// </summary>
        /// <param name="idPago"></param>		
        /// <returns></returns>
        public Pago Load(int idPago)
        {
            Pago oReturn = new Pago();
            try
            {
                using (DALPago dalPago = new DALPago())
                {
                    oReturn = dalPago.Load(idPago);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Pago
        /// </summary>
        /// <param name="oPago"></param>
        public void Delete(Pago oPago)
        {
            try
            {
                using (DALPago dalPago = new DALPago())
                {
                    dalPago.Delete(oPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Pago 
        /// </summary>
        /// <param name="oPago"></param>
        public void Update(Pago oPago)
        {
            try
            {
                using (DALPago dalPago = new DALPago())
                {
                    dalPago.Update(oPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Pago 
        /// </summary>
        /// <param name="oPago"></param>
        public void Insert(Pago oPago)
        {
            try
            {
                using (DALPago dalPago = new DALPago())
                {
                    dalPago.Insert(oPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Pago 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idPago"></param>    
        /// <returns></returns>
        public Pago GetPago(int idPago)
        {
            Pago oReturn = new Pago();
            try
            {
                using (DALPago dalPago = new DALPago())
                {
                    oReturn = dalPago.Load(idPago);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Pago
        /// de la tabla dbo.TBL_Pago
        /// </summary>
        /// <returns></returns>
        public List<Pago> GetAllPagos()
        {
            List<Pago> lstPago = new List<Pago>();
            try
            {
                using (DALPago dalPago = new DALPago())
                {
                    lstPago = dalPago.GetAllPagos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPago;

        }
    }
}
