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
    public class FacturaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Factura 
        /// </summary>
        /// <param name="idFactura"></param>		
        /// <returns></returns>
        public Factura Load(int idFactura)
        {
            Factura oReturn = new Factura();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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
        public void Delete(Factura oFactura)
        {
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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
        public void Update(Factura oFactura)
        {
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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
        public void Insert(Factura oFactura)
        {
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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
        public Factura GetFactura(int idFactura)
        {
            Factura oReturn = new Factura();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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
        public List<Factura> GetAllFacturas()
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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
        public List<Factura> GetAllFacturasPorIdDeudor(int idDeudor)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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
        public List<Factura> GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(int idDeudor)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
                {
                    lstFactura = dalFactura.GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(idDeudor);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }


        

        public List<Factura> GetDataTableFacturasPorDeudorQueNoEstenEnNingunRecibo(int idDeudor)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
                {
                    lstFactura = dalFactura.GetDataTableFacturasPorDeudorQueNoEstenEnNingunRecibo(idDeudor);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Factura donde proximagestion >= getdate()
        /// de la tabla dbo.MTR_Factura
        /// </summary>
        /// <returns></returns>
        public List<Factura> GetAllFacturasPorIdDeudorProximaGestion(int idDeudor)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdDeudorProximaGestion(idDeudor);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }


        public List<Factura> GetAllFacturasPorIdClienteEntreFechas(int idCliente, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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


        public List<Factura> GetAllFacturasPorVariosIdDeudor(string idDeudores)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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

        public List<Factura> GetDataTableFacturasPorDeudorPosiblesDeEdicion(int idDeudor,string numRecibo)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
                {
                    lstFactura = dalFactura.GetDataTableFacturasPorDeudorPosiblesDeEdicion(idDeudor, numRecibo);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }

        public List<Factura> GetAllFacturasPorIdDeudorSinFiltroDeEstado(int idDeudor)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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
        public List<Factura> GetAllFacturasPorIdClienteyIdDeudor(int idCliente, int idDeudor)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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



        public List<Factura> GetAllFacturasPorIdClienteyIdDeudorParaEstadoDeCuenta(int idCliente, int idDeudor)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdClienteyIdDeudorParaEstadoDeCuenta(idCliente, idDeudor);

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
        public List<Factura> GetAllFacturasPorIdClienteyIdDeudorIdEstado(int idCliente, int idDeudor, int idEstado)
        {
            List<Factura> lstFactura = null;
            List<Factura> lstFacturaFiltradas = null;
            try
            {
                using (DALFactura dalFactura = new DALFactura())
                {
                    lstFactura = dalFactura.GetAllFacturasPorIdClienteyIdDeudor(idCliente, idDeudor);

                }

                lstFacturaFiltradas = new List<Factura>();
                foreach (Factura factura in lstFactura)
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

        public List<Factura> GetAllFacturasPorIdClienteyIdDeudorACobrar(int idCliente, int idDeudor, DateTime fechaProximaGestion)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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

        public List<Factura> GetAllFacturasPorIdDeudorEntreFechas(int idDeudor, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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

        public List<Factura> GetAllFacturasByCriteriaTodosLosEstados(Factura oFactura)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
                {
                    lstFactura = dalFactura.GetAllFacturasByCriteriaTodosLosEstados(oFactura);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFactura;

        }
        public List<Factura> GetAllFacturasPorCriteria(Factura oFactura)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
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

        public List<Factura> GetAllFacturasByNumeroCompleto(Factura oFactura)
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (DALFactura dalFactura = new DALFactura())
                {
                    lstFactura = dalFactura.GetAllFacturasByNumeroCompleto(oFactura);

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
                using (DALFactura dalFactura = new DALFactura())
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
