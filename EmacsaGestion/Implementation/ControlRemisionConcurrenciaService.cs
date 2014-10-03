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
    /// Creado		: 2010-06-12
    /// Accion		: Implementacion de la Interface de la Entidad ControlRemisionConcurrencia
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_control_concurrencia_remision
    /// Descripcion	: 
    /// </summary>
    public class ControlRemisionConcurrenciaService : IControlRemisionConcurrenciaService
    {
        #region IControlRemisionConcurrenciaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>ControlRemisionConcurrenciaDataContracts</value>
        public ControlRemisionConcurrenciaDataContracts Load(int id)
        {
            try
            {
                ControlRemisionConcurrenciaAdmin controlremisionconcurrenciaAdmin = new ControlRemisionConcurrenciaAdmin();
                return (ControlRemisionConcurrenciaDataContracts)controlremisionconcurrenciaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ControlRemisionConcurrenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ControlRemisionConcurrenciaDataContracts oControlRemisionConcurrencia)
        {
            try
            {
                ControlRemisionConcurrenciaAdmin controlremisionconcurrenciaAdmin = new ControlRemisionConcurrenciaAdmin();
                controlremisionconcurrenciaAdmin.Delete((ControlRemisionConcurrencia)oControlRemisionConcurrencia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ControlRemisionConcurrenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ControlRemisionConcurrenciaDataContracts oControlRemisionConcurrencia)
        {
            try
            {
                ControlRemisionConcurrenciaAdmin controlremisionconcurrenciaAdmin = new ControlRemisionConcurrenciaAdmin();
                controlremisionconcurrenciaAdmin.Update((ControlRemisionConcurrencia)oControlRemisionConcurrencia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ControlRemisionConcurrenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ControlRemisionConcurrenciaDataContracts oControlRemisionConcurrencia)
        {
            try
            {
                ControlRemisionConcurrenciaAdmin controlremisionconcurrenciaAdmin = new ControlRemisionConcurrenciaAdmin();
                controlremisionconcurrenciaAdmin.Insert((ControlRemisionConcurrencia)oControlRemisionConcurrencia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ControlRemisionConcurrenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        ///                                      
        public string InsertWithResult (ControlRemisionConcurrenciaDataContracts oControlRemisionConcurrencia)
        {
            try
            {
                ControlRemisionConcurrenciaAdmin controlremisionconcurrenciaAdmin = new ControlRemisionConcurrenciaAdmin();
                return controlremisionconcurrenciaAdmin.InsertWithResult((ControlRemisionConcurrencia)oControlRemisionConcurrencia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ControlRemisionConcurrenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public ControlRemisionConcurrenciaDataContracts GetControlRemisionConcurrencia(int id)
        {
            try
            {
                ControlRemisionConcurrenciaAdmin controlremisionconcurrenciaAdmin = new ControlRemisionConcurrenciaAdmin();
                return (ControlRemisionConcurrenciaDataContracts)controlremisionconcurrenciaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetControlRemisionConcurrencia : ControlRemisionConcurrenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ControlRemisionConcurrenciaDataContracts> GetAllControlRemisionConcurrencias()
        {
            try
            {
                ControlRemisionConcurrenciaAdmin controlremisionconcurrenciaAdmin = new ControlRemisionConcurrenciaAdmin();
                List<ControlRemisionConcurrencia> resultList = controlremisionconcurrenciaAdmin.GetAllControlRemisionConcurrencias();

                return resultList.ConvertAll<ControlRemisionConcurrenciaDataContracts>(
                    delegate(ControlRemisionConcurrencia tempControlRemisionConcurrencia) { return (ControlRemisionConcurrenciaDataContracts)tempControlRemisionConcurrencia; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllControlRemisionConcurrencias : ControlRemisionConcurrenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion



       
    }
}