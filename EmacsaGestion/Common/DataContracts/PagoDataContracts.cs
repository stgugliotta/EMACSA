using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-03-14
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_pago
    /// Descripcion	: 
    /// </summary>
    public class PagoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Pago
        /// </summary>
        public PagoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S  G E N E R I C S
        /// <summary>
        /// 
        /// </summary>
        private int idPago;

        /// <summary>
        /// 
        /// </summary>
        private double importe;

        /// <summary>
        /// 
        /// </summary>
        private int idTipoPago;

        /// <summary>
        /// 
        /// </summary>
        private int idMoneda;


        /// <summary>
        /// 
        /// </summary>
        private FormaPagoDataContracts formaPago;


        private double totalPesificado;

        private int idTipoPagoRaro;
        #endregion
        #region A T T R I B U T E S  P A R T I C U L A R S  C H E Q U E

        private int id;
        private long numero;
        private string banco;
        private string sucursal;
        private DateTime emision;
        private DateTime vencimiento;
        private string cuenta;
        private string cp;
        private string cuit;

        #endregion
        #region A T T R I B U T E S  P A R T I C U L A R S   R E T E N C I O N
        /// <summary>
        /// 
        /// </summary>
        private int idRetencion;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaPago;

       private string numeroRetencion;
           

        #endregion
        #region A T T R I B U T E S  P A R T I C U L A R S  D E P O S I T O

        private string idCuenta;
        private string numComprobante;
        private DateTime fechaDeposito;
        #endregion
        #region A T T R I B U T E S  P A R T I C U L A R S  T N A N S F E R E N C I A 

        private string cuentaCredito;
        private string cuentaDebito;
        private DateTime fechaCarga;
        #endregion

        #region A T T R I B U T E S  P A R T I C U L A R S  D E S C U E N T O 

        private int idRemision;
        private int idDescuento;
        private DateTime fechaDescuento;
        #endregion

        #region P U B L I C  P R O P E R T I E S G E N E R I C S

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdPago
        {
            get { return this.idPago; }
            set { this.idPago = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdTipoPago
        {
            get { return this.idTipoPago; }
            set { this.idTipoPago = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdMoneda
        {
            get { return this.idMoneda; }
            set { this.idMoneda = value; }
        }

        public int Orden { get; set; }

        public DateTime FechaPago { get; set; }

        public string Moneda
        {
            get
            {
                switch (this.idMoneda)
                {
                    case 1:return CONSTANT.PESOS;
                        break;
                    case 2:return CONSTANT.DOLARES;
                        break;
                    case 3:return CONSTANT.EUROS;
                        break;
                    default :
                        return CONSTANT.PESOS;

                }
                
            }
       

        }

        public FormaPagoDataContracts FormaPago
        {

            get { return this.formaPago; }

            set { this.formaPago = value; }
        }

        #endregion
        #region P U B L I C  P R O P E R T I E S  P A R T I C U L A R S  C H E Q U E 

        
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
        /// <value>long</value>
        public long Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Banco
        {
            get { return this.banco; }
            set { this.banco = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Sucursal
        {
            get { return this.sucursal; }
            set { this.sucursal = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime Emision
        {
            get { return this.emision; }
            set { this.emision = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime Vencimiento
        {
            get { return this.vencimiento; }
            set { this.vencimiento = value; }
        }

        public string Cuenta { 
            
            get {return this.cuenta;}
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

        #endregion
        #region P U B L I C  P R O P E R T I E S   P A R T I C U L A R S  R E T E N C I O N

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdRetencion
        {
            get { return this.idRetencion; }
            set { this.idRetencion = value; }
        }
        public string NumeroRetencion
        {
            get { return this.numeroRetencion; }
            set { this.numeroRetencion = value; }
        }

        #endregion
        #region P U B L I C  P R O P E R T I E S  P A R T I C U L A R S  D E P O S I T O 

        public string IdCuenta {
            get { return this.idCuenta; }
            set { this.idCuenta = value; }
        }
        public string NumComprobante
        {
            get { return this.numComprobante; }
            set { this.numComprobante = value; }
        }

        public System.DateTime FechaDeposito
        {
            get { return this.fechaDeposito; }
            set { this.fechaDeposito = value; }
        }

       
        #endregion
        #region P U B L I C  P R O P E R T I E S  P A R T I C U L A R S  T R A N S F E R E N C I A 
        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string CuentaCredito
        {
            get { return this.cuentaCredito; }
            set { this.cuentaCredito = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string CuentaDebito
        {
            get { return this.cuentaDebito; }
            set { this.cuentaDebito = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public DateTime  FechaCarga
        {
            get { return this.fechaCarga; }
            set { this.fechaCarga = value; }
        }


        #endregion

        #region P U B L I C  P R O P E R T I E S  P A R T I C U L A R S   D E S C U E N T O
        public int IdRemision
        {
            get { return this.idRemision; }
            set { this.idRemision = value; }
        }

        public int IdDescuento
        {
            get { return this.idDescuento; }
            set { this.idDescuento = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaDescuento
        {
            get { return this.fechaDescuento; }
            set { this.fechaDescuento = value; }
        }

        public double TotalPesificado
        {
            get { return totalPesificado; }
            set { totalPesificado = value; }
        }

        #endregion

        #region PUBLIC PROPERTIES PARTICULARS OTROPAGO

        public int IdTipoPagoRaro
        {
            get { return this.idTipoPagoRaro; }
            set { this.idTipoPagoRaro = value; }
        }

        #endregion
    }
}
