using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Cheque 
    /// </summary>
    public class ChequeAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Cheque 
        /// </summary>

        /// <returns></returns>
        public Cheque Load(int idCheque)
        {
            Cheque oReturn = new Cheque();
            try
            {
                using (DALCheque dalCheque = new DALCheque())
                {
                    oReturn = dalCheque.Load(idCheque);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        public void Delete(Cheque oCheque)
        {
            try
            {
                using (DALCheque dalCheque = new DALCheque())
                {
                    dalCheque.Delete(oCheque);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Cheque 
        /// </summary>
        /// <param name="oCheque"></param>
        public void Update(Cheque oCheque)
        {
            try
            {
                using (DALCheque dalCheque = new DALCheque())
                {
                    dalCheque.Update(oCheque);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Cheque 
        /// </summary>
        /// <param name="oCheque"></param>
        public void Insert(Cheque oCheque)
        {
            try
            {
                using (DALCheque dalCheque = new DALCheque())
                {
                    dalCheque.Insert(oCheque);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Cheque 
        /// se deja por compatibilidad con Standares
        /// </summary>

        /// <returns></returns>
        public Cheque GetCheque(int idCheque)
        {
            Cheque oReturn = new Cheque();
            try
            {
                using (DALCheque dalCheque = new DALCheque())
                {
                    oReturn = dalCheque.Load(idCheque);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo de lectura de objeto Cheque 
        /// se deja por compatibilidad con Standares
        /// </summary>

        /// <returns></returns>
        public Cheque GetChequeByCuit(string cuit)
        {
            Cheque oReturn = new Cheque();
            try
            {
                using (DALCheque dalCheque = new DALCheque())
                {
                    oReturn = dalCheque.GetChequeByCuit(cuit);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }
        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Cheque
        /// de la tabla dbo.MTR_Cheque
        /// </summary>
        /// <returns></returns>
        public List<Cheque> GetAllCheques()
        {
            List<Cheque> lstCheque = new List<Cheque>();
            try
            {
                using (DALCheque dalCheque = new DALCheque())
                {
                    lstCheque = dalCheque.GetAllCheques();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCheque;

        }
    }
}
