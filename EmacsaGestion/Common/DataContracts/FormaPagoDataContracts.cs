using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-03-14
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_forma_pago
    /// Descripcion	: 
    /// </summary>
    public class FormaPagoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto FormaPago
        /// </summary>
        public FormaPagoDataContracts()
        {
        }

        public FormaPagoDataContracts(int idFormaPago, string descripcion)
        {
            this.idFormaPago = idFormaPago;
            this.descripcion = descripcion;
        }

        public override string ToString()
        {
            return this.descripcion;
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idFormaPago;

        /// <summary>
        /// 
        /// </summary>
        private string descripcion;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdFormaPago
        {
            get { return this.idFormaPago; }
            set { this.idFormaPago = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        #endregion
    }
}
