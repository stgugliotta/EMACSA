using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Implementation;
using Security;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using System.Web.Services;
using AjaxControlToolkit;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using Herramientas;
using iTextSharp;           //iTextSharp para crear PDF
using iTextSharp.text.pdf;  //idem
using System.IO;            //Manipular IO
using Gobbi.CoreServices.Security.Principal;
    


public partial class Vistas_ViewRemisionDeValoresEdicion  : GobbiPage 
{

    private bool _evitarPrerenderTextBox=false;
    private bool _evitarPrerenderGrillaFactura=false;
    private List<ReciboFacturaDataContracts> _listaFacturasSeleccionadas;

    protected void Page_Load(object sender, EventArgs e)
    {


       if (string.IsNullOrEmpty(Request.Params["idDeudor"].ToString()) || string.IsNullOrEmpty(Request.Params["idCliente"].ToString()) || string.IsNullOrEmpty(Request.Params["numRecibo"].ToString()) || string.IsNullOrEmpty(Request.Params["idRemision"].ToString()))
            Response.Redirect("ViewHome.aspx");

        if (!Page.IsPostBack)
        {
            #region Inicializacion de Vista

            this.btnCrearRemision.Enabled = false;
            this.txtFechaRecibo.Text = DateTime.Now.ToShortDateString();
            this.ddlSubTipo.Items.Clear();
            this.ddlSubTipo.Items.Add("No aplica");


            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            clientes = clienteServices.GetAllClientes();
            this.cmbClientes.DataSource = clientes;
            this.cmbClientes.DataTextField = "NOMBRE";
            this.cmbClientes.DataValueField = "idCliente";
            this.cmbClientes.DataBind();

            #region SOLAPA CHEQUES

            this.btnGuardarReciboEdicion.ValidationGroup = "reciboGroup";
            this.txtSumaFacturas.Text = "0";
            this.txtSumaFacturasExt.Text = "0";
            this.txtPagos.Text = "0";
            this.txtPagosExt.Text = "0";
            ActualizarGrillaCargaPagos();
            this.panelGeneralCuerpoPagina.Enabled = false;

            #endregion
            #region SOLAPA DEPOSITOS
            List<ClienteCuentaDataContracts> clienteCuentas = new List<ClienteCuentaDataContracts>();
            IClienteCuentaService clienteCuentaServices = ServiceClient<IClienteCuentaService>.GetService("ClienteCuentaService");
            clienteCuentas = clienteCuentaServices.GetAllClienteCuentasByIdCliente(int.Parse(this.cmbClientes.SelectedItem.Value));
            this.cmbCuentasClientes.DataSource = clienteCuentas;

            if (clienteCuentas != null)
            {
                this.cmbCuentasClientes.DataTextField = "cuenta";
                this.cmbCuentasClientes.DataValueField = "idCliente";
                this.cmbCuentasClientes.DataBind();
            }

            #endregion
            #region TRANSFERENCIAS

            this.cmbCuentaCredito.DataSource = clienteCuentas;
            if (clienteCuentas != null)
            {
                this.cmbCuentaCredito.DataTextField = "cuenta";
                this.cmbCuentaCredito.DataValueField = "idCliente";
                this.cmbCuentaCredito.DataBind();
            }
            #endregion
            #region SOLAPA OTROS
            List<TipoPagoRaroDataContracts> tiposPagosRaros = new List<TipoPagoRaroDataContracts>();
            ITipoPagoRaroService tiposPagosRarosServices = ServiceClient<ITipoPagoRaroService>.GetService("TipoPagoRaroService");
            tiposPagosRaros = tiposPagosRarosServices.GetAllTipoPagoRaros();
            if (tiposPagosRaros != null)
            {
                this.cmbTipoPagoRaro.DataSource = tiposPagosRaros;
                this.cmbTipoPagoRaro.DataTextField = "TipoPago";
                this.cmbTipoPagoRaro.DataValueField = "id";
                this.cmbTipoPagoRaro.DataBind();
            }

            #endregion
            #region PRONTO PAGO

            //Aca debo verificar si aplica pronto pago o no.
            this.lblAplicaProntoPago.Text = "El deudor seleccionado aplica pronto pago.";
            this.lblAplicaProntoPago.Visible = false;
            #endregion
            #region DESCUENTOS

            List<DescuentoDataContracts> descuentos = new List<DescuentoDataContracts>();
            IDescuentoService descuentoServices = ServiceClient<IDescuentoService>.GetService("DescuentoService");
            descuentos = descuentoServices.GetAllDescuentos();
            this.cmbDescuentos.DataSource = descuentos;
            this.cmbDescuentos.DataTextField = "Concepto";
            this.cmbDescuentos.DataValueField = "id";
            this.cmbDescuentos.DataBind();

            #endregion
            #region RETENCION
            List<RetencionMTRDataContracts> retenciones = new List<RetencionMTRDataContracts>();
            IRetencionMTRService retencionesServices = ServiceClient<IRetencionMTRService>.GetService("RetencionMTRService");
            retenciones = retencionesServices.GetAllRetencionMTRs();

            if (retenciones != null)
            {
                this.cmbRetenciones.DataSource = retenciones;
                this.cmbRetenciones.DataTextField = "descripcion";
                this.cmbRetenciones.DataValueField = "id";
                this.cmbRetenciones.DataBind();
            }

            #endregion

            this.txtFechaPagoEfectivo.Text = DateTime.Today.ToString();
            this.HiddenFieldPagosCargados.Value = string.Empty;
           
            #endregion
            
            #region PersonalizacionDeRemision
                List<ReciboDataContracts> recibosObtenidos = new List<ReciboDataContracts>();
            IReciboService reciboServices = ServiceClient<IReciboService>.GetService("ReciboService");
            ReciboDataContracts reciboDataContract = reciboServices.GetReciboByNumReciboIdDeudorIdCliente(Request.Params["numRecibo"].ToString(), int.Parse(Request.Params["idDeudor"].ToString()), int.Parse(Request.Params["idCliente"].ToString()));
            Session["tipoCambio"] = reciboDataContract.TipoDeCambio;
            List<ReciboFacturaDataContracts> recibosFacturasObtenidos = new List<ReciboFacturaDataContracts>();
            IReciboFacturaService reciboFacturasServices = ServiceClient<IReciboFacturaService>.GetService("ReciboFacturaService");
            recibosFacturasObtenidos = reciboFacturasServices.GetAllReciboFacturasByIdRecibo(reciboDataContract.Id);
            reciboDataContract.ListadoDeFacturasACancelar = recibosFacturasObtenidos;
            this._listaFacturasSeleccionadas = reciboDataContract.ListadoDeFacturasACancelar;
            CargarGrillaFacturasConPersistidas(int.Parse(Request.Params["idDeudor"].ToString()), this._listaFacturasSeleccionadas);
            List<ReciboPagoDataContracts> recibosPagosObtenidos = new List<ReciboPagoDataContracts>();
            IReciboPagoService reciboPagosServices = ServiceClient<IReciboPagoService>.GetService("ReciboPagoService");
            recibosPagosObtenidos = reciboPagosServices.GetAllReciboPagosByIdRecibo(reciboDataContract.Id);
            this.txtCambio.Text = reciboDataContract.TipoDeCambio.ToString();
            foreach (var reciboPagoDataContractse in recibosPagosObtenidos)
            {
              switch (reciboPagoDataContractse.FormaPago)
                {

                    case "CHEQUE":
                        ChequeDataContracts nuevoCheque = new ChequeDataContracts();
                        IChequeService chequeServices = ServiceClient<IChequeService>.GetService("ChequeService");
                        nuevoCheque = chequeServices.GetCheque(reciboPagoDataContractse.IdPago);
                        nuevoCheque.IdMoneda = reciboPagoDataContractse.IdMoneda;
                        nuevoCheque.TotalPesificado = reciboPagoDataContractse.TotalPesificado;
                        AsignarPagosAGrillaClientSide(nuevoCheque, reciboPagoDataContractse.FormaPago);
                        break;
                    case "RETENCION":
                        RetencionDataContracts nuevoRetencion = new RetencionDataContracts();
                        IRetencionService retencionServices = ServiceClient<IRetencionService>.GetService("RetencionService");
                        nuevoRetencion = retencionServices.GetRetencion(reciboPagoDataContractse.IdPago);
                        nuevoRetencion.IdMoneda = reciboPagoDataContractse.IdMoneda;
                        nuevoRetencion.TotalPesificado = reciboPagoDataContractse.TotalPesificado;
                        AsignarPagosAGrillaClientSide(nuevoRetencion, reciboPagoDataContractse.FormaPago);
                        break;
                    case "EFECTIVO":
                        EfectivoDataContracts nuevoEfectivo = new EfectivoDataContracts();
                        IEfectivoService efectivoServices = ServiceClient<IEfectivoService>.GetService("EfectivoService");
                        nuevoEfectivo = efectivoServices.GetEfectivo(reciboPagoDataContractse.IdPago);
                        nuevoEfectivo.IdMoneda = reciboPagoDataContractse.IdMoneda;
                        nuevoEfectivo.TotalPesificado = reciboPagoDataContractse.TotalPesificado;
                        AsignarPagosAGrillaClientSide(nuevoEfectivo, reciboPagoDataContractse.FormaPago);
                        break;
                    case "DEPOSITO":
                        DepositoDataContracts nuevoDeposito = new DepositoDataContracts();
                        IDepositoService depositoServices = ServiceClient<IDepositoService>.GetService("DepositoService");
                        nuevoDeposito = depositoServices.GetDeposito(reciboPagoDataContractse.IdPago);
                        nuevoDeposito.IdMoneda = reciboPagoDataContractse.IdMoneda;
                        nuevoDeposito.TotalPesificado = reciboPagoDataContractse.TotalPesificado;
                        AsignarPagosAGrillaClientSide(nuevoDeposito, reciboPagoDataContractse.FormaPago);
                        break;
                    case "TRANSFERENCIA":
                        TransferenciaDataContracts nuevoTransferencia = new TransferenciaDataContracts();
                        ITransferenciaService transferenciaServices = ServiceClient<ITransferenciaService>.GetService("TransferenciaService");
                        nuevoTransferencia = transferenciaServices.GetTransferencia(reciboPagoDataContractse.IdPago);
                        nuevoTransferencia.IdMoneda = reciboPagoDataContractse.IdMoneda;
                        nuevoTransferencia.TotalPesificado = reciboPagoDataContractse.TotalPesificado;
                        AsignarPagosAGrillaClientSide(nuevoTransferencia, reciboPagoDataContractse.FormaPago);
                        break;
                    case "OTROPAGO":
                        OtroPagoDataContracts nuevoOtroPago = new OtroPagoDataContracts();
                        IOtroPagoService otroPagoServices = ServiceClient<IOtroPagoService>.GetService("OtroPagoService");
                        nuevoOtroPago = otroPagoServices.GetOtroPago(reciboPagoDataContractse.IdPago);
                        nuevoOtroPago.IdMoneda = reciboPagoDataContractse.IdMoneda;
                        nuevoOtroPago.TotalPesificado = reciboPagoDataContractse.TotalPesificado;
                        AsignarPagosAGrillaClientSide(nuevoOtroPago, reciboPagoDataContractse.FormaPago);
                        break;
                    case "DESCUENTO":
                        DescuentoDataContracts nuevoDescuento = new DescuentoDataContracts();
                        IDescuentoService descuento_Services = ServiceClient<IDescuentoService>.GetService("DescuentoService");
                        nuevoDescuento = descuento_Services.GetDescuento(reciboPagoDataContractse.IdPago);
                        nuevoDescuento.IdMoneda = reciboPagoDataContractse.IdMoneda;
                        nuevoDescuento.TotalPesificado = reciboPagoDataContractse.TotalPesificado;
                        AsignarPagosAGrillaClientSide(nuevoDescuento, reciboPagoDataContractse.FormaPago);
                        break;
                    }
            }
            this.lblRemisionEnUso.Text = Request.Params["idRemision"].ToString();
            PersonalizarRemision();
            List<ReciboDataContracts> recibos_Obtenidos = new List<ReciboDataContracts>();
            recibos_Obtenidos.Add(reciboDataContract);
            this.cmbRecibosDisponibles.Items.Clear();
            this.cmbRecibosDisponibles.DataSource = recibos_Obtenidos;
            this.cmbRecibosDisponibles.DataTextField = "Numero";
            this.cmbRecibosDisponibles.DataValueField = "Id";
            this.cmbRecibosDisponibles.DataBind();
            this.cmbRecibosDisponibles.Enabled = false;
            this.txtSumaFacturas.Text = "0";
            UpdatePanelResultados.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
            #endregion
            }
    }


