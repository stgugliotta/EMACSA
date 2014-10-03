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

public partial class Vistas_ViewHistorialFacturasPorDeudor : GobbiPage 
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
            if (Request.QueryString["id_deudor"]==null)
            {

                rdoFechas.Checked = false;
                rdoFechas.Enabled = false;
                rdoIdFactura.Enabled = true;
                rdoIdFactura.Checked = true;
                this.txtFechaDesde.Enabled = false;
                this.txtFechaHasta.Enabled = false;
            }

            DeudorDataContracts oDeudor = new DeudorDataContracts();
            IDeudorService deudorService = ServiceClient<IDeudorService>.GetService("DeudorService");
            if (Request.QueryString["id_deudor"]!=null)
            {
                oDeudor = deudorService.GetDeudor(int.Parse(Request.QueryString["id_deudor"]));
                lblDeudor.Text = oDeudor.Nombre;
            }
        }                
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {        
        IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
        List<FacturaDataContracts> facturas = new List<FacturaDataContracts>();
        if (rdoFechas.Checked == true)
        {
            facturas = facturaService.GetAllFacturasPorIdDeudorEntreFechas(int.Parse(Request.QueryString["id_deudor"]), DateTime.Parse(this.txtFechaDesde.Text), DateTime.Parse(this.txtFechaHasta.Text));

        }
        else
        if(rdoIdFactura.Checked == true)
        {
            FacturaDataContracts factura = new FacturaDataContracts();
            factura.NumFacturaCompleto  = this.txtIdFactura.Text;
            facturas = facturaService.GetAllFacturasByNumeroCompleto(factura);

        }

        gvFacturas.DataSource = facturas;
        gvFacturas.DataBind();
    }

    protected void gvFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Table tblDetalles = (Table)e.Row.FindControl("tblDetalles");
            TableRow trObs = new TableRow();
            TableCell tcObsHeader = new TableCell();
            tcObsHeader.Style.Add("font-weight", "bold");
            tcObsHeader.Text = "Observaciones:";
            tcObsHeader.HorizontalAlign = HorizontalAlign.Left;
            trObs.Cells.Add(tcObsHeader);
            TableCell tcObs = new TableCell();
            tcObs.Text = e.Row.Cells[5].Text;            
            trObs.Cells.Add(tcObs);
            tblDetalles.Rows.Add(trObs);
            TableRow trHistorial = new TableRow();
            TableCell tcHistorialHeader = new TableCell();
            tcHistorialHeader.Style.Add("font-weight", "bold");
            tcHistorialHeader.Text = "Historial:";
            tcHistorialHeader.HorizontalAlign = HorizontalAlign.Left;
            trHistorial.Cells.Add(tcHistorialHeader);
            
            tblDetalles.Rows.Add(trHistorial);
            trHistorial = new TableRow();
            TableCell tcHistorial = new TableCell();
            tcHistorial.Text = ObtenerHistorial(int.Parse(e.Row.Cells[1].Text));
            trHistorial.Cells.Add(tcHistorial);
            tcHistorial.HorizontalAlign = HorizontalAlign.Left;
            tblDetalles.Rows.Add(trHistorial);
            tblDetalles.Style.Add("width", "400px");
        }
        e.Row.Cells[5].Visible = false;
    }

    protected void rdoFechas_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaDesde.Enabled = txtFechaHasta.Enabled = true;
        txtIdFactura.Enabled = false;
    }

    protected void rdoIdFactura_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaDesde.Enabled = txtFechaHasta.Enabled = false;
        txtIdFactura.Enabled = true;
    }

    private string ObtenerHistorial(int idFactura)
    {
        List<LOG_FacturaDataContracts> resultadoObtenidos = new List<LOG_FacturaDataContracts>();
        ILOG_FacturaService logFacturaServices = ServiceClient<ILOG_FacturaService>.GetService("LOG_FacturaService");
        resultadoObtenidos = logFacturaServices.GetAllLogFacturasByIdFactura(idFactura);

        string ResHistorial = "";
        foreach (LOG_FacturaDataContracts item in resultadoObtenidos)
        {
            //ResHistorial += "Fecha Actividad: " + item.FechaActividad.ToString() + " - Usuario: " + item.Usuario + " - Actividad: " + item.Observacion + "<br />";
            ResHistorial += item.FechaActividad.ToString() + " - ( " + item.Usuario + "): " + item.Observacion + "<br />";
        }

        return ResHistorial;
    }

    protected void NumericValidator_ServerValidate(Object source, ServerValidateEventArgs args)
    {
        //string numero = args.Value;
        //RegexStringValidator gsv = new RegexStringValidator(@"^[0-9]*$");
        //if (numero == null || numero.Length == 0)
        //{
        //    args.IsValid = false;
        //    return;
        //}

        //try
        //{
        //    gsv.Validate(numero);
        //}
        //catch (ArgumentException aex)
        //{
        //    args.IsValid = false;
        //    return;
        //}

        //args.IsValid = true;
    }

}
