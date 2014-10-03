using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_CompensacionDePago
    /// </summary>
    public class CompensacionDePago : Entity<CompensacionDePago, CompensacionDePagoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  CompensacionDePago
        /// </summary>
        public CompensacionDePago()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idCompensacion;
        private System.DateTime fechaRealizacionCompensacion;
        private double monto;
        private string reciboRelacionado;
        private int idDeudor;
        private int idCliente;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdCompensacion
        {
            get { return this.idCompensacion; }
            set { this.idCompensacion = value; }
        }

        public System.DateTime FechaRealizacionCompensacion
        {
            get { return this.fechaRealizacionCompensacion; }
            set { this.fechaRealizacionCompensacion = value; }
        }

        public double Monto
        {
            get { return this.monto; }
            set { this.monto = value; }
        }

        public string ReciboRelacionado
        {
            get { return this.reciboRelacionado; }
            set { this.reciboRelacionado = value; }
        }

        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        public int IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }


        #endregion
    }
}
