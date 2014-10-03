using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Globalization;


namespace Interfaces.Parsers
{
    abstract class FacturaExcelParser : Parser
    {

        protected int _linesNotReaded = 0;

        private string getColumnValue(Property propiedad, ExcelHandler excel, Range range, int rCnt)
        {

            string input = null;
            input = (propiedad.col != null ? excel.Read(range, rCnt, Int32.Parse(propiedad.col)) : "");
            return input;
        }

        public string getColumnValue(ExcelHandler excel, Range range, int rCnt, int cCnt)
        {

            string input = null;
            input = (excel.Read(range, rCnt, cCnt));
            return input;
        }

        public abstract Boolean passesRow(ExcelHandler excel, Range range, int rCnt);

        public virtual Boolean shouldProcessRow(ExcelHandler excel, Range range, int rCnt)
        {
            return true;
        }

        public virtual Boolean shouldContinueReading()
        {
            return !(_linesNotReaded >= 2);
        }

        public override List<FacturaDTO> parse(string fileFullName, ClienteInterfaz cliente)
        {
            LineaFactura lineaFactura = cliente.lineaFactura;
            FacturaDTO facturaDTO = null;
            ExcelHandler excel = null;

            Property id_deudor = lineaFactura.findPropertyByName("id_deudor");
            Property id_tipo_comprobante = lineaFactura.findPropertyByName("id_tipo_comprobante");
            Property letra = lineaFactura.findPropertyByName("letra");
            Property emision = lineaFactura.findPropertyByName("emision");
            Property nro_comprobante = lineaFactura.findPropertyByName("nro_comprobante");
            Property importe = lineaFactura.findPropertyByName("importe");
            Property id_moneda = lineaFactura.findPropertyByName("id_moneda");
            Property fecha_emision = lineaFactura.findPropertyByName("fecha_emision");
            Property fecha_vencimiento = lineaFactura.findPropertyByName("fecha_vencimiento");
            Property observaciones = lineaFactura.findPropertyByName("observaciones");

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            try
            {
                excel = new ExcelHandler();
                excel.Open(fileFullName);
                Worksheet hoja = null;
                try
                {
                    hoja = excel.getSheet(cliente.sheetName);
                }
                catch (Exception e)
                {
                    try
                    {
                        hoja = excel.getSheet(excel.GetSheetsNames()[0]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo determinar la hoja de datos de la planilla. Es probable que no corresponda.", ex);
                    }
                }

                //System.Collections.IEnumerator enumRows = hoja.QueryTables.GetEnumerator();

                List<FacturaDTO> listaFacturasDTO = new List<FacturaDTO>();
                long row = 0;
                string input;
                int rCnt = 0;
                Excel.Range range;

                range = hoja.UsedRange;

                for (rCnt = (getOffset() + 2); rCnt <= range.Rows.Count; rCnt++)
                {
                    if (! shouldContinueReading()) {
                        break;
                    }

                    if (shouldProcessRow(excel, range, rCnt))
                    {
                        facturaDTO = new FacturaDTO();
                        facturaDTO.idCliente = Int16.Parse(cliente.id);


                        // id_deudor
                        input = getColumnValue(id_deudor, excel, range, rCnt);
                        if (id_deudor.from != null && id_deudor.defaultValue == null && input != null && !"".Equals(input))
                        {
                            if (input.Length >= (Int16.Parse(id_deudor.from) + Int16.Parse(id_deudor.len)))
                            {
                                facturaDTO.idDeudor = input.Substring(Int16.Parse(id_deudor.from), Int16.Parse(id_deudor.len));
                            }
                            else 
                            {
                                facturaDTO.idDeudor = input;
                            }

                        }
                        else if (id_deudor.defaultValue != null)
                        {

                            facturaDTO.idDeudor = id_deudor.defaultValue;

                        }
                        else
                        {
                            facturaDTO.idDeudor = input;
                        }


                        // id_tipo_comprobante
                        input = getColumnValue(id_tipo_comprobante, excel, range, rCnt);
                        if (id_tipo_comprobante.from != null && id_tipo_comprobante.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(id_tipo_comprobante.from) + Int16.Parse(id_tipo_comprobante.len)))
                            {
                                facturaDTO.idTipoComprobante = input.Substring(Int16.Parse(id_tipo_comprobante.from), Int16.Parse(id_tipo_comprobante.len));
                            }
                            else
                            {
                                facturaDTO.idTipoComprobante = input;
                            }

                        }
                        else if (id_tipo_comprobante.defaultValue != null)
                        {

                            facturaDTO.idTipoComprobante = id_tipo_comprobante.defaultValue;

                        }
                        else
                        {
                            facturaDTO.idTipoComprobante = input;
                        }

                        // letra
                        input = getColumnValue(letra, excel, range, rCnt);
                        if (letra.from != null && letra.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(letra.from) + Int16.Parse(letra.len)))
                            {
                                facturaDTO.letra = input.Substring(Int16.Parse(letra.from), Int16.Parse(letra.len));
                            }
                            else 
                            {
                                facturaDTO.letra = input;
                            }
                           

                        }
                        else if (letra.defaultValue != null)
                        {

                            facturaDTO.letra = letra.defaultValue;

                        }
                        else
                        {
                            facturaDTO.letra = input;
                        }

                        // emision
                        input = getColumnValue(emision, excel, range, rCnt);
                        if (emision.from != null && emision.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(emision.from) + Int16.Parse(emision.len)))
                            {
                                facturaDTO.emision = input.Substring(Int16.Parse(emision.from), Int16.Parse(emision.len));
                            }
                            else
                            {
                                facturaDTO.emision = input;
                            }

                        }
                        else if (emision.defaultValue != null)
                        {

                            facturaDTO.emision = emision.defaultValue;

                        }
                        else
                        {
                            facturaDTO.emision = input;
                        }

