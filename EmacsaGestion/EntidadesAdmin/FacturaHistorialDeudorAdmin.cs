using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;
using Common.DataContracts;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Factura 
    /// </summary>
    public class FacturaHistorialDeudorAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Factura 
        /// </summary>
        /// <param name="idFactura"></param>		
        /// <returns></returns>
        public FacturaHistorialDeudor Load(int idFactura)
        {
            FacturaHistorialDeudor oReturn = new FacturaHistorialDeudor();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    oReturn = dalFactura.Load(idFactura);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Factura
        /// </summary>
        /// <param name="oFactura"></param>
        public void Delete(FacturaHistorialDeudor oFactura)
        {
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    dalFactura.Delete(oFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Factura 
        /// </summary>
        /// <param name="oFactura"></param>
        public void Update(FacturaHistorialDeudor oFactura)
        {
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    dalFactura.Update(oFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Factura 
        /// </summary>
        /// <param name="oFactura"></param>
        public void Insert(FacturaHistorialDeudor oFactura)
        {
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    dalFactura.Insert(oFactura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Factura 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idFactura"></param>                 
        /// <returns></returns>
        public FacturaHistorialDeudor GetFactura(int idFactura)
        {
            FacturaHistorialDeudor oReturn = new FacturaHistorialDeudor();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    oReturn = dalFactura.Load(idFactura);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Factura
        /// de la tabla dbo.MTR_Factura
        /// </summary>
        /// <returns></returns>
        public List<FacturaHistorialDeudor> GetAllFacturas()
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }



        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Factura
        /// de la tabla dbo.MTR_Factura
        /// </summary>
        /// <returns></returns>
        public List<FacturaHistorialDeudor> GetAllFacturasPorIdDeudor(int idDeudor)
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdDeudor(idDeudor);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }

        public List<FacturaHistorialDeudor> GetAllFacturasPorIdClienteEntreFechas(int idCliente, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdClienteEntreFechas(idCliente, fechaDesde , fechaHasta);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }


        public List<FacturaHistorialDeudor> GetAllFacturasPorVariosIdDeudor(string idDeudores)
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasPorVariosIdDeudor(idDeudores);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }

        public List<FacturaHistorialDeudor> GetAllFacturasPorIdDeudorSinFiltroDeEstado(int idDeudor)
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdDeudorSinFiltroDeEstado(idDeudor);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }

        /// <summary>
        /// Metodo para traer una lista de la totalidad de los objetos Factura
        /// de la tabla dbo.MTR_Factura
        /// </summary>
        /// <returns></returns>
        public List<FacturaHistorialDeudor> GetAllFacturasPorIdClienteyIdDeudor(int idCliente, int idDeudor)
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdClienteyIdDeudor(idCliente, idDeudor);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }

        /// <summary>
        /// Metodo para traer una lista de la totalidad de los objetos Factura
        /// de la tabla dbo.MTR_Factura
        /// </summary>
        /// <returns></returns>
        public List<FacturaHistorialDeudor> GetAllFacturasPorIdClienteyIdDeudorIdEstado(int idCliente, int idDeudor, int idEstado)
        {
            List<FacturaHistorialDeudor> lstFactura = null;
            List<FacturaHistorialDeudor> lstFacturaFiltradas = null;
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdClienteyIdDeudor(idCliente, idDeudor);

                }

                lstFacturaFiltradas = new List<FacturaHistorialDeudor>();
                foreach (FacturaHistorialDeudor factura in lstFactura)
                {

                    if (factura.IdEstadoFactura == idEstado)
                    {
                        lstFacturaFiltradas.Add(factura);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFacturaFiltradas;

        }

        public List<FacturaHistorialDeudor> GetAllFacturasPorIdClienteyIdDeudorACobrar(int idCliente, int idDeudor, DateTime fechaProximaGestion)
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdClienteyIdDeudorACobrar(idCliente, idDeudor, fechaProximaGestion);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }

        public List<FacturaHistorialDeudor> GetAllFacturasPorIdDeudorEntreFechas(int idDeudor, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdDeudorEntreFechas(idDeudor, fechaDesde, fechaHasta);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }


        public List<FacturaHistorialDeudor> GetAllFacturasPorCriteria(FacturaHistorialDeudor oFactura)
        {
            List<FacturaHistorialDeudor> lstFactura = new List<FacturaHistorialDeudor>();
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstFactura = dalFactura.GetAllFacturasByCriteria(oFactura);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }

        public List<DeudorHojaDeRutaDataContracts> getHojaDeRuta(DateTime fechaProximaGestion)
        {
            List<DeudorHojaDeRutaDataContracts> lstHojaDeRutaDto = null;
            try
            {
                using (DALFacturaHistorialDeudor dalFactura = new DALFacturaHistorialDeudor())
                {
                    lstHojaDeRutaDto = dalFactura.getHojaDeRuta(fechaProximaGestion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstHojaDeRutaDto;

        }

    }
}
