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
using Common.DataContracts;

public partial class Vistas_ViewExportToExcelHDRDSG : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        try
        {
            HojaDeRutaExcelDataContracts hr = (HojaDeRutaExcelDataContracts)Session["CACHE_HOJADERUTADSG_A_EXPORTAR"];
            System.IO.File.Delete(Server.MapPath("Files\\HojaDeRuta.xls"));

            if (hr != null)
            {

                ExcelXmlWriter.ExcelExport.GenerateDSG(Server.MapPath(".") + "\\Files\\HojaDeRuta.xls", hr);


            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment;filename=HojaDeRuta.xls");
            //Response.ContentType = "application/vnd.ms-excel";

            Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.WriteFile("/Vistas/Files/HojaDeRuta.xls");
            Response.Charset = "";
            Response.Flush();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorExcel", "javascript:alert('Ha ocurrido un error al intentar generar el archivo Excel. Detalle Técnico:  " + ex.Message +"');", true);
        }

    }
}
