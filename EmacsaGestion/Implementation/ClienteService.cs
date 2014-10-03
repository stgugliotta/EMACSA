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
    /// Creado		: 2009-12-19
    /// Accion		: Implementacion de la Interface de la Entidad Cliente
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_cliente
    /// Descripcion	: 
    /// </summary>
    public class ClienteService : IClienteService
    {
        #region IClienteService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto ClienteDataContracts
        /// </summary>
        /// <value>ClienteDataContracts</value>
        public ClienteDataContracts Load(decimal idCliente)
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
                return (ClienteDataContracts)clienteAdmin.Load(idCliente);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(ClienteDataContracts oCliente)
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
                clienteAdmin.Delete((Cliente)oCliente);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(ClienteDataContracts oCliente)
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
                clienteAdmin.Update((Cliente)oCliente);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(ClienteDataContracts oCliente)
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
                clienteAdmin.Insert((Cliente)oCliente);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        public ClienteDataContracts GetCliente(decimal idCliente)
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
                return (ClienteDataContracts)clienteAdmin.Load(idCliente);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCliente : ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }



        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        public ClienteDataContracts GetClientePorDeudor(decimal idDeudor)
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
              return (ClienteDataContracts)clienteAdmin.GetClienteByIdDeudor(idDeudor);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCliente : ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ClienteDataContracts> GetAllClientes()
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
                List<Cliente> resultList = clienteAdmin.GetAllClientes();

                return resultList.ConvertAll<ClienteDataContracts>(
                    delegate(Cliente tempCliente) { return (ClienteDataContracts)tempCliente; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllClientes : ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ClienteDataContracts con interfaz en Configuration.xml
        /// </summary>
        /// <value>void</value>
        public List<ClienteDataContracts> GetClientesInterfaces()
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
                List<Cliente> resultList = clienteAdmin.GetClientesInterfaces();

                return resultList.ConvertAll<ClienteDataContracts>(
                    delegate(Cliente tempCliente) { return (ClienteDataContracts)tempCliente; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetClientesInterfaces : ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
/// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ClienteDataContracts> GetAllClientesByAnalista(string analista)
        {
            try
            {
                ClienteAdmin clienteAdmin = new ClienteAdmin();
                List<Cliente> resultList = clienteAdmin.GetAllClientesByAnalista(analista);

                return resultList.ConvertAll<ClienteDataContracts>(
                    delegate(Cliente tempCliente) { return (ClienteDataContracts)tempCliente; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllClientesByAnalista : ClienteService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}