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
    /// Creado		: 2010-04-10
    /// Accion		: Implementacion de la Interface de la Entidad OtroPago
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_otropago
    /// Descripcion	: 
    /// </summary>
    public class OtroPagoService : IOtroPagoService
    {
        #region IOtroPagoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto OtroPagoDataContracts
        /// </summary>
        /// <value>OtroPagoDataContracts</value>
        public OtroPagoDataContracts Load(int id)
        {
            try
            {
                OtroPagoAdmin otropagoAdmin = new OtroPagoAdmin();
                return (OtroPagoDataContracts)otropagoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: OtroPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un OtroPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(OtroPagoDataContracts oOtroPago)
        {
            try
            {
                OtroPagoAdmin otropagoAdmin = new OtroPagoAdmin();
                otropagoAdmin.Delete((OtroPago)oOtroPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : OtroPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto OtroPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(OtroPagoDataContracts oOtroPago)
        {
            try
            {
                OtroPagoAdmin otropagoAdmin = new OtroPagoAdmin();
                otropagoAdmin.Update((OtroPago)oOtroPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : OtroPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto OtroPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(OtroPagoDataContracts oOtroPago)
        {
            try
            {
                OtroPagoAdmin otropagoAdmin = new OtroPagoAdmin();
                otropagoAdmin.Insert((OtroPago)oOtroPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : OtroPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto OtroPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public OtroPagoDataContracts GetOtroPago(int id)
        {
            try
            {
                OtroPagoAdmin otropagoAdmin = new OtroPagoAdmin();
                return (OtroPagoDataContracts)otropagoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetOtroPago : OtroPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos OtroPagoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<OtroPagoDataContracts> GetAllOtroPagos()
        {
            try
            {
                OtroPagoAdmin otropagoAdmin = new OtroPagoAdmin();
                List<OtroPago> resultList = otropagoAdmin.GetAllOtroPagos();

                return resultList.ConvertAll<OtroPagoDataContracts>(
                    delegate(OtroPago tempOtroPago) { return (OtroPagoDataContracts)tempOtroPago; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllOtroPagos : OtroPagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}