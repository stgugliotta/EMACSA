using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad ItemHojaDSGDataContracts(EMACSA_NUCLEO.dbo.MTR_Item_Hoja_DSG)
	/// </summary>
	public interface IItemHojaDSGService
	{
		/// <summary>
		/// Interface para retornar un objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>ItemHojaDSGDataContracts</value>
		ItemHojaDSGDataContracts Load(decimal idHoja,int nroItem);
		
		/// <summary>
		/// interface para eliminar un ItemHojaDSGDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(ItemHojaDSGDataContracts oItemHojaDSG);

        /// <summary>
		/// Interface para actualiza un objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(ItemHojaDSGDataContracts oItemHojaDSG);
		
        /// <summary>
		/// Inteface para Insertar un objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(ItemHojaDSGDataContracts oItemHojaDSG);

        /// <summary>
		/// Interface para  rertornar objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>ItemHojaDSGDataContracts</value>
	    ItemHojaDSGDataContracts GetItemHojaDSG(decimal idHoja,int nroItem);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto ItemHojaDSGDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<ItemHojaDSGDataContracts>]]></value>
		List<ItemHojaDSGDataContracts> GetAllItemHojaDSGs();

        /// <summary>
        /// Interface para  rertornar una lista de objeto ItemHojaDSGDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ItemHojaDSGDataContracts>]]></value>
        List<ItemHojaDSGDataContracts> GetAllItemHojaDSGsByIdHoja(int idHoja);

    }
}
