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
    /// Creado		: 2011-02-03
    /// Accion		: Implementacion de la Interface de la Entidad CompensacionDePago
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_compensaciondepago
    /// Descripcion	: 
    /// </summary>
    public class CompensacionDePagoService : ICompensacionDePagoService
    {
        #region ICompensacionDePagoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>CompensacionDePagoDataContracts</value>
        public CompensacionDePagoDataContracts Load(int idCompensacion)
        {
            try
            {
                CompensacionDePagoAdmin compensaciondepagoAdmin = new CompensacionDePagoAdmin();
                return (CompensacionDePagoDataContracts)compensaciondepagoAdmin.Load(idCompensacion);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: CompensacionDePagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(CompensacionDePagoDataContracts oCompensacionDePago)
        {
            try
            {
                CompensacionDePagoAdmin compensaciondepagoAdmin = new CompensacionDePagoAdmin();
                compensaciondepagoAdmin.Delete((CompensacionDePago)oCompensacionDePago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : CompensacionDePagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(CompensacionDePagoDataContracts oCompensacionDePago)
        {
            try
            {
                CompensacionDePagoAdmin compensaciondepagoAdmin = new CompensacionDePagoAdmin();
                compensaciondepagoAdmin.Update((CompensacionDePago)oCompensacionDePago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : CompensacionDePagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(CompensacionDePagoDataContracts oCompensacionDePago)
        {
            try
            {
                CompensacionDePagoAdmin compensaciondepagoAdmin = new CompensacionDePagoAdmin();
                compensaciondepagoAdmin.Insert((CompensacionDePago)oCompensacionDePago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : CompensacionDePagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        public CompensacionDePagoDataContracts GetCompensacionDePago(int idCompensacion)
        {
            try
            {
                CompensacionDePagoAdmin compensaciondepagoAdmin = new CompensacionDePagoAdmin();
                return (CompensacionDePagoDataContracts)compensaciondepagoAdmin.Load(idCompensacion);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCompensacionDePago : CompensacionDePagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<CompensacionDePagoDataContracts> GetAllCompensacionDePagos()
        {
            try
            {
                CompensacionDePagoAdmin compensaciondepagoAdmin = new CompensacionDePagoAdmin();
                List<CompensacionDePago> resultList = compensaciondepagoAdmin.GetAllCompensacionDePagos();

                return resultList.ConvertAll<CompensacionDePagoDataContracts>(
                    delegate(CompensacionDePago tempCompensacionDePago) { return (CompensacionDePagoDataContracts)tempCompensacionDePago; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllCompensacionDePagos : CompensacionDePagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        public CompensacionDePagoDataContracts GetCompensacionDePagoPorNumeroDeRecibo(string numRecibo)
        {
            try
            {
                CompensacionDePagoAdmin compensaciondepagoAdmin = new CompensacionDePagoAdmin();
                return (CompensacionDePagoDataContracts)compensaciondepagoAdmin.GetCompensacionDePagoPorNumeroDeRecibo(numRecibo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCompensacionDePagoPorNumeroDeRecibo : CompensacionDePagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}