using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Control_Concurrencia_Remision
    /// </summary>
    public class ControlRemisionConcurrencia : Entity<ControlRemisionConcurrencia, ControlRemisionConcurrenciaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  ControlRemisionConcurrencia
        /// </summary>
        public ControlRemisionConcurrencia()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int id;
        private string numRemision;
        private System.DateTime fechaInicioLock;
        private string usuarioLock;
        private string estadoLock;
        private bool forceUnlock;
        private string usuarioForceUnlock;
        private System.DateTime fechaForceUnlock;
        private string datoBloqueado;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string NumRemision
        {
            get { return this.numRemision; }
            set { this.numRemision = value; }
        }

        public System.DateTime FechaInicioLock
        {
            get { return this.fechaInicioLock; }
            set { this.fechaInicioLock = value; }
        }

        public string UsuarioLock
        {
            get { return this.usuarioLock; }
            set { this.usuarioLock = value; }
        }

        public string EstadoLock
        {
            get { return this.estadoLock; }
            set { this.estadoLock = value; }
        }

        public bool ForceUnlock
        {
            get { return this.forceUnlock; }
            set { this.forceUnlock = value; }
        }

        public string UsuarioForceUnlock
        {
            get { return this.usuarioForceUnlock; }
            set { this.usuarioForceUnlock = value; }
        }

        public System.DateTime FechaForceUnlock
        {
            get { return this.fechaForceUnlock; }
            set { this.fechaForceUnlock = value; }
        }

        public string DatoBloqueado
        {
            get { return this.datoBloqueado; }
            set { this.datoBloqueado = value; }
        }


        #endregion
    }
}
