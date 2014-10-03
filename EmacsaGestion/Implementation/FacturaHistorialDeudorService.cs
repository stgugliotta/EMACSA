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
    public class FacturaHistorialDeudorService : IFacturaHistorialDeudorService
    {
        #region IFacturaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto FacturaDataContracts
        /// </summary>
        /// <value>FacturaDataContracts</value>
        public FacturaHistorialDeudorDataContracts Load(int idFactura)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                return (FacturaHistorialDeudorDataContracts)facturaAdmin.Load(idFactura);
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
        public void Delete(FacturaHistorialDeudorDataContracts oFactura)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                facturaAdmin.Delete((FacturaHistorialDeudor)oFactura);

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
        public void Update(FacturaHistorialDeudorDataContracts oFactura)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                facturaAdmin.Update((FacturaHistorialDeudor)oFactura);

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
        public void Insert(FacturaHistorialDeudorDataContracts oFactura)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                facturaAdmin.Insert((FacturaHistorialDeudor)oFactura);

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
        public FacturaHistorialDeudorDataContracts GetFactura(int idFactura)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                return (FacturaHistorialDeudorDataContracts)facturaAdmin.Load(idFactura);
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
        public List<FacturaHistorialDeudorDataContracts> GetAllFacturas()
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturas();

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
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
        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdDeudor(int idDeudor)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturasPorIdDeudor(idDeudor);

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdClienteEntreFechas(int idCliente, DateTime desde, DateTime hasta)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturasPorIdClienteEntreFechas(idCliente, desde, hasta);

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorVariosIdDeudor(string idDeudores)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturasPorVariosIdDeudor(idDeudores);

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdDeudorSinFiltroDeEstado(int idDeudor)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturasPorIdDeudorSinFiltroDeEstado(idDeudor);

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
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
        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdClienteyIdDeudor(int idCliente, int idDeudor)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturasPorIdClienteyIdDeudor(idCliente, idDeudor);

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdClienteyIdDeudor : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdClienteyIdDeudorACobrar(int idCliente, int idDeudor, DateTime fechaProximaGestion)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturasPorIdClienteyIdDeudorACobrar(idCliente, idDeudor, fechaProximaGestion);

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdClienteyIdDeudorACobrar : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdClienteyIdDeudorIdEstado(int idCliente, int idDeudor, int idEstado)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturasPorIdClienteyIdDeudorIdEstado(idCliente, idDeudor, idEstado);

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllFacturasPorIdClienteyIdDeudorIdEstado : FacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdDeudorEntreFechas(int idDeudor, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> resultList = facturaAdmin.GetAllFacturasPorIdDeudorEntreFechas(idDeudor, fechaDesde, fechaHasta);

                return resultList.ConvertAll<FacturaHistorialDeudorDataContracts>(
                    delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });
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


        public List<FacturaHistorialDeudorDataContracts> GetAllFacturasByCriteria(FacturaHistorialDeudorDataContracts oFactura)
        {
            try
            {
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
                List<FacturaHistorialDeudor> facturas = facturaAdmin.GetAllFacturasPorCriteria((FacturaHistorialDeudor)oFactura);

                return facturas.ConvertAll<FacturaHistorialDeudorDataContracts>(
               delegate(FacturaHistorialDeudor tempFactura) { return (FacturaHistorialDeudorDataContracts)tempFactura; });

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
                FacturaHistorialDeudorAdmin facturaAdmin = new FacturaHistorialDeudorAdmin();
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
    }
}