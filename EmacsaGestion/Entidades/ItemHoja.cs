using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.MTR_Item_Hoja
	/// </summary>
	public class ItemHoja : Entity <ItemHoja, ItemHojaDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  ItemHoja
		/// </summary>
		public  ItemHoja()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private decimal idHoja;
		private int nroItem;
		private int idFactura;
		private decimal idCliente;
		private System.DateTime fechaVenc;
		private int idDeudor;
		private double importeModificado;
		private short idEstadoHoja;
		private string observaciones;
		private bool ingresada;
        private bool sePago;
        private int idCobrador;
        private string cobrador;
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
		
			public int IdFactura
				{
					get { return this.idFactura; }
					set { this.idFactura = value; }
				}
		
			public decimal IdCliente
				{
					get { return this.idCliente; }
					set { this.idCliente = value; }
				}
		
			public System.DateTime FechaVenc
				{
					get { return this.fechaVenc; }
					set { this.fechaVenc = value; }
				}
		
			public int IdDeudor
				{
					get { return this.idDeudor; }
					set { this.idDeudor = value; }
				}
		
			public double ImporteModificado
				{
					get { return this.importeModificado; }
					set { this.importeModificado = value; }
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



		
		#endregion
	}
}
