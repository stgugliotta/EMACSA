using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts
{
    public class ReciboDataContracts
    {

        private int _id;

        private string _numero;

        private CobradorDataContracts cobrador;

        private DeudorDataContracts _deudor;

        private ClienteDataContracts _cliente;

        private List<ReciboFacturaDataContracts> _listadoDeFacturasACancelar;

        private List<PagoDataContracts > _listadoDePagosIngresados;

        private string _nsap;
        
        public List<PagoDataContracts > ListadoDePagosIngresados { get; set; }


        private bool usadoRemision;


        public  ReciboDataContracts()
        {
            


        }

        public ReciboDataContracts(string numRecibo)
        {

            this._numero = numRecibo;

        }

        public ReciboDataContracts(string numRecibo,ClienteDataContracts  cliente)
        {

            this._numero = numRecibo;
            this._cliente = cliente;

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

     

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
   

        public CobradorDataContracts Cobrador
        {
            get { return cobrador; }
            set { cobrador = value; }
        }

        

        public DeudorDataContracts Deudor
        {
            get { return _deudor; }
            set { _deudor = value; }
        }

        

        public ClienteDataContracts Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        

        public List<ReciboFacturaDataContracts> ListadoDeFacturasACancelar
        {
            get { return _listadoDeFacturasACancelar; }
            set { _listadoDeFacturasACancelar = value; }
        }



        public DateTime FechaCarga { get; set; }

        public string SAP
        {
            get { return this._nsap; }
            set { this._nsap = value; }
        }

        public CompensacionDePagoDataContracts CompensacionDePago { get; set; }

        public double TipoDeCambio { get; set; }
        /// <summary>
        /// UsadoRemision / No UsadoRemision
        /// </summary>
        /// <value>bool</value>
        public bool UsadoRemision
        {
            get { return this.usadoRemision; }
            set { this.usadoRemision = value; }
        }


        public string NombreCobrador {
            get { return this.cobrador.NombreApellido; }
        }

        public string NombreCliente
        {
            get { return this.Cliente.NOMBRE; }
        }

        public string UsadoRemisionSiNo {
            get {
                if (this.usadoRemision) { return "Sí"; } else { return "No"; }
            }

        }


    }
}
