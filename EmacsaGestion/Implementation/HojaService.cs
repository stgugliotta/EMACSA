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
	/// Accion		: Implementacion de la Interface de la Entidad Hoja
	/// Objeto		: EMACSA_NUCLEO.dbo.mtr_hoja
	/// Descripcion	: 
	/// </summary>
	public class HojaService: IHojaService
	{
		#region IHojaService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto HojaDataContracts
		/// </summary>
		/// <value>HojaDataContracts</value>
		public HojaDataContracts Load(decimal idHoja)
		 {
			 try
            {
			    HojaAdmin hojaAdmin = new HojaAdmin();
                return (HojaDataContracts)hojaAdmin.Load( idHoja);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: HojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un HojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(HojaDataContracts oHoja)
		{
            try
            {
                HojaAdmin hojaAdmin = new HojaAdmin();
                	hojaAdmin.Delete((Hoja)oHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : HojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto HojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(HojaDataContracts oHoja)
		{
            try
            {
                HojaAdmin hojaAdmin = new HojaAdmin();
                	hojaAdmin.Update((Hoja)oHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : HojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto HojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(HojaDataContracts oHoja)
		{
			try
            {
                HojaAdmin hojaAdmin = new HojaAdmin();
                	hojaAdmin.Insert((Hoja) oHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : HojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto HojaDataContracts
		/// </summary>
		/// <value>void</value>
		public HojaDataContracts GetHoja(decimal idHoja)
		 {
			 try
            {
			    HojaAdmin hojaAdmin = new HojaAdmin();
                return (HojaDataContracts)hojaAdmin.Load( idHoja);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetHoja : HojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos HojaDataContracts
		/// </summary>
		/// <value>void</value>
		public List<HojaDataContracts> GetAllHojas()
		 {
			 try
            {
                HojaAdmin hojaAdmin = new HojaAdmin();
                 List<Hoja> resultList = hojaAdmin.GetAllHojas();

                return resultList.ConvertAll<HojaDataContracts>(
                    delegate(Hoja tempHoja) { return (HojaDataContracts)tempHoja; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllHojas : HojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
      
        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos HojaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<HojaDataContracts> GetAllHojasEntreFechas(DateTime fechaCreacionDesde, DateTime fechaCreacionHasta)
        {
            try
            {
                HojaAdmin hojaAdmin = new HojaAdmin();
                List<Hoja> resultList = hojaAdmin.GetAllHojasEntreFechas(fechaCreacionDesde, fechaCreacionHasta);

                return resultList.ConvertAll<HojaDataContracts>(
                    delegate(Hoja tempHoja) { return (HojaDataContracts)tempHoja; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllHojas : HojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		#endregion
	}
}