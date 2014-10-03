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
    /// Accion		: Implementacion de la Interface de la Entidad Transferencia
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_transferencia
    /// Descripcion	: 
    /// </summary>
    public class TransferenciaService : ITransferenciaService
    {
        #region ITransferenciaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto TransferenciaDataContracts
        /// </summary>
        /// <value>TransferenciaDataContracts</value>
        public TransferenciaDataContracts Load(int id)
        {
            try
            {
                TransferenciaAdmin transferenciaAdmin = new TransferenciaAdmin();
                return (TransferenciaDataContracts)transferenciaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: TransferenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un TransferenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(TransferenciaDataContracts oTransferencia)
        {
            try
            {
                TransferenciaAdmin transferenciaAdmin = new TransferenciaAdmin();
                transferenciaAdmin.Delete((Transferencia)oTransferencia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : TransferenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto TransferenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(TransferenciaDataContracts oTransferencia)
        {
            try
            {
                TransferenciaAdmin transferenciaAdmin = new TransferenciaAdmin();
                transferenciaAdmin.Update((Transferencia)oTransferencia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : TransferenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto TransferenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(TransferenciaDataContracts oTransferencia)
        {
            try
            {
                TransferenciaAdmin transferenciaAdmin = new TransferenciaAdmin();
                transferenciaAdmin.Insert((Transferencia)oTransferencia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : TransferenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto TransferenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public TransferenciaDataContracts GetTransferencia(int id)
        {
            try
            {
                TransferenciaAdmin transferenciaAdmin = new TransferenciaAdmin();
                return (TransferenciaDataContracts)transferenciaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetTransferencia : TransferenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos TransferenciaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<TransferenciaDataContracts> GetAllTransferencias()
        {
            try
            {
                TransferenciaAdmin transferenciaAdmin = new TransferenciaAdmin();
                List<Transferencia> resultList = transferenciaAdmin.GetAllTransferencias();

                return resultList.ConvertAll<TransferenciaDataContracts>(
                    delegate(Transferencia tempTransferencia) { return (TransferenciaDataContracts)tempTransferencia; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllTransferencias : TransferenciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}