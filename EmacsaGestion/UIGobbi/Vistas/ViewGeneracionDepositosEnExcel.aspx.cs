﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Gobbi.CoreServices.Caching;
using Gobbi.CoreServices.Caching.CacheManagers;
using iTextSharp;
using Common.DataContracts;
using Common.Interfaces;
using System.Collections.Generic;
using Gobbi.services;
using System.IO;
using iTextSharp.text.pdf;
using CarlosAg.ExcelXmlWriter;

public partial class Vistas_ViewGeneracionDepositosEnExcel : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int idRemision = int.Parse(Request.Params.Get("idRemision"));
        RemisionDataContracts oRemision = new RemisionDataContracts();
        IRemisionService remisionService = ServiceClient<IRemisionService>.GetService("RemisionService");
        oRemision = remisionService.GetRemision(idRemision);
        List<ReciboDataContracts> lstRecibo = new List<ReciboDataContracts>();
        IReciboService reciboService = ServiceClient<IReciboService>.GetService("ReciboService");
        lstRecibo = reciboService.GetAllRecibosByIdRemision(idRemision);
        Workbook book = new Workbook();
        WorksheetCollection sheets = book.Worksheets;
        WorksheetRow myRowBlank = new WorksheetRow();
        Worksheet sheet = sheets.Add("Resultado");
        
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
        sheet.Table.Rows.Add(myRowBlank);

        foreach (ReciboDataContracts oRecibo in lstRecibo)
        {
        //Armado de Tabla Pagos: Obtener todos los pagos de un recibo
        List<ReciboPagoDataContracts> lstReciboPagos = new List<ReciboPagoDataContracts>();
        IReciboPagoService recibopagoService = ServiceClient<IReciboPagoService>.GetService("ReciboPagoService");
        lstReciboPagos = recibopagoService.GetAllReciboPagosByIdRecibo(oRecibo.Id);
        //Armar la lista real de pagos
        List<PagoDataContracts> lstPagos = new List<PagoDataContracts>();
        foreach (ReciboPagoDataContracts oReciboPago in lstReciboPagos)
        {
            WorksheetRow myRowDatos = new WorksheetRow();
            myRowDatos.Cells.Add(idRemision.ToString());
            //myRowDatos.Cells.Add(oRecibo.Cliente.IdCliente.ToString());
            myRowDatos.Cells.Add(oRecibo.Deudor.AlfaNumDelCliente);
            myRowDatos.Cells.Add(oRecibo.Deudor.Nombre.ToString());
            myRowDatos.Cells.Add(oRecibo.Deudor.Cuit.ToString());
            myRowDatos.Cells.Add(oRecibo.Numero.ToString());
            myRowDatos.Cells.Add(oRecibo.FechaCarga.ToShortDateString());
            //Definir el tipo de pago y buscar los valores que correspondan: Fecha, IdPago, Forma,
            PagoDataContracts unPago = new PagoDataContracts();
            unPago.IdPago = oReciboPago.IdPago;
            unPago.FormaPago = new FormaPagoDataContracts();
            unPago.FormaPago.Descripcion = oReciboPago.FormaPago;
            #region Switch Forma de Pago
            switch (unPago.FormaPago.Descripcion)
            {
                case "CHEQUE":

                    ChequeDataContracts oCheque = new ChequeDataContracts();
                    IChequeService chequeService = ServiceClient<IChequeService>.GetService("ChequeService");
                    oCheque = chequeService.GetCheque(unPago.IdPago);
                    myRowDatos.Cells.Add("CH");
                    myRowDatos.Cells.Add(oCheque.Numero.ToString());
                    myRowDatos.Cells.Add(oCheque.Banco.ToString());
                    myRowDatos.Cells.Add(oCheque.Sucursal.ToString());
                    myRowDatos.Cells.Add(oCheque.Cuit.ToString());
                    myRowDatos.Cells.Add(oCheque.Importe.ToString());
                    myRowDatos.Cells.Add(oCheque.Emision.ToShortDateString());
                    myRowDatos.Cells.Add(oCheque.Vencimiento.ToShortDateString());
                    sheet.Table.Rows.Add(myRowDatos);

                    break;
                case "EFECTIVO":

                    EfectivoDataContracts oEfectivo = new EfectivoDataContracts();
                    IEfectivoService efectivoService = ServiceClient<IEfectivoService>.GetService("EfectivoService");
                    oEfectivo = efectivoService.GetEfectivo(unPago.IdPago);
                    myRowDatos.Cells.Add("EF");
                    myRowDatos.Cells.Add("EFECTIVO");
                    myRowDatos.Cells.Add("0");
                    myRowDatos.Cells.Add(string.Empty);
                    myRowDatos.Cells.Add(string.Empty);
                    myRowDatos.Cells.Add(oEfectivo.Monto.ToString());
                    myRowDatos.Cells.Add(string.Empty);
                    myRowDatos.Cells.Add(string.Empty);
                    sheet.Table.Rows.Add(myRowDatos);


                    break;
                case "RETENCION":
                    RetencionDataContracts oRetencion = new RetencionDataContracts();
                    IRetencionService retencionService = ServiceClient<IRetencionService>.GetService("RetencionService");
                    oRetencion = retencionService.GetRetencion(unPago.IdPago);
                     myRowDatos.Cells.Add("CR");
                    myRowDatos.Cells.Add(oRetencion.IdSubTipoRetencion.ToString());
                    myRowDatos.Cells.Add("0");
                    myRowDatos.Cells.Add(string.Empty);
                    myRowDatos.Cells.Add(string.Empty);
                    myRowDatos.Cells.Add(oRetencion.Importe.ToString());
                    myRowDatos.Cells.Add(string.Empty);
                    myRowDatos.Cells.Add(string.Empty);
                    sheet.Table.Rows.Add(myRowDatos);

                    break;
                case "DEPOSITO":

                    DepositoDataContracts oDeposito = new DepositoDataContracts();
                    IDepositoService depositoService = ServiceClient<IDepositoService>.GetService("DepositoService");
                    oDeposito = depositoService.GetDeposito(unPago.IdPago);
                    myRowDatos.Cells.Add("DEPO");
                    myRowDatos.Cells.Add(oDeposito.Numero.ToString());
                    myRowDatos.Cells.Add(oDeposito.Banco.ToString());
                    myRowDatos.Cells.Add(oDeposito.Sucursal.ToString());
                    myRowDatos.Cells.Add(oDeposito.Cuit.ToString());
                    myRowDatos.Cells.Add(oDeposito.Importe.ToString());
                    myRowDatos.Cells.Add(oDeposito.Emision.ToShortDateString());
                    myRowDatos.Cells.Add(oDeposito.Vencimiento.ToShortDateString());
                    sheet.Table.Rows.Add(myRowDatos);
                    break;
                case "TRANSFERENCIA":

                    TransferenciaDataContracts oTransferencia = new TransferenciaDataContracts();
                    ITransferenciaService transferenciaService = ServiceClient<ITransferenciaService>.GetService("TransferenciaService");
                    oTransferencia = transferenciaService.GetTransferencia(unPago.IdPago);

                    myRowDatos.Cells.Add("TRANS");
                    myRowDatos.Cells.Add(oTransferencia.Numero.ToString());
                    myRowDatos.Cells.Add(oTransferencia.Banco.ToString());
                    myRowDatos.Cells.Add(oTransferencia.Sucursal.ToString());
                    myRowDatos.Cells.Add(oTransferencia.Cuit.ToString());
                    myRowDatos.Cells.Add(oTransferencia.Importe.ToString());
                    myRowDatos.Cells.Add(oTransferencia.Emision.ToShortDateString());
                    myRowDatos.Cells.Add(oTransferencia.Vencimiento.ToShortDateString());
                    sheet.Table.Rows.Add(myRowDatos);
                    break;
                case "OTRO":

                    OtroPagoDataContracts oOtroPago = new OtroPagoDataContracts();
                    IOtroPagoService otroPagoService = ServiceClient<IOtroPagoService>.GetService("OtroPagoService");
                    oOtroPago = otroPagoService.GetOtroPago(unPago.IdPago);
                    myRowDatos.Cells.Add("OTRO PAGO");
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oOtroPago.Numero.ToString()) ? string.Empty : oOtroPago.Numero.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oOtroPago.Banco.ToString())?string.Empty:oOtroPago.Banco.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oOtroPago.Sucursal.ToString()) ? string.Empty:oOtroPago.Sucursal.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oOtroPago.Cuit.ToString())?string.Empty:oOtroPago.Cuit.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oOtroPago.Importe.ToString())?string.Empty:oOtroPago.Importe.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oOtroPago.Emision.ToString())?string.Empty:oOtroPago.Importe.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oOtroPago.Vencimiento.ToString())? string.Empty:oOtroPago.Importe.ToString());
                    sheet.Table.Rows.Add(myRowDatos);
                    break;
                case "DESCUENTO":

                    DescuentoDataContracts oDescuento = new DescuentoDataContracts();
                    IDescuentoService descuentoService = ServiceClient<IDescuentoService>.GetService("DescuentoService");
                    oDescuento = descuentoService.GetDescuento(unPago.IdPago);
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oDescuento.Numero.ToString())? string.Empty:oDescuento.Numero.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oDescuento.Banco.ToString())? string.Empty:oDescuento.Banco.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oDescuento.Sucursal.ToString()) ? string.Empty : oDescuento.Sucursal.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oDescuento.Cuit.ToString()) ? string.Empty : oDescuento.Cuit.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oDescuento.Importe.ToString()) ? string.Empty : oDescuento.Importe.ToString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oDescuento.Emision.ToString()) ? string.Empty : oDescuento.Emision.ToShortDateString());
                    myRowDatos.Cells.Add(string.IsNullOrEmpty(oDescuento.Vencimiento.ToString()) ? string.Empty : oDescuento.Vencimiento.ToShortDateString());
                    sheet.Table.Rows.Add(myRowDatos);
                    break;
            }
            #endregion
        }

        sheet.Table.Rows.Add(myRowBlank);
        }

        try
        {
            System.IO.File.Delete(Server.MapPath("Files\\Deposito.xls"));
        }
        catch (Exception)
        {


        }
        
        book.Save(Server.MapPath(".") + "\\Files\\Deposito.xls");
                Response.ClearContent();
                Response.AppendHeader("content-disposition", "attachment;filename=Deposito.xls");
                Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.WriteFile("/Vistas/Files/Deposito.xls");
                Response.Charset = "";
                Response.Flush();
       ///finnnn
    }




    //private void CreaarPdf(int idRemision)
    //{
    //    RemisionDataContracts oRemision = new RemisionDataContracts();
    //    IRemisionService remisionService = ServiceClient<IRemisionService>.GetService("RemisionService");
    //    oRemision = remisionService.GetRemision(idRemision);

    //    List<ReciboDataContracts> lstRecibo = new List<ReciboDataContracts>();
    //    IReciboService reciboService = ServiceClient<IReciboService>.GetService("ReciboService");
    //    lstRecibo = reciboService.GetAllRecibosByIdRemision(idRemision);

    //    //Se declara un nuevo objeto documento
    //    iTextSharp.text.Document oDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
    //    //Ruta donde se guardan los pdf y las imagenes y el nombre del archivo
    //    string pszRuta = Server.MapPath("../PDF");
    //    string pszImagenes = Server.MapPath("../Images");
    //    string pszArchivo = "/Remision" + idRemision.ToString() + ".pdf";
    //    try
    //    {
    //        //Se obtiene la instancia y se abre el documento:
    //        PdfWriter.GetInstance(oDoc, new FileStream(pszRuta + pszArchivo, FileMode.Create));
    //        oDoc.Open();
    //        //Trabajar con el documento:
    //        iTextSharp.text.Image fotoEmacsa = iTextSharp.text.Image.GetInstance(pszImagenes + "/fotoEmacsa.png");
    //        //fotoEmacsa.ScalePercent(24f);
    //        fotoEmacsa.ScaleAbsoluteWidth(oDoc.PageSize.Width);
    //        fotoEmacsa.ScaleAbsoluteHeight(124f);
    //        fotoEmacsa.SetAbsolutePosition(1f, oDoc.PageSize.Height - 98f);
    //        oDoc.Add(fotoEmacsa);

    //        iTextSharp.text.Chunk oChunk = new iTextSharp.text.Chunk("EMAC S.A.", iTextSharp.text.FontFactory.GetFont("dax-black", 24f));
    //        oChunk.SetUnderline(1.5f, -7.5f);

    //        string pszHeader = "\n\nNúmero de Remisión:         " + idRemision.ToString() + "                                            Fecha de Remisión:          " + DateTime.Now.Date.ToShortDateString();
    //        iTextSharp.text.Chunk chnkHeader = new iTextSharp.text.Chunk(pszHeader, iTextSharp.text.FontFactory.GetFont("Arial", 10f));

    //        iTextSharp.text.Phrase oPhrase = new iTextSharp.text.Phrase();
    //        oPhrase.Add(oChunk);
    //        oPhrase.Add(chnkHeader);
    //        oDoc.Add(oPhrase);

    //        //Creacion de fuente
    //        iTextSharp.text.pdf.BaseFont bfTimes = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, false);
    //        iTextSharp.text.Font fTimes = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

    //        if (lstRecibo.Count == 0)
    //        {
    //            string pszSinDatos = "\n\nRemisión de valores sin recibos cargados...";

    //            iTextSharp.text.Phrase oPhrase2 = new iTextSharp.text.Phrase(pszSinDatos, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.RED));

    //            oDoc.Add(oPhrase2);

    //            oDoc.Close();
    //            return;
    //        }

    //        string pszEmpresaCliente = "\n\nEmpresa:               " + lstRecibo[0].Cliente.NOMBRE + "\nCliente:                 " + lstRecibo[0].Deudor.Nombre + "           (" + lstRecibo[0].Deudor.IdDeudor.ToString() + ")\n";
    //        iTextSharp.text.Chunk chnkEmpresaCliente = new iTextSharp.text.Chunk(pszEmpresaCliente, fTimes);
    //        iTextSharp.text.Phrase obPhrase = new iTextSharp.text.Phrase();
    //        obPhrase.Add(chnkEmpresaCliente);
    //        oDoc.Add(obPhrase);

    //        iTextSharp.text.pdf.draw.LineSeparator oSeparador = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, iTextSharp.text.BaseColor.BLACK, 0, 0f);
    //        iTextSharp.text.Chunk chnkSeparador = new iTextSharp.text.Chunk(oSeparador);
    //        oDoc.Add(chnkSeparador);

    //        //Aca empieza el laburo groso. Este proceso se debería repetir por cada recibo:
    //        foreach (ReciboDataContracts oRecibo in lstRecibo)
    //        {
    //            //Armar la tabla con la cabecera: Cambio | Recibo | Fecha
    //            PdfPTable oTabla = new PdfPTable(3);

    //            PdfPCell CeldaCambio = new PdfPCell(new iTextSharp.text.Phrase("Cambio: $ " + oRecibo.TipoDeCambio.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //            oTabla.AddCell(CeldaCambio);

    //            PdfPCell CeldaRecibo = new PdfPCell(new iTextSharp.text.Phrase("Recibo: " + oRecibo.Numero, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //            oTabla.AddCell(CeldaRecibo);

    //            PdfPCell CeldaFecha = new PdfPCell(new iTextSharp.text.Phrase("Fecha de Recibo: " + oRecibo.FechaCarga.ToString().Substring(0, 10), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //            oTabla.AddCell(CeldaFecha);

    //            PdfPRow pdfpRow = oTabla.Rows[0];
    //            foreach (PdfPCell pc in pdfpRow.GetCells())
    //            {
    //                pc.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
    //                pc.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
    //                pc.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
    //            }

    //            oDoc.Add(oTabla);
    //            //Armar la tabla con pagos (Numero | Tipo | Importe) e Imputaciones (Id_Factura | TipoCompr. + Letra + Emision | Imputado)

    //            #region Armado de Tabla
    //            PdfPTable oTablaPagosImputaciones = new PdfPTable(7);

    //            PdfPCell CeldaPagos = new PdfPCell(new iTextSharp.text.Phrase("PAGOS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 08f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
    //            CeldaPagos.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaPagos.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

    //            CeldaPagos.Colspan = 4;
    //            oTablaPagosImputaciones.AddCell(CeldaPagos);

    //            PdfPCell CeldaImputaciones = new PdfPCell(new iTextSharp.text.Phrase("IMPUTACIONES", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 08f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
    //            CeldaImputaciones.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaImputaciones.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
    //            CeldaImputaciones.Colspan = 3;
    //            oTablaPagosImputaciones.AddCell(CeldaImputaciones);

    //            PdfPCell CeldaFechaPago = new PdfPCell(new iTextSharp.text.Phrase("Fecha", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
    //            CeldaFechaPago.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaFechaPago.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            oTablaPagosImputaciones.AddCell(CeldaFechaPago);

    //            PdfPCell CeldaNumPago = new PdfPCell(new iTextSharp.text.Phrase("Número", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
    //            CeldaNumPago.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaNumPago.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            oTablaPagosImputaciones.AddCell(CeldaNumPago);

    //            PdfPCell CeldaImportePago = new PdfPCell(new iTextSharp.text.Phrase("Importe", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
    //            CeldaImportePago.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaImportePago.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            oTablaPagosImputaciones.AddCell(CeldaImportePago);

    //            PdfPCell CeldaTipoPago = new PdfPCell(new iTextSharp.text.Phrase("Tipo", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
    //            CeldaTipoPago.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaTipoPago.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            oTablaPagosImputaciones.AddCell(CeldaTipoPago);

    //            PdfPCell CeldaIdFact = new PdfPCell(new iTextSharp.text.Phrase("Id. Factura", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
    //            CeldaIdFact.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaIdFact.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            oTablaPagosImputaciones.AddCell(CeldaIdFact);

    //            PdfPCell CeldaDocFact = new PdfPCell(new iTextSharp.text.Phrase("Documento", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
    //            CeldaDocFact.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaDocFact.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            oTablaPagosImputaciones.AddCell(CeldaDocFact);

    //            PdfPCell CeldaImpFact = new PdfPCell(new iTextSharp.text.Phrase("Imputado", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
    //            CeldaImpFact.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
    //            CeldaImpFact.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            oTablaPagosImputaciones.AddCell(CeldaImpFact);

    //            #endregion

    //            //Armado de Tabla Pagos: Obtener todos los pagos de un recibo
    //            List<ReciboPagoDataContracts> lstReciboPagos = new List<ReciboPagoDataContracts>();
    //            IReciboPagoService recibopagoService = ServiceClient<IReciboPagoService>.GetService("ReciboPagoService");
    //            lstReciboPagos = recibopagoService.GetAllReciboPagosByIdRecibo(oRecibo.Id);
    //            //Armar la lista real de pagos
    //            List<PagoDataContracts> lstPagos = new List<PagoDataContracts>();
    //            foreach (ReciboPagoDataContracts oReciboPago in lstReciboPagos)
    //            {
    //                //Definir el tipo de pago y buscar los valores que correspondan: Fecha, IdPago, Forma,
    //                PagoDataContracts unPago = new PagoDataContracts();
    //                unPago.IdPago = oReciboPago.IdPago;
    //                unPago.FormaPago = new FormaPagoDataContracts();
    //                unPago.FormaPago.Descripcion = oReciboPago.FormaPago;
    //                #region Switch Forma de Pago
    //                switch (unPago.FormaPago.Descripcion)
    //                {
    //                    case "CHEQUE":

    //                        ChequeDataContracts oCheque = new ChequeDataContracts();
    //                        IChequeService chequeService = ServiceClient<IChequeService>.GetService("ChequeService");
    //                        oCheque = chequeService.GetCheque(unPago.IdPago);
    //                        unPago.FechaPago = oCheque.Vencimiento;
    //                        unPago.Importe = oCheque.Importe;
    //                        unPago.IdMoneda = oReciboPago.IdMoneda;
    //                        unPago.TotalPesificado = oReciboPago.TotalPesificado;
    //                        break;
    //                    case "EFECTIVO":

    //                        EfectivoDataContracts oEfectivo = new EfectivoDataContracts();
    //                        IEfectivoService efectivoService = ServiceClient<IEfectivoService>.GetService("EfectivoService");
    //                        oEfectivo = efectivoService.GetEfectivo(unPago.IdPago);
    //                        unPago.FechaPago = oEfectivo.FechaPago;
    //                        unPago.Importe = oEfectivo.Monto;
    //                        unPago.IdMoneda = oReciboPago.IdMoneda;
    //                        unPago.TotalPesificado = oReciboPago.TotalPesificado;
    //                        break;
    //                    case "RETENCION":
    //                        RetencionDataContracts oRetencion = new RetencionDataContracts();
    //                        IRetencionService retencionService = ServiceClient<IRetencionService>.GetService("RetencionService");
    //                        oRetencion = retencionService.GetRetencion(unPago.IdPago);
    //                        unPago.FechaPago = oRetencion.FechaPago;
    //                        unPago.Importe = oRetencion.Importe;
    //                        unPago.IdMoneda = oReciboPago.IdMoneda;
    //                        unPago.TotalPesificado = oReciboPago.TotalPesificado;
    //                        break;
    //                    case "DEPOSITO":

    //                        DepositoDataContracts oDeposito = new DepositoDataContracts();
    //                        IDepositoService depositoService = ServiceClient<IDepositoService>.GetService("DepositoService");
    //                        oDeposito = depositoService.GetDeposito(unPago.IdPago);
    //                        unPago.FechaPago = oDeposito.FechaCarga;
    //                        unPago.Importe = oDeposito.Importe;
    //                        unPago.IdMoneda = oReciboPago.IdMoneda;
    //                        unPago.TotalPesificado = oReciboPago.TotalPesificado;
    //                        break;
    //                    case "TRANSFERENCIA":

    //                        TransferenciaDataContracts oTransferencia = new TransferenciaDataContracts();
    //                        ITransferenciaService transferenciaService = ServiceClient<ITransferenciaService>.GetService("TransferenciaService");
    //                        oTransferencia = transferenciaService.GetTransferencia(unPago.IdPago);
    //                        unPago.FechaPago = oTransferencia.FechaCarga;
    //                        unPago.Importe = oTransferencia.Importe;
    //                        unPago.IdMoneda = oReciboPago.IdMoneda;
    //                        unPago.TotalPesificado = oReciboPago.TotalPesificado;
    //                        break;
    //                    case "OTRO":

    //                        OtroPagoDataContracts oOtroPago = new OtroPagoDataContracts();
    //                        IOtroPagoService otroPagoService = ServiceClient<IOtroPagoService>.GetService("OtroPagoService");
    //                        oOtroPago = otroPagoService.GetOtroPago(unPago.IdPago);
    //                        unPago.FechaPago = oOtroPago.FechaCarga;
    //                        unPago.Importe = oOtroPago.Importe;
    //                        unPago.IdMoneda = oReciboPago.IdMoneda;
    //                        unPago.TotalPesificado = oReciboPago.TotalPesificado;
    //                        break;
    //                    case "DESCUENTO":

    //                        DescuentoDataContracts oDescuento = new DescuentoDataContracts();
    //                        IDescuentoService descuentoService = ServiceClient<IDescuentoService>.GetService("DescuentoService");
    //                        oDescuento = descuentoService.GetDescuento(unPago.IdPago);
    //                        unPago.FechaPago = oDescuento.FechaCarga;
    //                        unPago.Importe = oDescuento.Importe;
    //                        unPago.IdMoneda = oReciboPago.IdMoneda;
    //                        unPago.TotalPesificado = oReciboPago.TotalPesificado;
    //                        break;
    //                }
    //                #endregion
    //                lstPagos.Add(unPago);

    //            }

    //            PdfPTable oTblPagos = new PdfPTable(4);
    //            double ImportePagoTotal = 0;
    //            foreach (PagoDataContracts oPago in lstPagos)
    //            {
    //                PdfPCell CeldaFechaPagoV = new PdfPCell(new iTextSharp.text.Phrase(oPago.FechaPago.Date.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //                oTblPagos.AddCell(CeldaFechaPagoV);

    //                PdfPCell CeldaIdPagoV = new PdfPCell(new iTextSharp.text.Phrase(oPago.IdPago.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //                oTblPagos.AddCell(CeldaIdPagoV);

    //                PdfPCell CeldaImporteDePagoV = new PdfPCell(new iTextSharp.text.Phrase("(" + TomarSimboloMoneda(oPago.IdMoneda) + ") " + oPago.Importe.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //                oTblPagos.AddCell(CeldaImporteDePagoV);

    //                PdfPCell CeldaTipoDePagoV = new PdfPCell(new iTextSharp.text.Phrase(oPago.FormaPago.Descripcion, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //                oTblPagos.AddCell(CeldaTipoDePagoV);

    //                ImportePagoTotal += oPago.TotalPesificado;
    //            }


    //            PdfPCell CeldaTablaPagos = new PdfPCell(oTblPagos);
    //            CeldaTablaPagos.Colspan = 4;

    //            foreach (PdfPRow Fila1 in oTblPagos.Rows)
    //            {
    //                foreach (PdfPCell Celda1 in Fila1.GetCells())
    //                {
    //                    Celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //                    Celda1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
    //                }
    //            }

    //            oTablaPagosImputaciones.AddCell(CeldaTablaPagos);

    //            //Armado de Tabla Imputaciones
    //            List<ReciboFacturaDataContracts> lstReciboFacturas = new List<ReciboFacturaDataContracts>();
    //            IReciboFacturaService recibofacturaService = ServiceClient<IReciboFacturaService>.GetService("ReciboFacturaService");
    //            lstReciboFacturas = recibofacturaService.GetAllReciboFacturasByIdRecibo(oRecibo.Id);
                

    //            PdfPTable oTblImputaciones = new PdfPTable(3);
    //            double ImporteImputacionesTotal = 0;
    //            foreach (ReciboFacturaDataContracts oReciboFactura in lstReciboFacturas)
    //            {
    //                PdfPCell CeldaIdFactura = new PdfPCell(new iTextSharp.text.Phrase(oReciboFactura.IdFactura.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //                oTblImputaciones.AddCell(CeldaIdFactura);

    //                FacturaDataContracts oFactura = new FacturaDataContracts();
    //                IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
    //                oFactura = facturaService.GetFactura(oReciboFactura.IdFactura);

    //                string pszDocumento = oFactura.Id_Tipo_Comprobante + " " + oFactura.Letra + " " + oFactura.Emision + "-" + oFactura.NumeroComp;

    //                PdfPCell CeldaDocumentoFact = new PdfPCell(new iTextSharp.text.Phrase(pszDocumento, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //                oTblImputaciones.AddCell(CeldaDocumentoFact);

    //                PdfPCell CeldaImporteAImputar;
    //                if (oFactura.Moneda == "PE")
    //                {
    //                    CeldaImporteAImputar = new PdfPCell(new iTextSharp.text.Phrase("($)"+AplicarFormatoADoble(oReciboFactura.ImporteAImputar).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //                    ImporteImputacionesTotal += oReciboFactura.ImporteAImputar;
    //                }
    //                else
    //                {
    //                    CeldaImporteAImputar = new PdfPCell(new iTextSharp.text.Phrase("(u$d)" + AplicarFormatoADoble(oReciboFactura.ImporteAImputar).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //                    double multRes = oRecibo.TipoDeCambio * oReciboFactura.ImporteAImputar;
    //                    ImporteImputacionesTotal += multRes;
                    
    //                }
    //                oTblImputaciones.AddCell(CeldaImporteAImputar);

                    
    //            }

    //            PdfPCell CeldaTablaImputaciones = new PdfPCell(oTblImputaciones);
    //            CeldaTablaImputaciones.Colspan = 3;

    //            foreach (PdfPRow Fila2 in oTblImputaciones.Rows)
    //            {
    //                foreach (PdfPCell Celda2 in Fila2.GetCells())
    //                {
    //                    Celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //                    Celda2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
    //                }
    //            }

    //            oTablaPagosImputaciones.AddCell(CeldaTablaImputaciones);

    //            //Totales de pagos y totales de imputaciones
    //            PdfPCell CeldaTotalPagos = new PdfPCell(new iTextSharp.text.Phrase("Total de pagos de " + oRecibo.Numero + ":       $ " + AplicarFormatoADoble(ImportePagoTotal).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //            CeldaTotalPagos.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
    //            CeldaTotalPagos.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
    //            CeldaTotalPagos.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
    //            CeldaTotalPagos.Colspan = 4;
    //            oTablaPagosImputaciones.AddCell(CeldaTotalPagos);

    //            PdfPCell CeldaTotalImputaciones = new PdfPCell(new iTextSharp.text.Phrase("Imputado en recibo  " + oRecibo.Numero + ":       $ " + AplicarFormatoADoble(ImporteImputacionesTotal).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //            CeldaTotalImputaciones.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
    //            CeldaTotalImputaciones.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
    //            CeldaTotalImputaciones.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
    //            CeldaTotalImputaciones.Colspan = 3;
    //            oTablaPagosImputaciones.AddCell(CeldaTotalImputaciones);

    //            oDoc.Add(oTablaPagosImputaciones);

    //            PdfPTable oTblCompensaciones = new PdfPTable(1);

    //            ICompensacionDePagoService compensacionDePagoService = ServiceClient<ICompensacionDePagoService>.GetService("CompensacionDePagoService");

    //            CompensacionDePagoDataContracts compensacion = compensacionDePagoService.GetCompensacionDePagoPorNumeroDeRecibo(oRecibo.Numero);

    //            PdfPCell CeldaCompensaciones = new PdfPCell(new iTextSharp.text.Phrase("Saldo a favor: $ " + AplicarFormatoADoble(compensacion.Monto).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
    //            CeldaCompensaciones.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
    //            CeldaCompensaciones.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
    //            CeldaCompensaciones.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
    //            CeldaCompensaciones.Colspan = 4;
    //            oTblCompensaciones.AddCell(CeldaCompensaciones);

    //            oDoc.Add(oTblCompensaciones);

    //            oDoc.Add(chnkSeparador);
    //        }

    //    }
    //    catch (iTextSharp.text.DocumentException dEx)
    //    {
    //        //Response.Write(dEx.Message);
    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "errorPdf", "javascript:alert('"+ dEx.Message +"');", true);
    //    }
    //    catch (IOException ioEx)
    //    {
    //        //Response.Write(ioEx.Message);
    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "errorPdf", "javascript:alert('" + ioEx.Message + "');", true);
    //    }
    //    catch (Exception ex)
    //    {
    //        //  Response.Write(ex.Message);
    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "errorPdf", "javascript:alert('" +ex.Message + "');", true);
    //    }
    //    finally
    //    {
    //        //Cerrar el documento
    //        oDoc.Close();
    //    }

    //}

    private double AplicarFormatoADoble(double input)
    {
        if (input == 0)
        {
            return 0;
        }

        return double.Parse(string.Format("{0:#,#########.####}", input));
    }


    private string TomarSimboloMoneda(int idMoneda)
    {
        switch (idMoneda)
        {
            case 1:
                return "$";
                break;

            case 2:
                return "u$d";
                break;
            default:
                return "$";
                break;

        }

    }




}