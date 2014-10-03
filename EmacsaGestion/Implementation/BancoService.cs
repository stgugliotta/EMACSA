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
    /// Creado		: 2010-02-26
    /// Banco		: Implementacion de la Interface de la Entidad Banco
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_banco
    /// Descripcion	: 
    /// </summary>
    public class BancoService : IBancoService
    {
        #region IBancoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto BancoDataContracts
        /// </summary>
        /// <value>BancoDataContracts</value>
        public BancoDataContracts Load(int idBanco)
        {
            try
            {
                BancoAdmin bancoAdmin = new BancoAdmin();
                return (BancoDataContracts)bancoAdmin.Load(idBanco);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: BancoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un BancoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(BancoDataContracts oBanco)
        {
            try
            {
                BancoAdmin bancoAdmin = new BancoAdmin();
                bancoAdmin.Delete((Banco)oBanco);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : BancoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto BancoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(BancoDataContracts oBanco)
        {
            try
            {
                BancoAdmin bancoAdmin = new BancoAdmin();
               
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : BancoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto BancoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(BancoDataContracts oBanco)
        {
            try
            {
                BancoAdmin bancoAdmin = new BancoAdmin();
//              77  bancoAdmin.Insert((Banco)oBanco);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : BancoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto BancoDataContracts
        /// </summary>
        /// <value>void</value>
        public BancoDataContracts GetBanco(int idBanco)
        {
            try
            {
                BancoAdmin bancoAdmin = new BancoAdmin();
                return (BancoDataContracts)bancoAdmin.Load(idBanco);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetBanco : BancoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos BancoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<BancoDataContracts> GetAllBancos()
        {
            try
            {
                BancoAdmin bancoAdmin = new BancoAdmin();
                List<Banco> resultList = bancoAdmin.GetAllBancos();

                return resultList.ConvertAll<BancoDataContracts>(
                    delegate(Banco tempBanco) { return (BancoDataContracts)tempBanco; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllBancos : BancoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<BancoDataContracts> GetAllBancosByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc)
        {
            try
            {
                BancoAdmin bancoAdmin = new BancoAdmin();
             //   List<Banco> resultList = bancoAdmin.GetAllBancosByIdFacturaIdClienteFechaVenc(idFactura, idCliente, fechaVenc);
                return null;
                //return resultList.ConvertAll<BancoDataContracts>(
                //    delegate(Banco tempBanco) { return (BancoDataContracts)tempBanco; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllBancos : BancoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }



        public List<BancoDataContracts> GetAllBancosByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado)
        {
            try
            {
                BancoAdmin bancoAdmin = new BancoAdmin();
               // List<Banco> resultList = bancoAdmin.GetAllBancosByIdFacturaIdClienteFechaVencIdEstado(idFactura, idCliente, fechaVenc, idEstado);
                return null;
                //return resultList.ConvertAll<BancoDataContracts>(
                //    delegate(Banco tempBanco) { return (BancoDataContracts)tempBanco; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllBancos : BancoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}