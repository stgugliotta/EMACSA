using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-08
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_reporte
    /// Descripcion	: 
    /// </summary>
    public class ReporteDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Reporte
        /// </summary>
        public ReporteDataContracts()
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
        private string nombre;

        /// <summary>
        /// 
        /// </summary>
        private string urlComun;

        /// <summary>
        /// 
        /// </summary>
        private string directorio;

        /// <summary>
        /// 
        /// </summary>
        private string adicional;

        /// <summary>
        /// 
        /// </summary>
        private bool activo;

        /// <summary>
        /// 
        /// </summary>
        private string nombreFisico;

        private string ubicacion;
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
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string UrlComun
        {
            get { return this.urlComun; }
            set { this.urlComun = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Directorio
        {
            get { return this.directorio; }
            set { this.directorio = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Adicional
        {
            get { return this.adicional; }
            set { this.adicional = value; }
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

        /// <summary>
        /// 
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
