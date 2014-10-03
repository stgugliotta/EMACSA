using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad DepartamentoDataContracts(EMACSA_NUCLEO.dbo.TBL_Departamento)
	/// </summary>
	public interface IDepartamentoService
	{
		/// <summary>
		/// Interface para retornar un objeto DepartamentoDataContracts
		/// </summary>
		/// <value>DepartamentoDataContracts</value>
		DepartamentoDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un DepartamentoDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(DepartamentoDataContracts oDepartamento);

        /// <summary>
		/// Interface para actualiza un objeto DepartamentoDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(DepartamentoDataContracts oDepartamento);
		
        /// <summary>
		/// Inteface para Insertar un objeto DepartamentoDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(DepartamentoDataContracts oDepartamento);

        /// <summary>
		/// Interface para  rertornar objeto DepartamentoDataContracts
		/// </summary>
		/// <value>DepartamentoDataContracts</value>
	    DepartamentoDataContracts GetDepartamento(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto DepartamentoDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<DepartamentoDataContracts>]]></value>
		List<DepartamentoDataContracts> GetAllDepartamentos();



        /// <summary>
        /// Interface para  rertornar una lista de objeto DepartamentoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DepartamentoDataContracts>]]></value>
        List<DepartamentoDataContracts> GetAllDepartamentosByProvincia(int idProvincia);
	}
}
