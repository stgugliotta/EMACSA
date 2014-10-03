using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-04-10
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_retencion
    /// Descripcion	: 
    /// </summary>
    public class RetencionDataContracts:PagoDataContracts 
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Retencion
        /// </summary>
        public RetencionDataContracts()
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
        private int idRetencion;


        /// <summary>
        /// 
        /// </summary>
        private int idSubTipoRetencion;



        /// <summary>
        /// 
        /// </summary>
        private float importe;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaPago;


        /// <summary>
        /// 
        /// </summary>
        private int idPago;


        /// <summary>
        /// 
        /// </summary>
        private int orden;

        private string numeroRetencion;


 
      

        private FormaPagoDataContracts formaPago;

        #endregion

        #region P U B L I C  P R O P E R T I E S

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
        /// <value>int</value>
        public int IdRetencion
        {
            get { return base.IdRetencion; }
            set { base.IdRetencion = value; }
        }

        public int IdSubTipoRetencion
        {
            get { return this.idSubTipoRetencion; }
            set { this.idSubTipoRetencion = value; }
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

        public int IdPago { get; set; }

        public string NumeroRetencion 
         {
            get { return base.NumeroRetencion; }
            set { base.NumeroRetencion = value; }
        }

        #endregion
    }
}
