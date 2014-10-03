using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2009-12-31
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_deudor
    /// Descripcion	: 
    /// </summary>
    public class DeudorLivianoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Deudor
        /// </summary>
        public DeudorLivianoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idDeudor;
        private string nombre;
        private string alfaNumDelCliente;

        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string AlfaNumDelCliente
        {
            get { return this.alfaNumDelCliente; }
            set { this.alfaNumDelCliente = value; }
        }


        #endregion
    }
}
