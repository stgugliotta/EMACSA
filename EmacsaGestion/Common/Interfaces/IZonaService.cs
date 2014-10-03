using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad ZonaDataContracts(EMACSA_NUCLEO.dbo.MTR_Zona)
	/// </summary>
	public interface IZonaService
	{
		/// <summary>
		/// Interface para retornar un objeto ZonaDataContracts
		/// </summary>
		/// <value>ZonaDataContracts</value>
		ZonaDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un ZonaDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(ZonaDataContracts oZona);

        /// <summary>
		/// Interface para actualiza un objeto ZonaDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(ZonaDataContracts oZona);
		
        /// <summary>
		/// Inteface para Insertar un objeto ZonaDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(ZonaDataContracts oZona);

        /// <summary>
		/// Interface para  rertornar objeto ZonaDataContracts
		/// </summary>
		/// <value>ZonaDataContracts</value>
	    ZonaDataContracts GetZona(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto ZonaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<ZonaDataContracts>]]></value>
		List<ZonaDataContracts> GetAllZona();

        List<ZonaDataContracts> GetZonasByCobrador(int id_cobrador);

        void AsociarCobrador(int id_cobrador, int id_zona);

	}
}
