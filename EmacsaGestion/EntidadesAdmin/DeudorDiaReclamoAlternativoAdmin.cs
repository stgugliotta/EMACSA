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
    public class DeudorDiaReclamoAlternativoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto DeudorDiaReclamo 
        /// </summary>
        /// <param name="idDiaReclamo"></param>		
        /// <returns></returns>
        public DeudorDiaReclamoAlternativo Load(int idDiaReclamo)
        {
            DeudorDiaReclamoAlternativo oReturn = new DeudorDiaReclamoAlternativo();
            try
            {
                using (DALDeudorDiaReclamoAlternativo dalDeudorDiaReclamoAlternativo = new DALDeudorDiaReclamoAlternativo())
                {
                    oReturn = dalDeudorDiaReclamoAlternativo.Load(idDiaReclamo);
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
        public void Delete(DeudorDiaReclamoAlternativo oDeudorDiaReclamoAlternativo)
        {
            try
            {
                using (DALDeudorDiaReclamoAlternativo dalDeudorDiaReclamoAlternativo = new DALDeudorDiaReclamoAlternativo())
                {
                    dalDeudorDiaReclamoAlternativo.Delete(oDeudorDiaReclamoAlternativo);
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
        public void Update(DeudorDiaReclamoAlternativo oDeudorDiaReclamoAlternativo)
        {
            try
            {
                using (DALDeudorDiaReclamoAlternativo dalDeudorDiaReclamoAlternativo = new DALDeudorDiaReclamoAlternativo())
                {
                    dalDeudorDiaReclamoAlternativo.Update(oDeudorDiaReclamoAlternativo);
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
        public void Insert(DeudorDiaReclamoAlternativo oDeudorDiaReclamoAlternativo)
        {
            try
            {
                using (DALDeudorDiaReclamoAlternativo dalDeudorDiaReclamoAlternativo = new DALDeudorDiaReclamoAlternativo())
                {
                    dalDeudorDiaReclamoAlternativo.Insert(oDeudorDiaReclamoAlternativo);
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
        public void InsertHorarioAlterntivoDeCobro(DeudorDiaReclamoAlternativo oDeudorDiaReclamoAlternativo)
        {
            try
            {
                using (DALDeudorDiaReclamoAlternativo dalDeudorDiaReclamoAlternativo = new DALDeudorDiaReclamoAlternativo())
                {
                    dalDeudorDiaReclamoAlternativo.InsertHorarioAlterntivoDeCobro(oDeudorDiaReclamoAlternativo);
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
        public DeudorDiaReclamoAlternativo GetDeudorDiaReclamo(int idDiaReclamoAlternativo)
        {
            DeudorDiaReclamoAlternativo oReturn = new DeudorDiaReclamoAlternativo();
            try
            {
                using (DALDeudorDiaReclamoAlternativo dalDeudorDiaReclamoAlternativo = new DALDeudorDiaReclamoAlternativo())
                {
                    oReturn = dalDeudorDiaReclamoAlternativo.Load(idDiaReclamoAlternativo);
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
        public List<DeudorDiaReclamoAlternativo> GetAllDeudorDiaReclamo(int id_deudor)
        {
            List<DeudorDiaReclamoAlternativo> lstDeudorDiaReclamoAlternativo = new List<DeudorDiaReclamoAlternativo>();
            try
            {
                using (DALDeudorDiaReclamoAlternativo dalDeudorDiaReclamoAlternativo = new DALDeudorDiaReclamoAlternativo())
                {
                    lstDeudorDiaReclamoAlternativo = dalDeudorDiaReclamoAlternativo.GetAllDeudorDiaReclamoAlternativo(id_deudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudorDiaReclamoAlternativo;

        }
    }
}
