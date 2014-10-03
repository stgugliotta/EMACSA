using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-05-24
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_recibo_pago
    /// Descripcion	: 
    /// </summary>
    public class ReciboPagoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto ReciboPago
        /// </summary>
        public ReciboPagoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idRecibo;

        /// <summary>
        /// 
        /// </summary>
        private int idPago;

        /// <summary>
        /// 
        /// </summary>
        private string numRecibo;

        /// <summary>
        /// 
        /// </summary>
        private string formaPago;

        private int idMoneda;

        private double totalPesificado;
        private double importePago;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdRecibo
        {
            get { return this.idRecibo; }
            set { this.idRecibo = value; }
        }

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
        /// <value>string</value>
        public string NumRecibo
        {
            get { return this.numRecibo; }
            set { this.numRecibo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string FormaPago
        {
            get { return this.formaPago; }
            set { this.formaPago = value; }
        }

        public int IdMoneda
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
            get { return importePago ; }
            set { importePago = value; }
        }

        #endregion
    }
}
