using System;
using System.Collections;
using System.Collections.Generic;
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
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;


public partial class Vistas_ViewHojaDeRuta : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewHojaDeRuta));

            this.GvResultados.DataSource = GetTableLocalidadCp();
            this.GvResultados.DataBind();

            this.cmbCobrador.DataSource = GetTableCobrador();
            this.cmbCobrador.DataTextField = "Apellido";
            this.cmbCobrador.DataValueField = "Id";
            this.cmbCobrador.DataBind();

            this.cmbZona.DataSource = GetTableZona();
            this.cmbZona.DataTextField = "Descripcion";
            this.cmbZona.DataValueField = "Id";
            this.cmbZona.DataBind();

        }
    }

    private DataTable GetTableLocalidadCp()
    {
        List<DeudorDataContracts> deudores = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        deudores = deudorServices.GetAllLocalidadCp();
        return ConvertDataTable<DeudorDataContracts>.Convert(deudores);
    }

    private DataTable GetTableCobrador()
    {
        List<CobradorDataContracts> cobradores = new List<CobradorDataContracts>();
        ICobradorService cobradorServices = ServiceClient<ICobradorService>.GetService("CobradorService");
        cobradores = cobradorServices.GetAllCobrador();
        return ConvertDataTable<CobradorDataContracts>.Convert(cobradores);
    }

    private DataTable GetTableZona()
    {
        List<ZonaDataContracts> zonas = new List<ZonaDataContracts>();
        IZonaService zonaServices = ServiceClient<IZonaService>.GetService("ZonaService");
        zonas = zonaServices.GetAllZona();
        return ConvertDataTable<ZonaDataContracts>.Convert(zonas);
    }

    protected DataTable GvResultados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        try
        {
            dataTable = this.GetTableLocalidadCp();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dataTable;
    }
    protected void GvResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GvResultados.PageIndex = e.NewPageIndex;
        this.GvResultados.Fill();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Bindear", "BindearCP();", true);
    }
    protected void btnCargar_Click(object sender, EventArgs e)
    {
        ZonaDataContracts zona = new ZonaDataContracts();
        IZonaService zonaServices = ServiceClient<IZonaService>.GetService("ZonaService");

        zona.Descripcion = this.txtDescripcion.Text;
        zona.CP = this.txtCP.Value;

        zonaServices.Insert(zona);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup11", "javascript:alert('Los datos han sido guardados satisfactoriamente.');window.location.reload();", true);
        RefrescarDatos();
    }
    protected void btnAltaCobrador_Click(object sender, EventArgs e)
    {
        CobradorDataContracts cobrador = new CobradorDataContracts();
        ICobradorService cobradorServices = ServiceClient<ICobradorService>.GetService("CobradorService");

        cobrador.Nombre = this.txtNombre.Text;
        cobrador.Apellido = this.txtApellido.Text;
        cobrador.DNI = this.txtDNI.Text;
        cobrador.Telefono = this.txtTelefono.Text;
        cobrador.Horario = this.ddlHorario.SelectedValue;

        cobradorServices.Insert(cobrador);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup12", "javascript:alert('Los datos han sido guardados satisfactoriamente.');", true);

        txtNombre.Text = txtApellido.Text = txtDNI.Text = txtTelefono.Text = "";
        this.ddlHorario.SelectedIndex = 0;
        RefrescarDatos();

    }
    protected void btnAsociar_Click(object sender, EventArgs e)
    {
        IZonaService zonaService = ServiceClient<IZonaService>.GetService("ZonaService");
        try
        {
            zonaService.AsociarCobrador(int.Parse(this.cmbCobrador.SelectedValue), int.Parse(this.cmbZona.SelectedValue));
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup13", "javascript:alert('Los datos han sido guardados satisfactoriamente.');", true);
        }
        catch (Exception Ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Fallo", "javascript:alert('Ha ocurrido un error. No se pudo asociar zona al cobrador. Detalle tecnico: " + Ex.Message + "');", true);
        }        
    }
    private void RefrescarDatos()
    {
        this.cmbCobrador.DataSource = GetTableCobrador();
        this.cmbCobrador.DataBind();

        this.cmbZona.DataSource = GetTableZona();
        this.cmbZona.DataBind();
    }

    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {
        List<DeudorDataContracts> deudores = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");                

        if (txtCodigoPostal.Text.Length > 0)
        {
            deudores = deudorServices.GetAllLocalidadCp_PorCp(txtCodigoPostal.Text);
        }
        if (txtLocalidad.Text.Length > 0)
        {
            deudores = deudorServices.GetAllLocalidadCp_PorLocalidad(txtLocalidad.Text);
        }

        this.GvResultados.DataSource = deudores;
        this.GvResultados.DataBind();
    }
}
