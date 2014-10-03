using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2010-04-11
	/// Objeto		: EMACSA_NUCLEO.dbo.tbl_domicilio_deudor
	/// Descripcion	: 
	/// </summary>
	public class DomicilioDeudorAlternativoDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto DomicilioDeudor
		/// </summary>
		public  DomicilioDeudorAlternativoDataContracts() 
				{
				}
		#endregion
		
		#region A T T R I B U T E S
			/// <summary>
			/// 
			/// </summary>
            /// 
			private int idDeudor;
            private int idDeudorDomicilioAlternativo;
			/// <summary>
			/// 
			/// </summary>
			private int idPais;
		
			/// <summary>
			/// 
			/// </summary>
			private int idProvincia;
		
			/// <summary>
			/// 
			/// </summary>
			private int idDepartamento;
		
			/// <summary>
			/// 
			/// </summary>
			private int idLocalidad;
            private int id;
			/// <summary>
			/// 
			/// </summary>
			private string calleNombre;
		
			/// <summary>
			/// 
			/// </summary>
			private int calleAltura;
		
			/// <summary>
			/// 
			/// </summary>
			private string cp;
		
			/// <summary>
			/// 
			/// </summary>
			private string gmFormattedAddress;
		
			/// <summary>
			/// 
			/// </summary>
			private double gmLat;
		
			/// <summary>
			/// 
			/// </summary>
			private double gmLng;

            private int piso;

            private string depto;

            private bool dirPpal;

		
		#endregion
		
		#region P U B L I C  P R O P E R T I E S
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
            public int IdDeudorDomicilioAlternativo
        {
            get { return this.idDeudorDomicilioAlternativo; }
            set { this.idDeudorDomicilioAlternativo = value; }
        }

            public bool DirPpal
            {
                get { return this.dirPpal; }
                set { this.dirPpal = value; }
            }

			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}


            public int IdDeudor
            {
                get { return this.idDeudor; }
                set { this.idDeudor = value; }
            }

			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdPais
				{
					get { return this.idPais; }
					set { this.idPais = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdProvincia
				{
					get { return this.idProvincia; }
					set { this.idProvincia = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdDepartamento
				{
					get { return this.idDepartamento; }
					set { this.idDepartamento = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdLocalidad
				{
					get { return this.idLocalidad; }
					set { this.idLocalidad = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string CalleNombre
				{
					get { return this.calleNombre; }
					set { this.calleNombre = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int CalleAltura
				{
					get { return this.calleAltura; }
					set { this.calleAltura = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Cp
				{
					get { return this.cp; }
					set { this.cp = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string GmFormattedAddress
				{
					get { return this.gmFormattedAddress; }
					set { this.gmFormattedAddress = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>double</value>
			public double GmLat
				{
					get { return this.gmLat; }
					set { this.gmLat = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>double</value>
			public double GmLng
				{
					get { return this.gmLng; }
					set { this.gmLng = value; }
				}

            public int Piso
            {
                get { return this.piso; }
                set { this.piso = value; }
            }

            public string Depto
            {
                get { return this.depto; }
                set { this.depto = value; }
            }

        
        #endregion
	}
}
