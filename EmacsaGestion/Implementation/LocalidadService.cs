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
	/// Accion		: Implementacion de la Interface de la Entidad Localidad
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_localidad
	/// Descripcion	: 
	/// </summary>
	public class LocalidadService: ILocalidadService
	{
		#region ILocalidadService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto LocalidadDataContracts
		/// </summary>
		/// <value>LocalidadDataContracts</value>
		public LocalidadDataContracts Load(int id)
		 {
			 try
            {
			    LocalidadAdmin localidadAdmin = new LocalidadAdmin();
                return (LocalidadDataContracts)localidadAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: LocalidadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un LocalidadDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(LocalidadDataContracts oLocalidad)
		{
            try
            {
                LocalidadAdmin localidadAdmin = new LocalidadAdmin();
                	localidadAdmin.Delete((Localidad)oLocalidad);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : LocalidadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto LocalidadDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(LocalidadDataContracts oLocalidad)
		{
            try
            {
                LocalidadAdmin localidadAdmin = new LocalidadAdmin();
                	localidadAdmin.Update((Localidad)oLocalidad);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : LocalidadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto LocalidadDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(LocalidadDataContracts oLocalidad)
		{
			try
            {
                LocalidadAdmin localidadAdmin = new LocalidadAdmin();
                	localidadAdmin.Insert((Localidad) oLocalidad);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : LocalidadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto LocalidadDataContracts
		/// </summary>
		/// <value>void</value>
		public LocalidadDataContracts GetLocalidad(int id)
		 {
			 try
            {
			    LocalidadAdmin localidadAdmin = new LocalidadAdmin();
                return (LocalidadDataContracts)localidadAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetLocalidad : LocalidadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos LocalidadDataContracts
		/// </summary>
		/// <value>void</value>
		public List<LocalidadDataContracts> GetAllLocalidads()
		 {
			 try
            {
                LocalidadAdmin localidadAdmin = new LocalidadAdmin();
                 List<Localidad> resultList = localidadAdmin.GetAllLocalidads();

                return resultList.ConvertAll<LocalidadDataContracts>(
                    delegate(Localidad tempLocalidad) { return (LocalidadDataContracts)tempLocalidad; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllLocalidads : LocalidadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos LocalidadDataContracts
        /// </summary>
        /// <value>void</value>
        public List<LocalidadDataContracts> GetAllLocalidadsByDepartamento(int idDepartamento)
        {
            try
            {
                LocalidadAdmin localidadAdmin = new LocalidadAdmin();
                List<Localidad> resultList = localidadAdmin.GetAllLocalidadsByDepartamento(idDepartamento);

                return resultList.ConvertAll<LocalidadDataContracts>(
                    delegate(Localidad tempLocalidad) { return (LocalidadDataContracts)tempLocalidad; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllLocalidadsByDepartamento : LocalidadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		#endregion
	}
}