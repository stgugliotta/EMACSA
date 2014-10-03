using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-07-17
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_dias
    /// Descripcion	: 
    /// </summary>
    public class DiasDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Dias
        /// </summary>
        public DiasDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idDia;

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
        public int IdDia
        {
            get { return this.idDia; }
            set { this.idDia = value; }
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
