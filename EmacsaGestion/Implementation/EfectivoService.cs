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
    /// Creado		: 2010-04-10
    /// Accion		: Implementacion de la Interface de la Entidad Efectivo
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_efectivo
    /// Descripcion	: 
    /// </summary>
    public class EfectivoService : IEfectivoService
    {
        #region IEfectivoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto EfectivoDataContracts
        /// </summary>
        /// <value>EfectivoDataContracts</value>
        public EfectivoDataContracts Load(int id)
        {
            try
            {
                EfectivoAdmin efectivoAdmin = new EfectivoAdmin();
                return (EfectivoDataContracts)efectivoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: EfectivoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un EfectivoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(EfectivoDataContracts oEfectivo)
        {
            try
            {
                EfectivoAdmin efectivoAdmin = new EfectivoAdmin();
                efectivoAdmin.Delete((Efectivo)oEfectivo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : EfectivoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto EfectivoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(EfectivoDataContracts oEfectivo)
        {
            try
            {
                EfectivoAdmin efectivoAdmin = new EfectivoAdmin();
                efectivoAdmin.Update((Efectivo)oEfectivo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : EfectivoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto EfectivoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(EfectivoDataContracts oEfectivo)
        {
            try
            {
                EfectivoAdmin efectivoAdmin = new EfectivoAdmin();
                efectivoAdmin.Insert((Efectivo)oEfectivo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : EfectivoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto EfectivoDataContracts
        /// </summary>
        /// <value>void</value>
        public EfectivoDataContracts GetEfectivo(int id)
        {
            try
            {
                EfectivoAdmin efectivoAdmin = new EfectivoAdmin();
                return (EfectivoDataContracts)efectivoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetEfectivo : EfectivoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos EfectivoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<EfectivoDataContracts> GetAllEfectivos()
        {
            try
            {
                EfectivoAdmin efectivoAdmin = new EfectivoAdmin();
                List<Efectivo> resultList = efectivoAdmin.GetAllEfectivos();

                return resultList.ConvertAll<EfectivoDataContracts>(
                    delegate(Efectivo tempEfectivo) { return (EfectivoDataContracts)tempEfectivo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEfectivos : EfectivoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}