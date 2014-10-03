using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Pago
    /// </summary>
    public class Pago : Entity<Pago, PagoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Pago
        /// </summary>
        public Pago()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idPago;
        private double importe;
        private int idTipoPago;
        private int idMoneda;
        private DateTime fechaPago;
        private FormaPago formaPago;
        private DateTime fechaCarga;
        private DateTime fechaDescuento;
        private string moneda;
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
        #region A T T R I B U T E S   P A R T I C U L A R S   R E T E N C I O N

        private int idRetencion;
        private string numeroRetencion;
        #endregion
        #region A T T R I B U T E S  P A R T I C U L A R S  D E P O S I T O
        private string numComprobante;
        private string idCuenta;
        private DateTime fechaDeposito;
        #endregion
        #region A T T R I B U T E S  P A R T I C U L A R S  T N A N S F E R E N C I A

        private string cuentaCredito;
        private string cuentaDebito;
        #endregion


        #region P U B L I C    P R O P E R T I E S


        public int IdTipoPago
        {
            get { return this.idTipoPago; }
            set { this.idTipoPago = value; }
        }

        public int IdMoneda
        {
            get { return this.idMoneda; }
            set { this.idMoneda = value; }
        }



        public int IDPago
        {
            get { return this.idPago; }
            set { this.idPago = value; }
        }

        public DateTime FechaPago
        {
            get
            {
                return this.fechaPago;
            }
            set
            {
                this.fechaPago = value;
            }
        }

        public FormaPago FormaPago
        {
            get
            {
                return this.formaPago;
            }
            set
            {
                this.formaPago = value;
            }
        }

        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }

        public int Orden { get; set; }


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

        #endregion
        #region P U B L I C   P R O P E R T I E S   P A R T I C U L A R S   R E T E N C I O N

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
        #region P U B L I C   P R O P E R T I E S   P A R T I C U L A R S   D E P O S I T O

        public string IdCuenta
        {
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
        public DateTime FechaCarga
        {
            get { return this.fechaCarga; }
            set { this.fechaCarga = value; }
        }



        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public DateTime FechaDescuento
        {
            get { return this.fechaDescuento; }
            set { this.fechaDescuento = value; }
        }

        public double TotalPesificado
        {
            get { return totalPesificado; }
            set { totalPesificado = value; }
        }

        public int IdTipoPagoRaro
        {
            get { return idTipoPagoRaro; }
            set { idTipoPagoRaro = value; }

        }
    }
}
