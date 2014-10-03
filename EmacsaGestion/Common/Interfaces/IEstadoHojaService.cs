using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad EstadoHojaDataContracts(EMACSA_NUCLEO.dbo.TBL_Estado_Hoja)
	/// </summary>
	public interface IEstadoHojaService
	{
		/// <summary>
		/// Interface para retornar un objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>EstadoHojaDataContracts</value>
		EstadoHojaDataContracts Load(short idEstado);
		
		/// <summary>
		/// interface para eliminar un EstadoHojaDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(EstadoHojaDataContracts oEstadoHoja);

        /// <summary>
		/// Interface para actualiza un objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(EstadoHojaDataContracts oEstadoHoja);
		
        /// <summary>
		/// Inteface para Insertar un objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(EstadoHojaDataContracts oEstadoHoja);

        /// <summary>
		/// Interface para  rertornar objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>EstadoHojaDataContracts</value>
	    EstadoHojaDataContracts GetEstadoHoja(short idEstado);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto EstadoHojaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<EstadoHojaDataContracts>]]></value>
		List<EstadoHojaDataContracts> GetAllEstadoHojas();
	}
}
