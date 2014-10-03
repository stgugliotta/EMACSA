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
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using System.Collections.Generic;
using Gobbi.services;
using Herramientas;
using Gobbi.CoreServices.Security.Principal;
using System.Diagnostics;

public partial class Vistas_ViewGestionAnalista : GobbiPage
{

    private bool _evitarPrerenderGrillaFactura = false;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        if (Page.IsPostBack)
        {
            try
            {
                this.btnBuscarDeudor.Focus();
                fillHorariosReclamo();

                fillHorariosCobro();

            }
            catch (Exception ex)
            {
            }
        }

        CargarAgenda();

        actualizarSeleccionGrilla();

        actualizarSeleccionGrillaFacturas();

        if (!Page.IsPostBack)
        {
            ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
            //CargarAgendaDelDia();

            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            string nombre = principal.Identity.Name;
            clientes = clienteServices.GetAllClientesByAnalista(nombre);


            this.cmbClientesAsociados.DataSource = clientes;
            this.cmbClientesAsociados.DataTextField = "NOMBRE";
            this.cmbClientesAsociados.DataValueField = "idCliente";
            this.cmbClientesAsociados.DataBind();

            this.cmbClientesAsociados.Items.Insert(0, "Todas");

            DataTable dataTable = GetDataTableDeudores();
            this.GvResultados.DataSource = dataTable;
            this.GvResultados.DataBind();


            this.btnGestionar.Enabled = false;
            this.anclaPrueba.Visible = false;
            this.btnHistorial.Visible = false;

            this.lblResDeudorSeleccionado.Text = "---";
            this.lblTelefono.Text = "---";
            this.lblDomicilio.Text = "---";
            this.lblLocalidad.Text = "---";
            this.lblProvincia.Text = "---";
            this.lblCuandoReclamar.Text = "---";
            this.lblCuandoCobrar.Text = "---";
            this.lblCUIT.Text = "---";
            this.btnGestionar.Visible = true;
            lblAlfaNumDelCliente.Text = "---";

            lblNombreAnalista.Text = nombre;

            #region horarios


            string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
            string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
            List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
            List<DeudorDiaCobroDataContracts> listaDiasCobro = null;

            listaDiasReclamo = new List<DeudorDiaReclamoDataContracts>();
            listaDiasCobro = new List<DeudorDiaCobroDataContracts>();
            //mgr.Add(listaDiasReclamoKey, listaDiasReclamo);
            Session[listaDiasReclamoKey] = listaDiasReclamo;
            //mgr.Add(listaDiasCobroKey, listaDiasCobro);
            Session[listaDiasCobroKey] = listaDiasCobro;


            List<DiasDataContracts> dias = new List<DiasDataContracts>();
            IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
            dias = diasService.GetAllDiass();

            this.cmbDiasReclamo.DataSource = dias;
            this.cmbDiasReclamo.DataTextField = "Descripcion";
            this.cmbDiasReclamo.DataValueField = "IdDia";
            this.cmbDiasReclamo.DataBind();

            this.cmbDiasCobro.DataSource = dias;
            this.cmbDiasCobro.DataTextField = "Descripcion";
            this.cmbDiasCobro.DataValueField = "IdDia";
            this.cmbDiasCobro.DataBind();

            CargarAgendaDelDia();
            this.txtSumaFacturas.Text = "0";
            #endregion
            limpiarSession();
        }

    }

    private void limpiarSession()
    {
        Session["lblCuandoCobrar"] = null;
    }
    protected void anclaPrueba_Click(object sender, EventArgs e)
    {
        //string pszParametros = "?id_cliente=" + this.cmbClientesAsociados.SelectedItem.Value;
        string pszParametros = "?id_cliente=" + lblIdClienteSeleccionado.Text;
        pszParametros += "&id_deudor=" + GvResultados.SelectedDataKey.Value.ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentanaAjustable('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewMailEstadoCuenta.aspx" + pszParametros + "','_blank',800,500);", true);
    }

    protected void btnHistorial_Click(object sender, EventArgs e)
    {
        string pszParametros = "?id_cliente=" + lblIdClienteSeleccionado.Text;
        pszParametros += "&id_deudor=" + GvResultados.SelectedDataKey.Value.ToString();


        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentana2('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewHistorialFacturasPorDeudor.aspx" + pszParametros + "','viewHistorialFacturas',800,700);", true);
    }



    public int CompararFechas(AgendaDataContracts fecha1, AgendaDataContracts fecha2)
    {


        return fecha1.FechaDeAlerta.CompareTo(fecha2.FechaDeAlerta);


    }




    protected void Visualizar_Click(object sender, EventArgs e)
    {

    }

    private DataTable GetDataTableDeudoresByIdCliente(Int32 idCliente)
    {

        List<DeudorLivianoDataContracts> resultadoObtenido = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");


        //Se hardcodea el analista hasta tener el manejo de la sesion con el analista logueado.
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string nombre = principal.Identity.Name;
        Boolean todos = this.rbTodos.Checked;
        Boolean aVencer = this.rbAVencer.Checked;
        int cantDias = (this.txtCantidadDias.Text == string.Empty ? 0 : Int32.Parse(this.txtCantidadDias.Text));
        Boolean incluyeVencidas = this.chkIncluirVencidas.Checked;
        Boolean validarFechaReclamo = this.chkFechaReclamo.Checked;
        DateTime filtroFechaReclamo;

        //resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioAnalista(nombre);

        if (this.rbFiltroFechaReclamo.Checked == true)
        {

            if (!string.IsNullOrEmpty(this.txtFechaDesde.Text))
            {
                validarFechaReclamo = false;
                filtroFechaReclamo = DateTime.Parse(this.txtFechaDesde.Text);
                this.chkFechaReclamo.Checked = false;
                resultadoObtenido = deudorServices.GetAllDeudorsLivianoGestionAnalistaConFiltroFechaReclamo(nombre, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, false, filtroFechaReclamo);

            }
            else
            {
                resultadoObtenido = deudorServices.GetAllDeudorsLivianoGestionAnalista(nombre, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, false);
            }
        }
        else
            resultadoObtenido = deudorServices.GetAllDeudorsLivianoGestionAnalista(nombre, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, false);

        return ConvertDataTable<DeudorLivianoDataContracts>.Convert(resultadoObtenido);

    }

    private DataTable GetDataTableDeudores()
    {


        List<DeudorLivianoDataContracts> resultadoObtenidos = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");


        //Se hardcodea el analista hasta tener el manejo de la sesion con el analista logueado.
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string nombre = principal.Identity.Name;
        Boolean todos = this.rbTodos.Checked;
        Boolean aVencer = this.rbAVencer.Checked;
        int cantDias = (this.txtCantidadDias.Text == string.Empty ? 0 : Int32.Parse(this.txtCantidadDias.Text));
        Boolean incluyeVencidas = this.chkIncluirVencidas.Checked;
        Boolean validarFechaReclamo = this.chkFechaReclamo.Checked;

        //resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioAnalista(nombre);
        resultadoObtenidos = deudorServices.GetAllDeudorsLivianoGestionAnalista(nombre, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, -1, false);

        return ConvertDataTable<DeudorLivianoDataContracts>.Convert(resultadoObtenidos);
        //List<DeudorDataContracts> deudoresFiltrados = applyDeudoresList(resultadoObtenidos);
        //return ConvertDataTable<DeudorDataContracts>.Convert(deudoresFiltrados);
    }

    private List<DeudorDataContracts> applyDeudoresList(List<DeudorDataContracts> deudores)
    {

        Boolean todos = this.rbTodos.Checked;
        Boolean aVencer = this.rbAVencer.Checked;
        int cantDias = (this.txtCantidadDias.Text == string.Empty ? 0 : Int32.Parse(this.txtCantidadDias.Text));
        Boolean incluyeVencidas = this.chkIncluirVencidas.Checked;
        Boolean ValidarFechaReclamo = this.chkFechaReclamo.Checked;

        List<DeudorDataContracts> deudoresFiltrados = new List<DeudorDataContracts>();

        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        List<FacturaDataContracts> facturas = null;

        DeudorDataContracts[] aDeudores = deudores.ToArray();
        for (int i = 0; i < aDeudores.Count(); i++)
        {
            DeudorDataContracts deudorDC = aDeudores[i];

            facturas = facturaServices.GetAllFacturasPorIdDeudor(deudorDC.IdDeudor);

            FacturaDataContracts[] aFacturas = facturas.ToArray();
            for (int f = 0; f < aFacturas.Count(); f++)
            {

                FacturaDataContracts factura = aFacturas[f];

                if (factura.FechaVenc.Date < DateTime.Today && incluyeVencidas.Equals(true))
                {
                    deudoresFiltrados.Add(deudorDC);
                    break;
                }
                else if (Math.Abs((factura.FechaVenc.Date.Subtract(DateTime.Today)).Days) < cantDias && aVencer.Equals(true))
                {
                    deudoresFiltrados.Add(deudorDC);
                    break;

                }
                else if (todos.Equals(true))
                {
                    deudoresFiltrados.Add(deudorDC);
                    break;
                }
            }
        }
        if (ValidarFechaReclamo == true)
        {
            List<DeudorDataContracts> deudoresValidados = AplicarValidarFechaReclamo(deudoresFiltrados);
            return deudoresValidados;
        }
        else
            return deudoresFiltrados;
    }

    private List<DeudorDataContracts> AplicarValidarFechaReclamo(List<DeudorDataContracts> deudores)
    {
        List<DeudorDataContracts> NuevosDeudores = new List<DeudorDataContracts>();
        DeudorDataContracts[] aDeudores = deudores.ToArray();
        for (int i = 0; i < aDeudores.Count(); i++)
        {
            DeudorDataContracts deudorDC = aDeudores[i];
            List<DeudorDiaReclamoDataContracts> DeudorDiaReclamos = new List<DeudorDiaReclamoDataContracts>();
            IDeudorDiaReclamoService DeudorDiaReclamoServices = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
            DeudorDiaReclamos = DeudorDiaReclamoServices.GetAllDeudorDiaReclamo(deudorDC.IdDeudor);
            foreach (DeudorDiaReclamoDataContracts ddr in DeudorDiaReclamos)
            {
                if (ddr.IdDia == Convert.ToInt32(DateTime.Today.DayOfWeek))
                {
                    NuevosDeudores.Add(deudorDC);
                    break;
                }
            }
        }

        return NuevosDeudores;
    }

    private List<DeudorDataContracts> AplicarFiltrarPorFechaReclamo(List<DeudorDataContracts> deudores)
    {
        List<DeudorDataContracts> NuevosDeudores = new List<DeudorDataContracts>();
        DeudorDataContracts[] aDeudores = deudores.ToArray();
        for (int i = 0; i < aDeudores.Count(); i++)
        {
            DeudorDataContracts deudorDC = aDeudores[i];
            List<DeudorDiaReclamoDataContracts> DeudorDiaReclamos = new List<DeudorDiaReclamoDataContracts>();
            IDeudorDiaReclamoService DeudorDiaReclamoServices = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
            DeudorDiaReclamos = DeudorDiaReclamoServices.GetAllDeudorDiaReclamo(deudorDC.IdDeudor);
            foreach (DeudorDiaReclamoDataContracts ddr in DeudorDiaReclamos)
            {
                //if (ddr.IdDia == Convert.ToInt32( DateTime.Today.DayOfWeek))
                if (ddr.IdDia == Convert.ToInt32(DateTime.Parse(this.txtFechaDesde.Text).DayOfWeek))
                {
                    NuevosDeudores.Add(deudorDC);
                    break;
                }
            }
        }

        return NuevosDeudores;
    }

    private DataTable GetDataTableDeudoresByClienteYAnalista(int idCliente, string analista)
    {
        List<DeudorDataContracts> resultadoObtenidos = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");


        //Se hardcodea el analista hasta tener el manejo de la sesion con el analista logueado.
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string nombre = principal.Identity.Name;
        resultadoObtenidos = deudorServices.GetAllDeudorsByClienteYAnalista(idCliente, nombre);
        //Deudores - Proxima Gestion:
        List<DeudorDataContracts> deudoresFiltrados = new List<DeudorDataContracts>();

        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        List<FacturaDataContracts> facturas = null;

        DeudorDataContracts[] aDeudores = resultadoObtenidos.ToArray();
        for (int i = 0; i < aDeudores.Count(); i++)
        {
            DeudorDataContracts deudorDC = aDeudores[i];

            facturas = facturaServices.GetAllFacturasPorIdDeudor(deudorDC.IdDeudor);

            FacturaDataContracts[] aFacturas = facturas.ToArray();
            for (int f = 0; f < aFacturas.Count(); f++)
            {

                FacturaDataContracts factura = aFacturas[f];

                if (factura.ProximaGestion.Date != null && factura.ProximaGestion.Date <= DateTime.Today)
                {
                    deudoresFiltrados.Add(deudorDC);
                    break;
                }
                else
                    if (f == aFacturas.Count() - 1) //todas las facturas del deudor tienen "null" como proxima gestion
                    {
                        if (factura.ProximaGestion.Date == null)
                            deudoresFiltrados.Add(deudorDC);
                    }
            }

        }
        if (chkFechaReclamo.Checked == true)
        {
            List<DeudorDataContracts> deudoresValidados = AplicarValidarFechaReclamo(deudoresFiltrados);
            return ConvertDataTable<DeudorDataContracts>.Convert(deudoresValidados);
        }
        else
            return ConvertDataTable<DeudorDataContracts>.Convert(deudoresFiltrados);
    }

    private List<DeudorDataContracts> GetDeudoresByClienteYAnalista(int idCliente, string analista)
    {


        List<DeudorDataContracts> resultadoObtenidos = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");


        //Se hardcodea el analista hasta tener el manejo de la sesion con el analista logueado.
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string nombre = principal.Identity.Name;
        resultadoObtenidos = deudorServices.GetAllDeudorsByClienteYAnalista(idCliente, nombre);
        //Deudores - Proxima Gestion:
        List<DeudorDataContracts> deudoresFiltrados = new List<DeudorDataContracts>();

        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        List<FacturaDataContracts> facturas = null;

        DeudorDataContracts[] aDeudores = resultadoObtenidos.ToArray();
        for (int i = 0; i < aDeudores.Count(); i++)
        {
            DeudorDataContracts deudorDC = aDeudores[i];

            facturas = facturaServices.GetAllFacturasPorIdDeudor(deudorDC.IdDeudor);

            FacturaDataContracts[] aFacturas = facturas.ToArray();
            for (int f = 0; f < aFacturas.Count(); f++)
            {

                FacturaDataContracts factura = aFacturas[f];

                if (factura.ProximaGestion.Date != null && factura.ProximaGestion.Date <= DateTime.Today)
                {
                    deudoresFiltrados.Add(deudorDC);
                    break;
                }
                else
                    if (f == aFacturas.Count() - 1) //todas las facturas del deudor tienen "null" como proxima gestion
                    {
                        if (factura.ProximaGestion.Date == null)
                            deudoresFiltrados.Add(deudorDC);
                    }
            }

        }

        return deudoresFiltrados;
    }


    private DataTable GetDataTableFacturasPorDeudor(int idDeudor)
    {
        List<FacturaDataContracts> resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetAllFacturasPorIdDeudor(idDeudor)
                                .Where(x => x.IdEstadoFactura != 6).ToList();

        //AsignarColores(resultadoObtenidos);
        return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
    }

    protected DataTable GvResultados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {

            if (this.cmbClientesAsociados.SelectedValue != "Todas")
            {

                GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
                string nombre = principal.Identity.Name;
                dataTable = GetDataTableDeudoresByIdCliente(int.Parse(this.cmbClientesAsociados.SelectedItem.Value));
                //dataTable = GetDataTableDeudoresByClienteYAnalista(int.Parse(this.cmbClientesAsociados.SelectedItem.Value), nombre);

            }
            else
            {

                dataTable = this.GetDataTableDeudores();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        // this.GvResultados.Columns[0].Visible = false;

        return dataTable;
    }

    private void actualizarSeleccionGrilla()
    {

    }

    private void actualizarSeleccionGrillaFacturas()
    {
        List<string> lista = new List<string>();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");


        //        if (mgr.Contains(Session.SessionID + "SeleccionGrillaFacturas"))
        //            lista = (List<string>)mgr.GetData(Session.SessionID + "SeleccionGrillaFacturas");
        if (Session["SeleccionGrillaFacturas"] != null)
            lista = (List<string>)Session["SeleccionGrillaFacturas"];


        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultadosFacturas.Rows)
        {
            string key = dr.Cells[1].Text;
            if (((CheckBox)dr.Cells[0].Controls[1]).Checked)
            {
                if (lista.Find(delegate(string dk) { return dk.Equals(key); }) == null)
                {
                    lista.Add(key);
                }
            }
            else
            {
                if (lista.Find(delegate(string dk) { return dk.Equals(key); }) != null)
                {
                    lista.Remove(key);
                }
            }
        }

        //mgr.Add(Session.SessionID + "SeleccionGrillaFacturas", lista);
        Session["SeleccionGrillaFacturas"] = lista;

    }
    protected void Exportar_Click(object sender, EventArgs e)
    {
    }

    protected void GvResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.txtSumaFacturas.Text = "0";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "cerrarPopups", "javascript:CerrarTodosLosPopups();", true);
        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
        Session[listaDiasReclamoKey] = null;
        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        Session[listaDiasCobroKey] = null;

        //this.RadioButtonList1.Visible = false;
        this.btnGestionar.Enabled = false;
        this.anclaPrueba.Visible = false;
        this.btnHistorial.Visible = false;
        this.Panel1.Enabled = true;

        GvResultados_SelectedIndexChanged(sender, e);
        // Colorear:

        if (Session["FilaColorAnterior"] != null)
        {
            foreach (GridViewRow Fila in GvResultados.Rows)
            {
                if (Fila.BackColor == System.Drawing.Color.Aqua)
                {
                    Fila.BackColor = (System.Drawing.Color)Session["FilaColorAnterior"];
                }
            }
        }

        Session["FilaColorAnterior"] = GvResultados.Rows[e.NewEditIndex].BackColor;
        GvResultados.Rows[e.NewEditIndex].BackColor = System.Drawing.Color.Aqua;

        DataTable dataTable2 = GetDataTableFacturasPorDeudor(int.Parse(GvResultados.Rows[e.NewEditIndex].Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text));
        this.lblResIdentificarDeudor.Text = "(" + GvResultados.Rows[e.NewEditIndex].Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text + ")";

        this.GvResultadosFacturas.DataSource = dataTable2;
        this.GvResultadosFacturas.DataBind();
        this.UpdatePanelGrillaFacturas.Update();

        this.lblResDeudorSeleccionado.Text = GvResultados.Rows[e.NewEditIndex].Cells[UIUtils.GetPosCol(this.GvResultados, "Nombre")].Text;
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        DeudorDataContracts deudorDC = deudorServices.Load(Int32.Parse(GvResultados.Rows[e.NewEditIndex].Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text));

        //DomicilioDeudorDataContracts domiciliodeudorDC = new DomicilioDeudorDataContracts();
        //IDomicilioDeudorService domiciliodeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
        //domiciliodeudorDC = domiciliodeudorService.GetDomicilioDeudor(deudorDC.IdDeudor);

        DeudorDataContracts deudorDCConDireccion = deudorServices.GetDeudorConDireccionCompleta(deudorDC.IdDeudor);

        this.lblTelefono.Text = deudorDC.Telefono;
        if (this.lblTelefono.Text == null || this.lblTelefono.Text.Equals(string.Empty))
        {
            this.lblTelefono.Text = "(No tiene cargado)";
        }
        if (deudorDC.Fax != null && !deudorDC.Fax.Equals(string.Empty))
        {
            this.lblTelefono.Text += " / " + deudorDC.Fax;
        }
        //this.lblDomicilio.Text = deudorDC.Domicilio;
        //this.lblLocalidad.Text = deudorDC.Localidad;

        try
        {
            this.lblDomicilio.Text = deudorDCConDireccion.Domicilio;
        }
        catch (Exception)
        {

            this.lblDomicilio.Text = string.Empty;
        }

        try
        {
            this.lblLocalidad.Text = deudorDCConDireccion.Localidad;
        }
        catch (Exception)
        {

            this.lblLocalidad.Text = string.Empty;
        }

        if (deudorDC.Cp != null && !deudorDC.Cp.Equals(string.Empty))
        {

            this.lblLocalidad.Text += "(" + deudorDC.Cp + ")";
        }
        this.lblProvincia.Text = deudorDC.Provincia;

        Session["lblDireccionDeudor"] = this.lblDomicilio.Text + " - " + this.lblLocalidad.Text + " - " + this.lblProvincia.Text;

        List<DeudorDiaReclamoDataContracts> deudordiareclamo = new List<DeudorDiaReclamoDataContracts>();
        IDeudorDiaReclamoService deudordiaReclamoServices = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
        deudordiareclamo = deudordiaReclamoServices.GetAllDeudorDiaReclamo(deudorDC.IdDeudor);
        this.lblCuandoReclamar.Text = string.Empty;
        this.hdFecha_Reclamo.Value = string.Empty;
        foreach (DeudorDiaReclamoDataContracts ddr in deudordiareclamo)
        {
            DiasDataContracts dia = new DiasDataContracts();
            IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
            dia = diasService.GetDias(ddr.IdDia);

            this.lblCuandoReclamar.Text += dia.Descripcion + " - " + ddr.HorarioDesde + " - " + ddr.HorarioHasta + "<br />";
            this.hdFecha_Reclamo.Value += ddr.IdDia + " - ";
        }

        List<DeudorDiaCobroDataContracts> deudordiacobro = new List<DeudorDiaCobroDataContracts>();
        IDeudorDiaCobroService deudordiacobroServices = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
        deudordiacobro = deudordiacobroServices.GetAllDeudorDiaCobrosPorIdDeudor(deudorDC.IdDeudor);
        this.lblCuandoCobrar.Text = string.Empty;
        foreach (DeudorDiaCobroDataContracts ddc in deudordiacobro)
        {
            DiasDataContracts dia = new DiasDataContracts();
            IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
            dia = diasService.GetDias(ddc.IdDia);

            this.lblCuandoCobrar.Text += dia.Descripcion + " - " + ddc.HorarioDesde + " - " + ddc.HorarioHasta + "<br />";

        }

        this.lblCUIT.Text = deudorDC.Cuit;

        if (deudorDC.Email == null || deudorDC.Email.Trim().Equals(string.Empty) || deudorDC.Email.Contains("nbsp"))
        {
            //this.lnkEmail.Text = "(No tiene cargado)";
            //lnkEmail.NavigateUrl = string.Empty;
        }
        else
        {

            for (int i = 0; i < deudorDC.Email.Split(';').Length; i++)
            {

                HyperLink hl = new HyperLink();
                hl.Text = deudorDC.Email.Split(';')[i];

                hl.NavigateUrl = "mailto:" + hl.Text; //+ "&subject=Informe " + this.lblResDeudorSeleccionado.Text;

                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                tc.Controls.Add(hl);
                tr.Cells.Add(tc);

                tblEmails.Rows.Add(tr);
            }
        }

        lblAlfaNumDelCliente.Text = deudorDC.AlfaNumDelCliente;
        if (this.lblAlfaNumDelCliente.Text == null || this.lblAlfaNumDelCliente.Text.Equals(string.Empty))
        {
            this.lblAlfaNumDelCliente.Text = "(No tiene cargado)";
        }

        if (dataTable2.Rows.Count > 0)
        {

            this.btnGestionar.Enabled = false;
            this.btnGestionar.Visible = true;
            this.anclaPrueba.Visible = true;
            this.GvResultadosFacturas.Enabled = true;
            this.btnHistorial.Visible = true;
        }


        ClienteDataContracts cliente = new ClienteDataContracts();
        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
        cliente = clienteServices.GetClientePorDeudor(int.Parse(GvResultados.Rows[e.NewEditIndex].Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text));
        this.lblClienteSeleccionado.Text = string.Empty;
        if (cliente != null)
        {
            this.lblClienteSeleccionado.Text = cliente.NOMBRE;
            this.lblIdClienteSeleccionado.Text = cliente.IdCliente.ToString();
            this.lblClienteDelDeudorRes.Text = cliente.NOMBRE;

        }
        if (Session["deudorSeleccionado"] != null && Session["deudorSeleccionado"].ToString() != string.Empty)
            Session["deudorSeleccionado"] = null;

        Session["deudorSeleccionado"] = GvResultados.Rows[e.NewEditIndex].Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text;
        Session["clienteSeleccionado"] = cliente.IdCliente;
        this.UpdatePanelDatosDeudor.Update();


        if (cliente != null)
        {

            List<ProntoPagoDataContracts> listaProntoPago = new List<ProntoPagoDataContracts>();
            IProntoPagoService prontoPagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
            listaProntoPago = prontoPagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(cliente.IdCliente.ToString()), int.Parse(GvResultados.Rows[e.NewEditIndex].Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text));

            if (listaProntoPago.Count == 0)
                this.GvResultadosFacturas.Columns[UIUtils.GetPosCol(this.GvResultadosFacturas, "Pronto")].Visible = false;
            else
                this.GvResultadosFacturas.Columns[UIUtils.GetPosCol(this.GvResultadosFacturas, "Pronto")].Visible = true;
        }


        Session["idDeudorSeleccionado"] = int.Parse(GvResultados.Rows[e.NewEditIndex].Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text);

    }


    #region horarios
    private void initializeHorariosReclamoDeudor()
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int idDeudor = Int32.Parse(Session["deudorSeleccionado"].ToString());

        IDeudorDiaReclamoService deudorDiaReclamoService = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
        List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;

        //if (mgr.Contains(listaDiasReclamoKey))
        if (Session[listaDiasReclamoKey] != null)
        {
            //listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)mgr.GetData(listaDiasReclamoKey);
            listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)Session[listaDiasReclamoKey];

            foreach (DeudorDiaReclamoDataContracts ddrDTO in listaDiasReclamo)
            {
                if (ddrDTO.IdDiaReclamo == -1)
                {
                    ddrDTO.IdDeudor = idDeudor;
                    deudorDiaReclamoService.Insert(ddrDTO);
                }
            }
        }
        if (listaDiasReclamo != null)
        {
            listaDiasReclamo.Clear();
        }
        fillTableHorariosReclamo(listaDiasReclamo);
    }

    private void initializeHorariosCobroDeudor()
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int idDeudor = Int32.Parse(Session["deudorSeleccionado"].ToString());

        IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
        //if (mgr.Contains(listaDiasCobroKey))
        if (Session[listaDiasCobroKey] != null)
        {
            //listaDiasCobro = (List<DeudorDiaCobroDataContracts>)mgr.GetData(listaDiasCobroKey);
            listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];

            foreach (DeudorDiaCobroDataContracts ddcDTO in listaDiasCobro)
            {
                if (ddcDTO.IdDiaCobro == -1)
                {
                    ddcDTO.IdDeudor = idDeudor;
                    deudorDiaCobroService.Insert(ddcDTO);
                }
            }
        }
        listaDiasCobro.Clear();
        fillTableHorariosCobro(listaDiasCobro);



    }
    #endregion
    protected void GvResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GvResultados.PageIndex = e.NewPageIndex;
        this.GvResultados.Fill();

    }

    private bool BuscarEnTodasLasPaginas()
    {
        foreach (GridViewRow item in this.GvResultados.Rows)
        {

            item.Font.Bold = true;
            item.Font.Italic = false;
            item.Font.Underline = false;

        }

        for (int i = 0; i < this.GvResultados.PageCount; i++)
        {
            this.GvResultados.PageIndex = i;
            this.GvResultados.Fill();
            System.Drawing.Color col = System.Drawing.Color.Empty;
            foreach (GridViewRow item in this.GvResultados.Rows)
            {
                if (this.txtFindDeudor.Text.Trim().Length > 0 && item.Cells[UIUtils.GetPosCol(this.GvResultados, "Nombre")].Text.ToLower().Contains(this.txtFindDeudor.Text.ToLower()))
                {
                    item.Font.Bold = false;
                    item.Font.Italic = true;
                    item.BackColor = System.Drawing.Color.Aqua;
                    item.Font.Underline = true;
                    return true;

                }

            }


        }
        return false;
    }

    private bool BuscarEnTodasLasPaginasPorIdDeudor()
    {
        foreach (GridViewRow item in this.GvResultados.Rows)
        {

            item.Font.Bold = true;
            item.Font.Italic = false;
            item.Font.Underline = false;

        }

        for (int i = 0; i < this.GvResultados.PageCount; i++)
        {
            this.GvResultados.PageIndex = i;
            this.GvResultados.Fill();
            System.Drawing.Color col = System.Drawing.Color.Empty;
            foreach (GridViewRow item in this.GvResultados.Rows)
            {
                if (this.txtFindIdDeudor.Text.Trim().Length > 0 && item.Cells[UIUtils.GetPosCol(this.GvResultados, "AlfaNum")].Text.ToLower().Contains(this.txtFindIdDeudor.Text.ToLower()))
                {
                    item.Font.Bold = false;
                    item.Font.Italic = true;
                    item.Font.Underline = true;
                    return true;

                }

            }


        }
        return false;
    }




    protected void GvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Dado que eliminar los botones de la lupa, el de eliminar y el de detalles acarrea mas inconvenientes
        // que soluciones, dejan de estar visibles.        

        List<string> lista = new List<string>();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        //        if (mgr.Contains(Session.SessionID + "SeleccionGrilla"))
        //            lista = (List<string>)mgr.GetData(Session.SessionID + "SeleccionGrilla");


        if (Session["SeleccionGrilla"] != null)
            lista = (List<string>)Session["SeleccionGrilla"];

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string key = e.Row.Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text;

            try
            {
                if (lista.Find(delegate(string dk) { return dk.Equals(key); }) != null)
                {
                    ((CheckBox)e.Row.Cells[0].Controls[1]).Checked = true;
                }
            }
            catch (Exception)
            {
            }
            // GFSB 
            IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
            List<FacturaDataContracts> facturas = facturaServices.GetAllFacturasPorIdDeudor(Int32.Parse(key))
                                                    .Where(x => x.IdEstadoFactura != 6).ToList();

            FacturaDataContracts[] aFacturas = facturas.ToArray();
            Boolean rojo = false;
            Boolean amarillo = false;
            Boolean verde = false;
            for (int f = 0; f < aFacturas.Count(); f++)
            {

                FacturaDataContracts factura = aFacturas[f];
                if (factura.IdEstadoFactura == 6)
                {
                    e.Row.BackColor = System.Drawing.Color.Black;
                    e.Row.Cells[1].BackColor = System.Drawing.Color.White;
                    e.Row.ForeColor = System.Drawing.Color.Black;
                    e.Row.Font.Bold = true;
                    e.Row.BorderStyle = BorderStyle.Solid;
                    e.Row.BorderColor = System.Drawing.Color.Gray;
                }
                else
                {
                    if (factura.FechaVenc.Date < DateTime.Today)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.White;
                        e.Row.ForeColor = System.Drawing.Color.Black;
                        e.Row.Font.Bold = true;
                        e.Row.BorderStyle = BorderStyle.Solid;
                        e.Row.BorderColor = System.Drawing.Color.Gray;

                        rojo = true;
                        break;

                    }
                    else if ((Math.Abs((factura.FechaVenc.Date.Subtract(DateTime.Today)).Days)) < 7 && !rojo)
                    {
                        // e.Row.BackColor = System.Drawing.Color.FromArgb(255, 247, 0);
                        e.Row.BackColor = System.Drawing.Color.FromArgb(255, 185, 15);
                        e.Row.Cells[1].BackColor = System.Drawing.Color.White;
                        e.Row.ForeColor = System.Drawing.Color.Black;
                        e.Row.Font.Bold = true;
                        e.Row.BorderStyle = BorderStyle.Solid;
                        e.Row.BorderColor = System.Drawing.Color.Gray;
                        amarillo = true;
                        break;

                    }
                    else if (!amarillo && !rojo)
                    {

                        e.Row.BackColor = System.Drawing.Color.FromArgb(32, 232, 66);
                        e.Row.Cells[1].BackColor = System.Drawing.Color.White;
                        e.Row.ForeColor = System.Drawing.Color.Black;
                        e.Row.BorderColor = System.Drawing.Color.Gray;
                        e.Row.BorderStyle = BorderStyle.Solid;
                        e.Row.Font.Bold = true;


                    }
                }
            }

        }
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultados.Rows)
        {
            ((CheckBox)dr.Cells[0].Controls[1]).Checked = ((CheckBox)sender).Checked;
        }

    }

    protected void chkAll_CheckedChangedFacturas(object sender, EventArgs e)
    {
        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultadosFacturas.Rows)
        {
            ((CheckBox)dr.Cells[0].Controls[1]).Checked = btnGestionar.Enabled = ((CheckBox)sender).Checked;
        }

    }

    protected void GvResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


    }

    protected void GvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            ClienteDataContracts client = new ClienteDataContracts();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            client = clienteServices.GetClientePorDeudor(decimal.Parse(this.GvResultados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text));

        }

    }
    protected void GvResultados_Exporting(object sender, EventArgs e)
    {


        List<string> listaSeleccionados = new List<string>();
        DataTable dt = new DataTable();

        List<string> lista = new List<string>();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        DataTable dataTable = GvResultados_Filling(null, null);

        //if (mgr.Contains(Session.SessionID + "SeleccionGrilla"))
        //    lista = (List<string>)mgr.GetData(Session.SessionID + "SeleccionGrilla");
        if (Session["SeleccionGrilla"] != null)
            lista = (List<string>)Session["SeleccionGrilla"];



        DataColumn column0 = new DataColumn("idDeudor");
        column0.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column0);

        DataColumn column1 = new DataColumn("nombre");
        column1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column1);
        DataColumn column2 = new DataColumn("cuit");
        column2.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column2);
        DataColumn column3 = new DataColumn("domicilio");
        column3.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column3);
        DataColumn column4 = new DataColumn("localidad");
        column4.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column4);
        DataColumn column5 = new DataColumn("provincia");
        column5.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column5);


        foreach (string dataKey in lista)
        {
            if (dataTable.Select("idDeudor = '" + dataKey + "'").Length > 0)
            {

                foreach (DataRow dr in dataTable.Select("idDeudor =  '" + dataKey + "'"))
                {
                    dt.ImportRow(dr);
                    listaSeleccionados.Add(int.Parse(dr["idDeudor"].ToString()).ToString());
                }
            }
        }

        mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        if (Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] != null)
        {
            //mgr.Remove(Constants.CACHE_DOCUMENTOS_A_EXPORTAR);
            Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] = null;
        }
        //mgr.Add(Constants.CACHE_DOCUMENTOS_A_EXPORTAR, dt);
        Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] = dt;

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaPequenia('ViewExportToExcel.aspx','_blank');", true);
        this.StartupScriptKey++;

    }
    protected void GvResultadosFacturas_Exporting(object sender, EventArgs e)
    {


        List<string> listaSeleccionados = new List<string>();
        DataTable dt = new DataTable();

        List<string> lista = new List<string>();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        DataTable dataTable = GvResultadosFacturas_Filling(null, null);

        //        if (mgr.Contains(Session.SessionID + "SeleccionGrillaFacturas"))
        //            lista = (List<string>)mgr.GetData(Session.SessionID + "SeleccionGrillaFacturas");
        if (Session["SeleccionGrillaFacturas"] != null)
            lista = (List<string>)Session["SeleccionGrillaFacturas"];



        DataColumn column0 = new DataColumn("idFactura");
        column0.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column0);

        DataColumn column1 = new DataColumn("fechaVenc");
        column1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column1);
        DataColumn column2 = new DataColumn("saldo");
        column2.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column2);
        DataColumn column3 = new DataColumn("importe");
        column3.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column3);


        foreach (string dataKey in lista)
        {
            if (dataTable.Select("idFactura = '" + dataKey + "'").Length > 0)
            {

                foreach (DataRow dr in dataTable.Select("idFactura =  '" + dataKey + "'"))
                {
                    dt.ImportRow(dr);
                    listaSeleccionados.Add(int.Parse(dr["idFactura"].ToString()).ToString());
                }
            }
        }

        mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        //if (mgr.Contains(Constants.CACHE_DOCUMENTOS_A_EXPORTAR))
        if (Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] != null)
        {
            // mgr.Remove(Constants.CACHE_DOCUMENTOS_A_EXPORTAR);
            Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] = null;
        }
        //mgr.Add(Constants.CACHE_DOCUMENTOS_A_EXPORTAR, dt);
        Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] = dt;

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaPequenia('ViewExportToExcel.aspx','_blank');", true);
        this.StartupScriptKey++;

    }

    protected void Hola2(object sender, EventArgs e)
    {

    }

    protected void GvResultadosFacturas_RowEditing(object sender, GridViewEditEventArgs e)
    {

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentana('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewPopUpHitoFactura.aspx','_blank');", true);

    }

    protected void GvResultadosFacturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GvResultadosFacturas.PageIndex = e.NewPageIndex;
        this.GvResultadosFacturas.Fill();
    }

    protected void GvResultadosFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex != -1)
        {
            string estado = e.Row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Estado")].Text;
            if (estado != null && estado.ToUpper().StartsWith("BAJA"))
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Black;
                e.Row.ForeColor = System.Drawing.Color.Black;
                e.Row.Font.Bold = true;
            }
            else
            {
                //DateTime fechaDelItem = DateTime.Parse(e.Row.Cells[3].Text);
                DateTime fechaDelItem = DateTime.Parse(e.Row.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "Vencimiento")].Text);
                if (fechaDelItem.Date < DateTime.Today)
                {
                    //e.Row.BackColor = System.Drawing.Color.FromArgb(247, 23, 23);
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.Black;
                    e.Row.Font.Bold = true;

                }
                else if ((fechaDelItem.Date.Subtract(DateTime.Today)).Days < 7)
                {
                    //listadoFacturasAVencer.Add(factura);
                    e.Row.Cells[0].BackColor = System.Drawing.Color.FromArgb(255, 185, 15);
                    //e.Row.BackColor = System.Drawing.Color.FromArgb(255, 215, 0); ;
                    e.Row.ForeColor = System.Drawing.Color.Black;
                    e.Row.Font.Bold = true;
                }
                else
                {

                    e.Row.Cells[0].BackColor = System.Drawing.Color.FromArgb(32, 232, 66);
                    e.Row.ForeColor = System.Drawing.Color.Black;
                    e.Row.Font.Bold = true;
                }
            }

        }

    }


    protected void GvResultadosFacturas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GvResultadosFacturas_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnGestionar_Click(object sender, EventArgs e)
    {

        List<string> lista = new List<string>();
        Session["SeleccionGrillaFacturasSeleccionadas"] = null;
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultadosFacturas.Rows)
        {
            string key = dr.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "N°")].Text;
            if (((CheckBox)dr.Cells[0].Controls[1]).Checked && dr.Cells[0].Enabled)
            {
                if (lista.Find(delegate(string dk) { return dk.Equals(key); }) == null)
                {
                    lista.Add(key);
                    dr.Cells[0].Enabled = false;
                }
            }
            else
            {
                if (lista.Find(delegate(string dk) { return dk.Equals(key); }) != null)
                {
                    lista.Remove(key);
                }
            }
        }

        Session["SeleccionGrillaFacturasSeleccionadas"] = lista;
        Session["lblClienteSeleccionado"] = this.lblClienteSeleccionado.Text;
        Session["lblDeudorSeleccionado"] = this.lblResDeudorSeleccionado.Text;
        Session["lblCuandoCobrar"] = this.lblCuandoCobrar.Text;

        //        Random nr = new Random(0);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaPopUpHItoFacturaConScroll('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewPopUpHitoFactura.aspx','_blank');", true);

    }

    //No se usa este método
    private void AsignarColores(List<FacturaDataContracts> listadoDeFacturas)
    {
        List<FacturaDataContracts> listadoFacturasEnFecha = new List<FacturaDataContracts>();
        List<FacturaDataContracts> listadoFacturasAVencer = new List<FacturaDataContracts>();
        List<FacturaDataContracts> listadoFacturasVencidas = new List<FacturaDataContracts>();

        foreach (var factura in listadoDeFacturas)
        {

            if (factura.FechaVenc.Date < DateTime.Today)
            {
                listadoFacturasVencidas.Add(factura);

            }
            else if ((factura.FechaVenc.Date.Subtract(DateTime.Today)).Days < 7)
            {
                listadoFacturasAVencer.Add(factura);

            }
            else
            {
                listadoFacturasEnFecha.Add(factura);
            }

        }
        DataTable dt = new DataTable();

        DataColumn column0 = new DataColumn("idFactura");
        column0.DataType = System.Type.GetType("System.Int32");
        dt.Columns.Add(column0);

        DataColumn column1 = new DataColumn("numeroComp");
        column1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column1);

        DataColumn column2 = new DataColumn("fechaVenc");
        column2.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column2);

        DataColumn column3 = new DataColumn("saldo");
        column3.DataType = System.Type.GetType("System.Double");
        dt.Columns.Add(column3);

        DataColumn columnx = new DataColumn("importe");
        column3.DataType = System.Type.GetType("System.Double");
        dt.Columns.Add(columnx);

        DataColumn column4 = new DataColumn("estado");
        column4.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column4);

        DataColumn column5 = new DataColumn("proximaGestion");
        column5.DataType = System.Type.GetType("System.DateTime");
        dt.Columns.Add(column5);

        foreach (FacturaDataContracts factura in listadoFacturasEnFecha)
        {

            DataRow dr = dt.NewRow();

            dr["idFactura"] = factura.IdFactura;
            dr["numeroComp"] = factura.NumeroComp;
            dr["fechaVenc"] = factura.FechaVenc;
            dr["saldo"] = factura.Saldo;
            dr["importe"] = factura.Importe;
            dr["estado"] = factura.Estado;
            dr["proximaGestion"] = factura.ProximaGestion;
            dt.Rows.Add(dr);

        }

        foreach (FacturaDataContracts factura in listadoFacturasAVencer)
        {
            DataRow dr = dt.NewRow();

            dr["idFactura"] = factura.IdFactura;
            dr["numeroComp"] = factura.NumeroComp;
            dr["fechaVenc"] = factura.FechaVenc;
            dr["saldo"] = factura.Saldo;
            dr["importe"] = factura.Importe;
            dr["estado"] = factura.Estado;
            dr["proximaGestion"] = factura.ProximaGestion;
            dt.Rows.Add(dr);
        }

        foreach (FacturaDataContracts factura in listadoFacturasVencidas)
        {
            DataRow dr = dt.NewRow();

            dr["idFactura"] = factura.IdFactura;
            dr["numeroComp"] = factura.NumeroComp;
            dr["fechaVenc"] = factura.FechaVenc;
            dr["saldo"] = factura.Saldo;
            dr["importe"] = factura.Importe;
            dr["estado"] = factura.Estado;
            dr["proximaGestion"] = factura.ProximaGestion;
            dt.Rows.Add(dr);
        }


        this.GvResultadosFacturas.DataSource = dt;
        this.GvResultadosFacturas.DataBind();
        this.GvResultadosFacturas.Rows[0].BackColor = System.Drawing.Color.Coral;
        this.GvResultadosFacturas.DataBind();
    }

    protected void GvResultados_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((GridView)sender).SelectedIndex = ((System.Web.UI.WebControls.GridViewEditEventArgs)(e)).NewEditIndex;
        ((GridView)sender).SelectedRowStyle.BackColor = System.Drawing.Color.Beige;
        ((GridView)sender).SelectedRowStyle.ForeColor = System.Drawing.Color.White;
        ((GridView)sender).SelectedRowStyle.Font.Bold = true;

    }
    protected void GvResultados_PreRender(object sender, EventArgs e)
    {
        int cont = -1;
        foreach (GridViewRow item in GvResultados.Rows)
        {
            cont++;
            foreach (TableCell cell in item.Cells)
            {
                cell.Attributes.Add("onclick", "__doPostBack('ctl00$Contentplaceholder1$GvResultados','Edit$" + cont.ToString() + "');");

            }
        }

    }
    protected DataTable GvResultadosFacturas_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();

        try
        {
            if (this.lblResIdentificarDeudor.Text != string.Empty)
            {
                int idDeudor = Int32.Parse(this.lblResIdentificarDeudor.Text.Substring(1).Substring(0, this.lblResIdentificarDeudor.Text.Length - 2));
                dataTable = this.GetDataTableFacturasPorDeudor(idDeudor);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = GvResultadosFacturas_Filling(sender, e);
        DataTable dtFiltrado = new DataTable();
        DataColumn column0 = new DataColumn("idFactura");
        column0.DataType = System.Type.GetType("System.Int32");
        dtFiltrado.Columns.Add(column0);

        DataColumn column1 = new DataColumn("numeroComp");
        column1.DataType = System.Type.GetType("System.String");
        dtFiltrado.Columns.Add(column1);

        DataColumn column2 = new DataColumn("fechaVenc");
        column2.DataType = System.Type.GetType("System.String");
        dtFiltrado.Columns.Add(column2);

        DataColumn column3 = new DataColumn("saldo");
        column3.DataType = System.Type.GetType("System.Double");
        dtFiltrado.Columns.Add(column3);

        DataColumn columnx = new DataColumn("importe");
        column3.DataType = System.Type.GetType("System.Double");
        dtFiltrado.Columns.Add(columnx);

        DataColumn column4 = new DataColumn("estado");
        column4.DataType = System.Type.GetType("System.String");
        dtFiltrado.Columns.Add(column4);

        DataColumn column5 = new DataColumn("proximaGestion");
        column5.DataType = System.Type.GetType("System.DateTime");
        dtFiltrado.Columns.Add(column5);

        switch (((System.Web.UI.WebControls.ListControl)(sender)).SelectedValue)
        {

            case "0":
                dtFiltrado = dt;

                break;
            case "1":
                foreach (DataRow dr in dt.Rows)
                {

                    if ((DateTime.Parse(dr["fechaVenc"].ToString()).Date.Subtract(DateTime.Today)).Days < 5 && (DateTime.Parse(dr["fechaVenc"].ToString()).Date.Subtract(DateTime.Today)).Days >= 0)
                    {
                        dtFiltrado.ImportRow(dr);

                    }

                }
                break;

            case "2":

                foreach (DataRow dr in dt.Rows)
                {

                    if ((DateTime.Parse(dr["fechaVenc"].ToString()).Date.Subtract(DateTime.Today)).Days >= 5 && (DateTime.Parse(dr["fechaVenc"].ToString()).Date.Subtract(DateTime.Today)).Days <= 15)
                    {
                        dtFiltrado.ImportRow(dr);

                    }

                }
                break;

            case "3":

                foreach (DataRow dr in dt.Rows)
                {

                    if ((DateTime.Parse(dr["fechaVenc"].ToString()).Date.Subtract(DateTime.Today)).Days > 15)
                    {
                        dtFiltrado.ImportRow(dr);

                    }

                }
                break;


        }

        this.GvResultadosFacturas.DataSource = dtFiltrado;
        this.GvResultadosFacturas.DataBind();


    }

    protected void cmbClientesAsociados_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.cmbClientesAsociados.SelectedValue != "Todas")
        {

            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            string nombre = principal.Identity.Name;

            DataTable dt = GetDataTableDeudoresByIdCliente(int.Parse(this.cmbClientesAsociados.SelectedItem.Value));
            this.GvResultados.DataSource = dt;
            this.GvResultados.DataBind();
            this.UpdatePanelIndice.Update();

        }
        else
        {

            DataTable dt = GetDataTableDeudores();
            this.GvResultados.DataSource = dt;
            this.GvResultados.DataBind();
            //this.lblClienteSeleccionado.Text = "Todos";
            this.UpdatePanelIndice.Update();
        }
        this.lblClienteSeleccionado.Text = this.cmbClientesAsociados.SelectedItem.Text;
        GvResultadosFacturas.DataSource = null;
        GvResultadosFacturas.DataBind();

    }

    protected void AbrirEstadoDeCuenta(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaAjustable('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewMailEstadoCuenta.aspx','_blank','800','400');", true);

    }
    protected void txtFecha_TextChanged(object sender, EventArgs e)
    {
        try
        {


        }

        catch
        { }

    }
    protected void btnBuscarIdDeudor_Click(object sender, ImageClickEventArgs e)
    {
        //foreach (GridViewRow item in this.GvResultados.Rows)
        //{
        //    item.Font.Bold = true;
        //    item.Font.Italic = false;
        //    item.Font.Underline = false;


        //}

        //for (UInt16 i = 0; i < GvResultados.Rows.Count; i++)
        //{
        //    if (this.txtFindIdDeudor.Text.Trim().Length > 0 && GvResultados.Rows[i].Cells[UIUtils.GetPosCol(this.GvResultados, "AlfaNum")].Text.Contains(this.txtFindIdDeudor.Text))  
        //    {

        //        GvResultados.Rows[i].Font.Bold = false;
        //        GvResultados.Rows[i].Font.Italic = true;
        //        GvResultados.Rows[i].Font.Underline = true;
        //    }
        //}

        if (this.BuscarEnTodasLasPaginasPorIdDeudor()) return;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popupNoExisteDeudorBuscado", "javascript:alert('No se encontraron resultados.');", true);

    }

    protected void btnBuscarDeudor_Click(object sender, ImageClickEventArgs e)
    {


        if (BuscarEnTodasLasPaginas()) return;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popupNoExisteDeudorBuscado", "javascript:alert('No se encontraron resultados.');", true);
    }

    protected void rbTodos_CheckedChanged(object sender, EventArgs e)
    {
        this.txtCantidadDias.Enabled = this.chkIncluirVencidas.Checked = this.chkIncluirVencidas.Enabled = false;
        this.txtCantidadDias.Text = string.Empty;
        this.txtFechaDesde.Text = string.Empty;

    }
    protected void rbAVencer_CheckedChanged(object sender, EventArgs e)
    {
        this.txtCantidadDias.Enabled = this.chkIncluirVencidas.Enabled = true;
        this.txtCantidadDias.Text = "5";
        this.txtFechaDesde.Text = string.Empty;
    }

    protected void rbFiltroFechaReclamo_CheckedChanged(object sender, EventArgs e)
    {
        this.txtCantidadDias.Enabled = this.chkIncluirVencidas.Checked = this.chkIncluirVencidas.Enabled = false;
        this.txtCantidadDias.Text = string.Empty;
        this.chkIncluirVencidas.Checked = false;
    }

    protected void btnShowPopupHorariosReclamo_Click(object sender, EventArgs e)
    {
        if (Session["deudorSeleccionado"] == null) return;
        fillHorariosReclamo();

        //        initializeHorariosReclamoDeudor();
        this.ModalPopupHorariosReclamo.Show();
    }

    protected void btnShowPopupHorariosCobro_Click(object sender, EventArgs e)
    {
        if (Session["deudorSeleccionado"] == null) return;
        fillHorariosCobro();

        //        initializeHorariosCobroDeudor();
        this.ModalPopupHorariosCobro.Show();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DataTable dataTable = null;
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string nombre = principal.Identity.Name;


        if (this.cmbClientesAsociados.SelectedValue != "Todas")
        {
            /*List<DeudorDataContracts> deudoresFiltrados = applyDeudoresList(GetDeudoresByClienteYAnalista(int.Parse(this.cmbClientesAsociados.SelectedValue), nombre));
            dataTable = ConvertDataTable<DeudorDataContracts>.Convert(deudoresFiltrados);*/
            dataTable = GetDataTableDeudoresByIdCliente(int.Parse(this.cmbClientesAsociados.SelectedValue));
        }
        else
            dataTable = GetDataTableDeudores();

        this.GvResultadosFacturas.DataSource = null;
        this.GvResultadosFacturas.DataBind();
        this.GvResultados.DataSource = dataTable;
        this.GvResultados.DataBind();
    }

    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        btnGestionar.Enabled = false;
        this.txtSumaFacturas.Text = "0";
        foreach (GridViewRow Fila in GvResultadosFacturas.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)Fila.FindControl("chk");
            if (chk.Checked == true)
            {
                for (int cont = 1; cont < GvResultadosFacturas.Columns.Count; cont++)
                {
                    Fila.Cells[cont].Enabled = false;
                }

                btnGestionar.Enabled = true;
                this.txtSumaFacturas.Text = (double.Parse(this.txtSumaFacturas.Text) + double.Parse(Fila.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "saldo")].Text)).ToString();
                // break;
            }
            else
            {

                for (int cont = 1; cont < GvResultadosFacturas.Columns.Count; cont++)
                {
                    Fila.Cells[cont].Enabled = true;
                }
                // this.txtSumaFacturas.Text = (double.Parse(this.txtSumaFacturas.Text) - double.Parse(Fila.Cells[UIUtils.GetPosCol(this.GvResultadosFacturas, "saldo")].Text)).ToString();

            }
        }
    }

    protected void btnVerProximasGestiones_Click(object sender, EventArgs e)
    {
        this.CargarAgendaDelDia();
    }
    protected void btnVerAgenda_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript: document.open('ViewPopUpAgenda.aspx','_blank','height=650px,width=390px,scrollbars=no,resizable=yes');", true);
    }

    private void CargarAgendaDelDia()
    {
        //Verificar como obtenemos el analista actual

        //1.Obtener todos los deudores asignados al analista
        //2.Por cada deudor, buscar en sus facturas si al menos una tiene fecha de proxima gestión el dia actual
        //3.De encontrar una factura con proxima gestion igual al día actual, alertar por pop up y dejar de buscar en ese deudor

        string pszDeudores = string.Empty;


        List<DeudorLivianoDataContracts> deudores = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorService = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string nombre = principal.Identity.Name;
        //deudores = deudorService.GetAllDeudorsPorCriterioAnalista(nombre);
        deudores = deudorService.GetAllDeudorsLivianoGestionAnalista(nombre, true, false, 0, false, false, -1, true);

        Session["facturasProximaGestion"] = null;
        List<FacturaDataContracts> facturasProximaGestion = new List<FacturaDataContracts>();
        foreach (DeudorLivianoDataContracts deudor in deudores)
        {
            List<FacturaDataContracts> facturas = new List<FacturaDataContracts>();
            IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
            facturas = facturaService.GetAllFacturasPorIdDeudorProximaGestion(deudor.IdDeudor);

            foreach (FacturaDataContracts factura in facturas)
            {
                if (factura.ProximaGestion >= DateTime.Now && factura.ProximaGestion <= DateTime.Now.AddHours(2) && factura.Estado.Equals("A_GESTION"))
                {
                    facturasProximaGestion.Add(factura);
                    pszDeudores += "Deudor: " + deudor.Nombre + ". (Ej:Factura : " + factura.ComprobanteFormateado + ")\\n";
                    // break;
                }
            }
        }
        string inicio = string.Empty;
        inicio = pszDeudores;
        pszDeudores = "Usted HOY tiene para gestionar lo siguiente: " + "\\n";
        pszDeudores += "\\n";
        pszDeudores += inicio;
        Session["facturasProximaGestion"] = facturasProximaGestion;

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript: document.open('ViewPopUpProximasGestiones.aspx','_blank','height=470px,width=520px,scrollbars=no,resizable=no,location=no');", true);
    }
    private void CargarAgenda()
    {
        //y ahora recuperamos la agenda

        List<AgendaDataContracts> agendas = new List<AgendaDataContracts>();
        IAgendaService agendaService = ServiceClient<IAgendaService>.GetService("AgendaService");
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string nombre = principal.Identity.Name;
        agendas = agendaService.GetAllAgendasByAnalistaYFecha(nombre, DateTime.Now);

        //foreach (AgendaDataContracts agenda in agendas)
        //{
        //    if (agenda.FechaDeAlerta > DateTime.Now)
        //    {
        //        string pszAgenda = "Prioridad: " + agenda.Criticidad + " - Descripcion: " + agenda.Tarea;

        //        TimeSpan MilisegundosTotal = agenda.FechaDeAlerta - DateTime.Now;
        //        string Milisegundos = MilisegundosTotal.TotalMilliseconds.ToString();
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "baba", "javascript: setTimeout(\"alert('" + pszAgenda + "');\"," + Milisegundos + ");", true);
        //    }
        //}
    }

    protected void GvResultadosFacturas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        this.GvResultadosFacturas.SelectedIndex = e.NewSelectedIndex;

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if (Session["seleccionItemProntoPago"] != null)
            Session["seleccionItemProntoPago"] = null;

        Session["seleccionItemProntoPago"] = e.NewSelectedIndex;

        List<ProntoPagoDataContracts> listaProntoPago = new List<ProntoPagoDataContracts>();
        IProntoPagoService prontoPagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
        listaProntoPago = prontoPagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(this.lblIdClienteSeleccionado.Text), int.Parse(this.GvResultados.SelectedDataKey.Value.ToString()));
        //prontoPagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(this.cmbClientes.SelectedItem.Value), int.Parse(this.cmbDeudores.SelectedItem.Value));

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
    }

    protected void gvProntoPago_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int indexSelect = e.NewSelectedIndex;

        this.gvProntoPago.SelectedIndex = e.NewSelectedIndex;

        this.txtImporteProntoPago.Text = this.txtImporteActual.Text;
        this.txtImporteProntoPago.Text = (float.Parse(this.txtImporteProntoPago.Text) - float.Parse(this.gvProntoPago.SelectedRow.Cells[UIUtils.GetPosCol(this.gvProntoPago, "Porcentaje(%)")].Text) * float.Parse(this.txtImporteActual.Text) / 100).ToString();
        UIUtils.PaintSelectedRow(this.gvProntoPago, "id", (e.NewSelectedIndex + 1).ToString());
    }



    protected void btnAgregarHorarioReclamo_Click(object sender, EventArgs e)
    {

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int idDeudor = Int32.Parse(Session["deudorSeleccionado"].ToString());

        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
        List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
        if (Session[listaDiasReclamoKey] != null)
        {
            listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)Session[listaDiasReclamoKey];
        }
        else
        {
            listaDiasReclamo = new List<DeudorDiaReclamoDataContracts>();
            Session[listaDiasReclamoKey] = listaDiasReclamo;
        }

        DeudorDiaReclamoDataContracts ddrDTO = new DeudorDiaReclamoDataContracts();
        if (idDeudor > 0)
        {
            ddrDTO.IdDeudor = idDeudor;
        }
        ddrDTO.IdDiaReclamo = -1;
        ddrDTO.IdDia = int.Parse(this.cmbDiasReclamo.SelectedItem.Value);
        //int horaDesdeAMPM = this.tsHorarioDesde.Hour;
        //int horaHastaAMPM = this.tsHorarioHasta.Hour;
        //ddrDTO.HorarioDesde = horaDesdeAMPM.ToString("00") + ":" + this.tsHorarioDesde.Minute.ToString("00");
        //ddrDTO.HorarioHasta = horaHastaAMPM.ToString("00") + ":" + this.tsHorarioHasta.Minute.ToString("00");
        ddrDTO.HorarioDesde = this.tsHorarioDesde.SelectedItem.Value;
        ddrDTO.HorarioHasta = this.tsHorarioHasta.SelectedItem.Value;

        IDeudorDiaReclamoService deudorDiaReclamoService = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
        deudorDiaReclamoService.Insert(ddrDTO);

        listaDiasReclamo = deudorDiaReclamoService.GetAllDeudorDiaReclamo(idDeudor);
        this.lblCuandoReclamar.Text = string.Empty;
        foreach (DeudorDiaReclamoDataContracts ddr in listaDiasReclamo)
        {
            DiasDataContracts dia = new DiasDataContracts();
            IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
            dia = diasService.GetDias(ddr.IdDia);

            this.lblCuandoReclamar.Text += dia.Descripcion + " - " + ddr.HorarioDesde + " - " + ddr.HorarioHasta + "<br />";
            this.hdFecha_Reclamo.Value += ddr.IdDia + " - ";
        }
        UpdatePanelDatosDeudor.Update();
        Session[listaDiasReclamoKey] = listaDiasReclamo;
        fillTableHorariosReclamo(listaDiasReclamo);
    }

    protected void btnAgregarHorarioCobro_Click(object sender, EventArgs e)
    {

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int idDeudor = Int32.Parse(Session["deudorSeleccionado"].ToString());

        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
        if (Session[listaDiasCobroKey] != null)
        {
            listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];
        }
        else
        {
            listaDiasCobro = new List<DeudorDiaCobroDataContracts>();
            Session[listaDiasCobroKey] = listaDiasCobro;
        }

        DeudorDiaCobroDataContracts ddrDTO = new DeudorDiaCobroDataContracts();
        if (idDeudor > 0)
        {
            ddrDTO.IdDeudor = idDeudor;
        }
        ddrDTO.IdDiaCobro = -1;
        ddrDTO.IdDia = int.Parse(this.cmbDiasCobro.SelectedItem.Value);
        //int horaDesdeAMPM = int.Parse(this.tsHorarioDesdeCobro.SelectedItem.Value);
        //int horaHastaAMPM = int.Parse(this.tsHorarioHastaCobro.SelectedItem.Value);
        //ddrDTO.HorarioDesde = horaDesdeAMPM.ToString("00") + ":00";
        //ddrDTO.HorarioHasta = horaHastaAMPM.ToString("00") + ":00";
        ddrDTO.HorarioDesde = this.tsHorarioDesdeCobro.SelectedItem.Value;
        ddrDTO.HorarioHasta = this.tsHorarioHastaCobro.SelectedItem.Value;

        IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
        deudorDiaCobroService.Insert(ddrDTO);

        Session[listaDiasCobroKey] = listaDiasCobro;
        this.lblCuandoCobrar.Text = string.Empty;
        DiasDataContracts dia = null;
        IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");

        listaDiasCobro = deudorDiaCobroService.GetAllDeudorDiaCobrosPorIdDeudor(idDeudor);
        this.lblCuandoCobrar.Text = string.Empty;

        foreach (DeudorDiaCobroDataContracts ddr in listaDiasCobro)
        {

            dia = diasService.GetDias(ddr.IdDia);

            this.lblCuandoCobrar.Text += dia.Descripcion + " - " + ddr.HorarioDesde + " - " + ddr.HorarioHasta + "<br />";
        }
        UpdatePanelDatosDeudor.Update();
        Session[listaDiasCobroKey] = listaDiasCobro;
        fillTableHorariosCobro(listaDiasCobro);
    }


    protected void fillTableHorariosReclamo(List<DeudorDiaReclamoDataContracts> listaDiasReclamo)
    {
        IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
        TableCell cell = null;
        TableRow row = null;
        this.tblHorariosReclamo.Rows.Clear();
        this.tblHorariosReclamo.BorderWidth = 1;
        this.tblHorariosReclamo.CellPadding = 1;

        for (int i = 0; i < listaDiasReclamo.Count; i++)
        {
            DeudorDiaReclamoDataContracts ddrDTO = listaDiasReclamo.ElementAt(i);

            row = new TableRow();

            cell = new TableCell();
            cell.Text = diasService.GetDias(ddrDTO.IdDia).Descripcion;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = ddrDTO.HorarioDesde;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = ddrDTO.HorarioHasta;
            row.Cells.Add(cell);

            cell = new TableCell();
            LinkButton link = new LinkButton();
            link.Attributes.Add("runat", "server");
            link.Command += new CommandEventHandler(OnDeleteHorarioReclamo);
            link.CommandName = i.ToString();
            link.CommandArgument = i.ToString();
            link.Visible = true;
            link.Text = "Eliminar";
            link.ID = "lnkEliminarHR_" + i.ToString(); ;
            cell.Controls.Add(link);
            row.Cells.Add(cell);

            this.tblHorariosReclamo.Rows.Add(row);
            this.tblHorariosReclamo.CssClass = "gvAlternatingItem";
        }
    }

    protected void fillHorariosReclamo()
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int idDeudor = Int32.Parse(Session["deudorSeleccionado"].ToString());

        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
        List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
        if (Session[listaDiasReclamoKey] != null)
        {
            listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)Session[listaDiasReclamoKey];
        }
        else
        {
            listaDiasReclamo = new List<DeudorDiaReclamoDataContracts>();
            Session[listaDiasReclamoKey] = listaDiasReclamo;
        }

        IDeudorDiaReclamoService deudorDiaReclamoService = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
        if (idDeudor > 0 && listaDiasReclamo.Count == 0)
        {
            List<DeudorDiaReclamoDataContracts> ldr = deudorDiaReclamoService.GetAllDeudorDiaReclamo(idDeudor);

            listaDiasReclamo.AddRange(ldr);
        }

        fillTableHorariosReclamo(listaDiasReclamo);

    }

    protected void OnDeleteHorarioReclamo(object sender, CommandEventArgs e)
    {
        string idToDelete = e.CommandArgument.ToString();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
        List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
        if (Session[listaDiasReclamoKey] != null)
        {
            listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)Session[listaDiasReclamoKey];
            DeudorDiaReclamoDataContracts ddrDTO = listaDiasReclamo.ElementAt(int.Parse(idToDelete));
            if (ddrDTO.IdDiaReclamo != -1)
            {
                IDeudorDiaReclamoService deudorDiaReclamoService = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
                deudorDiaReclamoService.Delete(ddrDTO);
            }

            listaDiasReclamo.RemoveAt(int.Parse(idToDelete));
            this.lblCuandoReclamar.Text = string.Empty;
            foreach (DeudorDiaReclamoDataContracts ddr in listaDiasReclamo)
            {
                DiasDataContracts dia = new DiasDataContracts();
                IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
                dia = diasService.GetDias(ddr.IdDia);

                this.lblCuandoReclamar.Text += dia.Descripcion + " - " + ddr.HorarioDesde + " - " + ddr.HorarioHasta + "<br />";
                this.hdFecha_Reclamo.Value += ddr.IdDia + " - ";
            }
            UpdatePanelDatosDeudor.Update();
        }

        fillTableHorariosReclamo(listaDiasReclamo);
    }

    protected void fillTableHorariosCobro(List<DeudorDiaCobroDataContracts> listaDiasCobro)
    {
        IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
        TableCell cell = null;
        TableRow row = null;
        this.tblHorariosCobro.Rows.Clear();
        this.tblHorariosCobro.BorderWidth = 1;
        this.tblHorariosCobro.CellPadding = 1;

        for (int i = 0; i < listaDiasCobro.Count; i++)
        {
            DeudorDiaCobroDataContracts ddrDTO = listaDiasCobro.ElementAt(i);

            row = new TableRow();

            cell = new TableCell();
            cell.Text = diasService.GetDias(ddrDTO.IdDia).Descripcion;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = ddrDTO.HorarioDesde;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = ddrDTO.HorarioHasta;
            row.Cells.Add(cell);

            cell = new TableCell();
            LinkButton link = new LinkButton();
            link.Attributes.Add("runat", "server");
            link.Command += new CommandEventHandler(OnDeleteHorarioCobro);
            link.CommandName = i.ToString();
            link.CommandArgument = i.ToString();
            link.Visible = true;
            link.Text = "Eliminar";
            link.ID = "lnkEliminarHC_" + i.ToString(); ;
            link.Click += new EventHandler(OnDeleteHorarioCobro);
            cell.Controls.Add(link);
            row.Cells.Add(cell);

            this.tblHorariosCobro.Rows.Add(row);
            this.tblHorariosCobro.CssClass = "gvAlternatingItem";
        }
    }

    protected void fillHorariosCobro()
    {

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int idDeudor = Int32.Parse(Session["deudorSeleccionado"].ToString());

        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
        if (Session[listaDiasCobroKey] != null)
        {
            listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];
        }
        else
        {
            listaDiasCobro = new List<DeudorDiaCobroDataContracts>();
            Session[listaDiasCobroKey] = listaDiasCobro;
        }

        IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
        if (idDeudor > 0 && listaDiasCobro.Count == 0)
        {
            listaDiasCobro.AddRange(deudorDiaCobroService.GetAllDeudorDiaCobrosPorIdDeudor(idDeudor));
        }

        fillTableHorariosCobro(listaDiasCobro);
    }

    protected void OnDeleteHorarioCobro(object sender, EventArgs e)
    {
        Console.Write("ondelete horario cobro:");
    }
    protected void OnDeleteHorarioCobro(object sender, CommandEventArgs e)
    {

        string idToDelete = e.CommandArgument.ToString();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
        if (Session[listaDiasCobroKey] != null)
        {
            listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];
            DeudorDiaCobroDataContracts ddrDTO = listaDiasCobro.ElementAt(int.Parse(idToDelete));

            if (ddrDTO.IdDiaCobro != -1)
            {
                IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
                deudorDiaCobroService.Delete(ddrDTO);
            }

            listaDiasCobro.RemoveAt(int.Parse(idToDelete));

            this.lblCuandoCobrar.Text = string.Empty;
            DiasDataContracts dia = null;
            IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
            foreach (DeudorDiaCobroDataContracts ddr in listaDiasCobro)
            {

                dia = diasService.GetDias(ddr.IdDia);

                this.lblCuandoCobrar.Text += dia.Descripcion + " - " + ddr.HorarioDesde + " - " + ddr.HorarioHasta + "<br />";
            }
            UpdatePanelDatosDeudor.Update();
        }

        fillTableHorariosCobro(listaDiasCobro);
    }

    protected void btnHistorialCliente_Click(object sender, EventArgs e)
    {
        try
        {



            string pszParametros = "?id_cliente=" + lblIdClienteSeleccionado.Text;
            pszParametros += "&id_deudor=" + GvResultados.SelectedDataKey.Value.ToString();
            pszParametros += "&origen=gestionAnalista";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up Deudor", "javascript:AbrirVentana2Maximizable('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewHistorialDelDeudor.aspx" + pszParametros + "','viewHistorialDelDeudor',800,500);", true);
        }
        catch (Exception)
        {


        }
    }
    protected void btnFiltrarPorFechaReclamo_Click(object sender, EventArgs e)
    {

    }

}

