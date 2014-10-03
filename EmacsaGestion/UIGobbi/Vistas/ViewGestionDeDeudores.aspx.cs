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
using EvaWebControls;
using Common.DataContracts;
using Common.Interfaces;
using System.Collections.Generic;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using System.Web.Services;
using AjaxControlToolkit;
using System.Text;
using Herramientas;


public partial class Vistas_ViewGestionDeDeudores : GobbiPage
{

    private List<ReporteDataContracts> _listaReportes;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Params["restoreFilters"] == "true")
        {
            if (Session["busquedaDataContracts"]!=null)
            {
                DataTable dataTable = GetDataTableDeudoresToRestoreFilters();
                this.GvResultados.DataSource = dataTable;
                this.GvResultados.PageIndex = ((BusquedaDataContracts) Session["busquedaDataContracts"]).NumPage;
                this.GvResultados.DataBind();
                this.lblResultado.Text = "Resultados Obtenidos: " + dataTable.Rows.Count.ToString();
                actualizarSeleccionGrilla();
                this.DesahilitarValidatorsEdicion();
                this.MaskedEditValidator1.Enabled = false;
                this.MaskedEditValidator2.Enabled = false;


                this.TabContainer1.ActiveTabIndex = 0;
                this.UpdatePanelTabContainer.Update();
                return;
            }
            
            
        }

        actualizarSeleccionGrilla();
        this.DesahilitarValidatorsEdicion();

        if (!Page.IsPostBack)
        {

            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewGestionDeDeudores));

            this.radioCliente.Checked = false;
            this.radioAnalista.Checked = false;
            this.radioDeudor.Checked = true;

            this.panelDeudor.Enabled = true;
            this.panelCliente.Enabled = false;
            this.panelFacturas.Enabled = false;
            this.panelFechaCheque.Enabled = false;
            this.panelAnalista.Enabled = false;
            this.MaskedEditValidator1.Enabled = false;
            this.MaskedEditValidator2.Enabled = false;


            List<AnalistaDataContracts> analistas = new List<AnalistaDataContracts>();
            IAnalistaService analistaServices = ServiceClient<IAnalistaService>.GetService("AnalistaService");
            analistas = analistaServices.GetAllAnalistas();
            this.cmbAnalistas.DataSource = analistas;
            this.cmbAnalistas.DataTextField = "NOMBRE";
            this.cmbAnalistas.DataValueField = "idAnalista";
            this.cmbAnalistas.DataBind();

            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            clientes = clienteServices.GetAllClientes();
            this.cmbClientes.DataSource = clientes;
            this.cmbClientes.DataTextField = "NOMBRE";
            this.cmbClientes.DataValueField = "idCliente";
            this.cmbClientes.DataBind();


            this.TabContainer1.ActiveTabIndex = 0;
            this.UpdatePanelTabContainer.Update();
 
        }

    }
    protected void Visualizar_Click(object sender, EventArgs e)
    {
         DataTable dataTable = GetDataTableDeudores();
        this.GvResultados.DataSource = dataTable;
        this.GvResultados.DataBind();
        this.lblResultado.Text = "Resultados Obtenidos: " + dataTable.Rows.Count.ToString();
    }



    private DataTable GetDataTableDeudoresToRestoreFilters()
    {

        List<DeudorDataContracts> resultadoObtenidos = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        BusquedaDataContracts busquedaDataContracts = new BusquedaDataContracts();

        busquedaDataContracts = (BusquedaDataContracts)Session["busquedaDataContracts"];

        if (busquedaDataContracts.RadioDeudor)
        {
            this.radioDeudor.Checked = true;
            if (busquedaDataContracts.RadioDescription)
            {
                resultadoObtenidos = ConvertDataTable<DeudorDataContracts>.Convert(busquedaDataContracts.Results);
                this.rdoDescripcion.Checked = true;
                this.txtDescDeudor.Text = busquedaDataContracts.Parameters[0].ToString();

            }
            else
            {
                resultadoObtenidos = ConvertDataTable<DeudorDataContracts>.Convert(busquedaDataContracts.Results);
                this.rdoIdDeudor.Checked = true;
                this.txtId_Deudor.Text = busquedaDataContracts.Parameters[0].ToString();
            }
        }

        if (busquedaDataContracts.RadioCliente )
        {
            this.radioCliente.Checked = true;
            if (busquedaDataContracts.RadioAVencer )
            {
                this.radioCliente.Checked = true;
                this.cmbClientes.SelectedValue = busquedaDataContracts.Parameters[0].ToString();
                this.txtFechaDesde.Text=busquedaDataContracts.Parameters[1].ToString();
                this.txtFechaHasta.Text=busquedaDataContracts.Parameters[2].ToString();
                resultadoObtenidos = ConvertDataTable<DeudorDataContracts>.Convert(busquedaDataContracts.Results);

            }
            else
            {

                resultadoObtenidos = ConvertDataTable<DeudorDataContracts>.Convert(busquedaDataContracts.Results);
                this.cmbClientes.SelectedValue = busquedaDataContracts.Parameters[0].ToString();
                this.radioEstadoFactura.SelectedItem.Value = busquedaDataContracts.Parameters[1].ToString();
            }
        }

        if (busquedaDataContracts.RadioAnalista )
        {
            this.radioAnalista.Checked = true;
            this.cmbAnalistas.SelectedItem.Text = busquedaDataContracts.Parameters[0].ToString();
            resultadoObtenidos = ConvertDataTable<DeudorDataContracts>.Convert(busquedaDataContracts.Results);
     
        }
  
        return ConvertDataTable<DeudorDataContracts>.Convert(resultadoObtenidos);
    }


    private DataTable GetDataTableDeudores()
    {
        
        List<DeudorDataContracts> resultadoObtenidos = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        BusquedaDataContracts busquedaDataContracts =new BusquedaDataContracts();

        if (this.radioDeudor.Checked)
        {
            busquedaDataContracts.RadioDeudor = true;
            if (this.rdoDescripcion.Checked)
            {
                resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioDeudor(this.txtDescDeudor.Text);
                busquedaDataContracts.Parameters.Add(this.txtDescDeudor.Text);
                busquedaDataContracts.RadioDescription = true;
                busquedaDataContracts.Results = ConvertDataTable<DeudorDataContracts>.Convert(resultadoObtenidos);
            }
            else
            {
                //resultadoObtenidos.Add(deudorServices.GetDeudor(int.Parse(this.txtId_Deudor.Text)));
                //GetAllDeudorsPorAlfaNum
                resultadoObtenidos = deudorServices.GetAllDeudorsPorAlfaNum(this.txtId_Deudor.Text);
                busquedaDataContracts.Parameters.Add(this.txtId_Deudor.Text);
                busquedaDataContracts.Results = ConvertDataTable<DeudorDataContracts>.Convert(resultadoObtenidos);
            }
        }

        if (this.radioCliente.Checked)
        {
            if (this.radioAVencer.Checked)
            {
                resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioClienteFecha(
                    this.cmbClientes.SelectedValue, DateTime.Parse(this.txtFechaDesde.Text),
                    DateTime.Parse(this.txtFechaHasta.Text));
                busquedaDataContracts.Parameters.Add(this.cmbClientes.SelectedValue);
                busquedaDataContracts.Parameters.Add(this.txtFechaDesde.Text);
                busquedaDataContracts.Parameters.Add(this.txtFechaHasta.Text);

                busquedaDataContracts.RadioAVencer = true;
                busquedaDataContracts.Results = ConvertDataTable<DeudorDataContracts>.Convert(resultadoObtenidos);
            }
            else
            {
                resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioCliente(this.cmbClientes.SelectedValue,
                                                                                    int.Parse(
                                                                                        this.radioEstadoFactura.
                                                                                            SelectedItem.Value));

                busquedaDataContracts.Parameters.Add(this.cmbClientes.SelectedValue);
                busquedaDataContracts.Parameters.Add( int.Parse(this.radioEstadoFactura.SelectedItem.Value));
                busquedaDataContracts.Results = ConvertDataTable<DeudorDataContracts>.Convert(resultadoObtenidos);
            }
        }

        if (this.radioAnalista.Checked)
        {
            resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioAnalista(this.cmbAnalistas.SelectedItem.Text);
            busquedaDataContracts.RadioAnalista = true;
            busquedaDataContracts.Parameters.Add(int.Parse(this.cmbAnalistas.SelectedItem.Text));
            busquedaDataContracts.Results = ConvertDataTable<DeudorDataContracts>.Convert(resultadoObtenidos);
        }
        Session["busquedaDataContracts"] = busquedaDataContracts;
        return ConvertDataTable<DeudorDataContracts>.Convert(resultadoObtenidos);
    }

    protected DataTable GvResultados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();

        try
        {
            dataTable = this.GetDataTableDeudores();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }

    private void actualizarSeleccionGrilla()
    {
        List<string> lista = new List<string>();
   
        Session["SeleccionGrilla"] = null;

        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultados.Rows)
        {
            string key = dr.Cells[Herramientas.UIUtils.GetPosCol(GvResultados,"idDeudor")].Text;
            if (((CheckBox)dr.Cells[0].Controls[0]).Checked)
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

        Session["SeleccionGrilla"] = lista;
        
    }
    protected void Exportar_Click(object sender, EventArgs e)
    {
    }
    private void LimpiarCheck()
    {

        foreach (ListItem item in this.radioEstadoFactura.Items)
        {
            item.Selected = false;
        }
    }

    protected void CambioDeFiltro(object sender, EventArgs e)
    {
        string id;
        this.MaskedEditValidator1.Enabled = false;

        if (sender.GetType().ToString() == "System.Web.UI.WebControls.RadioButton")
        {
            RadioButton sen = (RadioButton)sender;

            id = sen.ID;
        }
        else
        {
            id = ((RadioButtonList)sender).ID;
        }

        switch (id)
        {
            case "radioDeudor":

                this.radioCliente.Checked = false;
                this.radioAnalista.Checked = false;
                this.radioDeudor.Checked = true;
                this.radioAVencer.Checked = false;
                this.panelDeudor.Enabled = true;
                this.panelCliente.Enabled = false;
                this.panelFacturas.Enabled = false;
                this.panelFechaCheque.Enabled = false;
                this.panelAnalista.Enabled = false;
                LimpiarCheck();

                break;


            case "radioAVencer":

                LimpiarCheck();
                this.MaskedEditValidator1.Enabled = true;
                break;

            case "radioEstadoFactura":
                this.radioAVencer.Checked = false;
                this.MaskedEditValidator1.Enabled = false;
                break;
            case "radioCliente":

                this.radioDeudor.Checked = false;
                this.radioAnalista.Checked = false;
                this.radioCliente.Checked = true;
                this.radioAVencer.Checked = false;
                this.radioEstadoFactura.Items[0].Selected = true;
                this.panelDeudor.Enabled = false;
                this.panelCliente.Enabled = true;
                this.panelFacturas.Enabled = true;
                this.panelFechaCheque.Enabled = true;
                this.panelAnalista.Enabled = false;

                break;

            case "radioAnalista":

                this.radioCliente.Checked = false;
                this.radioDeudor.Checked = false;
                this.radioAnalista.Checked = true;
                this.radioAVencer.Checked = false;
                LimpiarCheck();
                this.panelDeudor.Enabled = false;
                this.panelCliente.Enabled = false;
                this.panelFacturas.Enabled = false;
                this.panelFechaCheque.Enabled = false;
                this.panelAnalista.Enabled = true;

                break;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("HeaderGobbi.aspx");
    }
    protected void GvResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int idDomicilioDeudor =
            int.Parse(
                GvResultados.Rows[e.NewEditIndex].Cells[
                    Herramientas.UIUtils.GetPosCol(GvResultados, "idDomicilioDeudor")].Text);

        int idDeudor = int.Parse(
                GvResultados.Rows[e.NewEditIndex].Cells[
                    Herramientas.UIUtils.GetPosCol(GvResultados, "idDeudor")].Text);
        Response.Redirect("ViewAltaDeudor.aspx?Id_Deudor=" + idDeudor.ToString() + "&idDomicilioDeudor=" + idDomicilioDeudor.ToString(), true);
    }



    protected void GvResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GvResultados.PageIndex = e.NewPageIndex;
        this.GvResultados.Fill();

        if (Session["busquedaDataContracts"]!=null)
        {
            BusquedaDataContracts busquedaDataContracts = (BusquedaDataContracts)Session["busquedaDataContracts"];
            busquedaDataContracts.NumPage = e.NewPageIndex;
        }

    }


    protected void GvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        List<string> lista = new List<string>();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        if (Session["SeleccionGrilla"] != null)
            lista = (List<string>)Session["SeleccionGrilla"];

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string key = e.Row.Cells[4].Text;

            if (lista.Find(delegate(string dk) { return dk.Equals(key); }) != null)
            {
                ((CheckBox)e.Row.Cells[0].Controls[0]).Checked = true;
            }

        }
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultados.Rows)
        {
            ((CheckBox)dr.Cells[0].Controls[0]).Checked = ((CheckBox)sender).Checked;
        }

    }
    protected void Hola(object sender, EventArgs e)
    {

    }
    protected void Hola2(object sender, EventArgs e)
    {

    }

    protected void GvResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        try
        {
            deudorServices.DesactivarPorId(int.Parse(GvResultados.Rows[e.RowIndex].Cells[3].Text));
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Eliminar Ok", "javascript:alert('Se ha eliminado correctamente el deudor.');", true);
        }
        catch (Exception Ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Eliminar Fallo", "javascript:alert('Ha ocurrido un error. No se pudo eliminar el deudor. Detalle tecnico: " + Ex.Message + "');", true);
        }
        
        DataTable dataTable = GetDataTableDeudores();
        this.GvResultados.DataSource = dataTable;
        this.GvResultados.DataBind();
        this.lblResultado.Text = "Resultados Obtenidos: " + dataTable.Rows.Count.ToString();
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            DeudorDataContracts deudor = new DeudorDataContracts();
            IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
            deudor.Nombre = this.txtNombre.Text;
            deudor.Cuit = this.txtCuit.Text;
            deudor.Domicilio = this.txtDomicilio.Text;
            deudor.Localidad = this.txtLocalidad.Text;
            deudor.Provincia = this.txtProvincia.Text;
            deudor.Cp = this.txtCp.Text;
            deudor.Telefono = this.txtTelefono.Text;
            deudor.Fax = this.txtFax.Text;
            deudor.Email = this.txtEmail.Text;
            deudor.AnticipoGestion = int.Parse(this.txtAnticipo.Text == string.Empty ? "0" : this.txtAnticipo.Text);
            deudorServices.Insert(deudor);
            this.DeshabilitarValidatorsNuevoDeudor();


            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup11", "javascript:alert('Los datos han sido guardados satisfactoriamente.');HideModalNuevoDeudor();", true);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Ha ocurrido un error y los datos no han sido guardados. Detalle técnico:  ' " + ex.Message + "');HideEdicionDeudor();", true);

        }
    }

    protected void GuardarEdicion(object sender, EventArgs e)
    {

        try
        {

            DeudorDataContracts deudor = new DeudorDataContracts();
            IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
            deudor.IdDeudor = int.Parse(this.txtIdDeudor2.Text);
            deudor.Nombre = this.txtNombre2.Text;
            deudor.Cuit = this.txtCuit2.Text;
            deudor.Domicilio = this.txtDomicilio2.Text;
            deudor.Localidad = this.txtLocalidad2.Text;
            deudor.Provincia = this.txtProvincia2.Text;
            deudor.Cp = string.Empty;// this.txtCp2.Text;
            deudor.Telefono = this.txtTelefono2.Text;
            deudor.Fax = this.txtFax2.Text;
            deudor.Email = this.txtEmail.Text;
            deudor.AnticipoGestion = int.Parse(this.txtAnticipo2.Text);


            deudorServices.Update(deudor);
            this.DesahilitarValidatorsEdicion();

            Visualizar_Click(this, null);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:alert('Los datos han sido guardados satisfactoriamente.');HideEdicionDeudor();", true);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Ha ocurrido un error y los datos no han sido guardados. Detalle técnico:  ' " + ex.Message + "');HideEdicionDeudor();", true);



        }

    }


    private void HabilitarValidatorsNuevoDeudor()
    {
        this.RequiredFieldValidatorTelNuevo.Enabled = true;
        this.RequiredFieldValidatorTelAuxNuevo.Enabled = true;
        this.RequiredFieldValidatorProvNuevo.Enabled = true;
        this.RequiredFieldValidatorNombreNuevo.Enabled = true;
        this.RequiredFieldValidatorLocaNuevo.Enabled = true;
        this.RequiredFieldValidatorDomicilioNuevo.Enabled = true;
        this.RequiredFieldValidatorCuitNuevo.Enabled = true;
        this.RequiredFieldValidatorCPNuevo.Enabled = true;

    }

    private void DeshabilitarValidatorsNuevoDeudor()
    {
        this.RequiredFieldValidatorTelNuevo.Enabled = false;
        this.RequiredFieldValidatorTelAuxNuevo.Enabled = false;
        this.RequiredFieldValidatorProvNuevo.Enabled = false;
        this.RequiredFieldValidatorNombreNuevo.Enabled = false;
        this.RequiredFieldValidatorLocaNuevo.Enabled = false;
        this.RequiredFieldValidatorDomicilioNuevo.Enabled = false;
        this.RequiredFieldValidatorCuitNuevo.Enabled = false;
        this.RequiredFieldValidatorCPNuevo.Enabled = false;

    }


    private void HabilitarValidatorsEdicion()
    {

        this.RequiredFieldValidatorCPEdicion.Enabled = true;
        this.RequiredFieldValidatorDomicilioEdicion.Enabled = true;
        this.RequiredFieldValidatorLocaEdicion.Enabled = true;
        this.RequiredFieldValidatorNombreEdicion.Enabled = true;
        this.RequiredFieldValidatorProvEdicion.Enabled = true;
        this.RequiredFieldValidatorTelEdicion.Enabled = true;

    }
    private void DesahilitarValidatorsEdicion()
    {

        this.RequiredFieldValidatorCPEdicion.Enabled = false;
        this.RequiredFieldValidatorDomicilioEdicion.Enabled = false;
        this.RequiredFieldValidatorLocaEdicion.Enabled = false;
        this.RequiredFieldValidatorNombreEdicion.Enabled = false;
        this.RequiredFieldValidatorProvEdicion.Enabled = false;
        this.RequiredFieldValidatorTelEdicion.Enabled = false;

    }



    protected void NuevoDeudor(object sender, ImageClickEventArgs e)
    {
        this.HabilitarValidatorsNuevoDeudor();
        this.DesahilitarValidatorsEdicion();
        Response.Redirect("ViewImportacionDeDeudores.aspx");
    }

    protected void GestionarDomicilios(object sender, ImageClickEventArgs e)
    {
        string key = string.Empty;

        foreach (System.Web.UI.WebControls.GridViewRow dr in GvResultados.Rows)
        {
            
            if (((CheckBox)dr.Cells[0].Controls[0]).Checked)
            {
                key = dr.Cells[Herramientas.UIUtils.GetPosCol(GvResultados, "idDeudor")].Text;
                break;
            }
        }

        if (key.Equals(string.Empty)) {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Debe seleccionar un deudor", "javascript:alert('Debe seleccionar un deudor.');", true);
            return;
        }

        Response.Redirect("ViewABMDomicilio.aspx?Id_Deudor=" + key);
    }


    //[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    //public string FillDatosDeudor()
    //{


    //    DeudorDataContracts deudor = new DeudorDataContracts();

    //    deudor.Domicilio = "ASDD";
    //    deudor.Telefono = "ASDD";
    //    deudor.IdDeudor = 1;
    //    deudor.Nombre = "ASDD";


    //    this.txtDomicilio2.Text = deudor.Domicilio;
    //    this.txtTelefono2.Text = deudor.Telefono;
    //    this.txtNombre2.Text = deudor.Nombre;


    //    ModalPopupExtender modalPopup = (ModalPopupExtender)this.FindControl("extPnlEditarGrilla");

    //    modalPopup.Show();

    //    return "ass";
    //}
    public string GetContentFillerText()
    {
        return
            "ASP.NET AJAX is a free framework for building a new generation of richer, more interactive, highly personalized cross-browser web applications.  " +
            "This new web development technology from Microsoft integrates cross-browser client script libraries with the ASP.NET 2.0 server-based development framework.  " +
            "In addition, ASP.NET AJAX offers you the same type of development platform for client-based web pages that ASP.NET offers for server-based pages.  " +
            "And because ASP.NET AJAX is an extension of ASP.NET, it is fully integrated with server-based services. ASP.NET AJAX makes it possible to easily take advantage of AJAX techniques on the web and enables you to create ASP.NET pages with a rich, responsive UI and server communication.  " +
            "However, AJAX isn't just for ASP.NET.  " +
            "You can take advantage of the rich client framework to easily build client-centric web applications that integrate with any backend data provider and run on most modern browsers.  ";
    }
    private static string[] wordListText;
    public string[] GetWordListText()
    {
        // This is the NATO phonetic alphabet (http://en.wikipedia.org/wiki/NATO_phonetic_alphabet)
        // and was chosen for its size, non-specificity, and presence of multiple words with the same
        // starting letter.
        if (null == wordListText)
        {
            string[] tempWordListText = new string[] {
                "Alfa",
                "Alpha",
                "Bravo",
                "Charlie",
                "Delta",
                "Echo",
                "Foxtrot",
                "Golf",
                "Hotel",
                "India",
                "Juliett",
                "Juliet",
                "Kilo",
                "Lima",
                "Mike",
                "November",
                "Oscar",
                "Papa",
                "Quebec",
                "Romeo",
                "Sierra",
                "Tango",
                "Uniform",
                "Victor",
                "Whiskey",
                "X-ray",
                "Xray",
                "Yankee",
                "Zulu",
                "Zero",
                "Nadazero",
                "One",
                "Unaone",
                "Two",
                "Bissotwo",
                "Three",
                "Terrathree",
                "Four",
                "Kartefour",
                "Five",
                "Pantafive",
                "Six",
                "Soxisix",
                "Seven",
                "Setteseven",
                "Eight",
                "Oktoeight",
                "Nine",
                "Novenine"
                };
            Array.Sort(tempWordListText);
            wordListText = tempWordListText;
        }
        return wordListText;
    }


    protected void btnPrueba_Click(object sender, EventArgs e)
    {

    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        this.TabContainer1.ActiveTabIndex = ((TabContainer)sender).ActiveTabIndex;
        this.UpdatePanelTabContainer.Update();
        if (((TabContainer)sender).ActiveTabIndex == 2)
        {
            CargarddlReportesDisponibles();
            
        }
    }
    protected void GvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName =="Select")
        {
        ClienteDataContracts client = new ClienteDataContracts();
        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
        client = clienteServices.GetClientePorDeudor(decimal.Parse(this.GvResultados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text));


        if (client != null)
        {
            this.TabContainer1.ActiveTabIndex = 1;
            this.UpdatePanelTabContainer.Update();

        }

        }

    }
    protected void GvResultados_Exporting(object sender, EventArgs e)
    {

        List<string> listaSeleccionados = new List<string>();
        DataTable dt = new DataTable();

        List<string> lista = new List<string>();
 

        DataTable dataTable = GvResultados_Filling(null, null);

        if (Session["SeleccionGrilla"]!=null)
            lista = (List<string>) Session["SeleccionGrilla"];

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

        Session["CACHE_DOCUMENTOS_A_EXPORTAR"] = null;
        Session["CACHE_DOCUMENTOS_A_EXPORTAR"] = dt;


        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaPequenia('ViewExportToExcel.aspx','_blank');", true);
        this.StartupScriptKey++;

    }

    private void CargarddlReportesDisponibles()
    {

        try
        {
            ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
            List<ReporteDataContracts> listaReportes;

            listaReportes = (List<ReporteDataContracts>)Session[Constants.CACHE_LISTADOREPORTES];
            if (listaReportes == null)
            {
                IReporteService reporteServices = ServiceClient<IReporteService>.GetService("ReporteService");


                listaReportes = reporteServices.GetAllReportes();
                Session[Constants.CACHE_LISTADOREPORTES] =  listaReportes;
            }
            _listaReportes = listaReportes;


        }
        catch (Exception ex)
        {
            this.ShowError(ex.Message);
        }
    }


    private string BuildUrl(ReporteDataContracts reporte)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbEncode = new StringBuilder();
        sb.Append(reporte.UrlComun);
        sbEncode.Append(reporte.Directorio);
        sbEncode.Append(reporte.NombreFisico);
        return sb.ToString() + Server.UrlEncode(sbEncode.ToString());
    }

}
