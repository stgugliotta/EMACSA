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
using System.Collections.Generic;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.services;
using Herramientas;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.Caching;
using System.Reflection;

public partial class Vistas_ViewEdicionRecibo : System.Web.UI.Page
{

    private bool _evitarPrerenderTextBox = false;
    private bool _evitarPrerenderGrillaFactura = false;

    protected void Page_Load(object sender, EventArgs e)
    {



        ValidarCambioTab();

        if (!Page.IsPostBack)
        {



            this.gvResultadosPagos.DataSource = null;
            this.gvResultadosPagos.DataBind();
            this.btnCrearRemision.Enabled = false;
            this.btnNuevaRemisionTemporal.Enabled = false;
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



            this.btnAgregarPago.ValidationGroup = "chequeGroup";
            this.btnEditarPago.ValidationGroup = "chequeGroup";
            this.btnGuardarRecibo.ValidationGroup = "reciboGroup";

            this.txtSumaFacturas.Text = "0";
            this.txtSumaFacturasExt.Text = "0";
            this.txtPagos.Text = "0";
            this.txtPagosExt.Text = "0";
            this.btnEditarPago.Visible = false;
            this.btnCancelarEdicion.Visible = false;
            ActualizarGrillaCargaPagos();


            //Configuro estado inicial de la pantalla

            this.panelGeneralCuerpoPagina.Enabled = false;


            //


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

            PersonalizarRemision();

        }
    }


    private void ValidarCambioTab()
    {
        string postbackControl = this.hdPostbackControl.Value;


        switch (postbackControl)
        {

            case "CHEQUE":
                this.TabContainer1.ActiveTabIndex = 0;
                TabContainer1_ActiveTabChanged(null, null);

                break;

            case "RETENCION":
                this.TabContainer1.ActiveTabIndex = 1;
                TabContainer1_ActiveTabChanged(null, null);
                break;

            case "EFECTIVO":
                this.TabContainer1.ActiveTabIndex = 2;
                TabContainer1_ActiveTabChanged(null, null);
                break;

            case "DEPOSITO":
                this.TabContainer1.ActiveTabIndex = 3;
                TabContainer1_ActiveTabChanged(null, null);
                break;

            case "TRANSFERENCIA":
                this.TabContainer1.ActiveTabIndex = 4;
                TabContainer1_ActiveTabChanged(null, null);
                break;

            case "OTROPAGO":
                this.TabContainer1.ActiveTabIndex = 5;
                TabContainer1_ActiveTabChanged(null, null);
                break;

            case "DESCUENTO":
                this.TabContainer1.ActiveTabIndex = 6;
                TabContainer1_ActiveTabChanged(null, null);
                break;
        }
    }

    private void PersonalizarRemision()
    {
        if (Request.QueryString["idDeudor"] != string.Empty && Request.QueryString["idDeudor"] != null && Request.QueryString["idDeudor"] != string.Empty && Request.QueryString["idDeudor"] != null)
        {
            string idDeudor = Request.QueryString["idDeudor"].ToString();
            string idCliente = Request.QueryString["idCliente"].ToString();
            ListItem item = this.cmbClientes.Items.FindByValue(idCliente);
            this.cmbClientes.SelectedIndex = -1;
            item.Selected = true;

            this.cmbClientes_SelectedIndexChanged(null, null);

            ListItem itemDeudor = this.cmbDeudores.Items.FindByValue(idDeudor);
            this.cmbDeudores.SelectedIndex = -1;
            itemDeudor.Selected = true;

            this.cmbDeudores_SelectedIndexChanged(null, null);
        }
        else
        {

            this.cmbClientes.SelectedIndex = 0;

        }

    }

    private void CargarGrillaFacturas(int deudor)
    {
        DataTable dataTable2 = GetDataTableFacturasPorDeudor(deudor);

        this.GvResultadosFacturas.DataSource = dataTable2;

        this.GvResultadosFacturas.DataBind();


        GridViewRowCollection rows = this.GvResultadosFacturas.Rows;


        foreach (GridViewRow row in rows)
        {

            ((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Saldo")].Text;


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

    }


    private void LimpiarGrillaFacturas()
    {

        DataTable dataTable2 = null;

        this.GvResultadosFacturas.DataSource = dataTable2;

        this.GvResultadosFacturas.DataBind();


        GridViewRowCollection rows = this.GvResultadosFacturas.Rows;


        //foreach (GridViewRow row in rows)
        //{

        //    ((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Saldo")].Text;


        //}

        //if (this.GvResultadosFacturas.Rows.Count > 0)
        //{

        //    UInt16 i = 0;
        //    foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        //    {
        //        if (Fila.Visible == true)
        //            i++;
        //    }
        //    this.lblResResultadoCantFacts.Text = i.ToString();

        //}

        //else
        //{
        //    this.lblResResultadoCantFacts.Text = "0";
        //}


    }



    private DataTable GetDataTableFacturasPorDeudor(int idDeudor)
    {
        List<FacturaDataContracts> resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetAllFacturasPorIdDeudor(idDeudor);

        FiltrarFacturasTemporales(resultadoObtenidos);

        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);


    }



    protected void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
    {

        List<DeudorDataContracts> resultadoObtenidos = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");


        resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioCliente(int.Parse(this.cmbClientes.SelectedItem.Value));

        DeudorDataContracts seleccion = new DeudorDataContracts();
        seleccion.Nombre = "--- SELECCIONE ---";
        seleccion.IdDeudor = 0;
        resultadoObtenidos.Insert(0, seleccion);

        this.cmbDeudores.Items.Clear();
        this.cmbDeudores.DataSource = resultadoObtenidos;
        this.cmbDeudores.DataTextField = "NOMBRE";
        this.cmbDeudores.DataValueField = "idDeudor";
        this.cmbDeudores.DataBind();
        this.cmbDeudores.Enabled = true;



        // Esto pertenece a la solapa de Depositos
        List<ClienteCuentaDataContracts> clienteCuentas = new List<ClienteCuentaDataContracts>();
        IClienteCuentaService clienteCuentaServices = ServiceClient<IClienteCuentaService>.GetService("ClienteCuentaService");
        clienteCuentas = clienteCuentaServices.GetAllClienteCuentasByIdCliente(int.Parse(this.cmbClientes.SelectedItem.Value));
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

        if (resultadoObtenidos.Count != 0)
        {

            CargarGrillaFacturas(resultadoObtenidos[0].IdDeudor);

        }
        else
        {

            List<FacturaDataContracts> resultadoObtenidos2 = new List<FacturaDataContracts>();

            DataTable dataTable2 = ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos2);

            this.GvResultadosFacturas.DataSource = dataTable2;
            this.GvResultadosFacturas.DataBind();
            this.panelGeneralCuerpoPagina.Enabled = false;

        }
    }


    protected void btnAplicarProntoPago_OnClick(object sender, EventArgs e)
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (mgr.Contains("seleccionItemProntoPago"))
        {
            int key = (int)mgr.GetData("seleccionItemProntoPago");

            this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe PP")].Text = this.txtImporteProntoPago.Text;
            ((TextBox)this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text = this.txtImporteProntoPago.Text;

            updatePanelGvFacturas.Update();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "cerrarPanelProntoPago", "javascript:HideConfirma3();", true);


        }
    }


