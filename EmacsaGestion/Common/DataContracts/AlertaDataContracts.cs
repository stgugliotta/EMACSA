using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2011-03-07
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_alerta
    /// Descripcion	: 
    /// </summary>
    public class AlertaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Alerta
        /// </summary>
        public AlertaDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idAlerta;

        /// <summary>
        /// 
        /// </summary>
        private string alerta;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdAlerta
        {
            get { return this.idAlerta; }
            set { this.idAlerta = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string AlertaDes
        {
            get { return this.alerta; }
            set { this.alerta = value; }
        }

        #endregion
    }
}
