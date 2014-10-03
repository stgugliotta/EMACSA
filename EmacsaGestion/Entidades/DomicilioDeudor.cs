using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Domicilio_Deudor
	/// </summary>
	public class DomicilioDeudor : Entity <DomicilioDeudor, DomicilioDeudorDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  DomicilioDeudor
		/// </summary>
		public  DomicilioDeudor()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int idDeudor;
		private int idPais;
		private int idProvincia;
		private int idDepartamento;
		private int idLocalidad;
		private string calleNombre;
		private int calleAltura;
		private string cp;
		private string gmFormattedAddress;
		private double gmLat;
		private double gmLng;
        private int piso;
        private string depto;
        private bool dirPpal;
        private int idDomicilioAlternativo;

        public int IdDomicilioAlternativo
        {
            get { return idDomicilioAlternativo; }
            set { idDomicilioAlternativo = value; }
        }

       
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int IdDeudor
				{
					get { return this.idDeudor; }
					set { this.idDeudor = value; }
				}
		
			public int IdPais
				{
					get { return this.idPais; }
					set { this.idPais = value; }
				}
		
			public int IdProvincia
				{
					get { return this.idProvincia; }
					set { this.idProvincia = value; }
				}
		
			public int IdDepartamento
				{
					get { return this.idDepartamento; }
					set { this.idDepartamento = value; }
				}
		
			public int IdLocalidad
				{
					get { return this.idLocalidad; }
					set { this.idLocalidad = value; }
				}
		
			public string CalleNombre
				{
					get { return this.calleNombre; }
					set { this.calleNombre = value; }
				}
		
			public int CalleAltura
				{
					get { return this.calleAltura; }
					set { this.calleAltura = value; }
				}
		
			public string Cp
				{
					get { return this.cp; }
					set { this.cp = value; }
				}
		
			public string GmFormattedAddress
				{
					get { return this.gmFormattedAddress; }
					set { this.gmFormattedAddress = value; }
				}
		
			public double GmLat
				{
					get { return this.gmLat; }
					set { this.gmLat = value; }
				}
		
			public double GmLng
				{
					get { return this.gmLng; }
					set { this.gmLng = value; }
				}

            public int Piso
            {
                get { return this.piso; }
                set { this.piso = value;  }
            }


            public string Depto
            {
                get { return this.depto; }
                set { this.depto = value; }
            }

            public bool DirPpal
            {
                get { return dirPpal; }
                set { dirPpal = value; }
            }
        #endregion
	}
}
