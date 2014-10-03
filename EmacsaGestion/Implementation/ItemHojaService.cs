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
	/// Accion		: Implementacion de la Interface de la Entidad ItemHoja
	/// Objeto		: EMACSA_NUCLEO.dbo.mtr_item_hoja
	/// Descripcion	: 
	/// </summary>
	public class ItemHojaService: IItemHojaService
	{
		#region IItemHojaService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto ItemHojaDataContracts
		/// </summary>
		/// <value>ItemHojaDataContracts</value>
		public ItemHojaDataContracts Load(decimal idHoja,int nroItem)
		 {
			 try
            {
			    ItemHojaAdmin itemhojaAdmin = new ItemHojaAdmin();
                return (ItemHojaDataContracts)itemhojaAdmin.Load( idHoja, nroItem);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ItemHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un ItemHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(ItemHojaDataContracts oItemHoja)
		{
            try
            {
                ItemHojaAdmin itemhojaAdmin = new ItemHojaAdmin();
                	itemhojaAdmin.Delete((ItemHoja)oItemHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ItemHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto ItemHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(ItemHojaDataContracts oItemHoja)
		{
            try
            {
                ItemHojaAdmin itemhojaAdmin = new ItemHojaAdmin();
                	itemhojaAdmin.Update((ItemHoja)oItemHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ItemHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto ItemHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(ItemHojaDataContracts oItemHoja)
		{
			try
            {
                ItemHojaAdmin itemhojaAdmin = new ItemHojaAdmin();
                	itemhojaAdmin.Insert((ItemHoja) oItemHoja);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ItemHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto ItemHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public ItemHojaDataContracts GetItemHoja(decimal idHoja,int nroItem)
		 {
			 try
            {
			    ItemHojaAdmin itemhojaAdmin = new ItemHojaAdmin();
                return (ItemHojaDataContracts)itemhojaAdmin.Load( idHoja, nroItem);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetItemHoja : ItemHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos ItemHojaDataContracts
		/// </summary>
		/// <value>void</value>
		public List<ItemHojaDataContracts> GetAllItemHojas()
		 {
			 try
            {
                ItemHojaAdmin itemhojaAdmin = new ItemHojaAdmin();
                 List<ItemHoja> resultList = itemhojaAdmin.GetAllItemHojas();

                return resultList.ConvertAll<ItemHojaDataContracts>(
                    delegate(ItemHoja tempItemHoja) { return (ItemHojaDataContracts)tempItemHoja; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllItemHojas : ItemHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ItemHojaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ItemHojaDataContracts> GetItemsHojaByIdHoja(int idHoja)
        {
            try
            {
                ItemHojaAdmin itemhojaAdmin = new ItemHojaAdmin();
                List<ItemHoja> resultList = itemhojaAdmin.GetItemsHojaByIdHoja(idHoja);

                return resultList.ConvertAll<ItemHojaDataContracts>(
                    delegate(ItemHoja tempItemHoja) { return (ItemHojaDataContracts)tempItemHoja; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetItemsHojaByIdHoja : ItemHojaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

		#endregion
	}
}