using System;
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
using System.util;


public partial class Vistas_ViewGeneracionEspecialEnExcel : GobbiPage
{
    String numIdentificatorio;

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
        WorksheetRow myRowHeader = new WorksheetRow();

        foreach (ReciboDataContracts oRecibo in lstRecibo)
        {

            WorksheetRow headerRow = new WorksheetRow();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            //headerRow.Cells.Add();
            headerRow.Cells.Capacity = 10;
            headerRow.Cells.Insert(0, new WorksheetCell("101"));
            headerRow.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
            headerRow.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
            headerRow.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
            headerRow.Cells.Insert(4, new WorksheetCell("PES"));
            headerRow.Cells.Insert(5, new WorksheetCell(oRecibo.FechaCarga.ToShortDateString()));
            headerRow.Cells.Insert(6, new WorksheetCell("MAT"));
            sheet.Table.Rows.Add(headerRow);

            //Armado de Tabla Pagos: Obtener todos los pagos de un recibo
            List<ReciboPagoDataContracts> lstReciboPagos = new List<ReciboPagoDataContracts>();
            IReciboPagoService recibopagoService = ServiceClient<IReciboPagoService>.GetService("ReciboPagoService");
            lstReciboPagos = recibopagoService.GetAllReciboPagosByIdRecibo(oRecibo.Id);

            //Armar la lista real de pagos
            List<PagoDataContracts> lstPagos = new List<PagoDataContracts>();
            foreach (ReciboPagoDataContracts oReciboPago in lstReciboPagos)
            {


                //Definir el tipo de pago y buscar los valores que correspondan: Fecha, IdPago, Forma,
                PagoDataContracts unPago = new PagoDataContracts();
                unPago.IdPago = oReciboPago.IdPago;
                unPago.FormaPago = new FormaPagoDataContracts();
                unPago.FormaPago.Descripcion = oReciboPago.FormaPago;

                numIdentificatorio = string.Empty;
                //WorksheetRow myRowDatos = new WorksheetRow();
                //myRowDatos.Cells.Capacity = 10;

                //myRowDatos.Cells.Insert(0, new WorksheetCell(string.Empty));
                //myRowDatos.Cells.Insert(1,new WorksheetCell(idRemision.ToString()));
                //myRowDatos.Cells.Insert(2,new WorksheetCell(oRecibo.Numero.ToString()));
                //myRowDatos.Cells.Insert(3,new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));

                #region Switch Forma de Pago
                switch (unPago.FormaPago.Descripcion)
                {
                    case "CHEQUE":

                        ChequeDataContracts oCheque = new ChequeDataContracts();
                        IChequeService chequeService = ServiceClient<IChequeService>.GetService("ChequeService");
                        oCheque = chequeService.GetCheque(unPago.IdPago);
                        WorksheetRow myRowDatos = new WorksheetRow();
                        myRowDatos.Cells.Capacity = 10;
                        myRowDatos.Cells.Insert(0, new WorksheetCell("102"));
                        myRowDatos.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
                        myRowDatos.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
                        myRowDatos.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
                        myRowDatos.Cells.Insert(4, new WorksheetCell("CH"));
                        myRowDatos.Cells.Insert(5, new WorksheetCell(oCheque.Numero.ToString()));
                        myRowDatos.Cells.Insert(6, new WorksheetCell(oCheque.Banco.ToString()));
                        myRowDatos.Cells.Insert(7, new WorksheetCell(oCheque.Vencimiento.ToShortDateString()));
                        myRowDatos.Cells.Insert(8, new WorksheetCell(oCheque.Importe.ToString()));
                        myRowDatos.Cells.Insert(9, new WorksheetCell(oRecibo.Deudor.Cuit));
                        sheet.Table.Rows.Add(myRowDatos);

                        break;
                    case "EFECTIVO":

                        EfectivoDataContracts oEfectivo = new EfectivoDataContracts();
                        IEfectivoService efectivoService = ServiceClient<IEfectivoService>.GetService("EfectivoService");
                        oEfectivo = efectivoService.GetEfectivo(unPago.IdPago);
                        WorksheetRow myRowDatosE = new WorksheetRow();
                        myRowDatosE.Cells.Capacity = 10;
                        myRowDatosE.Cells.Insert(0, new WorksheetCell("102"));
                        myRowDatosE.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
                        myRowDatosE.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
                        myRowDatosE.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
                        myRowDatosE.Cells.Insert(4, new WorksheetCell("REI"));
                        myRowDatosE.Cells.Insert(5, new WorksheetCell(string.Empty));
                        myRowDatosE.Cells.Insert(6, new WorksheetCell(string.Empty));
                        myRowDatosE.Cells.Insert(7, new WorksheetCell(string.Empty));
                        myRowDatosE.Cells.Insert(8, new WorksheetCell(oEfectivo.Monto.ToString()));
                        myRowDatosE.Cells.Insert(9, new WorksheetCell(oRecibo.Deudor.Cuit));
                        sheet.Table.Rows.Add(myRowDatosE);


                        break;
                    case "RETENCION":
                        RetencionDataContracts oRetencion = new RetencionDataContracts();
                        IRetencionService retencionService = ServiceClient<IRetencionService>.GetService("RetencionService");
                        oRetencion = retencionService.GetRetencion(unPago.IdPago);
                        WorksheetRow myRowDatosR = new WorksheetRow();
                        myRowDatosR.Cells.Capacity = 10;
                        myRowDatosR.Cells.Insert(0, new WorksheetCell("102"));
                        myRowDatosR.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
                        myRowDatosR.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
                        myRowDatosR.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
                        myRowDatosR.Cells.Insert(4, new WorksheetCell("CRI"));
                        myRowDatosR.Cells.Insert(5, new WorksheetCell(oRetencion.NumeroRetencion.ToString()));
                        myRowDatosR.Cells.Insert(6, new WorksheetCell("0"));
                        myRowDatosR.Cells.Insert(7, new WorksheetCell(oRetencion.FechaPago.ToShortDateString()));
                        myRowDatosR.Cells.Insert(8, new WorksheetCell(oRetencion.Importe.ToString()));
                        myRowDatosR.Cells.Insert(9, new WorksheetCell(oRecibo.Deudor.Cuit));
                        sheet.Table.Rows.Add(myRowDatosR);

                        break;
                    case "DEPOSITO":

                        DepositoDataContracts oDeposito = new DepositoDataContracts();
                        IDepositoService depositoService = ServiceClient<IDepositoService>.GetService("DepositoService");
                        oDeposito = depositoService.GetDeposito(unPago.IdPago);
                        WorksheetRow myRowDatosD = new WorksheetRow();
                        myRowDatosD.Cells.Capacity = 10;
                        myRowDatosD.Cells.Insert(0, new WorksheetCell("999"));
                        myRowDatosD.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
                        myRowDatosD.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
                        myRowDatosD.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
                        myRowDatosD.Cells.Insert(4, new WorksheetCell("DEP"));
                        myRowDatosD.Cells.Insert(5, new WorksheetCell(string.Empty));
                        myRowDatosD.Cells.Insert(6, new WorksheetCell(string.Empty));
                        myRowDatosD.Cells.Insert(7, new WorksheetCell(string.Empty));
                        myRowDatosD.Cells.Insert(8, new WorksheetCell(string.Empty));
                        myRowDatosD.Cells.Insert(9, new WorksheetCell(string.Empty));
                        sheet.Table.Rows.Add(myRowDatosD);
                        break;
                    case "TRANSFERENCIA":

                        TransferenciaDataContracts oTransferencia = new TransferenciaDataContracts();
                        ITransferenciaService transferenciaService = ServiceClient<ITransferenciaService>.GetService("TransferenciaService");
                        oTransferencia = transferenciaService.GetTransferencia(unPago.IdPago);
                        WorksheetRow myRowDatosT = new WorksheetRow();
                        myRowDatosT.Cells.Capacity = 10;
                        myRowDatosT.Cells.Insert(0, new WorksheetCell("999"));
                        myRowDatosT.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
                        myRowDatosT.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
                        myRowDatosT.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
                        myRowDatosT.Cells.Insert(4, new WorksheetCell("TRS"));
                        myRowDatosT.Cells.Insert(5, new WorksheetCell(string.Empty));
                        myRowDatosT.Cells.Insert(6, new WorksheetCell(string.Empty));
                        myRowDatosT.Cells.Insert(7, new WorksheetCell(string.Empty));
                        myRowDatosT.Cells.Insert(8, new WorksheetCell(string.Empty));
                        myRowDatosT.Cells.Insert(9, new WorksheetCell(string.Empty));
                        sheet.Table.Rows.Add(myRowDatosT);
                        break;
                    case "OTRO":

                        OtroPagoDataContracts oOtroPago = new OtroPagoDataContracts();
                        IOtroPagoService otroPagoService = ServiceClient<IOtroPagoService>.GetService("OtroPagoService");
                        oOtroPago = otroPagoService.GetOtroPago(unPago.IdPago);
                        WorksheetRow myRowDatosO = new WorksheetRow();
                        myRowDatosO.Cells.Capacity = 10;
                        myRowDatosO.Cells.Insert(0, new WorksheetCell("999"));
                        myRowDatosO.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
                        myRowDatosO.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
                        myRowDatosO.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
                        myRowDatosO.Cells.Insert(4, new WorksheetCell("OPA"));
                        myRowDatosO.Cells.Insert(5, new WorksheetCell(string.Empty));
                        myRowDatosO.Cells.Insert(6, new WorksheetCell(string.Empty));
                        myRowDatosO.Cells.Insert(7, new WorksheetCell(string.Empty));
                        myRowDatosO.Cells.Insert(8, new WorksheetCell(string.Empty));
                        myRowDatosO.Cells.Insert(9, new WorksheetCell(string.Empty));
                        sheet.Table.Rows.Add(myRowDatosO);
                        break;
                    case "DESCUENTO":

                        DescuentoDataContracts oDescuento = new DescuentoDataContracts();
                        IDescuentoService descuentoService = ServiceClient<IDescuentoService>.GetService("DescuentoService");
                        oDescuento = descuentoService.GetDescuento(unPago.IdPago);
                        WorksheetRow myRowDatosDE = new WorksheetRow();
                        myRowDatosDE.Cells.Capacity = 10;
                        myRowDatosDE.Cells.Insert(0, new WorksheetCell("999"));
                        myRowDatosDE.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
                        myRowDatosDE.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
                        myRowDatosDE.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
                        myRowDatosDE.Cells.Insert(4, new WorksheetCell("DES"));
                        myRowDatosDE.Cells.Insert(5, new WorksheetCell(string.Empty));
                        myRowDatosDE.Cells.Insert(6, new WorksheetCell(string.Empty));
                        myRowDatosDE.Cells.Insert(7, new WorksheetCell(string.Empty));
                        myRowDatosDE.Cells.Insert(8, new WorksheetCell(string.Empty));
                        myRowDatosDE.Cells.Insert(9, new WorksheetCell(string.Empty));
                        sheet.Table.Rows.Add(myRowDatosDE);
                        break;
                }
                #endregion

            }

            List<ReciboFacturaDataContracts> lstReciboFacturas = new List<ReciboFacturaDataContracts>();
            IReciboFacturaService recibofaturaService = ServiceClient<IReciboFacturaService>.GetService("ReciboFacturaService");
            lstReciboFacturas = recibofaturaService.GetAllReciboFacturasByIdRecibo(oRecibo.Id);
            foreach (ReciboFacturaDataContracts oReciboFactura in lstReciboFacturas)
            {
                WorksheetRow myRowFactura = new WorksheetRow();
                myRowFactura.Cells.Capacity = 10;
                FacturaDataContracts oFactura = new FacturaDataContracts();
                IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
                oFactura = facturaService.GetFactura(oReciboFactura.IdFactura);
                myRowFactura.Cells.Insert(0, new WorksheetCell("103"));
                myRowFactura.Cells.Insert(1, new WorksheetCell(idRemision.ToString()));
                myRowFactura.Cells.Insert(2, new WorksheetCell(oRecibo.Numero.ToString()));
                myRowFactura.Cells.Insert(3, new WorksheetCell(oRecibo.Deudor.AlfaNumDelCliente.ToString()));
                myRowFactura.Cells.Insert(4, new WorksheetCell("FC"));
                myRowFactura.Cells.Insert(5, new WorksheetCell(oFactura.Letra));
                myRowFactura.Cells.Insert(6, new WorksheetCell(oFactura.Emision.ToString()));
                myRowFactura.Cells.Insert(7, new WorksheetCell(oFactura.NumeroComp.ToString()));
                myRowFactura.Cells.Insert(8, new WorksheetCell(oFactura.Importe.ToString()));
                myRowFactura.Cells.Insert(9, new WorksheetCell(string.Empty));
                sheet.Table.Rows.Add(myRowFactura);

            }

            ICompensacionDePagoService compensacionDePagoService = ServiceClient<ICompensacionDePagoService>.GetService("CompensacionDePagoService");
            CompensacionDePagoDataContracts compensacion = compensacionDePagoService.GetCompensacionDePagoPorNumeroDeRecibo(oRecibo.Numero);

            WorksheetRow myRowCompensacion = new WorksheetRow();
            myRowCompensacion.Cells.Add("102");
            myRowCompensacion.Cells.Add(idRemision.ToString());
            myRowCompensacion.Cells.Add(oRecibo.Numero.ToString());
            myRowCompensacion.Cells.Add(oRecibo.Deudor.AlfaNumDelCliente.ToString());
            myRowCompensacion.Cells.Add("DF");
            myRowCompensacion.Cells.Add("U");
            myRowCompensacion.Cells.Add(string.Empty);
            myRowCompensacion.Cells.Add(string.Empty);
            myRowCompensacion.Cells.Add(AplicarFormatoADoble(compensacion.Monto).ToString());
            sheet.Table.Rows.Add(myRowCompensacion);

        }

