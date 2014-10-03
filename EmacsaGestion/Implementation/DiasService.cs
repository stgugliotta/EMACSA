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
    /// Accion		: Implementacion de la Interface de la Entidad Dias
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_dias
    /// Descripcion	: 
    /// </summary>
    public class DiasService : IDiasService
    {
        #region IDiasService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto DiasDataContracts
        /// </summary>
        /// <value>DiasDataContracts</value>
        public DiasDataContracts Load(int idDia)
        {
            try
            {
                DiasAdmin diasAdmin = new DiasAdmin();
                return (DiasDataContracts)diasAdmin.Load(idDia);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DiasService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un DiasDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(DiasDataContracts oDias)
        {
            try
            {
                DiasAdmin diasAdmin = new DiasAdmin();
                diasAdmin.Delete((Dias)oDias);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DiasService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto DiasDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(DiasDataContracts oDias)
        {
            try
            {
                DiasAdmin diasAdmin = new DiasAdmin();
                diasAdmin.Update((Dias)oDias);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DiasService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto DiasDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(DiasDataContracts oDias)
        {
            try
            {
                DiasAdmin diasAdmin = new DiasAdmin();
                diasAdmin.Insert((Dias)oDias);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DiasService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto DiasDataContracts
        /// </summary>
        /// <value>void</value>
        public DiasDataContracts GetDias(int idDia)
        {
            try
            {
                DiasAdmin diasAdmin = new DiasAdmin();
                return (DiasDataContracts)diasAdmin.Load(idDia);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDias : DiasService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos DiasDataContracts
        /// </summary>
        /// <value>void</value>
        public List<DiasDataContracts> GetAllDiass()
        {
            try
            {
                DiasAdmin diasAdmin = new DiasAdmin();
                List<Dias> resultList = diasAdmin.GetAllDiass();

                return resultList.ConvertAll<DiasDataContracts>(
                    delegate(Dias tempDias) { return (DiasDataContracts)tempDias; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDiass : DiasService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}