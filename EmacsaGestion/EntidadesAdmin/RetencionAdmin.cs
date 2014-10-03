using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Retencion 
    /// </summary>
    public class RetencionAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Retencion 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public Retencion Load(int id)
        {
            Retencion oReturn = new Retencion();
            try
            {
                using (DALRetencion dalRetencion = new DALRetencion())
                {
                    oReturn = dalRetencion.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Retencion
        /// </summary>
        /// <param name="oRetencion"></param>
        public void Delete(Retencion oRetencion)
        {
            try
            {
                using (DALRetencion dalRetencion = new DALRetencion())
                {
                    dalRetencion.Delete(oRetencion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Retencion 
        /// </summary>
        /// <param name="oRetencion"></param>
        public void Update(Retencion oRetencion)
        {
            try
            {
                using (DALRetencion dalRetencion = new DALRetencion())
                {
                    dalRetencion.Update(oRetencion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Retencion 
        /// </summary>
        /// <param name="oRetencion"></param>
        public void Insert(Retencion oRetencion)
        {
            try
            {
                using (DALRetencion dalRetencion = new DALRetencion())
                {
                    dalRetencion.Insert(oRetencion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Retencion 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>    
        /// <returns></returns>
        public Retencion GetRetencion(int id)
        {
            Retencion oReturn = new Retencion();
            try
            {
                using (DALRetencion dalRetencion = new DALRetencion())
                {
                    oReturn = dalRetencion.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Retencion
        /// de la tabla dbo.TBL_Retencion
        /// </summary>
        /// <returns></returns>
        public List<Retencion> GetAllRetencions()
        {
            List<Retencion> lstRetencion = new List<Retencion>();
            try
            {
                using (DALRetencion dalRetencion = new DALRetencion())
                {
                    lstRetencion = dalRetencion.GetAllRetencions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRetencion;

        }
    }
}
