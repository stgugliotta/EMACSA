using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.services;
using Common.Interfaces;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-06
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_factura
    /// Descripcion	: 
    /// </summary>
    public class FacturaDataContracts
    {
        private IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Factura
        /// </summary>
        public FacturaDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idFactura;

        /// <summary>
        /// 
        /// </summary>
        private decimal idCliente;

        /// <summary>
        /// 
        /// </summary>
        private string tipoCobro;

        /// <summary>
        /// 
        /// </summary>
        private string letra;

        /// <summary>
        /// 
        /// </summary>
        private decimal emision;

        /// <summary>
        /// 
        /// </summary>
        private decimal numeroComp;

        /// <summary>
        /// 
        /// </summary>
        private int idDeudor;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaVenc;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaCobro;

        /// <summary>
        /// 
        /// </summary>
        private string moneda;

        /// <summary>
        /// 
        /// </summary>
        private double importe;

        /// <summary>
        /// 
        /// </summary>
        private double importePP;


        /// <summary>
        /// 
        /// </summary>
        private double saldo;

        /// <summary>
        /// 
        /// </summary>
        private int idEstadoFactura;

        /// <summary>
        /// 
        /// </summary>
        private string avisada;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime proximaGestion;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaIngreso;

        private string numFacturaCompleto;

        /// <summary>
        /// 
        /// </summary>
        private string observaciones;

        /// <summary>
        /// 
        /// </summary>
        private string estado;

        private string id_tipo_comprobante;
        private System.DateTime fecha_emision;
        private string comprobanteFormateado;
        private int idRemision;
        private string estadoRemision;
        private string numeroRecibo;
        private double montoUltimaImputacion;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdFactura
        {
            get { return this.idFactura; }
            set { this.idFactura = value; }
        }

        public int IdRemision
        {
            get { return this.idRemision; }
            set { this.idRemision = value; }
        }

        public string NumeroRecibo
        {
            get { return this.numeroRecibo; }
            set { this.numeroRecibo = value; }
        }

        public string EstadoRemision
        {
            get { return this.estadoRemision; }
            set { this.estadoRemision = value; }
        }
        
        public string Visible
        {
            get { return "false"; }
            
        }
        public string NumFacturaCompleto
        {
            get { return this.numFacturaCompleto; }
            set { this.numFacturaCompleto = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value>decimal</value>
        public decimal IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string TipoCobro
        {
            get { return this.tipoCobro; }
            set { this.tipoCobro = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Letra
        {
            get { return this.letra; }
            set { this.letra = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>decimal</value>
        public decimal Emision
        {
            get { return this.emision; }
            set { this.emision = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>decimal</value>
        public decimal NumeroComp
        {
            get { return this.numeroComp; }
            set { this.numeroComp = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaVenc
        {
            get { return this.fechaVenc; }
            set { this.fechaVenc = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaCobro
        {
            get { return this.fechaCobro; }
            set { this.fechaCobro = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Moneda
        {
            get { return this.moneda; }
            set { this.moneda = value; }
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
        public string ImporteFormateado
        {
            get { return this.importe.ToString().Replace(",","."); }

        }

        public string SaldoFormateado
        {
            get { return this.saldo.ToString().Replace(",", "."); }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double ImportePP
        {
            get { return this.importePP; }
            set { this.importePP = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdEstadoFactura
        {
            get { return this.idEstadoFactura; }
            set { this.idEstadoFactura = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Avisada
        {
            get { return this.avisada; }
            set { this.avisada = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime ProximaGestion
        {
            get { return this.proximaGestion; }
            set { this.proximaGestion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaIngreso
        {
            get { return this.fechaIngreso; }
            set { this.fechaIngreso = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string Id_Tipo_Comprobante
        {
            get { return this.id_tipo_comprobante; }
            set { this.id_tipo_comprobante = value; }
        }

        public System.DateTime FechaEmision
        {
            get { return this.fecha_emision; }
            set { this.fecha_emision = value; }
        }

        public string ComprobanteFormateado {
            get { return this.letra + " " + this.emision + " " + this.numeroComp; }
            set { this.comprobanteFormateado = value; }
        }

        public string NombreDeudor
        {
            get { return deudorServices.Load(this.idDeudor).Nombre; }
        }

        public double MontoUltimaImputacion
        {
            get { return this.montoUltimaImputacion; }
            set { this.montoUltimaImputacion = value; }
        }

        #endregion
    }
}
