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
	/// Creado		: 2010-03-23
	/// Accion		: Implementacion de la Interface de la Entidad ClienteDeudor
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_cliente_deudor
	/// Descripcion	: 
	/// </summary>
	public class ClienteDeudorService: IClienteDeudorService
	{
		#region IClienteDeudorService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>ClienteDeudorDataContracts</value>
		public ClienteDeudorDataContracts Load(int idCliente,int idDeudor)
		 {
			 try
            {
			    ClienteDeudorAdmin clientedeudorAdmin = new ClienteDeudorAdmin();
                return (ClienteDeudorDataContracts)clientedeudorAdmin.Load( idCliente, idDeudor);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ClienteDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un ClienteDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(ClienteDeudorDataContracts oClienteDeudor)
		{
            try
            {
                ClienteDeudorAdmin clientedeudorAdmin = new ClienteDeudorAdmin();
                	clientedeudorAdmin.Delete((ClienteDeudor)oClienteDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ClienteDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(ClienteDeudorDataContracts oClienteDeudor)
		{
            try
            {
                ClienteDeudorAdmin clientedeudorAdmin = new ClienteDeudorAdmin();
                	clientedeudorAdmin.Update((ClienteDeudor)oClienteDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ClienteDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(ClienteDeudorDataContracts oClienteDeudor)
		{
			try
            {
                ClienteDeudorAdmin clientedeudorAdmin = new ClienteDeudorAdmin();
                	clientedeudorAdmin.Insert((ClienteDeudor) oClienteDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ClienteDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public ClienteDeudorDataContracts GetClienteDeudor(int idCliente,int idDeudor)
		 {
			 try
            {
			    ClienteDeudorAdmin clientedeudorAdmin = new ClienteDeudorAdmin();
                return (ClienteDeudorDataContracts)clientedeudorAdmin.Load( idCliente, idDeudor);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetClienteDeudor : ClienteDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos ClienteDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public List<ClienteDeudorDataContracts> GetAllClienteDeudors()
		 {
			 try
            {
                ClienteDeudorAdmin clientedeudorAdmin = new ClienteDeudorAdmin();
                 List<ClienteDeudor> resultList = clientedeudorAdmin.GetAllClienteDeudors();

                return resultList.ConvertAll<ClienteDeudorDataContracts>(
                    delegate(ClienteDeudor tempClienteDeudor) { return (ClienteDeudorDataContracts)tempClienteDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllClienteDeudors : ClienteDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ClienteDeudorDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ClienteDeudorDataContracts> GetAllClienteDeudorsByIdDeudor(int idDeudor)
        {
            try
            {
                ClienteDeudorAdmin clientedeudorAdmin = new ClienteDeudorAdmin();
                List<ClienteDeudor> resultList = clientedeudorAdmin.GetAllClienteDeudorsByIdDeudor(idDeudor);

                return resultList.ConvertAll<ClienteDeudorDataContracts>(
                    delegate(ClienteDeudor tempClienteDeudor) { return (ClienteDeudorDataContracts)tempClienteDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllClienteDeudorsByIdDeudor : ClienteDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ClienteDeudorDataContracts
        /// </summary>
        /// <value>void</value>
        public ClienteDeudorDataContracts GetClienteAlfanumDelCliente(int idCliente, string alfanumDelCliente)
        {
            try
            {
                ClienteDeudorAdmin clientedeudorAdmin = new ClienteDeudorAdmin();
                
                return (ClienteDeudorDataContracts) clientedeudorAdmin.GetClienteAlfanumDelCliente(idCliente, alfanumDelCliente);
                
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetClienteAlfanumDelCliente : ClienteDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

		#endregion
	}
}