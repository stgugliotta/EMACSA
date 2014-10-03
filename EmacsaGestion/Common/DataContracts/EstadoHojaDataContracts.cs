using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2010-07-01
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_estado_hoja
	/// Descripcion	: 
	/// </summary>
	public class EstadoHojaDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto EstadoHoja
		/// </summary>
		public  EstadoHojaDataContracts() 
				{
				}
		#endregion
		
		#region A T T R I B U T E S
			/// <summary>
			/// 
			/// </summary>
			private short idEstadoHoja;
		
			/// <summary>
			/// 
			/// </summary>
			private string descripcion;
		
			/// <summary>
			/// 
			/// </summary>
			private bool requiereObservacion;
		
		#endregion
		
		#region P U B L I C  P R O P E R T I E S
			/// <summary>
			/// 
			/// </summary>
			/// <value>short</value>
			public short IdEstadoHoja
				{
					get { return this.idEstadoHoja; }
					set { this.idEstadoHoja = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Descripcion
				{
					get { return this.descripcion; }
					set { this.descripcion = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>bool</value>
			public bool RequiereObservacion
				{
					get { return this.requiereObservacion; }
					set { this.requiereObservacion = value; }
				}
				
		#endregion
	}
}
