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
	/// Creado		: 2010-04-11
	/// Accion		: Implementacion de la Interface de la Entidad Zona
	/// Objeto		: EMACSA_NUCLEO.dbo.MTR_Zona
	/// Descripcion	: 
	/// </summary>
	public class ZonaService: IZonaService
	{
		#region IZonaService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto ZonaDataContracts
		/// </summary>
		/// <value>ZonaDataContracts</value>
		public ZonaDataContracts Load(int id)
		 {
			 try
            {
			    ZonaAdmin zonaAdmin = new ZonaAdmin();
                return (ZonaDataContracts)zonaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ZonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un ZonaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(ZonaDataContracts oZona)
		{
            try
            {
                ZonaAdmin zonaAdmin = new ZonaAdmin();
                	zonaAdmin.Delete((Zona)oZona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ZonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto ZonaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(ZonaDataContracts oZona)
		{
            try
            {
                ZonaAdmin zonaAdmin = new ZonaAdmin();
                	zonaAdmin.Update((Zona)oZona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ZonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto ZonaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(ZonaDataContracts oZona)
		{
			try
            {
                ZonaAdmin zonaAdmin = new ZonaAdmin();
                	zonaAdmin.Insert((Zona) oZona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ZonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto ZonaDataContracts
		/// </summary>
		/// <value>void</value>
		public ZonaDataContracts GetZona(int id)
		 {
			 try
            {
			    ZonaAdmin zonaAdmin = new ZonaAdmin();
                return (ZonaDataContracts)zonaAdmin.Load(id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetZona : ZonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos ZonaDataContracts
		/// </summary>
		/// <value>void</value>
		public List<ZonaDataContracts> GetAllZona()
		 {
			 try
            {
                ZonaAdmin zonaAdmin = new ZonaAdmin();
                 List<Zona> resultList = zonaAdmin.GetAllZona();

                return resultList.ConvertAll<ZonaDataContracts>(
                    delegate(Zona tempZona) { return (ZonaDataContracts)tempZona; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllZona : ZonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ZonaDataContracts de un cobrador dado.
        /// </summary>
        /// <value>void</value>
        public List<ZonaDataContracts> GetZonasByCobrador(int id_cobrador)
        {
            try
            {
                ZonaAdmin zonaAdmin = new ZonaAdmin();
                List<Zona> resultList = zonaAdmin.GetZonasByCobrador(id_cobrador);

                return resultList.ConvertAll<ZonaDataContracts>(
                    delegate(Zona tempZona) { return (ZonaDataContracts)tempZona; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetZonasByCobrador : ZonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void AsociarCobrador(int id_cobrador, int id_zona)
        {
            try
            {
                ZonaAdmin zonaAdmin = new ZonaAdmin();
                zonaAdmin.AsociarCobrador(id_cobrador,id_zona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  AsociarCobrador : ZonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

		#endregion
	}
}