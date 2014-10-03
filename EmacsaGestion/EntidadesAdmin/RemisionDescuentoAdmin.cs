using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto RemisionDescuento 
    /// </summary>
    public class RemisionDescuentoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto RemisionDescuento 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public RemisionDescuento Load(int id)
        {
            RemisionDescuento oReturn = new RemisionDescuento();
            try
            {
                using (DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento())
                {
                    oReturn = dalRemisionDescuento.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto RemisionDescuento
        /// </summary>
        /// <param name="oRemisionDescuento"></param>
        public void Delete(RemisionDescuento oRemisionDescuento)
        {
            try
            {
                using (DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento())
                {
                    dalRemisionDescuento.Delete(oRemisionDescuento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto RemisionDescuento 
        /// </summary>
        /// <param name="oRemisionDescuento"></param>
        public void Update(RemisionDescuento oRemisionDescuento)
        {
            try
            {
                using (DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento())
                {
                    dalRemisionDescuento.Update(oRemisionDescuento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto RemisionDescuento 
        /// </summary>
        /// <param name="oRemisionDescuento"></param>
        public void Insert(RemisionDescuento oRemisionDescuento)
        {
            try
            {
                using (DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento())
                {
                    dalRemisionDescuento.Insert(oRemisionDescuento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto RemisionDescuento 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>     
        /// <returns></returns>
        public RemisionDescuento GetRemisionDescuento(int id)
        {
            RemisionDescuento oReturn = new RemisionDescuento();
            try
            {
                using (DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento())
                {
                    oReturn = dalRemisionDescuento.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos RemisionDescuento
        /// de la tabla dbo.TBL_Remision_Descuento
        /// </summary>
        /// <returns></returns>
        public List<RemisionDescuento> GetAllRemisionDescuentos()
        {
            List<RemisionDescuento> lstRemisionDescuento = new List<RemisionDescuento>();
            try
            {
                using (DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento())
                {
                    lstRemisionDescuento = dalRemisionDescuento.GetAllRemisionDescuentos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRemisionDescuento;

        }
    }
}
