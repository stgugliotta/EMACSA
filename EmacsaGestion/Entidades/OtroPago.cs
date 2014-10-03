using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_OtroPago
    /// </summary>
    public class OtroPago : Entity<OtroPago, OtroPagoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  OtroPago
        /// </summary>
        public OtroPago()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private System.DateTime fechaPago;
        private string numComprobante;
        private double importe;
        private int idTipoPagoRaro;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public System.DateTime FechaPago
        {
            get { return this.fechaPago; }
            set { this.fechaPago = value; }
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

        public int IdTipoPagoRaro
        {
            get { return this.idTipoPagoRaro ; }
            set { this.idTipoPagoRaro  = value; }
        }

        #endregion
    }
}
