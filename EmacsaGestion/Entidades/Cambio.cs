using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Accion
    /// </summary>
    public class Cambio : Entity<Cambio, CambioDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Accion
        /// </summary>
        public Cambio()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private string nombre;
        private double cambio;
        private DateTime fechaVigencia;
        private int idMoneda;
        private int idCambio;
        
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdMoneda
        {
            get { return this.idMoneda; }
            set { this.idMoneda = value; }
        }

        public int IdCambio
        {
            get { return this.idCambio; }
            set { this.idCambio = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public System.DateTime FechaVigencia
        {
            get { return this.fechaVigencia; }
            set { this.fechaVigencia = value; }
        }

        public double ValorCambio
        {
            get { return this.cambio; }
            set { this.cambio  = value; }
        }

        #endregion
    }
}
