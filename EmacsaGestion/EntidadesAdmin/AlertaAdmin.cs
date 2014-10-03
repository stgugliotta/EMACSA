using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Alerta 
    /// </summary>
    public class AlertaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Alerta 
        /// </summary>
        /// <param name="idAlerta"></param>		
        /// <returns></returns>
        public Alerta Load(int idAlerta)
        {
            Alerta oReturn = new Alerta();
            try
            {
                using (DALAlerta dalAlerta = new DALAlerta())
                {
                    oReturn = dalAlerta.Load(idAlerta);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Alerta
        /// </summary>
        /// <param name="oAlerta"></param>
        public void Delete(Alerta oAlerta)
        {
            try
            {
                using (DALAlerta dalAlerta = new DALAlerta())
                {
                    dalAlerta.Delete(oAlerta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Alerta 
        /// </summary>
        /// <param name="oAlerta"></param>
        public void Update(Alerta oAlerta)
        {
            try
            {
                using (DALAlerta dalAlerta = new DALAlerta())
                {
                    dalAlerta.Update(oAlerta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Alerta 
        /// </summary>
        /// <param name="oAlerta"></param>
        public void Insert(Alerta oAlerta)
        {
            try
            {
                using (DALAlerta dalAlerta = new DALAlerta())
                {
                    dalAlerta.Insert(oAlerta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Alerta 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idAlerta"></param>  
        /// <returns></returns>
        public Alerta GetAlerta(int idAlerta)
        {
            Alerta oReturn = new Alerta();
            try
            {
                using (DALAlerta dalAlerta = new DALAlerta())
                {
                    oReturn = dalAlerta.Load(idAlerta);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Alerta
        /// de la tabla dbo.MTR_Alerta
        /// </summary>
        /// <returns></returns>
        public List<Alerta> GetAllAlertas()
        {
            List<Alerta> lstAlerta = new List<Alerta>();
            try
            {
                using (DALAlerta dalAlerta = new DALAlerta())
                {
                    lstAlerta = dalAlerta.GetAllAlertas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAlerta;

        }
    }
}
