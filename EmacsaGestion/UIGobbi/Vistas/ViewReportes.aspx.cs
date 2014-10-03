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
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using System.Text;
using System.Collections.Generic;



public partial class ViewReportes : GobbiPage 
{
    private List<ReporteDataContracts> _listaReportes;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        if (!Page.IsPostBack)
        {
            if (this.ddlListadoDeReportes.Items.Count == 0)
            {
                _listaReportes = new List<ReporteDataContracts>();
                CargarddlReportesDisponibles();
            }

        }
    }
    private void CargarddlReportesDisponibles()
    {

        try
        {
            ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
            List<ReporteDataContracts> listaReportes;
            List<ReporteDataContracts> listaReportesIntranet=new List<ReporteDataContracts>();
            List<ReporteDataContracts> listaReportesInternet=new List<ReporteDataContracts>();

            listaReportes = (List<ReporteDataContracts>)mgr.GetData(Session.SessionID + Constants.CACHE_LISTADOREPORTES);
            if (listaReportes == null)
            {
                IReporteService reporteServices = ServiceClient<IReporteService>.GetService("ReporteService");


                listaReportes = reporteServices.GetAllReportes();

                mgr.Add(Session.SessionID + Constants.CACHE_LISTADOREPORTES, listaReportes);
            }
            _listaReportes = listaReportes;



            foreach (var reporteDataContractse in listaReportes)
            {
                if (reporteDataContractse.Ubicacion=="intranet")
                {
                    listaReportesIntranet.Add(reporteDataContractse);
                }
                else
                {
                    listaReportesInternet.Add(reporteDataContractse);
                }
            }

            this.ddlListadoDeReportes.DataSource = listaReportesIntranet;
            this.ddlListadoDeReportes.DataTextField = "Nombre";
            this.ddlListadoDeReportes.DataValueField = "Id";
            this.ddlListadoDeReportes.DataBind();
            this.ddlListadoDeReportesExsternos.DataSource = listaReportesInternet;
            this.ddlListadoDeReportesExsternos.DataTextField = "Nombre";
            this.ddlListadoDeReportesExsternos.DataValueField = "Id";
            this.ddlListadoDeReportesExsternos.DataBind();

        }
        catch (Exception ex)
        {
           // this.ShowError(ex.Message);
        }

    }


    protected void VisualizarReporte_Click(object sender, EventArgs e)
    {
        ReporteDataContracts reporteSeleccionado = new ReporteDataContracts();
        IReporteService reporteServices = ServiceClient<IReporteService>.GetService("ReporteService");

        string valueReport = "";
        if (this.reportesInternos.Checked)
        {
            valueReport = this.ddlListadoDeReportes.SelectedItem.Value;
            reporteSeleccionado = reporteServices.GetReporte(short.Parse(valueReport));
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaWithScroll('" + BuildUrl(reporteSeleccionado) + "','_blank');", true);
        }
        else
        {
            valueReport = this.ddlListadoDeReportesExsternos.SelectedItem.Value;
            reporteSeleccionado = reporteServices.GetReporte(short.Parse(valueReport));
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaWithScroll('" + reporteSeleccionado.UrlComun + "','_blank');", true);
        }
    }



    private string BuildUrl(ReporteDataContracts reporte)
    {

        StringBuilder sb = new StringBuilder();
        StringBuilder sbEncode = new StringBuilder();

        sb.Append(reporte.UrlComun);

        //sb.Append(reporte.Adicional);
        sbEncode.Append(reporte.Directorio);
        sbEncode.Append(reporte.NombreFisico);


        return sb.ToString() + Server.UrlEncode(sbEncode.ToString());
    }

    protected void ddlListadoDeReportes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlListadoDeReportes_TextChanged(object sender, EventArgs e)
    {

    }

    protected void reportesInternos_CheckedChanged(object sender, EventArgs e)
    {
        this.reportesExternos.Checked = false;
        this.ddlListadoDeReportes.Enabled = true;
        this.ddlListadoDeReportesExsternos.Enabled = false;

    }


    protected void reportesExternos_CheckedChanged(object sender, EventArgs e)
    {
       
        this.reportesInternos.Checked = false;
            this.ddlListadoDeReportes.Enabled = false;
        this.ddlListadoDeReportesExsternos.Enabled = true;

    }
}
