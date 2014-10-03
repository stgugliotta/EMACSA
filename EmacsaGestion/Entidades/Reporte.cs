using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.tbl_cfg_Reporte
    /// </summary>
    public class Reporte : Entity<Reporte, ReporteDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Reporte
        /// </summary>
        public Reporte()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private short id;
        private string nombre;
        private string urlComun;
        private string directorio;
        private string adicional;
        private bool activo;
        private string nombreFisico;
        private string ubicacion;

        #endregion

        #region P U B L I C    P R O P E R T I E S
        /// <summary>
        /// Identificador único del reporte
        /// </summary>
        /// <value>short</value>
        public short Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Nombre del reporte
        /// </summary>
        /// <value>string</value>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Url al cual se ejecuta el reporte
        /// </summary>
        /// <value>string</value>
        public string UrlComun
        {
            get { return this.urlComun; }
            set { this.urlComun = value; }
        }

        /// <summary>
        /// Directorio donde esta el reporte
        /// </summary>
        /// <value>string</value>
        public string Directorio
        {
            get { return this.directorio; }
            set { this.directorio = value; }
        }

        /// <summary>
        ///  Datos Adicionales
        /// </summary>
        /// <value>string</value>
        public string Adicional
        {
            get { return this.adicional; }
            set { this.adicional = value; }
        }

        /// <summary>
        /// Activo / Inactivo
        /// </summary>
        /// <value>bool</value>
        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Nombre físico del reporte
        /// </summary>
        /// <value>string</value>
        public string NombreFisico
        {
            get { return this.nombreFisico; }
            set { this.nombreFisico = value; }
        }

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        #endregion
    }
}