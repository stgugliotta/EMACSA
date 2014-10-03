using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-04-06
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_descuento
    /// Descripcion	: 
    /// </summary>
    public class DescuentoDataContracts :PagoDataContracts 
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Descuento
        /// </summary>
        public DescuentoDataContracts()
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
        private string concepto;

        /// <summary>
        /// 
        /// </summary>
        private int porcentajeDeAplicacion;

        /// <summary>
        /// 
        /// </summary>
        private float importeADescontar;

        /// <summary>
        /// 
        /// </summary>
        private DateTime  fechaPago;

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
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Concepto
        {
            get { return this.concepto; }
            set { this.concepto = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int PorcentajeDeAplicacion
        {
            get { return this.porcentajeDeAplicacion; }
            set { this.porcentajeDeAplicacion = value; }
        }


        public float ImporteADescontar
        {
            get { return this.importeADescontar; }
            set { this.importeADescontar = value; }
        }


        #endregion

        #region IPago Members

        public int IDPago
        {
            get
            {
                return base.IdPago;
            }
            set
            {
                base.IdPago = value;
            }
        }
        public DateTime FechaPago
        {
            get
            {
                return base.FechaPago;
            }
            set
            {
                base.FechaPago=value;
            }
        }

     
        public double Importe
        {
            get
            {
                return base.Importe ;
            }
            set
            {
                base.Importe  = value;
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
