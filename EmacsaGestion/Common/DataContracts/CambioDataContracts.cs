using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_accion
    /// Descripcion	: 
    /// </summary>
    public class CambioDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Accion
        /// </summary>
        public CambioDataContracts()
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
            set { this.cambio = value; }
        }
        public int IdCambio
        {
            get { return this.idCambio; }
            set { this.idCambio = value; }
        }
        #endregion

    }
}
