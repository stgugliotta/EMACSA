using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad ProvinciaDataContracts(EMACSA_NUCLEO.dbo.TBL_Provincia)
	/// </summary>
	public interface IProvinciaService
	{
		/// <summary>
		/// Interface para retornar un objeto ProvinciaDataContracts
		/// </summary>
		/// <value>ProvinciaDataContracts</value>
		ProvinciaDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un ProvinciaDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(ProvinciaDataContracts oProvincia);

        /// <summary>
		/// Interface para actualiza un objeto ProvinciaDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(ProvinciaDataContracts oProvincia);
		
        /// <summary>
		/// Inteface para Insertar un objeto ProvinciaDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(ProvinciaDataContracts oProvincia);

        /// <summary>
		/// Interface para  rertornar objeto ProvinciaDataContracts
		/// </summary>
		/// <value>ProvinciaDataContracts</value>
	    ProvinciaDataContracts GetProvincia(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto ProvinciaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<ProvinciaDataContracts>]]></value>
		List<ProvinciaDataContracts> GetAllProvincias();

        /// <summary>
        /// Interface para retornar una lista de objeto ProvinciaDataContracts.
        /// </summary>
        /// <param name="idPais">Pais a buscar.</param>
        /// <value>ListList<![CDATA[<ProvinciaDataContracts>]]></value>
        List<ProvinciaDataContracts> GetAllProvinciasByPais(int idPais);

	}
}
