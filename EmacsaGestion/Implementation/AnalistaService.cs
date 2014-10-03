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
    /// Creado		: 2010-02-23
    /// Accion		: Implementacion de la Interface de la Entidad Analista
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_analista
    /// Descripcion	: 
    /// </summary>
    public class AnalistaService : IAnalistaService
    {
        #region IAnalistaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto AnalistaDataContracts
        /// </summary>
        /// <value>AnalistaDataContracts</value>
        public AnalistaDataContracts Load()
        {
            try
            {
                AnalistaAdmin analistaAdmin = new AnalistaAdmin();
                return (AnalistaDataContracts)analistaAdmin.Load();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: AnalistaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un AnalistaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(AnalistaDataContracts oAnalista)
        {
            try
            {
                AnalistaAdmin analistaAdmin = new AnalistaAdmin();
                analistaAdmin.Delete((Analista)oAnalista);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : AnalistaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto AnalistaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(AnalistaDataContracts oAnalista)
        {
            try
            {
                AnalistaAdmin analistaAdmin = new AnalistaAdmin();
                analistaAdmin.Update((Analista)oAnalista);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : AnalistaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto AnalistaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(AnalistaDataContracts oAnalista)
        {
            try
            {
                AnalistaAdmin analistaAdmin = new AnalistaAdmin();
                analistaAdmin.Insert((Analista)oAnalista);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : AnalistaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto AnalistaDataContracts
        /// </summary>
        /// <value>void</value>
        public AnalistaDataContracts GetAnalista()
        {
            try
            {
                AnalistaAdmin analistaAdmin = new AnalistaAdmin();
                return (AnalistaDataContracts)analistaAdmin.Load();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetAnalista : AnalistaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos AnalistaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<AnalistaDataContracts> GetAllAnalistas()
        {
            try
            {
                AnalistaAdmin analistaAdmin = new AnalistaAdmin();
                List<Analista> resultList = analistaAdmin.GetAllAnalistas();

                return resultList.ConvertAll<AnalistaDataContracts>(
                    delegate(Analista tempAnalista) { return (AnalistaDataContracts)tempAnalista; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAnalistas : AnalistaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}