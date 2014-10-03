using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
    /// <summary>
    /// Creado		: 2010-02-06
    /// Accion		: Implementacion de la Interface de la Entidad Factura
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_factura
    /// Descripcion	: 
    /// </summary>
    public class FacturaService : IFacturaService
    {
        #region IFacturaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto FacturaDataContracts
        /// </summary>
        /// <value>FacturaDataContracts</value>
        public FacturaDataContracts Load(int idFactura)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                return (FacturaDataContracts)facturaAdmin.Load(idFactura);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(FacturaDataContracts oFactura)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                facturaAdmin.Delete((Factura)oFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(FacturaDataContracts oFactura)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                facturaAdmin.Update((Factura)oFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(FacturaDataContracts oFactura)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                facturaAdmin.Insert((Factura)oFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public FacturaDataContracts GetFactura(int idFactura)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                return (FacturaDataContracts)facturaAdmin.Load(idFactura);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetFactura : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<FacturaDataContracts> GetAllFacturas()
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturas();

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturas : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        /// 
        /// 
        public List<FacturaDataContracts> GetAllFacturasPorIdDeudor(int idDeudor)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdDeudor(idDeudor);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<FacturaDataContracts> GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(int idDeudor)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(idDeudor);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        


        public List<FacturaDataContracts> GetDataTableFacturasPorDeudorQueNoEstenEnNingunRecibo(int idDeudor)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetDataTableFacturasPorDeudorQueNoEstenEnNingunRecibo(idDeudor);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<FacturaDataContracts> GetAllFacturasPorIdDeudorProximaGestion(int idDeudor)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdDeudorProximaGestion(idDeudor);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudorProximaGestion : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<FacturaDataContracts> GetAllFacturasPorIdClienteEntreFechas(int idCliente, DateTime desde, DateTime hasta)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdClienteEntreFechas(idCliente, desde, hasta);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaDataContracts> GetAllFacturasPorVariosIdDeudor(string idDeudores)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorVariosIdDeudor(idDeudores);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaDataContracts> GetDataTableFacturasPorDeudorPosiblesDeEdicion(int idDeudor, string numRecibo)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetDataTableFacturasPorDeudorPosiblesDeEdicion(idDeudor, numRecibo);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        public List<FacturaDataContracts> GetAllFacturasPorIdDeudorSinFiltroDeEstado(int idDeudor)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdDeudorSinFiltroDeEstado(idDeudor);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos FacturaDataContracts por idCliente e idDeudor
        /// </summary>
        /// <value>void</value>
        public List<FacturaDataContracts> GetAllFacturasPorIdClienteyIdDeudor(int idCliente, int idDeudor)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdClienteyIdDeudor(idCliente,idDeudor);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdClienteyIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaDataContracts> GetAllFacturasPorIdClienteyIdDeudorACobrar(int idCliente, int idDeudor, DateTime fechaProximaGestion)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdClienteyIdDeudorACobrar(idCliente, idDeudor, fechaProximaGestion);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdClienteyIdDeudorACobrar : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaDataContracts> GetAllFacturasPorIdClienteyIdDeudorIdEstado(int idCliente, int idDeudor, int idEstado)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdClienteyIdDeudorIdEstado(idCliente, idDeudor, idEstado);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdClienteyIdDeudorIdEstado : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<FacturaDataContracts> GetAllFacturasPorIdDeudorEntreFechas(int idDeudor,DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdDeudorEntreFechas(idDeudor,fechaDesde,fechaHasta);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudorEntreFechas : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion

        #region IFacturaService Members


        public List<FacturaDataContracts> GetAllFacturasByCriteriaTodosLosEstados(FacturaDataContracts oFactura)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
               List<Factura> facturas= facturaAdmin.GetAllFacturasByCriteriaTodosLosEstados((Factura)oFactura);

               return facturas.ConvertAll<FacturaDataContracts>(
               delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        public List<FacturaDataContracts> GetAllFacturasByCriteria(FacturaDataContracts oFactura)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
               List<Factura> facturas= facturaAdmin.GetAllFacturasPorCriteria((Factura)oFactura);

               return facturas.ConvertAll<FacturaDataContracts>(
               delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaDataContracts> GetAllFacturasByNumeroCompleto(FacturaDataContracts oFactura)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
               List<Factura> facturas= facturaAdmin.GetAllFacturasByNumeroCompleto((Factura)oFactura);

               return facturas.ConvertAll<FacturaDataContracts>(
               delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        
        public List<DeudorHojaDeRutaDataContracts> getHojaDeRuta(DateTime fechaProximaGestion)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<DeudorHojaDeRutaDataContracts> hdrDtoList = facturaAdmin.getHojaDeRuta(fechaProximaGestion);

                return hdrDtoList;

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion

        #region IFacturaService Members


        public List<FacturaDataContracts> GetAllFacturasPorIdClienteyIdDeudorParaEstadoDeCuenta(int idCliente, int idDeudor)
        {
            try
            {
                FacturaAdmin facturaAdmin = new FacturaAdmin();
                List<Factura> resultList = facturaAdmin.GetAllFacturasPorIdClienteyIdDeudorParaEstadoDeCuenta(idCliente, idDeudor);

                return resultList.ConvertAll<FacturaDataContracts>(
                    delegate(Factura tempFactura) { return (FacturaDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdClienteyIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}