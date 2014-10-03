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
    /// Creado		: 2010-04-03
    /// Accion		: Implementacion de la Interface de la Entidad TipoPagoRaro
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_tipopagoraro
    /// Descripcion	: 
    /// </summary>
    public class TipoPagoRaroService : ITipoPagoRaroService
    {
        #region ITipoPagoRaroService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>TipoPagoRaroDataContracts</value>
        public TipoPagoRaroDataContracts Load(int id)
        {
            try
            {
                TipoPagoRaroAdmin tipopagoraroAdmin = new TipoPagoRaroAdmin();
                return (TipoPagoRaroDataContracts)tipopagoraroAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: TipoPagoRaroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un TipoPagoRaroDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(TipoPagoRaroDataContracts oTipoPagoRaro)
        {
            try
            {
                TipoPagoRaroAdmin tipopagoraroAdmin = new TipoPagoRaroAdmin();
                tipopagoraroAdmin.Delete((TipoPagoRaro)oTipoPagoRaro);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : TipoPagoRaroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(TipoPagoRaroDataContracts oTipoPagoRaro)
        {
            try
            {
                TipoPagoRaroAdmin tipopagoraroAdmin = new TipoPagoRaroAdmin();
                tipopagoraroAdmin.Update((TipoPagoRaro)oTipoPagoRaro);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : TipoPagoRaroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(TipoPagoRaroDataContracts oTipoPagoRaro)
        {
            try
            {
                TipoPagoRaroAdmin tipopagoraroAdmin = new TipoPagoRaroAdmin();
                tipopagoraroAdmin.Insert((TipoPagoRaro)oTipoPagoRaro);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : TipoPagoRaroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>void</value>
        public TipoPagoRaroDataContracts GetTipoPagoRaro(int id)
        {
            try
            {
                TipoPagoRaroAdmin tipopagoraroAdmin = new TipoPagoRaroAdmin();
                return (TipoPagoRaroDataContracts)tipopagoraroAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetTipoPagoRaro : TipoPagoRaroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos TipoPagoRaroDataContracts
        /// </summary>
        /// <value>void</value>
        public List<TipoPagoRaroDataContracts> GetAllTipoPagoRaros()
        {
            try
            {
                TipoPagoRaroAdmin tipopagoraroAdmin = new TipoPagoRaroAdmin();
                List<TipoPagoRaro> resultList = tipopagoraroAdmin.GetAllTipoPagoRaros();

                return resultList.ConvertAll<TipoPagoRaroDataContracts>(
                    delegate(TipoPagoRaro tempTipoPagoRaro) { return (TipoPagoRaroDataContracts)tempTipoPagoRaro; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllTipoPagoRaros : TipoPagoRaroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}