        try
        {
        ///    System.IO.File.Delete(Server.MapPath("Files\\ArchivoEspecial.xls"));
                   System.IO.File.Delete(Server.MapPath("Files\\ArchivoEspecial.txt"));
        }
        catch (Exception)
        {


        }
        string txtFileContent = procesarMacro(sheet.Table);
        //System.IO.File.WriteAllBytes
        System.IO.File.WriteAllText(Server.MapPath(".") + "\\Files\\ArchivoEspecial.txt", txtFileContent);

        //book.Save(Server.MapPath(".") + "\\Files\\ArchivoEspecial.xls");
        Response.ClearContent();
        //Response.AppendHeader("content-disposition", "attachment;filename=ArchivoEspecial.xls");
        Response.AppendHeader("content-disposition", "attachment;filename=ArchivoEspecial.txt");
        //Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.ContentType = "application/octet-stream";
        Response.ContentEncoding = System.Text.Encoding.Default;
        //Response.WriteFile("/Vistas/Files/ArchivoEspecial.xls");
        Response.Flush();
        Response.WriteFile("/Vistas/Files/ArchivoEspecial.txt");
        //Response.Charset = "";
        Response.End();

        ///finnnn
    }

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


    private string procesarMacro(WorksheetTable hoja1)
    {

        int I = 0;
        string s = string.Empty;
        string hoja2 = string.Empty;
        //I = 1
        string sTipoRegistro = string.Empty; //Dim sTipoRegistro As String
        string sArchivo = string.Empty; //Dim sArchivo As String
        string sLinea = string.Empty; //Dim sLinea As String
        string importe = string.Empty;

        // TODO: Hoja1.Cells.NumberFormat = "General"
        // TODO: Hoja2.Cells.Clear
        bool bChequeRechazado;//Dim bChequeRechazado As Boolean
        while (I < hoja1.Rows.Count)
        {

            for (int x = 0; x < 9; x++)
            {
                try
                {
                    if (!hoja1.Rows[I].Cells[x].Data.Type.Equals(DataType.String))
                    {
                        hoja1.Rows[I].Cells[x].Data.Text = hoja1.Rows[I].Cells[x].Data.Text;
                    }
                }
                catch (Exception ex)
                {
                }
            }

            sTipoRegistro = hoja1.Rows[I].Cells[0].Data.Text;
            s = hoja1.Rows[I].Cells[2].Data.Text;
            if (s.IndexOf("0000-") != -1)
            {
                s = s.Substring(("0000-".Length + 1));
                s = new String('0', 8 - s.Length) + s;
                hoja1.Rows[I].Cells[2].Data.Text = s;
            }

            bChequeRechazado = false;

            s = hoja1.Rows[I].Cells[4].Data.Text;
            if (s == "CH")
            {
                s = "CH ";
                hoja1.Rows[I].Cells[4].Data.Text = s;

                //INI GFSB  - Cheques rechazados - 31/10/2009
                if (hoja1.Rows[I].Cells[5].Data.Text == "R")
                {
                    //MsgBox "aca"
                    hoja1.Rows[I].Cells[4].Data.Text = "CR";
                    hoja1.Rows[I].Cells[5].Data.Text = " ";
                }
                //FIN GFSB  - Cheques rechazados - 31/10/2009

            }

            bool bRetencion = false;

            if (s == "RBA")
            {
                bRetencion = true;
            }

            if (s == "REI")
            {
                bRetencion = true;
            }

            if (s == "REG")
            {
                bRetencion = true;
            }

            if (s == "RCF")
            {
                bRetencion = true;
            }

            if (s == "RCO")
            {
                bRetencion = true;
            }

            if (s == "RME")
            {
                bRetencion = true;
            }

            if (s == "RSF")
            {
                bRetencion = true;
            }

            if (s == "RSL")
            {
                bRetencion = true;
            }

            if (bRetencion)
            {
                //Los números de estos, se deben completar como los cheques,
                // es decir completar con ceros a la izquierdas, hasta llegar al numero de
                // caracteres que llevan los cheques. Es un medio de pago mas.
                bRetencion = false;
                hoja1.Rows[I].Cells[5].Data.Text = new String('0', 10 - hoja1.Rows[I].Cells[5].Data.Text.Length) + hoja1.Rows[I].Cells[5].Data.Text;

            }

            if (s == "EFE")
            {

                if (hoja1.Rows[I].Cells[5].Data.Text.ToLower() == "efectivo")
                {

                    hoja1.Rows[I].Cells[5].Data.Text = new String(' ', 10);
                }
                else
                {

                    hoja1.Rows[I].Cells[5].Data.Text = hoja1.Rows[I].Cells[5].Data.Text + new String(' ', 10 - hoja1.Rows[I].Cells[5].Data.Text.Length);
                }
            }
            if (s == "DEP" || s == "DF")
            {
                if (s == "DEP")
                {
                    //DP: Depositos, en la macro todo lo que diga DP, lo debe pooner EFE, es decir como efectivo, solo eso. Solo cambia eso
                    s = "EFE";
                    hoja1.Rows[I].Cells[4].Data.Text = s;
                }

                hoja1.Rows[I].Cells[5].Data.Text = hoja1.Rows[I].Cells[5].Data.Text + new String(' ', 10 - hoja1.Rows[I].Cells[5].Data.Text.Length);

            }

            string aa = string.Empty;
            if (sTipoRegistro == "101")
            {

                try
                {
                    hoja1.Rows[I].Cells[5].Data.Text = /*"'" +*/ DateTime.Parse(hoja1.Rows[I].Cells[5].Data.Text).ToString("dd/MM/yy");
                }
                catch (Exception)
                {
                }
                try
                {

                    hoja1.Rows[I].Cells[6].Data.Text = /*"'" +*/ DateTime.Parse(hoja1.Rows[I].Cells[5].Data.Text).ToString("dd/MM/yy");
                }
                catch (Exception)
                {
                }
            }

            aa = string.Empty;
            if (sTipoRegistro == "102")
            {
                try
                {
                    hoja1.Rows[I].Cells[7].Data.Text = DateTime.Parse(hoja1.Rows[I].Cells[7].Data.Text).ToString("dd/MM/yy");
                    aa = hoja1.Rows[I].Cells[7].Data.Text;
                }
                catch (Exception ex)
                {
                }
                if (aa == "")
                {
                    aa = hoja1.Rows[I].Cells[7].Data.Text;
                }
                if (aa.IndexOf("-") != -1)
                {
                    aa = DateTime.Parse(hoja1.Rows[I].Cells[7].Data.Text.ToString().Replace("-", "/")).ToString("dd/MM/yy");
                }
                hoja1.Rows[I].Cells[7].Data.Text = aa;

                if (hoja1.Rows[I].Cells[6].Data.Text.Length != 0 && hoja1.Rows[I].Cells[6].Data.Text != "0")
                {
                    hoja1.Rows[I].Cells[6].Data.Text = new String('0', 3 - hoja1.Rows[I].Cells[6].Data.Text.Length) + hoja1.Rows[I].Cells[6].Data.Text;// String(3 - Len(Hoja1.Cells(I, 7)), "0") & Hoja1.Cells(I, 7)
                }
                else
                {
                    if (hoja1.Rows[I].Cells[6].Data.Text == "0")
                    {
                        hoja1.Rows[I].Cells[6].Data.Text = new String(' ', 3);// String(3 - 
                    }
                }
                if (hoja1.Rows[I].Cells[4].Data.Text == "CH " || hoja1.Rows[I].Cells[4].Data.Text == "REG" ||
                    hoja1.Rows[I].Cells[4].Data.Text == "RBA")
                {
                    hoja1.Rows[I].Cells[5].Data.Text = new String(' ', 10 - hoja1.Rows[I].Cells[5].Data.Text.Length) + hoja1.Rows[I].Cells[5].Data.Text;
                }



                if (hoja1.Rows[I].Cells[8].Data.Text == "-")
                {
                    importe = hoja1.Rows[I].Cells[8].Data.Text.Substring(2);//   Mid(Hoja1.Cells(I, 9), 2)
                    hoja1.Rows[I].Cells[8].Data.Text = "-" + new String('0', 13 - Convert.ToDouble(importe).ToString("#.00").Length) + Convert.ToDouble(importe).ToString("#.00");
                    //    Hoja1.Cells(I, 9) = "'-" & String(13 - Len(Format(importe, ".00")), "0") & Format(importe, ".00")
                }
                else
                {
                    hoja1.Rows[I].Cells[8].Data.Text = new String('0', 14 - Convert.ToDouble(hoja1.Rows[I].Cells[8].Data.Text).ToString("#.00").Length) + Convert.ToDouble(hoja1.Rows[I].Cells[8].Data.Text).ToString("#.00");

                }
            }

            if (sTipoRegistro == "103")
            {

                // INI GFSB - Cheques rechazados - 30/10/2009
                if (hoja1.Rows[I].Cells[4].Data.Text == "CR")
                { //If Hoja1.Cells(I, 5) = "CR" Then
                    hoja1.Rows[I].Cells[6].Data.Text = new String(' ', 4); // Hoja1.Cells(I, 7) = String(4, " ")
                    hoja1.Rows[I].Cells[7].Data.Text = "K" + new String('0', 7 - hoja1.Rows[I].Cells[7].Data.Text.Length) + hoja1.Rows[I].Cells[7].Data.Text;
                    //Hoja1.Cells(I, 8) = "'K" & String(7 - Len(Hoja1.Cells(I, 8)), "0") & Hoja1.Cells(I, 8)
                }
                else
                {
                    hoja1.Rows[I].Cells[6].Data.Text = new String('0', 4 - hoja1.Rows[I].Cells[6].Data.Text.Length) + hoja1.Rows[I].Cells[6].Data.Text;
                    hoja1.Rows[I].Cells[7].Data.Text = new String('0', 8 - hoja1.Rows[I].Cells[7].Data.Text.Length) + hoja1.Rows[I].Cells[7].Data.Text;
                }
                // FIN GFSB - Cheques rechazados - 30/10/2009
                //Hoja1.Cells(I, 9) = "'" & String(14 - Len(Format(Hoja1.Cells(I, 9), ".00")), "0") & Format(Hoja1.Cells(I, 9), ".00")
                importe = string.Empty;

                if (hoja1.Rows[I].Cells[7].Data.Text.Substring(0, 1) == "-")
                {
                    importe = hoja1.Rows[I].Cells[8].Data.Text.Substring(2);// Mid(Hoja1.Cells(I, 9), 2)
                    hoja1.Rows[I].Cells[8].Data.Text = "-" + new String('0', 13 - Convert.ToDouble(importe).ToString("#.00").Length) + Convert.ToDouble(importe).ToString("#.00");
                }
                else
                {

                    hoja1.Rows[I].Cells[8].Data.Text = new String('0', 14 - Convert.ToDouble(importe).ToString("#.00").Length) + Convert.ToDouble(importe).ToString("#.00");
                }
            }


            sLinea = string.Empty;
            for (int x = 0; x < 9; x++)
            {
                try
                {
                    sLinea = sLinea + hoja1.Rows[I].Cells[x].Data.Text + ";";
                }
                catch (Exception ex)
                {
                }
            }


            if (sTipoRegistro == "101")
            {
                sLinea = sLinea.Substring(0, sLinea.Length - 1);//  Mid(sLinea, 1, Len(sLinea) - 1)
            }

            //INI CUIT - 24/10/2009
            string lineaHoja2 = string.Empty;
            lineaHoja2 += sLinea.Substring(0, sLinea.Length - 1);

            //Hoja2.Cells(I, 1) = Mid(sLinea, 1, Len(sLinea) - 1)
            if (sTipoRegistro == "102")
            {
                if (hoja1.Rows[I].Cells[4].Data.Text == "CH ")
                {
                    //agrego CUIT
                    lineaHoja2 = lineaHoja2 + ";" + hoja1.Rows[I].Cells[9].Data.Text;
                }
                else
                {
                    // Si no es cheque agrego punto y coma al final
                    lineaHoja2 = lineaHoja2 + ";";

                }
            }

            hoja2 += lineaHoja2 + System.Environment.NewLine;
            //FIN CUIT - 24/10/2009
            I = I + 1;
            //  sArchivo = sArchivo & sLinea & Chr(13)

        }

        return hoja2;

    }

}
