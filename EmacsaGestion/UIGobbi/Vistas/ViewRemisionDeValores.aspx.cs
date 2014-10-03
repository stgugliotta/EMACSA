using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.Caching;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.services;
using Herramientas;
using Implementation;
//iTextSharp para crear PDF
    //idem
    //Manipular IO


public partial class Vistas_ViewRemisionDeValores : GobbiPage
{
    private bool _evitarPrerenderGrillaFactura;
    private bool _evitarPrerenderTextBox;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnCrearRemision.Enabled = false;
            btnNuevaRemisionTemporal.Enabled = false;
            this.txtFechaRecibo.Text = DateTime.Now.ToShortDateString();
            ddlSubTipo.Items.Clear();
            ddlSubTipo.Items.Add(new ListItem("No aplica", "0"));
            var clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            clientes = clienteServices.GetAllClientes();
            cmbClientes.DataSource = clientes;
            cmbClientes.DataTextField = "NOMBRE";
            cmbClientes.DataValueField = "idCliente";
            cmbClientes.DataBind();

            #region SOLAPA CHEQUES

            //this.btnEditarPago.ValidationGroup = "chequeGroup";
            btnGuardarRecibo.ValidationGroup = "reciboGroup";

            txtSumaFacturas.Text = "0";
            txtSumaFacturasExt.Text = "0";
            txtPagos.Text = "0";
            txtPagosExt.Text = "0";
            ActualizarGrillaCargaPagos();
            this.panelGeneralCuerpoPagina.Enabled = false;

            var listaBancos = new List<BancoDataContracts>();
            IBancoService bancoServices = new BancoService();
            var seleccionBanco = new BancoDataContracts();
            seleccionBanco.Descripcion = "--- SELECCIONE ---";
            seleccionBanco.Codigo = "";
            listaBancos = bancoServices.GetAllBancos();
            listaBancos.Insert(0, seleccionBanco);
            this.cmbBanco.DataSource = listaBancos;
            this.cmbBanco.DataTextField = "Descripcion";
            this.cmbBanco.DataValueField = "Codigo";

            this.cmbBanco.DataBind();

            #endregion

            #region SOLAPA DEPOSITOS

            var clienteCuentas = new List<ClienteCuentaDataContracts>();
            IClienteCuentaService clienteCuentaServices =
                ServiceClient<IClienteCuentaService>.GetService("ClienteCuentaService");
            clienteCuentas =
                clienteCuentaServices.GetAllClienteCuentasByIdCliente(int.Parse(cmbClientes.SelectedItem.Value));
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

            var tiposPagosRaros = new List<TipoPagoRaroDataContracts>();
            ITipoPagoRaroService tiposPagosRarosServices =
                ServiceClient<ITipoPagoRaroService>.GetService("TipoPagoRaroService");
            tiposPagosRaros = tiposPagosRarosServices.GetAllTipoPagoRaros();


            if (tiposPagosRaros != null)
            {
                cmbTipoPagoRaro.DataSource = tiposPagosRaros;
                cmbTipoPagoRaro.DataTextField = "TipoPago";
                cmbTipoPagoRaro.DataValueField = "id";
                cmbTipoPagoRaro.DataBind();
            }

            #endregion

            #region PRONTO PAGO

            //Aca debo verificar si aplica pronto pago o no.

            lblAplicaProntoPago.Text = "El deudor seleccionado aplica pronto pago.";
            lblAplicaProntoPago.Visible = false;

            #endregion

            #region DESCUENTOS

            var descuentos = new List<DescuentoDataContracts>();
            IDescuentoService descuentoServices = ServiceClient<IDescuentoService>.GetService("DescuentoService");
            descuentos = descuentoServices.GetAllDescuentos();
            cmbDescuentos.DataSource = descuentos;
            cmbDescuentos.DataTextField = "Concepto";
            cmbDescuentos.DataValueField = "id";
            cmbDescuentos.DataBind();

            #endregion

            #region RETENCION

            var retenciones = new List<RetencionMTRDataContracts>();
            IRetencionMTRService retencionesServices =
                ServiceClient<IRetencionMTRService>.GetService("RetencionMTRService");
            retenciones = retencionesServices.GetAllRetencionMTRs();


            if (retenciones != null)
            {
                cmbRetenciones.DataSource = retenciones;
                cmbRetenciones.DataTextField = "descripcion";
                cmbRetenciones.DataValueField = "id";
                cmbRetenciones.DataBind();
            }

            #endregion

