using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ReciboFactura 
    /// </summary>
    public class ReciboFacturaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto ReciboFactura 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public ReciboFactura Load(int id)
        {
            ReciboFactura oReturn = new ReciboFactura();
            try
            {
                using (DALReciboFactura dalReciboFactura = new DALReciboFactura())
                {
                    oReturn = dalReciboFactura.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto ReciboFactura
        /// </summary>
        /// <param name="oReciboFactura"></param>
        public void Delete(ReciboFactura oReciboFactura)
        {
            try
            {
                using (DALReciboFactura dalReciboFactura = new DALReciboFactura())
                {
                    dalReciboFactura.Delete(oReciboFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto ReciboFactura 
        /// </summary>
        /// <param name="oReciboFactura"></param>
        public void Update(ReciboFactura oReciboFactura)
        {
            try
            {
                using (DALReciboFactura dalReciboFactura = new DALReciboFactura())
                {
                    dalReciboFactura.Update(oReciboFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto ReciboFactura 
        /// </summary>
        /// <param name="oReciboFactura"></param>
        public void Insert(ReciboFactura oReciboFactura)
        {
            try
            {
                using (DALReciboFactura dalReciboFactura = new DALReciboFactura())
                {
                    dalReciboFactura.Insert(oReciboFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto ReciboFactura 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>       
        /// <returns></returns>
        public ReciboFactura GetReciboFactura(int id)
        {
            ReciboFactura oReturn = new ReciboFactura();
            try
            {
                using (DALReciboFactura dalReciboFactura = new DALReciboFactura())
                {
                    oReturn = dalReciboFactura.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ReciboFactura
        /// de la tabla dbo.TBL_Recibo_Factura
        /// </summary>
        /// <returns></returns>
        public List<ReciboFactura> GetAllReciboFacturas()
        {
            List<ReciboFactura> lstReciboFactura = new List<ReciboFactura>();
            try
            {
                using (DALReciboFactura dalReciboFactura = new DALReciboFactura())
                {
                    lstReciboFactura = dalReciboFactura.GetAllReciboFacturas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReciboFactura;

        }

        public List<ReciboFactura> GetAllReciboFacturasByIdRecibo(int idRecibo)
        {
            List<ReciboFactura> lstReciboFactura = new List<ReciboFactura>();
            try
            {
                using (DALReciboFactura dalReciboFactura = new DALReciboFactura())
                {
                    lstReciboFactura = dalReciboFactura.GetAllReciboFacturasByIdRecibo(idRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReciboFactura;

        }

    }
}
