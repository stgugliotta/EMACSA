using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-04-11
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_recibo_factura
    /// Descripcion	: 
    /// </summary>
    public class ReciboFacturaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto ReciboFactura
        /// </summary>
        public ReciboFacturaDataContracts()
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
        private string numRecibo;

        /// <summary>
        /// 
        /// </summary>
        private int idFactura;

        /// <summary>
        /// 
        /// </summary>
        private double importe;

        /// <summary>
        /// 
        /// </summary>
        private double importeAImputar;

        /// <summary>
        /// 
        /// </summary>
        private string observacion;

        /// <summary>
        /// 
        /// </summary>
        private string importeProntoPago;

        /// <summary>
        /// 
        /// </summary>
        private double saldo;


        private double montoImputacion;

        private string moneda;
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
        public string NumRecibo
        {
            get { return this.numRecibo; }
            set { this.numRecibo = value; }
        }

        public string Moneda
        {
            get { return this.moneda; }
            set { this.moneda = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdFactura
        {
            get { return this.idFactura; }
            set { this.idFactura = value; }
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
        /// <value>double</value>
        public double ImporteAImputar
        {
            get { return this.importeAImputar; }
            set { this.importeAImputar = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Observacion
        {
            get { return this.observacion; }
            set { this.observacion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string ImporteProntoPago
        {
            get { return this.importeProntoPago; }
            set { this.importeProntoPago = value; }
        }


        public double Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }

        public double MontoImputacion
        {
            get { return this.montoImputacion; }
            set { this.montoImputacion = value; }
        }
        #endregion
    }
}
