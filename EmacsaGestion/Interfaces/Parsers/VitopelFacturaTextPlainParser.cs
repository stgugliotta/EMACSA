using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace Interfaces.Parsers
{

    abstract class VitopelFacturaTextPlainParser : Parser
    {
        protected CultureInfo cultureEsAR = new CultureInfo("es-AR");
        protected string idDeudorActual = null;

        public virtual double getImporte(Property importe, string input)
        {
            return Double.Parse(input.Substring(Int16.Parse(importe.from), Int16.Parse(importe.len)).Replace('.', ','));
        }

        public override List<FacturaDTO> parse(String fileFullName, ClienteInterfaz cliente)
        {

            LineaFactura lineaFactura = cliente.lineaFactura;
            StreamReader re = File.OpenText(fileFullName);

            List<FacturaDTO> listaFacturasDTO = new List<FacturaDTO>();
            string input = null;
            FacturaDTO facturaDTO = null;

            Property id_deudor = lineaFactura.findPropertyByName("id_deudor");
            Property id_tipo_comprobante = lineaFactura.findPropertyByName("id_tipo_comprobante");
            Property letra = lineaFactura.findPropertyByName("letra");
            Property emision = lineaFactura.findPropertyByName("emision");
            Property nro_comprobante = lineaFactura.findPropertyByName("nro_comprobante");
            Property importe = lineaFactura.findPropertyByName("importe");
            Property saldo = lineaFactura.findPropertyByName("saldo");
            Property importe_moneda_local = lineaFactura.findPropertyByName("importe_moneda_local");
            Property id_moneda = lineaFactura.findPropertyByName("id_moneda");
            Property fecha_emision = lineaFactura.findPropertyByName("fecha_emision");
            Property fecha_vencimiento = lineaFactura.findPropertyByName("fecha_vencimiento");
            Property observaciones = lineaFactura.findPropertyByName("observaciones");
            try
            {

                int line = 0;
                while ((input = re.ReadLine()) != null)
                {
                    string TEXT_NRO_CLIENTE = "Nro. Cliente: ";
                    int posIniDeudor = input.IndexOf(TEXT_NRO_CLIENTE);
                    if (posIniDeudor != -1)
                    {
                        this.idDeudorActual = input.Substring(posIniDeudor + TEXT_NRO_CLIENTE.Length).Trim();
                    }

                    Boolean bLineaFactura = false;
                    int lineLen = input.Length;
                    if (lineLen == 131)
                    {
                        Boolean bFechaOk = false;
                        try
                        {
                            string fecha = input.Substring(1, 8);
                            DateTime dtFecha = DateTime.Now;
                            dtFecha = DateTime.Parse(fecha, cultureEsAR);
                            bFechaOk = true;
                        }
                        catch (Exception ef)
                        {
                        }

                        Boolean bImporteOk = false;
                        try
                        {
                            string importe2 = input.Substring(118);
                            Double dbImporte = 0.0f;
                            if (importe2.IndexOf(',') == -1)
                            {
                                dbImporte = double.Parse(importe2.Replace('.', ','), cultureEsAR);
                            }
                            else
                            {
                                try
                                {
                                    dbImporte = double.Parse(importe2, cultureEsAR);
                                }
                                catch (Exception ex)
                                {
                                    
                                    try
                                    {
                                        dbImporte = double.Parse(importe2);
                                        
                                    }
                                    catch (Exception eex)
                                    {
                                        dbImporte = double.Parse(importe2.Replace(",", "#").Replace(".", ",").Replace("#", ""));
                                    }
                                }
                            }
                            bImporteOk = true;
                        }
                        catch (Exception ex)
                        {
                        }

                        if (bFechaOk && bImporteOk)
                        {
                            bLineaFactura = true;
                        }


                    }

                    if (line > getOffset() && bLineaFactura && this.idDeudorActual != null)
                    {

                        facturaDTO = new FacturaDTO();
                        facturaDTO.idCliente = Int16.Parse(cliente.id);

                        facturaDTO.idDeudor = this.idDeudorActual;

                        // id_tipo_comprobante
                        if (id_tipo_comprobante.from != null && id_tipo_comprobante.defaultValue == null)
                        {

                            facturaDTO.idTipoComprobante = input.Substring(Int16.Parse(id_tipo_comprobante.from), Int16.Parse(id_tipo_comprobante.len));

                        }
                        else if (id_tipo_comprobante.defaultValue != null)
                        {

                            facturaDTO.idTipoComprobante = id_tipo_comprobante.defaultValue;

                        }

                        // letra
                        if (letra.from != null && letra.defaultValue == null)
                        {

                            facturaDTO.letra = input.Substring(Int16.Parse(letra.from), Int16.Parse(letra.len));

                        }
                        else if (letra.defaultValue != null)
                        {

                            facturaDTO.letra = letra.defaultValue;

                        }

                        // emision
                        if (emision.from != null && emision.defaultValue == null)
                        {

                            facturaDTO.emision = input.Substring(Int16.Parse(emision.from), Int16.Parse(emision.len));

                        }
                        else if (emision.defaultValue != null)
                        {

                            facturaDTO.emision = emision.defaultValue;

                        }

                        // nro_comprobante
                        if (nro_comprobante.from != null && nro_comprobante.defaultValue == null)
                        {

                            facturaDTO.nroComprobante = input.Substring(Int16.Parse(nro_comprobante.from), Int16.Parse(nro_comprobante.len));

                        }
                        else if (nro_comprobante.defaultValue != null)
                        {

                            facturaDTO.nroComprobante = nro_comprobante.defaultValue;

                        }

                        // importe
                        if (importe.from != null && importe.defaultValue == null)
                        {

                            //facturaDTO.importe = Double.Parse(input.Substring(Int16.Parse(importe.from), Int16.Parse(importe.len)).Replace('.', ','));
                            facturaDTO.importe = getImporte(importe, input);
                        }
                        else if (importe.defaultValue != null)
                        {

                            facturaDTO.importe = double.Parse(importe.defaultValue);

                        }

                        // saldo
                        if (saldo.from != null && saldo.defaultValue == null)
                        {

                            //facturaDTO.importe = Double.Parse(input.Substring(Int16.Parse(importe.from), Int16.Parse(importe.len)).Replace('.', ','));
                            facturaDTO.saldo = getImporte(saldo, input);
                        }
                        else if (saldo.defaultValue != null)
                        {

                            facturaDTO.saldo = double.Parse(saldo.defaultValue);

                        }

                        // importe_moneda_local
                        if (importe_moneda_local.from != null && importe_moneda_local.defaultValue == null)
                        {
                            //facturaDTO.importe = Double.Parse(input.Substring(Int16.Parse(importe.from), Int16.Parse(importe.len)).Replace('.', ','));
                            facturaDTO.importeMonedaLocal = getImporte(importe_moneda_local, input);
                        }
                        else if (importe_moneda_local.defaultValue != null)
                        {

                            facturaDTO.importeMonedaLocal = double.Parse(importe_moneda_local.defaultValue);

                        }


                        // id_moneda
                        if (id_moneda.from != null && id_moneda.defaultValue == null)
                        {

                            facturaDTO.idMoneda = input.Substring(Int16.Parse(id_moneda.from), Int16.Parse(id_moneda.len));

                        }
                        else if (id_moneda.defaultValue != null)
                        {

                            facturaDTO.idMoneda = id_moneda.defaultValue;

                        }


                        // fecha_emision
                        if (fecha_emision.from != null && fecha_emision.defaultValue == null)
                        {

                            //facturaDTO.fechaVencimiento = System.DateTime.Parse(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));
                            facturaDTO.fechaEmision = getDateTime(input.Substring(Int16.Parse(fecha_emision.from), Int16.Parse(fecha_emision.len)));

                        }
                        else if (fecha_emision.defaultValue != null)
                        {

                            facturaDTO.fechaEmision = System.DateTime.Parse(fecha_emision.defaultValue);

                        }


                        // fecha_vencimiento
                        if (fecha_vencimiento.from != null && fecha_vencimiento.defaultValue == null)
                        {

                            //facturaDTO.fechaVencimiento = System.DateTime.Parse(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));
                            facturaDTO.fechaVencimiento = getDateTime(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));

                        }
                        else if (fecha_vencimiento.defaultValue != null)
                        {

                            facturaDTO.fechaVencimiento = System.DateTime.Parse(fecha_vencimiento.defaultValue);

                        }

                        // observaciones
                        if (observaciones.from != null && observaciones.defaultValue == null)
                        {

                            facturaDTO.observaciones = input.Substring(Int16.Parse(observaciones.from), Int16.Parse(observaciones.len));

                        }
                        else if (observaciones.defaultValue != null)
                        {

                            facturaDTO.observaciones = observaciones.defaultValue;

                        }


                        applySpecificRules(facturaDTO);

                        if (passes(facturaDTO))
                        {
                            listaFacturasDTO.Add(facturaDTO);
                        }

                    }

                    line++;

                }
            }
            catch (Exception e)
            {
                System.Console.Write(e);

            }
            //re.close();

            return listaFacturasDTO;
        }

    }
}
