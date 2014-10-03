using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts
{
    public class BancoDataContracts
    {
        #region A T T R I B U T E S
        private int idBanco;
        private string codigo;
        private string descripcion;

        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdBanco
        {
            get { return this.idBanco; }
            set { this.idBanco = value; }
        }

        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }


        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }


        #endregion
    }
}
