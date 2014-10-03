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
    /// Creado		: 2010-04-06
    /// Accion		: Implementacion de la Interface de la Entidad RemisionDescuento
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_remision_descuento
    /// Descripcion	: 
    /// </summary>
    public class RemisionDescuentoService : IRemisionDescuentoService
    {
        #region IRemisionDescuentoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>RemisionDescuentoDataContracts</value>
        public RemisionDescuentoDataContracts Load(int id)
        {
            try
            {
                RemisionDescuentoAdmin remisiondescuentoAdmin = new RemisionDescuentoAdmin();
                return (RemisionDescuentoDataContracts)remisiondescuentoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: RemisionDescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un RemisionDescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(RemisionDescuentoDataContracts oRemisionDescuento)
        {
            try
            {
                RemisionDescuentoAdmin remisiondescuentoAdmin = new RemisionDescuentoAdmin();
                remisiondescuentoAdmin.Delete((RemisionDescuento)oRemisionDescuento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : RemisionDescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(RemisionDescuentoDataContracts oRemisionDescuento)
        {
            try
            {
                RemisionDescuentoAdmin remisiondescuentoAdmin = new RemisionDescuentoAdmin();
                remisiondescuentoAdmin.Update((RemisionDescuento)oRemisionDescuento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : RemisionDescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(RemisionDescuentoDataContracts oRemisionDescuento)
        {
            try
            {
                RemisionDescuentoAdmin remisiondescuentoAdmin = new RemisionDescuentoAdmin();
                remisiondescuentoAdmin.Insert((RemisionDescuento)oRemisionDescuento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : RemisionDescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public RemisionDescuentoDataContracts GetRemisionDescuento(int id)
        {
            try
            {
                RemisionDescuentoAdmin remisiondescuentoAdmin = new RemisionDescuentoAdmin();
                return (RemisionDescuentoDataContracts)remisiondescuentoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetRemisionDescuento : RemisionDescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos RemisionDescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<RemisionDescuentoDataContracts> GetAllRemisionDescuentos()
        {
            try
            {
                RemisionDescuentoAdmin remisiondescuentoAdmin = new RemisionDescuentoAdmin();
                List<RemisionDescuento> resultList = remisiondescuentoAdmin.GetAllRemisionDescuentos();

                return resultList.ConvertAll<RemisionDescuentoDataContracts>(
                    delegate(RemisionDescuento tempRemisionDescuento) { return (RemisionDescuentoDataContracts)tempRemisionDescuento; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllRemisionDescuentos : RemisionDescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}