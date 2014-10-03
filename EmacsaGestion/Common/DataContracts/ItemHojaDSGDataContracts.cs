using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2011-02-19
	/// Objeto		: EMACSA_NUCLEO.dbo.mtr_item_hoja_dsg
	/// Descripcion	: 
	/// </summary>
	public class ItemHojaDSGDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto ItemHojaDSG
		/// </summary>
		public  ItemHojaDSGDataContracts() 
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
			private decimal idCliente;
		
			/// <summary>
			/// 
			/// </summary>
			private string idDeudor;
		
			/// <summary>
			/// 
			/// </summary>
			private string deudorRazonSocial;
		
			/// <summary>
			/// 
			/// </summary>
			private string deudorDomicilio;
		
			/// <summary>
			/// 
			/// </summary>
			private string deudorLocalidad;
		
			/// <summary>
			/// 
			/// </summary>
			private string deudorDia;
		
			/// <summary>
			/// 
			/// </summary>
			private string deudorHorario;
		
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

            private string alfaNumDelCliente;
		
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
			/// <value>decimal</value>
			public decimal IdCliente
				{
					get { return this.idCliente; }
					set { this.idCliente = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string IdDeudor
				{
					get { return this.idDeudor; }
					set { this.idDeudor = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string DeudorRazonSocial
				{
					get { return this.deudorRazonSocial; }
					set { this.deudorRazonSocial = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string DeudorDomicilio
				{
					get { return this.deudorDomicilio; }
					set { this.deudorDomicilio = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string DeudorLocalidad
				{
					get { return this.deudorLocalidad; }
					set { this.deudorLocalidad = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string DeudorDia
				{
					get { return this.deudorDia; }
					set { this.deudorDia = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string DeudorHorario
				{
					get { return this.deudorHorario; }
					set { this.deudorHorario = value; }
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

            public String error { get; set; } 
		
		#endregion


          

            public string Cobrador
            {
                get { return this.cobrador; }
                set { this.cobrador = value; }
            }

            public string AlfaNumDelCliente
            {
                get { return this.alfaNumDelCliente; }
                set { this.alfaNumDelCliente = value; }
            }
	}
}
