using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-23
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_analista
    /// Descripcion	: 
    /// </summary>
    public class AnalistaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Analista
        /// </summary>
        public AnalistaDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idAnalista;

        /// <summary>
        /// 
        /// </summary>
        private string nombre;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdAnalista
        {
            get { return this.idAnalista; }
            set { this.idAnalista = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public override string ToString()
        {

            return this.nombre;
        }

        
        #endregion
    }
}
