using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
	/// <summary>
	/// Interface para manejar la entidad DomicilioDeudorDataContracts(EMACSA_NUCLEO.dbo.TBL_Domicilio_Deudor)
	/// </summary>
	public interface IDomicilioDeudorAlternativoService
	{
		/// <summary>
		/// Interface para retornar un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>DomicilioDeudorDataContracts</value>
        DomicilioDeudorAlternativoDataContracts Load(int idDeudor);
		
		/// <summary>
		/// interface para eliminar un DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
        void Delete(DomicilioDeudorAlternativoDataContracts oDomicilioDeudor);

        /// <summary>
		/// Interface para actualiza un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
        void Update(DomicilioDeudorAlternativoDataContracts oDomicilioDeudor);
		
        /// <summary>
		/// Inteface para Insertar un objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>void</value>
        void Insert(DomicilioDeudorAlternativoDataContracts oDomicilioDeudor);

        /// <summary>
		/// Interface para  rertornar objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>DomicilioDeudorDataContracts</value>
        DomicilioDeudorAlternativoDataContracts GetDomicilioDeudor(int idDeudor);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto DomicilioDeudorDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<DomicilioDeudorDataContracts>]]></value>
        List<DomicilioDeudorAlternativoDataContracts> GetAllDomicilioDeudors();

        List<DomicilioDeudorAlternativoDataContracts> GetAllDomicilioDeudorsPorIdDeudor(int idDeudor);

	}
}
