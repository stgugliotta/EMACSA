using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ProntoPago 
    /// </summary>
    public class ProntoPagoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto ProntoPago 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public ProntoPago Load(int id)
        {
            ProntoPago oReturn = new ProntoPago();
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    oReturn = dalProntoPago.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto ProntoPago
        /// </summary>
        /// <param name="oProntoPago"></param>
        public void Delete(ProntoPago oProntoPago)
        {
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    dalProntoPago.Delete(oProntoPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPorId(int id)
        {
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    dalProntoPago.EliminarPorId(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// M?todo para Actualizar  un objeto ProntoPago 
        /// </summary>
        /// <param name="oProntoPago"></param>
        public void Update(ProntoPago oProntoPago)
        {
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    dalProntoPago.Update(oProntoPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto ProntoPago 
        /// </summary>
        /// <param name="oProntoPago"></param>
        public void Insert(ProntoPago oProntoPago)
        {
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    dalProntoPago.Insert(oProntoPago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto ProntoPago 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>       
        /// <returns></returns>
        public ProntoPago GetProntoPago(int id)
        {
            ProntoPago oReturn = new ProntoPago();
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    oReturn = dalProntoPago.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ProntoPago
        /// de la tabla dbo.CFG_Pronto_Pago
        /// </summary>
        /// <returns></returns>
        public List<ProntoPago> GetAllProntoPagos()
        {
            List<ProntoPago> lstProntoPago = new List<ProntoPago>();
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    lstProntoPago = dalProntoPago.GetAllProntoPagos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProntoPago;

        }

        public List<ProntoPago> GetAllProntoPagosByIdClienteYIdDeudor(int idCliente, int idDeudor)
        {

            List<ProntoPago> lstProntoPago = new List<ProntoPago>();
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    lstProntoPago = dalProntoPago.GetAllProntoPagoByIdClienteYIdDeudor(idCliente, idDeudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProntoPago;

        
        }

        public List<ProntoPago> GetAllProntoPagosByIdCliente(int idCliente)
        {

            List<ProntoPago> lstProntoPago = new List<ProntoPago>();
            try
            {
                using (DALProntoPago dalProntoPago = new DALProntoPago())
                {
                    lstProntoPago = dalProntoPago.GetAllProntoPagoByIdCliente(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProntoPago;


        }
    }
}
