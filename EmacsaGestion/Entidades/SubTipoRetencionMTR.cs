using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_SubTipoRetencion
    /// </summary>
    public class SubTipoRetencionMTR : Entity<SubTipoRetencionMTR, SubTipoRetencionMTRDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  SubTipoRetencionMTR
        /// </summary>
        public SubTipoRetencionMTR()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private string descripcion;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }


        #endregion
    }
}
