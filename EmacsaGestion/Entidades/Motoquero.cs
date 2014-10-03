using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_Motoquero
    /// </summary>
    public class Motoquero : Entity<Motoquero, Common.DataContracts.MotoqueroDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Motoquero
        /// </summary>
        public Motoquero()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idMotoquero;
        private string descripcion;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdMotoquero
        {
            get { return this.idMotoquero; }
            set { this.idMotoquero = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }


        #endregion
    }
}
