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
    /// Creado		: 2010-03-12
    /// Accion		: Implementacion de la Interface de la Entidad Cheque
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_cheque
    /// Descripcion	: 
    /// </summary>
    public class ChequeService : IChequeService
    {
        #region IChequeService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ChequeDataContracts
        /// </summary>
        /// <value>ChequeDataContracts</value>
        public ChequeDataContracts Load(int IdCheque)
        {
            try
            {
                ChequeAdmin chequeAdmin = new ChequeAdmin();
                return (ChequeDataContracts)chequeAdmin.Load(IdCheque);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - Load: ChequeService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurrio una Excepcion en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ChequeDataContracts oCheque)
        {
            try
            {
                ChequeAdmin chequeAdmin = new ChequeAdmin();
                chequeAdmin.Delete((Cheque)oCheque);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ChequeService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ChequeDataContracts oCheque)
        {
            try
            {
                ChequeAdmin chequeAdmin = new ChequeAdmin();
                chequeAdmin.Update((Cheque)oCheque);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ChequeService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ChequeDataContracts oCheque)
        {
            try
            {
                ChequeAdmin chequeAdmin = new ChequeAdmin();
                chequeAdmin.Insert((Cheque)oCheque);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ChequeService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        public ChequeDataContracts GetCheque(int idCheque)
        {
            try
            {
                ChequeAdmin chequeAdmin = new ChequeAdmin();
                return (ChequeDataContracts)chequeAdmin.Load(idCheque);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  GetCheque : ChequeService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurrio una Excepcion en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ChequeDataContracts> GetAllCheques()
        {
            try
            {
                ChequeAdmin chequeAdmin = new ChequeAdmin();
                List<Cheque> resultList = chequeAdmin.GetAllCheques();

                return resultList.ConvertAll<ChequeDataContracts>(
                    delegate(Cheque tempCheque) { return (ChequeDataContracts)tempCheque; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllCheques : ChequeService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        public ChequeDataContracts GetChequeByCuit(string cuit)
        {
            try
            {
                ChequeAdmin chequeAdmin = new ChequeAdmin();
                return (ChequeDataContracts)chequeAdmin.GetChequeByCuit(cuit);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCheque : ChequeService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public ChequeDataContracts Load()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}