using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-01-13
    /// Objeto		: GOBBI_NUCLEO.dbo.INT_Factura
    /// Descripcion	: 
    /// </summary>  
    public class InterfazFacturaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Configuration
        /// </summary>
        public InterfazFacturaDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S

        private decimal idIntefazFactura;
        private System.DateTime fechaProceso;
        private short linea;
        private int idCliente;
        private string idDeudor;
        private string idTipoComprobante;
        private string letra;
        private string emision;
        private short numeroPag;
        private short cantidadP;
        private string nroComprobante;
        private double importe;
        private double saldo;
        private string idMoneda;
        private System.DateTime fechaEmision;
        private System.DateTime fechaVencimiento;
        private string observaciones;
        private string estado;

        #endregion

        #region P U B L I C  P R O P E R T I E S

        public decimal IdIntefazFactura
        {
            get { return this.idIntefazFactura; }
            set { this.idIntefazFactura = value; }
        }
        public System.DateTime FechaProceso
        {
            get { return this.fechaProceso; }
            set { this.fechaProceso = value; }
        }
        public short Linea
        {
            get { return this.linea; }
            set { this.linea = value; }
        }
        public int IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }
        public string IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }
        public string IdTipoComprobante
        {
            get { return this.idTipoComprobante; }
            set { this.idTipoComprobante = value; }
        }
        public string Letra
        {
            get { return this.letra; }
            set { this.letra = value; }
        }
        public string Emision
        {
            get { return this.emision; }
            set { this.emision = value; }
        }
        public short NumeroPag
        {
            get { return this.numeroPag; }
            set { this.numeroPag = value; }
        }
        public short CantidadP
        {
            get { return this.cantidadP; }
            set { this.cantidadP = value; }
        }
        public string NroComprobante
        {
            get { return this.nroComprobante; }
            set { this.nroComprobante = value; }
        }
        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }
        public double Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }
        public string IdMoneda
        {
            get { return this.idMoneda; }
            set { this.idMoneda = value; }
        }
        public System.DateTime FechaEmision
        {
            get { return this.fechaEmision; }
            set { this.fechaEmision = value; }
        }
        public System.DateTime FechaVencimiento
        {
            get { return this.fechaVencimiento; }
            set { this.fechaVencimiento = value; }
        }
        public string Observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }
        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        #endregion
    }
}
