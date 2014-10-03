using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gobbi.CoreServices.Caching;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.services;
using CarlosAg.ExcelXmlWriter;
using Common.DataContracts;
using Common.Interfaces;
using Common.DataContracts;
using System.Linq;

namespace ExcelXmlWriter
{
    using System;
    using System.Xml;
    using CarlosAg.ExcelXmlWriter;


    public static class ExcelExport
    {

        static void GenerateStyles(WorksheetStyleCollection styles)
        {
            // -----------------------------------------------
            //  Default
            // -----------------------------------------------
            WorksheetStyle Default = styles.Add("Default");
            Default.Name = "Normal";
            Default.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s18
            // -----------------------------------------------
            WorksheetStyle s18 = styles.Add("s18");
            s18.Name = "Moneda";
            s18.NumberFormat = "_ \"$\"\\ * #,##0.00_ ;_ \"$\"\\ * \\-#,##0.00_ ;_ \"$\"\\ * \"-\"??_ ;_ @_ ";
            // -----------------------------------------------
            //  m157238036
            // -----------------------------------------------
            WorksheetStyle m157238036 = styles.Add("m157238036");
            m157238036.Font.Bold = true;
            m157238036.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m157238036.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            m157238036.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m157238036.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m157238036.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m157238036.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m157238046
            // -----------------------------------------------
            WorksheetStyle m157238046 = styles.Add("m157238046");
            m157238046.Font.Bold = true;
            m157238046.Font.Size = 9;
            m157238046.Interior.Color = "#FFFFFF";
            m157238046.Interior.Pattern = StyleInteriorPattern.Solid;
            m157238046.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            m157238046.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            m157238046.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m157238046.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m157238046.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m157238046.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s21
            // -----------------------------------------------
            WorksheetStyle s21 = styles.Add("s21");
            s21.Font.Bold = true;
            // -----------------------------------------------
            //  s22
            // -----------------------------------------------
            WorksheetStyle s22 = styles.Add("s22");
            s22.Font.Bold = true;
            s22.Font.Color = "#000080";
            // -----------------------------------------------
            //  s23
            // -----------------------------------------------
            WorksheetStyle s23 = styles.Add("s23");
            s23.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s23.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s23.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s23.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s24
            // -----------------------------------------------
            WorksheetStyle s24 = styles.Add("s24");
            s24.Font.Bold = true;
            s24.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s24.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s24.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s24.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s25
            // -----------------------------------------------
            WorksheetStyle s25 = styles.Add("s25");
            s25.Font.Bold = true;
            s25.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s25.Alignment.WrapText = true;
            s25.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s25.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s25.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s25.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s26
            // -----------------------------------------------
            WorksheetStyle s26 = styles.Add("s26");
            s26.Font.Bold = true;
            // -----------------------------------------------
            //  s28
            // -----------------------------------------------
            WorksheetStyle s28 = styles.Add("s28");
            s28.Parent = "s18";
            s28.Font.Bold = true;
            s28.Font.Color = "#000080";
            s28.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s28.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s28.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s28.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s28.NumberFormat = "_ \"$\"\\ * #,##0.00_ ;_ \"$\"\\ * \\-#,##0.00_ ;_ \"$\"\\ * \"-\"??_ ;_ @_ ";
            // -----------------------------------------------
            //  s29
            // -----------------------------------------------
            WorksheetStyle s29 = styles.Add("s29");
            s29.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            s29.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s44
            // -----------------------------------------------
            WorksheetStyle s44 = styles.Add("s44");
            s44.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s44.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s44.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s44.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s45
            // -----------------------------------------------
            WorksheetStyle s45 = styles.Add("s45");
            s45.Font.Bold = true;
            s45.Font.Color = "#008000";
            // -----------------------------------------------
            //  s46
            // -----------------------------------------------
            WorksheetStyle s46 = styles.Add("s46");
            s46.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            s46.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s47
            // -----------------------------------------------
            WorksheetStyle s47 = styles.Add("s47");
            s47.Font.Bold = true;
            s47.Font.Color = "#FF0000";
            s47.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s47.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s47.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s47.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s48
            // -----------------------------------------------
            WorksheetStyle s48 = styles.Add("s48");
            s48.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s48.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s48.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s48.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s48.NumberFormat = "Short Date";
            // -----------------------------------------------
            //  s49
            // -----------------------------------------------
            WorksheetStyle s49 = styles.Add("s49");
            s49.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s49.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s49.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s49.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s49.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s49.NumberFormat = "0";
            // -----------------------------------------------
            //  s50
            // -----------------------------------------------
            WorksheetStyle s50 = styles.Add("s50");
            s50.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s50.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s50.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s50.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s50.NumberFormat = "Fixed";
            // -----------------------------------------------
            //  s51
            // -----------------------------------------------
            WorksheetStyle s51 = styles.Add("s51");
            s51.NumberFormat = "Fixed";
            // -----------------------------------------------
            //  s53
            // -----------------------------------------------
            WorksheetStyle s53 = styles.Add("s53");
            s53.Font.Bold = true;
            s53.Font.Color = "#008000";
            s53.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            s53.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s53.Alignment.WrapText = true;
            // -----------------------------------------------
            //  s54
            // -----------------------------------------------
            WorksheetStyle s54 = styles.Add("s54");
            s54.Font.Bold = true;
            s54.Font.Color = "#006699";
            s54.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            s54.Alignment.Vertical = StyleVerticalAlignment.Bottom;
        }

