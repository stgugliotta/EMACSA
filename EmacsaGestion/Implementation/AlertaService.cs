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
    /// Creado		: 2011-03-07
    /// Accion		: Implementacion de la Interface de la Entidad Alerta
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_alerta
    /// Descripcion	: 
    /// </summary>
    public class AlertaService : IAlertaService
    {
        #region IAlertaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto AlertaDataContracts
        /// </summary>
        /// <value>AlertaDataContracts</value>
        public AlertaDataContracts Load(int idAlerta)
        {
            try
            {
                AlertaAdmin alertaAdmin = new AlertaAdmin();
                return (AlertaDataContracts)alertaAdmin.Load(idAlerta);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: AlertaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un AlertaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(AlertaDataContracts oAlerta)
        {
            try
            {
                AlertaAdmin alertaAdmin = new AlertaAdmin();
                alertaAdmin.Delete((Alerta)oAlerta);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : AlertaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto AlertaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(AlertaDataContracts oAlerta)
        {
            try
            {
                AlertaAdmin alertaAdmin = new AlertaAdmin();
                alertaAdmin.Update((Alerta)oAlerta);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : AlertaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto AlertaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(AlertaDataContracts oAlerta)
        {
            try
            {
                AlertaAdmin alertaAdmin = new AlertaAdmin();
                alertaAdmin.Insert((Alerta)oAlerta);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : AlertaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto AlertaDataContracts
        /// </summary>
        /// <value>void</value>
        public AlertaDataContracts GetAlerta(int idAlerta)
        {
            try
            {
                AlertaAdmin alertaAdmin = new AlertaAdmin();
                return (AlertaDataContracts)alertaAdmin.Load(idAlerta);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetAlerta : AlertaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos AlertaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<AlertaDataContracts> GetAllAlertas()
        {
            try
            {
                AlertaAdmin alertaAdmin = new AlertaAdmin();
                List<Alerta> resultList = alertaAdmin.GetAllAlertas();

                return resultList.ConvertAll<AlertaDataContracts>(
                    delegate(Alerta tempAlerta) { return (AlertaDataContracts)tempAlerta; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAlertas : AlertaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}