using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2010-04-11
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_domicilio_deudor
	/// Descripcion	: 
	/// </summary>
	public class DomicilioDeudorAlternativoParaGrillaDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto DomicilioDeudor
		/// </summary>
		public  DomicilioDeudorAlternativoParaGrillaDataContracts() 
				{
				}
		#endregion
		
		#region A T T R I B U T E S
			/// <summary>
			/// 
			/// </summary>
          
		
		#endregion

        public string Domicilio { get; set; }
        public string Partido { get; set; }
        public string Localidad { get; set; }
        public string Cp { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public int Id { get; set; }
        public int IdDomicilioDeudorAlternativo { get; set; }
        public bool DirPpal { get; set; }
        
		
	}
}
