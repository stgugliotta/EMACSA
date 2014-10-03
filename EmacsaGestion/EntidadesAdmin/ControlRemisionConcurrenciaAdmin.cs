using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ControlRemisionConcurrencia 
    /// </summary>
    public class ControlRemisionConcurrenciaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto ControlRemisionConcurrencia 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public ControlRemisionConcurrencia Load(int id)
        {
            ControlRemisionConcurrencia oReturn = new ControlRemisionConcurrencia();
            try
            {
                using (DALControlRemisionConcurrencia dalControlRemisionConcurrencia = new DALControlRemisionConcurrencia())
                {
                    oReturn = dalControlRemisionConcurrencia.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto ControlRemisionConcurrencia
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        public void Delete(ControlRemisionConcurrencia oControlRemisionConcurrencia)
        {
            try
            {
                using (DALControlRemisionConcurrencia dalControlRemisionConcurrencia = new DALControlRemisionConcurrencia())
                {
                    dalControlRemisionConcurrencia.Delete(oControlRemisionConcurrencia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto ControlRemisionConcurrencia 
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        public void Update(ControlRemisionConcurrencia oControlRemisionConcurrencia)
        {
            try
            {
                using (DALControlRemisionConcurrencia dalControlRemisionConcurrencia = new DALControlRemisionConcurrencia())
                {
                    dalControlRemisionConcurrencia.Update(oControlRemisionConcurrencia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto ControlRemisionConcurrencia 
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        public void Insert(ControlRemisionConcurrencia oControlRemisionConcurrencia)
        {
            try
            {
                using (DALControlRemisionConcurrencia dalControlRemisionConcurrencia = new DALControlRemisionConcurrencia())
                {
                    dalControlRemisionConcurrencia.Insert(oControlRemisionConcurrencia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto ControlRemisionConcurrencia 
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        public string InsertWithResult(ControlRemisionConcurrencia oControlRemisionConcurrencia)
        {
            try
            {
                using (DALControlRemisionConcurrencia dalControlRemisionConcurrencia = new DALControlRemisionConcurrencia())
                {
                    return dalControlRemisionConcurrencia.InsertWithResult(oControlRemisionConcurrencia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto ControlRemisionConcurrencia 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>         
        /// <returns></returns>
        public ControlRemisionConcurrencia GetControlRemisionConcurrencia(int id)
        {
            ControlRemisionConcurrencia oReturn = new ControlRemisionConcurrencia();
            try
            {
                using (DALControlRemisionConcurrencia dalControlRemisionConcurrencia = new DALControlRemisionConcurrencia())
                {
                    oReturn = dalControlRemisionConcurrencia.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ControlRemisionConcurrencia
        /// de la tabla dbo.TBL_Control_Concurrencia_Remision
        /// </summary>
        /// <returns></returns>
        public List<ControlRemisionConcurrencia> GetAllControlRemisionConcurrencias()
        {
            List<ControlRemisionConcurrencia> lstControlRemisionConcurrencia = new List<ControlRemisionConcurrencia>();
            try
            {
                using (DALControlRemisionConcurrencia dalControlRemisionConcurrencia = new DALControlRemisionConcurrencia())
                {
                    lstControlRemisionConcurrencia = dalControlRemisionConcurrencia.GetAllControlRemisionConcurrencias();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstControlRemisionConcurrencia;

        }
    }
}
