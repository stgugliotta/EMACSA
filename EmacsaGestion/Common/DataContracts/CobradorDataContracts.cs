using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2010-04-11
	/// Objeto		: EMACSA_NUCLEO.dbo.mtr_cobrador
	/// Descripcion	: 
	/// </summary>
	public class CobradorDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Cobrador
		/// </summary>
		public  CobradorDataContracts() 
				{
				}
		#endregion
		
		#region A T T R I B U T E S
			/// <summary>
			/// 
			/// </summary>
			private int id;
		
			/// <summary>
			/// 
			/// </summary>
			private string nombre;
		
			/// <summary>
			/// 
			/// </summary>
			private string apellido;

            /// <summary>
            /// 
            /// </summary>
            private string dni;

            /// <summary>
            /// 
            /// </summary>
            private string telefono;

            /// <summary>
            /// 
            /// </summary>
            private string horario;
				
		#endregion
		
		#region P U B L I C  P R O P E R T I E S
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Nombre
				{
					get { return this.nombre; }
					set { this.nombre = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Apellido
				{
					get { return this.apellido; }
					set { this.apellido = value; }
				}

            /// <summary>
            /// 
            /// </summary>
            /// <value>string</value>
            public string DNI
            {
                get { return this.dni; }
                set { this.dni = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <value>string</value>
            public string Telefono
            {
                get { return this.telefono; }
                set { this.telefono = value; }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <value>string</value>
            public string Horario
            {
                get { return this.horario; }
                set { this.horario = value; }
            }



            public string NombreApellido
            {
                get {
                    if (this.nombre != null && this.nombre.Equals(this.apellido))
                    {
                        return this.nombre;
                    }
                    else {
                        return this.nombre + " " + this.apellido;
                    }
                }
            }
		#endregion
	}
}
