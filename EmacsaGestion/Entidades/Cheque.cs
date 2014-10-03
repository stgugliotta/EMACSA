using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_Cheque
    /// </summary>
    public class Cheque : Entity<Cheque, ChequeDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Cheque
        /// </summary>
        public Cheque()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private long numero;
        private string banco;
        private string sucursal;
        private System.DateTime emision;
        private System.DateTime vencimiento;

        private int idPago;
        private DateTime fechaPago;
        private FormaPago formaPago;
        private string cuit;
        private string cp;
        private string cuenta;
        private double importe;
    
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public long Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public string Banco
        {
            get { return this.banco; }
            set { this.banco = value; }
        }

        public string Sucursal
        {
            get { return this.sucursal; }
            set { this.sucursal = value; }
        }


        public string Cuenta
        {
            get { return this.cuenta; }
            set { this.cuenta = value; }
        }


        public string Cuit
        {
            get { return this.cuit; }
            set { this.cuit = value; }
        }
        public string Cp
        {
            get { return this.cp; }
            set { this.cp = value; }
        }
        public System.DateTime Emision
        {
            get { return this.emision; }
            set { this.emision = value; }
        }

        public System.DateTime Vencimiento
        {
            get { return this.vencimiento; }
            set { this.vencimiento = value; }
        }


        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }

        #endregion

       

 

      
    }
}
