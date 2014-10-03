using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2011-03-25
    /// Objeto		: EMACSA_NUCLEO.dbo.datosedicionrecibo
    /// Descripcion	: 
    /// </summary>
    public class DatosEdicionReciboDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto DatosEdicionRecibo
        /// </summary>
        public DatosEdicionReciboDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaCreacion;

        /// <summary>
        /// 
        /// </summary>
        private int idRemision;

        /// <summary>
        /// 
        /// </summary>
        private string usuarioCreador;

        /// <summary>
        /// 
        /// </summary>
        private string estado;

        /// <summary>
        /// 
        /// </summary>
        private int idRecibo;

        /// <summary>
        /// 
        /// </summary>
        private string numRecibo;

        /// <summary>
        /// 
        /// </summary>
        private string nSap;

        /// <summary>
        /// 
        /// </summary>
        private double tipoDeCambio;

        /// <summary>
        /// 
        /// </summary>
        private bool usadoRemision;

        private int idDeudor;
        private string nombreDeudor;
        private int idCliente;
        private string nombreCliente;
        private string cuitCliente;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaCreacion
        {
            get { return this.fechaCreacion; }
            set { this.fechaCreacion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdRemision
        {
            get { return this.idRemision; }
            set { this.idRemision = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string UsuarioCreador
        {
            get { return this.usuarioCreador; }
            set { this.usuarioCreador = value; }
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
        /// <value>int</value>
        public int IdRecibo
        {
            get { return this.idRecibo; }
            set { this.idRecibo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string NumRecibo
        {
            get { return this.numRecibo; }
            set { this.numRecibo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string NSap
        {
            get { return this.nSap; }
            set { this.nSap = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>double</value>
        public double TipoDeCambio
        {
            get { return this.tipoDeCambio; }
            set { this.tipoDeCambio = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>bool</value>
        public bool UsadoRemision
        {
            get { return this.usadoRemision; }
            set { this.usadoRemision = value; }
        }

        public int IdDeudor
        {
            get { return idDeudor; }
            set { idDeudor = value; }
        }

        public string NombreDeudor
        {
            get { return nombreDeudor; }
            set { nombreDeudor = value; }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }

        public string CuitCliente
        {
            get { return cuitCliente; }
            set { cuitCliente = value; }
        }

        #endregion
    }
}
