using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad LocalidadDataContracts(EMACSA_NUCLEO.dbo.TBL_Localidad)
	/// </summary>
	public interface ILocalidadService
	{
		/// <summary>
		/// Interface para retornar un objeto LocalidadDataContracts
		/// </summary>
		/// <value>LocalidadDataContracts</value>
		LocalidadDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un LocalidadDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(LocalidadDataContracts oLocalidad);

        /// <summary>
		/// Interface para actualiza un objeto LocalidadDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(LocalidadDataContracts oLocalidad);
		
        /// <summary>
		/// Inteface para Insertar un objeto LocalidadDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(LocalidadDataContracts oLocalidad);

        /// <summary>
		/// Interface para  rertornar objeto LocalidadDataContracts
		/// </summary>
		/// <value>LocalidadDataContracts</value>
	    LocalidadDataContracts GetLocalidad(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto LocalidadDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<LocalidadDataContracts>]]></value>
		List<LocalidadDataContracts> GetAllLocalidads();
        /// <summary>
        /// Interface para  rertornar una lista de objeto LocalidadDataContracts por Departamento
        /// </summary>
        /// <value>ListList<![CDATA[<LocalidadDataContracts>]]></value>
        List<LocalidadDataContracts> GetAllLocalidadsByDepartamento(int idDepartamento);
	}
}