    protected void btnQuitarProntoPago_OnClick(object sender, EventArgs e)
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (mgr.Contains("seleccionItemProntoPago"))
        {
            int key = (int)mgr.GetData("seleccionItemProntoPago");

            this.GvResultadosFacturas.Rows[key].Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe PP")].Text = "0";
            updatePanelGvFacturas.Update();


            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "cerrarPanelProntoPago", "javascript:HideConfirma3();", true);


        }
    }
    protected void btnAgregarPago_Click(object sender, EventArgs e)
    {


        _evitarPrerenderGrillaFactura = true;

        switch (this.TabContainer1.ActiveTabIndex)
        {
            //Creo un cheque
            case 0:

                ChequeDataContracts nuevoCheque = new ChequeDataContracts();
                nuevoCheque.FechaPago = DateTime.Now;
                nuevoCheque.Banco = this.txtBanco.Text;
                nuevoCheque.Cuenta = this.txtCuenta.Text;
                nuevoCheque.Cuit = this.txtCuitEmisor.Text;
                nuevoCheque.Cp = this.txtCp.Text;
                nuevoCheque.Emision = DateTime.Parse(this.txtFechaEmision.Text);
                nuevoCheque.Vencimiento = DateTime.Parse(this.txtFechaVencimiento.Text);
                nuevoCheque.Importe = double.Parse(System.Math.Round(double.Parse(this.txtImporte.Text), 2).ToString());
                nuevoCheque.Sucursal = this.txtSucursal.Text;
                nuevoCheque.FormaPago = new FormaPagoDataContracts(1, "CHEQUE");
                nuevoCheque.Numero = long.Parse(this.txtCheque.Text);
                this.AgregarPago(nuevoCheque);
                BlanquearPagos(this.TabContainer1.ActiveTabIndex);
                ActualizarGrillaCargaPagos();
                break;

            case 1:

                RetencionDataContracts nuevaRetencion = new RetencionDataContracts();

                nuevaRetencion.FechaPago = DateTime.Now;
                nuevaRetencion.FormaPago = new FormaPagoDataContracts(3, "RETENCION");
                nuevaRetencion.Importe = double.Parse(this.txtImporteRetencion.Text);
                nuevaRetencion.Importe = Math.Round(nuevaRetencion.Importe, 4);
                nuevaRetencion.NumeroRetencion = this.txtNumeroRetencion.Text.ToString();
                nuevaRetencion.IdRetencion = int.Parse(this.cmbDescuentos.SelectedItem.Value);

                this.AgregarPago(nuevaRetencion);
                BlanquearPagos(this.TabContainer1.ActiveTabIndex);
                ActualizarGrillaCargaPagos();

                break;

            case 2:
                EfectivoDataContracts nuevoEfectivo = new EfectivoDataContracts();
                nuevoEfectivo.FechaPago = DateTime.Parse(this.txtFechaPagoEfectivo.Text);
                nuevoEfectivo.FormaPago = new FormaPagoDataContracts(2, "EFECTIVO");
                nuevoEfectivo.Monto = double.Parse(this.txtImporteEfectivo.Text);
                //nuevoEfectivo.Importe = double.Parse(Math.Round(nuevoEfectivo.Monto, 2).ToString());
                nuevoEfectivo.Importe = double.Parse(nuevoEfectivo.Monto.ToString());
                nuevoEfectivo.Importe = Math.Round(nuevoEfectivo.Importe, 4);
                this.AgregarPago(nuevoEfectivo);
                BlanquearPagos(this.TabContainer1.ActiveTabIndex);
                ActualizarGrillaCargaPagos();

                break;

            case 3:

                DepositoDataContracts nuevoDeposito = new DepositoDataContracts();
                nuevoDeposito.FechaDeposito = DateTime.Parse(this.txtFechaDeposito.Text);
                nuevoDeposito.FechaPago = DateTime.Now;
                nuevoDeposito.FormaPago = new FormaPagoDataContracts(4, "DEPOSITO");
                nuevoDeposito.Importe = double.Parse(this.txtImporteDeposito.Text);
                nuevoDeposito.Importe = Math.Round(nuevoDeposito.Importe, 4);
                nuevoDeposito.NumComprobante = this.txtNumComprob.Text;
                nuevoDeposito.IdCuenta = this.cmbCuentasClientes.SelectedItem.Value;
                nuevoDeposito.Sucursal = this.txtSucursalDeposito.Text;
                this.AgregarPago(nuevoDeposito);
                BlanquearPagos(this.TabContainer1.ActiveTabIndex);
                ActualizarGrillaCargaPagos();
                break;
            case 4:

                TransferenciaDataContracts nuevaTransferencia = new TransferenciaDataContracts();
                nuevaTransferencia.FechaDeposito = DateTime.Parse(this.txtFechaTransferencia.Text);
                nuevaTransferencia.FechaCarga = DateTime.Now;
                nuevaTransferencia.FormaPago = new FormaPagoDataContracts(5, "TRANSFERENCIA");
                nuevaTransferencia.Importe = double.Parse(this.txtImporteTransferencia.Text);
                nuevaTransferencia.Importe = Math.Round(nuevaTransferencia.Importe, 4);
                nuevaTransferencia.CuentaCredito = this.cmbCuentaCredito.SelectedItem.ToString();
                nuevaTransferencia.CuentaDebito = this.txtCuentaDebito.Text;
                nuevaTransferencia.NumComprobante = this.txtNumComprobTrans.Text;
                this.AgregarPago(nuevaTransferencia);
                BlanquearPagos(this.TabContainer1.ActiveTabIndex);
                ActualizarGrillaCargaPagos();

                break;
            case 5:

                OtroPagoDataContracts nuevoOtroPago = new OtroPagoDataContracts();
                nuevoOtroPago.FechaPago = DateTime.Parse(this.txtFechaPagoRaro.Text);
                nuevoOtroPago.FormaPago = new FormaPagoDataContracts(6, "OTRO");
                nuevoOtroPago.Importe = double.Parse(this.txtImporteRaro.Text);
                nuevoOtroPago.Importe = Math.Round(nuevoOtroPago.Importe, 4);
                nuevoOtroPago.NumComprobante = this.txtNumCompRaro.Text;
                this.AgregarPago(nuevoOtroPago);
                BlanquearPagos(this.TabContainer1.ActiveTabIndex);
                ActualizarGrillaCargaPagos();


                break;
            case 6:

                RemisionDescuentoDataContracts nuevoDescuento = new RemisionDescuentoDataContracts();
                nuevoDescuento.FechaDescuento = DateTime.Now;
                nuevoDescuento.IdRemision = 0;//Ver
                nuevoDescuento.IdDescuento = int.Parse(this.cmbDescuentos.SelectedItem.Value);
                nuevoDescuento.Importe = double.Parse(this.txtImporteDescuento.Text);
                nuevoDescuento.Importe = Math.Round(nuevoDescuento.Importe, 4);
                nuevoDescuento.FormaPago = new FormaPagoDataContracts(7, "DESCUENTO");
                this.AgregarPago(nuevoDescuento);
                BlanquearPagos(this.TabContainer1.ActiveTabIndex);
                ActualizarGrillaCargaPagos();

                break;

        }




    }

    private void ActualizarGrillaDetalleCheque()
    {
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

        this.gvResultadosPagos.DataSource = dataTable;
        this.gvResultadosPagos.DataBind();

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
                this.txtBanco.Text = "";
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
                // this.txtCuentaCredito.Text = string.Empty;
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
        ///////////////////////////////////
        this.txtImporteRetencion.Text = string.Empty;
        this.txtNumeroRetencion.Text = string.Empty;
        ///////////////////////////////////
        this.txtImporteEfectivo.Text = string.Empty;

        this.txtFechaPagoEfectivo.Text = DateTime.Today.ToString();
        ///////////////////////////////////

        //this.cmbCuentasClientes.SelectedIndex=0;
        this.txtSucursalDeposito.Text = string.Empty;
        this.txtImporteDeposito.Text = string.Empty;
        this.txtFechaDeposito.Text = string.Empty;
        this.txtNumComprob.Text = string.Empty;
        //////////////////////////////////
        // this.txtCuentaCredito.Text = string.Empty;
        this.txtCuentaDebito.Text = string.Empty;
        this.txtFechaTransferencia.Text = string.Empty;
        this.txtNumComprobTrans.Text = string.Empty;
        this.txtImporteTransferencia.Text = string.Empty;
        /////////////////////////////////
        this.cmbTipoPagoRaro.SelectedIndex = 0;
        this.txtFechaPagoRaro.Text = string.Empty;
        this.txtNumCompRaro.Text = string.Empty;
        this.txtImporteRaro.Text = string.Empty;
        ////////////////////////////////
        this.txtImporteDescuento.Text = string.Empty;
        this.cmbDescuentos.SelectedIndex = 0;

    }


    private void AgregarPago(PagoDataContracts pago)
    {

        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();

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
    private void CrearRemision()
    {


        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");






        List<Common.DataContracts.PagoDataContracts> listaDePagos = new List<Common.DataContracts.PagoDataContracts>();

        ChequeDataContracts cheque = new ChequeDataContracts();


        cheque.Banco = "holas";
        cheque.Emision = DateTime.Now;


        //Usar un servicio para traer las formas de pago.
        //Seleccionar la que corresponda.
        FormaPagoDataContracts fp = new FormaPagoDataContracts();
        fp.IdFormaPago = 1;
        fp.Descripcion = "Cheque";
        cheque.FormaPago = fp;
        cheque.Importe = 140;


        ChequeDataContracts cheque2 = new ChequeDataContracts();


        cheque2.Banco = "holas";
        cheque2.Emision = DateTime.Now;
        cheque2.FechaPago = DateTime.Now;

        //Usar un servicio para traer las formas de pago.
        //Seleccionar la que corresponda.
        FormaPagoDataContracts fp2 = new FormaPagoDataContracts();
        fp2.IdFormaPago = 1;
        fp2.Descripcion = "Cheque";
        cheque2.FormaPago = fp;
        cheque2.Importe = 140;


        listaDePagos.Add(cheque);
        listaDePagos.Add(cheque2);


        MotoqueroDataContracts motoquero = new MotoqueroDataContracts();

        motoquero.IdMotoquero = 1;
        motoquero.Descripcion = "Martin";


        DeudorDataContracts deudorSeleccionado = new DeudorDataContracts();

        deudorSeleccionado.IdDeudor = int.Parse(this.cmbDeudores.SelectedItem.Value);
        deudorSeleccionado.Nombre = this.cmbDeudores.SelectedItem.Text;




        ClienteDataContracts clienteSeleccionado = new ClienteDataContracts();

        clienteSeleccionado.IdCliente = int.Parse(this.cmbDeudores.SelectedItem.Value);
        clienteSeleccionado.NOMBRE = this.cmbDeudores.SelectedItem.Text;


        List<FacturaDataContracts> listaDeFacturasSeleccionadas = new List<FacturaDataContracts>();

        FacturaDataContracts factura = new FacturaDataContracts();

        factura.FechaCobro = DateTime.Now;
        factura.FechaIngreso = DateTime.Now;
        factura.IdCliente = 1;
        factura.IdDeudor = 2;
        factura.IdFactura = 1;
        factura.Importe = 160;
        factura.Saldo = 150;
        factura.Moneda = "PESO";
        factura.IdEstadoFactura = 1;
        factura.NumeroComp = 1;
        factura.Observaciones = string.Empty;
        factura.ProximaGestion = DateTime.Now;
        factura.TipoCobro = string.Empty;

        listaDeFacturasSeleccionadas.Add(factura);

        AnalistaDataContracts analista = new AnalistaDataContracts();

        analista.IdAnalista = 1;
        analista.Nombre = "Moira";


        RemisionDataContracts remision = new RemisionDataContracts();


        remision.AnalistaGenerador = analista;
        remision.FechaDeCreacion = DateTime.Now;
        remision.ListaDePagos = listaDePagos;


        List<ReciboDataContracts> listaDeRecibosIngresados = new List<ReciboDataContracts>();

        ReciboDataContracts recibo = new ReciboDataContracts();

        //TODO: revisar...
        //recibo.ListadoDeFacturasACancelar=listaDeFacturasSeleccionadas;
        recibo.Numero = "200";
        recibo.Cliente = clienteSeleccionado;
        //recibo.Deudor=deudorSeleccionado;


        listaDeRecibosIngresados.Add(recibo);

        remision.ListaDeRecibos = listaDeRecibosIngresados;


        remisionServices.Insert(remision);



    }



    protected void GetPostBackControl_OnClick(object sender, EventArgs e)
    {

        int a;
    }


    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {

        string ctrlname = Page.Request.Params["__EVENTTARGET"];

        switch (this.TabContainer1.ActiveTabIndex)
        {
            case 0:
                this.btnAgregarPago.ValidationGroup = "chequeGroup";
                this.btnEditarPago.ValidationGroup = "chequeGroup";
                break;
            case 1:
                this.btnAgregarPago.ValidationGroup = "retencionesGroup";
                this.btnEditarPago.ValidationGroup = "retencionesGroup";

                break;
            case 2:
                this.btnAgregarPago.ValidationGroup = "efectivosGroup";

                this.btnEditarPago.ValidationGroup = "efectivosGroup";
                break;
            case 3:
                this.btnAgregarPago.ValidationGroup = "depositosGroup";
                this.btnEditarPago.ValidationGroup = "depositosGroup";
                break;
            case 4:
                this.btnAgregarPago.ValidationGroup = "transferenciasGroup";
                this.btnEditarPago.ValidationGroup = "transferenciasGroup";

                break;

            case 5:
                this.btnAgregarPago.ValidationGroup = "otrosPagosGroup";
                this.btnEditarPago.ValidationGroup = "otrosPagosGroup";
                break;

            case 6:
                this.btnAgregarPago.ValidationGroup = "descuentosGroup";
                this.btnEditarPago.ValidationGroup = "descuentosGroup";
                break;


        }
    }
    protected void gvResultadosPagos_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

        int a;

    }
    protected void gvResultadosPagos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];

            //Evita resta negativa
            if (txtPagos.Text != "0")
                ActualizarSumaPagos(double.Parse(System.Math.Round((listaDePagosCargados[e.RowIndex].Importe) * -1, 3).ToString()));
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


        if (chkPesificar.Checked)
        {
            fValorAgregar = valor * fCambio;
        }
        else
        {
            fValorAgregar = valor;
        }


        double suma = (double.Parse(this.txtPagos.Text) + fValorAgregar);
        suma = double.Parse(System.Math.Round(suma, 4).ToString());
        this.txtPagos.Text = suma.ToString();
        this.txtPagosExt.Text = (suma / fCambio).ToString();

        this.UpdatePanelTabContainer.Update();
        this.UpdatePanelIndice.Update();

    }
    private void ActualizarSumaPagos()
    {


        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            double sumaTotalDePagos = 0;

            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];

            foreach (PagoDataContracts item in listaDePagosCargados)
            {
                sumaTotalDePagos = sumaTotalDePagos + item.Importe;

            }

            this.txtPagos.Text = System.Math.Round(sumaTotalDePagos, 3).ToString();
            if (this.txtCambio.Text == string.Empty || this.txtCambio.Text == null)
                this.txtCambio.Text = "1,00";
            double sumaext = double.Parse(this.txtPagos.Text) / double.Parse(this.txtCambio.Text);
            this.txtPagosExt.Text = sumaext.ToString();


            this.UpdatePanelTabContainer.Update();
            this.UpdatePanelIndice.Update();

        }




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
                    (CheckBox)item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1];

                Button btnPP = (Button)item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Pronto")].Controls[0];

                checkSeleccion.Attributes.Add("onclick",
                                              "SumarImporte(this,'" + cont.ToString() + "'," +
                                              item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe")].Text.
                                                  Replace(",", ".") + "," +
                                              item.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe PP")].
                                                  Text.Replace(",", ".") + ",'" + btnPP.ClientID + "');");
            }

        }


    }
    protected void gvResultadosPagos_PreRender(object sender, EventArgs e)
    {

        int cont = -1;
        foreach (GridViewRow item in gvResultadosPagos.Rows)
        {
            cont++;
            foreach (TableCell cell in item.Cells)
            {

                cell.Attributes.Add("onclick", "__doPostBack('ctl00$Contentplaceholder1$gvResultadosPagos','Edit$" + cont.ToString() + "');");



            }
        }
    }
    protected void gvResultadosPagos_RowEditing(object sender, GridViewEditEventArgs e)
    {


        gvResultadosPagos.SelectedIndex = e.NewEditIndex;

        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];

            string tipo = listaDePagosCargados[e.NewEditIndex].FormaPago.Descripcion;

            //Horrible esto, hay que corregirlo
            switch (tipo)
            {
                case "CHEQUE":
                    ChequeDataContracts cheque = (ChequeDataContracts)listaDePagosCargados[e.NewEditIndex];

                    this.txtBanco.Text = cheque.Banco;
                    this.txtCheque.Text = cheque.Numero.ToString();
                    this.txtFechaVencimiento.Text = cheque.Vencimiento.ToString();
                    this.txtFechaEmision.Text = cheque.Emision.ToString();
                    this.txtImporte.Text = cheque.Importe.ToString();
                    this.txtSucursal.Text = cheque.Sucursal;
                    break;

                case "DESCUENTO":
                    DescuentoDataContracts descuento = (DescuentoDataContracts)listaDePagosCargados[e.NewEditIndex];
                    this.cmbDescuentos.SelectedIndex = cmbDescuentos.Items.IndexOf(this.cmbDescuentos.Items.FindByValue(descuento.Id.ToString()));

                    this.txtImporteDescuento.Text = descuento.Importe.ToString();

                    break;

            }



        }
        else
        {


        }
        this.btnCancelarEdicion.Visible = true;
        this.btnEditarPago.Visible = true;
        this.btnAgregarPago.Enabled = false;



        Session["ListaDePagos"] = listaDePagosCargados;
        this.UpdatePanelTabContainer.Update();



    }
    protected void btnBuscarFactura_Click(object sender, ImageClickEventArgs e)
    {

        System.Drawing.Color col = System.Drawing.Color.Empty;

        ReCalcularSuma();


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

    }
    protected DataTable GvResultadosFacturas_Filling(object sender, EventArgs e)
    {
        List<FacturaDataContracts> resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetAllFacturasPorIdDeudor(int.Parse(this.cmbDeudores.SelectedItem.Value));

        //AsignarColores(resultadoObtenidos);

        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }
    protected void btnEditarPago_Click(object sender, EventArgs e)
    {
        string tipo = gvResultadosPagos.SelectedRow.Cells[1].Text;



        List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();

        if (Session["ListaDePagos"] != null)
        {
            listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];

            ActualizarSumaPagos(double.Parse(System.Math.Round((listaDePagosCargados[gvResultadosPagos.SelectedIndex].Importe * -1), 3).ToString()));


            listaDePagosCargados.Remove(listaDePagosCargados[gvResultadosPagos.SelectedIndex]);



            switch (tipo)
            {
                //Creo un cheque
                case "CHEQUE":

                    ChequeDataContracts nuevoCheque = new ChequeDataContracts();

                    nuevoCheque.Banco = this.txtBanco.Text;
                    nuevoCheque.Emision = DateTime.Parse(this.txtFechaEmision.Text);
                    nuevoCheque.Vencimiento = DateTime.Parse(this.txtFechaVencimiento.Text);
                    nuevoCheque.Importe = double.Parse(System.Math.Round(double.Parse(this.txtImporte.Text), 3).ToString());
                    nuevoCheque.Sucursal = this.txtSucursal.Text;
                    nuevoCheque.FormaPago = new FormaPagoDataContracts(1, "CHEQUE");
                    nuevoCheque.Numero = long.Parse(this.txtCheque.Text);
                    this.AgregarPago(nuevoCheque);
                    ActualizarSumaPagos();
                    BlanquearPagos(this.TabContainer1.ActiveTabIndex);

                    ActualizarGrillaCargaPagos();

                    break;

                //case "RETENCION":


                //    break;

                //case "EFECTIVO":
                //    break;


                //case "DESCUENTO":

                //    DescuentoDataContracts nuevoDescuento = new DescuentoDataContracts();

                //    nuevoDescuento.Concepto = this.cmbDescuentos.SelectedItem.Text;
                //    //Esta fecha la pongo asi, porque supuestamente no interesa para los descuentos
                //    //cuando es la fecha real del descuento 
                //    nuevoDescuento.FechaPago = DateTime.Now;
                //    nuevoDescuento.FormaPago = new FormaPagoDataContracts(7, "DEPOSITO");
                //    nuevoDescuento.Id = int.Parse(this.cmbDescuentos.SelectedItem.Value);
                //    nuevoDescuento.Importe = double.Parse(this.txtImporteDescuento.Text);
                //    this.AgregarPago(nuevoDescuento);
                //    ActualizarSumaPagos();
                //    BlanquearPagos(this.TabContainer1.ActiveTabIndex);
                //    ActualizarGrillaCargaPagos();
                //    break;

            }

            ActualizarGrillaCargaPagos();


            this.btnCancelarEdicion.Visible = false;
            this.btnEditarPago.Visible = false;
            this.btnAgregarPago.Enabled = true;



        }




    }
    protected void gvResultadosPagos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvResultadosPagos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void btnCancelarEditarPago_Click(object sender, EventArgs e)
    {
        this.btnCancelarEdicion.Visible = false;
        this.btnEditarPago.Visible = false;
        this.btnAgregarPago.Enabled = true;
        this.BlanquearPagos(this.TabContainer1.ActiveTabIndex);



    }
    protected void txtCuitEmisor_PreRender(object sender, EventArgs e)
    {

        if (!this._evitarPrerenderTextBox)
        {
            this.txtCuitEmisor.Attributes.Add("onfocus", "MostrarPanelCheque()");
            //this.txtCuitEmisor.Attributes.Add("onblur", "onBlurTextBox()");

            this.panelLectoraCheque.Attributes.Add("onkeydown", "OcultarPanelCheque()");
        }
        else
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "desactivar", "javascript:DesactivarLectora('20134236397');", true);


        }


    }
    protected void imgBtnLectora_Click(object sender, ImageClickEventArgs e)
    {

        this.txtCuitEmisor.Attributes.Add("onfocus", "MostrarPanelCheque()");
    }
    protected void cmbDeudores_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (this.cmbDeudores.SelectedItem.Value != "0")
        {


            int res = BloquearDeudor_Click(string.Empty, string.Empty);


            if (res == 0) CargarGrillaFacturas(int.Parse(this.cmbDeudores.SelectedItem.Value));

        }
        else
        {
            this.btnNuevaRemisionTemporal.Enabled = false;
        }

        ListItem item = new ListItem();
        item = this.cmbDeudores.SelectedItem;
        this.cmbDeudores.Items.Clear();
        this.cmbDeudores.Items.Add(item);




    }
    protected void cmbDeudores_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmbDeudores_DataBound(object sender, EventArgs e)
    {


        if (this.cmbDeudores.Items.Count > 0)
        {
            this.cmbDeudores.SelectedIndex = 0;



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
        //Para evitar saldos negativos, quitamos todos los tildes de la grilla
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            CheckBox chk = (CheckBox)Fila.FindControl("chk");
            chk.Checked = false;
        }

        if (this.GvResultadosFacturas.Rows.Count > 0)
        {
            this.lblResResultadoCantFacts.Text = this.GvResultadosFacturas.Rows.Count.ToString();
        }

        else
        {
            this.lblResResultadoCantFacts.Text = "0";
        }

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
            {
                suma = suma + double.Parse(((TextBox)dr.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text);
            }
            else
            {
                suma = 0;
            }


        }
        this.txtSumaFacturas.Text = System.Math.Round(suma, 3).ToString();

        if (this.txtCambio.Text == string.Empty || this.txtCambio.Text == null)
            this.txtCambio.Text = "1,00";
        this.txtSumaFacturasExt.Text = (double.Parse(this.txtSumaFacturas.Text) / double.Parse(this.txtCambio.Text)).ToString();

        this.UpdatePanelResultados.Update();

    }
    protected void GvResultadosFacturas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        if (mgr.Contains("deudorSeleccionado"))
            mgr.Remove("deudorSeleccionado");
        if (mgr.Contains("lblClienteSeleccionado"))
            mgr.Remove("lblClienteSeleccionado");
        if (mgr.Contains("lblDeudorSeleccionado"))
            mgr.Remove("lblDeudorSeleccionado");
        if (mgr.Contains("SeleccionGrillaFacturasSeleccionadas"))
            mgr.Remove("SeleccionGrillaFacturasSeleccionadas");

        mgr.Add("deudorSeleccionado", this.cmbDeudores.SelectedValue);
        mgr.Add("lblClienteSeleccionado", this.cmbClientes.SelectedItem.Text);
        mgr.Add("lblDeudorSeleccionado", this.cmbDeudores.SelectedItem.Text);
        List<string> lista = new List<string>();
        lista.Add(GvResultadosFacturas.DataKeys[e.NewEditIndex].Value.ToString());
        mgr.Add("SeleccionGrillaFacturasSeleccionadas", lista);

        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaParaCambiarEstado('http://" + Request.ServerVariables["SERVER_NAME"] + "/Vistas/ViewPopUpHitoFactura.aspx','_blank');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript: window.open('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewPopUpHitoFactura.aspx','_blank','location=no,height=560px,width=540px,scrollbars=yes,resizable=yes');", true);


    }
    protected void txtCuitEmisor2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtCuitEmisor_TextChanged1(object sender, EventArgs e)
    {

        ChequeDataContracts resultadoObtenido = new ChequeDataContracts();
        IChequeService chequeServices = ServiceClient<IChequeService>.GetService("ChequeService");
        resultadoObtenido = chequeServices.GetChequeByCuit(((TextBox)sender).Text);

        if (resultadoObtenido != null)
        {
            this.txtBanco.Text = resultadoObtenido.Banco;
            this.txtSucursal.Text = resultadoObtenido.Sucursal;
            this.txtCuenta.Text = resultadoObtenido.Cuenta;

        }

        this.txtCuenta.Focus();
        this._evitarPrerenderTextBox = true;

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


            //this.txtCuitEmisor.TextChanged+=new EventHandler(txtCuitEmisor_TextChanged1); 
        }
    }
    protected void imgBtnAgregarObservacion_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnGuardarRecibo_Click(object sender, EventArgs e)
    {

        this.Validate("reciboGroup");
        this.btnGuardarRecibo.Enabled = true;
        if (!this.IsValid) { return; }


        ReciboDataContracts nuevoRecibo = new ReciboDataContracts();

        //Antes que nada, aca debo validar que el número de recibo ingresado no exista

        List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");

        nuevoRecibo.Cliente = clienteServices.GetCliente(decimal.Parse(this.cmbClientes.SelectedItem.Value));

        DeudorDataContracts resultadoObtenidos = new DeudorDataContracts();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");

        nuevoRecibo.Deudor = deudorServices.GetDeudor(int.Parse(this.cmbDeudores.SelectedItem.Value));

        nuevoRecibo.Numero = this.txtRecibo.Text;
        nuevoRecibo.SAP = this.txtSAP.Text;

        //No puede haber recibo sin pagos ingresados

        if ((List<PagoDataContracts>)Session["ListaDePagos"] != null)
        {
            nuevoRecibo.ListadoDePagosIngresados = (List<PagoDataContracts>)Session["ListaDePagos"];
        }

        //Con esto tomo todas las facturas seleccionadas

        List<ReciboFacturaDataContracts> listaRecibosFacturas = new List<ReciboFacturaDataContracts>();

        listaRecibosFacturas = ObtenerFacturasSeleccionadas();

        nuevoRecibo.ListadoDeFacturasACancelar = listaRecibosFacturas;


        List<ReciboDataContracts> recibosCargadosPorEnElFront = new List<ReciboDataContracts>();

        if ((List<ReciboDataContracts>)Session["ListaDeRecibosCargados"] != null)
            recibosCargadosPorEnElFront = (List<ReciboDataContracts>)Session["ListaDeRecibosCargados"];

        recibosCargadosPorEnElFront.Add(nuevoRecibo);
        Session["ListaDeRecibosCargados"] = recibosCargadosPorEnElFront;


        //Actualizo la lista del costado

        ListItem nuevoItemListaRecibos = new ListItem(this.cmbClientes.SelectedItem.ToString() + " - " + this.cmbDeudores.SelectedItem.ToString() + " - " + nuevoRecibo.Numero, nuevoRecibo.Numero);

        this.lstRecibosCargados.Items.Add(nuevoItemListaRecibos);


        nuevoRecibo.FechaCarga = DateTime.Parse(this.txtFechaRecibo.Text);


        if (this.lstRecibosCargados.Items.Count > 0)
        {
            this.btnCrearRemision.Enabled = true;
        }

        //Esto es para que actualice el saldo de las facturas seleccionadas
        foreach (ReciboFacturaDataContracts oRecibo in listaRecibosFacturas)
        {
            foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
            {
                CheckBox chk = (CheckBox)Fila.FindControl("chk");
                if (chk.Checked)
                    Fila.Cells[4].Text = String.Format("{0:0.00}", (double.Parse(Fila.Cells[4].Text) - oRecibo.ImporteAImputar));
            }
        }
        ReCalcularSuma();

        InicializarRecibo();
        GuardarRecibo();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "reciboGuardado", "javascript:alert('El recibo fue almacenado exitosamente.');", true);

    }

    private void GuardarRecibo()
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

        //nuevaRemision.Cambio = float.Parse(this.txtCambio.Text);

        //Aca deberi ir todo el proceso de guardar la remision en la base de datos
        //Si la operacion fué exitosa, se debe mostrar el número de remision generado y
        //limpiar toda la pantalla y las variables de sesion


        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");


        remisionServices.Update(nuevaRemision);


    }


    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        //
    }



    protected void VerDetalleCheques(object sender, ImageClickEventArgs e)
    {

        ActualizarGrillaDetalleCheque();
        this.ModalPopupDetalleCheques.Show();
    }
    private List<ReciboFacturaDataContracts> ObtenerFacturasSeleccionadas()
    {

        GridViewRowCollection rows = this.GvResultadosFacturas.Rows;

        List<ReciboFacturaDataContracts> listaRecibosFacturas = new List<ReciboFacturaDataContracts>();


        foreach (GridViewRow row in rows)
        {


            if (((CheckBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked)
            {

                ReciboFacturaDataContracts reciboFactura = new ReciboFacturaDataContracts();

                reciboFactura.IdFactura = int.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "id Factura")].Text);
                reciboFactura.Importe = double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "importe")].Text);
                reciboFactura.ImporteAImputar = double.Parse(((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text);
                reciboFactura.ImporteAImputar = Math.Round(reciboFactura.ImporteAImputar, 4);
                reciboFactura.ImporteProntoPago = "1";//Esto se debe calcular.
                reciboFactura.NumRecibo = this.txtRecibo.Text;
                reciboFactura.Observacion = string.Empty; //La que venga de la grilla
                reciboFactura.Saldo = double.Parse(row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "saldo")].Text);
                reciboFactura.Saldo = Math.Round(reciboFactura.Saldo, 4);
                listaRecibosFacturas.Add(reciboFactura);

            }

        }

        return listaRecibosFacturas;

    }

    private void InicializarRecibo()
    {

        this.txtRecibo.Text = "0000-";
        this.txtCambio.Text = string.Empty;
        this.txtFechaRecibo.Text = DateTime.Now.ToShortDateString();
        Session["ListaDePagos"] = null;
        ActualizarGrillaCargaPagos();
        this.txtPagos.Text = "0";
        this.txtPagosExt.Text = "0";
        this.txtSumaFacturas.Text = "0";
        this.txtSumaFacturasExt.Text = "0";
        //Para evitar saldos negativos, removemos tldes de la grilla
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            CheckBox chk = (CheckBox)Fila.FindControl("chk");
            chk.Checked = false;
        }
        BlanquearTodosLosPagos();
        CargarGrillaFacturas(int.Parse(this.cmbDeudores.SelectedValue));

        this.TabContainer1.ActiveTabIndex = 0;
    }


    private void FiltrarFacturasTemporales(List<FacturaDataContracts> facturasTotalesDelDeudor)
    {
        List<ReciboDataContracts> recibosCargadosTemporalmente = new List<ReciboDataContracts>();

        if ((List<ReciboDataContracts>)Session["ListaDeRecibosCargados"] != null)
            recibosCargadosTemporalmente = (List<ReciboDataContracts>)Session["ListaDeRecibosCargados"];


        foreach (ReciboDataContracts recibo in recibosCargadosTemporalmente)
        {

            List<ReciboFacturaDataContracts> listadoDeFacturasACancelar = recibo.ListadoDeFacturasACancelar;

            foreach (ReciboFacturaDataContracts factura in listadoDeFacturasACancelar)
            {
                //facturasTotalesDelDeudor.RemoveAll(new System.Predicate<FacturaDataContracts>(delegate(FacturaDataContracts fact) { return (fact.IdFactura == factura.IdFactura); }));
                foreach (FacturaDataContracts facturaReal in facturasTotalesDelDeudor)
                {
                    if (factura.IdFactura == facturaReal.IdFactura)
                    {
                        facturaReal.Saldo = Math.Round(factura.Saldo - factura.ImporteAImputar, 4);
                        break;
                    }
                }

            }

        }



    }


    private void ReCalcularSuma()
    {
        double total = 0;
        foreach (GridViewRow row in this.GvResultadosFacturas.Rows)
        {

            if (((CheckBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Seleccionar")].Controls[1]).Checked)
            {
                total = total + double.Parse(((TextBox)row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "A Imputar")].Controls[1]).Text);
            }


        }

        this.txtSumaFacturas.Text = total.ToString();

        if (this.txtCambio.Text == string.Empty || this.txtCambio.Text == null)
            this.txtCambio.Text = "1,00";
        this.txtSumaFacturasExt.Text = (double.Parse(this.txtSumaFacturas.Text) / double.Parse(this.txtCambio.Text)).ToString();
    }


    protected void btnCrearRemision_Click(object sender, EventArgs e)
    {

        //Lo primero que hago aca es validar si se puede o no guardar el recibo en base
        // a los valores cargados y a las facturas seleccionadas.


        RemisionDataContracts oRemision = new RemisionDataContracts();

        AnalistaDataContracts nuevoAnalista = new AnalistaDataContracts();//Tomar de sistema
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
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "remisionSinPagos", "javascript:alert('La remisión n° " + this.lblRemisionEnUso.Text + " ha sido cerrada definitivamente');", true);
        InicializarRemision();




    }

    protected void ddlSubTipo_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void lstRecibosCargados_TextChanged(object sender, EventArgs e)
    {
        this.lstRecibosCargados.ToolTip = this.lstRecibosCargados.SelectedItem.ToString();
    }
    protected void GvResultadosFacturas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        this.GvResultadosFacturas.SelectedIndex = e.NewSelectedIndex;

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        if (mgr.Contains("seleccionItemProntoPago"))
            mgr.Remove("seleccionItemProntoPago");

        mgr.Add("seleccionItemProntoPago", e.NewSelectedIndex);

        List<ProntoPagoDataContracts> listaProntoPago = new List<ProntoPagoDataContracts>();
        IProntoPagoService prontoPagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
        listaProntoPago = prontoPagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(this.cmbClientes.SelectedItem.Value), int.Parse(this.cmbDeudores.SelectedItem.Value));

        foreach (ProntoPagoDataContracts pronto in listaProntoPago)
        {

            pronto.FechaLimiteDescuento = DateTime.Parse(this.GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Vencimiento")].Text).AddDays(-pronto.DiasDeAnticipacion);
        }

        DataTable dt = ConvertDataTable<ProntoPagoDataContracts>.Convert((List<ProntoPagoDataContracts>)listaProntoPago);
        this.gvProntoPago.DataSource = dt;
        this.gvProntoPago.DataBind();

        this.txtImporteActual.Text = this.GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Importe")].Text;
        this.lblVencimientoFactRes.Text = this.GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "vencimiento")].Text;

        this.txtImporteProntoPago.Text = string.Empty;
        this.ModalPopupProntoPago.Show();

        UIUtils.PaintSelectedRow(this.GvResultadosFacturas, "id factura", this.GvResultadosFacturas.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "id Factura")].Text);



    }
    protected void gvProntoPago_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int indexSelect = e.NewSelectedIndex;

        this.gvProntoPago.SelectedIndex = e.NewSelectedIndex;

        this.txtImporteProntoPago.Text = this.txtImporteActual.Text;
        this.txtImporteProntoPago.Text = (double.Parse(this.txtImporteProntoPago.Text) - double.Parse(this.gvProntoPago.SelectedRow.Cells[UIUtils.GetPosCol(this.gvProntoPago, "Porcentaje(%)")].Text) * double.Parse(this.txtImporteActual.Text) / 100).ToString();
        UIUtils.PaintSelectedRow(this.gvProntoPago, "id", (e.NewSelectedIndex + 1).ToString());
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void btnEliminarRecibo_Click(object sender, ImageClickEventArgs e)
    {

        ListItem itemRecibo;

        itemRecibo = this.lstRecibosCargados.SelectedItem;

        if (itemRecibo == null) return;


        List<ReciboDataContracts> recibosCargadosTemporalmente = new List<ReciboDataContracts>();

        if ((List<ReciboDataContracts>)Session["ListaDeRecibosCargados"] != null)
        {
            ((List<ReciboDataContracts>)Session["ListaDeRecibosCargados"]).RemoveAll(new System.Predicate<ReciboDataContracts>(delegate(ReciboDataContracts recibo) { return (recibo.Numero == itemRecibo.Value); }));

            this.lstRecibosCargados.Items.Remove(itemRecibo);

        }


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

        //nuevaRemision.Cambio=float.Parse(this.txtCambio.Text);
        nuevaRemision.Estado = "ABIERTA";
        nuevaRemision.FechaDeCreacion = DateTime.Now;

        int remisionTemporal = remisionServices.InsertCabecera(nuevaRemision);

        this.panelGeneralCuerpoPagina.Enabled = true;
        this.btnRemisionEnUso.Enabled = false;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('La remisión se ha creado con éxito');", true);
        this.btnNuevaRemisionTemporal.Enabled = true;
        this.btnRemisionEnUso.Enabled = false;
        this.lblRemisionEnUso.Text = remisionTemporal.ToString();


        this.btnNuevaRemisionTemporal.CommandArgument = "CERRAR";
        this.btnNuevaRemisionTemporal.Text = "Nueva operación";
        this.TabPanel1.Focus();

    }
    protected void btnRemisionEnUso_Click(object sender, EventArgs e)
    {


        List<RemisionDataContracts> listaRemisiones = new List<RemisionDataContracts>();
        IRemisionService remisionServices = ServiceClient<IRemisionService>.GetService("RemisionService");
        listaRemisiones = remisionServices.GetAllRemisionsBlocked();



        // DataTable dt = ConvertDataTable<ProntoPagoDataContracts>.Convert((List<ProntoPagoDataContracts>)listaProntoPago);

        DataTable dt = ConvertDataTable<RemisionDataContracts>.Convert((List<RemisionDataContracts>)listaRemisiones);
        this.gvResultadosConcurrencia.DataSource = dt;
        this.gvResultadosConcurrencia.DataBind();
        this.panelGeneralCuerpoPagina.Enabled = true;
        this.ModalPopupDetalleControlConcurrencia.Show();



    }

    protected void chkCP_CheckedChanged(object sender, EventArgs e)
    {
        //
    }

    protected void GvResultadosFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "saldo")].Text == "0,0000")
                e.Row.Visible = false;
        }
    }

    private int BloquearDeudor_Click(string nuevoDeudor, string anteriorDeudor)
    {

        string res = string.Empty;

        //Bloqueo del deudor.

        try
        {

            if (this.cmbDeudores.SelectedItem.Value != "0")
            {
                ControlRemisionConcurrenciaDataContracts controlRemision = new ControlRemisionConcurrenciaDataContracts();
                controlRemision.DatoBloqueado = this.cmbDeudores.SelectedItem.Text;
                controlRemision.EstadoLock = Session.SessionID + "/LOCK";
                controlRemision.FechaInicioLock = DateTime.Now;
                controlRemision.FechaForceUnlock = DateTime.Now;
                controlRemision.NumRemision = this.lblRemisionEnUso.Text;
                GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
                controlRemision.UsuarioLock = (principal.Identity.Name);

                IControlRemisionConcurrenciaService controlRemisionServices = ServiceClient<IControlRemisionConcurrenciaService>.GetService("ControlRemisionConcurrenciaService");
                res = controlRemisionServices.InsertWithResult(controlRemision);

                if (res != string.Empty)
                {
                    throw new Exception();

                }

                //Elimino el anterior deudor bloqueado
                if (string.Empty != this.lblSelDeu.Text)
                {
                    controlRemision.DatoBloqueado = this.lblSelDeu.Text;
                    controlRemisionServices.Delete(controlRemision);
                }

                this.btnNuevaRemisionTemporal.Enabled = true;
                this.lblSelDeu.Text = this.cmbDeudores.SelectedItem.ToString();




                return 0;


            }
            else
            {

                this.btnNuevaRemisionTemporal.Enabled = false;
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

        string res = string.Empty;

        //Bloqueo del deudor.

        try
        {
            this.btnNuevaRemisionTemporal.Enabled = false;
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
                {
                    throw new Exception();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('Deudor " + this.cmbDeudores.SelectedItem.Text + " bloqueado con éxito');", true);
                }

                this.btnNuevaRemisionTemporal.Enabled = true;
                this.cmbDeudores.Enabled = false;
                this.cmbClientes.Enabled = false;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('Seleccione un deudor.');", true);


            }
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "nuevaRemision", "javascript:alert('El deudor que esta intentando bloquear, esta siendo utilizado por " + res + ". ');", true);

        }


        //Fin bloqueo deudor



    }
    protected void ibtnDesbloquearDeudor_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnNuevaRemisionTemporal_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument.ToString() == "CREAR")
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "crearNuevaRemision", "javascript:VerificarConfirmacionNuevaRemision();", true);
            this.btnNuevaRemision.Focus();


        }
        else
        {
            //Aca cancelo todo
            this.cmbClientes.Enabled = true;
            this.cmbDeudores.Enabled = true;
            this.btnNuevaRemisionTemporal.Enabled = true;
            this.btnNuevaRemisionTemporal.CommandArgument = "CREAR";
            this.btnNuevaRemisionTemporal.Text = "Crear Remisión";
            this.cmbDeudores.SelectedIndex = 0;




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



        }

    }


    private void InicializarRemision()
    {

        this.txtRecibo.Text = "0000-";
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
        this.cmbClientes.SelectedIndex = 0;
        this.cmbDeudores.Items.Clear();
        this.cmbDeudores.Enabled = false;
        this.btnNuevaRemisionTemporal.Enabled = false;
        this.btnRemisionEnUso.Enabled = true;
        this.lblRemisionEnUso.Text = string.Empty;
        this.lblSelDeu.Text = string.Empty;
        this.cmbClientes.Enabled = true;
        this.updatePanelRemisionEnUso.Update();



    }
    protected void btnRefreshCmbDeudores_Click(object sender, ImageClickEventArgs e)
    {
        List<DeudorDataContracts> resultadoObtenidos = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");


        resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioCliente(int.Parse(this.cmbClientes.SelectedItem.Value));

        DeudorDataContracts seleccion = new DeudorDataContracts();
        seleccion.Nombre = "--- SELECCIONE ---";
        seleccion.IdDeudor = 0;
        resultadoObtenidos.Insert(0, seleccion);

        this.cmbDeudores.Items.Clear();
        this.cmbDeudores.DataSource = resultadoObtenidos;
        this.cmbDeudores.DataTextField = "NOMBRE";
        this.cmbDeudores.DataValueField = "idDeudor";
        this.cmbDeudores.DataBind();
        this.btnNuevaRemisionTemporal.Enabled = false;


    }



    protected void btnCerrarModalRemisionesAbiertas_Click(object sender, EventArgs e)
    {
        this.ModalPopupDetalleControlConcurrencia.Hide();

    }
    protected void gvResultadosConcurrencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idRemision = ((GridView)sender).SelectedDataKey.Value.ToString();
        string idCliente = ((GridView)sender).SelectedRow.Cells[UIUtils.GetPosCol(((GridView)sender), "ID Cliente")].Text;

        // ListItem item=((ListItem)this.cmbClientes.Items.FindByValue(idCliente));
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
        else
        {
            this.btnCrearRemision.Enabled = false;
        }
        cmbClientes_SelectedIndexChanged(sender, null);
        this.cmbClientes.DataBind();
        this.UpdatePanelIndice.Update();
        this.updatePanelRemisionEnUso.Update();

        this.ModalPopupDetalleControlConcurrencia.Hide();



    }
    protected void hdPostbackControl_ValueChanged(object sender, EventArgs e)
    {
        int a;

    }
}
