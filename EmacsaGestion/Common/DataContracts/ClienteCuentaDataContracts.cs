using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-04-03
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_cliente_cuenta
    /// Descripcion	: 
    /// </summary>
    public class ClienteCuentaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto ClienteCuenta
        /// </summary>
        public ClienteCuentaDataContracts()
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
        private int idCliente;

        /// <summary>
        /// 
        /// </summary>
        private string nombreCliente;

        /// <summary>
        /// 
        /// </summary>
        private string cuenta;

        /// <summary>
        /// 
        /// </summary>
        private bool habilitada;

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
        public int IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string NombreCliente
        {
            get { return this.nombreCliente; }
            set { this.nombreCliente = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Cuenta
        {
            get { return this.cuenta; }
            set { this.cuenta = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>bool</value>
        public bool Habilitada
        {
            get { return this.habilitada; }
            set { this.habilitada = value; }
        }

        #endregion
    }
}
