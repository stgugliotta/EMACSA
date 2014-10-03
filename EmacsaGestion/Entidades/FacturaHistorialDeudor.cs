using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_Factura
    /// </summary>
    public class FacturaHistorialDeudor : Entity<FacturaHistorialDeudor, FacturaHistorialDeudorDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Factura
        /// </summary>
        public FacturaHistorialDeudor()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idFactura;
        private decimal idCliente;
        private string tipoCobro;
        private string letra;
        private decimal emision;
        private decimal numeroComp;
        private int idDeudor;
        private System.DateTime fechaVenc;
        private System.DateTime fechaCobro;
        private string moneda;
        private double importe;
        private double saldo;
        private double importePP;
        private int idEstadoFactura;
        private string avisada;
        private System.DateTime proximaGestion;
        private System.DateTime fechaIngreso;
        private string observaciones;
        private string estado;
        private DateTime fechaActividad;
        private string id_tipo_comprobante;
        private System.DateTime fecha_emision;
        private string usuario;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdFactura
        {
            get { return this.idFactura; }
            set { this.idFactura = value; }
        }

        public decimal IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        public string TipoCobro
        {
            get { return this.tipoCobro; }
            set { this.tipoCobro = value; }
        }

        public string Letra
        {
            get { return this.letra; }
            set { this.letra = value; }
        }

        public decimal Emision
        {
            get { return this.emision; }
            set { this.emision = value; }
        }

        public decimal NumeroComp
        {
            get { return this.numeroComp; }
            set { this.numeroComp = value; }
        }

        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        public System.DateTime FechaVenc
        {
            get { return this.fechaVenc; }
            set { this.fechaVenc = value; }
        }
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }


        public System.DateTime FechaActividad
        {
            get { return this.fechaActividad; }
            set { this.fechaActividad = value; }

        }
        public System.DateTime FechaCobro
        {
            get { return this.fechaCobro; }
            set { this.fechaCobro = value; }
        }

        public string Moneda
        {
            get { return this.moneda; }
            set { this.moneda = value; }
        }

        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }

        public double ImportePP
        {
            get { return this.importePP; }
            set { this.importePP = value; }
        }

        public double Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }

        public int IdEstadoFactura
        {
            get { return this.idEstadoFactura; }
            set { this.idEstadoFactura = value; }
        }

        public string Avisada
        {
            get { return this.avisada; }
            set { this.avisada = value; }
        }

        public System.DateTime ProximaGestion
        {
            get { return this.proximaGestion; }
            set { this.proximaGestion = value; }
        }

        public System.DateTime FechaIngreso
        {
            get { return this.fechaIngreso; }
            set { this.fechaIngreso = value; }
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
        #endregion
    }
}
