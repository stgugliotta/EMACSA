using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Interfaces
{
    public class ConfigurationLoader
    {
        public static string configuracionXML = "";

        public static ConfigurationInterfaz loadConfiguration()
        {
            ConfigurationInterfaz config = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                //myDoc.Load(Server.MapPath("..\\Configuration.xml"));
                //doc.Load("C:\\Users\\Gaby\\Documents\\trabajos\\Emacsa\\gobbi\\Gobbi\\Interfaces\\Configuration.xml");
                try
                {
                    doc.Load(System.IO.Path.GetFullPath(configuracionXML));
                }
                catch (Exception e) {
                    Console.Write(e);
                }
                config = new ConfigurationInterfaz();


                XmlNodeList facturas = doc.DocumentElement.GetElementsByTagName("Factura");
                
                //Recorro las facturas
                foreach (XmlNode node in facturas)
                {
                    FacturaInterfaz factura = new FacturaInterfaz();
                    factura.tableName = node.Attributes.GetNamedItem("tableName").Value;

                    //Recorro los clientes
                    XmlNodeList clientes = node.ChildNodes;
                    foreach (XmlNode nodoCliente in clientes) {

                        ClienteInterfaz cliente = new ClienteInterfaz();
                        LineaFactura lineaFactura = new LineaFactura();
                        cliente.id = nodoCliente.Attributes.GetNamedItem("id").Value;
                        cliente.contentType = nodoCliente.Attributes.GetNamedItem("contentType").Value;
                        cliente.parser = nodoCliente.Attributes.GetNamedItem("parser").Value;
                        if (nodoCliente.Attributes.GetNamedItem("sheetName") != null) {

                            cliente.sheetName = nodoCliente.Attributes.GetNamedItem("sheetName").Value;
                        }
                        cliente.lineaFactura = lineaFactura;

                        // Agrego al tipo de factura / interfaz
                        factura.clientes.Add(cliente);


                        // Recorro las propiedades seteadas para el cliente..
                        XmlNodeList propiedades = nodoCliente.FirstChild.ChildNodes;
                        foreach (XmlNode nodoPropiedad in propiedades) {
                            Property propiedad = new Property();
                            if (nodoPropiedad.Name.Equals("property")) { 

                                propiedad.name = nodoPropiedad.Attributes.GetNamedItem("name").Value;
                                if (nodoPropiedad.Attributes.GetNamedItem("from") != null) {
                                    propiedad.from = nodoPropiedad.Attributes.GetNamedItem("from").Value;
                                }
                                if (nodoPropiedad.Attributes.GetNamedItem("len") != null)
                                {
                                    propiedad.len= nodoPropiedad.Attributes.GetNamedItem("len").Value;
                                }
                                if (nodoPropiedad.Attributes.GetNamedItem("default") != null)
                                {

                                    propiedad.defaultValue = nodoPropiedad.Attributes.GetNamedItem("default").Value;
                                }
                                if (nodoPropiedad.Attributes.GetNamedItem("col") != null)
                                {
                                    propiedad.col = nodoPropiedad.Attributes.GetNamedItem("col").Value;
                                }
                                lineaFactura.propiedades.Add(propiedad);
                            }
                        }
                    }

                    config.interfacesFactura.Add(factura);
                }
            }
            catch (Exception e)
            {
            }

            return config;

        }


    }

}
