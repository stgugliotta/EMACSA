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
    /// Creado		: 2010-03-14
    /// Accion		: Implementacion de la Interface de la Entidad Pago
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_pago
    /// Descripcion	: 
    /// </summary>
    public class PagoService : IPagoService
    {
        #region IPagoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto PagoDataContracts
        /// </summary>
        /// <value>PagoDataContracts</value>
        public PagoDataContracts Load(int idPago)
        {
            try
            {
                PagoAdmin pagoAdmin = new PagoAdmin();
                return (PagoDataContracts)pagoAdmin.Load(idPago);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: PagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un PagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(PagoDataContracts oPago)
        {
            try
            {
                PagoAdmin pagoAdmin = new PagoAdmin();
                pagoAdmin.Delete((Pago)oPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : PagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto PagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(PagoDataContracts oPago)
        {
            try
            {
                PagoAdmin pagoAdmin = new PagoAdmin();
                pagoAdmin.Update((Pago)oPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : PagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto PagoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(PagoDataContracts oPago)
        {
            try
            {
                PagoAdmin pagoAdmin = new PagoAdmin();
                pagoAdmin.Insert((Pago)oPago);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : PagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto PagoDataContracts
        /// </summary>
        /// <value>void</value>
        public PagoDataContracts GetPago(int idPago)
        {
            try
            {
                PagoAdmin pagoAdmin = new PagoAdmin();
                return (PagoDataContracts)pagoAdmin.Load(idPago);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetPago : PagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos PagoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<PagoDataContracts> GetAllPagos()
        {
            try
            {
                PagoAdmin pagoAdmin = new PagoAdmin();
                List<Pago> resultList = pagoAdmin.GetAllPagos();

                return resultList.ConvertAll<PagoDataContracts>(
                    delegate(Pago tempPago) { return (PagoDataContracts)tempPago; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllPagos : PagoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
 
        #endregion

        #region IPagoService Members

        PagoDataContracts IPagoService.Load(int idPago)
        {
            throw new NotImplementedException();
        }

        void IPagoService.Delete(PagoDataContracts oPago)
        {
            throw new NotImplementedException();
        }

        void IPagoService.Update(PagoDataContracts oPago)
        {
            throw new NotImplementedException();
        }

        void IPagoService.Insert(PagoDataContracts oPago)
        {
            throw new NotImplementedException();
        }

        PagoDataContracts IPagoService.GetPago(int idPago)
        {
            throw new NotImplementedException();
        }

        List<PagoDataContracts> IPagoService.GetAllPagos()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}