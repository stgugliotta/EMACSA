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
using Common.Interfaces;
using Gobbi.services;
using Herramientas;
using Common.DataContracts;
using Common.Interfaces;

public partial class Vistas_ViewLocalizarRecibo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }


    }

    protected void gvResultados_PreRender(object sender, EventArgs e)
    {

        int cont = -1;
        foreach (GridViewRow item in gvResultados.Rows)
        {
            cont++;
            foreach (TableCell cell in item.Cells)
            {

                cell.Attributes.Add("onclick", "__doPostBack('ctl00$Contentplaceholder1$gvResultadosPagos','Edit$" + cont.ToString() + "');");



            }
        }


    }

    protected void btnBuscarPorRecibo_OnClick(object sender, EventArgs e)
    {
        List<DatosEdicionReciboDataContracts> recibos = new List<DatosEdicionReciboDataContracts>();
        IDatosEdicionReciboService datosEdicionReciboServices = ServiceClient<IDatosEdicionReciboService>.GetService("DatosEdicionReciboService");
        recibos = datosEdicionReciboServices.GetAllDatosEdicionRecibosPorNumeroRecibo(this.txtNumRecibo.Text);
        this.gvResultados.DataSource = recibos;
        this.gvResultados.DataBind();
    }

    protected void btnBuscarPorRemision_OnClick(object sender, EventArgs e)
    {
        List<DatosEdicionReciboDataContracts> recibos = new List<DatosEdicionReciboDataContracts>();
        IDatosEdicionReciboService datosEdicionReciboServices = ServiceClient<IDatosEdicionReciboService>.GetService("DatosEdicionReciboService");
        recibos = datosEdicionReciboServices.GetAllDatosEdicionRecibosPorNumeroRemision(int.Parse(this.txtNumRemision.Text));
        this.gvResultados.DataSource = recibos;
        this.gvResultados.DataBind();
    }

    protected void gvResultados_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int a;

        GridViewRow selRow = ((GridView)sender).SelectedRow;

        //Response.Redirect("ViewRemisionDeValoresEdicion.aspx?idCliente=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "ID Cliente")].Text + "&idDeudor=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "ID Deudor")].Text + "&numRecibo=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Recibo")].Text + "&idRemision=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text);

       

        try
        {

            //PdfCreator pc = new PdfCreator();
            //string pszRuta = Server.MapPath("../PDF");
            //string pszImagenes = Server.MapPath("../Images");
            GridViewRow row = ((GridView)sender).SelectedRow;
            //pc.CreaarPdf(int.Parse(row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text), pszRuta, pszImagenes);
            //Response.ContentType = "Application/pdf";
            //string filePath = MapPath("../PDF/Remision" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text + ".pdf");
            //Response.WriteFile(filePath);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.Redirect("ViewGeneracionDepositosEnExcel.aspx?idRemision=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text);
          //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentanaPequenia2('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewGeneracionPdf.aspx?idRemision=" + int.Parse(row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text) + "','_blank','scrollbars=yes');", true);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "error", "javascript:alert('Ha ocurrido un error al intentar recuperar el archivo pdf.');", true);
        }
    }


    protected void gvResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            PdfCreator pc = new PdfCreator();
            string pszRuta = Server.MapPath("../PDF");
            string pszImagenes = Server.MapPath("../Images");
            GridViewRow row = ((GridView)sender).Rows[e.NewEditIndex];
            pc.CreaarPdf(int.Parse(row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text), pszRuta, pszImagenes);
            Response.ContentType = "Application/pdf";
            string filePath = MapPath("../PDF/Remision" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text + ".pdf");
            Response.WriteFile(filePath);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.Redirect("ViewGeneracionPdf.aspx?idRemision=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentanaPequenia2('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewGeneracionPdf.aspx?idRemision=" + int.Parse(row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text) + "','_blank','scrollbars=yes');", true);

        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "error", "javascript:alert('Ha ocurrido un error al intentar recuperar el archivo pdf.');", true);
        }

    }
    protected void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToUpper().EndsWith("ESP"))
            {
            

            GridViewRow row = ((GridView) sender).Rows[0];
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.Redirect("ViewGeneracionEspecialEnExcel.aspx?idRemision=" +
                              row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text);
                }
            else
            {

                try
                {
                    PdfCreator pc = new PdfCreator();
                    string pszRuta = Server.MapPath("../PDF");
                    string pszImagenes = Server.MapPath("../Images");
                    GridViewRow row = ((GridView)sender).Rows[0];
                    pc.CreaarPdf(int.Parse(row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text), pszRuta, pszImagenes);
                    Response.ContentType = "Application/pdf";
                    string filePath = MapPath("../PDF/Remision" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text + ".pdf");
                    Response.WriteFile(filePath);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    Response.Redirect("ViewGeneracionPdf.aspx?idRemision=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text,false);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentanaPequenia2('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewGeneracionPdf.aspx?idRemision=" + int.Parse(row.Cells[UIUtils.GetPosCol(this.gvResultados, "N° Remisión")].Text) + "','_blank','scrollbars=yes');", true);

                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "error", "javascript:alert('Ha ocurrido un error al intentar recuperar el archivo pdf.');", true);
                }

            }
   
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "error", "javascript:alert('Ha ocurrido un error al intentar generar el archivo especial.');", true);
        }


    }
}
