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
    /// Creado		: 2010-07-17
    /// Accion		: Implementacion de la Interface de la Entidad DeudorDiaReclamo
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_deudor_dia_reclamo
    /// Descripcion	: 
    /// </summary>
    public class DeudorDiaReclamoAlternativoService : IDeudorDiaReclamoAlternativoService
    {
        #region IDeudorDiaReclamoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>DeudorDiaReclamoDataContracts</value>
        public DeudorDiaReclamoAlternativoDataContracts Load(int idDiaReclamo)
        {
            try
            {
                DeudorDiaReclamoAlternativoAdmin deudordiareclamoAlternativoAdmin = new DeudorDiaReclamoAlternativoAdmin();
                return (DeudorDiaReclamoAlternativoDataContracts)deudordiareclamoAlternativoAdmin.Load(idDiaReclamo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DeudorDiaReclamoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(DeudorDiaReclamoAlternativoDataContracts oDeudorDiaReclamo)
        {
            try
            {
                DeudorDiaReclamoAlternativoAdmin deudordiareclamoAlternativoAdmin = new DeudorDiaReclamoAlternativoAdmin();
                deudordiareclamoAlternativoAdmin.Delete((DeudorDiaReclamoAlternativo)oDeudorDiaReclamo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DeudorDiaReclamoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(DeudorDiaReclamoAlternativoDataContracts oDeudorDiaReclamoAlternativo)
        {
            try
            {
                DeudorDiaReclamoAlternativoAdmin deudordiareclamoAlternativoAdmin = new DeudorDiaReclamoAlternativoAdmin();
                deudordiareclamoAlternativoAdmin.Update((DeudorDiaReclamoAlternativo)oDeudorDiaReclamoAlternativo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DeudorDiaReclamoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(DeudorDiaReclamoAlternativoDataContracts oDeudorDiaReclamo)
        {
            try
            {
                DeudorDiaReclamoAlternativoAdmin deudordiareclamoAlternativoAdmin = new DeudorDiaReclamoAlternativoAdmin();
                deudordiareclamoAlternativoAdmin.Insert((DeudorDiaReclamoAlternativo)oDeudorDiaReclamo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DeudorDiaReclamoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        public void InsertHorarioAlterntivoDeCobro(DeudorDiaReclamoAlternativoDataContracts oDeudorDiaReclamo)
        {
            try
            {
                DeudorDiaReclamoAlternativoAdmin deudordiareclamoAlternativoAdmin = new DeudorDiaReclamoAlternativoAdmin();
                deudordiareclamoAlternativoAdmin.InsertHorarioAlterntivoDeCobro((DeudorDiaReclamoAlternativo)oDeudorDiaReclamo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DeudorDiaReclamoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        public DeudorDiaReclamoAlternativoDataContracts GetDeudorDiaReclamoAlternativo(int idDiaReclamo)
        {
            try
            {
                DeudorDiaReclamoAlternativoAdmin deudordiareclamoAdmin = new DeudorDiaReclamoAlternativoAdmin();
                return (DeudorDiaReclamoAlternativoDataContracts)deudordiareclamoAdmin.Load(idDiaReclamo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDeudorDiaReclamo : DeudorDiaReclamoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<DeudorDiaReclamoAlternativoDataContracts> GetAllDeudorDiaReclamoAlternativo(int id_deudor)
        {
            try
            {
                DeudorDiaReclamoAlternativoAdmin deudordiareclamoAdmin = new DeudorDiaReclamoAlternativoAdmin();
                List<DeudorDiaReclamoAlternativo> resultList = deudordiareclamoAdmin.GetAllDeudorDiaReclamo(id_deudor);

                return resultList.ConvertAll<DeudorDiaReclamoAlternativoDataContracts>(
                    delegate(DeudorDiaReclamoAlternativo tempDeudorDiaReclamo) { return (DeudorDiaReclamoAlternativoDataContracts)tempDeudorDiaReclamo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorDiaReclamos : DeudorDiaReclamoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}