using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-04-06
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_remision_descuento
    /// Descripcion	: 
    /// </summary>
    public class RemisionDescuentoDataContracts:PagoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto RemisionDescuento
        /// </summary>
        public RemisionDescuentoDataContracts()
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
        private int idRemision;

        /// <summary>
        /// 
        /// </summary>
        private int idDescuento;

        /// <summary>
        /// 
        /// </summary>
        private double importe;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaDescuento;

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
        /// <value>int</value>
        public int IdRemision
        {
            get { return this.idRemision; }
            set { this.idRemision = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDescuento
        {
            get { return this.idDescuento; }
            set { this.idDescuento = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double Importe
        {
            get { return base.Importe; }
            set { base.Importe = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaDescuento
        {
            get { return base.FechaDescuento; }
            set { base.FechaDescuento = value; }
        }

        #endregion
    }
}
