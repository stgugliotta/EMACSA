using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto DeudorDiaCobro 
    /// </summary>
    public class DeudorDiaCobroAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto DeudorDiaCobro 
        /// </summary>
        /// <param name="idDiaCobro"></param>		
        /// <returns></returns>
        public DeudorDiaCobro Load(int idDiaCobro)
        {
            DeudorDiaCobro oReturn = new DeudorDiaCobro();
            try
            {
                using (DALDeudorDiaCobro dalDeudorDiaCobro = new DALDeudorDiaCobro())
                {
                    oReturn = dalDeudorDiaCobro.Load(idDiaCobro);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto DeudorDiaCobro
        /// </summary>
        /// <param name="oDeudorDiaCobro"></param>
        public void Delete(DeudorDiaCobro oDeudorDiaCobro)
        {
            try
            {
                using (DALDeudorDiaCobro dalDeudorDiaCobro = new DALDeudorDiaCobro())
                {
                    dalDeudorDiaCobro.Delete(oDeudorDiaCobro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto DeudorDiaCobro 
        /// </summary>
        /// <param name="oDeudorDiaCobro"></param>
        public void Update(DeudorDiaCobro oDeudorDiaCobro)
        {
            try
            {
                using (DALDeudorDiaCobro dalDeudorDiaCobro = new DALDeudorDiaCobro())
                {
                    dalDeudorDiaCobro.Update(oDeudorDiaCobro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto DeudorDiaCobro 
        /// </summary>
        /// <param name="oDeudorDiaCobro"></param>
        public void Insert(DeudorDiaCobro oDeudorDiaCobro)
        {
            try
            {
                using (DALDeudorDiaCobro dalDeudorDiaCobro = new DALDeudorDiaCobro())
                {
                    dalDeudorDiaCobro.Insert(oDeudorDiaCobro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto DeudorDiaCobro 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idDiaCobro"></param>     
        /// <returns></returns>
        public DeudorDiaCobro GetDeudorDiaCobro(int idDiaCobro)
        {
            DeudorDiaCobro oReturn = new DeudorDiaCobro();
            try
            {
                using (DALDeudorDiaCobro dalDeudorDiaCobro = new DALDeudorDiaCobro())
                {
                    oReturn = dalDeudorDiaCobro.Load(idDiaCobro);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos DeudorDiaCobro
        /// de la tabla dbo.TBL_Deudor_Dia_Cobro
        /// </summary>
        /// <returns></returns>
        public List<DeudorDiaCobro> GetAllDeudorDiaCobros()
        {
            List<DeudorDiaCobro> lstDeudorDiaCobro = new List<DeudorDiaCobro>();
            try
            {
                using (DALDeudorDiaCobro dalDeudorDiaCobro = new DALDeudorDiaCobro())
                {
                    lstDeudorDiaCobro = dalDeudorDiaCobro.GetAllDeudorDiaCobros();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudorDiaCobro;

        }

        public List<DeudorDiaCobro> GetAllDeudorDiaCobrosPorIdDeudor(int id_deudor)
        {
            List<DeudorDiaCobro> lstDeudorDiaCobro = new List<DeudorDiaCobro>();
            try
            {
                using (DALDeudorDiaCobro dalDeudorDiaCobro = new DALDeudorDiaCobro())
                {
                    lstDeudorDiaCobro = dalDeudorDiaCobro.GetAllDeudorDiaCobrosPorIdDeudor(id_deudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudorDiaCobro;

        }
    }
}
