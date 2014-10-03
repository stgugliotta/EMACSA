using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_accion
    /// Descripcion	: 
    /// </summary>
    public class AccionDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Accion
        /// </summary>
        public AccionDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idAccion;

        /// <summary>
        /// 
        /// </summary>
        private string usuario;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaAccion;

        /// <summary>
        /// 
        /// </summary>
        private int idEstado;

        /// <summary>
        /// 
        /// </summary>
        private string observacion;

        /// <summary>
        /// 
        /// </summary>
        private string informacionComplementaria;

        /// <summary>
        /// 
        /// </summary>
        private int idFactura;

        /// <summary>
        /// 
        /// </summary>
        private int idDeudor;


        /// <summary>
        /// 
        /// </summary>
        private int idCliente;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaVencimiento;
        private System.DateTime proxima_gestion;
        private int idDomicilioAlternativo;
        private double saldo;
        private double montoImputacion;
        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdAccion
        {
            get { return this.idAccion; }
            set { this.idAccion = value; }
        }
        public double Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
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
        /// <value>System.DateTime</value>
        public System.DateTime FechaAccion
        {
            get { return this.fechaAccion; }
            set { this.fechaAccion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdEstado
        {
            get { return this.idEstado; }
            set { this.idEstado = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Observacion
        {
            get { return this.observacion; }
            set { this.observacion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string InformacionComplementaria
        {
            get { return this.informacionComplementaria; }
            set { this.informacionComplementaria = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdFactura
        {
            get { return this.idFactura; }
            set { this.idFactura = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        public int IdDomicilioAlternativo
        {
            get { return this.idDomicilioAlternativo; }
            set { this.idDomicilioAlternativo = value; }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaVencimiento
        {
            get { return this.fechaVencimiento; }
            set { this.fechaVencimiento = value; }
        }

        public System.DateTime ProximaGestion
        {
            get { return this.proxima_gestion; }
            set { this.proxima_gestion = value; }
        }

        public double MontoImputacion
        {
            get { return this.montoImputacion; }
            set { this.montoImputacion = value; }
        }

        #endregion

    }
}
