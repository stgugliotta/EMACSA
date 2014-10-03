using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    public class Remision : Entity<Remision, RemisionDataContracts>
    {

        public Remision()
        { }

        private double _cambio;
        private double _compensacion = 0;

        public double Cambio
        {
            get { return this._cambio; }
            set { this._cambio = value; }
        }

        private string _estado;
        
        public string Estado { get; set; }

        private int _numeroRemision;
        public int NumeroRemision
        {
            get { return _numeroRemision; }
            set { _numeroRemision = value; }
        }
        private List<Recibo> _listaDeRecibos;

        public List<Recibo> ListaDeRecibos
        {
            get { return _listaDeRecibos; }
            set { _listaDeRecibos = value; }
        }
        private List<Pago> _listaDePagos;

        public List<Pago> ListaDePagos
        {
            get { return _listaDePagos; }
            set { _listaDePagos = value; }
        }
        private DateTime _fechaDeCreacion;

        public DateTime FechaDeCreacion
        {
            get { return _fechaDeCreacion; }
            set { _fechaDeCreacion = value; }
        }
        private Analista _analistaGenerador;

        public Analista AnalistaGenerador
        {
            get { return _analistaGenerador; }
            set { _analistaGenerador = value; }
        }
        private int _idCliente;

        public int IDCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public double Compensacion
        {
            get { return _compensacion; }
            set { _compensacion = value; }
        }

        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
    }
}
