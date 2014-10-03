using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.tbl_logCambiosDeEstado
    /// </summary>
    public class LogCambioDeEstado : Entity<LogCambioDeEstado, LogCambioDeEstadoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  LogCambioDeEstado
        /// </summary>
        public LogCambioDeEstado()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private decimal id;
        private long cantRegistrosExportados;
        private long cnatRegistrosMarcados;
        private System.DateTime fechaExportacion;
        private string usuario;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public decimal Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public long CantRegistrosExportados
        {
            get { return this.cantRegistrosExportados; }
            set { this.cantRegistrosExportados = value; }
        }

        public long CnatRegistrosMarcados
        {
            get { return this.cnatRegistrosMarcados; }
            set { this.cnatRegistrosMarcados = value; }
        }

        public System.DateTime FechaExportacion
        {
            get { return this.fechaExportacion; }
            set { this.fechaExportacion = value; }
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }


        #endregion
    }
}
