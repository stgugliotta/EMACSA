using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad HojaDataContracts(EMACSA_NUCLEO.dbo.MTR_Hoja)
	/// </summary>
	public interface IHojaService
	{
		/// <summary>
		/// Interface para retornar un objeto HojaDataContracts
		/// </summary>
		/// <value>HojaDataContracts</value>
		HojaDataContracts Load(decimal idHoja);
		
		/// <summary>
		/// interface para eliminar un HojaDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(HojaDataContracts oHoja);

        /// <summary>
		/// Interface para actualiza un objeto HojaDataContracts
		/// </summary>
		/// <value>void</value>
        void Update(HojaDataContracts oHoja);
		
        /// <summary>
		/// Inteface para Insertar un objeto HojaDataContracts
		/// </summary>
		/// <value>void</value>
        void Insert(HojaDataContracts oHoja);

        /// <summary>
		/// Interface para  rertornar objeto HojaDataContracts
		/// </summary>
		/// <value>HojaDataContracts</value>
	    HojaDataContracts GetHoja(decimal idHoja);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto HojaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<HojaDataContracts>]]></value>
        List<HojaDataContracts> GetAllHojas();


        /// <summary>
		/// Interface para  rertornar una lista de objeto HojaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<HojaDataContracts>]]></value>
        List<HojaDataContracts> GetAllHojasEntreFechas(DateTime fechaCreacionDesde, DateTime fechaCreacionHasta);
	}
}
