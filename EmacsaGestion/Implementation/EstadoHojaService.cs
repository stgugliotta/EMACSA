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
	/// Creado		: 2010-07-01
	/// Accion		: Implementacion de la Interface de la Entidad EstadoHoja
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_estado_hoja
	/// Descripcion	: 
	/// </summary>
	public class EstadoHojaService: IEstadoHojaService
	{
		#region IEstadoHojaService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>EstadoHojaDataContracts</value>
		public EstadoHojaDataContracts Load(short idEstado)
		 {
			try
            {
			    EstadoHojaAdmin estadohojaAdmin = new EstadoHojaAdmin();
                return (EstadoHojaDataContracts)estadohojaAdmin.Load( idEstado);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: EstadoHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un EstadoHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(EstadoHojaDataContracts oEstadoHoja)
		{
            try
            {
                EstadoHojaAdmin estadohojaAdmin = new EstadoHojaAdmin();
                	estadohojaAdmin.Delete((EstadoHoja)oEstadoHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : EstadoHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(EstadoHojaDataContracts oEstadoHoja)
		{
            try
            {
                EstadoHojaAdmin estadohojaAdmin = new EstadoHojaAdmin();
                	estadohojaAdmin.Update((EstadoHoja)oEstadoHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : EstadoHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(EstadoHojaDataContracts oEstadoHoja)
		{
			try
            {
                EstadoHojaAdmin estadohojaAdmin = new EstadoHojaAdmin();
                	estadohojaAdmin.Insert((EstadoHoja) oEstadoHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : EstadoHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public EstadoHojaDataContracts GetEstadoHoja(short idEstado)
		 {
			 try
            {
			    EstadoHojaAdmin estadohojaAdmin = new EstadoHojaAdmin();
                return (EstadoHojaDataContracts)estadohojaAdmin.Load( idEstado);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetEstadoHoja : EstadoHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos EstadoHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public List<EstadoHojaDataContracts> GetAllEstadoHojas()
		 {
			 try
            {
                EstadoHojaAdmin estadohojaAdmin = new EstadoHojaAdmin();
                 List<EstadoHoja> resultList = estadohojaAdmin.GetAllEstadoHojas();

                return resultList.ConvertAll<EstadoHojaDataContracts>(
                    delegate(EstadoHoja tempEstadoHoja) { return (EstadoHojaDataContracts)tempEstadoHoja; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEstadoHojas : EstadoHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}