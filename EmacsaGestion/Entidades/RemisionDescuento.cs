using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Remision_Descuento
    /// </summary>
    public class RemisionDescuento : Entity<RemisionDescuento, RemisionDescuentoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  RemisionDescuento
        /// </summary>
        public RemisionDescuento()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private int idRemision;
        private int idDescuento;
        private double importe;
        private System.DateTime fechaDescuento;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int IdRemision
        {
            get { return this.idRemision; }
            set { this.idRemision = value; }
        }

        public int IdDescuento
        {
            get { return this.idDescuento; }
            set { this.idDescuento = value; }
        }

        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }

        public System.DateTime FechaDescuento
        {
            get { return this.fechaDescuento; }
            set { this.fechaDescuento = value; }
        }


        #endregion
    }
}
