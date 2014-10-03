using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.CFG_Application
    /// </summary>
    public class Configuration : Entity<Configuration, ConfigurationDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Configuration
        /// </summary>
        public Configuration()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private short idConfiguracion;
        private string nombre;
        private string valor;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public short IdConfiguracion
        {
            get { return this.idConfiguracion; }
            set { this.idConfiguracion = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }


        #endregion
    }
}
