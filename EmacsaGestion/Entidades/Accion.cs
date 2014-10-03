using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Accion
    /// </summary>
    public class Accion : Entity<Accion, AccionDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Accion
        /// </summary>
        public Accion()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idAccion;
        private string usuario;
        private System.DateTime fechaAccion;
        private int idEstado;
        private string observacion;
        private string informacionComplementaria;
        private int idFactura;
        private int idDeudor;
        private int idCliente;
        private System.DateTime fechaVencimiento;
        private System.DateTime proxima_gestion;
        private int idDomicilioAlternativo;
        private double saldo;
        private double montoImputacion;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdAccion
        {
            get { return this.idAccion; }
            set { this.idAccion = value; }
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public System.DateTime FechaAccion
        {
            get { return this.fechaAccion; }
            set { this.fechaAccion = value; }
        }

        public int IdEstado
        {
            get { return this.idEstado; }
            set { this.idEstado = value; }
        }

        public string Observacion
        {
            get { return this.observacion; }
            set { this.observacion = value; }
        }

        public string InformacionComplementaria
        {
            get { return this.informacionComplementaria; }
            set { this.informacionComplementaria = value; }
        }

        public int IdFactura
        {
            get { return this.idFactura; }
            set { this.idFactura = value; }
        }

        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }


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


        public System.DateTime FechaVencimiento
        {
            get { return this.fechaVencimiento; }
            set { this.fechaVencimiento  = value; }
        }

        public System.DateTime ProximaGestion
        {
            get { return this.proxima_gestion; }
            set { this.proxima_gestion = value; }
        }

        public double Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }
        public double MontoImputacion
        {
            get { return this.montoImputacion; }
            set { this.montoImputacion = value; }
        }
        #endregion
    }
}
