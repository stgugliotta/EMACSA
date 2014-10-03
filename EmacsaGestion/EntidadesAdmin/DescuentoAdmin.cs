using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Descuento 
    /// </summary>
    public class DescuentoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Descuento 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public Descuento Load(int id)
        {
            Descuento oReturn = new Descuento();
            try
            {
                using (DALDescuento dalDescuento = new DALDescuento())
                {
                    oReturn = dalDescuento.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Descuento
        /// </summary>
        /// <param name="oDescuento"></param>
        public void Delete(Descuento oDescuento)
        {
            try
            {
                using (DALDescuento dalDescuento = new DALDescuento())
                {
                    dalDescuento.Delete(oDescuento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Descuento 
        /// </summary>
        /// <param name="oDescuento"></param>
        public void Update(Descuento oDescuento)
        {
            try
            {
                using (DALDescuento dalDescuento = new DALDescuento())
                {
                    dalDescuento.Update(oDescuento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Descuento 
        /// </summary>
        /// <param name="oDescuento"></param>
        public void Insert(Descuento oDescuento)
        {
            try
            {
                using (DALDescuento dalDescuento = new DALDescuento())
                {
                    dalDescuento.Insert(oDescuento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Descuento 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        public Descuento GetDescuento(int id)
        {
            Descuento oReturn = new Descuento();
            try
            {
                using (DALDescuento dalDescuento = new DALDescuento())
                {
                    oReturn = dalDescuento.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Descuento
        /// de la tabla dbo.TBL_Descuento
        /// </summary>
        /// <returns></returns>
        public List<Descuento> GetAllDescuentos()
        {
            List<Descuento> lstDescuento = new List<Descuento>();
            try
            {
                using (DALDescuento dalDescuento = new DALDescuento())
                {
                    lstDescuento = dalDescuento.GetAllDescuentos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDescuento;

        }
    }
}
