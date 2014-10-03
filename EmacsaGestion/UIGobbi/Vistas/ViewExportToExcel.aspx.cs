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
using Gobbi.CoreServices.Caching;
using Gobbi.CoreServices.Caching.CacheManagers;


public partial class Vistas_ViewExportToExcel : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }


        DataTable dt = new DataTable();

 
        try
        {
            dt = (DataTable)Session["CACHE_DOCUMENTOS_A_EXPORTAR"];
            System.IO.File.Delete(Server.MapPath("Files\\ResultadoDocumentos.xls"));

            if (dt!=null)
            {
            
            ExcelXmlWriter.ExcelExport.Generate(Server.MapPath(".") + "\\Files\\ResultadoDocumentos.xls", dt);


            Response.ClearContent();
            Response.AppendHeader("content-disposition", "inline;filename=ResultadoDocumentos.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.TransmitFile("/Vistas/Files/ResultadoDocumentos.xls");
            Response.Flush();
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            //Loguear esto.
        }

    }
}
