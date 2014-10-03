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
    /// Creado		: 2010-04-03
    /// Accion		: Implementacion de la Interface de la Entidad ClienteCuenta
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_cliente_cuenta
    /// Descripcion	: 
    /// </summary>
    public class ClienteCuentaService : IClienteCuentaService
    {
        #region IClienteCuentaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>ClienteCuentaDataContracts</value>
        public ClienteCuentaDataContracts Load(int id)
        {
            try
            {
                ClienteCuentaAdmin clientecuentaAdmin = new ClienteCuentaAdmin();
                return (ClienteCuentaDataContracts)clientecuentaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ClienteCuentaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ClienteCuentaDataContracts oClienteCuenta)
        {
            try
            {
                ClienteCuentaAdmin clientecuentaAdmin = new ClienteCuentaAdmin();
                clientecuentaAdmin.Delete((ClienteCuenta)oClienteCuenta);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ClienteCuentaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ClienteCuentaDataContracts oClienteCuenta)
        {
            try
            {
                ClienteCuentaAdmin clientecuentaAdmin = new ClienteCuentaAdmin();
                clientecuentaAdmin.Update((ClienteCuenta)oClienteCuenta);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ClienteCuentaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ClienteCuentaDataContracts oClienteCuenta)
        {
            try
            {
                ClienteCuentaAdmin clientecuentaAdmin = new ClienteCuentaAdmin();
                clientecuentaAdmin.Insert((ClienteCuenta)oClienteCuenta);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ClienteCuentaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        public ClienteCuentaDataContracts GetClienteCuenta(int id)
        {
            try
            {
                ClienteCuentaAdmin clientecuentaAdmin = new ClienteCuentaAdmin();
                return (ClienteCuentaDataContracts)clientecuentaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetClienteCuenta : ClienteCuentaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ClienteCuentaDataContracts> GetAllClienteCuentas()
        {
            try
            {
                ClienteCuentaAdmin clientecuentaAdmin = new ClienteCuentaAdmin();
                List<ClienteCuenta> resultList = clientecuentaAdmin.GetAllClienteCuentas();

                return resultList.ConvertAll<ClienteCuentaDataContracts>(
                    delegate(ClienteCuenta tempClienteCuenta) { return (ClienteCuentaDataContracts)tempClienteCuenta; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllClienteCuentas : ClienteCuentaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


          /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ClienteCuentaDataContracts> GetAllClienteCuentasByIdCliente(int idCliente)
        {
            try
            {
                ClienteCuentaAdmin clientecuentaAdmin = new ClienteCuentaAdmin();
                List<ClienteCuenta> resultList = clientecuentaAdmin.GetAllClienteCuentasByIdCliente(idCliente);

                return resultList.ConvertAll<ClienteCuentaDataContracts>(
                    delegate(ClienteCuenta tempClienteCuenta) { return (ClienteCuentaDataContracts)tempClienteCuenta; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllClienteCuentas : ClienteCuentaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        #endregion
    }
}