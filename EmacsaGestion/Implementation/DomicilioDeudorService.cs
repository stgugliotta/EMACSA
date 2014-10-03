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
	/// Accion		: Implementacion de la Interface de la Entidad DomicilioDeudor
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_domicilio_deudor
	/// Descripcion	: 
	/// </summary>
	public class DomicilioDeudorService: IDomicilioDeudorService
	{
		#region IDomicilioDeudorService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>DomicilioDeudorDataContracts</value>
		public DomicilioDeudorDataContracts Load(int idDeudor)
		 {
			 try
            {
			    DomicilioDeudorAdmin domiciliodeudorAdmin = new DomicilioDeudorAdmin();
                return (DomicilioDeudorDataContracts)domiciliodeudorAdmin.Load( idDeudor);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(DomicilioDeudorDataContracts oDomicilioDeudor)
		{
            try
            {
                DomicilioDeudorAdmin domiciliodeudorAdmin = new DomicilioDeudorAdmin();
                	domiciliodeudorAdmin.Delete((DomicilioDeudor)oDomicilioDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(DomicilioDeudorDataContracts oDomicilioDeudor)
		{
            try
            {
                DomicilioDeudorAdmin domiciliodeudorAdmin = new DomicilioDeudorAdmin();
                	domiciliodeudorAdmin.Update((DomicilioDeudor)oDomicilioDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(DomicilioDeudorDataContracts oDomicilioDeudor)
		{
			try
            {
                DomicilioDeudorAdmin domiciliodeudorAdmin = new DomicilioDeudorAdmin();
                	domiciliodeudorAdmin.Insert((DomicilioDeudor) oDomicilioDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        public void InsertNuevo(DomicilioDeudorDataContracts oDomicilioDeudor)
        {
            try
            {
                DomicilioDeudorAdmin domiciliodeudorAdmin = new DomicilioDeudorAdmin();
                domiciliodeudorAdmin.InsertNuevo((DomicilioDeudor)oDomicilioDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public DomicilioDeudorDataContracts GetDomicilioDeudor(int idDeudor)
		 {
			 try
            {
			    DomicilioDeudorAdmin domiciliodeudorAdmin = new DomicilioDeudorAdmin();
                return (DomicilioDeudorDataContracts)domiciliodeudorAdmin.Load( idDeudor);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDomicilioDeudor : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}


        public DomicilioDeudorDataContracts GetDomicilioDeudorByIdDeudorIdHoja(int idDeudor, int idHoja)
        {
            try
            {
                DomicilioDeudorAdmin domiciliodeudorAdmin = new DomicilioDeudorAdmin();
                return (DomicilioDeudorDataContracts)domiciliodeudorAdmin.GetDomicilioDeudorByIdDeudorIdHoja(idDeudor, idHoja);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDomicilioDeudorByIdDeudorIdHoja : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        
        /// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		public List<DomicilioDeudorDataContracts> GetAllDomicilioDeudors()
		 {
			 try
            {
                DomicilioDeudorAdmin domiciliodeudorAdmin = new DomicilioDeudorAdmin();
                 List<DomicilioDeudor> resultList = domiciliodeudorAdmin.GetAllDomicilioDeudors();

                return resultList.ConvertAll<DomicilioDeudorDataContracts>(
                    delegate(DomicilioDeudor tempDomicilioDeudor) { return (DomicilioDeudorDataContracts)tempDomicilioDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDomicilioDeudors : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		#endregion
	}
}