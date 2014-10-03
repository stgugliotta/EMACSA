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
    /// Creado		: 2010-05-07
    /// Accion		: Implementacion de la Interface de la Entidad SubTipoRetencionMTR
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_subtiporetencion
    /// Descripcion	: 
    /// </summary>
    public class SubTipoRetencionMTRService : ISubTipoRetencionMTRService
    {
        #region ISubTipoRetencionMTRService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>SubTipoRetencionMTRDataContracts</value>
        public SubTipoRetencionMTRDataContracts Load()
        {
            try
            {
                SubTipoRetencionMTRAdmin subtiporetencionmtrAdmin = new SubTipoRetencionMTRAdmin();
                return (SubTipoRetencionMTRDataContracts)subtiporetencionmtrAdmin.Load();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: SubTipoRetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(SubTipoRetencionMTRDataContracts oSubTipoRetencionMTR)
        {
            try
            {
                SubTipoRetencionMTRAdmin subtiporetencionmtrAdmin = new SubTipoRetencionMTRAdmin();
                subtiporetencionmtrAdmin.Delete((SubTipoRetencionMTR)oSubTipoRetencionMTR);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : SubTipoRetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(SubTipoRetencionMTRDataContracts oSubTipoRetencionMTR)
        {
            try
            {
                SubTipoRetencionMTRAdmin subtiporetencionmtrAdmin = new SubTipoRetencionMTRAdmin();
                subtiporetencionmtrAdmin.Update((SubTipoRetencionMTR)oSubTipoRetencionMTR);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : SubTipoRetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(SubTipoRetencionMTRDataContracts oSubTipoRetencionMTR)
        {
            try
            {
                SubTipoRetencionMTRAdmin subtiporetencionmtrAdmin = new SubTipoRetencionMTRAdmin();
                subtiporetencionmtrAdmin.Insert((SubTipoRetencionMTR)oSubTipoRetencionMTR);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : SubTipoRetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public SubTipoRetencionMTRDataContracts GetSubTipoRetencionMTR()
        {
            try
            {
                SubTipoRetencionMTRAdmin subtiporetencionmtrAdmin = new SubTipoRetencionMTRAdmin();
                return (SubTipoRetencionMTRDataContracts)subtiporetencionmtrAdmin.Load();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetSubTipoRetencionMTR : SubTipoRetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public List<SubTipoRetencionMTRDataContracts> GetAllSubTipoRetencionMTRs()
        {
            try
            {
                SubTipoRetencionMTRAdmin subtiporetencionmtrAdmin = new SubTipoRetencionMTRAdmin();
                List<SubTipoRetencionMTR> resultList = subtiporetencionmtrAdmin.GetAllSubTipoRetencionMTRs();

                return resultList.ConvertAll<SubTipoRetencionMTRDataContracts>(
                    delegate(SubTipoRetencionMTR tempSubTipoRetencionMTR) { return (SubTipoRetencionMTRDataContracts)tempSubTipoRetencionMTR; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllSubTipoRetencionMTRs : SubTipoRetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}