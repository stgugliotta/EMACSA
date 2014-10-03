using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Dias
    /// </summary>
    public class Dias : Entity<Dias, DiasDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Dias
        /// </summary>
        public Dias()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idDia;
        private string descripcion;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdDia
        {
            get { return this.idDia; }
            set { this.idDia = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }


        #endregion
    }
}
