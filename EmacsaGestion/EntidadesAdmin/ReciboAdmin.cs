using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Recibo 
    /// </summary>
    public class ReciboAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Recibo 
        /// </summary>
        /// <param name="idRecibo"></param>		
        /// <returns></returns>
        public Recibo Load(int idRecibo)
        {
            Recibo oReturn = new Recibo();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    oReturn = dalRecibo.Load(idRecibo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo de lectura de objeto Recibo 
        /// </summary>
        /// <param name="idRecibo"></param>		
        /// <returns></returns>
        public Recibo Load(Recibo  oRecibo)
        {
            Recibo oReturn = new Recibo();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    oReturn = dalRecibo.Load(oRecibo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo de lectura de objeto Recibo 
        /// </summary>
        /// <param name="idRecibo"></param>		
        /// <returns></returns>
        public Recibo Load(Recibo oRecibo, int idCliente)
        {
            Recibo oReturn = new Recibo();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    oReturn = dalRecibo.Load(oRecibo,idCliente);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Recibo
        /// </summary>
        /// <param name="oRecibo"></param>
        public void Delete(Recibo oRecibo)
        {
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    dalRecibo.Delete(oRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Recibo oRecibo,int idCliente)
        {
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    dalRecibo.Delete(oRecibo,idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Recibo 
        /// </summary>
        /// <param name="oRecibo"></param>
        public void Update(Recibo oRecibo)
        {
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    dalRecibo.Update(oRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Recibo 
        /// </summary>
        /// <param name="oRecibo"></param>
        public void Insert(Recibo oRecibo)
        {
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                   dalRecibo.Insert(oRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Recibo 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idRecibo"></param>      
        /// <returns></returns>
        public Recibo GetRecibo(int idRecibo)
        {
            Recibo oReturn = new Recibo();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    oReturn = dalRecibo.Load(idRecibo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Recibo
        /// de la tabla dbo.TBL_Recibo
        /// </summary>
        /// <returns></returns>
        public List<Recibo> GetAllRecibos()
        {
            List<Recibo> lstRecibo = new List<Recibo>();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    lstRecibo = dalRecibo.GetAllRecibos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRecibo;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Recibo
        /// de la tabla dbo.TBL_Recibo
        /// </summary>
        /// <returns></returns>
        public List<Recibo> GetAllRecibosByIdRemision(int idRemision)
        {
            List<Recibo> lstRecibo = new List<Recibo>();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    lstRecibo = dalRecibo.GetAllRecibosByIdRemision(idRemision);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRecibo;

        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Recibo
        /// de la tabla dbo.TBL_Recibo
        /// </summary>
        /// <returns></returns>
        public List<Recibo> GetAllRecibosByIdCliente(int idCliente)
        {
            List<Recibo> lstRecibo = new List<Recibo>();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    lstRecibo = dalRecibo.GetAllRecibosByIdCliente(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRecibo;

        }

        public List<Recibo> GetAllRecibosByIdClienteSinUsar(int idCliente)
        {
            List<Recibo> lstRecibo = new List<Recibo>();
            Cliente cli = new Cliente();
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    cli = dalCliente.Load(idCliente);
                }
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    lstRecibo = dalRecibo.GetAllRecibosByIdClienteSinUsar(idCliente);
                }

                foreach (var item in lstRecibo)
                {
                    item.Cliente = cli;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRecibo;

        }

        public Recibo GetReciboByNumReciboIdDeudorIdCliente(string pszNumRecibo, int IdDeudor, int IdCliente)
        {
            Recibo oReturn = new Recibo();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    oReturn = dalRecibo.GetReciboByNumReciboIdDeudorIdCliente(pszNumRecibo, IdDeudor, IdCliente);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        public Recibo GetReciboByNumReciboIdCliente(string pszNumRecibo, int IdCliente)
        {
            Recibo oReturn = new Recibo();
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    oReturn = dalRecibo.GetReciboByNumReciboIdCliente(pszNumRecibo, IdCliente);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        public void InsertRelacion(int idRecibo, int idRemision)
        {
            try
            {
                using (DALRecibo dalRecibo = new DALRecibo())
                {
                    dalRecibo.InsertRelacion(idRecibo, idRemision);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}
