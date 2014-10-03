using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad ClienteDeudorDataContracts(EMACSA_NUCLEO.dbo.TBL_Cliente_Deudor)
	/// </summary>
	public interface IClienteDeudorService
	{
		/// <summary>
		/// Interface para retornar un objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>ClienteDeudorDataContracts</value>
		ClienteDeudorDataContracts Load(int idCliente,int idDeudor);
		
		/// <summary>
		/// interface para eliminar un ClienteDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(ClienteDeudorDataContracts oClienteDeudor);

        /// <summary>
		/// Interface para actualiza un objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(ClienteDeudorDataContracts oClienteDeudor);
		
        /// <summary>
		/// Inteface para Insertar un objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(ClienteDeudorDataContracts oClienteDeudor);

        /// <summary>
		/// Interface para  rertornar objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>ClienteDeudorDataContracts</value>
	    ClienteDeudorDataContracts GetClienteDeudor(int idCliente,int idDeudor);

        /// <summary>
        /// Interface para  rertornar objeto ClienteDeudorDataContracts
        /// </summary>
        /// <value>ClienteDeudorDataContracts</value>
        ClienteDeudorDataContracts GetClienteAlfanumDelCliente(int idCliente, string alfanumDelCliente);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto ClienteDeudorDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<ClienteDeudorDataContracts>]]></value>
		List<ClienteDeudorDataContracts> GetAllClienteDeudors();

        /// <summary>
        /// Interface para  rertornar una lista de objeto ClienteDeudorDataContracts por IdDeudor
        /// </summary>
        /// <value>ListList<![CDATA[<ClienteDeudorDataContracts>]]></value>
        List<ClienteDeudorDataContracts> GetAllClienteDeudorsByIdDeudor(int idDeudor);
	}
}
