using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Deposito
    /// </summary>
    public class Deposito : Entity<Deposito, DepositoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Deposito
        /// </summary>
        public Deposito()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private string idCuenta;
        private System.DateTime fechaDeposito;
        private string numComprobante;
        private double importe;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string IdCuenta
        {
            get { return this.idCuenta; }
            set { this.idCuenta = value; }
        }

        public System.DateTime FechaDeposito
        {
            get { return this.fechaDeposito; }
            set { this.fechaDeposito = value; }
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
