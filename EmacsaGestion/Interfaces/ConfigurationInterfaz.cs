using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public class ConfigurationInterfaz
    {
        public ConfigurationInterfaz()
        {
            interfacesFactura = new List<FacturaInterfaz>();
        }
        public List<FacturaInterfaz> interfacesFactura { get; set; }
    }

    public class FacturaInterfaz
    {
        public FacturaInterfaz()
        {
            clientes = new List<ClienteInterfaz>();
        }

        public String tableName { get; set; }
        public List<ClienteInterfaz> clientes { get; set; }
    }

    public class ClienteInterfaz
    {
        public LineaFactura lineaFactura { get; set; }

        public String id { get; set; }
        public String contentType { get; set; }
        public String parser { get; set; }
        public String sheetName { get; set; }

    }

    public class LineaFactura
    {
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

    public class Property 
    {
        public String name { get; set; }
        public String from { get; set; }
        public String len { get; set; }
        public String defaultValue { get; set; }
        public String col { get; set; }
    }



}
