using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_Cliente
    /// </summary>
    public class Cliente : Entity<Cliente, ClienteDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Cliente
        /// </summary>
        public Cliente()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private decimal idCliente;
        private string nOMBRE;
        private string cUIT;
        private string cALLE;
        private double aLTURA;
        private string dEPARTAMENTO;
        private string lOCALIDAD;
        private double cp;
        private string pROVINCIA;
        private string tELEFONOS;
        private string fAX;
        private string eMAIL;
        private string nOMBRECORTO;
        private string monedaCredito;
        private string oBSERVACIONES;
        private string sOLOGESTION;
        private string aCTIVO;
        private string gruRec;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public decimal IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        public string NOMBRE
        {
            get { return this.nOMBRE; }
            set { this.nOMBRE = value; }
        }

        public string CUIT
        {
            get { return this.cUIT; }
            set { this.cUIT = value; }
        }

        public string CALLE
        {
            get { return this.cALLE; }
            set { this.cALLE = value; }
        }

        public double ALTURA
        {
            get { return this.aLTURA; }
            set { this.aLTURA = value; }
        }

        public string DEPARTAMENTO
        {
            get { return this.dEPARTAMENTO; }
            set { this.dEPARTAMENTO = value; }
        }

        public string LOCALIDAD
        {
            get { return this.lOCALIDAD; }
            set { this.lOCALIDAD = value; }
        }

        public double CP
        {
            get { return this.cp; }
            set { this.cp = value; }
        }

        public string PROVINCIA
        {
            get { return this.pROVINCIA; }
            set { this.pROVINCIA = value; }
        }

        public string TELEFONOS
        {
            get { return this.tELEFONOS; }
            set { this.tELEFONOS = value; }
        }

        public string FAX
        {
            get { return this.fAX; }
            set { this.fAX = value; }
        }

        public string EMAIL
        {
            get { return this.eMAIL; }
            set { this.eMAIL = value; }
        }

        public string NOMBRECORTO
        {
            get { return this.nOMBRECORTO; }
            set { this.nOMBRECORTO = value; }
        }

        public string MonedaCredito
        {
            get { return this.monedaCredito; }
            set { this.monedaCredito = value; }
        }

        public string OBSERVACIONES
        {
            get { return this.oBSERVACIONES; }
            set { this.oBSERVACIONES = value; }
        }

        public string SOLOGESTION
        {
            get { return this.sOLOGESTION; }
            set { this.sOLOGESTION = value; }
        }

        public string ACTIVO
        {
            get { return this.aCTIVO; }
            set { this.aCTIVO = value; }
        }

        public string GruRec
        {
            get { return this.gruRec; }
            set { this.gruRec = value; }
        }


        #endregion
    }
}
