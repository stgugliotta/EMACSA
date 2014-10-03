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

public partial class Vistas_ViewAsignacionDeAnalista : GobbiPage 
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
            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewAsignacionDeAnalista));

            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            clientes = clienteServices.GetAllClientes();
            this.cmbClientes.DataSource = clientes;
            this.cmbClientes.DataTextField = "NOMBRE";
            this.cmbClientes.DataValueField = "idCliente";
            this.cmbClientes.DataBind();

            List<DeudorLivianoDataContracts> deudores = new List<DeudorLivianoDataContracts>();
            IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");
            deudores = deudorServices.GetAllDeudorsLivianoPorCriterioCliente(int.Parse(this.cmbClientes.SelectedValue));
            this.cmbDeudores.DataSource = deudores;
            this.cmbDeudores.DataTextField = "NOMBRE";
            this.cmbDeudores.DataValueField = "idDeudor";
            this.cmbDeudores.DataBind();

            //Agregar opcion todos
            ListItem liTodos = new ListItem("Todos","*");
            ListItem liNinguno = new ListItem("Ninguno", "#");
            this.cmbDeudores.Items.Add(liTodos);
            this.cmbDeudores.Items.Add(liNinguno);
            this.cmbDeudores.SelectedIndex = this.cmbDeudores.Items.Count;

            List<AnalistaDataContracts> analistas = new List<AnalistaDataContracts>();
            IAnalistaService analistaServices = ServiceClient<IAnalistaService>.GetService("AnalistaService");
            analistas = analistaServices.GetAllAnalistas();
            this.cmbAnalistas.DataSource = analistas;
            this.cmbAnalistas.DataTextField = "NOMBRE";
            this.cmbAnalistas.DataValueField = "idAnalista";
            this.cmbAnalistas.DataBind();

            DataTable dtResultado = GetTableDeudorAnalista();
            gvResultados.DataSource = dtResultado;
            gvResultados.DataBind();

        }
    }
    protected void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.cmbDeudores.Items.Clear();
        List<DeudorLivianoDataContracts> deudores = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");
        deudores = deudorServices.GetAllDeudorsLivianoPorCriterioCliente(int.Parse(this.cmbClientes.SelectedValue));
        this.cmbDeudores.DataSource = deudores;
        this.cmbDeudores.DataBind();

        
        ListItem liTodos = new ListItem("Todos", "*");
        ListItem liNinguno = new ListItem("Ninguno", "#");
        this.cmbDeudores.Items.Add(liTodos);
        this.cmbDeudores.Items.Add(liNinguno);
        this.cmbDeudores.SelectedIndex = this.cmbDeudores.Items.Count - 1;
    }
    protected DataTable gvResultados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();

        try
        {
            dataTable = this.GetTableDeudorAnalista();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;

    }
    protected void gvResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvResultados.PageIndex = e.NewPageIndex;
        this.gvResultados.Fill();
    }
    protected void gvResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //gvResultados.Rows[e.RowIndex].Cells[2].Text   Deudor
        //this.cmbAnalistas.SelectedValue               Analista
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        try
        {
            deudorServices.EliminarAnalista(int.Parse(gvResultados.Rows[e.RowIndex].Cells[1].Text), int.Parse(this.cmbAnalistas.SelectedValue));
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Eliminar Ok", "javascript:alert('Se ha eliminado correctamente el analista del deudor.');", true);
        }
        catch (Exception Ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Eliminar Fallo", "javascript:alert('Ha ocurrido un error. No se pudo eliminar el analista del deudor. Detalle tecnico: " + Ex.Message + "');", true);
        }
        gvResultados.DataSource = GetTableDeudorAnalista();
        gvResultados.DataBind();
    }
    private DataTable GetTableDeudorAnalista()
    {
        List<DeudorLivianoDataContracts> resultadosObtenidos = new List<DeudorLivianoDataContracts>();
        IDeudorLivianoService deudorServices = ServiceClient<IDeudorLivianoService>.GetService("DeudorLivianoService");

        resultadosObtenidos = deudorServices.GetAllDeudorsLivianoPorCriterioAnalista(this.cmbAnalistas.SelectedItem.Text);
        return ConvertDataTable<DeudorLivianoDataContracts>.Convert(resultadosObtenidos);
    }
    protected void btnAsignar_Click(object sender, EventArgs e)
    {        
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");

        if (this.cmbDeudores.SelectedValue != "*" && this.cmbDeudores.SelectedValue != "#")
        {
            try
            {
                deudorServices.AsignarAnalista(int.Parse(this.cmbDeudores.SelectedValue), int.Parse(this.cmbAnalistas.SelectedValue));
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Ok", "javascript:alert('Se ha asignado correctamente el analista al deudor.');", true);
            }
            catch (Exception Ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Fallo", "javascript:alert('Ha ocurrido un error. No se pudo asignar analista al deudor. Detalle tecnico: " + Ex.Message + "');", true);
            }
        }
        else
        {
            if (this.cmbDeudores.SelectedValue == "#")
            {
                try
                {
                    //deudorServices.AsignarAnalista(-1, int.Parse(this.cmbAnalistas.SelectedValue));
                    deudorServices.AsignarAnalista_Cliente(int.Parse(this.cmbClientes.SelectedValue) , -1, int.Parse(this.cmbAnalistas.SelectedValue));
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Ok", "javascript:alert('Se han desasignado todos los deudores al analista.');", true);
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Fallo", "javascript:alert('Ha ocurrido un error. No se pudo desasignar los deudores al analista. Detalle tecnico: " + Ex.Message + "');", true);
                }
            }
            else
            {
                //Ciclar por la lista de Deudores e intentar asignar uno a uno
                foreach (ListItem liItem in this.cmbDeudores.Items)
                {
                    if (liItem.Value != "*")
                    {
                        try
                        {
                            deudorServices.AsignarAnalista(int.Parse(liItem.Value), int.Parse(this.cmbAnalistas.SelectedValue));
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Ok", "javascript:alert('Se ha asignado correctamente el analista al deudor.');", true);
                        }
                        catch (Exception Ex)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Fallo", "javascript:alert('Ha ocurrido un error. No se pudo asignar analista al deudor. Detalle tecnico: " + Ex.Message + "');", true);
                        }
                    }
                }
            }
        }
        gvResultados.DataSource = GetTableDeudorAnalista();
        gvResultados.DataBind();
    }
    protected void cmbAnalistas_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvResultados.DataSource = GetTableDeudorAnalista();
        gvResultados.DataBind();
    }
}