        static void GenerateStylesToHDR(WorksheetStyleCollection styles)
        {
            WorksheetStyle s54 = styles.Add("s54");
            s54.Font.Bold = true;
            s54.Font.Color = "#006699";
            s54.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            s54.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            styles.Add(s54);
        }

        public static void Generate(string filename,
          HojaDeRutaExcelDataContracts hojaDeRuta)
        {


            Workbook book = new Workbook();
            WorksheetCollection sheets = book.Worksheets;

            Worksheet sheet = sheets.Add("Resultado");

            WorksheetRow myRowTitle = new WorksheetRow();
            myRowTitle.Cells.Add("HOJA DE RUTA " + DateTime.Now.ToString());
            sheet.Table.Rows.Add(myRowTitle);
            WorksheetRow myRowBlank = new WorksheetRow();
            myRowBlank.Cells.Add("");
            sheet.Table.Rows.Add(myRowBlank);


            IEnumerable<IGrouping<string, DeudorHojaDeRutaDataContracts>> lista = hojaDeRuta.DeudoresDeLahojaConGestion.GroupBy(x => x.Cobrador);
            bool encabezadoCreado = false;
            //Encabezado resumen
            foreach (IGrouping<string, DeudorHojaDeRutaDataContracts> item in lista)
            {
                foreach (DeudorHojaDeRutaDataContracts content in item.OrderBy(con => con.Provincia).ThenBy(con => con.Localidad).ThenBy(con => con.Domicilio))
                {

                    if (!encabezadoCreado)
                    {
                        sheet.Table.Rows.Add(myRowBlank);
                        WorksheetRow myRowHeader = new WorksheetRow();
                        myRowHeader.Cells.Add("FECHA");
                        myRowHeader.Cells.Add("CLIENTE");
                        myRowHeader.Cells.Add("DEUDOR");
                        myRowHeader.Cells.Add("DOMICILIO");
                        myRowHeader.Cells.Add("LOCALIDAD");
                        myRowHeader.Cells.Add("PROVINCIA");
                        myRowHeader.Cells.Add("OBSERVACIONES");
                        myRowHeader.Cells.Add("HORARIO");
                        myRowHeader.Cells.Add("CODIGO POSTAL");
                        myRowHeader.Cells.Add("COBRADOR");
                        sheet.Table.Rows.Add(myRowHeader);
                        encabezadoCreado = true;
                    }
                    WorksheetRow myRow = new WorksheetRow();
                    myRow.Cells.Add(DateTime.Now.ToString());
                    myRow.Cells.Add(content.Cliente);
                    myRow.Cells.Add(content.Deudor);
                    myRow.Cells.Add(content.Domicilio);
                    myRow.Cells.Add(content.Localidad);
                    myRow.Cells.Add(content.Provincia);
                    myRow.Cells.Add(content.ObservacionesHistoria);
                    myRow.Cells.Add(content.Horario);
                    myRow.Cells.Add(content.Cp);
                    myRow.Cells.Add(content.Cobrador);

                    sheet.Table.Rows.Add(myRow);

                }
            }

            // Fin encabezado resumen

            sheet.Table.Rows.Add(myRowBlank);
            //sheet.Table.Rows.Add(myRowBlank);

            foreach (IGrouping<string, DeudorHojaDeRutaDataContracts> item in lista)
            {


                foreach (DeudorHojaDeRutaDataContracts content in item.OrderBy(con => con.Provincia).ThenBy(con => con.Localidad).ThenBy(con => con.Domicilio))
                {
                    //sheet.Table.Rows.Add(myRowBlank);
                    WorksheetRow myRowCobrador = new WorksheetRow();
                    myRowCobrador.Cells.Add("COBRADOR: " + content.Cobrador);
                    sheet.Table.Rows.Add(myRowCobrador);
                    //sheet.Table.Rows.Add(myRowBlank);


                    WorksheetRow myRowHeader = new WorksheetRow();
                    myRowHeader.Cells.Add("DEUDOR");
                    myRowHeader.Cells.Add("CLIENTE");
                    myRowHeader.Cells.Add("ALFANUM");
                    myRowHeader.Cells.Add("PROVINCIA");
                    myRowHeader.Cells.Add("LOCALIDAD");
                    myRowHeader.Cells.Add("DOMICILIO");
                    myRowHeader.Cells.Add("CODIGO POSTAL");
                    sheet.Table.Rows.Add(myRowHeader);



                    WorksheetRow myRow = new WorksheetRow();

                    myRow.Cells.Add(content.Deudor);
                    myRow.Cells.Add(content.Cliente);
                    myRow.Cells.Add(content.AlfaNumDelCliente);
                    myRow.Cells.Add(content.Provincia);
                    myRow.Cells.Add(content.Localidad);
                    myRow.Cells.Add(content.Domicilio);
                    myRow.Cells.Add(content.Cp);

                    sheet.Table.Rows.Add(myRow);

                    WorksheetRow myRowObservaciones = new WorksheetRow();
                    myRowObservaciones.Cells.Add("Observaciones: " + content.ObservacionesHistoria);
                    sheet.Table.Rows.Add(myRowObservaciones);

                    WorksheetRow myRowFacturas = new WorksheetRow();

                    sheet.Table.Rows.Add(myRowBlank);
                    WorksheetRow myRowFacturasHeader = new WorksheetRow();
                    myRowFacturasHeader.Cells.Add("Número Factura");
                    myRowFacturasHeader.Cells.Add("Fecha Vencimiento");
                    //myRowFacturasHeader.Cells.Add("Fecha Cobro");
                    myRowFacturasHeader.Cells.Add("Importe");
                    myRowFacturasHeader.Cells.Add("Saldo");
                    sheet.Table.Rows.Add(myRowFacturasHeader);
                    foreach (ItemHojaDataContracts ih in hojaDeRuta.ItemsHoja)
                    {
                        if (ih.IdDeudor.ToString() == content.IdDeudor)
                        {
                            WorksheetRow myRowFactura = new WorksheetRow();
                            myRowFactura.Cells.Add(ih.ComprobanteFormateado);
                            myRowFactura.Cells.Add(ih.FechaVenc.ToString());
                            //myRowFactura.Cells.Add(ih.FechaCobro.ToString());
                            myRowFactura.Cells.Add(ih.Importe.ToString());
                            myRowFactura.Cells.Add(ih.Saldo.ToString());
                            sheet.Table.Rows.Add(myRowFactura);
                        }

                    }



                }
            }
            // GenerateStylesToHDR(book.Styles);
            book.Save(filename);

        }

