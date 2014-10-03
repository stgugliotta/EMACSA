using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto DeudorDiaReclamo 
    /// </summary>
    public class DeudorDiaReclamoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto DeudorDiaReclamo 
        /// </summary>
        /// <param name="idDiaReclamo"></param>		
        /// <returns></returns>
        public DeudorDiaReclamo Load(int idDiaReclamo)
        {
            DeudorDiaReclamo oReturn = new DeudorDiaReclamo();
            try
            {
                using (DALDeudorDiaReclamo dalDeudorDiaReclamo = new DALDeudorDiaReclamo())
                {
                    oReturn = dalDeudorDiaReclamo.Load(idDiaReclamo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto DeudorDiaReclamo
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        public void Delete(DeudorDiaReclamo oDeudorDiaReclamo)
        {
            try
            {
                using (DALDeudorDiaReclamo dalDeudorDiaReclamo = new DALDeudorDiaReclamo())
                {
                    dalDeudorDiaReclamo.Delete(oDeudorDiaReclamo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto DeudorDiaReclamo 
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        public void Update(DeudorDiaReclamo oDeudorDiaReclamo)
        {
            try
            {
                using (DALDeudorDiaReclamo dalDeudorDiaReclamo = new DALDeudorDiaReclamo())
                {
                    dalDeudorDiaReclamo.Update(oDeudorDiaReclamo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto DeudorDiaReclamo 
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        public void Insert(DeudorDiaReclamo oDeudorDiaReclamo)
        {
            try
            {
                using (DALDeudorDiaReclamo dalDeudorDiaReclamo = new DALDeudorDiaReclamo())
                {
                    dalDeudorDiaReclamo.Insert(oDeudorDiaReclamo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto DeudorDiaReclamo 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idDiaReclamo"></param>     
        /// <returns></returns>
        public DeudorDiaReclamo GetDeudorDiaReclamo(int idDiaReclamo)
        {
            DeudorDiaReclamo oReturn = new DeudorDiaReclamo();
            try
            {
                using (DALDeudorDiaReclamo dalDeudorDiaReclamo = new DALDeudorDiaReclamo())
                {
                    oReturn = dalDeudorDiaReclamo.Load(idDiaReclamo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos DeudorDiaReclamo
        /// de la tabla dbo.TBL_Deudor_Dia_Reclamo
        /// </summary>
        /// <returns></returns>
        public List<DeudorDiaReclamo> GetAllDeudorDiaReclamo(int id_deudor)
        {
            List<DeudorDiaReclamo> lstDeudorDiaReclamo = new List<DeudorDiaReclamo>();
            try
            {
                using (DALDeudorDiaReclamo dalDeudorDiaReclamo = new DALDeudorDiaReclamo())
                {
                    lstDeudorDiaReclamo = dalDeudorDiaReclamo.GetAllDeudorDiaReclamo(id_deudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudorDiaReclamo;

        }
    }
}
