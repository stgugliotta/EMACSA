using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad DomicilioDeudorDataContracts(EMACSA_NUCLEO.dbo.TBL_Domicilio_Deudor)
	/// </summary>
	public interface IDomicilioDeudorService
	{
		/// <summary>
		/// Interface para retornar un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>DomicilioDeudorDataContracts</value>
		DomicilioDeudorDataContracts Load(int idDeudor);
		
		/// <summary>
		/// interface para eliminar un DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(DomicilioDeudorDataContracts oDomicilioDeudor);

        /// <summary>
		/// Interface para actualiza un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(DomicilioDeudorDataContracts oDomicilioDeudor);
		
        /// <summary>
		/// Inteface para Insertar un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(DomicilioDeudorDataContracts oDomicilioDeudor);
        void InsertNuevo(DomicilioDeudorDataContracts oDomicilioDeudor);
        /// <summary>
		/// Interface para  rertornar objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>DomicilioDeudorDataContracts</value>
	    DomicilioDeudorDataContracts GetDomicilioDeudor(int idDeudor);


        DomicilioDeudorDataContracts GetDomicilioDeudorByIdDeudorIdHoja(int idDeudor, int idHoja);
        
        /// <summary>
		/// Interface para  rertornar una lista de objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<DomicilioDeudorDataContracts>]]></value>
		List<DomicilioDeudorDataContracts> GetAllDomicilioDeudors();

	}
}
