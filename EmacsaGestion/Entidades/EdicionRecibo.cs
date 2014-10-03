using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.DatosEdicionRecibo
    /// </summary>
    public class DatosEdicionRecibo : Entity<DatosEdicionRecibo, DatosEdicionReciboDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  DatosEdicionRecibo
        /// </summary>
        public DatosEdicionRecibo()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private System.DateTime fechaCreacion;
        private int idRemision;
        private string usuarioCreador;
        private string estado;
        private int idRecibo;
        private string numRecibo;
        private string nSap;
        private double tipoDeCambio;
        private bool usadoRemision;
        private int idDeudor;
        private string nombreDeudor;
        private int idCliente;
        private string nombreCliente;
        private string cuitCliente;

        #endregion

        #region P U B L I C    P R O P E R T I E S
        public System.DateTime FechaCreacion
        {
            get { return this.fechaCreacion; }
            set { this.fechaCreacion = value; }
        }

        public int IdRemision
        {
            get { return this.idRemision; }
            set { this.idRemision = value; }
        }

        public string UsuarioCreador
        {
            get { return this.usuarioCreador; }
            set { this.usuarioCreador = value; }
        }

        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public int IdRecibo
        {
            get { return this.idRecibo; }
            set { this.idRecibo = value; }
        }

        public string NumRecibo
        {
            get { return this.numRecibo; }
            set { this.numRecibo = value; }
        }

        public string NSap
        {
            get { return this.nSap; }
            set { this.nSap = value; }
        }

        public double TipoDeCambio
        {
            get { return this.tipoDeCambio; }
            set { this.tipoDeCambio = value; }
        }

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
