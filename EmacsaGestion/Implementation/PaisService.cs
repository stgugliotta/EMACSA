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
	/// Accion		: Implementacion de la Interface de la Entidad Pais
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_pais
	/// Descripcion	: 
	/// </summary>
	public class PaisService: IPaisService
	{
		#region IPaisService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto PaisDataContracts
		/// </summary>
		/// <value>PaisDataContracts</value>
		public PaisDataContracts Load(int id)
		 {
			 try
            {
			    PaisAdmin paisAdmin = new PaisAdmin();
                return (PaisDataContracts)paisAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: PaisService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un PaisDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(PaisDataContracts oPais)
		{
            try
            {
                PaisAdmin paisAdmin = new PaisAdmin();
                	paisAdmin.Delete((Pais)oPais);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : PaisService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto PaisDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(PaisDataContracts oPais)
		{
            try
            {
                PaisAdmin paisAdmin = new PaisAdmin();
                	paisAdmin.Update((Pais)oPais);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : PaisService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto PaisDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(PaisDataContracts oPais)
		{
			try
            {
                PaisAdmin paisAdmin = new PaisAdmin();
                	paisAdmin.Insert((Pais) oPais);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : PaisService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto PaisDataContracts
		/// </summary>
		/// <value>void</value>
		public PaisDataContracts GetPais(int id)
		 {
			 try
            {
			    PaisAdmin paisAdmin = new PaisAdmin();
                return (PaisDataContracts)paisAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetPais : PaisService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos PaisDataContracts
		/// </summary>
		/// <value>void</value>
		public List<PaisDataContracts> GetAllPaiss()
		 {
			 try
            {
                PaisAdmin paisAdmin = new PaisAdmin();
                 List<Pais> resultList = paisAdmin.GetAllPaiss();

                return resultList.ConvertAll<PaisDataContracts>(
                    delegate(Pais tempPais) { return (PaisDataContracts)tempPais; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllPaiss : PaisService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}