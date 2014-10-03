using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts
{
    public class DeudorHojaDeRutaDataContracts
    {
        private string nroItem;
        private string idCliente;
        private string cliente;
        private string idDeudor;
        private string deudor;
        private string domicilio;
        private string localidad;
        private string provincia;
        private string cp;
        private string horario;
        private short idEstadoHoja;
        private string observaciones;
        private string observacionesHistoria;
        private bool ingresada;
        private string alfaNumDelCliente;
        private string observacionParaCobrador;
        
        /// </summary>
        private int idCobrador;
        private string cobrador;

        private bool tieneObservacionesHistoria;
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdCobrador
        {
            get { return this.idCobrador; }
            set { this.idCobrador = value; }
        }

        public string Cobrador
        {
            get { return this.cobrador; }
            set { this.cobrador = value; }
        }
        public string ObservacionParaCobrador
        {
            get { return this.observacionParaCobrador; }
            set { this.observacionParaCobrador = value; }
        }


        public string IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }
        public string Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }

        public string IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }


        public string Deudor
        {
            get { return this.deudor; }
            set { this.deudor = value; }
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

        public string Horario
        {
            get { return this.horario; }
            set { this.horario = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>short</value>
        public short IdEstadoHoja
        {
            get { return this.idEstadoHoja; }
            set { this.idEstadoHoja = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string ObservacionesHistoria
        {
            get { return this.observacionesHistoria; }
            set { this.observacionesHistoria = value; }
        }

        public string AlfaNumDelCliente
        {
            get { return this.alfaNumDelCliente; }
            set { this.alfaNumDelCliente = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>bool</value>
        public bool Ingresada
        {
            get { return this.ingresada; }
            set { this.ingresada = value; }
        }


        public bool TieneObservacionesHistoria
        {
            get { return this.tieneObservacionesHistoria; }
            set { this.tieneObservacionesHistoria = value; }
        }

        /// <value>string</value>
        public string NroItem
        {
            get { return this.nroItem; }
            set { this.nroItem = value; }
        }

    }
}



