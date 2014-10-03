using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Recibo_Pago
    /// </summary>
    public class ReciboPago : Entity<ReciboPago, ReciboPagoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  ReciboPago
        /// </summary>
        public ReciboPago()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idRecibo;
        private int idPago;
        private string numRecibo;
        private string formaPago;
        private int idMoneda;
        private double totalPesificado;
        private double importePago;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdRecibo
        {
            get { return this.idRecibo; }
            set { this.idRecibo = value; }
        }

        public int IdPago
        {
            get { return this.idPago; }
            set { this.idPago = value; }
        }

        public string NumRecibo
        {
            get { return this.numRecibo; }
            set { this.numRecibo = value; }
        }

        public string FormaPago
        {
            get { return this.formaPago; }
            set { this.formaPago = value; }
        }

        public int  IdMoneda
        {
            get { return idMoneda; }
            set { idMoneda = value; }
        }

        public double TotalPesificado
        {
            get { return totalPesificado; }
            set { totalPesificado = value; }
        }

        public double ImportePago
        {
            get { return importePago; }
            set { importePago = value; }
        }

        #endregion
    }
}
