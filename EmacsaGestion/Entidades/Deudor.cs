using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.MTR_Deudor
    /// </summary>
    public class Deudor : Entity<Deudor, DeudorDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Deudor
        /// </summary>
        public Deudor()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idDeudor;
        private string nombre;
        private string apellido;
        private string domicilio;
        private string localidad;
        private string provincia;
        private string cp;
        private string telefono;
        private string fax;
        private string email;
        private string codigoZona;
        private string mapa;
        private int sucursal;
        private int anticipoGestion;
        private string cuit;
        private string tODOS;
        private string zona;
        private string zonaCobro;
        private string tipo;
        private string alfaNumDelCliente;
        private string telefono_aux;
        private System.DateTime fecha_reclamo;
        private DomicilioDeudor domicilioDeudor;
        private string cliente;
        private int idDomicilioDeudor;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public string Domicilio
        {
            get { return this.domicilio; }
            set { this.domicilio = value; }
        }

        public string Localidad
        {
            get { return this.localidad; }
            set { this.localidad = value; }
        }

        public string Provincia
        {
            get { return this.provincia; }
            set { this.provincia = value; }
        }

        public string Cp
        {
            get { return this.cp; }
            set { this.cp = value; }
        }

        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string CodigoZona
        {
            get { return this.codigoZona; }
            set { this.codigoZona = value; }
        }

        public string Mapa
        {
            get { return this.mapa; }
            set { this.mapa = value; }
        }

        public int Sucursal
        {
            get { return this.sucursal; }
            set { this.sucursal = value; }
        }



        public int AnticipoGestion
        {
            get { return this.anticipoGestion; }
            set { this.anticipoGestion = value; }
        }

        public string Cuit
        {
            get { return this.cuit; }
            set { this.cuit = value; }
        }

        public string TODOS
        {
            get { return this.tODOS; }
            set { this.tODOS = value; }
        }

        public string Zona
        {
            get { return this.zona; }
            set { this.zona = value; }
        }

        public string ZonaCobro
        {
            get { return this.zonaCobro; }
            set { this.zonaCobro = value; }
        }

        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

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
        
        public DomicilioDeudor Domicilio_Deudor
        {
            get { return this.domicilioDeudor; }
            set { this.domicilioDeudor = value; }
        }

        public string Cliente
        {
            get { return this.cliente ; }
            set { this.cliente  = value; }
        }

        public int IdDomicilioDeudor
        {
            get { return idDomicilioDeudor; }
            set { idDomicilioDeudor = value; }
        }

        #endregion
    }
}
