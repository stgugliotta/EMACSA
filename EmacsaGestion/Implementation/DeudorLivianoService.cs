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
    /// Creado		: 2009-12-31
    /// Accion		: Implementacion de la Interface de la Entidad Deudor
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_deudor
    /// Descripcion	: 
    /// </summary>
    public class DeudorLivianoService : IDeudorLivianoService


    {


        public List<DeudorLivianoDataContracts> GetAllDeudorsLivianoPorCriterioAnalista(string cliente)
        {
            try
            {
                DeudorLivianoAdmin deudorLivianoAdmin = new DeudorLivianoAdmin();
                List<DeudorLiviano> resultList = deudorLivianoAdmin.GetAllDeudorsLivianoPorCriterioAnalista(cliente);

                return resultList.ConvertAll<DeudorLivianoDataContracts>(
                    delegate(DeudorLiviano tempDeudor) { return (DeudorLivianoDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsLivianoPorCriterioAnalista : DeudorLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        public List<DeudorLivianoDataContracts> GetAllDeudorsLivianoPorCriterioCliente(int cliente)
        {
            try
            {
                DeudorLivianoAdmin deudorLivianoAdmin = new DeudorLivianoAdmin();
                List<DeudorLiviano> resultList = deudorLivianoAdmin.GetAllDeudorsLivianoPorCriterioCliente(cliente);

                return resultList.ConvertAll<DeudorLivianoDataContracts>(
                    delegate(DeudorLiviano tempDeudor) { return (DeudorLivianoDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioCliente : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #region IDeudorLivianoService Members


        public List<DeudorLivianoDataContracts> GetAllDeudorsLivianoPorAnalista(string analista)
        {
            try
            {
                DeudorLivianoAdmin deudorLivianoAdmin = new DeudorLivianoAdmin();
                List<DeudorLiviano> resultList = deudorLivianoAdmin.GetAllDeudorsLivianoPorAnalista(analista);

                return resultList.ConvertAll<DeudorLivianoDataContracts>(
                    delegate(DeudorLiviano tempDeudor) { return (DeudorLivianoDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsLivianoPorCriterioAnalista : DeudorLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorLivianoDataContracts> GetAllDeudorsLivianoGestionAnalista(string analista, bool todos, bool aVencer, int cantDias, bool incluyeVencidas, bool validarFechaReclamo, int idCliente, bool proximaGestion)
        {
            try
            {
                DeudorLivianoAdmin deudorLivianoAdmin = new DeudorLivianoAdmin();
                List<DeudorLiviano> resultList = deudorLivianoAdmin.GetAllDeudorsLivianoGestionAnalista(analista, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, proximaGestion);

                return resultList.ConvertAll<DeudorLivianoDataContracts>(
                    delegate(DeudorLiviano tempDeudor) { return (DeudorLivianoDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsLivianoPorCriterioAnalista : DeudorLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorLivianoDataContracts> GetAllDeudorsLivianoGestionAnalistaConFiltroFechaReclamo(string analista, bool todos, bool aVencer, int cantDias, bool incluyeVencidas, bool validarFechaReclamo, int idCliente, bool proximaGestion, DateTime fechaFiltroFechaReclamo)
        {
            try
            {
                DeudorLivianoAdmin deudorLivianoAdmin = new DeudorLivianoAdmin();
                List<DeudorLiviano> resultList = deudorLivianoAdmin.GetAllDeudorsLivianoGestionAnalistaConFiltroFechaReclamo(analista, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, proximaGestion, fechaFiltroFechaReclamo);

                return resultList.ConvertAll<DeudorLivianoDataContracts>(
                    delegate(DeudorLiviano tempDeudor) { return (DeudorLivianoDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsLivianoPorCriterioAnalista : DeudorLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion


       
    }
}