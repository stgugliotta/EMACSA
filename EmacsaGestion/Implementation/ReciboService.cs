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
    /// Creado		: 2010-04-17
    /// Accion		: Implementacion de la Interface de la Entidad Recibo
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_recibo
    /// Descripcion	: 
    /// </summary>
    public class ReciboService : IReciboService
    {
        #region IReciboService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ReciboDataContracts
        /// </summary>
        /// <value>ReciboDataContracts</value>
        public ReciboDataContracts Load(int idRecibo)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                return (ReciboDataContracts)reciboAdmin.Load(idRecibo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ReciboDataContracts oRecibo)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                reciboAdmin.Delete((Recibo)oRecibo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void Delete(ReciboDataContracts oRecibo, int idCliente)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                reciboAdmin.Delete((Recibo)oRecibo,idCliente);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ReciboDataContracts oRecibo)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                reciboAdmin.Update((Recibo)oRecibo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ReciboDataContracts oRecibo)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                reciboAdmin.Insert((Recibo)oRecibo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public ReciboDataContracts GetRecibo(int idRecibo)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                return (ReciboDataContracts)reciboAdmin.Load(idRecibo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetRecibo : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ReciboDataContracts> GetAllRecibos()
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                List<Recibo> resultList = reciboAdmin.GetAllRecibos();

                return resultList.ConvertAll<ReciboDataContracts>(
                    delegate(Recibo tempRecibo) { return (ReciboDataContracts)tempRecibo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllRecibos : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ReciboDataContracts> GetAllRecibosByIdRemision(int idRemision)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                List<Recibo> resultList = reciboAdmin.GetAllRecibosByIdRemision(idRemision);

                return resultList.ConvertAll<ReciboDataContracts>(
                    delegate(Recibo tempRecibo) { return (ReciboDataContracts)tempRecibo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllRecibos : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ReciboDataContracts> GetAllRecibosByIdCliente(int idCliente)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                List<Recibo> resultList = reciboAdmin.GetAllRecibosByIdCliente(idCliente);

                return resultList.ConvertAll<ReciboDataContracts>(
                    delegate(Recibo tempRecibo) { return (ReciboDataContracts)tempRecibo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllRecibos : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<ReciboDataContracts> GetAllRecibosByIdClienteSinUsar(int idCliente)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                List<Recibo> resultList = reciboAdmin.GetAllRecibosByIdClienteSinUsar(idCliente);

                return resultList.ConvertAll<ReciboDataContracts>(
                    delegate(Recibo tempRecibo) { return (ReciboDataContracts)tempRecibo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllRecibos : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion


        #region IReciboService Members


        public ReciboDataContracts Load(ReciboDataContracts oRecibo)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                return (ReciboDataContracts)reciboAdmin.Load((Recibo)oRecibo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public ReciboDataContracts Load(ReciboDataContracts oRecibo,int idCliente)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                return (ReciboDataContracts)reciboAdmin.Load((Recibo)oRecibo,idCliente);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public ReciboDataContracts GetReciboByNumReciboIdDeudorIdCliente(string pszNumRecibo, int IdDeudor, int IdCliente)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                return (ReciboDataContracts)reciboAdmin.GetReciboByNumReciboIdDeudorIdCliente(pszNumRecibo, IdDeudor, IdCliente);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public ReciboDataContracts GetReciboByNumReciboIdCliente(string pszNumRecibo, int IdCliente)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                return (ReciboDataContracts)reciboAdmin.GetReciboByNumReciboIdCliente(pszNumRecibo, IdCliente);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void InsertRelacion(int idRecibo, int idRemision)
        {
            try
            {
                ReciboAdmin reciboAdmin = new ReciboAdmin();
                reciboAdmin.InsertRelacion(idRecibo, idRemision);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ReciboService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}