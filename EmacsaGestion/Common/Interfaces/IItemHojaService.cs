using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad ItemHojaDataContracts(EMACSA_NUCLEO.dbo.MTR_Item_Hoja)
	/// </summary>
	public interface IItemHojaService
	{
		/// <summary>
		/// Interface para retornar un objeto ItemHojaDataContracts
		/// </summary>
		/// <value>ItemHojaDataContracts</value>
		ItemHojaDataContracts Load(decimal idHoja,int nroItem);
		
		/// <summary>
		/// interface para eliminar un ItemHojaDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(ItemHojaDataContracts oItemHoja);

        /// <summary>
		/// Interface para actualiza un objeto ItemHojaDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(ItemHojaDataContracts oItemHoja);
		
        /// <summary>
		/// Inteface para Insertar un objeto ItemHojaDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(ItemHojaDataContracts oItemHoja);

        /// <summary>
		/// Interface para  rertornar objeto ItemHojaDataContracts
		/// </summary>
		/// <value>ItemHojaDataContracts</value>
	    ItemHojaDataContracts GetItemHoja(decimal idHoja,int nroItem);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto ItemHojaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<ItemHojaDataContracts>]]></value>
		List<ItemHojaDataContracts> GetAllItemHojas();

        List<ItemHojaDataContracts> GetItemsHojaByIdHoja(int idHoja);

	}
}
