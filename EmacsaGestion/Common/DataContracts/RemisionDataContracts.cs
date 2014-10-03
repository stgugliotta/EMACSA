using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts
{
    public class RemisionDataContracts
    {

        public RemisionDataContracts()
        { }


        private string _estado;
        private double _compensacion=0;
        private string cliente;

        public string Estado { get { return this._estado; } set { this._estado = value; } }

        private double _cambio;
        public double Cambio
        {
            get { return this._cambio; }
            set { this._cambio = value; }
        }


        private int _numeroRemision;


        public int NumeroRemision
        {
            get { return _numeroRemision; }
            set { _numeroRemision = value; }
        }
        private List<ReciboDataContracts> _listaDeRecibos;

        public  List<ReciboDataContracts> ListaDeRecibos
        {
            get { return _listaDeRecibos; }
            set { _listaDeRecibos = value; }
        }
        private List<PagoDataContracts > _listaDePagos;

        public List<PagoDataContracts > ListaDePagos
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
        private AnalistaDataContracts _analistaGenerador;

        public AnalistaDataContracts AnalistaGenerador
        {
            get { return _analistaGenerador; }
            set { _analistaGenerador = value; }
        }

        public string AnalistaGeneradorName
        {
            get { return _analistaGenerador.Nombre ; }
            set { _analistaGenerador.Nombre  = value; }
        }

        private int _idCliente;

        public int IDCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public double Compensacion
        {
            get { return _compensacion; }
            set { _compensacion = value; }
        }
    }
}