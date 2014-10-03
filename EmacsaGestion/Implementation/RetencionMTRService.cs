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
    /// Accion		: Implementacion de la Interface de la Entidad RetencionMTR
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_retencion
    /// Descripcion	: 
    /// </summary>
    public class RetencionMTRService : IRetencionMTRService
    {
        #region IRetencionMTRService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>RetencionMTRDataContracts</value>
        public RetencionMTRDataContracts Load()
        {
            try
            {
                RetencionMTRAdmin retencionmtrAdmin = new RetencionMTRAdmin();
                return (RetencionMTRDataContracts)retencionmtrAdmin.Load();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: RetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un RetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(RetencionMTRDataContracts oRetencionMTR)
        {
            try
            {
                RetencionMTRAdmin retencionmtrAdmin = new RetencionMTRAdmin();
                retencionmtrAdmin.Delete((RetencionMTR)oRetencionMTR);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : RetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(RetencionMTRDataContracts oRetencionMTR)
        {
            try
            {
                RetencionMTRAdmin retencionmtrAdmin = new RetencionMTRAdmin();
                retencionmtrAdmin.Update((RetencionMTR)oRetencionMTR);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : RetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(RetencionMTRDataContracts oRetencionMTR)
        {
            try
            {
                RetencionMTRAdmin retencionmtrAdmin = new RetencionMTRAdmin();
                retencionmtrAdmin.Insert((RetencionMTR)oRetencionMTR);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : RetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public RetencionMTRDataContracts GetRetencionMTR()
        {
            try
            {
                RetencionMTRAdmin retencionmtrAdmin = new RetencionMTRAdmin();
                return (RetencionMTRDataContracts)retencionmtrAdmin.Load();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetRetencionMTR : RetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos RetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        public List<RetencionMTRDataContracts> GetAllRetencionMTRs()
        {
            try
            {
                RetencionMTRAdmin retencionmtrAdmin = new RetencionMTRAdmin();
                List<RetencionMTR> resultList = retencionmtrAdmin.GetAllRetencionMTRs();

                return resultList.ConvertAll<RetencionMTRDataContracts>(
                    delegate(RetencionMTR tempRetencionMTR) { return (RetencionMTRDataContracts)tempRetencionMTR; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllRetencionMTRs : RetencionMTRService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}