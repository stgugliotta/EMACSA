using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Descuento
    /// </summary>
    public class Descuento : Entity<Descuento, DescuentoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Descuento
        /// </summary>
        public Descuento()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private string concepto;
        private int porcentajeDeAplicacion;
        private float importeADescontar;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Concepto
        {
            get { return this.concepto; }
            set { this.concepto = value; }
        }

        public int PorcentajeDeAplicacion
        {
            get { return this.porcentajeDeAplicacion; }
            set { this.porcentajeDeAplicacion = value; }
        }

        public float ImporteADescontar
        {
            get { return this.importeADescontar; }
            set { this.importeADescontar = value; }
        }


        #endregion
    }
}
