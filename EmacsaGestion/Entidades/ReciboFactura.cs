using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Recibo_Factura
    /// </summary>
    public class ReciboFactura : Entity<ReciboFactura, ReciboFacturaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  ReciboFactura
        /// </summary>
        public ReciboFactura()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private string numRecibo;
        private int idFactura;
        private double importe;
        private double importeAImputar;
        private string observacion;
        private string importeProntoPago;
        private double saldo;
        private double montoImputacion;
        private string moneda;

        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string NumRecibo
        {
            get { return this.numRecibo; }
            set { this.numRecibo = value; }
        }

        public int IdFactura
        {
            get { return this.idFactura; }
            set { this.idFactura = value; }
        }

        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }

        public double ImporteAImputar
        {
            get { return this.importeAImputar; }
            set { this.importeAImputar = value; }
        }

        public string Observacion
        {
            get { return this.observacion; }
            set { this.observacion = value; }
        }

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

        public string Moneda
        {
            get { return this.moneda; }
            set { this.moneda = value; }
        }
        #endregion
    }
}