        public static void GenerateDepositoEnExcel(string filename,
                 HojaDeRutaExcelDataContracts hojaDeRuta)
        {


            Workbook book = new Workbook();
            WorksheetCollection sheets = book.Worksheets;
            Worksheet sheet = sheets.Add("Resultado");

            WorksheetRow myRowBlank = new WorksheetRow();
            sheet.Table.Rows.Add(myRowBlank);
            WorksheetRow myRowHeader = new WorksheetRow();
            myRowHeader.Cells.Add("Formulario");
            myRowHeader.Cells.Add("N° Cliente");
            myRowHeader.Cells.Add("Razón Social");
            myRowHeader.Cells.Add("CUIT Emisor");
            myRowHeader.Cells.Add("Numero RC");
            myRowHeader.Cells.Add("Fecha RC");
            myRowHeader.Cells.Add("MEDIO P");
            myRowHeader.Cells.Add("Numero");
            myRowHeader.Cells.Add("Bco");
            myRowHeader.Cells.Add("Suc");
            myRowHeader.Cells.Add("Cuit");
            myRowHeader.Cells.Add("Importe");
            myRowHeader.Cells.Add("Fecha Emi");
            myRowHeader.Cells.Add("Fecha Venci");

            sheet.Table.Rows.Add(myRowHeader);
           // encabezadoCreado = true;

        }



