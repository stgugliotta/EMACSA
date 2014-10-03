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
	public class DomicilioDeudorAlternativoService: IDomicilioDeudorAlternativoService
	{
		#region IDomicilioDeudorService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>DomicilioDeudorDataContracts</value>
        public DomicilioDeudorAlternativoDataContracts Load(int idDeudor)
		 {
			 try
            {
                DomicilioDeudorAlternativoAdmin domiciliodeudorAlternativoAdmin = new DomicilioDeudorAlternativoAdmin();
                return (DomicilioDeudorAlternativoDataContracts)domiciliodeudorAlternativoAdmin.Load(idDeudor);
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
        public void Delete(DomicilioDeudorAlternativoDataContracts oDomicilioDeudor)
		{
            try
            {
                DomicilioDeudorAlternativoAdmin domiciliodeudorAlternativoAdmin = new DomicilioDeudorAlternativoAdmin();
                domiciliodeudorAlternativoAdmin.Delete((DomicilioDeudorAlternativo)oDomicilioDeudor);

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
        public void Update(DomicilioDeudorAlternativoDataContracts oDomicilioDeudor)
		{
            try
            {
                DomicilioDeudorAlternativoAdmin domiciliodeudorAlternativoAdmin = new DomicilioDeudorAlternativoAdmin();
                domiciliodeudorAlternativoAdmin.Update((DomicilioDeudorAlternativo)oDomicilioDeudor);

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
        public void Insert(DomicilioDeudorAlternativoDataContracts oDomicilioDeudor)
		{
			try
            {
                DomicilioDeudorAlternativoAdmin domiciliodeudorAlternativoAdmin = new DomicilioDeudorAlternativoAdmin();
                domiciliodeudorAlternativoAdmin.Insert((DomicilioDeudorAlternativo)oDomicilioDeudor);

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
        public DomicilioDeudorAlternativoDataContracts GetDomicilioDeudor(int idDeudor)
		 {
			 try
            {
                DomicilioDeudorAlternativoAdmin domiciliodeudorAlternativoAdmin = new DomicilioDeudorAlternativoAdmin();
                return (DomicilioDeudorAlternativoDataContracts)domiciliodeudorAlternativoAdmin.Load(idDeudor);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDomicilioDeudor : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
        public List<DomicilioDeudorAlternativoDataContracts> GetAllDomicilioDeudors()
		 {
			 try
            {
                DomicilioDeudorAlternativoAdmin domiciliodeudorAlternativoAdmin = new DomicilioDeudorAlternativoAdmin();
                 List<DomicilioDeudorAlternativo> resultList = domiciliodeudorAlternativoAdmin.GetAllDomicilioDeudorsAlternativo();

                 return resultList.ConvertAll<DomicilioDeudorAlternativoDataContracts>(
                    delegate(DomicilioDeudorAlternativo tempDomicilioDeudor) { return (DomicilioDeudorAlternativoDataContracts)tempDomicilioDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDomicilioDeudors : DomicilioDeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        
        public List<DomicilioDeudorAlternativoDataContracts> GetAllDomicilioDeudorsPorIdDeudor(int idDeudor)
        {
            try
            {
                DomicilioDeudorAlternativoAdmin domiciliodeudorAlternativoAdmin = new DomicilioDeudorAlternativoAdmin();
                List<DomicilioDeudorAlternativo> resultList = domiciliodeudorAlternativoAdmin.GetAllDomicilioDeudorsAlternativoPorIdDeudor(idDeudor);

                return resultList.ConvertAll<DomicilioDeudorAlternativoDataContracts>(
                   delegate(DomicilioDeudorAlternativo tempDomicilioDeudor) { return (DomicilioDeudorAlternativoDataContracts)tempDomicilioDeudor; });
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