            txtFechaPagoEfectivo.Text = DateTime.Today.ToString();
            this.HiddenFieldPagosCargados.Value = "";
            ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                                "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                                "javascript:ActualizarDiferenciaPagosFacturas();", true);
            PersonalizarRemision();
            RemoveSessionObjects();
            if (Request.Params["__noitidesi"] != null && Request.Params["__etneilcid"] != null &&
                Request.Params["er"] != null)
            {
                AbrirRemisionDesdeEdicion(Request.Params["__noitidesi"], Request.Params["__etneilcid"],
                                          Request.Params["er"]);
            }
        }
    }

    private void RemoveSessionObjects()
    {
        Session["ListaDePagos"] = null;
        Session["ListaDeRecibosCargados"] = null;
    }

    private void PersonalizarRemision()
    {
        if (Request.QueryString["idDeudor"] != string.Empty && Request.QueryString["idDeudor"] != null &&
            Request.QueryString["idDeudor"] != string.Empty && Request.QueryString["idDeudor"] != null)
        {
            string idDeudor = Request.QueryString["idDeudor"];
            string idCliente = Request.QueryString["idCliente"];
            ListItem item = cmbClientes.Items.FindByValue(idCliente);
            cmbClientes.SelectedIndex = -1;
            item.Selected = true;
            cmbClientes_SelectedIndexChanged(null, null);
            ListItem itemDeudor = cmbDeudores.Items.FindByValue(idDeudor);
            cmbDeudores.SelectedIndex = -1;
            itemDeudor.Selected = true;
            cmbDeudores_SelectedIndexChanged(null, null);
        }
        else
            cmbClientes.SelectedIndex = 0;
    }

    private void CargarGrillaFacturas(int deudor)
    {
        DataTable dataTable2 = GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(deudor);
        GvResultadosFacturas.DataSource = dataTable2;
        GvResultadosFacturas.DataBind();
        GridViewRowCollection rows = GvResultadosFacturas.Rows;
        foreach (GridViewRow row in rows)
        {
            ((TextBox) row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Controls[1]).Text =
                row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Saldo")].Text.Replace(",", ".");
        }

        if (GvResultadosFacturas.Rows.Count > 0)
        {
            UInt16 i = 0;
            foreach (GridViewRow Fila in
                GvResultadosFacturas.Rows.Cast<GridViewRow>().Where(Fila => Fila.Visible))
            {
                i++;
            }
            lblResResultadoCantFacts.Text = i.ToString();
        }
        else
        {
            lblResResultadoCantFacts.Text = "0";
        }
    }

    private void LimpiarGrillaFacturas()
    {
        DataTable dataTable2 = null;
        GvResultadosFacturas.DataSource = dataTable2;
        GvResultadosFacturas.DataBind();
        GridViewRowCollection rows = GvResultadosFacturas.Rows;
    }

    private DataTable GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(int idDeudor)
    {
        var resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos =
            facturaServices.GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(idDeudor);
        FiltrarFacturasTemporales(resultadoObtenidos);
        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }

    private DataTable GetDataTableFacturasPorDeudor(int idDeudor)
    {
        var resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetAllFacturasPorIdDeudor(idDeudor);
        FiltrarFacturasTemporales(resultadoObtenidos);
        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }

    private DataTable GetDataTableFacturasPorDeudorQueNoEstenEnNingunRecibo(int idDeudor)
    {
        var resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetDataTableFacturasPorDeudorQueNoEstenEnNingunRecibo(idDeudor);
        FiltrarFacturasTemporales(resultadoObtenidos);
        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }

    protected void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (FillRecibosDisponibles() > 0)
        {
            var resultadoObtenidos = new List<DeudorLivianoDataContracts>();
            IDeudorLivianoService deudorServices =
                ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");
            resultadoObtenidos =
                deudorServices.GetAllDeudorsLivianoPorCriterioCliente(int.Parse(cmbClientes.SelectedItem.Value));
            var seleccion = new DeudorLivianoDataContracts();
            seleccion.Nombre = "--- SELECCIONE ---";
            seleccion.IdDeudor = 0;
            resultadoObtenidos.Insert(0, seleccion);
            cmbDeudores.Items.Clear();
            cmbDeudores.DataSource = resultadoObtenidos;
            cmbDeudores.DataTextField = "NOMBRE";
            cmbDeudores.DataValueField = "idDeudor";
            cmbDeudores.DataBind();
            cmbDeudores.Enabled = true;
            cmbClientes.ToolTip = cmbClientes.SelectedItem.Text;

            // Esto pertenece a la solapa de Depositos
            var clienteCuentas = new List<ClienteCuentaDataContracts>();
            IClienteCuentaService clienteCuentaServices =
                ServiceClient<IClienteCuentaService>.GetService("ClienteCuentaService");
            clienteCuentas =
                clienteCuentaServices.GetAllClienteCuentasByIdCliente(int.Parse(cmbClientes.SelectedItem.Value));
            this.cmbCuentasClientes.DataSource = clienteCuentas;
            this.cmbCuentaCredito.DataSource = clienteCuentas;
            if (clienteCuentas != null)
            {
                this.cmbCuentasClientes.DataTextField = "cuenta";
                this.cmbCuentasClientes.DataValueField = "idCliente";
                this.cmbCuentasClientes.DataBind();
                this.cmbCuentaCredito.DataTextField = "cuenta";
                this.cmbCuentaCredito.DataValueField = "idCliente";
                this.cmbCuentaCredito.DataBind();
            }
            cmbDeudores.Focus();
            this.panelGeneralCuerpoPagina.Enabled = false;
            btnNuevaRemisionTemporal.Enabled = false;
        }
    }

    private int FillRecibosDisponibles()
    {
        var recibosObtenidos = new List<ReciboDataContracts>();
        IReciboService reciboServices = ServiceClient<IReciboService>.GetService("ReciboService");
        recibosObtenidos = reciboServices.GetAllRecibosByIdClienteSinUsar(int.Parse(cmbClientes.SelectedItem.Value));
        this.cmbRecibosDisponibles.Items.Clear();
        this.cmbRecibosDisponibles.DataSource = recibosObtenidos;
        this.cmbRecibosDisponibles.DataTextField = "Numero";
        this.cmbRecibosDisponibles.DataValueField = "Id";
        this.cmbRecibosDisponibles.DataBind();
        this.cmbRecibosDisponibles.Enabled = true;

        

        if (this.cmbRecibosDisponibles.Items.Count == 0)
        {
            this.panelGeneralCuerpoPagina.Enabled = false;
            ScriptManager.RegisterStartupScript(Page, GetType(), "sinRecibosCargados",
                                                "javascript:alert('Por favor cargue recibos para poder operar.');", true);
        }
        return this.cmbRecibosDisponibles.Items.Count;
    }

    protected void btnAplicarProntoPago_OnClick(object sender, EventArgs e)
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (mgr.Contains("seleccionItemProntoPago"))
        {
            var key = (int) mgr.GetData("seleccionItemProntoPago");
            GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(GvResultadosFacturas, "importe PP")].Text =
                txtImporteProntoPago.Text.Replace(",", ".");
            ((TextBox)
             GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Controls[1]).
                Text = txtImporteProntoPago.Text.Replace(",", ".");
            updatePanelGvFacturas.Update();
            ScriptManager.RegisterStartupScript(Page, GetType(), "cerrarPanelProntoPago", "javascript:HideConfirma3();",
                                                true);
            ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                                "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                                "javascript:ActualizarDiferenciaPagosFacturas();", true);
        }
    }

    protected void btnQuitarProntoPago_OnClick(object sender, EventArgs e)
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (mgr.Contains("seleccionItemProntoPago"))
        {
            var key = (int) mgr.GetData("seleccionItemProntoPago");

            GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(GvResultadosFacturas, "importe PP")].Text = "0";
            ((TextBox)
             GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Controls[1]).
                Text = GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(GvResultadosFacturas, "saldo")].Text;
            updatePanelGvFacturas.Update();
            ScriptManager.RegisterStartupScript(Page, GetType(), "cerrarPanelProntoPago", "javascript:HideConfirma3();",
                                                true);
            ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                                "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                                "javascript:ActualizarDiferenciaPagosFacturas();", true);
        }
    }

    protected void btnAgregarPago_Click(object sender, EventArgs e)
    {
        _evitarPrerenderGrillaFactura = true;
        string[] pagos = this.HiddenFieldPagosCargados.Value.Split('@');
        string tipoPago = "";
        foreach (string pago in pagos)
        {
            if (pago == "") break;
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
                    var nuevoCheque = new ChequeDataContracts();
                    nuevoCheque.FechaPago = DateTime.Now;
                    nuevoCheque.Banco = GetValueFromAttribute(pago, "banco");
                    nuevoCheque.Cuenta = GetValueFromAttribute(pago, "cuenta");
                    nuevoCheque.Cuit = GetValueFromAttribute(pago, "cuitEmisor");
                    nuevoCheque.Cp = GetValueFromAttribute(pago, "cp");
                    nuevoCheque.Emision = DateTime.Parse(GetValueFromAttribute(pago, "fechaEmision"));
                    nuevoCheque.Vencimiento = DateTime.Parse(GetValueFromAttribute(pago, "fechaVencimiento"));
                    nuevoCheque.Importe =
                        double.Parse(
                            AplicarFormatoADoble(double.Parse(GetValueFromAttribute(pago, "importe"))).ToString());
                    nuevoCheque.Sucursal = GetValueFromAttribute(pago, "sucursal");
                    nuevoCheque.FormaPago = new FormaPagoDataContracts(1, "CHEQUE");
                    nuevoCheque.Numero = long.Parse(GetValueFromAttribute(pago, "cheque"));
                    nuevoCheque.IdMoneda = GetIdMoneda(pago);
                    nuevoCheque.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    AgregarPago(nuevoCheque);
                    BlanquearPagos(0);
                    ActualizarGrillaCargaPagos();
                    break;

                case "RETENCION":

                    var nuevaRetencion = new RetencionDataContracts();

                    nuevaRetencion.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaRetencion"));
                    nuevaRetencion.FormaPago = new FormaPagoDataContracts(3, "RETENCION");
                    nuevaRetencion.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevaRetencion.Importe = AplicarFormatoADoble(nuevaRetencion.Importe);
                    nuevaRetencion.NumeroRetencion = GetValueFromAttribute(pago, "numeroRetencion");
                    nuevaRetencion.IdRetencion = int.Parse(GetValueFromAttribute(pago, "concepto"));
                    nuevaRetencion.IdSubTipoRetencion = int.Parse(GetValueFromAttribute(pago, "subtipo"));
                    nuevaRetencion.IdMoneda = GetIdMoneda(pago);
                    nuevaRetencion.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    AgregarPago(nuevaRetencion);
                    BlanquearPagos(1);
                    ActualizarGrillaCargaPagos();
                    break;

                case "EFECTIVO":
                    var nuevoEfectivo = new EfectivoDataContracts();
                    nuevoEfectivo.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaPago"));
                    nuevoEfectivo.FormaPago = new FormaPagoDataContracts(2, "EFECTIVO");
                    nuevoEfectivo.Monto = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoEfectivo.Importe = double.Parse(nuevoEfectivo.Monto.ToString());
                    nuevoEfectivo.Importe = AplicarFormatoADoble(nuevoEfectivo.Importe);
                    nuevoEfectivo.IdMoneda = GetIdMoneda(pago);
                    nuevoEfectivo.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    AgregarPago(nuevoEfectivo);
                    BlanquearPagos(2);
                    ActualizarGrillaCargaPagos();
                    break;

                case "DEPOSITO":

                    var nuevoDeposito = new DepositoDataContracts();
                    nuevoDeposito.FechaDeposito = DateTime.Parse(GetValueFromAttribute(pago, "fechaDeposito"));
                    nuevoDeposito.FechaPago = DateTime.Now;
                    nuevoDeposito.FormaPago = new FormaPagoDataContracts(4, "DEPOSITO");
                    nuevoDeposito.Importe = AplicarFormatoADoble(double.Parse(GetValueFromAttribute(pago, "importe")));
                    nuevoDeposito.Importe = AplicarFormatoADoble(nuevoDeposito.Importe);
                    nuevoDeposito.NumComprobante = GetValueFromAttribute(pago, "numComprobante");
                    // nuevoDeposito.IdCuenta = this.cmbCuentasClientes.SelectedItem.Value; Agregar esto
                    nuevoDeposito.IdCuenta = 1.ToString(); //Quitar cuando este la linea de arriba
                    nuevoDeposito.Sucursal = GetValueFromAttribute(pago, "sucursal");
                    nuevoDeposito.IdMoneda = GetIdMoneda(pago);
                    nuevoDeposito.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    AgregarPago(nuevoDeposito);
                    BlanquearPagos(3);
                    ActualizarGrillaCargaPagos();
                    break;
                case "TRANSFERENCIA":

                    var nuevaTransferencia = new TransferenciaDataContracts();
                    nuevaTransferencia.FechaDeposito = DateTime.Parse(GetValueFromAttribute(pago, "fechaTransferencia"));
                    nuevaTransferencia.FechaCarga = DateTime.Now;
                    nuevaTransferencia.FormaPago = new FormaPagoDataContracts(5, "TRANSFERENCIA");
                    nuevaTransferencia.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevaTransferencia.Importe = AplicarFormatoADoble(nuevaTransferencia.Importe);
                    //nuevaTransferencia.CuentaCredito = this.cmbCuentaCredito.SelectedItem.ToString();
                    nuevaTransferencia.CuentaCredito = "";
                    nuevaTransferencia.CuentaDebito = GetValueFromAttribute(pago, "cuentaDebito");
                    nuevaTransferencia.NumComprobante = GetValueFromAttribute(pago, "numComprobante");
                    nuevaTransferencia.IdMoneda = GetIdMoneda(pago);
                    nuevaTransferencia.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    AgregarPago(nuevaTransferencia);
                    BlanquearPagos(4);
                    ActualizarGrillaCargaPagos();
                    break;
                case "OTROPAGO":

                    var nuevoOtroPago = new OtroPagoDataContracts();
                    nuevoOtroPago.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaPago"));
                    nuevoOtroPago.FormaPago = new FormaPagoDataContracts(6, "OTRO");
                    nuevoOtroPago.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoOtroPago.Importe = AplicarFormatoADoble(nuevoOtroPago.Importe);
                    nuevoOtroPago.NumComprobante = GetValueFromAttribute(pago, "txtNumComprobante");
                    ((PagoDataContracts) nuevoOtroPago).IdTipoPagoRaro =
                        int.Parse(GetValueFromAttribute(pago, "tipoPago"));
                    nuevoOtroPago.IdMoneda = GetIdMoneda(pago);
                    nuevoOtroPago.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    AgregarPago(nuevoOtroPago);
                    BlanquearPagos(5);
                    ActualizarGrillaCargaPagos();
                    break;
                case "DESCUENTO":

                    var nuevoDescuento = new RemisionDescuentoDataContracts();
                    nuevoDescuento.FechaDescuento = DateTime.Now;
                    nuevoDescuento.IdRemision = 0; //Ver
                    nuevoDescuento.IdDescuento = 1; //arreglar int.Parse(this.cmbDescuentos.SelectedItem.Value);
                    nuevoDescuento.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoDescuento.Importe = AplicarFormatoADoble(nuevoDescuento.Importe);
                    nuevoDescuento.FormaPago = new FormaPagoDataContracts(7, "DESCUENTO");
                    nuevoDescuento.IdMoneda = GetIdMoneda(pago);
                    nuevoDescuento.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    AgregarPago(nuevoDescuento);
                    BlanquearPagos(6);
                    ActualizarGrillaCargaPagos();
                    break;
            }
            if (chkPestreificar.Checked)
            {
                chkPestreificar.Checked = false;
                //this.txtCambio.Text = Constants.DEFAULT_CHANGE;
                UpdatePanelIndice.Update();
            }
        }
        this.HiddenFieldPagosCargados.Value = "";
    }

    protected void TomarPagosCargadosTemporalmente()
    {
        _evitarPrerenderGrillaFactura = true;
        string[] pagos = this.HiddenFieldPagosCargados.Value.Split('@');
        string tipoPago = "";
        foreach (string pago in pagos)
        {
            if (pago == "") break;
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

                    var nuevoCheque = new ChequeDataContracts();
                    nuevoCheque.FechaPago = DateTime.Now;
                    nuevoCheque.Banco = GetValueFromAttribute(pago, "banco");
                    nuevoCheque.Cuenta = GetValueFromAttribute(pago, "cuenta");
                    nuevoCheque.Cuit = GetValueFromAttribute(pago, "cuitEmisor");
                    nuevoCheque.Cp = GetValueFromAttribute(pago, "cp");
                    nuevoCheque.Emision = DateTime.Parse(GetValueFromAttribute(pago, "fechaEmision"));
                    nuevoCheque.Vencimiento = DateTime.Parse(GetValueFromAttribute(pago, "fechaVencimiento"));

                    nuevoCheque.Importe =
                        double.Parse(
                            AplicarFormatoADoble(double.Parse(GetValueFromAttribute(pago, "importe"))).ToString());
                    nuevoCheque.Sucursal = GetValueFromAttribute(pago, "sucursal");
                    nuevoCheque.FormaPago = new FormaPagoDataContracts(1, "CHEQUE");
                    nuevoCheque.Numero = long.Parse(GetValueFromAttribute(pago, "cheque"));
                    nuevoCheque.IdMoneda = GetIdMoneda();
                    AgregarPagoTemporal(nuevoCheque);
                    break;

                case "RETENCION":

                    var nuevaRetencion = new RetencionDataContracts();
                    nuevaRetencion.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaRetencion"));
                    nuevaRetencion.FormaPago = new FormaPagoDataContracts(3, "RETENCION");
                    nuevaRetencion.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevaRetencion.Importe = AplicarFormatoADoble(nuevaRetencion.Importe);
                    nuevaRetencion.NumeroRetencion = GetValueFromAttribute(pago, "numeroRetencion");
                    nuevaRetencion.IdRetencion = int.Parse(GetValueFromAttribute(pago, "concepto"));
                    nuevaRetencion.IdSubTipoRetencion = int.Parse(GetValueFromAttribute(pago, "subtipo"));
                    nuevaRetencion.IdMoneda = GetIdMoneda(pago);
                    nuevaRetencion.TotalPesificado = double.Parse(GetValueFromAttribute(pago, "totalPesificado"));
                    AgregarPagoTemporal(nuevaRetencion);
                    break;

                case "EFECTIVO":
                    var nuevoEfectivo = new EfectivoDataContracts();
                    nuevoEfectivo.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaPago"));
                    nuevoEfectivo.FormaPago = new FormaPagoDataContracts(2, "EFECTIVO");
                    nuevoEfectivo.Monto = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoEfectivo.Importe = double.Parse(nuevoEfectivo.Monto.ToString());
                    nuevoEfectivo.Importe = AplicarFormatoADoble(nuevoEfectivo.Importe);
                    nuevoEfectivo.IdMoneda = GetIdMoneda();
                    AgregarPagoTemporal(nuevoEfectivo);
                    break;

                case "DEPOSITO":

                    var nuevoDeposito = new DepositoDataContracts();
                    nuevoDeposito.FechaDeposito = DateTime.Parse(GetValueFromAttribute(pago, "fechaDeposito"));
                    nuevoDeposito.FechaPago = DateTime.Now;
                    nuevoDeposito.FormaPago = new FormaPagoDataContracts(4, "DEPOSITO");
                    nuevoDeposito.Importe = AplicarFormatoADoble(double.Parse(GetValueFromAttribute(pago, "importe")));
                    nuevoDeposito.Importe = AplicarFormatoADoble(nuevoDeposito.Importe);
                    nuevoDeposito.NumComprobante = GetValueFromAttribute(pago, "numComprobante");
                    nuevoDeposito.IdCuenta = 1.ToString(); //Quitar cuando este la linea de arriba
                    nuevoDeposito.Sucursal = GetValueFromAttribute(pago, "sucursal");
                    nuevoDeposito.IdMoneda = GetIdMoneda();
                    AgregarPagoTemporal(nuevoDeposito);
                    break;
                case "TRANSFERENCIA":

                    var nuevaTransferencia = new TransferenciaDataContracts();
                    nuevaTransferencia.FechaDeposito = DateTime.Parse(GetValueFromAttribute(pago, "fechaTransferencia"));
                    nuevaTransferencia.FechaCarga = DateTime.Now;
                    nuevaTransferencia.FormaPago = new FormaPagoDataContracts(5, "TRANSFERENCIA");
                    nuevaTransferencia.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevaTransferencia.Importe = AplicarFormatoADoble(nuevaTransferencia.Importe);
                    nuevaTransferencia.CuentaCredito = "";
                    nuevaTransferencia.CuentaDebito = GetValueFromAttribute(pago, "cuentaDebito");
                    nuevaTransferencia.NumComprobante = GetValueFromAttribute(pago, "numComprobante");
                    nuevaTransferencia.IdMoneda = GetIdMoneda();
                    AgregarPagoTemporal(nuevaTransferencia);
                    break;
                case "OTROPAGO":

                    var nuevoOtroPago = new OtroPagoDataContracts();
                    nuevoOtroPago.FechaPago = DateTime.Parse(GetValueFromAttribute(pago, "fechaPago"));
                    nuevoOtroPago.FormaPago = new FormaPagoDataContracts(6, "OTRO");
                    nuevoOtroPago.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoOtroPago.Importe = AplicarFormatoADoble(nuevoOtroPago.Importe);
                    nuevoOtroPago.NumComprobante = GetValueFromAttribute(pago, "txtNumComprobante");
                    nuevoOtroPago.IdMoneda = GetIdMoneda();
                    AgregarPagoTemporal(nuevoOtroPago);
                    break;
                case "DESCUENTO":

                    var nuevoDescuento = new RemisionDescuentoDataContracts();
                    nuevoDescuento.FechaDescuento = DateTime.Now;
                    nuevoDescuento.IdRemision = 0; //Ver
                    nuevoDescuento.IdDescuento = 1; //arreglar int.Parse(this.cmbDescuentos.SelectedItem.Value);
                    nuevoDescuento.Importe = double.Parse(GetValueFromAttribute(pago, "importe"));
                    nuevoDescuento.Importe = AplicarFormatoADoble(nuevoDescuento.Importe);
                    nuevoDescuento.FormaPago = new FormaPagoDataContracts(7, "DESCUENTO");
                    nuevoDescuento.IdMoneda = GetIdMoneda();
                    AgregarPagoTemporal(nuevoDescuento);
                    break;
            }
        }
    }


    private void AgregarPagoTemporal(PagoDataContracts pago)
    {
        var listaDePagosCargados = new List<PagoDataContracts>();
        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>) Session["ListaDePagos"];
            listaDePagosCargados.Add(pago);
        }
        else
        {
            listaDePagosCargados.Add(pago);
        }
        Session["ListaDePagos"] = listaDePagosCargados;
    }

    private string GetValueFromAttribute(string cadena, string attribute)
    {
        int pos = cadena.IndexOf(attribute);

        int lengthAttribute = attribute.Length;

        string shortCadena = cadena.Remove(0, pos).Remove(0, lengthAttribute + 1);

        shortCadena = shortCadena.Remove(shortCadena.IndexOf(";"), shortCadena.Length - shortCadena.IndexOf(";"));

        return shortCadena;
    }

    private int GetIdMoneda()
    {
        return Convert.ToInt32(chkPestreificar.Checked) + 1;
    }

    private int GetIdMoneda(String moneda)
    {
        switch (moneda.Split(';')[0])
        {
            case "PESOS":
                return 1;
                break;

            case "DOLARES":
                return 2;
                break;
            default:
                return 1;
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
                chkPestreificar.Checked = false;
                break;

            case "DOLARES":
                chkPestreificar.Checked = true;
                break;
        }
    }


    private void ActualizarGrillaDetalleCheque()
    {
        TomarPagosCargadosTemporalmente();
        var listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>) Session["ListaDePagos"];
        }
        int a = 1;
        var listaDeCheques = new List<ChequeDataContracts>();
        foreach (PagoDataContracts pago in listaDePagosCargados)
        {
            if (pago.FormaPago.Descripcion == "CHEQUE")
            {
                pago.Orden = a++;
                var nuevoCheque = new ChequeDataContracts();
                UIUtils.MappingEntity(pago, nuevoCheque);
                listaDeCheques.Add(nuevoCheque);
            }
        }

        var dataTable = new DataTable();
        Type itemsType = typeof (ChequeDataContracts);

        foreach (PropertyInfo property in itemsType.GetProperties())
        {
            var column = new DataColumn(property.Name);
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


        gvResultadosCheques.DataSource = dataTable;
        gvResultadosCheques.DataBind();
        Session["ListaDePagos"] = null;
    }

    private void ActualizarGrillaCargaPagos()
    {
        var listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>) Session["ListaDePagos"];
        }

        int a = 1;
        foreach (PagoDataContracts pago in listaDePagosCargados)
        {
            pago.Orden = a++;
        }

        var dataTable = new DataTable();
        Type itemsType = typeof (PagoDataContracts);

        foreach (PropertyInfo property in itemsType.GetProperties())
        {
            var column = new DataColumn(property.Name);
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

        //Agregado para evitar sumas negativas:
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            var chk = (CheckBox) Fila.FindControl("chk");
            chk.Checked = false;
        }
    }

    private void ActualizarGrillaCargaPagosYActualizaTotales()
    {
        var listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>) Session["ListaDePagos"];
        }

        int a = 1;
        foreach (PagoDataContracts pago in listaDePagosCargados)
        {
            pago.Orden = a++;
        }

        var dataTable = new DataTable();
        Type itemsType = typeof (PagoDataContracts);

        foreach (PropertyInfo property in itemsType.GetProperties())
        {
            var column = new DataColumn(property.Name);
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

                if (property.Name == "Importe")
                {
                    total = total + double.Parse(property.GetValue(pago, null).ToString());
                }
            }
            dataTable.Rows.Add(row);
        }

        ActualizarTotalesEnPantalla(total);
        //Agregado para evitar sumas negativas:
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            var chk = (CheckBox) Fila.FindControl("chk");
            chk.Checked = false;
        }
    }

    private void BlanquearPagos(int tipoPago)
    {
        switch (tipoPago)
        {
            case 0:
                this.txtBanco.Text = "";
                this.txtCheque.Text = "";
                this.txtFechaVencimiento.Text = "";
                this.txtFechaEmision.Text = "";
                txtImporte.Text = "";
                this.txtSucursal.Text = "";
                this.txtCuitEmisor.Text = "";
                txtCuenta.Text = "";
                txtCp.Text = "";
                break;

            case 1:
                txtImporteRetencion.Text = "";
                txtNumeroRetencion.Text = "";

                break;

            case 2:
                txtImporteEfectivo.Text = "";
                break;

            case 3:
                this.cmbCuentasClientes.SelectedIndex = 0;
                this.txtSucursalDeposito.Text = "";
                this.txtImporteDeposito.Text = "";
                this.txtFechaDeposito.Text = "";
                this.txtNumComprob.Text = "";

                break;

            case 4:
                this.txtCuentaDebito.Text = "";
                txtFechaTransferencia.Text = "";
                this.txtNumComprobTrans.Text = "";
                txtImporteTransferencia.Text = "";
                break;

            case 5:
                cmbTipoPagoRaro.SelectedIndex = 0;
                this.txtFechaPagoRaro.Text = "";
                this.txtNumCompRaro.Text = "";
                this.txtImporteRaro.Text = "";
                break;

            case 6:
                txtImporteDescuento.Text = "";
                cmbDescuentos.SelectedIndex = 0;
                break;
        }
    }

    private void BlanquearTodosLosPagos()
    {
        this.txtBanco.Text = "";
        this.txtCheque.Text = "";
        this.txtFechaVencimiento.Text = "";
        this.txtFechaEmision.Text = "";
        txtImporte.Text = "";
        this.txtSucursal.Text = "";
        this.txtCuitEmisor.Text = "";
        txtCuenta.Text = "";
        txtCp.Text = "";
        txtImporteRetencion.Text = "";
        txtNumeroRetencion.Text = "";
        txtImporteEfectivo.Text = "";
        txtFechaPagoEfectivo.Text = DateTime.Today.ToString();
        this.txtSucursalDeposito.Text = "";
        this.txtImporteDeposito.Text = "";
        this.txtFechaDeposito.Text = "";
        this.txtNumComprob.Text = "";
        this.txtCuentaDebito.Text = "";
        txtFechaTransferencia.Text = "";
        this.txtNumComprobTrans.Text = "";
        txtImporteTransferencia.Text = "";
        cmbTipoPagoRaro.SelectedIndex = 0;
        this.txtFechaPagoRaro.Text = "";
        this.txtNumCompRaro.Text = "";
        this.txtImporteRaro.Text = "";
        txtImporteDescuento.Text = "";
        cmbDescuentos.SelectedIndex = 0;
    }

    private void AgregarPago(PagoDataContracts pago)
    {
        var listaDePagosCargados = new List<PagoDataContracts>();
        ReCalcularSuma();
        UpdatePanelResultados.Update();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>) Session["ListaDePagos"];

            listaDePagosCargados.Add(pago);
            ActualizarSumaPagos(double.Parse(pago.Importe.ToString()));
        }
        else
        {
            listaDePagosCargados.Add(pago);
            ActualizarSumaPagos(double.Parse(pago.Importe.ToString()));
        }

        Session["ListaDePagos"] = listaDePagosCargados;
    }

    protected void gvResultadosPagos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>) Session["ListaDePagos"];

            //Evita resta negativa
            if (txtPagos.Text != "0")
                ActualizarSumaPagos(
                    double.Parse(string.Format("{0:#.#########,####}", (listaDePagosCargados[e.RowIndex].Importe*-1))));

            listaDePagosCargados.Remove(listaDePagosCargados[e.RowIndex]);
            Session["ListaDePagos"] = listaDePagosCargados;
            ActualizarGrillaCargaPagos();
        }
    }

    private void ActualizarSumaPagos(double valor)
    {
        double fCambio = double.Parse("1.0000");
        double fValorAgregar = double.Parse("0");
        if (txtCambio.Text != "1.0000" && txtCambio.Text != "")
            fCambio = double.Parse(txtCambio.Text);
        bool chkPesif = chkPestreificar.Checked;
        if (chkPesif)
        {
            fValorAgregar = valor*fCambio;
        }
        else
        {
            fValorAgregar = valor;
        }
        double suma = (double.Parse(txtPagos.Text) + fValorAgregar);
        if (valor < 0) suma = (suma*-1);
        if (suma != 0)
        {
            string sumaFormatString = string.Format("{0:#.#########,####}", suma);
            suma = double.Parse(sumaFormatString);
            if (valor < 0) suma = (suma*-1);
        }
        ActualizarTotalesEnPantalla(suma);
    }

    private void ActualizarTotalesEnPantalla(double suma)
    {
        txtPagos.Text = suma.ToString();
        this.UpdatePanelTabContainer.Update();
        UpdatePanelSumasPagos.Update();

        txtDiferenciaPe.Text = "0";
        if (txtPagos.Text != string.Empty && txtSumaFacturas.Text != string.Empty)
        {
            double txtPagoConFormato = txtPagos.Text != "0"
                                           ? double.Parse(string.Format("{0:#.#########,####}",
                                                                        double.Parse(txtPagos.Text)))
                                           : 0;
            double txtSumaFacturasConFormato = txtSumaFacturas.Text != "0"
                                                   ? double.Parse(string.Format("{0:#.#########,####}",
                                                                                double.Parse(txtSumaFacturas.Text)))
                                                   : 0;

            txtDiferenciaPe.Text =
                (txtPagoConFormato - txtSumaFacturasConFormato).ToString();
        }

        UpdatePanelResultadosDiferenciaLocal.Update();
    }

    private void ActualizarTotalesEnPantalla()
    {
        txtDiferenciaPe.Text = "0";
        if (txtPagos.Text != string.Empty && txtSumaFacturas.Text != string.Empty)
        {
            double txtPagoConFormato = txtPagos.Text != "0"
                                           ? double.Parse(string.Format("{0:#.#########,####}",
                                                                        double.Parse(txtPagos.Text)))
                                           : 0;
            double txtSumaFacturasConFormato = txtSumaFacturas.Text != "0"
                                                   ? double.Parse(string.Format("{0:#.#########,####}",
                                                                                double.Parse(txtSumaFacturas.Text)))
                                                   : 0;

            txtDiferenciaPe.Text =
                (txtPagoConFormato - txtSumaFacturasConFormato).ToString();
        }

        UpdatePanelResultadosDiferenciaLocal.Update();
    }

    private void ActualizarSumaPagos()
    {
        var listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            double sumaTotalDePagos = 0;

            listaDePagosCargados = (List<PagoDataContracts>) Session["ListaDePagos"];

            foreach (PagoDataContracts item in listaDePagosCargados)
            {
                sumaTotalDePagos = sumaTotalDePagos + item.Importe;
            }
            double sumaTotalDePagosConFormato = double.Parse(string.Format("{0:#.#########,####}", sumaTotalDePagos));

            txtPagos.Text = sumaTotalDePagosConFormato.ToString();
            if (this.txtCambio.Text == "" || this.txtCambio.Text == null)
                this.txtCambio.Text = "1.0000";
            this.UpdatePanelTabContainer.Update();
            UpdatePanelIndice.Update();
        }
    }

    private double AplicarFormatoADoble(double input)
    {
        if (input == 0)
        {
            return 0;
        }

        return double.Parse(string.Format("{0:#.#########,####}", input));
    }

    private void ActualizarSumaFacturas()
    {
        GridViewRowCollection rows = GvResultadosFacturas.Rows;

        double sumaFacturas = 0;
        foreach (GridViewRow row in rows)
        {
            if (((CheckBox) row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked)
            {
                sumaFacturas = sumaFacturas +
                               double.Parse(string.Format("{0:#.#########,####}",
                                                          double.Parse(
                                                              row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "saldo")
                                                                  ].Text)));
            }
        }
        txtSumaFacturas.Text = sumaFacturas.ToString();

        UpdatePanelResultados.Update();
    }

    protected void GvResultadosFacturas_PreRender(object sender, EventArgs e)
    {
        if (!_evitarPrerenderGrillaFactura)
        {
            int cont = -1;
            foreach (GridViewRow item in GvResultadosFacturas.Rows)
            {
                cont++;
                var checkSeleccion =
                    (CheckBox) item.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Seleccionar")].Controls[1];

                var btnPP = (Button) item.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Pronto")].Controls[0];

                checkSeleccion.Attributes.Add("onclick",
                                              "SumarImporte(this,'" + cont + "'," +
                                              item.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "saldo")].Text.Replace(
                                                  ",", ".") + "," +
                                              item.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "importe PP")].
                                                  Text.Replace(",", ".") + ",'" + btnPP.ClientID + "'," +
                                              item.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Saldo")].Text.
                                                  Replace(",", ".") + ");");
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
        Validate("facturasABuscarGroup");
        if (!IsValid)
        {
            return;
        }
        Color col = Color.Empty;
        ReCalcularSuma();
        MantenerEstadoDeFilasDeshabilitadas();
        foreach (GridViewRow item in GvResultadosFacturas.Rows)
        {
            item.BackColor = col;
        }
        foreach (GridViewRow item in GvResultadosFacturas.Rows)
        {
            if (
                item.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Nro Factura")].Text.IndexOf(this.txtNumFactura.Text) !=
                -1)
            {
                item.BackColor = Color.Gold;
            }
        }
        UpdatePanelResultadosDiferenciaLocal.Update();
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
    }

    protected DataTable GvResultadosFacturas_Filling(object sender, EventArgs e)
    {
        var resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetAllFacturasPorIdDeudor(int.Parse(cmbDeudores.SelectedItem.Value));
        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }

    protected void imgBtnLectora_Click(object sender, ImageClickEventArgs e)
    {
        this.txtCuitEmisor.Attributes.Add("onfocus", "MostrarPanelCheque()");
    }

    protected void cmbDeudores_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbDeudores.SelectedItem.Value != "0")
        {
            cmbDeudores.ToolTip = cmbDeudores.SelectedItem.Text;
            int res = BloquearDeudor_Click("", "");
            this.panelGeneralCuerpoPagina.Enabled = true;

            if (res == 0) CargarGrillaFacturas(int.Parse(cmbDeudores.SelectedItem.Value));
        }
        else
        {
            btnNuevaRemisionTemporal.Enabled = false;
            this.panelGeneralCuerpoPagina.Enabled = false;
        }

        var item = new ListItem();
        item = cmbDeudores.SelectedItem;
        cmbDeudores.Items.Clear();
        cmbDeudores.Items.Add(item);
        btnNuevaRemisionTemporal.Focus();


        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
    }

    protected void cmbRecibosDisponibles_TextChanged(object sender, EventArgs e)
    {
        if (this.cmbRecibosDisponibles.Items.Count > 0)
        {
            btnGuardarRecibo.Enabled = true;
            this.txtRecibo.Text = this.cmbRecibosDisponibles.SelectedItem.Text;
            updatePanelTxtRecibo.Update();
            _evitarPrerenderGrillaFactura = true;
            this.cmbRecibosDisponibles.ToolTip = this.cmbRecibosDisponibles.SelectedItem.Text;
        }
        else
        {
            this.txtRecibo.Text = "";
            updatePanelTxtRecibo.Update();
            _evitarPrerenderGrillaFactura = true;
            btnGuardarRecibo.Enabled = false;
            this.cmbRecibosDisponibles.ToolTip = "";
        }
    }

    protected void cmbDeudores_DataBound(object sender, EventArgs e)
    {
        if (cmbDeudores.Items.Count > 0)
        {
            cmbDeudores.SelectedIndex = 0;
            cmbDeudores.ToolTip = cmbDeudores.SelectedItem.Text;
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
        GridViewRowCollection rows = GvResultadosFacturas.Rows;


        foreach (GridViewRow row in rows)
        {
            ((TextBox) row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Controls[1]).Text =
                row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Importe")].Text;
        }

        txtSumaFacturas.Text = "0";
        txtSumaFacturasExt.Text = "0";
        //Para evitar saldos negativos, quitamos todos los tildes de la grilla
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            var chk = (CheckBox) Fila.FindControl("chk");
            chk.Checked = false;
        }

        if (GvResultadosFacturas.Rows.Count > 0)
        {
            lblResResultadoCantFacts.Text = GvResultadosFacturas.Rows.Count.ToString();
        }

        else
        {
            lblResResultadoCantFacts.Text = "0";
        }
    }

    protected void SeleccionProntoPago(object sender, EventArgs e)
    {
        if (((CheckBox) sender).Checked)
        {
            var listaProntoPago = new List<ProntoPagoDataContracts>();
            IProntoPagoService prontoPagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
            listaProntoPago =
                prontoPagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(cmbClientes.SelectedItem.Value),
                                                                         int.Parse(cmbDeudores.SelectedItem.Value));
            DataTable dt = ConvertDataTable<ProntoPagoDataContracts>.Convert(listaProntoPago);
            gvProntoPago.DataSource = dt;
            gvProntoPago.DataBind();
            ModalPopupProntoPago.Show();
        }
    }

    private bool IsValidateCampoAImputar(string valor)
    {
        try
        {
            if (valor == string.Empty) return false;

            double.Parse(valor);
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow dr in GvResultadosFacturas.Rows)
        {
            if (
                !IsValidateCampoAImputar(
                    ((TextBox) dr.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Controls[1]).Text))
            {
                UIUtils.PaintSelectedRow(GvResultadosFacturas, "id Factura",
                                         dr.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "id Factura")].Text, Color.Red);

                ScriptManager.RegisterStartupScript(Page, GetType(), "aImputarInvalido",
                                                    "alert('Importe inválido para la factura " +
                                                    dr.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "id Factura")].Text +
                                                    ". Verifique los valores de la columna (A imputar).')", true);
                return;
            }
        }
        double suma = 0;
        foreach (GridViewRow dr in GvResultadosFacturas.Rows)
        {
            ((CheckBox) dr.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked =
                ((CheckBox) sender).Checked;
            if (((CheckBox) sender).Checked)
            {
                suma = suma +
                       double.Parse(
                           ((TextBox) dr.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Controls[1]).Text);
            }
            else
            {
                suma = 0;
            }
        }
        txtSumaFacturas.Text = AplicarFormatoADoble(suma).ToString();
        this.txtCambio.Text = "1.0000";
        txtSumaFacturasExt.Text = (double.Parse(txtSumaFacturas.Text)/double.Parse(this.txtCambio.Text)).ToString();


        UpdatePanelResultados.Update();
    }

    protected void txtCuitEmisor_TextChanged1(object sender, EventArgs e)
    {
        var resultadoObtenido = new ChequeDataContracts();
        IChequeService chequeServices = ServiceClient<IChequeService>.GetService("ChequeService");
        resultadoObtenido = chequeServices.GetChequeByCuit(((TextBox) sender).Text);

        if (resultadoObtenido != null)
        {
            this.txtBanco.Text = resultadoObtenido.Banco;
            this.txtSucursal.Text = resultadoObtenido.Sucursal;
            txtCuenta.Text = resultadoObtenido.Cuenta;
        }
        txtCuenta.Focus();
        _evitarPrerenderTextBox = true;
    }

    protected void linkButtonRemisionEnCurso_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Abrir Pop Up",
                                                    "javascript:AbrirVentanaPequenia2('http://" +
                                                    Request.ServerVariables["SERVER_NAME"] + ":" +
                                                    Request.ServerVariables["SERVER_PORT"] +
                                                    "/Vistas/ViewGeneracionPdf.aspx?idRemision=" + lblRemisionEnUso.Text +
                                                    "','_blank','scrollbars=yes');", true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    protected void linkButtonCuit_Click(object sender, EventArgs e)
    {
        var resultadoObtenidos = new DeudorDataContracts();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        resultadoObtenidos = deudorServices.GetDeudor(int.Parse(cmbDeudores.SelectedItem.Value));

        if (resultadoObtenidos != null)
        {
            this.txtCuitEmisor.Text = resultadoObtenidos.Cuit;


            var resultadoCheque = new ChequeDataContracts();
            IChequeService chequeServices = ServiceClient<IChequeService>.GetService("ChequeService");
            resultadoCheque = chequeServices.GetChequeByCuit(this.txtCuitEmisor.Text);

            if (resultadoCheque != null)
            {
                this.txtSucursal.Text = resultadoCheque.Sucursal;
                txtCuenta.Text = resultadoCheque.Cuenta;
                this.txtBanco.Text = resultadoCheque.Banco;
                txtCp.Focus();
            }
            _evitarPrerenderTextBox = true;
        }
    }

    protected void btnGuardarRecibo_Click(object sender, EventArgs e)
    {
        try
        {
            btnAgregarPago_Click(null, null);
            MantenerEstadoDeFilasDeshabilitadas();
            btnGuardarRecibo.Enabled = true;
            if (!IsValid)
            {
                return;
            }
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            ClienteDataContracts clienteDataContracts =
                clienteServices.GetCliente(decimal.Parse(cmbClientes.SelectedItem.Value));
            //Validacion de recibo existente
            IReciboService reciboServices = ServiceClient<IReciboService>.GetService("ReciboService");
            ReciboDataContracts reciboPersistido = reciboServices.Load(new ReciboDataContracts(this.txtRecibo.Text),
                                                                       int.Parse(cmbClientes.SelectedItem.Value));
            if (reciboPersistido.UsadoRemision)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "reciboDuplicado",
                                                    "javascript:alert('El número de recibo indicado ya existe.');", true);
                ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                                    "javascript:AsignarHiddenFieldATabla();", true);
                ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                                    "javascript:ActualizarDiferenciaPagosFacturas();", true);

                return;
            }
            var nuevoRecibo = new ReciboDataContracts();
            var clientes = new List<ClienteDataContracts>();
            nuevoRecibo.Id = reciboPersistido.Id;
            nuevoRecibo.Cliente = clienteDataContracts;
            var resultadoObtenidos = new DeudorDataContracts();
            IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
            nuevoRecibo.Deudor = deudorServices.GetDeudor(int.Parse(cmbDeudores.SelectedItem.Value));
            nuevoRecibo.Numero = this.txtRecibo.Text;
            nuevoRecibo.Cobrador = reciboPersistido.Cobrador;
            nuevoRecibo.SAP = this.txtSAP.Text;
            nuevoRecibo.CompensacionDePago = null;
            nuevoRecibo.TipoDeCambio = AplicarFormatoADoble(double.Parse(this.txtCambio.Text.Replace(".", ",")));
            nuevoRecibo.UsadoRemision = true;
            nuevoRecibo.FechaCarga = DateTime.Now;
            if (!string.IsNullOrEmpty(txtDiferenciaPe.Text))
            {
                if (double.Parse(txtDiferenciaPe.Text) > 0)
                {
                    var compensacionDePago = new CompensacionDePagoDataContracts();
                    compensacionDePago.FechaRealizacionCompensacion = DateTime.Now;
                    compensacionDePago.IdCliente = int.Parse(cmbClientes.SelectedItem.Value);
                    compensacionDePago.IdCompensacion = 0;
                    compensacionDePago.IdDeudor = int.Parse(cmbDeudores.SelectedItem.Value);
                    compensacionDePago.Monto =
                        double.Parse(Request.Params.Get("ctl00$Contentplaceholder1$txtDiferenciaPe").Replace(".", ","));
                    compensacionDePago.ReciboRelacionado = this.txtRecibo.Text;
                    nuevoRecibo.CompensacionDePago = compensacionDePago;
                }
            }
            //No puede haber recibo sin pagos ingresados

            if (Session["ListaDePagos"] != null)
            {
                nuevoRecibo.ListadoDePagosIngresados = (List<PagoDataContracts>) Session["ListaDePagos"];
            }

            //Con esto tomo todas las facturas seleccionadas
            var listaRecibosFacturas = new List<ReciboFacturaDataContracts>();
            listaRecibosFacturas = ObtenerFacturasSeleccionadas();
            nuevoRecibo.ListadoDeFacturasACancelar = listaRecibosFacturas;
            var recibosCargadosPorEnElFront = new List<ReciboDataContracts>();
            if (Session["ListaDeRecibosCargados"] != null)
                recibosCargadosPorEnElFront = (List<ReciboDataContracts>) Session["ListaDeRecibosCargados"];
            recibosCargadosPorEnElFront.Add(nuevoRecibo);
            Session["ListaDeRecibosCargados"] = recibosCargadosPorEnElFront;
            //Actualizo la lista del costado
            var nuevoItemListaRecibos =
                new ListItem(cmbClientes.SelectedItem + " - " + cmbDeudores.SelectedItem + " - " + nuevoRecibo.Numero,
                             nuevoRecibo.Numero);
            btnCrearRemision.Enabled = true;
            //Esto es para que actualice el saldo de las facturas seleccionadas
            foreach (ReciboFacturaDataContracts oRecibo in listaRecibosFacturas)
            {
                foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
                {
                    var chk = (CheckBox) Fila.FindControl("chk");
                    if (chk.Checked)
                    {
                        //Fila.Cells[4].Text = String.Format("{0:0.00}", (double.Parse(Fila.Cells[4].Text) - oRecibo.ImporteAImputar));
                        Fila.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Text = String.Format(
                            "{0:0.00}",
                            (double.Parse(Fila.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Text) -
                             oRecibo.ImporteAImputar));

                        Fila.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Enabled = false;
                    }
                }
            }
            ReCalcularSuma();
            GuardarRecibo(nuevoRecibo);
            FillRecibosDisponibles();
            InicializarRecibo();
            this.HiddenFieldPagosCargados.Value = "";
            ScriptManager.RegisterStartupScript(Page, GetType(), "blanquearHiddenFieldPagos",
                                                "javascript:BlanquearHiddenFieldPagosCargados();", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "errorAlGuardarRecibo",
                                                "javascript:alert('Se ha producido el siguiente error al intentar guardar el recibo: " +
                                                ex.Message + "');", true);
        }
    }

    private void MantenerEstadoDeFilasDeshabilitadas()
    {
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            var chk = (CheckBox) Fila.FindControl("chk");
            var textBox = (TextBox) Fila.FindControl("txtAImputarPorFactura");
            var button = (Button) Fila.FindControl("ctl01");
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
        var nuevaRemision = new RemisionDataContracts();
        var nuevoAnalista = new AnalistaDataContracts(); //Tomar de sistema
        var principal = (GobbiPrincipal) Session["UserPrincipal"];
        nuevoAnalista.Nombre = principal.Identity.Name;
        nuevoAnalista.IdAnalista = ((GobbiIdentity) principal.Identity).Id;
        ;
        nuevaRemision.AnalistaGenerador = nuevoAnalista;
        nuevaRemision.FechaDeCreacion = DateTime.Now;
        nuevaRemision.NumeroRemision = int.Parse(lblRemisionEnUso.Text);

        //Para aceptar una lista de pagos, ya previamente desde javascript tendria que haber validado
        // que el usuario haya cargado algun pago, sino no puedo guardar un recibo.

        if (Session["ListaDeRecibosCargados"] == null)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "remisionSinPagos",
                                                "javascript:alert('Debe insertar algun pago para crear una remisión.');",
                                                true);
            return;
        }
        else
        {
            nuevaRemision.ListaDeRecibos = (List<ReciboDataContracts>) Session["ListaDeRecibosCargados"];
        }

        nuevaRemision.Estado = "ABIERTA";
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        remisionServices.UpdateReciboEnRemision(nuevaRemision, nuevoRecibo);
        ScriptManager.RegisterStartupScript(Page, GetType(), "reciboGuardado",
                                            "javascript:alert('El recibo " + nuevaRemision.ListaDeRecibos[0].Numero +
                                            " fue almacenado exitosamente.');", true);
    }

    protected void VerDetalleCheques(object sender, ImageClickEventArgs e)
    {
        ActualizarGrillaDetalleCheque();
        ModalPopupDetalleCheques.Show();
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
    }

    private List<ReciboFacturaDataContracts> ObtenerFacturasSeleccionadas()
    {
        GridViewRowCollection rows = GvResultadosFacturas.Rows;
        var listaRecibosFacturas = new List<ReciboFacturaDataContracts>();
        int pos = 1;
        string contString = "";
        int cantDigitos = 0;
        cantDigitos = rows.Count.ToString().Length;
        if (cantDigitos == 1) cantDigitos++;
        foreach (GridViewRow row in rows)
        {
            pos++;
            string rowName = "";
            if (
                Request.Form[
                    "ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" + pos.ToString().PadLeft(cantDigitos, '0') +
                    "$chk"] != null)
            {
                rowName =
                    Request.Form[
                        "ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" + pos.ToString().PadLeft(cantDigitos, '0') +
                        "$chk"];
            }
            else
            {
                if (
                    Request.Form[
                        "ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" +
                        pos.ToString().PadLeft(cantDigitos - 1, '0') + "$chk"] != null)
                    rowName =
                        Request.Form[
                            "ctl00$Contentplaceholder1$GvResultadosFacturas$ctl" +
                            pos.ToString().PadLeft(cantDigitos - 1, '0') +
                            "$chk"];
            }
            if (rowName == "on")
            {
                var reciboFactura = new ReciboFacturaDataContracts();

                reciboFactura.IdFactura =
                    int.Parse(row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "id Factura")].Text);
                reciboFactura.Importe =
                    double.Parse(row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "importe")].Text.Replace(".", ","));
                reciboFactura.ImporteAImputar =
                    double.Parse(
                        ((TextBox) row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].Controls[1]).Text.
                            Replace(".", ","));
                reciboFactura.ImporteAImputar =
                    double.Parse(string.Format("{0:#.#####,####}", reciboFactura.ImporteAImputar).Replace(".", ","));
                reciboFactura.ImporteProntoPago = "1"; //Esto se debe calcular.
                reciboFactura.NumRecibo = this.txtRecibo.Text;
                reciboFactura.Observacion = ""; //La que venga de la grilla
                reciboFactura.Saldo =
                    double.Parse(string.Format("{0:#.#####,####}",
                                               double.Parse(
                                                   row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "saldo")].Text.
                                                       Replace(".", ",")))) -
                    double.Parse(string.Format("{0:#.#####,####}",
                                               double.Parse(
                                                   ((TextBox)
                                                    row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].
                                                        Controls[1]).Text.Replace(".", ","))));
                reciboFactura.Saldo = reciboFactura.Saldo == 0
                                          ? 0
                                          : double.Parse(
                                              string.Format("{0:#.#####,####}", reciboFactura.Saldo).Replace(".", ","));
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
        txtPagos.Text = "0";
        txtPagosExt.Text = "0";
        txtSumaFacturas.Text = "0";
        txtSumaFacturasExt.Text = "0";
        txtDiferenciaPe.Text = "0";
        this.txtImporteTotalDelRecibo.Text = "0";
        //Para evitar saldos negativos, removemos tldes de la grilla
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            var chk = (CheckBox) Fila.FindControl("chk");
            chk.Checked = false;
        }
        BlanquearTodosLosPagos();
        LimpiarGrillaFacturas();
        this.TabContainer1.ActiveTabIndex = 0;
        this.HiddenFieldPagosCargados.Value = "";
        if (Session["ListaDeRecibosCargados"] != null)
            Session["ListaDeRecibosCargados"] = null;
        UpdatePanelIndice.Update();
        RemoveSessionObjects();
    }

    private void FiltrarFacturasTemporales(List<FacturaDataContracts> facturasTotalesDelDeudor)
    {
        var recibosCargadosTemporalmente = new List<ReciboDataContracts>();

        if (Session["ListaDeRecibosCargados"] != null)
            recibosCargadosTemporalmente = (List<ReciboDataContracts>) Session["ListaDeRecibosCargados"];


        foreach (ReciboDataContracts  recibo in recibosCargadosTemporalmente)
        {
            List<ReciboFacturaDataContracts> listadoDeFacturasACancelar = recibo.ListadoDeFacturasACancelar;

            foreach (ReciboFacturaDataContracts  factura in listadoDeFacturasACancelar)
            {
                //facturasTotalesDelDeudor.RemoveAll(new System.Predicate<FacturaDataContracts>(delegate(FacturaDataContracts fact) { return (fact.IdFactura == factura.IdFactura); }));
                foreach (FacturaDataContracts facturaReal in facturasTotalesDelDeudor)
                {
                    if (factura.IdFactura == facturaReal.IdFactura)
                    {
                        facturaReal.Saldo =
                            double.Parse(string.Format("{0:#.#########,####}", factura.Saldo - factura.ImporteAImputar));
                        break;
                    }
                }
            }
        }
    }

    private void ReCalcularSuma()
    {
        double total =
            GvResultadosFacturas.Rows.Cast<GridViewRow>().Where(
                row =>
                ((CheckBox) row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked).
                Aggregate<GridViewRow, double>(0,
                                               (current, row) =>
                                               current +
                                               double.Parse(
                                                   ((TextBox)
                                                    row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "A Imputar")].
                                                        Controls[1]).Text));

        txtSumaFacturas.Text = total.ToString();

        if (string.IsNullOrEmpty(this.txtCambio.Text))
            this.txtCambio.Text = "1.0000";
    }

    protected void btnCrearRemision_Click(object sender, EventArgs e)
    {
        var oRemision = new RemisionDataContracts();
        var nuevoAnalista = new AnalistaDataContracts(); //Tomar de sistema
        var principal = (GobbiPrincipal) Session["UserPrincipal"];
        nuevoAnalista.Nombre = principal.Identity.Name;
        nuevoAnalista.IdAnalista = ((GobbiIdentity) principal.Identity).Id;
        oRemision.AnalistaGenerador = nuevoAnalista;
        oRemision.NumeroRemision = int.Parse(lblRemisionEnUso.Text);
        oRemision.FechaDeCreacion = DateTime.Now;
        oRemision.Estado = "CERRADA"; //Hardcodeo horrible.

        //Aca deberi ir todo el proceso de guardar la remision en la base de datos
        //Si la operacion fué exitosa, se debe mostrar el número de remision generado y
        //limpiar toda la pantalla y las variables de sesion
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        remisionServices.Update(oRemision);

        //Se guarda PDF
        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
        ClienteDataContracts clienteDataContracts =
            clienteServices.GetCliente(decimal.Parse(cmbClientes.SelectedItem.Value));
        GuardarRemision(oRemision.NumeroRemision, clienteDataContracts);
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "remisionCerrada", "javascript:alert('La remisión n° " + this.lblRemisionEnUso.Text + " ha sido cerrada definitivamente');", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "GenerarPdfDeCierreDeRemision",
                                            "javascript:GenerarPdfDeCierreDeRemision('" + lblRemisionEnUso.Text + "');",
                                            true);
        InicializarRemision();
        RemoveSessionObjects();
        ScriptManager.RegisterStartupScript(Page, GetType(), "remisionCerrada2", "javascript:ClearRecibos();", true);
        AplicarEstiloAPantalla(Constants.ESTILO_REMISION_NUEVA);
    }

    protected void cmbRetenciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        var resultadoObtenidos = new List<SubTipoRetencionMTRDataContracts>();
        ISubTipoRetencionMTRService subTipoRetencionMTRServices =
            ServiceClient<ISubTipoRetencionMTRService>.GetService("SubTipoRetencionMTRService");
        resultadoObtenidos = subTipoRetencionMTRServices.GetAllSubTipoRetencionMTRs();
        if (cmbRetenciones.SelectedItem.Text == "Ingresos Brutos")
        {
            ddlSubTipo.Items.Clear();
            ddlSubTipo.DataSource = resultadoObtenidos;
            ddlSubTipo.DataTextField = "descripcion";
            ddlSubTipo.DataValueField = "id";
            ddlSubTipo.DataBind();
        }
        else
        {
            ddlSubTipo.Items.Clear();
            ddlSubTipo.Items.Add(new ListItem("No aplica", "0"));
        }
    }

    protected void GvResultadosFacturas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GvResultadosFacturas.SelectedIndex = e.NewSelectedIndex;
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (mgr.Contains("seleccionItemProntoPago"))
            mgr.Remove("seleccionItemProntoPago");
        mgr.Add("seleccionItemProntoPago", e.NewSelectedIndex);
        var listaProntoPago = new List<ProntoPagoDataContracts>();
        IProntoPagoService prontoPagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
        listaProntoPago =
            prontoPagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(cmbClientes.SelectedItem.Value),
                                                                     int.Parse(cmbDeudores.SelectedItem.Value));
        foreach (ProntoPagoDataContracts  pronto in listaProntoPago)
        {
            pronto.FechaLimiteDescuento =
                DateTime.Parse(
                    GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Vencimiento")].Text)
                    .AddDays(-pronto.DiasDeAnticipacion);
        }
        DataTable dt = ConvertDataTable<ProntoPagoDataContracts>.Convert(listaProntoPago);
        gvProntoPago.DataSource = dt;
        gvProntoPago.DataBind();
        txtImporteActual.Text =
            GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "Saldo")].Text;
        lblVencimientoFactRes.Text =
            GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "vencimiento")].Text;
        txtImporteProntoPago.Text = "";
        ModalPopupProntoPago.Show();
        UIUtils.PaintSelectedRow(GvResultadosFacturas, "id factura",
                                 GvResultadosFacturas.SelectedRow.Cells[
                                     UIUtils.GetPosCol(GvResultadosFacturas, "id Factura")].Text);
    }

    protected void gvProntoPago_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int indexSelect = e.NewSelectedIndex;
        gvProntoPago.SelectedIndex = e.NewSelectedIndex;
        txtImporteProntoPago.Text =
            (double.Parse(gvProntoPago.SelectedRow.Cells[UIUtils.GetPosCol(gvProntoPago, "Porcentaje(%)")].Text)*
             double.Parse(txtImporteActual.Text.Replace(".", ","))/100).ToString();
        UIUtils.PaintSelectedRow(gvProntoPago, "id", (e.NewSelectedIndex + 1).ToString());
        ModalPopupProntoPago.Show();
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
    }

    protected void RadioButtonEstadoRemision_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((RadioButtonList) sender).SelectedValue == "Abierta")
        {
            btnNuevaRemision.Text = "Buscar Remisión";
        }
        else
        {
            btnNuevaRemision.Text = "Crear Remisión";
        }
    }

    protected void btnNuevaRemision_Click(object sender, EventArgs e)
    {
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        var nuevaRemision = new RemisionDataContracts();
        var principal = (GobbiPrincipal) Session["UserPrincipal"];
        var nuevoAnalista = new AnalistaDataContracts();
        nuevoAnalista.Nombre = principal.Identity.Name;
        nuevoAnalista.IdAnalista = ((GobbiIdentity) principal.Identity).Id;
        nuevaRemision.AnalistaGenerador = nuevoAnalista;
        nuevaRemision.IDCliente = int.Parse(cmbClientes.SelectedValue);
        nuevaRemision.Estado = "ABIERTA";
        nuevaRemision.FechaDeCreacion = DateTime.Now;
        int remisionTemporal = remisionServices.InsertCabecera(nuevaRemision);
        this.panelGeneralCuerpoPagina.Enabled = true;
        btnRemisionEnUso.Enabled = false;
        ScriptManager.RegisterStartupScript(Page, GetType(), "nuevaRemision", "javascript:PopupRemisionCreadaOk();",
                                            true);
        btnNuevaRemisionTemporal.Enabled = true;
        btnRemisionEnUso.Enabled = false;
        lblRemisionEnUso.Text = remisionTemporal.ToString();
        btnNuevaRemisionTemporal.CommandArgument = "";
        btnNuevaRemisionTemporal.Text = "Nueva operación";
        TabPanel1.Focus();
        RemoveSessionObjects();
    }

    protected void btnRemisionEnUso_Click(object sender, EventArgs e)
    {
        InicializarRemision();
        var listaRemisiones = new List<RemisionDataContracts>();
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        listaRemisiones = remisionServices.GetAllRemisionsBlocked();
        DataTable dt = ConvertDataTable<RemisionDataContracts>.Convert(listaRemisiones);
        gvResultadosConcurrencia.DataSource = dt;
        gvResultadosConcurrencia.DataBind();
        this.panelGeneralCuerpoPagina.Enabled = true;
        this.ModalPopupDetalleControlConcurrencia.Show();
        this.HiddenFieldPagosCargados.Value = "";
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
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
            this.txtFechaVencimiento.Text = "";
        }
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
    }

    protected void GvResultadosFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[UIUtils.GetPosCol(GvResultadosFacturas, "saldo")].Text == "0,0000")
                e.Row.Visible = false;
        }
    }

    private int BloquearDeudor_Click(string nuevoDeudor, string anteriorDeudor)
    {
        string res = "";
        try
        {
            if (cmbDeudores.SelectedItem.Value != "0")
            {
                var controlRemision = new ControlRemisionConcurrenciaDataContracts();
                controlRemision.DatoBloqueado = cmbDeudores.SelectedItem.Text;
                controlRemision.EstadoLock = Session.SessionID + "/LOCK";
                controlRemision.FechaInicioLock = DateTime.Now;
                controlRemision.FechaForceUnlock = DateTime.Now;
                controlRemision.NumRemision = lblRemisionEnUso.Text;
                var principal = (GobbiPrincipal) Session["UserPrincipal"];
                controlRemision.UsuarioLock = (principal.Identity.Name);
                IControlRemisionConcurrenciaService controlRemisionServices =
                    ServiceClient<IControlRemisionConcurrenciaService>.GetService("ControlRemisionConcurrenciaService");
                res = controlRemisionServices.InsertWithResult(controlRemision);
                if (res != string.Empty)
                    new Exception();
                //Elimino el anterior deudor bloqueado
                if (string.Empty != this.lblSelDeu.Text)
                {
                    controlRemision.DatoBloqueado = this.lblSelDeu.Text;
                    controlRemisionServices.Delete(controlRemision);
                }

                if (this.cmbRecibosDisponibles.Items.Count > 0)

                    btnNuevaRemisionTemporal.Enabled = true;
                else
                    btnNuevaRemisionTemporal.Enabled = false;

                this.lblSelDeu.Text = cmbDeudores.SelectedItem.ToString();
                return 0;
            }
            else
            {
                btnNuevaRemisionTemporal.Enabled = false;
                ScriptManager.RegisterStartupScript(Page, GetType(), "nuevaRemision",
                                                    "javascript:alert('Seleccione un deudor.');", true);
                return -1;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "nuevaRemision",
                                                "javascript:alert('El deudor que esta intentando bloquear, esta siendo utilizado por " +
                                                res + ". ');", true);
            return -1;
        }
    }

    protected void ibtnBloquearDeudor_Click(object sender, ImageClickEventArgs e)
    {
        string res = "";
        try
        {
            btnNuevaRemisionTemporal.Enabled = false;
            if (cmbDeudores.SelectedItem.Value != "0")
            {
                var controlRemision = new ControlRemisionConcurrenciaDataContracts();
                controlRemision.DatoBloqueado = cmbDeudores.SelectedItem.Text;
                controlRemision.EstadoLock = "LOCK";
                controlRemision.FechaInicioLock = DateTime.Now;
                controlRemision.FechaForceUnlock = DateTime.Now;
                controlRemision.NumRemision = lblRemisionEnUso.Text;
                var principal = (GobbiPrincipal) Session["UserPrincipal"];
                controlRemision.UsuarioLock = (principal.Identity.Name);
                IControlRemisionConcurrenciaService controlRemisionServices =
                    ServiceClient<IControlRemisionConcurrenciaService>.GetService("ControlRemisionConcurrenciaService");
                res = controlRemisionServices.InsertWithResult(controlRemision);

                if (res != string.Empty)
                {
                    throw new Exception();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "nuevaRemision",
                                                        "javascript:alert('Deudor " + cmbDeudores.SelectedItem.Text +
                                                        " bloqueado con éxito');", true);
                }

                btnNuevaRemisionTemporal.Enabled = true;
                cmbDeudores.Enabled = false;
                cmbClientes.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "nuevaRemision",
                                                    "javascript:alert('Seleccione un deudor.');", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "nuevaRemision",
                                                "javascript:alert('El deudor que esta intentando bloquear, esta siendo utilizado por " +
                                                res + ". ');", true);
        }
    }

    protected void btnNuevaRemisionTemporal_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument.ToString() == "CREAR")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "crearNuevaRemision",
                                                "javascript:VerificarConfirmacionNuevaRemision();", true);
            btnNuevaRemision.Focus();
        }
        else
        {
            //Aca cancelo todo
            AplicarEstiloAPantalla(Constants.ESTILO_REMISION_NUEVA);
            var controlRemision = new ControlRemisionConcurrenciaDataContracts();
            controlRemision.DatoBloqueado = this.lblSelDeu.Text;
            controlRemision.EstadoLock = Session.SessionID + "/OPERACION_CANCELADA";
            controlRemision.FechaInicioLock = DateTime.Now;
            controlRemision.FechaForceUnlock = DateTime.Now;
            controlRemision.NumRemision = lblRemisionEnUso.Text;
            var principal = (GobbiPrincipal) Session["UserPrincipal"];
            controlRemision.UsuarioLock = (principal.Identity.Name);
            IControlRemisionConcurrenciaService controlRemisionServices =
                ServiceClient<IControlRemisionConcurrenciaService>.GetService("ControlRemisionConcurrenciaService");
            controlRemisionServices.Update(controlRemision);
            InicializarRemision();
            this.HiddenFieldPagosCargados.Value = string.Empty;
            ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                                "javascript:AsignarHiddenFieldATabla();", true);
            ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                                "javascript:ActualizarDiferenciaPagosFacturas();", true);
            Response.Redirect("ViewRemisionDeValores.aspx");
        }
    }

    private void InicializarRemision()
    {
        this.txtCambio.Text = "1.0000"; //Horrible;
        this.txtFechaRecibo.Text = DateTime.Now.ToShortDateString();
        Session["ListaDePagos"] = null;
        ActualizarGrillaCargaPagos();
        txtPagos.Text = "0";
        txtSumaFacturas.Text = "0";
        BlanquearTodosLosPagos();
        LimpiarGrillaFacturas();
        this.TabContainer1.ActiveTabIndex = 0;
        this.panelGeneralCuerpoPagina.Enabled = false;
        cmbClientes.SelectedIndex = 0;
        cmbDeudores.Items.Clear();
        cmbDeudores.Enabled = false;
        btnNuevaRemisionTemporal.Enabled = false;
        btnRemisionEnUso.Enabled = true;
        lblRemisionEnUso.Text = "";
        this.lblSelDeu.Text = "";
        cmbClientes.Enabled = true;
        updatePanelRemisionEnUso.Update();
        this.HiddenFieldPagosCargados.Value = "";
        btnNuevaRemisionTemporal.Text = "Crear Remision";
        this.panelGeneralCuerpoPagina.Enabled = false;
        this.txtRecibo.Text = "";
        UpdatePanelIndice.Update();
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
    }

    private void InicializarRemisionPorPostback()
    {
        this.txtCambio.Text = "1.0000"; //Horrible;
        this.txtFechaRecibo.Text = DateTime.Now.ToShortDateString();
        Session["ListaDePagos"] = null;
        ActualizarGrillaCargaPagos();
        txtPagos.Text = "0";
        txtSumaFacturas.Text = "0";
        BlanquearTodosLosPagos();
        LimpiarGrillaFacturas();
        this.TabContainer1.ActiveTabIndex = 0;
        this.panelGeneralCuerpoPagina.Enabled = false;
        btnNuevaRemisionTemporal.Enabled = false;
        btnRemisionEnUso.Enabled = true;
        this.lblSelDeu.Text = "";
        cmbClientes.Enabled = true;
        updatePanelRemisionEnUso.Update();
        this.HiddenFieldPagosCargados.Value = "";
        btnNuevaRemisionTemporal.Text = "Crear Remision";
        this.panelGeneralCuerpoPagina.Enabled = false;
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
        lblRemisionEnUso.Text = "";
    }

    private void GuardarRemision(int idRemision, ClienteDataContracts cliente)
    {
        var pc = new PdfCreator();
        string pszRuta = Server.MapPath("../PDF");
        string pszImagenes = Server.MapPath("../Images");
        try
        {
            pc.CreaarPdf(idRemision, pszRuta, pszImagenes);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Enviado",
                                                    "alert('Ocurrió un error al intentar crear el archivo PDF. Infórmelo al administrador. Detalle: " +
                                                    ex.Message + "');", true);
        }
        try
        {
            if (chkMail.Checked)
                EnviarRemision("/Remision" + idRemision + ".pdf", cliente.EMAIL);
            chkMail.Checked = false;
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Enviado",
                                                    "alert('Email no enviado: No se puede conectar al servidor de correo. Deberá enviarlo manualmente.');",
                                                    true);
        }
    }

    protected void btnRefreshCmbDeudores_Click(object sender, ImageClickEventArgs e)
    {
        //Si refresco el deudor, elimino los pagos cargados, totales y facturas.
        var resultadoObtenidos = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");
        resultadoObtenidos =
            deudorServices.GetAllDeudorsLivianoPorCriterioCliente(int.Parse(cmbClientes.SelectedItem.Value));
        var seleccion = new DeudorLivianoDataContracts();
        seleccion.Nombre = "--- SELECCIONE ---";
        seleccion.IdDeudor = 0;
        resultadoObtenidos.Insert(0, seleccion);
        cmbDeudores.Items.Clear();
        cmbDeudores.DataSource = resultadoObtenidos;
        cmbDeudores.DataTextField = "NOMBRE";
        cmbDeudores.DataValueField = "idDeudor";
        cmbDeudores.DataBind();
        btnNuevaRemisionTemporal.Enabled = false;
        InicializarRecibo();
        this.HiddenFieldPagosCargados.Value = "";
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
        this.panelGeneralCuerpoPagina.Enabled = false;
        UpdatePanelIndice.Update();
    }

    protected void btnCerrarModalRemisionesAbiertas_Click(object sender, EventArgs e)
    {
        this.ModalPopupDetalleControlConcurrencia.Hide();
        this.panelGeneralCuerpoPagina.Enabled = false;
        UpdatePanelIndice.Update();
    }

    protected void gvResultadosConcurrencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idRemision = ((GridView) sender).SelectedDataKey.Value.ToString();
        string idCliente =
            ((GridView) sender).SelectedRow.Cells[UIUtils.GetPosCol(((GridView) sender), "ID Cliente")].Text;
        ListItem item = cmbClientes.SelectedItem;
        item.Selected = false;
        item = (cmbClientes.Items.FindByValue(idCliente));
        item.Selected = true;
        lblRemisionEnUso.Text = idRemision;
        var principal = (GobbiPrincipal) Session["UserPrincipal"];
        string usuario = (principal.Identity.Name);
        if (usuario ==
            ((GridView) sender).SelectedRow.Cells[UIUtils.GetPosCol(((GridView) sender), "Analista Creador")].Text)
            btnCrearRemision.Enabled = true;
        else
            btnCrearRemision.Enabled = false;
        AplicarEstiloAPantalla(Constants.ESTILO_REMISION_EN_USO);
        cmbClientes_SelectedIndexChanged(sender, null);
        cmbClientes.DataBind();
        UpdatePanelIndice.Update();
        updatePanelRemisionEnUso.Update();
        this.ModalPopupDetalleControlConcurrencia.Hide();
        this.HiddenFieldPagosCargados.Value = "";
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturas();", true);
    }

    protected void AbrirRemisionDesdeEdicion(string idRemision, string idCliente, string analista)
    {
        // ListItem item=((ListItem)this.cmbClientes.Items.FindByValue(idCliente));
        txtSumaFacturas.Text = "0.00";
        ListItem item = cmbClientes.SelectedItem;
        item.Selected = false;
        item = (cmbClientes.Items.FindByValue(idCliente));
        item.Selected = true;
        lblRemisionEnUso.Text = idRemision;
        cmbClientes.Enabled = false;
        var principal = (GobbiPrincipal) Session["UserPrincipal"];
        string usuario = (principal.Identity.Name);
        if (usuario == analista)
            btnCrearRemision.Enabled = true;
        else
            btnCrearRemision.Enabled = false;
        cmbClientes_SelectedIndexChanged(null, null);
        cmbClientes.DataBind();
        UpdatePanelIndice.Update();
        updatePanelRemisionEnUso.Update();
        this.ModalPopupDetalleControlConcurrencia.Hide();
        this.HiddenFieldPagosCargados.Value = "";
        ScriptManager.RegisterStartupScript(Page, GetType(), "AsignarHiddenFieldATabla",
                                            "javascript:AsignarHiddenFieldATabla();", true);
        ScriptManager.RegisterStartupScript(Page, GetType(), "ActualizarDiferenciaPagosFacturas",
                                            "javascript:ActualizarDiferenciaPagosFacturasPantallaEdicion();", true);
    }

    private void EnviarRemision(string pszArchivo, string destinatario)
    {
        string isTest = ConfigurationManager.AppSettings["isTest"];
        if (isTest == "Test")
            destinatario = "stgugliotta@gmail.com";
        var Correo = new MailMessage();
        Correo.From = new MailAddress(((GobbiIdentity) ((GobbiPrincipal) Session["UserPrincipal"]).Identity).Email);
            //Si se quiere comprobar, agregar una cuenta de yahoo         
        Correo.To.Add(destinatario);
        Correo.Bcc.Add(((GobbiIdentity) ((GobbiPrincipal) Session["UserPrincipal"]).Identity).Email);
        Correo.Bcc.Add("stgugliotta@gmail.com"); //Si se quiere probar, poner cualquier cuenta
        Correo.Bcc.Add("fmperfetti@hotmail.com");
        Correo.Bcc.Add("gabrielsanblas@gmail.com");

        Correo.Subject = "EMACSA - Nueva Remision de Valores"; //Completar el asunto
        Correo.Body = "";
        Correo.IsBodyHtml = false;
        Correo.Priority = MailPriority.Normal;

        //Adjunto:
        var oAdjunto = new Attachment(Server.MapPath("../PDF" + pszArchivo));
        Correo.Attachments.Add(oAdjunto);

        var smtp = new SmtpClient();
        smtp.Host = ConfigurationManager.AppSettings["smtp" + ConfigurationManager.AppSettings["isTest"]];
        //Si se quiere probar, usar el smtp de yahoo (smtp.mail.yahoo)
        smtp.Credentials =
            new NetworkCredential(((GobbiIdentity) ((GobbiPrincipal) Session["UserPrincipal"]).Identity).Email,
                                  ((GobbiIdentity) ((GobbiPrincipal) Session["UserPrincipal"]).Identity).PasswordEmail);
        //Si se quiere prbar, completar con el nombre de usuario (sin @yahoo.com ni nada) y el pass.
        try
        {
            smtp.Send(Correo);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Enviado", "alert('Remision enviada por mail.');",
                                                    true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Enviado",
                                                    "alert('Mensaje no enviado: No se puede conectar al servidor de correo. Deberá enviarlo manualmente.');",
                                                    true);
        }
    }

    protected void cmbBanco_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtBanco.Text = cmbBanco.SelectedValue;
    }

    private void AplicarEstiloAPantalla(string nombreDelEstilo)
    {
        switch (nombreDelEstilo)
        {
            case "RemisionEnUso":
                {
                    cmbClientes.Enabled = false;
                    lblTipoRemision.Text = "Remisión en Uso";
                    btnNuevaRemisionTemporal.CommandArgument = "";
                    btnNuevaRemisionTemporal.Text = "Nueva operación";
                    btnRemisionEnUso.Visible = false;
                    break;
                }

            case "RemisionNueva":
                {
                    cmbClientes.Enabled = true;
                    cmbDeudores.Enabled = true;
                    btnNuevaRemisionTemporal.Enabled = false;
                    btnNuevaRemisionTemporal.CommandArgument = "CREAR";
                    btnNuevaRemisionTemporal.Text = "Crear Remisión";
                    btnRemisionEnUso.Visible = true;
                    cmbDeudores.Items.Clear();
                    this.cmbRecibosDisponibles.Items.Clear();
                    break;
                }
            case "EdicionDeRemision":
                {
                    break;
                }
        }
    }
}