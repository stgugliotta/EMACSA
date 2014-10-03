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
    public class Alerta : Entity<Alerta, AlertaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Alerta
        /// </summary>
        public Alerta()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idAlerta;
        private string alerta;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdAlerta
        {
            get { return this.idAlerta; }
            set { this.idAlerta = value; }
        }

        public string AlertaDes
        {
            get { return this.alerta; }
            set { this.alerta = value; }
        }


        #endregion
    }
}
