using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-04-10
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_efectivo
    /// Descripcion	: 
    /// </summary>
    public class EfectivoDataContracts:PagoDataContracts 
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Efectivo
        /// </summary>
        public EfectivoDataContracts()
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
        private System.DateTime fechaPago;

        /// <summary>
        /// 
        /// </summary>
        private double monto;

        /// <summary>
        /// 
        /// </summary>
        private int idPago;


        /// <summary>
        /// 
        /// </summary>
        private int orden;



        private FormaPagoDataContracts formaPago;


        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaPago
        {
            get { return base.FechaPago; }
            set { base.FechaPago = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double Monto
        {
            get { return this.monto; }
            set { this.monto = value; }
        }

        #endregion

        #region IPago Members

        public int IDPago
        {
            get
            {
                return this.idPago;
            }
            set
            {
                this.idPago = value;
            }
        }
       
        public double Importe
        {
            get
            {
                return base.Importe;
            }
            set
            {
                base.Importe = value;
            }
        }

        public int Orden
        {
            get
            {
                return base.Orden;
            }
            set
            {
                base.Orden = value;
            }
        }

        public FormaPagoDataContracts FormaPago
        {
            get
            {
                return base.FormaPago;
            }
            set
            {
                base.FormaPago = value;
            }
        }

        #endregion
    }
}
