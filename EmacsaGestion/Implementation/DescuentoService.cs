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
    /// Accion		: Implementacion de la Interface de la Entidad Descuento
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_descuento
    /// Descripcion	: 
    /// </summary>
    public class DescuentoService : IDescuentoService
    {
        #region IDescuentoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto DescuentoDataContracts
        /// </summary>
        /// <value>DescuentoDataContracts</value>
        public DescuentoDataContracts Load(int id)
        {
            try
            {
                DescuentoAdmin descuentoAdmin = new DescuentoAdmin();
                return (DescuentoDataContracts)descuentoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un DescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(DescuentoDataContracts oDescuento)
        {
            try
            {
                DescuentoAdmin descuentoAdmin = new DescuentoAdmin();
                descuentoAdmin.Delete((Descuento)oDescuento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto DescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(DescuentoDataContracts oDescuento)
        {
            try
            {
                DescuentoAdmin descuentoAdmin = new DescuentoAdmin();
                descuentoAdmin.Update((Descuento)oDescuento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto DescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(DescuentoDataContracts oDescuento)
        {
            try
            {
                DescuentoAdmin descuentoAdmin = new DescuentoAdmin();
                descuentoAdmin.Insert((Descuento)oDescuento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto DescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public DescuentoDataContracts GetDescuento(int id)
        {
            try
            {
                DescuentoAdmin descuentoAdmin = new DescuentoAdmin();
                return (DescuentoDataContracts)descuentoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDescuento : DescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos DescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<DescuentoDataContracts> GetAllDescuentos()
        {
            try
            {
                DescuentoAdmin descuentoAdmin = new DescuentoAdmin();
                List<Descuento> resultList = descuentoAdmin.GetAllDescuentos();

                return resultList.ConvertAll<DescuentoDataContracts>(
                    delegate(Descuento tempDescuento) { return (DescuentoDataContracts)tempDescuento; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDescuentos : DescuentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}