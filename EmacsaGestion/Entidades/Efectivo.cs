using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Efectivo
    /// </summary>
    public class Efectivo : Entity<Efectivo, EfectivoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Efectivo
        /// </summary>
        public Efectivo()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private System.DateTime fechaPago;
        private double monto;
        private double importe;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public System.DateTime FechaPago
        {
            get { return this.fechaPago; }
            set { this.fechaPago = value; }
        }

        public double Monto
        {
            get { return this.monto; }
            set { this.monto = value; }
        }

        public double Importe
        {
            get
            {
                return importe;
            }
            set
            {
                importe = value;
            }
        }

        #endregion
    }
}
