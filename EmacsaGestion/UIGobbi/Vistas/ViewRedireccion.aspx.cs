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

public partial class Vistas_ViewRedireccion : System.Web.UI.Page
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
        string route = Request.Params["route"].ToString();

        switch (route)
        {
                
           case "Route1":{
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentana2('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewHistorialFacturas.aspx" + "','viewHistorialFacturas',800,700);", true);
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ReAbrirHome", "javascript:document.location='ViewHome.aspx'", true);
               
          
                     break;
                     }

           case "Route2":
               {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentana2('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewHistorialDelDeudor.aspx" + "','viewHistorialDelDeudor',930,500);", true);
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ReAbrirHome", "javascript:document.location='ViewHome.aspx'", true);


                   break;
               }
           case "Route3":
               {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentana3('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewLocalizarFactura.aspx" + "','viewLocalizarFactura',660,410);", true);
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ReAbrirHome", "javascript:document.location='ViewHome.aspx'", true);
                   break;
               }
           case "Route4":
               {
                   Response.Redirect("http://www.streambe-track.com.ar/emacsa"); 
                   break;
               }
           default:
                    {
                    Response.Redirect("ViewHome.aspx");
                    break;
                    }
        }
        }
    }
}
