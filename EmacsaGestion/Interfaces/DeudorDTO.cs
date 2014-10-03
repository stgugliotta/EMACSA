using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class DeudorDTO
    {
        public int idCliente { get; set; }
        public String alfaNumericoCliente { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String cuit { get; set; }
        public String domicilioCalle { get; set; }
        public int domicilioAltura { get; set; }
        public String localidad { get; set; }
        public String departamento { get; set; }
        public String provincia { get; set; }
        public String cp { get; set; }
        public long latitud { get; set; }
        public long longitud { get; set; }
        public String telefono { get; set; }
        public String telefonoAuxiliar { get; set; }
        public String telefonoFax { get; set; }
        public String emails { get; set; }
        public short anticipoGestion { get; set; }
        public int piso { get; set; }
        public string depto { get; set; }
        public String error { get; set; } 
    }
}
