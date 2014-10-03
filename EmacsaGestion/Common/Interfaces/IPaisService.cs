using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad PaisDataContracts(EMACSA_NUCLEO.dbo.TBL_Pais)
	/// </summary>
	public interface IPaisService
	{
		/// <summary>
		/// Interface para retornar un objeto PaisDataContracts
		/// </summary>
		/// <value>PaisDataContracts</value>
		PaisDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un PaisDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(PaisDataContracts oPais);

        /// <summary>
		/// Interface para actualiza un objeto PaisDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(PaisDataContracts oPais);
		
        /// <summary>
		/// Inteface para Insertar un objeto PaisDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(PaisDataContracts oPais);

        /// <summary>
		/// Interface para  rertornar objeto PaisDataContracts
		/// </summary>
		/// <value>PaisDataContracts</value>
	    PaisDataContracts GetPais(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto PaisDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<PaisDataContracts>]]></value>
		List<PaisDataContracts> GetAllPaiss();
	}
}
