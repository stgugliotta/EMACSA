using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Objeto		: EMACSA_NUCLEO.dbo.log_factura
    /// Descripcion	: 
    /// </summary>
    public class LOG_FacturaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto LogFactura
        /// </summary>
        public LOG_FacturaDataContracts()
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
        private int idFactura;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaActividad;

        /// <summary>
        /// 
        /// </summary>
        private string usuario;

        /// <summary>
        /// 
        /// </summary>
        private string observacion;

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
        public int IdFactura
        {
            get { return this.idFactura; }
            set { this.idFactura = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaActividad
        {
            get { return this.fechaActividad; }
            set { this.fechaActividad = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Observacion
        {
            get { return this.observacion; }
            set { this.observacion = value; }
        }

        #endregion
    }
}
