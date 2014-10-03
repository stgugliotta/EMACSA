using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-06-12
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_control_concurrencia_remision
    /// Descripcion	: 
    /// </summary>
    public class ControlRemisionConcurrenciaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto ControlRemisionConcurrencia
        /// </summary>
        public ControlRemisionConcurrenciaDataContracts()
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
        private string numRemision;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaInicioLock;

        /// <summary>
        /// 
        /// </summary>
        private string usuarioLock;

        /// <summary>
        /// 
        /// </summary>
        private string estadoLock;

        /// <summary>
        /// 
        /// </summary>
        private bool forceUnlock;

        /// <summary>
        /// 
        /// </summary>
        private string usuarioForceUnlock;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaForceUnlock;

        /// <summary>
        /// 
        /// </summary>
        private string datoBloqueado;

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
        /// <value>string</value>
        public string NumRemision
        {
            get { return this.numRemision; }
            set { this.numRemision = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaInicioLock
        {
            get { return this.fechaInicioLock; }
            set { this.fechaInicioLock = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string UsuarioLock
        {
            get { return this.usuarioLock; }
            set { this.usuarioLock = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string EstadoLock
        {
            get { return this.estadoLock; }
            set { this.estadoLock = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>bool</value>
        public bool ForceUnlock
        {
            get { return this.forceUnlock; }
            set { this.forceUnlock = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string UsuarioForceUnlock
        {
            get { return this.usuarioForceUnlock; }
            set { this.usuarioForceUnlock = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaForceUnlock
        {
            get { return this.fechaForceUnlock; }
            set { this.fechaForceUnlock = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string DatoBloqueado
        {
            get { return this.datoBloqueado; }
            set { this.datoBloqueado = value; }
        }

        #endregion
    }
}
