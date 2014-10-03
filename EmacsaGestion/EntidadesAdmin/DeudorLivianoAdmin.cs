using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Deudor 
    /// </summary>
    public class DeudorLivianoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Deudor 
        /// </summary>
        /// <param name="idDeudor"></param>		
        /// <returns></returns>
        public DeudorLiviano Load(int idDeudor)
        {
            DeudorLiviano oReturn = new DeudorLiviano();
            try
            {
                using (DALDeudorLiviano dalDeudor = new DALDeudorLiviano())
                {
                    oReturn = dalDeudor.Load(idDeudor);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


         public List<DeudorLiviano> GetAllDeudorsLivianoPorCriterioAnalista(string cliente)
        {
            List<DeudorLiviano> lstDeudor = new List<DeudorLiviano>();
            try
            {
                using (DALDeudorLiviano dalDeudor = new DALDeudorLiviano())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsLivianoPorCriterioAnalista(cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }
         public List<DeudorLiviano> GetAllDeudorsLivianoPorAnalista(string analista)
         {
             List<DeudorLiviano> lstDeudor = new List<DeudorLiviano>();
             try
             {
                 using (DALDeudorLiviano dalDeudor = new DALDeudorLiviano())
                 {
                     lstDeudor = dalDeudor.GetAllDeudorsLivianoPorAnalista(analista);
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return lstDeudor;
         }
         public List<DeudorLiviano> GetAllDeudorsLivianoGestionAnalista(string analista, bool todos, bool aVencer, int cantDias, bool incluyeVencidas, bool validarFechaReclamo, int idCliente, bool proximaGestion)
         {
             List<DeudorLiviano> lstDeudor = new List<DeudorLiviano>();
             try
             {
                 using (DALDeudorLiviano dalDeudor = new DALDeudorLiviano())
                 {
                     lstDeudor = dalDeudor.GetAllDeudorsLivianoGestionAnalista(analista, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, proximaGestion);
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return lstDeudor;
         }

         public List<DeudorLiviano> GetAllDeudorsLivianoGestionAnalistaConFiltroFechaReclamo(string analista, bool todos, bool aVencer, int cantDias, bool incluyeVencidas, bool validarFechaReclamo, int idCliente, bool proximaGestion, DateTime fechaFiltroFechaReclamo)
         {
             List<DeudorLiviano> lstDeudor = new List<DeudorLiviano>();
             try
             {
                 using (DALDeudorLiviano dalDeudor = new DALDeudorLiviano())
                 {
                     lstDeudor = dalDeudor.GetAllDeudorsLivianoGestionAnalistaConFiltroFechaReclamo(analista, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, proximaGestion, fechaFiltroFechaReclamo);
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return lstDeudor;
         }


        public List<DeudorLiviano> GetAllDeudorsLivianoPorCriterioCliente(int idCliente)
        {
            List<DeudorLiviano> lstDeudor = new List<DeudorLiviano>();
            try
            {
                using (DALDeudorLiviano dalDeudor = new DALDeudorLiviano())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsLivianoPorCriterioCliente(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }

    }
}
