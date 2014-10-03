using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2009-12-19
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_cliente
    /// Descripcion	: 
    /// </summary>
    public class ClienteDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Cliente
        /// </summary>
        public ClienteDataContracts()
        {
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
        private string cALLE;

        /// <summary>
        /// 
        /// </summary>
        private double aLTURA;

        /// <summary>
        /// 
        /// </summary>
        private string dEPARTAMENTO;

        /// <summary>
        /// 
        /// </summary>
        private string lOCALIDAD;

        /// <summary>
        /// 
        /// </summary>
        private double cp;

        /// <summary>
        /// 
        /// </summary>
        private string pROVINCIA;

        /// <summary>
        /// 
        /// </summary>
        private string tELEFONOS;

        /// <summary>
        /// 
        /// </summary>
        private string fAX;

        /// <summary>
        /// 
        /// </summary>
        private string eMAIL;

        /// <summary>
        /// 
        /// </summary>
        private string nOMBRECORTO;

        /// <summary>
        /// 
        /// </summary>
        private string monedaCredito;

        /// <summary>
        /// 
        /// </summary>
        private string oBSERVACIONES;

        /// <summary>
        /// 
        /// </summary>
        private string sOLOGESTION;

        /// <summary>
        /// 
        /// </summary>
        private string aCTIVO;

        /// <summary>
        /// 
        /// </summary>
        private string gruRec;

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
        public string CALLE
        {
            get { return this.cALLE; }
            set { this.cALLE = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double ALTURA
        {
            get { return this.aLTURA; }
            set { this.aLTURA = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string DEPARTAMENTO
        {
            get { return this.dEPARTAMENTO; }
            set { this.dEPARTAMENTO = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string LOCALIDAD
        {
            get { return this.lOCALIDAD; }
            set { this.lOCALIDAD = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double CP
        {
            get { return this.cp; }
            set { this.cp = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string PROVINCIA
        {
            get { return this.pROVINCIA; }
            set { this.pROVINCIA = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string TELEFONOS
        {
            get { return this.tELEFONOS; }
            set { this.tELEFONOS = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string FAX
        {
            get { return this.fAX; }
            set { this.fAX = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string EMAIL
        {
            get { return this.eMAIL; }
            set { this.eMAIL = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string NOMBRECORTO
        {
            get { return this.nOMBRECORTO; }
            set { this.nOMBRECORTO = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string MonedaCredito
        {
            get { return this.monedaCredito; }
            set { this.monedaCredito = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string OBSERVACIONES
        {
            get { return this.oBSERVACIONES; }
            set { this.oBSERVACIONES = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string SOLOGESTION
        {
            get { return this.sOLOGESTION; }
            set { this.sOLOGESTION = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string ACTIVO
        {
            get { return this.aCTIVO; }
            set { this.aCTIVO = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string GruRec
        {
            get { return this.gruRec; }
            set { this.gruRec = value; }
        }

        #endregion
    }
}
