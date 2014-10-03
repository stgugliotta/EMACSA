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
	/// Accion		: Implementacion de la Interface de la Entidad Departamento
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_departamento
	/// Descripcion	: 
	/// </summary>
	public class DepartamentoService: IDepartamentoService
	{
		#region IDepartamentoService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto DepartamentoDataContracts
		/// </summary>
		/// <value>DepartamentoDataContracts</value>
		public DepartamentoDataContracts Load(int id)
		 {
			 try
            {
			    DepartamentoAdmin departamentoAdmin = new DepartamentoAdmin();
                return (DepartamentoDataContracts)departamentoAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DepartamentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un DepartamentoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(DepartamentoDataContracts oDepartamento)
		{
            try
            {
                DepartamentoAdmin departamentoAdmin = new DepartamentoAdmin();
                	departamentoAdmin.Delete((Departamento)oDepartamento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DepartamentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto DepartamentoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(DepartamentoDataContracts oDepartamento)
		{
            try
            {
                DepartamentoAdmin departamentoAdmin = new DepartamentoAdmin();
                	departamentoAdmin.Update((Departamento)oDepartamento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DepartamentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto DepartamentoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(DepartamentoDataContracts oDepartamento)
		{
			try
            {
                DepartamentoAdmin departamentoAdmin = new DepartamentoAdmin();
                	departamentoAdmin.Insert((Departamento) oDepartamento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DepartamentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto DepartamentoDataContracts
		/// </summary>
		/// <value>void</value>
		public DepartamentoDataContracts GetDepartamento(int id)
		 {
			 try
            {
			    DepartamentoAdmin departamentoAdmin = new DepartamentoAdmin();
                return (DepartamentoDataContracts)departamentoAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDepartamento : DepartamentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos DepartamentoDataContracts
		/// </summary>
		/// <value>void</value>
		public List<DepartamentoDataContracts> GetAllDepartamentos()
		 {
			 try
            {
                DepartamentoAdmin departamentoAdmin = new DepartamentoAdmin();
                 List<Departamento> resultList = departamentoAdmin.GetAllDepartamentos();

                return resultList.ConvertAll<DepartamentoDataContracts>(
                    delegate(Departamento tempDepartamento) { return (DepartamentoDataContracts)tempDepartamento; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDepartamentos : DepartamentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos DepartamentoDataContracts por provincia
        /// </summary>
        /// <value>void</value>
        public List<DepartamentoDataContracts> GetAllDepartamentosByProvincia(int idProvincia)
        {
            try
            {
                DepartamentoAdmin departamentoAdmin = new DepartamentoAdmin();
                List<Departamento> resultList = departamentoAdmin.GetAllDepartamentosByProvincia(idProvincia);

                return resultList.ConvertAll<DepartamentoDataContracts>(
                    delegate(Departamento tempDepartamento) { return (DepartamentoDataContracts)tempDepartamento; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDepartamentosByProvincia : DepartamentoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		#endregion
	}
}