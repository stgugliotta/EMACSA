using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto CompensacionDePago 
    /// </summary>
    public class CompensacionDePagoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto CompensacionDePago 
        /// </summary>
        /// <param name="idCompensacion"></param>		
        /// <returns></returns>
        public CompensacionDePago Load(int idCompensacion)
        {
            CompensacionDePago oReturn = new CompensacionDePago();
            try
            {
                using (DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago())
                {
                    oReturn = dalCompensacionDePago.Load(idCompensacion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto CompensacionDePago
        /// </summary>
        /// <param name="oCompensacionDePago"></param>
        public void Delete(CompensacionDePago oCompensacionDePago)
        {
            try
            {
                using (DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago())
                {
                    dalCompensacionDePago.Delete(oCompensacionDePago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto CompensacionDePago 
        /// </summary>
        /// <param name="oCompensacionDePago"></param>
        public void Update(CompensacionDePago oCompensacionDePago)
        {
            try
            {
                using (DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago())
                {
                    dalCompensacionDePago.Update(oCompensacionDePago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto CompensacionDePago 
        /// </summary>
        /// <param name="oCompensacionDePago"></param>
        public void Insert(CompensacionDePago oCompensacionDePago)
        {
            try
            {
                using (DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago())
                {
                    dalCompensacionDePago.Insert(oCompensacionDePago);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto CompensacionDePago 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idCompensacion"></param>      
        /// <returns></returns>
        public CompensacionDePago GetCompensacionDePago(int idCompensacion)
        {
            CompensacionDePago oReturn = new CompensacionDePago();
            try
            {
                using (DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago())
                {
                    oReturn = dalCompensacionDePago.Load(idCompensacion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo de lectura de objeto CompensacionDePago 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idCompensacion"></param>      
        /// <returns></returns>
        public CompensacionDePago GetCompensacionDePagoPorNumeroDeRecibo(string numRecibo)
        {
            CompensacionDePago oReturn = new CompensacionDePago();
            try
            {
                using (DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago())
                {
                    oReturn = dalCompensacionDePago.GetCompensacionDePagoPorNumeroDeRecibo(numRecibo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos CompensacionDePago
        /// de la tabla dbo.TBL_CompensacionDePago
        /// </summary>
        /// <returns></returns>
        public List<CompensacionDePago> GetAllCompensacionDePagos()
        {
            List<CompensacionDePago> lstCompensacionDePago = new List<CompensacionDePago>();
            try
            {
                using (DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago())
                {
                    lstCompensacionDePago = dalCompensacionDePago.GetAllCompensacionDePagos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCompensacionDePago;

        }
    }
}
