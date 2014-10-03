using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.MTR_Item_Hoja_DSG
	/// </summary>
	public class ItemHojaDSG : Entity <ItemHojaDSG, ItemHojaDSGDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  ItemHojaDSG
		/// </summary>
		public  ItemHojaDSG()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private decimal idHoja;
		private int nroItem;
		private decimal idCliente;
		private string idDeudor;
		private string deudorRazonSocial;
		private string deudorDomicilio;
		private string deudorLocalidad;
		private string deudorDia;
		private string deudorHorario;
		private short idEstadoHoja;
		private string observaciones;
		private bool ingresada;
		private bool sePago;
		private int idCobrador;
        private string cobrador;
        private string alfaNumDelCliente;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public decimal IdHoja
				{
					get { return this.idHoja; }
					set { this.idHoja = value; }
				}
		
			public int NroItem
				{
					get { return this.nroItem; }
					set { this.nroItem = value; }
				}
		
			public decimal IdCliente
				{
					get { return this.idCliente; }
					set { this.idCliente = value; }
				}
		
			public string IdDeudor
				{
					get { return this.idDeudor; }
					set { this.idDeudor = value; }
				}
		
			public string DeudorRazonSocial
				{
					get { return this.deudorRazonSocial; }
					set { this.deudorRazonSocial = value; }
				}
		
			public string DeudorDomicilio
				{
					get { return this.deudorDomicilio; }
					set { this.deudorDomicilio = value; }
				}
		
			public string DeudorLocalidad
				{
					get { return this.deudorLocalidad; }
					set { this.deudorLocalidad = value; }
				}
		
			public string DeudorDia
				{
					get { return this.deudorDia; }
					set { this.deudorDia = value; }
				}
		
			public string DeudorHorario
				{
					get { return this.deudorHorario; }
					set { this.deudorHorario = value; }
				}
		
			public short IdEstadoHoja
				{
					get { return this.idEstadoHoja; }
					set { this.idEstadoHoja = value; }
				}
		
			public string Observaciones
				{
					get { return this.observaciones; }
					set { this.observaciones = value; }
				}
		
			public bool Ingresada
				{
					get { return this.ingresada; }
					set { this.ingresada = value; }
				}
		
			public bool SePago
				{
					get { return this.sePago; }
					set { this.sePago = value; }
				}
		
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

            public string AlfaNumDelCliente
            {
                get { return this.alfaNumDelCliente; }
                set { this.alfaNumDelCliente = value; }
            }
		#endregion
	}
}
