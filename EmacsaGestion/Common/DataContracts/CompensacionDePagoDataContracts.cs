using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2011-02-03
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_compensaciondepago
    /// Descripcion	: 
    /// </summary>
    public class CompensacionDePagoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto CompensacionDePago
        /// </summary>
        public CompensacionDePagoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idCompensacion;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaRealizacionCompensacion;

        /// <summary>
        /// 
        /// </summary>
        private double monto;

        /// <summary>
        /// 
        /// </summary>
        private string reciboRelacionado;

        /// <summary>
        /// 
        /// </summary>
        private int idDeudor;

        /// <summary>
        /// 
        /// </summary>
        private int idCliente;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdCompensacion
        {
            get { return this.idCompensacion; }
            set { this.idCompensacion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaRealizacionCompensacion
        {
            get { return this.fechaRealizacionCompensacion; }
            set { this.fechaRealizacionCompensacion = value; }
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

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string ReciboRelacionado
        {
            get { return this.reciboRelacionado; }
            set { this.reciboRelacionado = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        #endregion
    }
}
