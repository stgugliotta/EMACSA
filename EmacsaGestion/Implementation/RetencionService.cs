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
    /// Accion		: Implementacion de la Interface de la Entidad Retencion
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_retencion
    /// Descripcion	: 
    /// </summary>
    public class RetencionService : IRetencionService
    {
        #region IRetencionService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto RetencionDataContracts
        /// </summary>
        /// <value>RetencionDataContracts</value>
        public RetencionDataContracts Load(int id)
        {
            try
            {
                RetencionAdmin retencionAdmin = new RetencionAdmin();
                return (RetencionDataContracts)retencionAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: RetencionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un RetencionDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(RetencionDataContracts oRetencion)
        {
            try
            {
                RetencionAdmin retencionAdmin = new RetencionAdmin();
                retencionAdmin.Delete((Retencion)oRetencion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : RetencionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto RetencionDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(RetencionDataContracts oRetencion)
        {
            try
            {
                RetencionAdmin retencionAdmin = new RetencionAdmin();
                retencionAdmin.Update((Retencion)oRetencion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : RetencionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto RetencionDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(RetencionDataContracts oRetencion)
        {
            try
            {
                RetencionAdmin retencionAdmin = new RetencionAdmin();
                retencionAdmin.Insert((Retencion)oRetencion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : RetencionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto RetencionDataContracts
        /// </summary>
        /// <value>void</value>
        public RetencionDataContracts GetRetencion(int id)
        {
            try
            {
                RetencionAdmin retencionAdmin = new RetencionAdmin();
                return (RetencionDataContracts)retencionAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetRetencion : RetencionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos RetencionDataContracts
        /// </summary>
        /// <value>void</value>
        public List<RetencionDataContracts> GetAllRetencions()
        {
            try
            {
                RetencionAdmin retencionAdmin = new RetencionAdmin();
                List<Retencion> resultList = retencionAdmin.GetAllRetencions();

                return resultList.ConvertAll<RetencionDataContracts>(
                    delegate(Retencion tempRetencion) { return (RetencionDataContracts)tempRetencion; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllRetencions : RetencionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}