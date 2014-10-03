using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Retencion
    /// </summary>
    public class Retencion : Entity<Retencion, RetencionDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Retencion
        /// </summary>
        public Retencion()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private int idRetencion;
        private int idSubTipoRetencion;
        private double importe;
        private System.DateTime fechaPago;
        private string numeroRetencion;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int IdRetencion
        {
            get { return this.idRetencion; }
            set { this.idRetencion = value; }
        }

        public int IdSubTipoRetencion
        {
            get { return this.idSubTipoRetencion; }
            set { this.idSubTipoRetencion = value; }
        }


        public double Importe
        {
            get { return this.importe; }
            set { this.importe = value; }
        }

        public System.DateTime FechaPago
        {
            get { return this.fechaPago; }
            set { this.fechaPago = value; }
        }

        public string NumeroRetencion
        {
            get
            {
                return this.numeroRetencion;

            }
            set
            {
                this.numeroRetencion = value;

            }

        }     

        #endregion
    }
}
