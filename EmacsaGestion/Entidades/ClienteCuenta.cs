using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Cliente_Cuenta
    /// </summary>
    public class ClienteCuenta : Entity<ClienteCuenta, ClienteCuentaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  ClienteCuenta
        /// </summary>
        public ClienteCuenta()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private int idCliente;
        private string nombreCliente;
        private string cuenta;
        private bool habilitada;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        public string NombreCliente
        {
            get { return this.nombreCliente; }
            set { this.nombreCliente = value; }
        }

        public string Cuenta
        {
            get { return this.cuenta; }
            set { this.cuenta = value; }
        }

        public bool Habilitada
        {
            get { return this.habilitada; }
            set { this.habilitada = value; }
        }


        #endregion
    }
}
