using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2010-07-01
	/// Objeto		: EMACSA_NUCLEO.dbo.mtr_hoja
	/// Descripcion	: 
	/// </summary>
	public class HojaViewDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Hoja
		/// </summary>
        public HojaViewDataContracts() 
				{
				}
		#endregion
		
		#region A T T R I B U T E S
			/// <summary>
			/// 
			/// </summary>
			private decimal idHoja;
		
			/// <summary>
			/// 
			/// </summary>
			private int idCobrador;
            private string cobrador;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fechaCreacion;
		
			/// <summary>
			/// 
			/// </summary>
			private string usuario;

            private List<ItemHojaDataContracts> itemsHoja;
		
		#endregion
		
		#region P U B L I C  P R O P E R T I E S
			/// <summary>
			/// 
			/// </summary>
			/// <value>decimal</value>
			public decimal IdHoja
				{
					get { return this.idHoja; }
					set { this.idHoja = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdCobrador
				{
					get { return this.idCobrador; }
					set { this.idCobrador = value; }
				}

            public string Cobrador
            {
                get { return this.cobrador; }
                set { this.cobrador = value; }
            }

			/// <summary>
			/// 
			/// </summary>
			/// <value>System.DateTime</value>
			public System.DateTime FechaCreacion
				{
					get { return this.fechaCreacion; }
					set { this.fechaCreacion = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Usuario
				{
					get { return this.usuario; }
					set { this.usuario = value; }
				}


            public List<ItemHojaDataContracts> ItemsHoja
            {
                get { return this.itemsHoja; }
                set { this.itemsHoja = value; }
            }
		
		#endregion
	}
}
