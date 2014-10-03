using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2009-12-31
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_deudor
    /// Descripcion	: 
    /// </summary>
    public class DeudorDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Deudor
        /// </summary>
        public DeudorDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idDeudor;

        /// <summary>
        /// 
        /// </summary>
        private string nombre;

        /// <summary>
        /// 
        /// </summary>
        private string apellido;

        /// <summary>
        /// 
        /// </summary>
        private string domicilio;

        /// <summary>
        /// 
        /// </summary>
        private string localidad;

        /// <summary>
        /// 
        /// </summary>
        private string provincia;

        /// <summary>
        /// 
        /// </summary>
        private string cp;

        /// <summary>
        /// 
        /// </summary>
        private string telefono;

        /// <summary>
        /// 
        /// </summary>
        private string fax;

        /// <summary>
        /// 
        /// </summary>
        private string email;

        /// <summary>
        /// 
        /// </summary>
        private string codigoZona;

        /// <summary>
        /// 
        /// </summary>
        private string mapa;

        /// <summary>
        /// 
        /// </summary>
        private int sucursal;

        /// <summary>
        /// 
        /// </summary>
        private int anticipoGestion;

        /// <summary>
        /// 
        /// </summary>
        private string cuit;

        /// <summary>
        /// 
        /// </summary>
        private string tODOS;

        /// <summary>
        /// 
        /// </summary>
        private string zona;

        /// <summary>
        /// 
        /// </summary>
        private string zonaCobro;

        /// <summary>
        /// 
        /// </summary>
        private string tipo;

        /// <summary>
        /// 
        /// </summary>
        private string alfaNumDelCliente;

        private string telefono_aux;

        private System.DateTime fecha_reclamo;

        private DomicilioDeudorDataContracts domicilioDeudor;

        private string cliente;


        private int _idDomicilioDeudor;
        #endregion

        #region P U B L I C  P R O P E R T I E S
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
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Domicilio
        {
            get { return this.domicilio; }
            set { this.domicilio = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Localidad
        {
            get { return this.localidad; }
            set { this.localidad = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Provincia
        {
            get { return this.provincia; }
            set { this.provincia = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Cp
        {
            get { return this.cp; }
            set { this.cp = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string CodigoZona
        {
            get { return this.codigoZona; }
            set { this.codigoZona = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Mapa
        {
            get { return this.mapa; }
            set { this.mapa = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>byte</value>
        public int Sucursal
        {
            get { return this.sucursal; }
            set { this.sucursal = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int AnticipoGestion
        {
            get { return this.anticipoGestion; }
            set { this.anticipoGestion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Cuit
        {
            get { return this.cuit; }
            set { this.cuit = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string TODOS
        {
            get { return this.tODOS; }
            set { this.tODOS = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Zona
        {
            get { return this.zona; }
            set { this.zona = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string ZonaCobro
        {
            get { return this.zonaCobro; }
            set { this.zonaCobro = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string AlfaNumDelCliente
        {
            get { return this.alfaNumDelCliente; }
            set { this.alfaNumDelCliente = value; }
        }

        public string Telefono_Aux
        {
            get { return this.telefono_aux; }
            set { this.telefono_aux = value; }
        }

        public System.DateTime FechaReclamo
        {
            get { return this.fecha_reclamo; }
            set { this.fecha_reclamo = value; }
        }


        public DomicilioDeudorDataContracts Domicilio_Deudor
        {
            get { return this.domicilioDeudor; }
            set { this.domicilioDeudor = value; }
        }

        public string Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }

        }

        public int IdDomicilioDeudor
        {
            get { return _idDomicilioDeudor; }
            set { _idDomicilioDeudor = value; }
        }

        #endregion
    }
}
