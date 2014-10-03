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
    /// Creado		: 2010-05-17
    /// Accion		: Implementacion de la Interface de la Entidad ProntoPago
    /// Objeto		: EMACSA_NUCLEO.dbo.cfg_pronto_pago
    /// Descripcion	: 
    /// </summary>
    public class ProntoPagoService : IProntoPagoService
    {
        #region IProntoPagoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>ProntoPagoDataContracts</value>
        public ProntoPagoDataContracts Load(int id)
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                return (ProntoPagoDataContracts)prontopagoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ProntoPagoDataContracts oProntoPago)
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                prontopagoAdmin.Delete((ProntoPago)oProntoPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void EliminarPorId(int id)
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                prontopagoAdmin.EliminarPorId(id);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  EliminarPorId : ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ProntoPagoDataContracts oProntoPago)
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                prontopagoAdmin.Update((ProntoPago)oProntoPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ProntoPagoDataContracts oProntoPago)
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                prontopagoAdmin.Insert((ProntoPago)oProntoPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public ProntoPagoDataContracts GetProntoPago(int id)
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                return (ProntoPagoDataContracts)prontopagoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetProntoPago : ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ProntoPagoDataContracts> GetAllProntoPagos()
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                List<ProntoPago> resultList = prontopagoAdmin.GetAllProntoPagos();

                return resultList.ConvertAll<ProntoPagoDataContracts>(
                    delegate(ProntoPago tempProntoPago) { return (ProntoPagoDataContracts)tempProntoPago; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllProntoPagos : ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ProntoPagoDataContracts> GetAllProntoPagosByIdClienteYIdDeudor(int idCliente, int idDeudor)
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                List<ProntoPago> resultList = prontopagoAdmin.GetAllProntoPagosByIdClienteYIdDeudor(idCliente, idDeudor);

                return resultList.ConvertAll<ProntoPagoDataContracts>(
                    delegate(ProntoPago tempProntoPago) { return (ProntoPagoDataContracts)tempProntoPago; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllProntoPagos : ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<ProntoPagoDataContracts> GetAllProntoPagosByIdCliente(int idCliente)
        {
            try
            {
                ProntoPagoAdmin prontopagoAdmin = new ProntoPagoAdmin();
                List<ProntoPago> resultList = prontopagoAdmin.GetAllProntoPagosByIdCliente(idCliente);

                return resultList.ConvertAll<ProntoPagoDataContracts>(
                    delegate(ProntoPago tempProntoPago) { return (ProntoPagoDataContracts)tempProntoPago; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllProntoPagosByIdCliente : ProntoPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}