    private void AsignarPagosAGrillaClientSide(PagoDataContracts pagoDataContract,string formaPago)
    {
        string idPagoString=string.Empty;
        switch (formaPago)
        {
            case "CHEQUE":
                idPagoString=(pagoDataContract.IdMoneda==1 ? "PESOS":"DOLARES");

                this.HiddenFieldPagosCargados.Value = this.HiddenFieldPagosCargados.Value + idPagoString +
                                                      ";[CHEQUE];importe=" + double.Parse(string.Format("{0:#,#########.####}", pagoDataContract.Importe)).ToString() +
                                                      ";cheque=" +pagoDataContract.Numero +
                                                      ";fechaVencimiento=" + pagoDataContract.Vencimiento.ToString() +
                                                      ";fechaEmision=" + pagoDataContract.Emision.ToString() + ";banco=" +
                                                      pagoDataContract.Banco + ";sucursal=" + pagoDataContract.Sucursal +
                                                      ";cuitEmisor=" + pagoDataContract.Cuit + ";cuenta=" +
                                                      pagoDataContract.Cuenta + ";cp=" + pagoDataContract.Cp +
                                                      ";totalPesificado=" + pagoDataContract.TotalPesificado.ToString() +";" + pagoDataContract.Id + ";@";
                ActualizarSumaPagos(pagoDataContract.TotalPesificado);
                
                break;

            case "RETENCION":
                RetencionDataContracts retencionDataContracts = pagoDataContract as RetencionDataContracts;
                this.HiddenFieldPagosCargados.Value = this.HiddenFieldPagosCargados.Value + pagoDataContract.Id + ";[RETENCION];concepto=" + retencionDataContracts.IdRetencion.ToString() + ";subtipo=" + retencionDataContracts.IdSubTipoRetencion.ToString() + ";numeroRetencion=" + pagoDataContract.NumeroRetencion + ";importe=" + double.Parse(string.Format("{0:#,#########.####}", pagoDataContract.Importe)).ToString() + ";fechaRetencion=" + pagoDataContract.FechaPago + ";totalPesificado=" + pagoDataContract.TotalPesificado.ToString() + ";idMoneda=" + pagoDataContract.IdMoneda.ToString() + ";@";
                ActualizarSumaPagos(pagoDataContract.TotalPesificado);
                break;
            case "EFECTIVO":
                EfectivoDataContracts efectivoDataContracts = pagoDataContract as EfectivoDataContracts;
                this.HiddenFieldPagosCargados.Value = this.HiddenFieldPagosCargados.Value + pagoDataContract.Id.ToString() + ";[EFECTIVO];importe=" + double.Parse(string.Format("{0:#.#########,####}", efectivoDataContracts.Monto)).ToString() + ";fechaPago=" + efectivoDataContracts.FechaPago.ToString() + ";totalPesificado=" + double.Parse(string.Format("{0:#.#########,####}", ((PagoDataContracts)efectivoDataContracts).TotalPesificado)).ToString() + ";idMoneda=" + pagoDataContract.IdMoneda.ToString() + ";@";
                ActualizarSumaPagos(pagoDataContract.TotalPesificado);
                break;
            case "DEPOSITO":
                DepositoDataContracts depositoDataContracts = pagoDataContract as DepositoDataContracts;
                this.HiddenFieldPagosCargados.Value = this.HiddenFieldPagosCargados.Value + pagoDataContract.Id.ToString() + ";[DEPOSITO];cuenta=" + depositoDataContracts.Cuenta + ";sucursal=" + depositoDataContracts.Sucursal + ";fechaDeposito=" + depositoDataContracts.FechaDeposito.ToString() + ";importe=" + double.Parse(string.Format("{0:#,#########.####}", depositoDataContracts.Importe)).ToString() + ";numComprobante=" + depositoDataContracts.NumComprobante + ";totalPesificado=" + double.Parse(string.Format("{0:#,#########.####}", depositoDataContracts.TotalPesificado)).ToString() + ";idMoneda=" + pagoDataContract.IdMoneda.ToString() + ";@";
                ActualizarSumaPagos(pagoDataContract.TotalPesificado);
                break;
            case "TRANSFERENCIA":
                TransferenciaDataContracts transferenciaDataContracts = pagoDataContract as TransferenciaDataContracts;
                this.HiddenFieldPagosCargados.Value = this.HiddenFieldPagosCargados.Value + pagoDataContract.Id.ToString() + ";[TRANSFERENCIA];cuentaCredito=" + transferenciaDataContracts.CuentaCredito + ";cuentaDebito=" + transferenciaDataContracts.CuentaDebito + ";fechaTransferencia=" + transferenciaDataContracts.FechaDeposito.ToString() + ";importe=" + double.Parse(string.Format("{0:#,#########.####}", transferenciaDataContracts.Importe)).ToString() + ";numComprobante=" + transferenciaDataContracts.NumComprobante + ";totalPesificado=" + double.Parse(string.Format("{0:#,#########.####}", transferenciaDataContracts.TotalPesificado)).ToString() + ";idMoneda=" + pagoDataContract.IdMoneda.ToString() + ";@";
                ActualizarSumaPagos(pagoDataContract.TotalPesificado);
                break;
            case "OTROPAGO":
                OtroPagoDataContracts otroPagoDataContracts = pagoDataContract as OtroPagoDataContracts;
                this.HiddenFieldPagosCargados.Value = this.HiddenFieldPagosCargados.Value + pagoDataContract.Id.ToString() + ";[OTROPAGO];tipoPago=" + otroPagoDataContracts.IdTipoPago.ToString() + ";fechaPago=" + otroPagoDataContracts.FechaPago.ToString() + ";importe=" + double.Parse(string.Format("{0:#,#########.####}", otroPagoDataContracts.Importe)).ToString() + ";numComprobante=" + otroPagoDataContracts.NumComprobante + ";totalPesificado=" + double.Parse(string.Format("{0:#,#########.####}", otroPagoDataContracts.TotalPesificado)).ToString() + ";idMoneda=" + pagoDataContract.IdMoneda.ToString() + ";@";
                ActualizarSumaPagos(pagoDataContract.TotalPesificado);
                  break;
            case "DESCUENTO":
                  DescuentoDataContracts descuentoDataContracts = pagoDataContract as DescuentoDataContracts;
                  this.HiddenFieldPagosCargados.Value = this.HiddenFieldPagosCargados.Value + pagoDataContract.Id.ToString() + ";[DESCUENTO];importe=" + double.Parse(string.Format("{0:#,#########.####}", descuentoDataContracts.Importe)).ToString() + ";concepto=" + descuentoDataContracts.Concepto + ";totalPesificado=" + double.Parse(string.Format("{0:#,#########.####}", descuentoDataContracts.TotalPesificado)).ToString() + ";idMoneda=" + pagoDataContract.IdMoneda.ToString() + ";@";
                  ActualizarSumaPagos(pagoDataContract.TotalPesificado);
                  break;
        }
    }

    private void RemoveSessionObjects()
    {
        Session["ListaDePagos"] = null;
        Session["ListaDeRecibosCargados"] = null;
    }

    private void PersonalizarRemision()
    {
        if (!string.IsNullOrEmpty(Request.Params["idDeudor"].ToString()) && !string.IsNullOrEmpty(Request.Params["idCliente"].ToString()) && !string.IsNullOrEmpty(Request.Params["numRecibo"].ToString()) && !string.IsNullOrEmpty(Request.Params["idRemision"].ToString()))
        {
            string idDeudor = Request.QueryString["idDeudor"].ToString();
            string idCliente = Request.QueryString["idCliente"].ToString();
            ListItem item = this.cmbClientes.Items.FindByValue(idCliente);
            this.cmbClientes.SelectedIndex = -1;
            item.Selected=true;
            this.cmbClientes_SelectedIndexChanged(null, null);
            ListItem itemDeudor = this.cmbDeudores.Items.FindByValue(idDeudor);
            this.cmbDeudores.SelectedIndex = -1;
            itemDeudor.Selected = true;
            if (Session["tipoCambio"] != null)
            {
                this.txtCambio.Text = Session["tipoCambio"].ToString().Replace(",","."); ; 
            }
            
            //this.cmbDeudores_SelectedIndexChanged(null, null);
        }
        else
        {
            this.cmbClientes.SelectedIndex = 0;
        }

        btnRefreshCmbDeudores.Enabled = false;
        this.cmbClientes.Enabled = false;
        this.cmbDeudores.Enabled = false;
        this.panelGeneralCuerpoPagina.Enabled = true;
        this.chkMail.Enabled = false;
    }

