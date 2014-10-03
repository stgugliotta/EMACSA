using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_agenda
    /// Descripcion	: 
    /// </summary>
    public class AgendaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Agenda
        /// </summary>
        public AgendaDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idTarea;

        /// <summary>
        /// 
        /// </summary>
        private string usuario;

        /// <summary>
        /// 
        /// </summary>
        private string tarea;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaDeAlerta;

        /// <summary>
        /// 
        /// </summary>
        private string estado;

        /// <summary>
        /// 
        /// </summary>
        private string criticidad;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdTarea
        {
            get { return this.idTarea; }
            set { this.idTarea = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Tarea
        {
            get { return this.tarea; }
            set { this.tarea = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaDeAlerta
        {
            get { return this.fechaDeAlerta; }
            set { this.fechaDeAlerta = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Criticidad
        {
            get { return this.criticidad; }
            set { this.criticidad = value; }
        }

        #endregion
    }
}
