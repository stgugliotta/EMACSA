using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.MTR_Cobrador
	/// </summary>
	public class Cobrador : Entity <Cobrador, CobradorDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Cobrador
		/// </summary>
		public Cobrador()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private string nombre;
		private string apellido;
        private string dni;
        private string telefono;
        private string horario;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public string Nombre
				{
					get { return this.nombre; }
					set { this.nombre = value; }
				}
		
			public string Apellido
				{
					get { return this.apellido; }
					set { this.apellido = value; }
				}

            public string DNI
            {
                get { return this.dni; }
                set { this.dni = value; }
            }

            public string Telefono
            {
                get { return this.telefono; }
                set { this.telefono = value; }
            }

            public string Horario
            {
                get { return this.horario; }
                set { this.horario = value; }
            }

		#endregion
	}
}
