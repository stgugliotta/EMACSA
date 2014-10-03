using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto DatosEdicionRecibo 
    /// </summary>
    public class DatosEdicionReciboAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto DatosEdicionRecibo 
        /// </summary>

        /// <returns></returns>
        public DatosEdicionRecibo Load()
        {
            DatosEdicionRecibo oReturn = new DatosEdicionRecibo();
            try
            {
                using (DALDatosEdicionRecibo dalDatosEdicionRecibo = new DALDatosEdicionRecibo())
                {
                    oReturn = dalDatosEdicionRecibo.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto DatosEdicionRecibo
        /// </summary>
        /// <param name="oDatosEdicionRecibo"></param>
        public void Delete(DatosEdicionRecibo oDatosEdicionRecibo)
        {
            try
            {
                using (DALDatosEdicionRecibo dalDatosEdicionRecibo = new DALDatosEdicionRecibo())
                {
                    dalDatosEdicionRecibo.Delete(oDatosEdicionRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto DatosEdicionRecibo 
        /// </summary>
        /// <param name="oDatosEdicionRecibo"></param>
        public void Update(DatosEdicionRecibo oDatosEdicionRecibo)
        {
            try
            {
                using (DALDatosEdicionRecibo dalDatosEdicionRecibo = new DALDatosEdicionRecibo())
                {
                    dalDatosEdicionRecibo.Update(oDatosEdicionRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto DatosEdicionRecibo 
        /// </summary>
        /// <param name="oDatosEdicionRecibo"></param>
        public void Insert(DatosEdicionRecibo oDatosEdicionRecibo)
        {
            try
            {
                using (DALDatosEdicionRecibo dalDatosEdicionRecibo = new DALDatosEdicionRecibo())
                {
                    dalDatosEdicionRecibo.Insert(oDatosEdicionRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto DatosEdicionRecibo 
        /// se deja por compatibilidad con Standares
        /// </summary>

        /// <returns></returns>
        public DatosEdicionRecibo GetDatosEdicionRecibo()
        {
            DatosEdicionRecibo oReturn = new DatosEdicionRecibo();
            try
            {
                using (DALDatosEdicionRecibo dalDatosEdicionRecibo = new DALDatosEdicionRecibo())
                {
                    oReturn = dalDatosEdicionRecibo.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos DatosEdicionRecibo
        /// de la tabla dbo.DatosEdicionRecibo
        /// </summary>
        /// <returns></returns>
        public List<DatosEdicionRecibo> GetAllDatosEdicionRecibos()
        {
            List<DatosEdicionRecibo> lstDatosEdicionRecibo = new List<DatosEdicionRecibo>();
            try
            {
                using (DALDatosEdicionRecibo dalDatosEdicionRecibo = new DALDatosEdicionRecibo())
                {
                    lstDatosEdicionRecibo = dalDatosEdicionRecibo.GetAllDatosEdicionRecibos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDatosEdicionRecibo;

        }

        public List<DatosEdicionRecibo> GetAllDatosEdicionRecibosPorNumeroRemision(int idRemision)
        {
            List<DatosEdicionRecibo> lstDatosEdicionRecibo = new List<DatosEdicionRecibo>();
            try
            {
                using (DALDatosEdicionRecibo dalDatosEdicionRecibo = new DALDatosEdicionRecibo())
                {
                    lstDatosEdicionRecibo = dalDatosEdicionRecibo.GetAllDatosEdicionRecibosPorNumeroRemision(idRemision);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDatosEdicionRecibo;

        }

        public List<DatosEdicionRecibo> GetAllDatosEdicionRecibosPorNumeroRecibo(string numRecibo)
        {
            List<DatosEdicionRecibo> lstDatosEdicionRecibo = new List<DatosEdicionRecibo>();
            try
            {
                using (DALDatosEdicionRecibo dalDatosEdicionRecibo = new DALDatosEdicionRecibo())
                {
                    lstDatosEdicionRecibo = dalDatosEdicionRecibo.GetAllDatosEdicionRecibosPorNumeroRecibo(numRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDatosEdicionRecibo;

        }
    }
}
