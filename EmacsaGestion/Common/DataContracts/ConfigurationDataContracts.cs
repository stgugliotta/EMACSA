using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-01-13
    /// Objeto		: GOBBI_NUCLEO.dbo.cfg_application
    /// Descripcion	: 
    /// </summary>
    public class ConfigurationDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Configuration
        /// </summary>
        public ConfigurationDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private short idConfiguracion;

        /// <summary>
        /// 
        /// </summary>
        private string nombre;

        /// <summary>
        /// 
        /// </summary>
        private string valor;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>short</value>
        public short IdConfiguracion
        {
            get { return this.idConfiguracion; }
            set { this.idConfiguracion = value; }
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
        public string Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        #endregion
    }
}