    private void CargarGrillaFacturasConPersistidas(int deudor,List<ReciboFacturaDataContracts> facturasTildadas)
    {

        this.GvResultadosFacturas.DataSource = this.GetDataTableFacturasPorDeudorPosiblesDeEdicion(deudor, Request.Params["numRecibo"].ToString());
        this.GvResultadosFacturas.DataBind();
        GridViewRowCollection rows = this.GvResultadosFacturas.Rows;
        int pos = 0;
        int cantDigitos=0;
        cantDigitos = rows.Count.ToString().Length;
        if (cantDigitos == 1) cantDigitos++;
        double sumaFacturasSeleccionadas=0;
        foreach (GridViewRow row in rows)
        {
            
            //row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Pronto")].Enabled = true;
           // ((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = (double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Importe")].Text)).ToString();
            ((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Ultima Imputacion")].Text.Replace(",",".");
            

            if (facturasTildadas.Exists(f => f.IdFactura == int.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "id Factura")].Text)))
            {

                //sacar gato
                //((Button)row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Pronto")].Controls[0]).Enabled = false;

                string moneda = row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Moneda")].Text;
                double valorCambio = moneda.Equals("DO")? double.Parse(Session["tipoCambio"].ToString()):1;
                //((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = (double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Importe")].Text) - double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Saldo")].Text)).ToString().Replace(",", ".");
                ((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Enabled = false;
                sumaFacturasSeleccionadas += double.Parse(((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text.Replace(".", ",")) * valorCambio;
                string obj = rows[pos].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1].ClientID.Replace("txtAImputarPorFactura", "chk");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "checherFactura" + pos.ToString(), "javascript:TildarFacturasPersistidas('" + obj + "');", true);      
            }
            pos++;
        }
        

        if (this.GvResultadosFacturas.Rows.Count > 0)
        {
            UInt16 i = 0;
            foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
            {
                if (Fila.Visible == true)
                    i++;
            }
            this.lblResResultadoCantFacts.Text = i.ToString();
        }
        else
        {
            this.lblResResultadoCantFacts.Text = "0";
        }

        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ReCalcularSumaClientSide", "javascript:ReCalcularSumaClientSide('" + string.Format("{0:#,#########.####}", sumaFacturasSeleccionadas) + "');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ReCalcularSumaClientSide", "javascript:ReCalcularSumaClientSide('" +  sumaFacturasSeleccionadas + "');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturas2", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }
    
    private void CargarGrillaFacturas(int deudor)
    {
    }

    private void LimpiarGrillaFacturas()
    {
        DataTable dataTable2 = null;
        this.GvResultadosFacturas.DataSource = dataTable2;
        this.GvResultadosFacturas.DataBind();
        GridViewRowCollection rows = this.GvResultadosFacturas.Rows;
    }

    private DataTable GetDataTableFacturasPorDeudorSinFiltroDeEstado(int idDeudor)
    {
        List<FacturaDataContracts> resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetAllFacturasPorIdDeudorSinFiltroDeEstado(idDeudor);
        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }
    private DataTable GetDataTableFacturasPorDeudorPosiblesDeEdicion(int idDeudor,string numRecibo)
    {
        List<FacturaDataContracts> resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetDataTableFacturasPorDeudorPosiblesDeEdicion(idDeudor,numRecibo);
        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }

    protected void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
    {

        List<DeudorLivianoDataContracts> resultadoObtenidos = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");
        resultadoObtenidos = deudorServices.GetAllDeudorsLivianoPorCriterioCliente(int.Parse(this.cmbClientes.SelectedItem.Value));
        DeudorLivianoDataContracts seleccion = new DeudorLivianoDataContracts();
        seleccion.Nombre = "--- SELECCIONE ---";
        seleccion.IdDeudor = 0;
        resultadoObtenidos.Insert(0, seleccion);
        this.cmbDeudores.Items.Clear();
        this.cmbDeudores.DataSource = resultadoObtenidos;
        this.cmbDeudores.DataTextField = "NOMBRE";
        this.cmbDeudores.DataValueField = "idDeudor";
        this.cmbDeudores.DataBind();
        this.cmbDeudores.Enabled = true;
        this.cmbClientes.ToolTip = this.cmbClientes.SelectedItem.Text;
    }

    private void FillRecibosDisponibles()
    {
        List<ReciboDataContracts> recibosObtenidos = new List<ReciboDataContracts>();
        IReciboService reciboServices = ServiceClient<IReciboService>.GetService("ReciboService");
        recibosObtenidos = reciboServices.GetAllRecibosByIdClienteSinUsar(int.Parse(this.cmbClientes.SelectedItem.Value));
        this.cmbRecibosDisponibles.Items.Clear();
        this.cmbRecibosDisponibles.DataSource = recibosObtenidos;
        this.cmbRecibosDisponibles.DataTextField = "Numero";
        this.cmbRecibosDisponibles.DataValueField = "Id";
        this.cmbRecibosDisponibles.DataBind();
        this.cmbRecibosDisponibles.Enabled = true;

        if (this.cmbRecibosDisponibles.Items.Count==0)
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sinRecibosCargados", "javascript:alert('Por favor cargue recibos para poder operar.');", true);
    }

    protected void btnAplicarProntoPago_OnClick(object sender, EventArgs e)
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (mgr.Contains("seleccionItemProntoPago"))
        {
            int key = (int)mgr.GetData("seleccionItemProntoPago");
            this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas,"importe PP")].Text  = this.txtImporteProntoPago.Text.Replace(",",".");
            ((TextBox)this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = this.txtImporteProntoPago.Text.Replace(",", ".");
            ((TextBox)this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Enabled = true;
            updatePanelGvFacturas.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "cerrarPanelProntoPago", "javascript:HideConfirma3();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
        }
    }

    protected void btnQuitarProntoPago_OnClick(object sender, EventArgs e)
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (mgr.Contains("seleccionItemProntoPago"))
        {
            int key = (int)mgr.GetData("seleccionItemProntoPago");
            this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe PP")].Text = "0";
            ((TextBox)this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "saldo")].Text;
            updatePanelGvFacturas.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "cerrarPanelProntoPago", "javascript:HideConfirma3();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
        }
    }

    protected void btnAgregarPago_Click(object sender, EventArgs e)
    {
        _evitarPrerenderGrillaFactura = true;
        string[] pagos = this.HiddenFieldPagosCargados.Value.Split('@');
        string tipoPago=string.Empty;
        foreach (string pago in pagos)
        {
            if (pago==string.Empty) break;
            if (pago.Contains("[CHEQUE]")) tipoPago = "CHEQUE";
            if (pago.Contains("[RETENCION]")) tipoPago = "RETENCION";
            if (pago.Contains("[EFECTIVO]")) tipoPago = "EFECTIVO";
            if (pago.Contains("[DEPOSITO]")) tipoPago = "DEPOSITO";
            if (pago.Contains("[TRANSFERENCIA]")) tipoPago = "TRANSFERENCIA";
            if (pago.Contains("[OTROPAGO]")) tipoPago = "OTROPAGO";
            if (pago.Contains("[DESCUENTO]")) tipoPago = "DESCUENTO";
            switch (tipoPago )
            {
             case "CHEQUE":
                    ChequeDataContracts nuevoCheque = new ChequeDataContracts();
                    nuevoCheque.FechaPago = DateTime.Now;
                    nuevoCheque.Banco = GetValueFromAttribute(pago, "banco");
                    nuevoCheque.Cuenta = GetValueFromAttribute(pago, "cuenta");
                    nuevoCheque.Cuit = GetValueFromAttribute(pago, "cuitEmisor");
                    nuevoCheque.Cp = GetValueFromAttribute(pago, "cp");
                    nuevoCheque.Emision = DateTime.Parse(GetValueFromAttribute(pago, "fechaEmision"));
                    nuevoCheque.Vencimiento = DateTime.Parse(GetValueFromAttribute(pago, "fechaVencimiento"));
                    nuevoCheque.Importe = double.Parse(AplicarFormatoADoble(double.Parse(GetValueFromAttribute(pago, "importe"))).ToString());
                    nuevoCheque.Sucursal = GetValueFromAttribute(pago, "sucursal");
                    nuevoCheque.FormaPago = new FormaPagoDataContracts(1, "CHEQUE");
                    nuevoCheque.Numero = long.Parse(GetValueFromAttribute(pago, "cheque"));
                    nuevoCheque.IdMoneda = this.GetIdMoneda(pago);
                    nuevoCheque.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    this.AgregarPago(nuevoCheque);
                    BlanquearPagos(0);
                    ActualizarGrillaCargaPagos();
                    break;

                case "RETENCION":
                    RetencionDataContracts nuevaRetencion = new RetencionDataContracts();
                    nuevaRetencion.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaRetencion"));
                    nuevaRetencion.FormaPago = new FormaPagoDataContracts(3, "RETENCION");
                    nuevaRetencion.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevaRetencion.Importe = AplicarFormatoADoble(nuevaRetencion.Importe);
                    nuevaRetencion.NumeroRetencion = GetValueFromAttribute(pago, "numeroRetencion");
                    nuevaRetencion.IdRetencion = int.Parse(GetValueFromAttribute(pago, "concepto"));
                    nuevaRetencion.IdSubTipoRetencion = int.Parse(GetValueFromAttribute(pago, "subtipo"));
                    nuevaRetencion.IdMoneda = this.GetIdMoneda(pago);
                    nuevaRetencion.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    this.AgregarPago(nuevaRetencion);
                    BlanquearPagos(1);
                    ActualizarGrillaCargaPagos();
                    break;

                case "EFECTIVO":
                    EfectivoDataContracts nuevoEfectivo = new EfectivoDataContracts();
                    nuevoEfectivo.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaPago"));
                    nuevoEfectivo.FormaPago = new FormaPagoDataContracts(2, "EFECTIVO");
                    nuevoEfectivo.Monto = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoEfectivo.Importe = double.Parse(nuevoEfectivo.Monto.ToString());
                    nuevoEfectivo.Importe = AplicarFormatoADoble(nuevoEfectivo.Importe);
                    nuevoEfectivo.IdMoneda = this.GetIdMoneda(pago);
                    nuevoEfectivo.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    this.AgregarPago(nuevoEfectivo);
                    BlanquearPagos(2);
                    ActualizarGrillaCargaPagos();
                    break;

                case "DEPOSITO":
                    DepositoDataContracts nuevoDeposito = new DepositoDataContracts();
                    nuevoDeposito.FechaDeposito = DateTime.Parse(GetValueFromAttribute(pago, "fechaDeposito"));
                    nuevoDeposito.FechaPago = DateTime.Now;
                    nuevoDeposito.FormaPago = new FormaPagoDataContracts(4, "DEPOSITO");
                    nuevoDeposito.Importe = AplicarFormatoADoble(double.Parse(GetValueFromAttribute(pago, "importe")));
                    nuevoDeposito.Importe = AplicarFormatoADoble(nuevoDeposito.Importe);
                    nuevoDeposito.NumComprobante = GetValueFromAttribute(pago, "numComprobante");
                    // nuevoDeposito.IdCuenta = this.cmbCuentasClientes.SelectedItem.Value; Agregar esto
                    nuevoDeposito.IdCuenta = 1.ToString(); //Quitar cuando este la linea de arriba
                    nuevoDeposito.Sucursal = GetValueFromAttribute(pago, "sucursal");
                    nuevoDeposito.IdMoneda = this.GetIdMoneda(pago);
                    nuevoDeposito.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    this.AgregarPago(nuevoDeposito);
                    BlanquearPagos(3);
                    ActualizarGrillaCargaPagos();
                    break;
                case "TRANSFERENCIA":
                    TransferenciaDataContracts nuevaTransferencia = new TransferenciaDataContracts();
                    nuevaTransferencia.FechaDeposito = DateTime.Parse(GetValueFromAttribute(pago, "fechaTransferencia"));
                    nuevaTransferencia.FechaCarga = DateTime.Now;
                    nuevaTransferencia.FormaPago = new FormaPagoDataContracts(5, "TRANSFERENCIA");
                    nuevaTransferencia.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevaTransferencia.Importe = AplicarFormatoADoble(nuevaTransferencia.Importe);
                    nuevaTransferencia.CuentaCredito = string.Empty;
                    nuevaTransferencia.CuentaDebito = GetValueFromAttribute(pago, "cuentaDebito");
                    nuevaTransferencia.NumComprobante = GetValueFromAttribute(pago, "numComprobante");
                    nuevaTransferencia.IdMoneda = this.GetIdMoneda(pago);
                    nuevaTransferencia.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    this.AgregarPago(nuevaTransferencia);
                    BlanquearPagos(4);
                    ActualizarGrillaCargaPagos();
                    break;
                case "OTROPAGO":
                    OtroPagoDataContracts nuevoOtroPago = new OtroPagoDataContracts();
                    nuevoOtroPago.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaPago"));
                    nuevoOtroPago.FormaPago = new FormaPagoDataContracts(6, "OTRO");
                    nuevoOtroPago.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoOtroPago.Importe = AplicarFormatoADoble(nuevoOtroPago.Importe);
                    nuevoOtroPago.NumComprobante = GetValueFromAttribute(pago, "txtNumComprobante");
                    nuevoOtroPago.IdMoneda = this.GetIdMoneda(pago);
                    nuevoOtroPago.IdTipoPagoRaro =int.Parse(nuevoOtroPago.NumComprobante = GetValueFromAttribute(pago, "tipoPago"));
                    nuevoOtroPago.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    this.AgregarPago(nuevoOtroPago);
                    BlanquearPagos(5);
                    ActualizarGrillaCargaPagos();
                    break;
                case "DESCUENTO":
                    RemisionDescuentoDataContracts nuevoDescuento = new RemisionDescuentoDataContracts();
                    nuevoDescuento.FechaDescuento = DateTime.Now;
                    nuevoDescuento.IdRemision = 0; //Ver
                    nuevoDescuento.IdDescuento = 1;//arreglar int.Parse(this.cmbDescuentos.SelectedItem.Value);
                    nuevoDescuento.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoDescuento.Importe = AplicarFormatoADoble(nuevoDescuento.Importe);
                    nuevoDescuento.FormaPago = new FormaPagoDataContracts(7, "DESCUENTO");
                    nuevoDescuento.IdMoneda = this.GetIdMoneda(pago);
                    nuevoDescuento.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    this.AgregarPago(nuevoDescuento);
                    BlanquearPagos(6);
                    ActualizarGrillaCargaPagos();
                    break;
            }
            if (this.chkPestreificar.Checked)
            {
                this.chkPestreificar.Checked = false;
                this.txtCambio.Text = Constants.DEFAULT_CHANGE;
                this.UpdatePanelIndice.Update();
            }
        }
        this.HiddenFieldPagosCargados.Value = string.Empty;
    }

    protected void TomarPagosCargadosTemporalmente()
    {
        _evitarPrerenderGrillaFactura = true;
        string[] pagos = this.HiddenFieldPagosCargados.Value.Split('@');
        string tipoPago = string.Empty;
        foreach (string pago in pagos)
        {
            if (pago == string.Empty) break;
            if (pago.Contains("[CHEQUE]")) tipoPago = "CHEQUE";
            if (pago.Contains("[RETENCION]")) tipoPago = "RETENCION";
            if (pago.Contains("[EFECTIVO]")) tipoPago = "EFECTIVO";
            if (pago.Contains("[DEPOSITO]")) tipoPago = "DEPOSITO";
            if (pago.Contains("[TRANSFERENCIA]")) tipoPago = "TRANSFERENCIA";
            if (pago.Contains("[OTROPAGO]")) tipoPago = "OTROPAGO";
            if (pago.Contains("[DESCUENTO]")) tipoPago = "DESCUENTO";
            switch (tipoPago)
            {
                case "CHEQUE":
                    ChequeDataContracts nuevoCheque = new ChequeDataContracts();
                    nuevoCheque.FechaPago = DateTime.Now;
                    nuevoCheque.Banco = GetValueFromAttribute(pago, "banco");
                    nuevoCheque.Cuenta = GetValueFromAttribute(pago, "cuenta");
                    nuevoCheque.Cuit = GetValueFromAttribute(pago, "cuitEmisor");
                    nuevoCheque.Cp = GetValueFromAttribute(pago, "cp");
                    nuevoCheque.Emision = DateTime.Parse(GetValueFromAttribute(pago, "fechaEmision"));
                    nuevoCheque.Vencimiento = DateTime.Parse(GetValueFromAttribute(pago, "fechaVencimiento"));
                    nuevoCheque.Importe =
                    double.Parse(AplicarFormatoADoble(double.Parse(GetValueFromAttribute(pago, "importe"))).ToString());
                    nuevoCheque.Sucursal = GetValueFromAttribute(pago, "sucursal");
                    nuevoCheque.FormaPago = new FormaPagoDataContracts(1, "CHEQUE");
                    nuevoCheque.Numero = long.Parse(GetValueFromAttribute(pago, "cheque"));
                    nuevoCheque.IdMoneda = this.GetIdMoneda();
                    this.AgregarPagoTemporal(nuevoCheque);
                    break;
                case "RETENCION":
                    RetencionDataContracts nuevaRetencion = new RetencionDataContracts();
                    nuevaRetencion.FechaPago = DateTime.Now;
                    nuevaRetencion.FormaPago = new FormaPagoDataContracts(3, "RETENCION");
                    nuevaRetencion.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevaRetencion.Importe = AplicarFormatoADoble(nuevaRetencion.Importe);
                    nuevaRetencion.NumeroRetencion = GetValueFromAttribute(pago, "numeroRetencion");
                    nuevaRetencion.IdRetencion = 1;//Falta ver esto
                    nuevaRetencion.IdMoneda = this.GetIdMoneda();
                    this.AgregarPagoTemporal(nuevaRetencion);
                    break;
                case "EFECTIVO":
                    EfectivoDataContracts nuevoEfectivo = new EfectivoDataContracts();
                    nuevoEfectivo.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaPago"));
                    nuevoEfectivo.FormaPago = new FormaPagoDataContracts(2, "EFECTIVO");
                    nuevoEfectivo.Monto = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoEfectivo.Importe = double.Parse(nuevoEfectivo.Monto.ToString());
                    nuevoEfectivo.Importe = AplicarFormatoADoble(nuevoEfectivo.Importe);
                    nuevoEfectivo.IdMoneda = this.GetIdMoneda();
                    this.AgregarPagoTemporal(nuevoEfectivo);
                    break;
                case "DEPOSITO":
                    DepositoDataContracts nuevoDeposito = new DepositoDataContracts();
                    nuevoDeposito.FechaDeposito = DateTime.Parse(GetValueFromAttribute(pago, "fechaDeposito"));
                    nuevoDeposito.FechaPago = DateTime.Now;
                    nuevoDeposito.FormaPago = new FormaPagoDataContracts(4, "DEPOSITO");
                    nuevoDeposito.Importe = AplicarFormatoADoble(double.Parse(GetValueFromAttribute(pago, "importe")));
                    nuevoDeposito.Importe = AplicarFormatoADoble(nuevoDeposito.Importe);
                    nuevoDeposito.NumComprobante = GetValueFromAttribute(pago, "numComprobante");
                    // nuevoDeposito.IdCuenta = this.cmbCuentasClientes.SelectedItem.Value; Agregar esto
                    nuevoDeposito.IdCuenta = 1.ToString(); //Quitar cuando este la linea de arriba
                    nuevoDeposito.Sucursal = GetValueFromAttribute(pago, "sucursal");
                    nuevoDeposito.IdMoneda = this.GetIdMoneda();
                    this.AgregarPagoTemporal(nuevoDeposito);
                    break;
                case "TRANSFERENCIA":
                    TransferenciaDataContracts nuevaTransferencia = new TransferenciaDataContracts();
                    nuevaTransferencia.FechaDeposito = DateTime.Parse(GetValueFromAttribute(pago, "fechaTransferencia"));
                    nuevaTransferencia.FechaCarga = DateTime.Now;
                    nuevaTransferencia.FormaPago = new FormaPagoDataContracts(5, "TRANSFERENCIA");
                    nuevaTransferencia.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevaTransferencia.Importe = AplicarFormatoADoble(nuevaTransferencia.Importe);
                    nuevaTransferencia.CuentaCredito = string.Empty;
                    nuevaTransferencia.CuentaDebito = GetValueFromAttribute(pago, "cuentaDebito");
                    nuevaTransferencia.NumComprobante = GetValueFromAttribute(pago, "numComprobante");
                    nuevaTransferencia.IdMoneda = this.GetIdMoneda();
                    this.AgregarPagoTemporal(nuevaTransferencia);
                    break;
                case "OTROPAGO":
                    OtroPagoDataContracts nuevoOtroPago = new OtroPagoDataContracts();
                    nuevoOtroPago.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaPago"));
                    nuevoOtroPago.FormaPago = new FormaPagoDataContracts(6, "OTRO");
                    nuevoOtroPago.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoOtroPago.Importe = AplicarFormatoADoble(nuevoOtroPago.Importe);
                    nuevoOtroPago.NumComprobante = GetValueFromAttribute(pago, "txtNumComprobante");
                    nuevoOtroPago.IdMoneda = this.GetIdMoneda();
                    this.AgregarPagoTemporal(nuevoOtroPago);
                    break;
                case "DESCUENTO":
                    RemisionDescuentoDataContracts nuevoDescuento = new RemisionDescuentoDataContracts();
                    nuevoDescuento.FechaDescuento = DateTime.Now;
                    nuevoDescuento.IdRemision = 0; //Ver
                    nuevoDescuento.IdDescuento = 1;//arreglar int.Parse(this.cmbDescuentos.SelectedItem.Value);
                    nuevoDescuento.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoDescuento.Importe = AplicarFormatoADoble(nuevoDescuento.Importe);
                    nuevoDescuento.FormaPago = new FormaPagoDataContracts(7, "DESCUENTO");
                    nuevoDescuento.IdMoneda = this.GetIdMoneda();
                    this.AgregarPagoTemporal(nuevoDescuento);
                    break;
            }
        }
    }


    private void AgregarPagoTemporal(PagoDataContracts pago)
    {
            var listaDePagosCargados = new List<PagoDataContracts>();
            if (Session["ListaDePagos"] != null)
            {
                listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];
                listaDePagosCargados.Add(pago);
            }
            else
            {
                listaDePagosCargados.Add(pago);
            }
            Session["ListaDePagos"] = listaDePagosCargados;
    }

    private string GetValueFromAttribute(string cadena,string attribute)
    {
        int pos = cadena.IndexOf(attribute);
        int lengthAttribute = attribute.Length;
        string shortCadena = cadena.Remove(0, pos).Remove(0, lengthAttribute + 1);
        shortCadena = shortCadena.Remove(shortCadena.IndexOf(";"), shortCadena.Length - shortCadena.IndexOf(";"));
        return shortCadena;
    }

    private int GetIdMoneda()
    {
        return  Convert.ToInt32(this.chkPestreificar.Checked)+1;
    }

    private int GetIdMoneda(String moneda)
    {
        switch (moneda.Split(';')[0])
        {
            case "PESOS":return 1;
                break;

            case "DOLARES":return 2;
                break;
            default:return 1;
                break;

        }
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

    private void SetTipoMoneda(string monedaNombre)
    {
        switch (monedaNombre)
        {
            case "PESOS":
                this.chkPestreificar.Checked = false;
                break;

            case "DOLARES":
                this.chkPestreificar.Checked = true;
                break;
                       
        }
    }


    private void ActualizarGrillaDetalleCheque()
    {
        TomarPagosCargadosTemporalmente();
        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];
        }
        int a = 1;
        List<ChequeDataContracts> listaDeCheques = new List<ChequeDataContracts>();
        foreach (PagoDataContracts pago in listaDePagosCargados)
        {
            if (pago.FormaPago.Descripcion == "CHEQUE")
            {
                pago.Orden = a++;
                ChequeDataContracts nuevoCheque = new ChequeDataContracts();
                UIUtils.MappingEntity(pago, nuevoCheque);
                listaDeCheques.Add(nuevoCheque);
            }
        }

        DataTable dataTable = new DataTable();
        Type itemsType = typeof(ChequeDataContracts);

        foreach (PropertyInfo property in itemsType.GetProperties())
        {
            DataColumn column = new DataColumn(property.Name);
            column.DataType = property.PropertyType;
            dataTable.Columns.Add(column);

        }

        foreach (ChequeDataContracts cheque in listaDeCheques)
        {
            DataRow row = dataTable.NewRow();

            foreach (PropertyInfo property in itemsType.GetProperties())
            {
                row[property.Name] = property.GetValue(cheque, null);
            }
            dataTable.Rows.Add(row);
        }

        this.gvResultadosCheques.DataSource = dataTable;
        this.gvResultadosCheques.DataBind();
        Session["ListaDePagos"] = null;
    }

    private void ActualizarGrillaCargaPagos()
    { 
        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();
        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];
        }
        int a = 1;
        foreach (PagoDataContracts pago in listaDePagosCargados)
        {
            pago.Orden = a++;

        }

        DataTable dataTable = new DataTable();
        Type itemsType = typeof(PagoDataContracts);

        foreach (PropertyInfo property in itemsType.GetProperties())
        {
            DataColumn column = new DataColumn(property.Name);
            column.DataType = property.PropertyType;
            dataTable.Columns.Add(column);
        }

        foreach (PagoDataContracts pago in listaDePagosCargados)
        {
            DataRow row = dataTable.NewRow();
            foreach (PropertyInfo property in itemsType.GetProperties())
            {
                row[property.Name] = property.GetValue(pago, null);
            }
            dataTable.Rows.Add(row);
        }
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            CheckBox chk = (CheckBox)Fila.FindControl("chk");
            chk.Checked = false;
        }
    }

    private void ActualizarGrillaCargaPagosYActualizaTotales()
    {
        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];
        }
        int a = 1;
        foreach (PagoDataContracts pago in listaDePagosCargados)
        {
            pago.Orden = a++;
        }
        DataTable dataTable = new DataTable();
        Type itemsType = typeof(PagoDataContracts);
        foreach (PropertyInfo property in itemsType.GetProperties())
        {
            DataColumn column = new DataColumn(property.Name);
            column.DataType = property.PropertyType;
            dataTable.Columns.Add(column);
        }
        double total = 0;
        foreach (PagoDataContracts pago in listaDePagosCargados)
        {
            DataRow row = dataTable.NewRow();

            foreach (PropertyInfo property in itemsType.GetProperties())
            {
                row[property.Name] = property.GetValue(pago, null);

                if (property.Name=="Importe")
                {
                        total = total + double.Parse(property.GetValue(pago, null).ToString());
                }
            }
            dataTable.Rows.Add(row);
        }
        this.ActualizarTotalesEnPantalla(total);
        //Agregado para evitar sumas negativas:
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            CheckBox chk = (CheckBox)Fila.FindControl("chk");
            chk.Checked = false;
        }
    }

    private void BlanquearPagos(int tipoPago)
    {
        switch (tipoPago)
        {
                case 0:
                    this.txtBanco.Text = string.Empty;
                    this.txtCheque.Text = string.Empty;
                    this.txtFechaVencimiento.Text = string.Empty;
                    this.txtFechaEmision.Text = string.Empty;
                    this.txtImporte.Text = string.Empty;
                    this.txtSucursal.Text = string.Empty;
                    this.txtCuitEmisor.Text = string.Empty;
                    this.txtCuenta.Text = string.Empty;
                    this.txtCp.Text = string.Empty;
                    break;
                case 1:
                    this.txtImporteRetencion.Text = string.Empty;
                    this.txtNumeroRetencion.Text = string.Empty;
                    break;
                case 2:
                  this.txtImporteEfectivo.Text = string.Empty;
                  break;
                case 3:
                    this.cmbCuentasClientes.SelectedIndex = 0;
                    this.txtSucursalDeposito.Text = string.Empty;
                    this.txtImporteDeposito.Text = string.Empty;
                    this.txtFechaDeposito.Text = string.Empty;
                    this.txtNumComprob.Text = string.Empty;
                    break;
                case 4:
                    this.txtCuentaDebito.Text = string.Empty;
                    this.txtFechaTransferencia.Text = string.Empty;
                    this.txtNumComprobTrans.Text = string.Empty;
                    this.txtImporteTransferencia.Text = string.Empty;
                    break;
                case 5:
                    this.cmbTipoPagoRaro.SelectedIndex = 0;
                    this.txtFechaPagoRaro.Text = string.Empty;
                    this.txtNumCompRaro.Text = string.Empty;
                    this.txtImporteRaro.Text = string.Empty;
                    break;
                case 6:
                    this.txtImporteDescuento.Text = string.Empty;
                    this.cmbDescuentos.SelectedIndex = 0;
                    break;
          }
        }
    
        private void BlanquearTodosLosPagos()
        {
                this.txtBanco.Text = string.Empty;
                this.txtCheque.Text = string.Empty;
                this.txtFechaVencimiento.Text = string.Empty;
                this.txtFechaEmision.Text = string.Empty;
                this.txtImporte.Text = string.Empty;
                this.txtSucursal.Text = string.Empty;
                this.txtCuitEmisor.Text = string.Empty;
                this.txtCuenta.Text = string.Empty;
                this.txtCp.Text = string.Empty;
                this.txtImporteRetencion.Text = string.Empty;
                this.txtNumeroRetencion.Text = string.Empty;
                this.txtImporteEfectivo.Text = string.Empty;
                this.txtFechaPagoEfectivo.Text = DateTime.Today.ToString();
                this.txtSucursalDeposito.Text=string.Empty;
                this.txtImporteDeposito.Text = string.Empty;
                this.txtFechaDeposito.Text = string.Empty;
                this.txtNumComprob.Text = string.Empty;
                this.txtCuentaDebito.Text = string.Empty;
                this.txtFechaTransferencia.Text  = string.Empty;
                this.txtNumComprobTrans.Text = string.Empty;
                this.txtImporteTransferencia.Text = string.Empty;
                this.cmbTipoPagoRaro.SelectedIndex = 0;
                this.txtFechaPagoRaro.Text = string.Empty;
                this.txtNumCompRaro.Text = string.Empty;
                this.txtImporteRaro.Text = string.Empty;
                this.txtImporteDescuento.Text = string.Empty;
                this.cmbDescuentos.SelectedIndex = 0;
    }


    private void AgregarPago(PagoDataContracts pago)
    {

        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();
        this.UpdatePanelResultados.Update();
        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];
            listaDePagosCargados.Add(pago);
            this.ActualizarSumaPagos(double.Parse(pago.Importe.ToString()));
        }
        else
        {
            listaDePagosCargados.Add(pago);
            this.ActualizarSumaPagos(double.Parse(pago.Importe.ToString()));
        }

        Session["ListaDePagos"] = listaDePagosCargados;
    }
    

    protected void gvResultadosPagos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<PagoDataContracts > listaDePagosCargados = new List<PagoDataContracts >();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts >)Session["ListaDePagos"];

            //Evita resta negativa
            if(txtPagos.Text != "0")
                ActualizarSumaPagos(double.Parse(string.Format("{0:#,#########.####}", (listaDePagosCargados[e.RowIndex].Importe * -1))));
            
            listaDePagosCargados.Remove(listaDePagosCargados[e.RowIndex]);
            Session["ListaDePagos"] = listaDePagosCargados;
            ActualizarGrillaCargaPagos();
           
        }
    }

    private void ActualizarSumaPagos(double valor)
    {
        double fCambio = double.Parse("1,00");
        double fValorAgregar = double.Parse("0");
        if (txtCambio.Text != "1,00" && txtCambio.Text != string.Empty)
            fCambio = double.Parse(txtCambio.Text);
        bool chkPesif = this.chkPestreificar.Checked;
        if (chkPesif==true)
        {
            fValorAgregar = valor * fCambio;
        }
        else
        {
            fValorAgregar = valor;
        }
        double suma = (double.Parse(this.txtPagos.Text) + fValorAgregar);
        if (valor < 0) suma = (suma*-1);
        if (suma!=0)
        {
            string sumaFormatString = string.Format("{0:#,#########.####}", suma);
            suma = double.Parse(sumaFormatString);
            if (valor < 0) suma = (suma * -1);
        }
        
        ActualizarTotalesEnPantalla(suma);
    }

    private void ActualizarTotalesEnPantalla(double suma)
    {
        this.txtPagos.Text = suma.ToString();
        this.UpdatePanelTabContainer.Update();
        this.UpdatePanelSumasPagos.Update();

        this.txtDiferenciaPe.Text = "0";
        if (this.txtPagos.Text != string.Empty && this.txtSumaFacturas.Text != string.Empty)
        {
            double txtPagoConFormato = this.txtPagos.Text!="0" ? double.Parse(string.Format("{0:#,#########.####}", double.Parse(this.txtPagos.Text))):0;
            double txtSumaFacturasConFormato = this.txtSumaFacturas.Text!="0" ? double.Parse(string.Format("{0:#,#########.####}", double.Parse(this.txtSumaFacturas.Text))):0;

            this.txtDiferenciaPe.Text =
                (txtPagoConFormato - txtSumaFacturasConFormato).ToString();
        }
     
        this.UpdatePanelResultadosDiferenciaLocal.Update();
    }

    private void ActualizarTotalesEnPantalla()
    {
        this.txtDiferenciaPe.Text = "0";
        if (this.txtPagos.Text != string.Empty && this.txtSumaFacturas.Text != string.Empty)
        {
            double txtPagoConFormato = this.txtPagos.Text != "0" ? double.Parse(string.Format("{0:#,#########.####}", double.Parse(this.txtPagos.Text))) : 0;
            double txtSumaFacturasConFormato = this.txtSumaFacturas.Text != "0" ? double.Parse(string.Format("{0:#,#########.####}", double.Parse(this.txtSumaFacturas.Text))) : 0;
            this.txtDiferenciaPe.Text =
                (txtPagoConFormato - txtSumaFacturasConFormato).ToString();
        }

        this.UpdatePanelResultadosDiferenciaLocal.Update();
    }


    private void ActualizarSumaPagos()
    {
        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts >();

        if (Session["ListaDePagos"] != null)
        {
            double sumaTotalDePagos = 0;

            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];

            foreach (PagoDataContracts item in listaDePagosCargados)
            {
                sumaTotalDePagos = sumaTotalDePagos + item.Importe;
            }
            double sumaTotalDePagosConFormato = double.Parse(string.Format("{0:#,#########.####}", sumaTotalDePagos));
            this.txtPagos.Text = sumaTotalDePagosConFormato.ToString();
            if (this.txtCambio.Text == string.Empty || this.txtCambio.Text == null)
            this.txtCambio.Text = "1,00";
            this.UpdatePanelTabContainer.Update();
            this.UpdatePanelIndice.Update();

        }
    }

    private double AplicarFormatoADoble(double input)
    {
        if (input==0)
        {
            return 0;
        }

        return double.Parse(string.Format("{0:#,#########.####}", input));
    }

    private void ActualizarSumaFacturas()
    {
        GridViewRowCollection rows = this.GvResultadosFacturas.Rows;

        double sumaFacturas = 0;
        foreach (GridViewRow row in rows)
        {
            if (((CheckBox) row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked)
            {
                sumaFacturas = sumaFacturas + double.Parse(string.Format("{0:#,#########.####}", double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "saldo")].Text)));
            }
        }
        this.txtSumaFacturas.Text = sumaFacturas.ToString();

        this.UpdatePanelResultados.Update();
    }

    protected void GvResultadosFacturas_PreRender(object sender, EventArgs e)
    {
        if (!_evitarPrerenderGrillaFactura)
        {

            int cont = -1;
            foreach (GridViewRow item in GvResultadosFacturas.Rows)
            {
                cont++;
                CheckBox checkSeleccion =
                    (CheckBox) item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1];

                Button btnPP = (Button) item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Pronto")].Controls[0];

                checkSeleccion.Attributes.Add("onclick",
                                              "SumarImporteEdicionRecibo(this,'" + cont.ToString() + "'," +
                                              item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe")].Text.
                                                  Replace(",", ".") + "," +
                                              item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe PP")].
                                                  Text.Replace(",", ".") + ",'" + btnPP.ClientID + "'," +item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Saldo")].Text.
                                                  Replace(",", ".") +");");
            }

        }


    }

    private void SeleccionarTabParaModificar(string tipo)
    {
        foreach (TabPanel  tab  in this.TabContainer1.Tabs)
                                              tab.Enabled = false;
        switch (tipo)
        {
                case "CHEQUE":
                         this.TabContainer1.Tabs[0].Enabled = true;
                         break;
                case "RETENCION":
                         this.TabContainer1.Tabs[1].Enabled = true;
                         break;
                case "EFECTIVO":
                         this.TabContainer1.Tabs[2].Enabled = true;
                        break;
                case "DEPOSITO":
                        this.TabContainer1.Tabs[3].Enabled = true;
                        break;
                case "TRANSFERENCIA":
                        this.TabContainer1.Tabs[4].Enabled = true;
                        break;
                case "OTRO":
                        this.TabContainer1.Tabs[5].Enabled = true;
                        break;
                case "DESCUENTO":
                        this.TabContainer1.Tabs[6].Enabled = true;
                        break;
            }
    }

    private void HabilitarTabs()
    {
        foreach (TabPanel tab in this.TabContainer1.Tabs)
            tab.Enabled = true;
    }

    protected void btnBuscarFactura_Click(object sender, ImageClickEventArgs e)
    {
        this.Validate("facturasABuscarGroup");
        if (!this.IsValid) { return; }
        System.Drawing.Color col = System.Drawing.Color.Empty;
        ReCalcularSuma();
        MantenerEstadoDeFilasDeshabilitadas();
        foreach (GridViewRow item in this.GvResultadosFacturas.Rows)
        {
            item.BackColor = col;
        }
        foreach (GridViewRow item in this.GvResultadosFacturas.Rows)
        {
            if (item.Cells[1].Text == this.txtNumFactura.Text)
            {
                item.BackColor = System.Drawing.Color.Gold;
            }
        }
        UpdatePanelResultadosDiferenciaLocal.Update();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }

    protected DataTable GvResultadosFacturas_Filling(object sender, EventArgs e)
    {
        List<FacturaDataContracts> resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetAllFacturasPorIdDeudor(int.Parse(this.cmbDeudores.SelectedItem.Value));
        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }

    protected void btnCancelarEditarPago_Click(object sender, EventArgs e)
    {
        this.chkPestreificar.Checked = false;
        this.BlanquearPagos(this.TabContainer1.ActiveTabIndex);
        HabilitarTabs();
    }

    protected void imgBtnLectora_Click(object sender, ImageClickEventArgs e)
    {
        this.txtCuitEmisor.Attributes.Add("onfocus", "MostrarPanelCheque()");
    }

    protected void cmbRecibosDisponibles_TextChanged(object sender, EventArgs e)
    {
        if (this.cmbRecibosDisponibles.Items.Count > 0)
        {
            this.btnGuardarReciboEdicion.Enabled = true;
            this.txtRecibo.Text = this.cmbRecibosDisponibles.SelectedItem.Text;
            updatePanelTxtRecibo.Update();
            _evitarPrerenderGrillaFactura = true;
            this.cmbRecibosDisponibles.ToolTip = this.cmbRecibosDisponibles.SelectedItem.Text;
        }
        else
        {
            this.txtRecibo.Text = string.Empty;
            updatePanelTxtRecibo.Update();
            _evitarPrerenderGrillaFactura = true;
            this.btnGuardarReciboEdicion.Enabled = false;
            this.cmbRecibosDisponibles.ToolTip = string.Empty;
        }
    }

    protected void cmbDeudores_DataBound(object sender, EventArgs e)
    {
     if (this.cmbDeudores.Items.Count > 0)
        {
            this.cmbDeudores.SelectedIndex = 0;
            this.cmbDeudores.ToolTip = this.cmbDeudores.SelectedItem.Text;
        }
    }

    protected void cmbRecibosDisponibles_DataBound(object sender, EventArgs e)
    {
        if (this.cmbRecibosDisponibles.Items.Count > 0)
        {
            this.cmbRecibosDisponibles.SelectedIndex = 0;
            this.txtRecibo.Text = this.cmbRecibosDisponibles.SelectedItem.Text;
            this.cmbRecibosDisponibles.ToolTip = this.cmbRecibosDisponibles.SelectedItem.Text;
        }
        else
        {
            this.txtRecibo.Text = string.Empty;
        }
    }

    protected void GvResultadosFacturas_Sorted(object sender, EventArgs e)
    {
        GridViewRowCollection rows = this.GvResultadosFacturas.Rows;
        foreach (GridViewRow row in rows)
        {
            ((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Importe")].Text;
        }

        this.txtSumaFacturas.Text = "0";
        this.txtSumaFacturasExt.Text = "0";
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            CheckBox chk = (CheckBox)Fila.FindControl("chk");
            chk.Checked = false;
        }

        if (this.GvResultadosFacturas.Rows.Count > 0)
            this.lblResResultadoCantFacts.Text = this.GvResultadosFacturas.Rows.Count.ToString();

        else
            this.lblResResultadoCantFacts.Text = "0";
    }

    protected void SeleccionProntoPago(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked)
        {
            List<ProntoPagoDataContracts> listaProntoPago = new List<ProntoPagoDataContracts>();
            IProntoPagoService prontoPagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
            listaProntoPago = prontoPagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(this.cmbClientes.SelectedItem.Value), int.Parse(this.cmbDeudores.SelectedItem.Value));
            DataTable dt = ConvertDataTable<ProntoPagoDataContracts>.Convert((List<ProntoPagoDataContracts>)listaProntoPago);
            this.gvProntoPago.DataSource = dt;
            this.gvProntoPago.DataBind();
            this.ModalPopupProntoPago.Show();
        }
    }

    private bool IsValidateCampoAImputar(string valor)
    {
        try
        { 
          if (valor==string.Empty) return false;
          double.Parse(valor);
        }
        catch(Exception ex)
        {
            return false;
        }
        return true;
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultadosFacturas.Rows)
        {
            if (!IsValidateCampoAImputar(((TextBox)dr.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text))
            {
                UIUtils.PaintSelectedRow(GvResultadosFacturas, "id Factura", dr.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "id Factura")].Text, System.Drawing.Color.Red);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "aImputarInvalido", "alert('Importe inválido para la factura " + dr.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "id Factura")].Text + ". Verifique los valores de la columna (A imputar).')", true);
                return;
            }
        }
        double suma = 0;
        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultadosFacturas.Rows)
        {
            ((CheckBox)dr.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked = ((CheckBox)sender).Checked;
            if (((CheckBox)sender).Checked)
                suma = suma + double.Parse(((TextBox)dr.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text);
            else 
                suma = 0;
        }
        this.txtSumaFacturas.Text = AplicarFormatoADoble(suma).ToString();
        if(string.IsNullOrEmpty(this.txtCambio.Text))
            this.txtCambio.Text = "1,00";
        this.txtSumaFacturasExt.Text = (double.Parse(this.txtSumaFacturas.Text) / double.Parse(this.txtCambio.Text)).ToString();
        this.UpdatePanelResultados.Update();
    }

    protected void txtCuitEmisor_TextChanged1(object sender, EventArgs e)
    {
        
        ChequeDataContracts resultadoObtenido = new ChequeDataContracts();
        IChequeService chequeServices = ServiceClient<IChequeService>.GetService("ChequeService");
        resultadoObtenido = chequeServices.GetChequeByCuit(((TextBox)sender).Text);
        if (resultadoObtenido!=null)
        {
            this.txtBanco.Text = resultadoObtenido.Banco;
            this.txtSucursal.Text = resultadoObtenido.Sucursal;
            this.txtCuenta.Text = resultadoObtenido.Cuenta;
        }
        this.txtCuenta.Focus();
        this._evitarPrerenderTextBox = true;
    }

    protected void linkButtonRemisionEnCurso_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentanaPequenia2('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewGeneracionPdf.aspx?idRemision=" + this.lblRemisionEnUso.Text +"','_blank','scrollbars=yes');", true);        
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    protected void linkButtonCuit_Click(object sender, EventArgs e)
    {
        DeudorDataContracts resultadoObtenidos = new DeudorDataContracts();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        resultadoObtenidos = deudorServices.GetDeudor(int.Parse(cmbDeudores.SelectedItem.Value.ToString()));
        if (resultadoObtenidos != null)
        {
            this.txtCuitEmisor.Text = resultadoObtenidos.Cuit;
        ChequeDataContracts resultadoCheque = new ChequeDataContracts();
        IChequeService chequeServices = ServiceClient<IChequeService>.GetService("ChequeService");
        resultadoCheque = chequeServices.GetChequeByCuit(this.txtCuitEmisor.Text);

        if (resultadoCheque != null)
        {
            this.txtSucursal.Text = resultadoCheque.Sucursal;
            this.txtCuenta.Text = resultadoCheque.Cuenta;
            this.txtBanco.Text = resultadoCheque.Banco;
            this.txtCp.Focus();
        }
            this._evitarPrerenderTextBox = true;
        }
    }

    protected void btnGuardarReciboEdicion_Click(object sender, EventArgs e)
    {
        try
        {

            btnAgregarPago_Click(null,null);
            MantenerEstadoDeFilasDeshabilitadas();
            this.btnGuardarReciboEdicion.Enabled = true;
            if (!this.IsValid) { return; }
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            ClienteDataContracts clienteDataContracts = clienteServices.GetCliente(decimal.Parse(this.cmbClientes.SelectedItem.Value));
            //Validacion de recibo existente
            IReciboService reciboServices = ServiceClient<IReciboService>.GetService("ReciboService");
            ReciboDataContracts reciboPersistido = reciboServices.Load(new ReciboDataContracts(this.txtRecibo.Text), int.Parse(this.cmbClientes.SelectedItem.Value));
            ReciboDataContracts nuevoRecibo=new ReciboDataContracts();
            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            nuevoRecibo.Id = reciboPersistido.Id;
            nuevoRecibo.Cliente = clienteDataContracts;
            DeudorDataContracts resultadoObtenidos = new DeudorDataContracts();
            IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
            nuevoRecibo.Deudor = deudorServices.GetDeudor(int.Parse(this.cmbDeudores.SelectedItem.Value));
            nuevoRecibo.Numero = this.txtRecibo.Text;
            nuevoRecibo.Cobrador = reciboPersistido.Cobrador;
            nuevoRecibo.SAP = this.txtSAP.Text;
            nuevoRecibo.CompensacionDePago = null;
            nuevoRecibo.TipoDeCambio = AplicarFormatoADoble(double.Parse(this.txtCambio.Text));
            nuevoRecibo.UsadoRemision = true;
            nuevoRecibo.FechaCarga = DateTime.Now;
            if (!string.IsNullOrEmpty(this.txtDiferenciaPe.Text))
            {
                if (double.Parse(this.txtDiferenciaPe.Text)>0)
                {
                    var compensacionDePago = new CompensacionDePagoDataContracts();
                    compensacionDePago.FechaRealizacionCompensacion = DateTime.Now;
                    compensacionDePago.IdCliente = int.Parse(this.cmbClientes.SelectedItem.Value);
                    compensacionDePago.IdCompensacion = 0;
                    compensacionDePago.IdDeudor = int.Parse(this.cmbDeudores.SelectedItem.Value);
                    compensacionDePago.Monto = double.Parse(Request.Params.Get("ctl00$Contentplaceholder1$txtDiferenciaPe"));
                    compensacionDePago.ReciboRelacionado = this.txtRecibo.Text;
                    nuevoRecibo.CompensacionDePago = compensacionDePago;
                }
            }
            //No puede haber recibo sin pagos ingresados

            if ((List<PagoDataContracts >)Session["ListaDePagos"] != null)
            {
                nuevoRecibo.ListadoDePagosIngresados = (List<PagoDataContracts >)Session["ListaDePagos"];
            }
            
            //Con esto tomo todas las facturas seleccionadas
            List<ReciboFacturaDataContracts> listaRecibosFacturas = new List<ReciboFacturaDataContracts>();
            listaRecibosFacturas =ObtenerFacturasSeleccionadas();
            nuevoRecibo.ListadoDeFacturasACancelar = listaRecibosFacturas;
            List<ReciboDataContracts> recibosCargadosPorEnElFront=new List<ReciboDataContracts>();
            if ((List<ReciboDataContracts>)Session["ListaDeRecibosCargados"] != null)
                recibosCargadosPorEnElFront = (List<ReciboDataContracts>)Session["ListaDeRecibosCargados"];
            recibosCargadosPorEnElFront.Add(nuevoRecibo);
            Session["ListaDeRecibosCargados"] = recibosCargadosPorEnElFront;
            //Actualizo la lista del costado
            ListItem nuevoItemListaRecibos=new ListItem(this.cmbClientes.SelectedItem.ToString() + " - " + this.cmbDeudores.SelectedItem.ToString() + " - " + nuevoRecibo.Numero, nuevoRecibo.Numero);
            //Esto es para que actualice el saldo de las facturas seleccionadas
            foreach (ReciboFacturaDataContracts oRecibo in listaRecibosFacturas)
            {
                foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
                {
                    CheckBox chk = (CheckBox)Fila.FindControl("chk");
                    if (chk.Checked)
                    {
                        Fila.Cells[4].Text = String.Format("{0:0.00}", (double.Parse(Fila.Cells[4].Text) - oRecibo.ImporteAImputar));
                        Fila.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Enabled = false;
                    }
                }
            }
            ReCalcularSuma();
            GuardarRecibo(nuevoRecibo);
            FillRecibosDisponibles();
            InicializarRecibo();
            this.HiddenFieldPagosCargados.Value = string.Empty;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "blanquearHiddenFieldPagos", "javascript:BlanquearHiddenFieldPagosCargados();", true);
            Response.Redirect("ViewRemisionDeValores.aspx");
        }
        catch (Exception ex)
        {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "errorAlGuardarRecibo", "javascript:alert('Se ha producido el siguiente error al intentar guardar el recibo: " + ex.Message +"');", true);
        }
    }

    private void MantenerEstadoDeFilasDeshabilitadas()
    {
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            CheckBox chk = (CheckBox) Fila.FindControl("chk");
            TextBox textBox = (TextBox) Fila.FindControl("txtAImputarPorFactura");
            Button button = (Button) Fila.FindControl("ctl01");
            if (chk.Checked)
            {
                textBox.Attributes.Add("disabled", "True");
                button.Attributes.Add("disabled", "True");
            }
            ActualizarSumaFacturas();
            ActualizarTotalesEnPantalla();
        }
    }

    private void GuardarRecibo(ReciboDataContracts nuevoRecibo)
    {
        RemisionDataContracts nuevaRemision = new RemisionDataContracts();
        AnalistaDataContracts nuevoAnalista = new AnalistaDataContracts();//Tomar de sistema
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        nuevoAnalista.Nombre = principal.Identity.Name;
        nuevoAnalista.IdAnalista = ((Gobbi.CoreServices.Security.Principal.GobbiIdentity)principal.Identity).Id; ;
        nuevaRemision.AnalistaGenerador = nuevoAnalista;
        nuevaRemision.NumeroRemision = int.Parse(this.lblRemisionEnUso.Text.ToString());
        //Para aceptar una lista de pagos, ya previamente desde javascript tendria que haber validado
        // que el usuario haya cargado algun pago, sino no puedo guardar un recibo.
        if (Session["ListaDeRecibosCargados"] == null)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "remisionSinPagos", "javascript:alert('Debe insertar algun pago para crear una remisión.');", true);
            return;
        }
        else
        {
            nuevaRemision.ListaDeRecibos = (List<ReciboDataContracts>)Session["ListaDeRecibosCargados"];
        }
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        remisionServices.UpdateReciboEnRemisionParaEdicion(nuevaRemision,nuevoRecibo);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "reciboGuardado", "javascript:alert('El recibo " + nuevaRemision.ListaDeRecibos[0].Numero  + " fue almacenado exitosamente.');", true);
       
       
    }

    private void GuardarReciboParaEdicion(ReciboDataContracts nuevoRecibo)
    {
        RemisionDataContracts nuevaRemision = new RemisionDataContracts();
        AnalistaDataContracts nuevoAnalista = new AnalistaDataContracts();//Tomar de sistema
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        nuevoAnalista.Nombre = principal.Identity.Name;
        nuevoAnalista.IdAnalista = ((Gobbi.CoreServices.Security.Principal.GobbiIdentity)principal.Identity).Id; ;
        nuevaRemision.AnalistaGenerador = nuevoAnalista;
        nuevaRemision.FechaDeCreacion = DateTime.Now;
        nuevaRemision.NumeroRemision = int.Parse(this.lblRemisionEnUso.Text.ToString());
        //Para aceptar una lista de pagos, ya previamente desde javascript tendria que haber validado
        // que el usuario haya cargado algun pago, sino no puedo guardar un recibo.
        if (Session["ListaDeRecibosCargados"] == null)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "remisionSinPagos", "javascript:alert('Debe insertar algun pago para crear una remisión.');", true);
            return;
        }
        else
        {
            nuevaRemision.ListaDeRecibos = (List<ReciboDataContracts>)Session["ListaDeRecibosCargados"];
        }

        nuevaRemision.Estado = "ABIERTA";
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        remisionServices.UpdateReciboEnRemisionParaEdicion(nuevaRemision, nuevoRecibo);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "reciboGuardado", "javascript:alert('El recibo " + nuevaRemision.ListaDeRecibos[0].Numero + " fue almacenado exitosamente.');", true);
    }

    protected void VerDetalleCheques(object sender, ImageClickEventArgs e)
    {
        ActualizarGrillaDetalleCheque();
        this.ModalPopupDetalleCheques.Show();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }

    private List<ReciboFacturaDataContracts> ObtenerFacturasSeleccionadas()
    {
        GridViewRowCollection rows = this.GvResultadosFacturas.Rows;
        List<ReciboFacturaDataContracts> listaRecibosFacturas = new List<ReciboFacturaDataContracts>();
        int pos = 1;
        string contString = string.Empty;
        int cantDigitos=0;
        cantDigitos = rows.Count.ToString().Length;
        if (cantDigitos == 1) cantDigitos++;
        foreach (GridViewRow row in rows)
        {
            pos++;
            string rowName=string.Empty;
            string clientObjectName = string.Empty;
            if (Request.Form["ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" + pos.ToString().PadLeft(cantDigitos, '0') + "$chk"] != null)
            {
                rowName =
                    Request.Form[
                        "ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" + pos.ToString().PadLeft(cantDigitos, '0') +
                        "$chk"].ToString();
                clientObjectName = "ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" + pos.ToString().PadLeft(cantDigitos, '0');
            }
            else
            {
                if (Request.Form["ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" + pos.ToString().PadLeft(cantDigitos - 1, '0') + "$chk"] != null)
                    rowName =
                        Request.Form[
                            "ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" + pos.ToString().PadLeft(cantDigitos - 1, '0') +
                            "$chk"].ToString();
                clientObjectName = "ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" + pos.ToString().PadLeft(cantDigitos - 1, '0');
            }
            if (rowName == "on")
            {
              ReciboFacturaDataContracts reciboFactura = new ReciboFacturaDataContracts();
              reciboFactura.IdFactura =
              int.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "id Factura")].Text);
              //reciboFactura.Importe =
              //          double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe")].Text);
              //reciboFactura.ImporteAImputar =
              //          double.Parse(string.Format("{0:#,#########.####}", reciboFactura.ImporteAImputar - reciboFactura.Saldo));

              //reciboFactura.ImporteProntoPago = "1"; //Esto se debe calcular.
              //reciboFactura.NumRecibo = this.txtRecibo.Text;
              //reciboFactura.Observacion = string.Empty; //La que venga de la grilla
              //reciboFactura.Saldo =
              //      double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "saldo")].Text);
              //reciboFactura.Saldo = reciboFactura.Saldo == 0 ? 0 : double.Parse(string.Format("{0:#,#########.####}", reciboFactura.Saldo));

              reciboFactura.Importe =
              double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe")].Text.Replace(".", ","));
              reciboFactura.ImporteAImputar =
                  double.Parse(((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text.Replace(".", ","));
              reciboFactura.ImporteAImputar =
                  double.Parse(string.Format("{0:#.#####,####}", reciboFactura.ImporteAImputar).Replace(".", ","));
              reciboFactura.ImporteProntoPago = "1"; //Esto se debe calcular.
              reciboFactura.NumRecibo = this.txtRecibo.Text;
              reciboFactura.Observacion = ""; //La que venga de la grilla
              reciboFactura.Saldo =
                  double.Parse(string.Format("{0:#.#####,####}", double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "saldo")].Text.Replace(".", ",")))) - double.Parse(string.Format("{0:#.#####,####}", double.Parse(((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text.Replace(".", ","))));
              reciboFactura.Saldo = reciboFactura.Saldo == 0 ? 0 : double.Parse(string.Format("{0:#.#####,####}", reciboFactura.Saldo).Replace(".", ","));
              reciboFactura.MontoImputacion = reciboFactura.ImporteAImputar;
              listaRecibosFacturas.Add(reciboFactura);
              
            }
       }
       return listaRecibosFacturas;
    }

    private void InicializarRecibo()
    {
        this.txtFechaRecibo.Text = DateTime.Now.ToShortDateString();
        Session["ListaDePagos"] = null;
        ActualizarGrillaCargaPagos();
        this.txtPagos.Text = "0";
        this.txtPagosExt.Text = "0";
        this.txtSumaFacturas.Text = "0";
        this.txtSumaFacturasExt.Text = "0";
        this.txtDiferenciaPe.Text = "0";
        //Para evitar saldos negativos, removemos tldes de la grilla
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            CheckBox chk = (CheckBox)Fila.FindControl("chk");
            chk.Checked = false;
        }
        BlanquearTodosLosPagos();
        LimpiarGrillaFacturas();
        this.TabContainer1.ActiveTabIndex = 0;
        this.HiddenFieldPagosCargados.Value = string.Empty;
        if ((List<ReciboDataContracts>)Session["ListaDeRecibosCargados"] != null)
                                                      Session["ListaDeRecibosCargados"]=null;
        List<DeudorLivianoDataContracts> resultadoObtenidos = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");
        resultadoObtenidos = deudorServices.GetAllDeudorsLivianoPorCriterioCliente(int.Parse(this.cmbClientes.SelectedItem.Value));
        DeudorLivianoDataContracts seleccion = new DeudorLivianoDataContracts();
        seleccion.Nombre = "--- SELECCIONE ---";
        seleccion.IdDeudor = 0;
        resultadoObtenidos.Insert(0, seleccion);
        this.cmbDeudores.Items.Clear();
        this.cmbDeudores.DataSource = resultadoObtenidos;
        this.cmbDeudores.DataTextField = "NOMBRE";
        this.cmbDeudores.DataValueField = "idDeudor";
        this.cmbDeudores.DataBind();
        this.cmbDeudores.Enabled = true;
        this.cmbDeudores.SelectedIndex = 0;
        this.UpdatePanelIndice.Update();
        RemoveSessionObjects();
    }

    private void FiltrarFacturasTemporales(List<FacturaDataContracts> facturasTotalesDelDeudor)
    {
        List<ReciboDataContracts> recibosCargadosTemporalmente=new List<ReciboDataContracts>();
        if ((List<ReciboDataContracts>)Session["ListaDeRecibosCargados"] != null)
            recibosCargadosTemporalmente = (List<ReciboDataContracts>)Session["ListaDeRecibosCargados"];
        foreach (ReciboDataContracts  recibo in recibosCargadosTemporalmente )
        {            
            List<ReciboFacturaDataContracts> listadoDeFacturasACancelar = recibo.ListadoDeFacturasACancelar;
            foreach (ReciboFacturaDataContracts  factura in listadoDeFacturasACancelar )
            {
                foreach (FacturaDataContracts facturaReal in facturasTotalesDelDeudor)
                {
                    if (factura.IdFactura == facturaReal.IdFactura)
                    {
                        facturaReal.Saldo = double.Parse(string.Format("{0:#,#########.####}", factura.Saldo - factura.ImporteAImputar));
                        break;
                    }
                }
            }
        }
    }

    private void ReCalcularSumaClientSide()
    {
        double total = this.GvResultadosFacturas.Rows.Cast<GridViewRow>().Where(row => ((CheckBox) row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked).Aggregate<GridViewRow, double>(0, (current, row) => current + double.Parse(((TextBox) row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text));
        this.txtSumaFacturas.Text = total.ToString();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ReCalcularSumaClientSide", "javascript:ReCalcularSumaClientSide(" + total.ToString() + ");", true);
     }

    private void ReCalcularSuma()
    {
        double total = this.GvResultadosFacturas.Rows.Cast<GridViewRow>().Where(row => ((CheckBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked).Aggregate<GridViewRow, double>(0, (current, row) => current + double.Parse(((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text));
        this.txtSumaFacturas.Text = total.ToString();
        if (string.IsNullOrEmpty(this.txtCambio.Text))
            this.txtCambio.Text = "1,00";
    }

    protected void btnCrearRemision_Click(object sender, EventArgs e)
    {
        RemisionDataContracts oRemision = new RemisionDataContracts();
        AnalistaDataContracts nuevoAnalista= new AnalistaDataContracts();//Tomar de sistema
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        nuevoAnalista.Nombre = principal.Identity.Name;
        nuevoAnalista.IdAnalista = ((Gobbi.CoreServices.Security.Principal.GobbiIdentity)principal.Identity).Id;
        oRemision.AnalistaGenerador = nuevoAnalista;
        oRemision.NumeroRemision = int.Parse(this.lblRemisionEnUso.Text);
        oRemision.FechaDeCreacion = DateTime.Now;
        oRemision.Estado = "CERRADA"; //Hardcodeo horrible.
        //Aca deberi ir todo el proceso de guardar la remision en la base de datos
        //Si la operacion fué exitosa, se debe mostrar el número de remision generado y
        //limpiar toda la pantalla y las variables de sesion
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        remisionServices.Update(oRemision);
        //Se guarda PDF
        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
        ClienteDataContracts clienteDataContracts =clienteServices.GetCliente(decimal.Parse(cmbClientes.SelectedItem.Value));
        GuardarRemision(oRemision.NumeroRemision, clienteDataContracts);
		ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "remisionCerrada", "javascript:alert('La remisión n° " + this.lblRemisionEnUso.Text + " ha sido cerrada definitivamente');", true);
        InicializarRemision();
        RemoveSessionObjects();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "remisionCerrada2", "javascript:ClearRecibos();", true);
    }
    
    protected void cmbRetenciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<SubTipoRetencionMTRDataContracts> resultadoObtenidos = new List<SubTipoRetencionMTRDataContracts>();
        ISubTipoRetencionMTRService subTipoRetencionMTRServices = ServiceClient<ISubTipoRetencionMTRService>.GetService("SubTipoRetencionMTRService");
        resultadoObtenidos = subTipoRetencionMTRServices.GetAllSubTipoRetencionMTRs();
        if (this.cmbRetenciones.SelectedItem.Text == "Ingresos Brutos")
        {
            this.ddlSubTipo.Items.Clear();
            this.ddlSubTipo.DataSource = resultadoObtenidos;
            this.ddlSubTipo.DataTextField = "descripcion";
            this.ddlSubTipo.DataValueField = "id";
            this.ddlSubTipo.DataBind();
        }
        else
        {
            this.ddlSubTipo.Items.Clear();
            this.ddlSubTipo.Items.Add("No aplica");
        }
    }

    protected void GvResultadosFacturas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        this.GvResultadosFacturas.SelectedIndex = e.NewSelectedIndex;
        GridViewRow Fila = this.GvResultadosFacturas.SelectedRow;
        CheckBox chk = (CheckBox)Fila.FindControl("chk");
        if (chk.Checked)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "BotonProntoPagoInhabilitado", "javascript:alert('No puede ver el pronto pago si la factura se encuentra tildada.');", true);
            return;
        }

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (mgr.Contains("seleccionItemProntoPago"))
            mgr.Remove("seleccionItemProntoPago");
            mgr.Add("seleccionItemProntoPago", e.NewSelectedIndex);
            List<ProntoPagoDataContracts> listaProntoPago = new List<ProntoPagoDataContracts>();
            IProntoPagoService prontoPagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
            listaProntoPago = prontoPagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(this.cmbClientes.SelectedItem.Value), int.Parse(this.cmbDeudores.SelectedItem.Value));
            foreach (ProntoPagoDataContracts  pronto in listaProntoPago)
            {
                pronto.FechaLimiteDescuento = DateTime.Parse(this.GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Vencimiento")].Text).AddDays(-pronto.DiasDeAnticipacion);
            }
            DataTable dt = ConvertDataTable<ProntoPagoDataContracts>.Convert((List<ProntoPagoDataContracts>)listaProntoPago);
            this.gvProntoPago.DataSource = dt;
            this.gvProntoPago.DataBind();
            this.txtImporteActual.Text = this.GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Saldo")].Text;
            this.lblVencimientoFactRes.Text = this.GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "vencimiento")].Text;
            this.txtImporteProntoPago.Text = string.Empty;
            this.ModalPopupProntoPago.Show();
            UIUtils.PaintSelectedRow(this.GvResultadosFacturas, "id factura", this.GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "id Factura")].Text);
    }

    protected void gvProntoPago_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int indexSelect = e.NewSelectedIndex;
        this.gvProntoPago.SelectedIndex = e.NewSelectedIndex;
        this.txtImporteProntoPago.Text = (double.Parse(this.gvProntoPago.SelectedRow.Cells[UIUtils.GetPosCol(this.gvProntoPago, "Porcentaje(%)")].Text) * double.Parse(this.txtImporteActual.Text.Replace(".", ",")) / 100).ToString(); UIUtils.PaintSelectedRow(this.gvProntoPago, "id", (e.NewSelectedIndex + 1).ToString().Replace(",", "."));
        this.ModalPopupProntoPago.Show();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }

    
    protected void RadioButtonEstadoRemision_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((RadioButtonList)sender).SelectedValue == "Abierta")
        {
            this.btnNuevaRemision.Text = "Buscar Remisión";
        }
        else
        {
            this.btnNuevaRemision.Text = "Crear Remisión";
        }
     }

    protected void btnNuevaRemision_Click(object sender, EventArgs e)
    {
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        RemisionDataContracts nuevaRemision = new RemisionDataContracts();
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        AnalistaDataContracts nuevoAnalista = new AnalistaDataContracts();
        nuevoAnalista.Nombre = principal.Identity.Name;
        nuevoAnalista.IdAnalista = ((Gobbi.CoreServices.Security.Principal.GobbiIdentity)principal.Identity).Id;
        nuevaRemision.AnalistaGenerador = nuevoAnalista;
        nuevaRemision.IDCliente = int.Parse(this.cmbClientes.SelectedValue);
        nuevaRemision.Estado = "ABIERTA";
        nuevaRemision.FechaDeCreacion = DateTime.Now;
        int remisionTemporal = remisionServices.InsertCabecera(nuevaRemision);
        this.panelGeneralCuerpoPagina.Enabled = true;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:PopupRemisionCreadaOk();", true);
        this.TabPanel1.Focus();
        RemoveSessionObjects();
    }

    protected void btnRemisionEnUso_Click(object sender, EventArgs e)
    {
        InicializarRemision();
        List<RemisionDataContracts> listaRemisiones = new List<RemisionDataContracts>();
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        listaRemisiones = remisionServices.GetAllRemisionsBlocked();
        DataTable dt = ConvertDataTable<RemisionDataContracts>.Convert((List<RemisionDataContracts>)listaRemisiones);
        this.gvResultadosConcurrencia.DataSource = dt;
        this.gvResultadosConcurrencia.DataBind();
        this.panelGeneralCuerpoPagina.Enabled = true;
        this.ModalPopupDetalleControlConcurrencia.Show();
        this.HiddenFieldPagosCargados.Value = string.Empty;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }

    protected void chkCP_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkCP.Checked)
        {
            this.txtFechaVencimiento.Enabled = false;
            this.txtFechaVencimiento.Text = DateTime.MaxValue.ToString();
        }
        else
        {
            this.txtFechaVencimiento.Enabled = true;
            this.txtFechaVencimiento.Text = string.Empty;
        }
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }

    private int BloquearDeudor_Click(string nuevoDeudor, string anteriorDeudor)
    {
        string res = string.Empty;
        try
        {
            if (this.cmbDeudores.SelectedItem.Value != "0")
            {
                ControlRemisionConcurrenciaDataContracts controlRemision = new ControlRemisionConcurrenciaDataContracts();
                controlRemision.DatoBloqueado = this.cmbDeudores.SelectedItem.Text;
                controlRemision.EstadoLock =Session.SessionID + "/LOCK";
                controlRemision.FechaInicioLock = DateTime.Now;
                controlRemision.FechaForceUnlock = DateTime.Now;
                controlRemision.NumRemision = this.lblRemisionEnUso.Text;
                GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
                controlRemision.UsuarioLock = (principal.Identity.Name);
                IControlRemisionConcurrenciaService controlRemisionServices = ServiceClient<IControlRemisionConcurrenciaService>.GetService("ControlRemisionConcurrenciaService");
                res = controlRemisionServices.InsertWithResult(controlRemision);
                if (res != string.Empty)
                    throw new Exception();
                //Elimino el anterior deudor bloqueado
                if (string.Empty!=this.lblSelDeu.Text)
                {
                    controlRemision.DatoBloqueado = this.lblSelDeu.Text;
                    controlRemisionServices.Delete(controlRemision);
                }
                this.lblSelDeu.Text = this.cmbDeudores.SelectedItem.ToString();
                return 0;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('Seleccione un deudor.');", true);
                return -1;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('El deudor que esta intentando bloquear, esta siendo utilizado por " + res + ". ');", true);
            return -1;
        }         
    }

    protected void ibtnBloquearDeudor_Click(object sender, ImageClickEventArgs e)
    {
        string res=string.Empty;
        try
        {
            if (this.cmbDeudores.SelectedItem.Value != "0")
            {
                ControlRemisionConcurrenciaDataContracts controlRemision = new ControlRemisionConcurrenciaDataContracts();
                controlRemision.DatoBloqueado = this.cmbDeudores.SelectedItem.Text;
                controlRemision.EstadoLock = "LOCK";
                controlRemision.FechaInicioLock = DateTime.Now;
                controlRemision.FechaForceUnlock = DateTime.Now;
                controlRemision.NumRemision = this.lblRemisionEnUso.Text;
                GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
                controlRemision.UsuarioLock = (principal.Identity.Name);
                IControlRemisionConcurrenciaService controlRemisionServices = ServiceClient<IControlRemisionConcurrenciaService>.GetService("ControlRemisionConcurrenciaService");
                res = controlRemisionServices.InsertWithResult(controlRemision);
                if (res != string.Empty)
                    throw new Exception();
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('Deudor " + this.cmbDeudores.SelectedItem.Text + " bloqueado con éxito');", true);
                this.cmbDeudores.Enabled = false;
                this.cmbClientes.Enabled = false;
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('Seleccione un deudor.');", true);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('El deudor que esta intentando bloquear, esta siendo utilizado por " + res + ". ');", true);
      
        }         
    }

    protected void btnNuevaRemisionTemporal_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument.ToString()=="CREAR")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "crearNuevaRemision", "javascript:VerificarConfirmacionNuevaRemision();", true);
            this.btnNuevaRemision.Focus();
        }
        else
        {
            //Aca cancelo todo
            this.cmbClientes.Enabled = true;
            this.cmbDeudores.Enabled = true;
            this.cmbDeudores.Items.Clear();
            this.cmbRecibosDisponibles.Items.Clear();
            this.HiddenFieldPagosCargados.Value = string.Empty;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
            ControlRemisionConcurrenciaDataContracts controlRemision = new ControlRemisionConcurrenciaDataContracts();
            controlRemision.DatoBloqueado = this.lblSelDeu.Text;
            controlRemision.EstadoLock = Session.SessionID + "/OPERACION_CANCELADA";
            controlRemision.FechaInicioLock = DateTime.Now;
            controlRemision.FechaForceUnlock = DateTime.Now;
            controlRemision.NumRemision = this.lblRemisionEnUso.Text;
            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            controlRemision.UsuarioLock = (principal.Identity.Name);
            IControlRemisionConcurrenciaService controlRemisionServices = ServiceClient<IControlRemisionConcurrenciaService>.GetService("ControlRemisionConcurrenciaService");
            controlRemisionServices.Update(controlRemision);
            InicializarRemision();
            this.HiddenFieldPagosCargados.Value = string.Empty;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
       }
        
    }

    private void InicializarRemision()
    {
        this.txtCambio.Text = "1,00"; //Horrible;
        this.txtFechaRecibo.Text = DateTime.Now.ToShortDateString();
        Session["ListaDePagos"] = null;
        this.txtPagos.Text = "0";
        this.txtSumaFacturas.Text = "0";
        BlanquearTodosLosPagos();
        LimpiarGrillaFacturas();
        this.TabContainer1.ActiveTabIndex = 0;
        this.panelGeneralCuerpoPagina.Enabled = false;
        this.cmbClientes.SelectedIndex = 0;
        this.cmbDeudores.Items.Clear();
        this.cmbDeudores.Enabled = false;
        this.lblRemisionEnUso.Text = string.Empty;
        this.lblSelDeu.Text = string.Empty;
        this.cmbClientes.Enabled = true;
        this.updatePanelRemisionEnUso.Update();
        this.HiddenFieldPagosCargados.Value = string.Empty;
        this.panelGeneralCuerpoPagina.Enabled = false;
        this.txtRecibo.Text = string.Empty;
        this.UpdatePanelIndice.Update();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }

    private void InicializarRemisionPorPostback()
    {
        this.txtCambio.Text = "1,00"; //Horrible;
        this.txtFechaRecibo.Text = DateTime.Now.ToShortDateString();
        Session["ListaDePagos"] = null;
        ActualizarGrillaCargaPagos();
        this.txtPagos.Text = "0";
        this.txtSumaFacturas.Text = "0";
        BlanquearTodosLosPagos();
        LimpiarGrillaFacturas();
        this.TabContainer1.ActiveTabIndex = 0;
        this.panelGeneralCuerpoPagina.Enabled = false;
        this.lblSelDeu.Text = string.Empty;
        this.cmbClientes.Enabled = true;
        this.updatePanelRemisionEnUso.Update();
        this.HiddenFieldPagosCargados.Value = string.Empty;
        this.panelGeneralCuerpoPagina.Enabled = false;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
            this.lblRemisionEnUso.Text = string.Empty;
    }


    private void GuardarRemision(int idRemision, ClienteDataContracts cliente)
    {
        CreaarPdf(idRemision);
        //Se envia el mail si está chequeado:
        try
        {
            if (chkMail.Checked)
                EnviarRemision("/Remision" + idRemision.ToString() + ".pdf",cliente.EMAIL);
            chkMail.Checked = false;

        }
        catch (Exception)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Enviado", "alert('Email no enviado: No se puede conectar al servidor de correo. Deberá enviarlo manualmente.');", true);
        }
    }

    private void CreaarPdf(int idRemision)
    {
        RemisionDataContracts oRemision = new RemisionDataContracts();
        IRemisionService remisionService = ServiceClient<IRemisionService>.GetService("RemisionService");
        oRemision = remisionService.GetRemision(idRemision);
        List<ReciboDataContracts> lstRecibo = new List<ReciboDataContracts>();
        IReciboService reciboService = ServiceClient<IReciboService>.GetService("ReciboService");
        lstRecibo = reciboService.GetAllRecibosByIdRemision(idRemision);
        //Se declara un nuevo objeto documento
        iTextSharp.text.Document oDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
        //Ruta donde se guardan los pdf y las imagenes y el nombre del archivo
        string pszRuta = Server.MapPath("../PDF");
        string pszImagenes = Server.MapPath("../Images");
        string pszArchivo = "/Remision" + idRemision.ToString() + ".pdf";
        try
        {
            //Se obtiene la instancia y se abre el documento:
            PdfWriter.GetInstance(oDoc, new FileStream(pszRuta + pszArchivo, FileMode.Create));
            oDoc.Open();
            //Trabajar con el documento:
            iTextSharp.text.Image fotoEmacsa = iTextSharp.text.Image.GetInstance(pszImagenes + "/fotoEmacsa.png");
            //fotoEmacsa.ScalePercent(24f);
            fotoEmacsa.ScaleAbsoluteWidth(oDoc.PageSize.Width);
            fotoEmacsa.ScaleAbsoluteHeight(124f);
            fotoEmacsa.SetAbsolutePosition(1f, oDoc.PageSize.Height - 98f);
            oDoc.Add(fotoEmacsa);
            iTextSharp.text.Chunk oChunk = new iTextSharp.text.Chunk("EMAC S.A.", iTextSharp.text.FontFactory.GetFont("dax-black", 24f));
            oChunk.SetUnderline(1.5f, -7.5f);
            string pszHeader = "\n\nNúmero de Remisión:         " + idRemision.ToString() + "                                            Fecha de Remisión:          " + DateTime.Now.Date.ToShortDateString();
            iTextSharp.text.Chunk chnkHeader = new iTextSharp.text.Chunk(pszHeader, iTextSharp.text.FontFactory.GetFont("Arial", 10f));
            iTextSharp.text.Phrase oPhrase = new iTextSharp.text.Phrase();
            oPhrase.Add(oChunk);
            oPhrase.Add(chnkHeader);
            oDoc.Add(oPhrase);
            //Creacion de fuente
            iTextSharp.text.pdf.BaseFont bfTimes = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, false);
            iTextSharp.text.Font fTimes = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            if (lstRecibo.Count==0)
            {
                string pszSinDatos = "\n\nRemisión de valores sin recibos cargados...";
                iTextSharp.text.Phrase oPhrase2 = new iTextSharp.text.Phrase(pszSinDatos, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.RED));
                oDoc.Add(oPhrase2);
                oDoc.Close();
                return;
            }

            string pszEmpresaCliente = "\n\nEmpresa:               " + lstRecibo[0].Cliente.NOMBRE + "\nCliente:                 " + lstRecibo[0].Deudor.Nombre + "           (" + lstRecibo[0].Deudor.IdDeudor.ToString() + ")\n";
            iTextSharp.text.Chunk chnkEmpresaCliente = new iTextSharp.text.Chunk(pszEmpresaCliente, fTimes);
            iTextSharp.text.Phrase obPhrase = new iTextSharp.text.Phrase();
            obPhrase.Add(chnkEmpresaCliente);
            oDoc.Add(obPhrase);
            iTextSharp.text.pdf.draw.LineSeparator oSeparador = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, iTextSharp.text.BaseColor.BLACK, 0, 0f);
            iTextSharp.text.Chunk chnkSeparador = new iTextSharp.text.Chunk(oSeparador);
            oDoc.Add(chnkSeparador);

            //Aca empieza el laburo groso. Este proceso se debería repetir por cada recibo:
            foreach (ReciboDataContracts oRecibo in lstRecibo)
            {
                //Armar la tabla con la cabecera: Cambio | Recibo | Fecha
                PdfPTable oTabla = new PdfPTable(3);

                PdfPCell CeldaCambio = new PdfPCell(new iTextSharp.text.Phrase("Cambio: " + oRecibo.TipoDeCambio.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                oTabla.AddCell(CeldaCambio);

                PdfPCell CeldaRecibo = new PdfPCell(new iTextSharp.text.Phrase("Recibo: " + oRecibo.Numero, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                oTabla.AddCell(CeldaRecibo);

                PdfPCell CeldaFecha = new PdfPCell(new iTextSharp.text.Phrase("Fecha de Recibo: " + oRecibo.FechaCarga.ToString().Substring(0, 10), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                oTabla.AddCell(CeldaFecha);

                PdfPRow pdfpRow = oTabla.Rows[0];
                foreach (PdfPCell pc in pdfpRow.GetCells())
                {
                    pc.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    pc.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    pc.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                }

                oDoc.Add(oTabla);
                //Armar la tabla con pagos (Numero | Tipo | Importe) e Imputaciones (Id_Factura | TipoCompr. + Letra + Emision | Imputado)

                #region Armado de Tabla
                PdfPTable oTablaPagosImputaciones = new PdfPTable(7);

                PdfPCell CeldaPagos = new PdfPCell(new iTextSharp.text.Phrase("PAGOS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 08f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                CeldaPagos.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaPagos.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                CeldaPagos.Colspan = 4;
                oTablaPagosImputaciones.AddCell(CeldaPagos);

                PdfPCell CeldaImputaciones = new PdfPCell(new iTextSharp.text.Phrase("IMPUTACIONES", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 08f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                CeldaImputaciones.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaImputaciones.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                CeldaImputaciones.Colspan = 3;
                oTablaPagosImputaciones.AddCell(CeldaImputaciones);

                PdfPCell CeldaFechaPago = new PdfPCell(new iTextSharp.text.Phrase("Fecha", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                CeldaFechaPago.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaFechaPago.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                oTablaPagosImputaciones.AddCell(CeldaFechaPago);

                PdfPCell CeldaNumPago = new PdfPCell(new iTextSharp.text.Phrase("Número", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                CeldaNumPago.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaNumPago.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                oTablaPagosImputaciones.AddCell(CeldaNumPago);

                PdfPCell CeldaImportePago = new PdfPCell(new iTextSharp.text.Phrase("Importe", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                CeldaImportePago.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaImportePago.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                oTablaPagosImputaciones.AddCell(CeldaImportePago);

                PdfPCell CeldaTipoPago = new PdfPCell(new iTextSharp.text.Phrase("Tipo", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                CeldaTipoPago.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaTipoPago.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                oTablaPagosImputaciones.AddCell(CeldaTipoPago);

                PdfPCell CeldaIdFact = new PdfPCell(new iTextSharp.text.Phrase("Id. Factura", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                CeldaIdFact.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaIdFact.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                oTablaPagosImputaciones.AddCell(CeldaIdFact);

                PdfPCell CeldaDocFact = new PdfPCell(new iTextSharp.text.Phrase("Documento", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                CeldaDocFact.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaDocFact.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                oTablaPagosImputaciones.AddCell(CeldaDocFact);

                PdfPCell CeldaImpFact = new PdfPCell(new iTextSharp.text.Phrase("Imputado", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                CeldaImpFact.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                CeldaImpFact.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                oTablaPagosImputaciones.AddCell(CeldaImpFact);

                #endregion

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
                    #region Switch Forma de Pago
                    switch (unPago.FormaPago.Descripcion)
                    {
                        case "CHEQUE":

                            ChequeDataContracts oCheque = new ChequeDataContracts();
                            IChequeService chequeService = ServiceClient<IChequeService>.GetService("ChequeService");
                            oCheque = chequeService.GetCheque(unPago.IdPago);
                            unPago.FechaPago = oCheque.Vencimiento;
                            unPago.Importe = oCheque.Importe;
                            unPago.IdMoneda = oReciboPago.IdMoneda;
                            unPago.TotalPesificado = oReciboPago.TotalPesificado;
                            break;
                        case "EFECTIVO":

                            EfectivoDataContracts oEfectivo = new EfectivoDataContracts();
                            IEfectivoService efectivoService = ServiceClient<IEfectivoService>.GetService("EfectivoService");
                            oEfectivo = efectivoService.GetEfectivo(unPago.IdPago);
                            unPago.FechaPago = oEfectivo.FechaPago;
                            unPago.Importe = oEfectivo.Monto;
                            unPago.IdMoneda = oReciboPago.IdMoneda;
                            unPago.TotalPesificado = oReciboPago.TotalPesificado;
                            break;
                        case "RETENCION":
                            RetencionDataContracts oRetencion = new RetencionDataContracts();
                            IRetencionService retencionService = ServiceClient<IRetencionService>.GetService("RetencionService");
                            oRetencion = retencionService.GetRetencion(unPago.IdPago);
                            unPago.FechaPago = oRetencion.FechaPago;
                            unPago.Importe = oRetencion.Importe;
                            unPago.IdMoneda = oReciboPago.IdMoneda;
                            unPago.TotalPesificado = oReciboPago.TotalPesificado;
                            break;
                        case "DEPOSITO":

                            DepositoDataContracts oDeposito = new DepositoDataContracts();
                            IDepositoService depositoService = ServiceClient<IDepositoService>.GetService("DepositoService");
                            oDeposito = depositoService.GetDeposito(unPago.IdPago);
                            unPago.FechaPago = oDeposito.FechaCarga;
                            unPago.Importe = oDeposito.Importe;
                            unPago.IdMoneda = oReciboPago.IdMoneda;
                            unPago.TotalPesificado = oReciboPago.TotalPesificado;
                            break;
                        case "TRANSFERENCIA":

                            TransferenciaDataContracts oTransferencia = new TransferenciaDataContracts();
                            ITransferenciaService transferenciaService = ServiceClient<ITransferenciaService>.GetService("TransferenciaService");
                            oTransferencia = transferenciaService.GetTransferencia(unPago.IdPago);
                            unPago.FechaPago = oTransferencia.FechaCarga;
                            unPago.Importe = oTransferencia.Importe;
                            unPago.IdMoneda = oReciboPago.IdMoneda;
                            unPago.TotalPesificado = oReciboPago.TotalPesificado;
                            break;
                        case "OTRO":

                            OtroPagoDataContracts oOtroPago = new OtroPagoDataContracts();
                            IOtroPagoService otroPagoService = ServiceClient<IOtroPagoService>.GetService("OtroPagoService");
                            oOtroPago = otroPagoService.GetOtroPago(unPago.IdPago);
                            unPago.FechaPago = oOtroPago.FechaCarga;
                            unPago.Importe = oOtroPago.Importe;
                            unPago.IdMoneda = oReciboPago.IdMoneda;
                            unPago.TotalPesificado = oReciboPago.TotalPesificado;
                            break;
                        case "DESCUENTO":

                            DescuentoDataContracts oDescuento = new DescuentoDataContracts();
                            IDescuentoService descuentoService = ServiceClient<IDescuentoService>.GetService("DescuentoService");
                            oDescuento = descuentoService.GetDescuento(unPago.IdPago);
                            unPago.FechaPago = oDescuento.FechaCarga;
                            unPago.Importe = oDescuento.Importe;
                            unPago.IdMoneda = oReciboPago.IdMoneda;
                            unPago.TotalPesificado = oReciboPago.TotalPesificado;
                            break;
                    }
                    #endregion
                    lstPagos.Add(unPago);

                }

                PdfPTable oTblPagos = new PdfPTable(4);
                double ImportePagoTotal = 0;
                foreach (PagoDataContracts oPago in lstPagos)
                {
                    PdfPCell CeldaFechaPagoV = new PdfPCell(new iTextSharp.text.Phrase(oPago.FechaPago.Date.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    oTblPagos.AddCell(CeldaFechaPagoV);

                    PdfPCell CeldaIdPagoV = new PdfPCell(new iTextSharp.text.Phrase(oPago.IdPago.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    oTblPagos.AddCell(CeldaIdPagoV);

                    PdfPCell CeldaImporteDePagoV = new PdfPCell(new iTextSharp.text.Phrase("(" + TomarSimboloMoneda(oPago.IdMoneda) + ") " + oPago.Importe.ToString() , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    oTblPagos.AddCell(CeldaImporteDePagoV);

                    PdfPCell CeldaTipoDePagoV = new PdfPCell(new iTextSharp.text.Phrase(oPago.FormaPago.Descripcion, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    oTblPagos.AddCell(CeldaTipoDePagoV);

                    ImportePagoTotal += oPago.TotalPesificado;
                }
                

                PdfPCell CeldaTablaPagos = new PdfPCell(oTblPagos);
                CeldaTablaPagos.Colspan = 4;

                foreach (PdfPRow Fila1 in oTblPagos.Rows)
                {
                    foreach (PdfPCell Celda1 in Fila1.GetCells())
                    {
                        Celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        Celda1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    }
                }

                oTablaPagosImputaciones.AddCell(CeldaTablaPagos);

                //Armado de Tabla Imputaciones
                List<ReciboFacturaDataContracts> lstReciboFacturas = new List<ReciboFacturaDataContracts>();
                IReciboFacturaService recibofacturaService = ServiceClient<IReciboFacturaService>.GetService("ReciboFacturaService");
                lstReciboFacturas = recibofacturaService.GetAllReciboFacturasByIdRecibo(oRecibo.Id);

                PdfPTable oTblImputaciones = new PdfPTable(3);
                double ImporteImputacionesTotal = 0;
                foreach (ReciboFacturaDataContracts oReciboFactura in lstReciboFacturas)
                {
                    PdfPCell CeldaIdFactura = new PdfPCell(new iTextSharp.text.Phrase(oReciboFactura.IdFactura.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    oTblImputaciones.AddCell(CeldaIdFactura);

                    FacturaDataContracts oFactura = new FacturaDataContracts();
                    IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
                    oFactura = facturaService.GetFactura(oReciboFactura.IdFactura);

                    string pszDocumento = oFactura.Id_Tipo_Comprobante + " " + oFactura.Letra + " " + oFactura.Emision + "-" + oFactura.NumeroComp;

                    PdfPCell CeldaDocumentoFact = new PdfPCell(new iTextSharp.text.Phrase(pszDocumento, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    oTblImputaciones.AddCell(CeldaDocumentoFact);

                    PdfPCell CeldaImporteAImputar = new PdfPCell(new iTextSharp.text.Phrase(AplicarFormatoADoble(oReciboFactura.ImporteAImputar).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                    oTblImputaciones.AddCell(CeldaImporteAImputar);

                    ImporteImputacionesTotal += oReciboFactura.ImporteAImputar;
                }

                PdfPCell CeldaTablaImputaciones = new PdfPCell(oTblImputaciones);
                CeldaTablaImputaciones.Colspan = 3;

                foreach (PdfPRow Fila2 in oTblImputaciones.Rows)
                {
                    foreach (PdfPCell Celda2 in Fila2.GetCells())
                    {
                        Celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        Celda2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    }
                }

                oTablaPagosImputaciones.AddCell(CeldaTablaImputaciones);

                //Totales de pagos y totales de imputaciones
                PdfPCell CeldaTotalPagos = new PdfPCell(new iTextSharp.text.Phrase("Total de pagos de " + oRecibo.Numero + ":       $ " + AplicarFormatoADoble(ImportePagoTotal).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                CeldaTotalPagos.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                CeldaTotalPagos.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                CeldaTotalPagos.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                CeldaTotalPagos.Colspan = 4;
                oTablaPagosImputaciones.AddCell(CeldaTotalPagos);

                PdfPCell CeldaTotalImputaciones = new PdfPCell(new iTextSharp.text.Phrase("Imputado en recibo  " + oRecibo.Numero + ":       $ " + AplicarFormatoADoble(ImporteImputacionesTotal).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                CeldaTotalImputaciones.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                CeldaTotalImputaciones.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                CeldaTotalImputaciones.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                CeldaTotalImputaciones.Colspan = 3;
                oTablaPagosImputaciones.AddCell(CeldaTotalImputaciones);

                oDoc.Add(oTablaPagosImputaciones);

                PdfPTable oTblCompensaciones = new PdfPTable(1);

                ICompensacionDePagoService compensacionDePagoService = ServiceClient<ICompensacionDePagoService>.GetService("CompensacionDePagoService");

                CompensacionDePagoDataContracts compensacion = compensacionDePagoService.GetCompensacionDePagoPorNumeroDeRecibo(oRecibo.Numero);

                PdfPCell CeldaCompensaciones = new PdfPCell(new iTextSharp.text.Phrase("Saldo a favor: $ " + AplicarFormatoADoble(compensacion.Monto).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                CeldaCompensaciones.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                CeldaCompensaciones.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                CeldaCompensaciones.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                CeldaCompensaciones.Colspan = 4;
                oTblCompensaciones.AddCell(CeldaCompensaciones);
                oDoc.Add(oTblCompensaciones);
                oDoc.Add(chnkSeparador);
            }

        }
        catch (iTextSharp.text.DocumentException dEx)
        {
            //Response.Write(dEx.Message);
        }
        catch (IOException ioEx)
        {
            //Response.Write(ioEx.Message);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Enviado", "alert('Ocurrió un error al intentar crear el archivo PDF. Infórmelo al administrador.');", true);
        }
        finally
        {
            //Cerrar el documento
            oDoc.Close();
        }
    }

    protected void btnRefreshCmbDeudores_Click(object sender, ImageClickEventArgs e)
    {
        //Si refresco el deudor, elimino los pagos cargados, totales y facturas.
        List<DeudorLivianoDataContracts> resultadoObtenidos = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");
        resultadoObtenidos = deudorServices.GetAllDeudorsLivianoPorCriterioCliente(int.Parse(this.cmbClientes.SelectedItem.Value));
        DeudorLivianoDataContracts seleccion = new DeudorLivianoDataContracts();
        seleccion.Nombre = "--- SELECCIONE ---";
        seleccion.IdDeudor = 0;
        resultadoObtenidos.Insert(0, seleccion);
        this.cmbDeudores.Items.Clear();
        this.cmbDeudores.DataSource = resultadoObtenidos;
        this.cmbDeudores.DataTextField = "NOMBRE";
        this.cmbDeudores.DataValueField = "idDeudor";
        this.cmbDeudores.DataBind();
        InicializarRecibo();
        this.HiddenFieldPagosCargados.Value = string.Empty;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
        UpdatePanelIndice.Update();
    }

    protected void btnCerrarModalRemisionesAbiertas_Click(object sender, EventArgs e)
    {
        this.ModalPopupDetalleControlConcurrencia.Hide();
        this.panelGeneralCuerpoPagina.Enabled = false;
        this.UpdatePanelIndice.Update();
    }

    protected void gvResultadosConcurrencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idRemision = ((GridView)sender).SelectedDataKey.Value.ToString();
        string idCliente=((GridView)sender).SelectedRow.Cells[UIUtils.GetPosCol(((GridView)sender),"ID Cliente")].Text;
        ListItem item = this.cmbClientes.SelectedItem;
        item.Selected = false;
        item = ((ListItem)this.cmbClientes.Items.FindByValue(idCliente));
        item.Selected = true;
        this.lblRemisionEnUso.Text = idRemision;
        this.cmbClientes.Enabled = false;
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string usuario = (principal.Identity.Name);
        if (usuario == ((GridView)sender).SelectedRow.Cells[UIUtils.GetPosCol(((GridView)sender), "Analista Creador")].Text)
        {
            this.btnCrearRemision.Enabled = true;
        }
        else {
            this.btnCrearRemision.Enabled = false;
        }
        cmbClientes_SelectedIndexChanged(sender, null);
        this.cmbClientes.DataBind();
        this.UpdatePanelIndice.Update();
        this.updatePanelRemisionEnUso.Update();
        this.ModalPopupDetalleControlConcurrencia.Hide();
        this.HiddenFieldPagosCargados.Value = string.Empty;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AsignarHiddenFieldATabla", "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ActualizarDiferenciaPagosFacturasPantallaEdicion", "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }

 private void EnviarRemision(string pszArchivo, string destinatario)
    {
        string isTest=ConfigurationManager.AppSettings["isTest"].ToString();
        if (isTest=="Test")
            destinatario = "stgugliotta@gmail.com";

        System.Net.Mail.MailMessage Correo = new System.Net.Mail.MailMessage();
        Correo.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["fromSmtp" + ConfigurationManager.AppSettings["isTest"]]);//Si se quiere comprobar, agregar una cuenta de yahoo         
        Correo.To.Add(destinatario);
        Correo.Bcc.Add("stgugliotta@gmail.com");   //Si se quiere probar, poner cualquier cuenta
        Correo.Bcc.Add("fmperfetti@hotmail.com");
        Correo.Bcc.Add("gabrielsanblas@gmail.com"); 

        Correo.Subject = "EMACSA - Nueva Remision de Valores";      //Completar el asunto
        Correo.Body = string.Empty;
        Correo.IsBodyHtml = false;
        Correo.Priority = System.Net.Mail.MailPriority.Normal;

        //Adjunto:
        System.Net.Mail.Attachment oAdjunto = new System.Net.Mail.Attachment(Server.MapPath("../PDF" + pszArchivo));
        Correo.Attachments.Add(oAdjunto);

        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = ConfigurationManager.AppSettings["smtp" + ConfigurationManager.AppSettings["isTest"]];
        //Si se quiere probar, usar el smtp de yahoo (smtp.mail.yahoo)
        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["usuarioSmtp" + ConfigurationManager.AppSettings["isTest"]], ConfigurationManager.AppSettings["passSmtp" + ConfigurationManager.AppSettings["isTest"]]);
        //Si se quiere prbar, completar con el nombre de usuario (sin @yahoo.com ni nada) y el pass.
        try
        {
            smtp.Send(Correo);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Enviado", "alert('Remision enviada por mail.');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Enviado", "alert('Mensaje no enviado: No se puede conectar al servidor de correo. Deberá enviarlo manualmente.');", true);
        }
    }
}
