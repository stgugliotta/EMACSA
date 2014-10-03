using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Agenda
    /// </summary>
    public class Agenda : Entity<Agenda, AgendaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Agenda
        /// </summary>
        public Agenda()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idTarea;
        private string usuario;
        private string tarea;
        private System.DateTime fechaDeAlerta;
        private string estado;
        private string criticidad;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdTarea
        {
            get { return this.idTarea; }
            set { this.idTarea = value; }
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public string Tarea
        {
            get { return this.tarea; }
            set { this.tarea = value; }
        }

        public System.DateTime FechaDeAlerta
        {
            get { return this.fechaDeAlerta; }
            set { this.fechaDeAlerta = value; }
        }

        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string Criticidad
        {
            get { return this.criticidad; }
            set { this.criticidad = value; }
        }



        #endregion
    }
}
