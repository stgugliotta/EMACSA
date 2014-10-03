using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Deposito 
    /// </summary>
    public class DepositoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Deposito 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public Deposito Load(int id)
        {
            Deposito oReturn = new Deposito();
            try
            {
                using (DALDeposito dalDeposito = new DALDeposito())
                {
                    oReturn = dalDeposito.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Deposito
        /// </summary>
        /// <param name="oDeposito"></param>
        public void Delete(Deposito oDeposito)
        {
            try
            {
                using (DALDeposito dalDeposito = new DALDeposito())
                {
                    dalDeposito.Delete(oDeposito);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Deposito 
        /// </summary>
        /// <param name="oDeposito"></param>
        public void Update(Deposito oDeposito)
        {
            try
            {
                using (DALDeposito dalDeposito = new DALDeposito())
                {
                    dalDeposito.Update(oDeposito);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Deposito 
        /// </summary>
        /// <param name="oDeposito"></param>
        public void Insert(Deposito oDeposito)
        {
            try
            {
                using (DALDeposito dalDeposito = new DALDeposito())
                {
                    dalDeposito.Insert(oDeposito);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Deposito 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>     
        /// <returns></returns>
        public Deposito GetDeposito(int id)
        {
            Deposito oReturn = new Deposito();
            try
            {
                using (DALDeposito dalDeposito = new DALDeposito())
                {
                    oReturn = dalDeposito.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Deposito
        /// de la tabla dbo.TBL_Deposito
        /// </summary>
        /// <returns></returns>
        public List<Deposito> GetAllDepositos()
        {
            List<Deposito> lstDeposito = new List<Deposito>();
            try
            {
                using (DALDeposito dalDeposito = new DALDeposito())
                {
                    lstDeposito = dalDeposito.GetAllDepositos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeposito;

        }
    }
}
