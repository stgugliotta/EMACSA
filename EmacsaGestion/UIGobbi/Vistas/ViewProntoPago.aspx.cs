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

public partial class Vistas_ViewProntoPago : GobbiPage 
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
            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewProntoPago));

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
            ListItem liTodos = new ListItem("Todos", "*");
            this.cmbDeudores.Items.Add(liTodos);
            this.cmbDeudores.SelectedIndex = this.cmbDeudores.Items.Count;

           // CargarPorcentajes();

            DataTable dtResultado = GetTableProntoPagoPorCliente();
            gvResultados.DataSource = dtResultado;
            gvResultados.DataBind();
            this.txtPorcentaje.Text = "0";
        }

    }
    protected void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.cmbDeudores.Items.Clear();
        List<DeudorDataContracts> deudores = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        deudores = deudorServices.GetAllDeudorsPorCriterioCliente(int.Parse(this.cmbClientes.SelectedValue));
        this.cmbDeudores.DataSource = deudores;
        this.cmbDeudores.DataBind();

        ListItem liTodos = new ListItem("Todos", "*");
        this.cmbDeudores.Items.Add(liTodos);
        this.cmbDeudores.SelectedIndex = this.cmbDeudores.Items.Count - 1;

        DataTable dtResultado = GetTableProntoPagoPorCliente();
        gvResultados.DataSource = dtResultado;
        gvResultados.DataBind();

    }
    protected void cmbDeudores_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbDeudores.SelectedValue != "*")
        {
            DataTable dtResultado = GetTableProntoPago();
            gvResultados.DataSource = dtResultado;
            gvResultados.DataBind();
        }
        else
        {
            DataTable dtResultado = GetTableProntoPagoPorCliente();
            gvResultados.DataSource = dtResultado;
            gvResultados.DataBind();
        }
    }
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        //Reemplazar IProntoPagoService por el que corresponda con la clase

        IProntoPagoService prontopagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
        ProntoPagoDataContracts prontopago = new ProntoPagoDataContracts();
        if (this.cmbDeudores.SelectedValue != "*")
        {
            try
            {
                prontopago.IdDeudor = int.Parse(this.cmbDeudores.SelectedValue);
                prontopago.IdCliente = int.Parse(this.cmbClientes.SelectedValue);
                prontopago.DiasDeAnticipacion = int.Parse(this.txtDiasAnticipacion.Text);
                prontopago.PorcentajeAplicacion = double.Parse(this.txtPorcentaje.Text);
                prontopago.Activo = this.chkActivo.Checked;

                prontopagoServices.Insert(prontopago);

                if (cmbDeudores.SelectedValue != "*")
                {
                    DataTable dtResultado = GetTableProntoPago();
                    gvResultados.DataSource = dtResultado;
                    gvResultados.DataBind();
                }
                else
                {
                    DataTable dtResultado = GetTableProntoPagoPorCliente();
                    gvResultados.DataSource = dtResultado;
                    gvResultados.DataBind();
                }
                //cmbDeudores_SelectedIndexChanged(null, null);
                

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Ok", "javascript:alert('Se ha creado correctamente el pronto pago.');", true);
            }
            catch (Exception Ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Fallo", "javascript:alert('Ha ocurrido un error. No se pudo crear el pronto pago. Detalle tecnico: " + Ex.Message + "');", true);
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
                        prontopago.IdDeudor = int.Parse(liItem.Value);
                        prontopago.IdCliente = int.Parse(this.cmbClientes.SelectedValue);
                        prontopago.DiasDeAnticipacion = int.Parse(this.txtDiasAnticipacion.Text);
                        prontopago.PorcentajeAplicacion = double.Parse(this.txtPorcentaje.Text);

                        prontopago.Activo = this.chkActivo.Checked;

                        prontopagoServices.Insert(prontopago);
                                                
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Ok", "javascript:alert('Se ha creado correctamente el pronto pago.');", true);
                    }
                    catch (Exception Ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Insert Fallo", "javascript:alert('Ha ocurrido un error. No se pudo crear el pronto pago. Detalle tecnico: " + Ex.Message + "');", true);
                    }
                }
            }
        }
        LimpiarDatos();
    }
    private DataTable GetTableProntoPago()
    {
        List<ProntoPagoDataContracts> resultadosObtenidos = new List<ProntoPagoDataContracts>();
        IProntoPagoService prontopagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
        if (this.cmbDeudores.SelectedValue != "*")
            resultadosObtenidos = prontopagoServices.GetAllProntoPagosByIdClienteYIdDeudor(int.Parse(this.cmbClientes.SelectedValue), int.Parse(this.cmbDeudores.SelectedValue));
        else
            resultadosObtenidos = prontopagoServices.GetAllProntoPagosByIdCliente(int.Parse(this.cmbClientes.SelectedValue));
        return ConvertDataTable<ProntoPagoDataContracts>.Convert(resultadosObtenidos);
    }
    private DataTable GetTableProntoPagoPorCliente()
    {
        List<ProntoPagoDataContracts> resultadosObtenidos = new List<ProntoPagoDataContracts>();
        IProntoPagoService prontopagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");

        resultadosObtenidos = prontopagoServices.GetAllProntoPagosByIdCliente(int.Parse(this.cmbClientes.SelectedValue));
        return ConvertDataTable<ProntoPagoDataContracts>.Convert(resultadosObtenidos);
    }
    protected DataTable gvResultados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();

        try
        {
            dataTable = this.GetTableProntoPago();

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
        IProntoPagoService prontopagoServices = ServiceClient<IProntoPagoService>.GetService("ProntoPagoService");
        try
        {
            prontopagoServices.EliminarPorId(Convert.ToInt32(gvResultados.DataKeys[e.RowIndex].Value));
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Eliminar Ok", "javascript:alert('Se ha eliminado correctamente el pronto pago.');", true);
        }
        catch (Exception Ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Eliminar Fallo", "javascript:alert('Ha ocurrido un error. No se pudo eliminar el pronto pago. Detalle tecnico: " + Ex.Message + "');", true);
        }
        gvResultados.DataSource = GetTableProntoPago();
        gvResultados.DataBind();
    }
    private void LimpiarDatos()
    {
        //this.cmbClientes.SelectedIndex = 0;
        //this.cmbDeudores.SelectedIndex = 0;
        //this.txtDiasAnticipacion.Text = "";
        //this.txtPorcentaje.Text= "0";
        //this.chkActivo.Checked = true;
        //this.gvResultados.DataSource = null;
        //this.gvResultados.DataBind();
    }
}
