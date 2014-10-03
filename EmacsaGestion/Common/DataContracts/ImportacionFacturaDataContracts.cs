using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2009-12-19
    /// Objeto		: EMACSA_NUCLEO.dbo.?
    /// Descripcion	: 
    /// </summary>
    public class ImportacionFacturaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Cliente
        /// </summary>
        public ImportacionFacturaDataContracts()
        {
        }

        public ImportacionFacturaDataContracts(decimal idCli, string nom, string cui, string arch, string est) {
            this.idCliente = idCli;
            this.NOMBRE = nom;
            this.CUIT = cui;
            this.ARCHIVO = arch;
            this.ESTADO = est;
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private decimal idCliente;

        /// <summary>
        /// 
        /// </summary>
        private string nOMBRE;

        /// <summary>
        /// 
        /// </summary>
        private string cUIT;

        /// <summary>
        /// 
        /// </summary>
        private string aRCHIVO;

        /// <summary>
        /// 
        /// </summary>
        private string eSTADO;

        private string registrosEnviados;
        private string registrosIngresados;
        private string insersionModificacion;
        private string registrosRechazados;
        private string documentosBaja;
        private DateTime fechaProceso;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>decimal</value>
        public decimal IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string NOMBRE
        {
            get { return this.nOMBRE; }
            set { this.nOMBRE = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string CUIT
        {
            get { return this.cUIT; }
            set { this.cUIT = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string ARCHIVO
        {
            get { return this.aRCHIVO; }
            set { this.aRCHIVO = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string ESTADO
        {
            get { return this.eSTADO; }
            set { this.eSTADO = value; }
        }


        public string RegistrosEnviados
        {
            get;
            set;
        }

        public string RegistrosIngresados { get; set; }
        public string InsersionModificacion { get; set; }
        public string RegistrosRechazados { get; set; }
        public string DocumentosBaja { get; set; }
        public string RegistrosActualizados { get; set; }
        public string RegistrosExistentes { get; set; }
        public DateTime FechaProceso { get; set; }

        #endregion
    }
}
