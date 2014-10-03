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
using System.Collections.Generic;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Interfaces;

public partial class Vistas_HistorialDelDeudor : GobbiPage 
{    
    protected void Page_Load(object sender, EventArgs e)
    {

         if (!IsPostBack)
        {
            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            clientes = clienteServices.GetAllClientes();
            this.cmbClientes.DataSource = clientes;
            this.cmbClientes.DataTextField = "NOMBRE";
            this.cmbClientes.DataValueField = "idCliente";
            this.cmbClientes.DataBind();

            DeudorDataContracts oDeudor = new DeudorDataContracts();
            IDeudorService deudorService = ServiceClient<IDeudorService>.GetService("DeudorService");
            if (Request.QueryString["id_deudor"]!=null)
            {
                oDeudor = deudorService.GetDeudor(int.Parse(Request.QueryString["id_deudor"]));
                lblDeudor.Text = oDeudor.Nombre;
            }
           
            this.cmbDeudores.Items.Add(new ListItem("--- TODOS ---","0"));
            if (Request.QueryString["origen"]=="gestionAnalista")
                        TraerHistorial();
        }                
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        IFacturaHistorialDeudorService facturaService = ServiceClient<IFacturaHistorialDeudorService>.GetService("FacturaHistorialDeudorService");
        List<FacturaHistorialDeudorDataContracts> facturas = new List<FacturaHistorialDeudorDataContracts>();
          
        if (this.cmbDeudores.SelectedItem.Text == "--- TODOS ---")
            facturas = facturaService.GetAllFacturasPorIdClienteEntreFechas(int.Parse(this.cmbClientes.SelectedValue), DateTime.Parse(this.txtFechaDesde.Text), DateTime.Parse(this.txtFechaHasta.Text));
        else
            facturas = facturaService.GetAllFacturasPorIdDeudorEntreFechas(int.Parse(this.cmbDeudores.SelectedValue), DateTime.Parse(this.txtFechaDesde.Text), DateTime.Parse(this.txtFechaHasta.Text));
        gvFacturas.DataSource = facturas;
        gvFacturas.DataBind();
    }


    private void TraerHistorial()
    {
        IFacturaHistorialDeudorService facturaService = ServiceClient<IFacturaHistorialDeudorService>.GetService("FacturaHistorialDeudorService");
        List<FacturaHistorialDeudorDataContracts> facturas = new List<FacturaHistorialDeudorDataContracts>();

        facturas = facturaService.GetAllFacturasPorIdDeudorEntreFechas(int.Parse(Request.QueryString["id_deudor"]), DateTime.Now.AddDays(-90),DateTime.Now);
        gvFacturas.DataSource = facturas;
        gvFacturas.DataBind();
    }


    protected void gvFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }

    protected void rdoFechas_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaDesde.Enabled = txtFechaHasta.Enabled = true;

    }

    protected void rdoIdFactura_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaDesde.Enabled = txtFechaHasta.Enabled = false;

    }

    private string ObtenerHistorial(int idFactura)
    {
        List<LOG_FacturaDataContracts> resultadoObtenidos = new List<LOG_FacturaDataContracts>();
        ILOG_FacturaService logFacturaServices = ServiceClient<ILOG_FacturaService>.GetService("LOG_FacturaService");
        resultadoObtenidos = logFacturaServices.GetAllLogFacturasByIdFactura(idFactura);

        string ResHistorial = "";
        foreach (LOG_FacturaDataContracts item in resultadoObtenidos)
        {
            ResHistorial += item.FechaActividad.ToString() + " - ( " + item.Usuario + "): " + item.Observacion + "<br />";
        }

        return ResHistorial;
    }

    protected void NumericValidator_ServerValidate(Object source, ServerValidateEventArgs args)
    {
        string numero = args.Value;
        RegexStringValidator gsv = new RegexStringValidator(@"^[0-9]*$");
        if (numero == null || numero.Length == 0)
        {
            args.IsValid = false;
            return;
        }

        try
        {
            gsv.Validate(numero);
        }
        catch (ArgumentException aex)
        {
            args.IsValid = false;
            return;
        }

        args.IsValid = true;
    }

      

protected void  cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
{
    List<DeudorDataContracts> resultadoObtenidos = new List<DeudorDataContracts>();
    IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
    resultadoObtenidos = deudorServices.GetAllDeudorsPorCriterioCliente(int.Parse(this.cmbClientes.SelectedItem.Value));
    DeudorDataContracts seleccion = new DeudorDataContracts();
    seleccion.Nombre = "--- TODOS ---";
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
}
