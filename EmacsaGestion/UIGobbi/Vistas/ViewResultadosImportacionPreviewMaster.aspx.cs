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
using Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using System.Collections.Generic;



public partial class Vistas_ViewResultadosImportacionPreviewMaster : GobbiPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewResultadosImportacionPreviewMaster));
            this.txtFechaDesde.Text = DateTime.Today.ToShortDateString();

        }

    }

    private DataTable GetDataTableImportaciones()
    {


        List<ImportacionFacturaDataContracts> listaImportacionFac = ImportadorInterfaces.mostrarResultados();

        DataTable dataTable = ConvertDataTable<ImportacionFacturaDataContracts>.Convert(listaImportacionFac);

     
        return dataTable;
    }

    private DataTable GetDataTableImportacionesPorFecha()
    {
        List<ImportacionFacturaDataContracts> listaImportacionFac;
        int idCliente = int.Parse(Session["idCliente"].ToString());
        if (idCliente != null)
        {
            listaImportacionFac = ImportadorInterfaces.mostrarResultadosPorFechaPreview(idCliente, DateTime.Parse(this.txtFechaDesde.Text));
        }
        else
        {
            listaImportacionFac = new List<ImportacionFacturaDataContracts>();
        }

        DataTable dataTable = ConvertDataTable<ImportacionFacturaDataContracts>.Convert(listaImportacionFac);


        return dataTable;
    }




    protected DataTable GvResultados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            dataTable = this.GetDataTableImportaciones();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }



    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
    }
 

    protected void GvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void Exportar_Click(object sender, EventArgs e)
    {


        List<string> listaSeleccionados = new List<string>();
        DataTable dt = new DataTable();

        List<string> lista = new List<string>();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        DataTable dataTable = GvResultados_Filling(null, null);

        if (mgr.Contains(Session.SessionID + "SeleccionGrilla"))
            lista = (List<string>)mgr.GetData(Session.SessionID + "SeleccionGrilla");



        DataColumn column0 = new DataColumn("IdCliente");
        column0.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column0);

        DataColumn column1 = new DataColumn("Nombre");
        column1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column1);
        DataColumn column2 = new DataColumn("CUIT");
        column2.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column2);
        DataColumn column3 = new DataColumn("RegistrosEnviados");
        column3.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column3);
        DataColumn column4 = new DataColumn("RegistrosIngresados");
        column4.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column4);
        DataColumn column5 = new DataColumn("RegistrosRechazados");
        column5.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column5);
        DataColumn column6 = new DataColumn("DocumentosBaja");
        column6.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column6);
        DataColumn column7 = new DataColumn("FechaProceso");
        column6.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column7);


        //foreach (string dataKey in lista)
        //{
        //    if (dataTable.Select("idCliente = '" + dataKey + "'").Length > 0)
        //    {

                foreach (DataRow dr in dataTable.Select())
                {
                    dt.ImportRow(dr);
                    listaSeleccionados.Add(int.Parse(dr["idCliente"].ToString()).ToString());
                }
          //  }
        //}

        mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        if (mgr.Contains(Constants.CACHE_DOCUMENTOS_A_EXPORTAR))
        {
            mgr.Remove(Constants.CACHE_DOCUMENTOS_A_EXPORTAR);
        }
        mgr.Add(Constants.CACHE_DOCUMENTOS_A_EXPORTAR, dt);

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaPequenia('ViewExportToExcel.aspx','_blank');", true);
        this.StartupScriptKey++;


    }

    protected void GvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select") {
            Response.Redirect("ViewDetalleUltimaImportacionClientePreview.aspx?idCliente=" + this.GvResultados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text + "&fechaProceso=" +this.GvResultados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text);
        }

    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewImportacionDeFacturas.aspx");
    }
    protected void Visualizar_Click(object sender, EventArgs e)
    {
        this.GvResultados.DataSource = this.GetDataTableImportacionesPorFecha();
        this.GvResultados.DataBind();
    }
}
    