        public static void GenerateDSG(string filename,
                  HojaDeRutaExcelDataContracts hojaDeRuta)
        {


            Workbook book = new Workbook();
            WorksheetCollection sheets = book.Worksheets;
            
            Worksheet sheet = sheets.Add("Resultado");

            WorksheetRow myRowTitle = new WorksheetRow();
            myRowTitle.Cells.Add("HOJA DE RUTA " + DateTime.Now.ToString());
            sheet.Table.Rows.Add(myRowTitle);
            WorksheetRow myRowBlank = new WorksheetRow();
            myRowBlank.Cells.Add("");
            sheet.Table.Rows.Add(myRowBlank);


            IEnumerable<IGrouping<string,DeudorHojaDeRutaDataContracts>> lista = hojaDeRuta.DeudoresDeLahojaConGestion.GroupBy(x => x.Cobrador);
            bool encabezadoCreado = false;
            //Encabezado resumen
            foreach (IGrouping<string, DeudorHojaDeRutaDataContracts> item in lista)
            {
                foreach (DeudorHojaDeRutaDataContracts content in item.OrderBy(con => con.Provincia).ThenBy(con => con.Localidad).ThenBy(con => con.Domicilio))
                {
              
                    if (!encabezadoCreado)
                    {
                        sheet.Table.Rows.Add(myRowBlank);
                        WorksheetRow myRowHeader = new WorksheetRow();
                        myRowHeader.Cells.Add("FECHA");
                        myRowHeader.Cells.Add("CLIENTE");
                        myRowHeader.Cells.Add("DEUDOR");
                        myRowHeader.Cells.Add("DOMICILIO");
                        myRowHeader.Cells.Add("LOCALIDAD");
                        myRowHeader.Cells.Add("PROVINCIA");
                        myRowHeader.Cells.Add("OBSERVACIONES");
                        myRowHeader.Cells.Add("HORARIO");
                        myRowHeader.Cells.Add("CODIGO POSTAL");
                        myRowHeader.Cells.Add("COBRADOR");
                        sheet.Table.Rows.Add(myRowHeader);
                        encabezadoCreado = true;
                    }
                    WorksheetRow myRow = new WorksheetRow();
                    myRow.Cells.Add(DateTime.Now.ToString());
                    myRow.Cells.Add(content.Cliente);
                    myRow.Cells.Add(content.Deudor);
                    myRow.Cells.Add(content.Domicilio);
                    myRow.Cells.Add(content.Localidad);
                    myRow.Cells.Add(content.Provincia);
                    myRow.Cells.Add(content.ObservacionesHistoria);
                    myRow.Cells.Add(content.Horario);
                    myRow.Cells.Add(content.Cp);
                    myRow.Cells.Add(content.Cobrador);
                    
                    sheet.Table.Rows.Add(myRow);

                }
            }


            //Inicio encabezado sin gestion

            //fin encabezado sin gestion

            IEnumerable<IGrouping<string, DeudorHojaDeRutaDataContracts>> listaSinGestion = hojaDeRuta.DeudoresDeLahojaSinGestion.GroupBy(x => x.Cobrador);
            //Encabezado resumen
            foreach (IGrouping<string, DeudorHojaDeRutaDataContracts> item in listaSinGestion)
            {
                foreach (DeudorHojaDeRutaDataContracts content in item.OrderBy(con => con.Provincia).ThenBy(con => con.Localidad).ThenBy(con => con.Domicilio))
                {
                    
                    WorksheetRow myRow = new WorksheetRow();
                    myRow.Cells.Add(DateTime.Now.ToString());
                    myRow.Cells.Add(content.Cliente);
                    myRow.Cells.Add(content.Deudor);
                    myRow.Cells.Add(content.Domicilio);
                    myRow.Cells.Add(content.Localidad);
                    myRow.Cells.Add(content.Provincia);
                    myRow.Cells.Add(content.ObservacionesHistoria);
                    myRow.Cells.Add(content.Horario);
                    myRow.Cells.Add(content.Cp);
                    myRow.Cells.Add(content.Cobrador);

                    sheet.Table.Rows.Add(myRow);

                }
            }


            // Fin encabezado resumen

            sheet.Table.Rows.Add(myRowBlank);
           
            ////detalle para los con gestion

            sheet.Table.Rows.Add(myRowBlank);
            //sheet.Table.Rows.Add(myRowBlank);
            IEnumerable<IGrouping<string, DeudorHojaDeRutaDataContracts>> listaConGestion = hojaDeRuta.DeudoresDeLahojaConGestion.GroupBy(x => x.Cobrador);
            foreach (IGrouping<string, DeudorHojaDeRutaDataContracts> item in listaConGestion)
            {


                foreach (DeudorHojaDeRutaDataContracts content in item.OrderBy(con => con.Provincia).ThenBy(con => con.Localidad).ThenBy(con => con.Domicilio))
                {
                    //sheet.Table.Rows.Add(myRowBlank);
                    WorksheetRow myRowCobrador = new WorksheetRow();
                    myRowCobrador.Cells.Add("COBRADOR: " + content.Cobrador);
                    sheet.Table.Rows.Add(myRowCobrador);
                    //sheet.Table.Rows.Add(myRowBlank);


                    WorksheetRow myRowHeader = new WorksheetRow();
                    myRowHeader.Cells.Add("DEUDOR");
                    myRowHeader.Cells.Add("CLIENTE");
                    myRowHeader.Cells.Add("ALFANUM");
                    myRowHeader.Cells.Add("PROVINCIA");
                    myRowHeader.Cells.Add("LOCALIDAD");
                    myRowHeader.Cells.Add("DOMICILIO");
                    myRowHeader.Cells.Add("CODIGO POSTAL");
                    sheet.Table.Rows.Add(myRowHeader);



                    WorksheetRow myRow = new WorksheetRow();

                    myRow.Cells.Add(content.Deudor);
                    myRow.Cells.Add(content.Cliente);
                    myRow.Cells.Add(content.AlfaNumDelCliente);
                    myRow.Cells.Add(content.Provincia);
                    myRow.Cells.Add(content.Localidad);
                    myRow.Cells.Add(content.Domicilio);
                    myRow.Cells.Add(content.Cp);

                    sheet.Table.Rows.Add(myRow);

                    WorksheetRow myRowObservaciones = new WorksheetRow();
                    myRowObservaciones.Cells.Add("Observaciones: " + content.ObservacionesHistoria);
                    sheet.Table.Rows.Add(myRowObservaciones);

                    WorksheetRow myRowFacturas = new WorksheetRow();

                    sheet.Table.Rows.Add(myRowBlank);
                    WorksheetRow myRowFacturasHeader = new WorksheetRow();
                    myRowFacturasHeader.Cells.Add("Número Factura");
                    myRowFacturasHeader.Cells.Add("Fecha Vencimiento");
                    //myRowFacturasHeader.Cells.Add("Fecha Cobro");
                    myRowFacturasHeader.Cells.Add("Importe");
                    myRowFacturasHeader.Cells.Add("Saldo");
                    sheet.Table.Rows.Add(myRowFacturasHeader);
                    foreach (ItemHojaDataContracts ih in hojaDeRuta.ItemsHoja)
                    {
                        if (ih.IdDeudor.ToString() == content.IdDeudor)
                        {
                            WorksheetRow myRowFactura = new WorksheetRow();
                            myRowFactura.Cells.Add(ih.ComprobanteFormateado);
                            myRowFactura.Cells.Add(ih.FechaVenc.ToString());
                            //myRowFactura.Cells.Add(ih.FechaCobro.ToString());
                            myRowFactura.Cells.Add(ih.Importe.ToString());
                            myRowFactura.Cells.Add(ih.Saldo.ToString());
                            sheet.Table.Rows.Add(myRowFactura);
                        }

                    }



                }
            }
            //fin detalle para los con gestion
           // GenerateStylesToHDR(book.Styles);
            book.Save(filename);

        }

