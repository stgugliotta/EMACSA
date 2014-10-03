using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2010-03-23
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_cliente_deudor
	/// Descripcion	: 
	/// </summary>
	public class ClienteDeudorDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto ClienteDeudor
		/// </summary>
		public  ClienteDeudorDataContracts() 
				{
				}
		#endregion
		
		#region A T T R I B U T E S
			/// <summary>
			/// 
			/// </summary>
			private int idCliente;
		
			/// <summary>
			/// 
			/// </summary>
			private int idDeudor;
		
			/// <summary>
			/// 
			/// </summary>
			private string alfanumdelcliente;
		
		#endregion
		
		#region P U B L I C  P R O P E R T I E S
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdCliente
				{
					get { return this.idCliente; }
					set { this.idCliente = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdDeudor
				{
					get { return this.idDeudor; }
					set { this.idDeudor = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Alfanumdelcliente
				{
					get { return this.alfanumdelcliente; }
					set { this.alfanumdelcliente = value; }
				}
				
		#endregion


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            ClienteDeudorDataContracts cdDTO = (ClienteDeudorDataContracts)obj;
            return (cdDTO.IdCliente == this.idCliente && cdDTO.IdDeudor == this.idDeudor);
        }


	}
}
