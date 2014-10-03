using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class FacturaDTO
    {
        public int idCliente { get; set; }
        public String idDeudor { get; set; }
        public String idTipoComprobante { get; set; }
        public String letra { get; set; }
        public String emision { get; set; }
        public short numeroPag { get; set; }
        public short cantidadP { get; set; }
        public String nroComprobante { get; set; }
        public double importe { get; set; }
        public double saldo { get; set; }
        public double importeMonedaLocal { get; set; }
        public String idMoneda { get; set; }
        public System.DateTime fechaEmision { get; set; }
        public System.DateTime fechaVencimiento { get; set; }
        public String observaciones { get; set; }
        public String estado { get; set; }
    }
}