                        // nro_comprobante
                        input = getColumnValue(nro_comprobante, excel, range, rCnt);
                        if (nro_comprobante.from != null && nro_comprobante.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(nro_comprobante.from) + Int16.Parse(nro_comprobante.len)))
                            {
                                facturaDTO.nroComprobante = input.Substring(Int16.Parse(nro_comprobante.from), Int16.Parse(nro_comprobante.len));
                            }
                            else 
                            {
                                facturaDTO.nroComprobante = input;
                            }

                        }
                        else if (nro_comprobante.defaultValue != null)
                        {

                            facturaDTO.nroComprobante = nro_comprobante.defaultValue;

                        }
                        else
                        {
                            facturaDTO.nroComprobante = input;
                        }

                        // importe
                        input = getColumnValue(importe, excel, range, rCnt);
                        if (importe.from != null && importe.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(importe.from) + Int16.Parse(importe.len)))
                            {
                                facturaDTO.importe = Double.Parse(input.Substring(Int16.Parse(importe.from), Int16.Parse(importe.len)).Replace('.', ','));
                            }
                            else { 
                                try {
                                    facturaDTO.importe = Double.Parse(input.Replace('.', ','));
                                } catch (Exception ex) {
                                    Console.Write(ex);
                                }
                            }

                        }
                        else if (importe.defaultValue != null)
                        {

                            facturaDTO.importe = double.Parse(importe.defaultValue);

                        }
                        else
                        {
                            facturaDTO.importe = double.Parse(input);
                        }


                        // id_moneda
                        input = getColumnValue(id_moneda, excel, range, rCnt);
                        if (id_moneda.from != null && id_moneda.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(id_moneda.from) + Int16.Parse(id_moneda.len)))
                            {
                                facturaDTO.idMoneda = input.Substring(Int16.Parse(id_moneda.from), Int16.Parse(id_moneda.len));
                            } 
                            else
                            {
                                facturaDTO.idMoneda = input;
                            }

                        }
                        else if (id_moneda.defaultValue != null)
                        {

                            facturaDTO.idMoneda = id_moneda.defaultValue;

                        }
                        else
                        {
                            facturaDTO.idMoneda = input;
                        }


                        // fecha_emision
                        input = getColumnValue(fecha_emision, excel, range, rCnt);
                        if (fecha_emision.from != null && fecha_emision.defaultValue == null && input != null && !"".Equals(input))
                        {

                            //facturaDTO.fechaVencimiento = System.DateTime.Parse(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));
                            if (input.Length >= (Int16.Parse(id_moneda.from) + Int16.Parse(id_moneda.len))) {
                                facturaDTO.fechaEmision = getDateTime(input.Substring(Int16.Parse(fecha_emision.from), Int16.Parse(fecha_emision.len)));
                            } 
                            else 
                            {
                                try {
                                    facturaDTO.fechaEmision = getDateTime(input);
                                } catch (Exception ex)
                                {
                                    Console.Write(ex);
                                }
                            }

                        }
                        else if (fecha_emision.defaultValue != null)
                        {

                            facturaDTO.fechaEmision = System.DateTime.Parse(fecha_emision.defaultValue);

                        }
                        else
                        {
                            try
                            {
                                facturaDTO.fechaEmision = getDateTime(input);
                            }
                            catch (Exception ex)
                            {
                                if (input != null)
                                {
                                    try
                                    {
                                        DateTime dt = new DateTime(1900, 1, 1);
                                        dt = dt.AddDays(double.Parse(input) -2 );
                                        facturaDTO.fechaEmision = dt;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.Write(e);
                                    }
                                }

                            }

                        }


                        // fecha_vencimiento
                        input = getColumnValue(fecha_vencimiento, excel, range, rCnt);
                        if (fecha_vencimiento.from != null && fecha_vencimiento.defaultValue == null && input != null && !"".Equals(input))
                        {

                            //facturaDTO.fechaVencimiento = System.DateTime.Parse(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));
                            if (input.Length >= (Int16.Parse(fecha_vencimiento.from) + Int16.Parse(fecha_vencimiento.len)))
                            {
                                facturaDTO.fechaVencimiento = getDateTime(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));
                            } 
                            else 
                            {
                                try {
                                    facturaDTO.fechaVencimiento = getDateTime(input);
                                } catch (Exception ex)
                                {
                                    Console.Write(ex);
                                }

                        }

                        }
                        else if (fecha_vencimiento.defaultValue != null)
                        {

                            facturaDTO.fechaVencimiento = System.DateTime.Parse(fecha_vencimiento.defaultValue);

                        }
                        else
                        {

                            try
                            {
                                facturaDTO.fechaVencimiento = getDateTime(input);
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    DateTime dt = new DateTime(1900, 1, 1);
                                    dt = dt.AddDays(double.Parse(input) - 2);
                                    facturaDTO.fechaVencimiento = dt;
                                }
                                catch (Exception e)
                                {
                                    Console.Write(e);
                                }
                            }

                        }

                        // observaciones
                        input = getColumnValue(observaciones, excel, range, rCnt);
                        if (observaciones.from != null && observaciones.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(observaciones.from) + Int16.Parse(observaciones.len))) {
                                facturaDTO.observaciones = input.Substring(Int16.Parse(observaciones.from), Int16.Parse(observaciones.len));
                            } else {
                                facturaDTO.observaciones = input;
                            }

                        }
                        else if (observaciones.defaultValue != null)
                        {

                            facturaDTO.observaciones = observaciones.defaultValue;

                        }
                        else
                        {
                            facturaDTO.observaciones = input;
                        }

                        applySpecificRules(facturaDTO);

                        if (passes(facturaDTO) && passesRow(excel, range, rCnt))
                        {
                            listaFacturasDTO.Add(facturaDTO);
                        }
                    }

                }

                return listaFacturasDTO;


            }
            catch (Exception e)
            {
                Console.Write(e);
                throw e;

            }
            finally
            {

                if (excel != null)
                {

                    excel.Close();
                }
            }

            return null;
        }
    }
}
