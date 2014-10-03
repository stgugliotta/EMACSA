using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-03-15
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_motoquero
    /// Descripcion	: 
    /// </summary>
    public class MotoqueroDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Motoquero
        /// </summary>
        public MotoqueroDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idMotoquero;

        /// <summary>
        /// 
        /// </summary>
        private string descripcion;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdMotoquero
        {
            get { return this.idMotoquero; }
            set { this.idMotoquero = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        #endregion
    }
}
