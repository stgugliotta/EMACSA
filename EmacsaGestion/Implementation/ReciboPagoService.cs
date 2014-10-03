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
    /// Creado		: 2010-05-24
    /// Accion		: Implementacion de la Interface de la Entidad ReciboPago
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_recibo_pago
    /// Descripcion	: 
    /// </summary>
    public class ReciboPagoService : IReciboPagoService
    {
        #region IReciboPagoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>ReciboPagoDataContracts</value>
        public ReciboPagoDataContracts Load(int idRecibo, int idPago)
        {
            try
            {
                ReciboPagoAdmin recibopagoAdmin = new ReciboPagoAdmin();
                return (ReciboPagoDataContracts)recibopagoAdmin.Load(idRecibo, idPago);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ReciboPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ReciboPagoDataContracts oReciboPago)
        {
            try
            {
                ReciboPagoAdmin recibopagoAdmin = new ReciboPagoAdmin();
                recibopagoAdmin.Delete((ReciboPago)oReciboPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ReciboPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ReciboPagoDataContracts oReciboPago)
        {
            try
            {
                ReciboPagoAdmin recibopagoAdmin = new ReciboPagoAdmin();
                recibopagoAdmin.Update((ReciboPago)oReciboPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ReciboPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ReciboPagoDataContracts oReciboPago)
        {
            try
            {
                ReciboPagoAdmin recibopagoAdmin = new ReciboPagoAdmin();
                recibopagoAdmin.Insert((ReciboPago)oReciboPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ReciboPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public ReciboPagoDataContracts GetReciboPago(int idRecibo, int idPago)
        {
            try
            {
                ReciboPagoAdmin recibopagoAdmin = new ReciboPagoAdmin();
                return (ReciboPagoDataContracts)recibopagoAdmin.Load(idRecibo, idPago);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetReciboPago : ReciboPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ReciboPagoDataContracts> GetAllReciboPagos()
        {
            try
            {
                ReciboPagoAdmin recibopagoAdmin = new ReciboPagoAdmin();
                List<ReciboPago> resultList = recibopagoAdmin.GetAllReciboPagos();

                return resultList.ConvertAll<ReciboPagoDataContracts>(
                    delegate(ReciboPago tempReciboPago) { return (ReciboPagoDataContracts)tempReciboPago; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllReciboPagos : ReciboPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ReciboPagoDataContracts> GetAllReciboPagosByIdRecibo(int idRecibo)
        {
            try
            {
                ReciboPagoAdmin recibopagoAdmin = new ReciboPagoAdmin();
                List<ReciboPago> resultList = recibopagoAdmin.GetAllReciboPagosByIdRecibo(idRecibo);

                return resultList.ConvertAll<ReciboPagoDataContracts>(
                    delegate(ReciboPago tempReciboPago) { return (ReciboPagoDataContracts)tempReciboPago; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllReciboPagos : ReciboPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
 
        #endregion
    }
}