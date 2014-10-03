using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_Deudor
    /// </summary>
    public class DeudorLiviano : Entity<DeudorLiviano, DeudorLivianoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Deudor
        /// </summary>
        public DeudorLiviano()
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
