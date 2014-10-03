using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-04-10
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_deposito
    /// Descripcion	: 
    /// </summary>
    public class DepositoDataContracts:PagoDataContracts 
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Deposito
        /// </summary>
        public DepositoDataContracts()
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
        private string idCuenta;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaDeposito;

        /// <summary>
        /// 
        /// </summary>
        private string numComprobante;

        /// <summary>
        /// 
        /// </summary>
        private float importe;


        /// <summary>
        /// 
        /// </summary>
        private int idPago;


        /// <summary>
        /// 
        /// </summary>
        private int orden;



        private FormaPagoDataContracts formaPago;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaPago;


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
        /// <value>string</value>
        public string IdCuenta
        {
            get { return base.IdCuenta; }
            set { base.IdCuenta = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaDeposito
        {
            get { return base.FechaDeposito; }
            set { base.FechaDeposito = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string NumComprobante
        {
            get { return base.NumComprobante; }
            set { base.NumComprobante = value; }
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

        public double Importe
        {
            get
            {
                return base.Importe;
            }
            set
            {
                base.Importe = value;
            }
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

        #region IPago Members


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

        #endregion
    }
}
