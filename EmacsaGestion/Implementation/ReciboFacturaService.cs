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
    /// Creado		: 2010-04-11
    /// Accion		: Implementacion de la Interface de la Entidad ReciboFactura
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_recibo_factura
    /// Descripcion	: 
    /// </summary>
    public class ReciboFacturaService : IReciboFacturaService
    {
        #region IReciboFacturaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>ReciboFacturaDataContracts</value>
        public ReciboFacturaDataContracts Load(int id)
        {
            try
            {
                ReciboFacturaAdmin recibofacturaAdmin = new ReciboFacturaAdmin();
                return (ReciboFacturaDataContracts)recibofacturaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ReciboFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ReciboFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ReciboFacturaDataContracts oReciboFactura)
        {
            try
            {
                ReciboFacturaAdmin recibofacturaAdmin = new ReciboFacturaAdmin();
                recibofacturaAdmin.Delete((ReciboFactura)oReciboFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ReciboFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ReciboFacturaDataContracts oReciboFactura)
        {
            try
            {
                ReciboFacturaAdmin recibofacturaAdmin = new ReciboFacturaAdmin();
                recibofacturaAdmin.Update((ReciboFactura)oReciboFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ReciboFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ReciboFacturaDataContracts oReciboFactura)
        {
            try
            {
                ReciboFacturaAdmin recibofacturaAdmin = new ReciboFacturaAdmin();
                recibofacturaAdmin.Insert((ReciboFactura)oReciboFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ReciboFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public ReciboFacturaDataContracts GetReciboFactura(int id)
        {
            try
            {
                ReciboFacturaAdmin recibofacturaAdmin = new ReciboFacturaAdmin();
                return (ReciboFacturaDataContracts)recibofacturaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetReciboFactura : ReciboFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ReciboFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ReciboFacturaDataContracts> GetAllReciboFacturas()
        {
            try
            {
                ReciboFacturaAdmin recibofacturaAdmin = new ReciboFacturaAdmin();
                List<ReciboFactura> resultList = recibofacturaAdmin.GetAllReciboFacturas();

                return resultList.ConvertAll<ReciboFacturaDataContracts>(
                    delegate(ReciboFactura tempReciboFactura) { return (ReciboFacturaDataContracts)tempReciboFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllReciboFacturas : ReciboFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<ReciboFacturaDataContracts> GetAllReciboFacturasByIdRecibo(int idRecibo)
        {
            try
            {
                ReciboFacturaAdmin recibofacturaAdmin = new ReciboFacturaAdmin();
                List<ReciboFactura> resultList = recibofacturaAdmin.GetAllReciboFacturasByIdRecibo(idRecibo);

                return resultList.ConvertAll<ReciboFacturaDataContracts>(
                    delegate(ReciboFactura tempReciboFactura) { return (ReciboFacturaDataContracts)tempReciboFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllReciboFacturas : ReciboFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion

    }
}