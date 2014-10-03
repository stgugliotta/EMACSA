using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Cambio 
    /// </summary>
    public class CambioAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Cambio 
        /// </summary>
        /// <param name="idCambio"></param>		
        /// <returns></returns>
        public Cambio Load(int idCambio)
        {
            Cambio oReturn = new Cambio();
            try
            {
                using (DALCambio dalCambio = new DALCambio())
                {
                    oReturn = dalCambio.Load(idCambio);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Cambio
        /// </summary>
        /// <param name="oCambio"></param>
        public void Delete(Cambio oCambio)
        {
            try
            {
                using (DALCambio dalCambio = new DALCambio())
                {
                    dalCambio.Delete(oCambio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Cambio 
        /// </summary>
        /// <param name="oCambio"></param>
        public void Update(Cambio oCambio)
        {
            try
            {
                using (DALCambio dalCambio = new DALCambio())
                {
                    dalCambio.Update(oCambio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Cambio 
        /// </summary>
        /// <param name="oCambio"></param>
        public void Insert(Cambio oCambio)
        {
            try
            {
                using (DALCambio dalCambio = new DALCambio())
                {
                    dalCambio.Insert(oCambio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Cambio 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idCambio"></param>        
        /// <returns></returns>
        public Cambio GetCambio(int idCambio)
        {
            Cambio oReturn = new Cambio();
            try
            {
                using (DALCambio dalCambio = new DALCambio())
                {
                    oReturn = dalCambio.Load(idCambio);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Cambio
        /// de la tabla dbo.TBL_Cambio
        /// </summary>
        /// <returns></returns>
        public List<Cambio> GetAllCambios()
        {
            List<Cambio> lstCambio = new List<Cambio>();
            try
            {
                using (DALCambio dalCambio = new DALCambio())
                {
                    lstCambio = dalCambio.GetAllCambios();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCambio;

        }
                /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Cambio
        /// de la tabla dbo.TBL_Cambio
        /// </summary>
        /// <returns></returns>


      
        
    }
}
