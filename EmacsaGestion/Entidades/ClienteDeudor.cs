using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Cliente_Deudor
	/// </summary>
	public class ClienteDeudor : Entity <ClienteDeudor, ClienteDeudorDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  ClienteDeudor
		/// </summary>
		public  ClienteDeudor()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int idCliente;
		private int idDeudor;
		private string alfanumdelcliente;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int IdCliente
				{
					get { return this.idCliente; }
					set { this.idCliente = value; }
				}
		
			public int IdDeudor
				{
					get { return this.idDeudor; }
					set { this.idDeudor = value; }
				}
		
			public string Alfanumdelcliente
				{
					get { return this.alfanumdelcliente; }
					set { this.alfanumdelcliente = value; }
				}
		
		
		#endregion
	}
}
