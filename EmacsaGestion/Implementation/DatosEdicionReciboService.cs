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
    /// Creado		: 2011-03-25
    /// Accion		: Implementacion de la Interface de la Entidad DatosEdicionRecibo
    /// Objeto		: EMACSA_NUCLEO.dbo.datosedicionrecibo
    /// Descripcion	: 
    /// </summary>
    public class DatosEdicionReciboService : IDatosEdicionReciboService
    {
        #region IDatosEdicionReciboService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>DatosEdicionReciboDataContracts</value>
        public DatosEdicionReciboDataContracts Load()
        {
            try
            {
                DatosEdicionReciboAdmin datosedicionreciboAdmin = new DatosEdicionReciboAdmin();
                return (DatosEdicionReciboDataContracts)datosedicionreciboAdmin.Load();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DatosEdicionReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(DatosEdicionReciboDataContracts oDatosEdicionRecibo)
        {
            try
            {
                DatosEdicionReciboAdmin datosedicionreciboAdmin = new DatosEdicionReciboAdmin();
                datosedicionreciboAdmin.Delete((DatosEdicionRecibo)oDatosEdicionRecibo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DatosEdicionReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(DatosEdicionReciboDataContracts oDatosEdicionRecibo)
        {
            try
            {
                DatosEdicionReciboAdmin datosedicionreciboAdmin = new DatosEdicionReciboAdmin();
                datosedicionreciboAdmin.Update((DatosEdicionRecibo)oDatosEdicionRecibo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DatosEdicionReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(DatosEdicionReciboDataContracts oDatosEdicionRecibo)
        {
            try
            {
                DatosEdicionReciboAdmin datosedicionreciboAdmin = new DatosEdicionReciboAdmin();
                datosedicionreciboAdmin.Insert((DatosEdicionRecibo)oDatosEdicionRecibo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DatosEdicionReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public DatosEdicionReciboDataContracts GetDatosEdicionRecibo()
        {
            try
            {
                DatosEdicionReciboAdmin datosedicionreciboAdmin = new DatosEdicionReciboAdmin();
                return (DatosEdicionReciboDataContracts)datosedicionreciboAdmin.Load();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDatosEdicionRecibo : DatosEdicionReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public List<DatosEdicionReciboDataContracts> GetAllDatosEdicionRecibos()
        {
            try
            {
                DatosEdicionReciboAdmin datosedicionreciboAdmin = new DatosEdicionReciboAdmin();
                List<DatosEdicionRecibo> resultList = datosedicionreciboAdmin.GetAllDatosEdicionRecibos();

                return resultList.ConvertAll<DatosEdicionReciboDataContracts>(
                    delegate(DatosEdicionRecibo tempDatosEdicionRecibo) { return (DatosEdicionReciboDataContracts)tempDatosEdicionRecibo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDatosEdicionRecibos : DatosEdicionReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion

        #region IDatosEdicionReciboService Members


        public List<DatosEdicionReciboDataContracts> GetAllDatosEdicionRecibosPorNumeroRemision(int idRemision)
        {
            try
            {
                DatosEdicionReciboAdmin datosedicionreciboAdmin = new DatosEdicionReciboAdmin();
                List<DatosEdicionRecibo> resultList =
                    datosedicionreciboAdmin.GetAllDatosEdicionRecibosPorNumeroRemision(idRemision);

                return resultList.ConvertAll<DatosEdicionReciboDataContracts>(
                    delegate(DatosEdicionRecibo tempDatosEdicionRecibo) { return (DatosEdicionReciboDataContracts)tempDatosEdicionRecibo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDatosEdicionRecibosPorNumeroRemision: DatosEdicionReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DatosEdicionReciboDataContracts> GetAllDatosEdicionRecibosPorNumeroRecibo(string numRecibo)
        {
            try
            {
                DatosEdicionReciboAdmin datosedicionreciboAdmin = new DatosEdicionReciboAdmin();
                List<DatosEdicionRecibo> resultList =
                    datosedicionreciboAdmin.GetAllDatosEdicionRecibosPorNumeroRecibo(numRecibo);

                return resultList.ConvertAll<DatosEdicionReciboDataContracts>(
                    delegate(DatosEdicionRecibo tempDatosEdicionRecibo) { return (DatosEdicionReciboDataContracts)tempDatosEdicionRecibo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDatosEdicionRecibosPorNumeroRecibo: DatosEdicionReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}