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
	/// Accion		: Implementacion de la Interface de la Entidad Cobrador
	/// Objeto		: EMACSA_NUCLEO.dbo.MTR_Cobrador
	/// Descripcion	: 
	/// </summary>
	public class CobradorService: ICobradorService
	{
		#region ICobradorService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto CobradorDataContracts
		/// </summary>
		/// <value>CobradorDataContracts</value>
		public CobradorDataContracts Load(int id)
		 {
			 try
            {
			    CobradorAdmin cobradorAdmin = new CobradorAdmin();
                return (CobradorDataContracts)cobradorAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: CobradorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un CobradorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(CobradorDataContracts oCobrador)
		{
            try
            {
                CobradorAdmin cobradorAdmin = new CobradorAdmin();
                	cobradorAdmin.Delete((Cobrador)oCobrador);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : CobradorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto CobradorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(CobradorDataContracts oCobrador)
		{
            try
            {
                CobradorAdmin cobradorAdmin = new CobradorAdmin();
                	cobradorAdmin.Update((Cobrador)oCobrador);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : CobradorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto CobradorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(CobradorDataContracts oCobrador)
		{
			try
            {
                CobradorAdmin cobradorAdmin = new CobradorAdmin();
                	cobradorAdmin.Insert((Cobrador) oCobrador);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : CobradorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto CobradorDataContracts
		/// </summary>
		/// <value>void</value>
		public CobradorDataContracts GetCobrador(int id)
		 {
			 try
            {
			    CobradorAdmin cobradorAdmin = new CobradorAdmin();
                return (CobradorDataContracts)cobradorAdmin.Load(id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCobrador : CobradorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos CobradorDataContracts
		/// </summary>
		/// <value>void</value>
		public List<CobradorDataContracts> GetAllCobrador()
		 {
			 try
            {
                CobradorAdmin cobradorAdmin = new CobradorAdmin();
                 List<Cobrador> resultList = cobradorAdmin.GetAllCobrador();

                return resultList.ConvertAll<CobradorDataContracts>(
                    delegate(Cobrador tempCobrador) { return (CobradorDataContracts)tempCobrador; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllCobrador : CobradorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        public List<CobradorDataContracts> GetAllCobradorPorZonaAsignada(int idZona)
        {
            try
            {
                CobradorAdmin cobradorAdmin = new CobradorAdmin();
                List<Cobrador> resultList = cobradorAdmin.GetAllCobradorPorZonaAsignada(idZona);

                return resultList.ConvertAll<CobradorDataContracts>(
                    delegate(Cobrador tempCobrador) { return (CobradorDataContracts)tempCobrador; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllCobrador : CobradorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

		#endregion
	}
}