        public static void Generate(string filename,
                    DataTable lstDocs)
        {

            Workbook book = new Workbook();
            // -----------------------------------------------
            //  Properties
            // -----------------------------------------------
            book.Properties.Author = "Aplicativo EMACSA ";
            book.Properties.LastAuthor = "Aplicativo EMACSA";
            book.Properties.Created = DateTime.Now;
            book.Properties.LastSaved = DateTime.Now;
            book.Properties.Manager = "Proyecto EMACSA";
            book.Properties.Company = "GPS Systems S.A.";
            book.Properties.Version = "11.9999";
            book.ExcelWorkbook.WindowHeight = 9210;
            book.ExcelWorkbook.WindowWidth = 15195;
            book.ExcelWorkbook.WindowTopX = 0;
            book.ExcelWorkbook.WindowTopY = 30;
            book.ExcelWorkbook.ProtectWindows = false;
            book.ExcelWorkbook.ProtectStructure = false;

            GenerateStyles(book.Styles);


            if (lstDocs!=null)
            {
                GenerateWorksheetDocumentos(book.Worksheets, lstDocs);
                book.Save(filename);

            }
            
        }



        static void GenerateWorksheetDocumentos(WorksheetCollection sheets, DataTable lstdoc)
        {
            Worksheet sheet = sheets.Add("Resultado");

            // -----------------------------------------------

            // -----------------------------------------------
            // Recorro la lista de documentos

            WorksheetRow myRowTitle = new WorksheetRow();
            myRowTitle.Cells.Add("Resultados Obtenidos");
            sheet.Table.Rows.Add(myRowTitle);

            WorksheetRow myRowBlank = new WorksheetRow();
            myRowBlank.Cells.Add("");
            sheet.Table.Rows.Add(myRowBlank);


            WorksheetRow myRowHeader = new WorksheetRow();

            foreach (DataColumn dc in lstdoc.Columns) {
                myRowHeader.Cells.Add(separateCamel(dc.ColumnName));
            }

            /*myRowHeader.Cells.Add("ID DEUDOR");
            myRowHeader.Cells.Add("NOMBRE");
            myRowHeader.Cells.Add("CUIT");
            myRowHeader.Cells.Add("DOMICILIO");
            myRowHeader.Cells.Add("LOCALIDAD");
            myRowHeader.Cells.Add("PROVINCIA"); */
            sheet.Table.Rows.Add(myRowHeader);



            WorksheetRow myRow;

            foreach (DataRow dr in lstdoc.Rows)
            {
                myRow = new WorksheetRow();

                foreach (object obj in dr.ItemArray) {
                    myRow.Cells.Add(obj.ToString(), DataType.String, "s23") ;
                }
                /*
                myRow.Cells.Add(dr["idDeudor"].ToString(), DataType.String, "s23");
                myRow.Cells.Add(dr["nombre"].ToString(), DataType.String, "s23");
                myRow.Cells.Add(dr["cuit"].ToString(), DataType.String, "s23");
                myRow.Cells.Add(dr["domicilio"].ToString(), DataType.String, "s23");
                myRow.Cells.Add(dr["localidad"].ToString(), DataType.String, "s23");
                myRow.Cells.Add(dr["provincia"].ToString(), DataType.String, "s23");
                */
                sheet.Table.Rows.Add(myRow);
            }




        }

        private static string separateCamel(string camelCase)
        {

            for (int i = 1; i < camelCase.Length; i++) { 
                if (camelCase.Substring(i,1).Equals(camelCase.Substring(i,1).ToUpper())) {

                    camelCase = camelCase.Insert(i  , " ");
                    i++;
                }
            }


            return camelCase;
        }

    }

}
