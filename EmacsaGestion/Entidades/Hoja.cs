using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.MTR_Hoja
	/// </summary>
	public class Hoja : Entity <Hoja, HojaDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Hoja
		/// </summary>
		public  Hoja()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private decimal idHoja;
		private System.DateTime fechaCreacion;
		private string usuario;

        private List<ItemHoja> itemsHoja;

		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public decimal IdHoja
				{
					get { return this.idHoja; }
					set { this.idHoja = value; }
				}
		
		
			public System.DateTime FechaCreacion
				{
					get { return this.fechaCreacion; }
					set { this.fechaCreacion = value; }
				}
		
			public string Usuario
				{
					get { return this.usuario; }
					set { this.usuario = value; }
				}

            public List<ItemHoja> ItemsHoja
            {
                get { return this.itemsHoja; }
                set { this.itemsHoja = value; }
            }
		
		#endregion
	}
}
