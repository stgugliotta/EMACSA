using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Deudor 
    /// </summary>
    public class DeudorAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Deudor 
        /// </summary>
        /// <param name="idDeudor"></param>		
        /// <returns></returns>
        public Deudor Load(int idDeudor)
        {
            Deudor oReturn = new Deudor();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    oReturn = dalDeudor.Load(idDeudor);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para eliminar un objeto Deudor
        /// </summary>
        /// <param name="oDeudor"></param>
        public void Delete(Deudor oDeudor)
        {
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    dalDeudor.Delete(oDeudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Deudor 
        /// </summary>
        /// <param name="oDeudor"></param>
        public void Update(Deudor oDeudor)
        {
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    dalDeudor.Update(oDeudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Deudor 
        /// </summary>
        /// <param name="oDeudor"></param>
        public void Insert(Deudor oDeudor)
        {
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    dalDeudor.Insert(oDeudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert2(Deudor oDeudor)
        {
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    return dalDeudor.Insert2(oDeudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo de lectura de objeto Deudor 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idDeudor"></param>                   
        /// <returns></returns>
        public Deudor GetDeudor(int idDeudor)
        {
            Deudor oReturn = new Deudor();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    oReturn = dalDeudor.Load(idDeudor);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        public Deudor GetLastId()
        {
            Deudor oReturn = new Deudor();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    oReturn = dalDeudor.GetLastId();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Deudor
        /// de la tabla dbo.MTR_Deudor
        /// </summary>
        /// <returns></returns>
        public List<Deudor> GetAllDeudors()
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudors();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Deudor
        /// de la tabla dbo.MTR_Deudor
        /// </summary>
        /// <returns></returns>
        public List<Deudor> GetAllDeudorsPorCriterioDeudor(string nombre)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsPorCriterioDeudor(nombre);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }
        
        public List<Deudor> GetAllDeudorsPorCriterioCliente(string cliente, int idFiltro)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsPorCriterioCliente(cliente,idFiltro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }
        public List<Deudor> GetAllDeudorsPorCriterioCliente(int idCliente)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsPorCriterioCliente(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }

        

        public List<Deudor> GetAllDeudorsPorCriterioZona(int idZona)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsPorCriterioZona(idZona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }


        public List<Deudor> GetAllDeudorsPorCriterioClienteFecha(string cliente, DateTime vencimientoDesde, DateTime vencimientoHasta)
                {
                    List<Deudor> lstDeudor = new List<Deudor>();
                    try
                    {
                        using (DALDeudor dalDeudor = new DALDeudor())
                        {
                            lstDeudor = dalDeudor.GetAllDeudorsPorCriterioClienteFecha(cliente, vencimientoDesde, vencimientoHasta);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return lstDeudor;

                }



        public List<Deudor> GetAllDeudorsOpt(string ids)
         {
             List<Deudor> lstDeudor = new List<Deudor>();
             try
             {
                 using (DALDeudor dalDeudor = new DALDeudor())
                 {
                     lstDeudor = dalDeudor.GetAllDeudorsOpt(ids);
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return lstDeudor;

         }
        public List<Deudor> GetAllDeudorsPorAlfaNum(string alfaNum)
         {
             List<Deudor> lstDeudor = new List<Deudor>();
             try
             {
                 using (DALDeudor dalDeudor = new DALDeudor())
                 {
                     lstDeudor = dalDeudor.GetAllDeudorsPorAlfaNum(alfaNum);
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return lstDeudor;

         }

        public List<Deudor> GetAllDeudorsPorAlfaNumAndIdCliente(string alfaNum, int idCliente)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsPorAlfaNumAndIdCliente(alfaNum, idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }

        public List<Deudor> GetAllDeudorsPorCriterioAnalista(string analista)
         {
             List<Deudor> lstDeudor = new List<Deudor>();
             try
             {
                 using (DALDeudor dalDeudor = new DALDeudor())
                 {
                     lstDeudor = dalDeudor.GetAllDeudorsPorCriterioAnalista(analista);
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return lstDeudor;

         }

        public List<Deudor> GetAllDeudorsGestionAnalista(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsGestionAnalista(analista, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, proximaGestion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }


        public List<Deudor> GetAllDeudorsGestionAnalistaConFiltroFechaReclamo(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion, DateTime filtroFechaReclamo)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsGestionAnalistaConFiltroFechaReclamo(analista, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, proximaGestion, filtroFechaReclamo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }

        public List<Deudor> GetAllLocalidadCp()
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllLocalidadCp();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }




        public List<Deudor> GetAllLocalidadPorCriterioIdZona(int id)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllLocalidadPorCriterioIdZona(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }

        public List<Deudor> GetAllLocalidadCp_PorCp(string Cp)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllLocalidadCp_PorCP(Cp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;
        }

        public List<Deudor> GetAllLocalidadCp_PorLocalidad(string Localidad)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllLocalidadCp_PorLocalidad(Localidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;
        }

        public List<Deudor> GetAllDeudorsByClienteYAnalista(int idDeudor,string analista)
        {
            List<Deudor> lstDeudor = new List<Deudor>();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    lstDeudor = dalDeudor.GetAllDeudorsByClienteYAnalista(idDeudor,analista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeudor;

        }

        public void AsignarAnalista(int idDeudor, int idAnalista)
        {
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    dalDeudor.AsignarAnalista(idDeudor,idAnalista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarAnalista_Cliente(int idCliente, int idDeudor, int idAnalista)
        {
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    dalDeudor.AsignarAnalista_Cliente(idCliente, idDeudor, idAnalista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        
        public void EliminarAnalista(int idDeudor, int idAnalista)
        {
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    dalDeudor.EliminarAnalista(idDeudor, idAnalista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesactivarPorId(int idDeudor)
        {
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    dalDeudor.DesactivarPorId(idDeudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo de lectura de objeto Deudor 
        /// </summary>
        /// <param name="idDeudor"></param>		
        /// <returns></returns>
        public Deudor getDeudorByCuit(string cuit)
        {
            Deudor oReturn = new Deudor();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    oReturn = dalDeudor.getDeudorByCuit(cuit);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        public Deudor GetDeudorConDireccionCompleta(int idDeudor)
        {
            Deudor oReturn = new Deudor();
            try
            {
                using (DALDeudor dalDeudor = new DALDeudor())
                {
                    oReturn = dalDeudor.GetDeudorConDireccionCompleta(idDeudor);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }
    }
}
