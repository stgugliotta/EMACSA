using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.CFG_Pronto_Pago
    /// </summary>
    public class ProntoPago : Entity<ProntoPago, ProntoPagoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  ProntoPago
        /// </summary>
        public ProntoPago()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private int idDeudor;
        private int idCliente;
        private string nombreDeudor;
        private string nombreCliente;
        private DateTime  fechaLimiteDescuento;
        private int diasDeAnticipacion;
       
        private double porcentajeAplicacion;
        private bool activo;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
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
        public string NombreDeudor
        {
            get { return nombreDeudor; }
            set { nombreDeudor = value; }
        }


        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }
        public DateTime  FechaLimiteDescuento
        {
            get { return this.fechaLimiteDescuento; }
            set { this.fechaLimiteDescuento = value; }
        }

        public int DiasDeAnticipacion
        {
            get { return this.diasDeAnticipacion; }
            set { this.diasDeAnticipacion = value; }
        }

        
        public double PorcentajeAplicacion
        {
            get { return this.porcentajeAplicacion; }
            set { this.porcentajeAplicacion = value; }
        }

        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }


        #endregion
    }
}
