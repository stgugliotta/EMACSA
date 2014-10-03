using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Transferencia 
    /// </summary>
    public class TransferenciaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Transferencia 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public Transferencia Load(int id)
        {
            Transferencia oReturn = new Transferencia();
            try
            {
                using (DALTransferencia dalTransferencia = new DALTransferencia())
                {
                    oReturn = dalTransferencia.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Transferencia
        /// </summary>
        /// <param name="oTransferencia"></param>
        public void Delete(Transferencia oTransferencia)
        {
            try
            {
                using (DALTransferencia dalTransferencia = new DALTransferencia())
                {
                    dalTransferencia.Delete(oTransferencia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Transferencia 
        /// </summary>
        /// <param name="oTransferencia"></param>
        public void Update(Transferencia oTransferencia)
        {
            try
            {
                using (DALTransferencia dalTransferencia = new DALTransferencia())
                {
                    dalTransferencia.Update(oTransferencia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Transferencia 
        /// </summary>
        /// <param name="oTransferencia"></param>
        public void Insert(Transferencia oTransferencia)
        {
            try
            {
                using (DALTransferencia dalTransferencia = new DALTransferencia())
                {
                    dalTransferencia.Insert(oTransferencia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Transferencia 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>       
        /// <returns></returns>
        public Transferencia GetTransferencia(int id)
        {
            Transferencia oReturn = new Transferencia();
            try
            {
                using (DALTransferencia dalTransferencia = new DALTransferencia())
                {
                    oReturn = dalTransferencia.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Transferencia
        /// de la tabla dbo.TBL_Transferencia
        /// </summary>
        /// <returns></returns>
        public List<Transferencia> GetAllTransferencias()
        {
            List<Transferencia> lstTransferencia = new List<Transferencia>();
            try
            {
                using (DALTransferencia dalTransferencia = new DALTransferencia())
                {
                    lstTransferencia = dalTransferencia.GetAllTransferencias();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTransferencia;

        }
    }
}
