using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Transferencia
    /// </summary>
    public class Transferencia : Entity<Transferencia, TransferenciaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Transferencia
        /// </summary>
        public Transferencia()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private System.DateTime fechaDeposito;
        private string cuentaCredito;
        private string cuentaDebito;
        private System.DateTime fechaCarga;
        private string numComprobante;
        private double importe;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public System.DateTime FechaDeposito
        {
            get { return this.fechaDeposito; }
            set { this.fechaDeposito = value; }
        }

        public string CuentaCredito
        {
            get { return this.cuentaCredito; }
            set { this.cuentaCredito = value; }
        }

        public string CuentaDebito
        {
            get { return this.cuentaDebito; }
            set { this.cuentaDebito = value; }
        }

        public System.DateTime FechaCarga
        {
            get { return this.fechaCarga; }
            set { this.fechaCarga = value; }
        }

        public string NumComprobante
        {
            get { return this.numComprobante; }
            set { this.numComprobante = value; }
        }

        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }


        #endregion
    }
}
