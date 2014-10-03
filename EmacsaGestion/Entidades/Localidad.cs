using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Localidad
	/// </summary>
	public class Localidad : Entity <Localidad, LocalidadDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Localidad
		/// </summary>
		public  Localidad()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private int idDepartamento;
		private string nombre;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int ID
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public int IdDepartamento
				{
					get { return this.idDepartamento; }
					set { this.idDepartamento = value; }
				}
		
			public string Nombre
				{
					get { return this.nombre; }
					set { this.nombre = value; }
				}
		
		
		#endregion
	}
}
