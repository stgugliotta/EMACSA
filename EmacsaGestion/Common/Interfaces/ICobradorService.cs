using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad CobradorDataContracts(EMACSA_NUCLEO.dbo.MTR_Cobrador)
	/// </summary>
	public interface ICobradorService
	{
		/// <summary>
		/// Interface para retornar un objeto CobradorDataContracts
		/// </summary>
		/// <value>CobradorDataContracts</value>
		CobradorDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un CobradorDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(CobradorDataContracts oCobrador);

        /// <summary>
		/// Interface para actualiza un objeto CobradorDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(CobradorDataContracts oCobrador);
		
        /// <summary>
		/// Inteface para Insertar un objeto CobradorDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(CobradorDataContracts oCobrador);

        /// <summary>
		/// Interface para  rertornar objeto CobradorDataContracts
		/// </summary>
		/// <value>CobradorDataContracts</value>
	    CobradorDataContracts GetCobrador(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto CobradorDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<CobradorDataContracts>]]></value>
		List<CobradorDataContracts> GetAllCobrador();

	    List<CobradorDataContracts> GetAllCobradorPorZonaAsignada(int idZona);

	}
}
