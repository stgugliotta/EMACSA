using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-03-12
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_cheque
    /// Descripcion	: 
    /// </summary>
    public class ChequeDataContracts:PagoDataContracts 
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Cheque
        /// </summary>
        public ChequeDataContracts()
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
        private long numero;

        /// <summary>
        /// 
        /// </summary>
        private string banco;

        /// <summary>
        /// 
        /// </summary>
        private string sucursal;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime emision;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime vencimiento;

        /// <summary>
        /// 
        /// </summary>
        private double importe;



        private int idPago;
        private DateTime fechaPago;
        private FormaPagoDataContracts formaPago;
        private string cuit;
        private string cp;
        private int orden;
        private string cuenta;


        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>long</value>
        public long Numero
        {
            get { return base.Numero; }
            set { base.Numero = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Banco
        {
            get { return base.Banco; }
            set { base.Banco = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Sucursal
        {
            get { return base.Sucursal; }
            set { base.Sucursal = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime Emision
        {
            get { return base.Emision; }
            set { base.Emision = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime Vencimiento
        {
            get { return base.Vencimiento; }
            set { base.Vencimiento = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double Importe
        {
            get
            { return base.Importe; }
            set { base.Importe = value; }
        }

        #endregion

        #region IPago Members

        public int IDPago
        {
            get
            {
                return this.idPago;
            }
            set
            {
                this.idPago = value;
            }
        }

        public string Cuit
        {
            get { return base.Cuit; }
            set { base.Cuit = value; }
        }
        public string Cp
        {
            get { return base.Cp; }
            set { base.Cp = value; }
        }

        public string Cuenta
        {
            get { return base.Cuenta; }
            set { base.Cuenta = value; }
        }

        public FormaPagoDataContracts FormaPago
        {
            get
            {
                return base.FormaPago;
                
            }
            set
            {
                base.FormaPago = value;
                
            }
        }

       

        #endregion

     




        public DateTime FechaPago
        {
            get
            {
                return base.FechaPago;
                
            }
            set
            {
                base.FechaPago = value;
                
            }
        }



        public override  string ToString()
        {
          
           
            return "s";
        }




        public int Orden
        {
            get
            {
                return base.Orden;
            }
            set
            {
                base.Orden = value;
            }
        }

    }
}
