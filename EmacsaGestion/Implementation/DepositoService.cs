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
    /// Accion		: Implementacion de la Interface de la Entidad Deposito
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_deposito
    /// Descripcion	: 
    /// </summary>
    public class DepositoService : IDepositoService
    {
        #region IDepositoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto DepositoDataContracts
        /// </summary>
        /// <value>DepositoDataContracts</value>
        public DepositoDataContracts Load(int id)
        {
            try
            {
                DepositoAdmin depositoAdmin = new DepositoAdmin();
                return (DepositoDataContracts)depositoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DepositoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un DepositoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(DepositoDataContracts oDeposito)
        {
            try
            {
                DepositoAdmin depositoAdmin = new DepositoAdmin();
                depositoAdmin.Delete((Deposito)oDeposito);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DepositoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto DepositoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(DepositoDataContracts oDeposito)
        {
            try
            {
                DepositoAdmin depositoAdmin = new DepositoAdmin();
                depositoAdmin.Update((Deposito)oDeposito);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DepositoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto DepositoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(DepositoDataContracts oDeposito)
        {
            try
            {
                DepositoAdmin depositoAdmin = new DepositoAdmin();
                depositoAdmin.Insert((Deposito)oDeposito);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DepositoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto DepositoDataContracts
        /// </summary>
        /// <value>void</value>
        public DepositoDataContracts GetDeposito(int id)
        {
            try
            {
                DepositoAdmin depositoAdmin = new DepositoAdmin();
                return (DepositoDataContracts)depositoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDeposito : DepositoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos DepositoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<DepositoDataContracts> GetAllDepositos()
        {
            try
            {
                DepositoAdmin depositoAdmin = new DepositoAdmin();
                List<Deposito> resultList = depositoAdmin.GetAllDepositos();

                return resultList.ConvertAll<DepositoDataContracts>(
                    delegate(Deposito tempDeposito) { return (DepositoDataContracts)tempDeposito; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDepositos : DepositoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}