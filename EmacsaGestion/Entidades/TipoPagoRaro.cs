using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_TipoPagoRaro
    /// </summary>
    public class TipoPagoRaro : Entity<TipoPagoRaro, TipoPagoRaroDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  TipoPagoRaro
        /// </summary>
        public TipoPagoRaro()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private string tipoPago;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string TipoPago
        {
            get { return this.tipoPago; }
            set { this.tipoPago = value; }
        }


        #endregion
    }
}
