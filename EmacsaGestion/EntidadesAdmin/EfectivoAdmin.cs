using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Efectivo 
    /// </summary>
    public class EfectivoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Efectivo 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public Efectivo Load(int id)
        {
            Efectivo oReturn = new Efectivo();
            try
            {
                using (DALEfectivo dalEfectivo = new DALEfectivo())
                {
                    oReturn = dalEfectivo.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Efectivo
        /// </summary>
        /// <param name="oEfectivo"></param>
        public void Delete(Efectivo oEfectivo)
        {
            try
            {
                using (DALEfectivo dalEfectivo = new DALEfectivo())
                {
                    dalEfectivo.Delete(oEfectivo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Efectivo 
        /// </summary>
        /// <param name="oEfectivo"></param>
        public void Update(Efectivo oEfectivo)
        {
            try
            {
                using (DALEfectivo dalEfectivo = new DALEfectivo())
                {
                    dalEfectivo.Update(oEfectivo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Efectivo 
        /// </summary>
        /// <param name="oEfectivo"></param>
        public void Insert(Efectivo oEfectivo)
        {
            try
            {
                using (DALEfectivo dalEfectivo = new DALEfectivo())
                {
                    dalEfectivo.Insert(oEfectivo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Efectivo 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        public Efectivo GetEfectivo(int id)
        {
            Efectivo oReturn = new Efectivo();
            try
            {
                using (DALEfectivo dalEfectivo = new DALEfectivo())
                {
                    oReturn = dalEfectivo.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Efectivo
        /// de la tabla dbo.TBL_Efectivo
        /// </summary>
        /// <returns></returns>
        public List<Efectivo> GetAllEfectivos()
        {
            List<Efectivo> lstEfectivo = new List<Efectivo>();
            try
            {
                using (DALEfectivo dalEfectivo = new DALEfectivo())
                {
                    lstEfectivo = dalEfectivo.GetAllEfectivos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEfectivo;

        }
    }
}
