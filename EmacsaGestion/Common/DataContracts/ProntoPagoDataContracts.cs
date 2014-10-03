using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-05-17
    /// Objeto		: EMACSA_NUCLEO.dbo.cfg_pronto_pago
    /// Descripcion	: 
    /// </summary>
    public class ProntoPagoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto ProntoPago
        /// </summary>
        public ProntoPagoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int id;

        /// <summary>
        /// 
        /// </summary>
        private int idDeudor;

        /// <summary>
        /// 
        /// </summary>
        private int idCliente;

        private DateTime  fechaLimiteDescuento;
        private int diasDeAnticipacion;

        private string nombreDeudor;
        private string nombreCliente;

        /// <summary>
        /// 
        /// </summary>
        private double porcentajeAplicacion;

        /// <summary>
        /// 
        /// </summary>
        private bool activo;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        public string NombreDeudor
        {
            get { return nombreDeudor; }
            set { nombreDeudor = value; }
        }

        public int DiasDeAnticipacion
        {
            get { return this.diasDeAnticipacion; }
            set { this.diasDeAnticipacion = value; }
        }

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }

        public DateTime FechaLimiteDescuento
        {
            get { return this.fechaLimiteDescuento; }
            set { this.fechaLimiteDescuento = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public double PorcentajeAplicacion
        {
            get { return this.porcentajeAplicacion; }
            set { this.porcentajeAplicacion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>bool</value>
        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        #endregion
    }
}
