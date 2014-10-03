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
    /// Creado		: 2010-02-08
    /// Accion		: Implementacion de la Interface de la Entidad Reporte
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_reporte
    /// Descripcion	: 
    /// </summary>
    public class ReporteService : IReporteService
    {
        #region IReporteService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ReporteDataContracts
        /// </summary>
        /// <value>ReporteDataContracts</value>
        public ReporteDataContracts Load(int id)
        {
            try
            {
                ReporteAdmin reporteAdmin = new ReporteAdmin();
                return (ReporteDataContracts)reporteAdmin.Load((short)id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ReporteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ReporteDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ReporteDataContracts oReporte)
        {
            try
            {
                ReporteAdmin reporteAdmin = new ReporteAdmin();
                reporteAdmin.Delete((Reporte)oReporte);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ReporteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ReporteDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ReporteDataContracts oReporte)
        {
            try
            {
                ReporteAdmin reporteAdmin = new ReporteAdmin();
                reporteAdmin.Update((Reporte)oReporte);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ReporteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ReporteDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ReporteDataContracts oReporte)
        {
            try
            {
                ReporteAdmin reporteAdmin = new ReporteAdmin();
                reporteAdmin.Insert((Reporte)oReporte);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ReporteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ReporteDataContracts
        /// </summary>
        /// <value>void</value>
        public ReporteDataContracts GetReporte(int id)
        {
            try
            {
                ReporteAdmin reporteAdmin = new ReporteAdmin();
                return (ReporteDataContracts)reporteAdmin.Load((short)id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetReporte : ReporteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ReporteDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ReporteDataContracts> GetAllReportes()
        {
            try
            {
                ReporteAdmin reporteAdmin = new ReporteAdmin();
                List<Reporte> resultList = reporteAdmin.GetAllReportes();

                return resultList.ConvertAll<ReporteDataContracts>(
                    delegate(Reporte tempReporte) { return (ReporteDataContracts)tempReporte; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllReportes : ReporteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}