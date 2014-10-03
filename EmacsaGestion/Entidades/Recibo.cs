using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    public class Recibo : Entity<Recibo, ReciboDataContracts>
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

     

        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private Cobrador cobrador;

        public Cobrador Cobrador
        {
            get { return cobrador; }
            set { cobrador = value; }
        }

        private Deudor _deudor;

        public Deudor Deudor
        {
            get { return _deudor; }
            set { _deudor = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private List<ReciboFactura> _listadoDeFacturasACancelar;

        public List<ReciboFactura> ListadoDeFacturasACancelar
        {
            get { return _listadoDeFacturasACancelar; }
            set { _listadoDeFacturasACancelar = value; }
        }

        private List<Pago> _listadoDePagosIngresados;
        public List<Pago> ListadoDePagosIngresados { get; set; }


        public DateTime  FechaCarga { get; set; }

        private string _nsap;
        public string SAP
        {
            get { return this._nsap; }
            set { this._nsap = value; }
        }



        public double TipoDeCambio { get; set; }


        public CompensacionDePago CompensacionDePago { get; set; }


        private bool usadoRemision;

        /// <summary>
        /// UsadoRemision / No UsadoRemision
        /// </summary>
        /// <value>bool</value>
        public bool UsadoRemision
        {
            get { return this.usadoRemision; }
            set { this.usadoRemision = value; }
        }
    }
}
