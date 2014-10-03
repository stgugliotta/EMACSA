using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_Alerta
    /// </summary>
    public class Banco : Entity<Banco, BancoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Alerta
        /// </summary>
        public Banco()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idBanco;
        private string codigo;
        private string descripcion;

        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdBanco
        {
            get { return this.idBanco ; }
            set { this.idBanco  = value; }
        }

        public string Codigo
        {
            get { return this.codigo ; }
            set { this.codigo  = value; }
        }


        public string Descripcion
        {
            get { return this.descripcion ; }
            set { this.descripcion  = value; }
        }


        #endregion
    }
}
