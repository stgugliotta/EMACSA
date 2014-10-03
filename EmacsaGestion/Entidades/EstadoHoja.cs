using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Estado_Hoja
	/// </summary>
	public class EstadoHoja : Entity <EstadoHoja, EstadoHojaDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  EstadoHoja
		/// </summary>
		public  EstadoHoja()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private short idEstadoHoja;
		private string descripcion;
		private bool requiereObservacion;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public short IdEstadoHoja
				{
					get { return this.idEstadoHoja; }
					set { this.idEstadoHoja = value; }
				}
		
			public string Descripcion
				{
					get { return this.descripcion; }
					set { this.descripcion = value; }
				}
		
			public bool RequiereObservacion
				{
					get { return this.requiereObservacion; }
					set { this.requiereObservacion = value; }
				}
		
		
		#endregion
	}
}
