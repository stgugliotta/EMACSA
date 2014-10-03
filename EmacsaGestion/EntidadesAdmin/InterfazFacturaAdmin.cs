using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;
using Common.DataContracts;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto InterfazFactura 
    /// </summary>
    public class InterfazFacturaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto InterfazFactura 
        /// </summary>
        /// <param name="idInterfazFactura"></param>		
        /// <returns></returns>
        public InterfazFactura Load(short idInterfazFactura)
        {
            InterfazFactura oReturn = new InterfazFactura();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    oReturn = dalInterfazFactura.Load(idInterfazFactura);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto InterfazFactura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        public void Delete(InterfazFactura oInterfazFactura)
        {
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    dalInterfazFactura.Delete(oInterfazFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto InterfazFactura 
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        public void Update(InterfazFactura oInterfazFactura)
        {
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    dalInterfazFactura.Update(oInterfazFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto InterfazFactura 
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        public void Insert(InterfazFactura oInterfazFactura)
        {
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    dalInterfazFactura.Insert(oInterfazFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertPreview(InterfazFactura oInterfazFactura)
        {
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    dalInterfazFactura.InsertPreview(oInterfazFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateTablePreview()
        {
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    dalInterfazFactura.TruncateTablePreview();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteLastImport(int idCliente)
        {
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    dalInterfazFactura.DeleteLastImport(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteLastImportPreview(int idCliente)
        {
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    dalInterfazFactura.DeleteLastImportPreview(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo de lectura de objeto InterfazFactura 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idInterfazFactura"></param>   
        /// <returns></returns>
        public InterfazFactura GetInterfazFactura(short idInterfazFactura)
        {
            InterfazFactura oReturn = new InterfazFactura();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    oReturn = dalInterfazFactura.Load(idInterfazFactura);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos InterfazFactura
        /// de la tabla dbo.CFG_Application
        /// </summary>
        /// <returns></returns>
        public List<InterfazFactura> GetAllInterfazFacturas()
        {
            List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    lstInterfazFactura = dalInterfazFactura.GetAllInterfazFacturas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInterfazFactura;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de un cliente dado, de los objetos InterfazFactura
        /// de la tabla dbo.INT_Factura
        /// </summary>
        /// <returns></returns>
        public List<InterfazFactura> GetAllInterfazFacturasByIdCliente(int idCliente)
        {
            List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    lstInterfazFactura = dalInterfazFactura.GetAllInterfazFacturasByCliente(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInterfazFactura;

        }


        public List<InterfazFactura> GetAllFacturasBajaPorInterfazByClienteFechaProceso(int idCliente, DateTime fechaProceso)
        {
            List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    lstInterfazFactura = dalInterfazFactura.GetAllFacturasBajaPorInterfazByClienteFechaProceso(idCliente, fechaProceso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInterfazFactura;

        }
        public List<InterfazFactura> GetAllFacturasBajaPorInterfazByClienteFechaProcesoPreview(int idCliente, DateTime fechaProceso)
        {
            List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    lstInterfazFactura = dalInterfazFactura.GetAllFacturasBajaPorInterfazByClienteFechaProcesoPreview(idCliente, fechaProceso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInterfazFactura;

        }
          


        public List<InterfazFactura> GetAllInterfazFacturasByClienteFechaProceso(int idCliente, DateTime fechaProceso)
        {
            List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    lstInterfazFactura = dalInterfazFactura.GetAllInterfazFacturasByClienteFechaProceso(idCliente, fechaProceso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInterfazFactura;

        }
   

        public List<InterfazFactura> GetAllInterfazFacturasByClienteFechaProcesoPreview(int idCliente, DateTime fechaProceso)
        {
            List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    lstInterfazFactura = dalInterfazFactura.GetAllInterfazFacturasByClienteFechaProcesoPreview(idCliente, fechaProceso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInterfazFactura;

        }

        
        /// <summary>
        /// M?todo para traer una lista de la totalidad de un cliente dado, de los objetos InterfazFactura
        /// de la tabla dbo.INT_Factura
        /// </summary>
        /// <returns></returns>
        public List<InterfazFactura> GetAllFacturasBajaPorInterfazByCliente(int idCliente)
        {
            List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    lstInterfazFactura = dalInterfazFactura.GetAllFacturasBajaPorInterfazByCliente(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInterfazFactura;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de un cliente dado, de los objetos InterfazFactura
        /// de la tabla dbo.INT_Factura
        /// </summary>
        /// <returns></returns>
        public List<ImportacionFacturaDataContracts> ProcessInterfazFacturasByClientePreview(int idCliente, string idUsuario)
        {
            //List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            List<ImportacionFacturaDataContracts> retval = null;
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    retval = dalInterfazFactura.ProcessInterfazFacturasByClientePreview(idCliente, idUsuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;

        }

        public List<ImportacionFacturaDataContracts> ProcessInterfazFacturasByCliente(int idCliente, string idUsuario)
        {
            //List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            List<ImportacionFacturaDataContracts> retval = null;
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    retval = dalInterfazFactura.ProcessInterfazFacturasByCliente(idCliente, idUsuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;

        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturas()
        {
            //List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            List<ImportacionFacturaDataContracts> retval = null;
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    retval = dalInterfazFactura.getProcessResultInterfazFacturas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;

        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFecha(DateTime fecha)
        {
            //List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            List<ImportacionFacturaDataContracts> retval = null;
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    retval = dalInterfazFactura.getProcessResultInterfazFacturasPorFecha(fecha);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;

        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFechaPreview(DateTime fecha)
        {
            //List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            List<ImportacionFacturaDataContracts> retval = null;
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    retval = dalInterfazFactura.getProcessResultInterfazFacturasPorFechaPreview(fecha);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;

        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFechaPreview(int idCliente, DateTime fecha)
        {
            //List<InterfazFactura> lstInterfazFactura = new List<InterfazFactura>();
            List<ImportacionFacturaDataContracts> retval = null;
            try
            {
                using (DALInterfazFactura dalInterfazFactura = new DALInterfazFactura())
                {
                    retval = dalInterfazFactura.getProcessResultInterfazFacturasPorFechaPreview(idCliente, fecha);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;

        }




    }
}
