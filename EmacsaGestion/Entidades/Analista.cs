using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_Analista
    /// </summary>
    public class Analista : Entity<Analista, AnalistaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Analista
        /// </summary>
        public Analista()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idAnalista;
        private string nombre;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdAnalista
        {
            get { return this.idAnalista; }
            set { this.idAnalista = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }


        #endregion
    }
}
