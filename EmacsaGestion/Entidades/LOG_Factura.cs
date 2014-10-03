using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.LOG_Factura
    /// </summary>
    public class LogFactura : Entity<LogFactura, LOG_FacturaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  LogFactura
        /// </summary>
        public LogFactura()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private int idFactura;
        private System.DateTime fechaActividad;
        private string usuario;
        private string observacion;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int IdFactura
        {
            get { return this.idFactura; }
            set { this.idFactura = value; }
        }

        public System.DateTime FechaActividad
        {
            get { return this.fechaActividad; }
            set { this.fechaActividad = value; }
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public string Observacion
        {
            get { return this.observacion; }
            set { this.observacion = value; }
        }


        #endregion
    }
}
