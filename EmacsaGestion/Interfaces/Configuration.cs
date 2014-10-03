using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class Configuration
    {
        public Configuration() {
            interfacesFactura = new List<Factura>();
        }
        public List<Factura> interfacesFactura { get; set; }
    }

    class Factura
    {
        public Factura() {
            clientes = new List<Cliente>();
        }

        public String tableName { get; set; }
        public List<Cliente> clientes { get; set; }
    }

    class Cliente
    {
        public LineaFactura lineaFactura { get; set; }

        public String id { get; set; }
        public String contentType { get; set; }
        public String parser { get; set; }
        public String sheetName { get; set; }

    }

    class LineaFactura {
        public LineaFactura() {
            propiedades = new List<Property>();
        }
        public List<Property> propiedades { get; set; }

        public Property findPropertyByName(String name) {

            foreach (Property p in propiedades) {

                if (p.name.Equals(name)) {
                    return p;
                }
            }

            return null;
        }
    }
    
    class Property 
    {
        public String name { get; set; }
        public String from { get; set; }
        public String len { get; set; }
        public String defaultValue { get; set; }
        public String col { get; set; }
    }



}
