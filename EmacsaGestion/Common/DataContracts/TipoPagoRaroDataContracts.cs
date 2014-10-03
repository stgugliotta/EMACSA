using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-04-03
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_tipopagoraro
    /// Descripcion	: 
    /// </summary>
    public class TipoPagoRaroDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto TipoPagoRaro
        /// </summary>
        public TipoPagoRaroDataContracts()
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
        private string tipoPago;

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
        public string TipoPago
        {
            get { return this.tipoPago; }
            set { this.tipoPago = value; }
        }

        #endregion
    }
}
