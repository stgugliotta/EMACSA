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
    /// Creado		: 2010-02-26
    /// Accion		: Implementacion de la Interface de la Entidad LogFactura
    /// Objeto		: EMACSA_NUCLEO.dbo.log_factura
    /// Descripcion	: 
    /// </summary>
    public class LOG_FacturaService : ILOG_FacturaService
    {
        #region ILogFacturaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>LOG_FacturaDataContracts</value>
        public LOG_FacturaDataContracts Load(int id)
        {
            try
            {
                LogFacturaAdmin logfacturaAdmin = new LogFacturaAdmin();
                return (LOG_FacturaDataContracts)logfacturaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: LogFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(LOG_FacturaDataContracts oLOG_Factura)
        {
            try
            {
                LogFacturaAdmin logfacturaAdmin = new LogFacturaAdmin();
                logfacturaAdmin.Delete((LogFactura)oLOG_Factura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : LogFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(LOG_FacturaDataContracts oLOG_Factura)
        {
            try
            {
                LogFacturaAdmin logfacturaAdmin = new LogFacturaAdmin();
                logfacturaAdmin.Update((LogFactura)oLOG_Factura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : LogFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(LOG_FacturaDataContracts oLOG_Factura)
        {
            try
            {
                LogFacturaAdmin logfacturaAdmin = new LogFacturaAdmin();
                logfacturaAdmin.Insert((LogFactura)oLOG_Factura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : LogFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public LOG_FacturaDataContracts GetLogFactura(int id)
        {
            try
            {
                LogFacturaAdmin logfacturaAdmin = new LogFacturaAdmin();
                return (LOG_FacturaDataContracts)logfacturaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetLogFactura : LogFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<LOG_FacturaDataContracts> GetAllLogFacturas()
        {
            try
            {
                LogFacturaAdmin logfacturaAdmin = new LogFacturaAdmin();
                List<LogFactura> resultList = logfacturaAdmin.GetAllLogFacturas();

                return resultList.ConvertAll<LOG_FacturaDataContracts>(
                    delegate(LogFactura tempLogFactura) { return (LOG_FacturaDataContracts)tempLogFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllLogFacturas : LogFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<LOG_FacturaDataContracts> GetAllLogFacturasByIdFactura(int idFactura)
        {
            try
            {
                LogFacturaAdmin logfacturaAdmin = new LogFacturaAdmin();
                List<LogFactura> resultList = logfacturaAdmin.GetAllLogFacturasByIdFactura(idFactura);

                return resultList.ConvertAll<LOG_FacturaDataContracts>(
                    delegate(LogFactura tempLogFactura) { return (LOG_FacturaDataContracts)tempLogFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllLogFacturas_ByIdFactura : LogFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}