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
    /// Accion		: Implementacion de la Interface de la Entidad Accion
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_accion
    /// Descripcion	: 
    /// </summary>
    public class AccionService : IAccionService
    {
        #region IAccionService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto AccionDataContracts
        /// </summary>
        /// <value>AccionDataContracts</value>
        public AccionDataContracts Load(int idAccion)
        {
            try
            {
                AccionAdmin accionAdmin = new AccionAdmin();
                return (AccionDataContracts)accionAdmin.Load(idAccion);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: AccionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un AccionDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(AccionDataContracts oAccion)
        {
            try
            {
                AccionAdmin accionAdmin = new AccionAdmin();
                accionAdmin.Delete((Accion)oAccion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : AccionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto AccionDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(AccionDataContracts oAccion)
        {
            try
            {
                AccionAdmin accionAdmin = new AccionAdmin();
                accionAdmin.Update((Accion)oAccion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : AccionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto AccionDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(AccionDataContracts oAccion)
        {
            try
            {
                AccionAdmin accionAdmin = new AccionAdmin();
                accionAdmin.Insert((Accion)oAccion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : AccionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto AccionDataContracts
        /// </summary>
        /// <value>void</value>
        public AccionDataContracts GetAccion(int idAccion)
        {
            try
            {
                AccionAdmin accionAdmin = new AccionAdmin();
                return (AccionDataContracts)accionAdmin.Load(idAccion);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetAccion : AccionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos AccionDataContracts
        /// </summary>
        /// <value>void</value>
        public List<AccionDataContracts> GetAllAccions()
        {
            try
            {
                AccionAdmin accionAdmin = new AccionAdmin();
                List<Accion> resultList = accionAdmin.GetAllAccions();

                return resultList.ConvertAll<AccionDataContracts>(
                    delegate(Accion tempAccion) { return (AccionDataContracts)tempAccion; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAccions : AccionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<AccionDataContracts> GetAllAccionsByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc)
        {
            try
            {
                AccionAdmin accionAdmin = new AccionAdmin();
                List<Accion> resultList = accionAdmin.GetAllAccionsByIdFacturaIdClienteFechaVenc(idFactura, idCliente, fechaVenc);

                return resultList.ConvertAll<AccionDataContracts>(
                    delegate(Accion tempAccion) { return (AccionDataContracts)tempAccion; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAccions : AccionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }



        public List<AccionDataContracts> GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado)
        {
            try
            {
                AccionAdmin accionAdmin = new AccionAdmin();
                List<Accion> resultList = accionAdmin.GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(idFactura, idCliente, fechaVenc, idEstado);

                return resultList.ConvertAll<AccionDataContracts>(
                    delegate(Accion tempAccion) { return (AccionDataContracts)tempAccion; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAccions : AccionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion

        #region IAccionService Members


        public AccionDataContracts GetLastActionByIdFactura(int idFactura)
        {
            AccionAdmin accionAdmin = new AccionAdmin();
            return (AccionDataContracts)accionAdmin.GetLastActionByIdFactura(idFactura);
        }

        #endregion
    }
}