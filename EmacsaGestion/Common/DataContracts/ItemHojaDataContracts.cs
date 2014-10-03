using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2010-07-01
	/// Objeto		: EMACSA_NUCLEO.dbo.mtr_item_hoja
	/// Descripcion	: 
	/// </summary>
	public class ItemHojaDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto ItemHoja
		/// </summary>
		public  ItemHojaDataContracts() 
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
			private int nroItem;
		
			/// <summary>
			/// 
			/// </summary>
			private int idFactura;
		
			/// <summary>
			/// 
			/// </summary>
			private decimal idCliente;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fechaVenc;

            /// <summary>
            /// 
            /// </summary>
            private System.DateTime fechaCobro;

			/// <summary>
			/// 
			/// </summary>
			private int idDeudor;

            /// <summary>
            /// 
            /// </summary>
            private double importe;

            /// <summary>
            /// 
            /// </summary>
            private double saldo;

			/// <summary>
			/// 
			/// </summary>
			private double importeModificado;
		
			/// <summary>
			/// 
			/// </summary>
			private short idEstadoHoja;
		
			/// <summary>
			/// 
			/// </summary>
			private string observaciones;
		
			/// <summary>
			/// 
			/// </summary>
			private bool ingresada;

            /// <summary>
            /// 
            /// </summary>
            private bool sePago;
            /// <summary>
            /// 
            /// </summary>
            private int idCobrador;
            private string cobrador;
            private string comprobanteFormateado;
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
			public int NroItem
				{
					get { return this.nroItem; }
					set { this.nroItem = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdFactura
				{
					get { return this.idFactura; }
					set { this.idFactura = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>decimal</value>
			public decimal IdCliente
				{
					get { return this.idCliente; }
					set { this.idCliente = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>System.DateTime</value>
			public System.DateTime FechaVenc
				{
					get { return this.fechaVenc; }
					set { this.fechaVenc = value; }
				}
            /// <summary>
            /// 
            /// </summary>
            /// <value>System.DateTime</value>
            public System.DateTime FechaCobro
            {
                get { return this.fechaCobro; }
                set { this.fechaCobro = value; }
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
			/// <value>double</value>
			public double ImporteModificado
				{
					get { return this.importeModificado; }
					set { this.importeModificado = value; }
				}

            /// <summary>
            /// 
            /// </summary>
            /// <value>double</value>
            public double Importe
            {
                get { return this.importe; }
                set { this.importe = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <value>double</value>
            public double Saldo
            {
                get { return this.saldo; }
                set { this.saldo = value; }
            }

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
			public string Observaciones
				{
					get { return this.observaciones; }
					set { this.observaciones = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>bool</value>
			public bool Ingresada
				{
					get { return this.ingresada; }
					set { this.ingresada = value; }
				}


            /// <summary>
            /// 
            /// </summary>
            /// <value>bool</value>
            public bool SePago
            {
                get { return this.sePago; }
                set { this.sePago = value; }
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

            public string ComprobanteFormateado
            {
                get { return this.comprobanteFormateado; }
                set { this.comprobanteFormateado = value; }
            }

		#endregion
	}
}
