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
	/// Creado		: 2011-02-19
	/// Accion		: Implementacion de la Interface de la Entidad ItemHojaDSG
	/// Objeto		: EMACSA_NUCLEO.dbo.mtr_item_hoja_dsg
	/// Descripcion	: 
	/// </summary>
	public class ItemHojaDSGService: IItemHojaDSGService
	{
		#region IItemHojaDSGService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>ItemHojaDSGDataContracts</value>
		public ItemHojaDSGDataContracts Load(decimal idHoja,int nroItem)
		 {
			 try
            {
			    ItemHojaDSGAdmin itemhojadsgAdmin = new ItemHojaDSGAdmin();
                return (ItemHojaDSGDataContracts)itemhojadsgAdmin.Load( idHoja, nroItem);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ItemHojaDSGService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un ItemHojaDSGDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(ItemHojaDSGDataContracts oItemHojaDSG)
		{
            try
            {
                ItemHojaDSGAdmin itemhojadsgAdmin = new ItemHojaDSGAdmin();
                	itemhojadsgAdmin.Delete((ItemHojaDSG)oItemHojaDSG);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ItemHojaDSGService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(ItemHojaDSGDataContracts oItemHojaDSG)
		{
            try
            {
                ItemHojaDSGAdmin itemhojadsgAdmin = new ItemHojaDSGAdmin();
                	itemhojadsgAdmin.Update((ItemHojaDSG)oItemHojaDSG);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ItemHojaDSGService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(ItemHojaDSGDataContracts oItemHojaDSG)
		{
			try
            {
                ItemHojaDSGAdmin itemhojadsgAdmin = new ItemHojaDSGAdmin();
                	itemhojadsgAdmin.Insert((ItemHojaDSG) oItemHojaDSG);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ItemHojaDSGService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>void</value>
		public ItemHojaDSGDataContracts GetItemHojaDSG(decimal idHoja,int nroItem)
		 {
			 try
            {
			    ItemHojaDSGAdmin itemhojadsgAdmin = new ItemHojaDSGAdmin();
                return (ItemHojaDSGDataContracts)itemhojadsgAdmin.Load( idHoja, nroItem);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetItemHojaDSG : ItemHojaDSGService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos ItemHojaDSGDataContracts
		/// </summary>
		/// <value>void</value>
		public List<ItemHojaDSGDataContracts> GetAllItemHojaDSGs()
		 {
			 try
            {
                ItemHojaDSGAdmin itemhojadsgAdmin = new ItemHojaDSGAdmin();
                 List<ItemHojaDSG> resultList = itemhojadsgAdmin.GetAllItemHojaDSGs();

                return resultList.ConvertAll<ItemHojaDSGDataContracts>(
                    delegate(ItemHojaDSG tempItemHojaDSG) { return (ItemHojaDSGDataContracts)tempItemHojaDSG; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllItemHojaDSGs : ItemHojaDSGService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ItemHojaDSGDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ItemHojaDSGDataContracts> GetAllItemHojaDSGsByIdHoja(int idHoja)
        {
            try
            {
                ItemHojaDSGAdmin itemhojadsgAdmin = new ItemHojaDSGAdmin();
                List<ItemHojaDSG> resultList = itemhojadsgAdmin.GetAllItemHojaDSGsByIdHoja(idHoja);

                return resultList.ConvertAll<ItemHojaDSGDataContracts>(
                    delegate(ItemHojaDSG tempItemHojaDSG) { return (ItemHojaDSGDataContracts)tempItemHojaDSG; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllItemHojaDSGsByIdHoja : ItemHojaDSGService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

		#endregion
	}
}