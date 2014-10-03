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
	/// Accion		: Implementacion de la Interface de la Entidad Provincia
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_provincia
	/// Descripcion	: 
	/// </summary>
	public class ProvinciaService: IProvinciaService
	{
		#region IProvinciaService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto ProvinciaDataContracts
		/// </summary>
		/// <value>ProvinciaDataContracts</value>
		public ProvinciaDataContracts Load(int id)
		 {
			 try
            {
			    ProvinciaAdmin provinciaAdmin = new ProvinciaAdmin();
                return (ProvinciaDataContracts)provinciaAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ProvinciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un ProvinciaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(ProvinciaDataContracts oProvincia)
		{
            try
            {
                ProvinciaAdmin provinciaAdmin = new ProvinciaAdmin();
                	provinciaAdmin.Delete((Provincia)oProvincia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ProvinciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto ProvinciaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(ProvinciaDataContracts oProvincia)
		{
            try
            {
                ProvinciaAdmin provinciaAdmin = new ProvinciaAdmin();
                	provinciaAdmin.Update((Provincia)oProvincia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ProvinciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto ProvinciaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(ProvinciaDataContracts oProvincia)
		{
			try
            {
                ProvinciaAdmin provinciaAdmin = new ProvinciaAdmin();
                	provinciaAdmin.Insert((Provincia) oProvincia);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ProvinciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto ProvinciaDataContracts
		/// </summary>
		/// <value>void</value>
		public ProvinciaDataContracts GetProvincia(int id)
		 {
			 try
            {
			    ProvinciaAdmin provinciaAdmin = new ProvinciaAdmin();
                return (ProvinciaDataContracts)provinciaAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetProvincia : ProvinciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos ProvinciaDataContracts
		/// </summary>
		/// <value>void</value>
		public List<ProvinciaDataContracts> GetAllProvincias()
		 {
			 try
            {
                ProvinciaAdmin provinciaAdmin = new ProvinciaAdmin();
                 List<Provincia> resultList = provinciaAdmin.GetAllProvincias();

                return resultList.ConvertAll<ProvinciaDataContracts>(
                    delegate(Provincia tempProvincia) { return (ProvinciaDataContracts)tempProvincia; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllProvincias : ProvinciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ProvinciaDataContracts por Pais
        /// </summary>
        /// <value>List<![CDATA[<ProvinciaDataContracts>]]></value>
        public List<ProvinciaDataContracts> GetAllProvinciasByPais(int idPais)
        {
            try
            {
                ProvinciaAdmin provinciaAdmin = new ProvinciaAdmin();
                List<Provincia> resultList = provinciaAdmin.GetAllProvinciasByPais(idPais);

                return resultList.ConvertAll<ProvinciaDataContracts>(
                    delegate(Provincia tempProvincia) { return (ProvinciaDataContracts)tempProvincia; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllProvinciasByPais : ProvinciaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

		#endregion
	}
}