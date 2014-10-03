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
using Gobbi.CoreServices.Logging;
using Gobbi.CoreServices.Security.Principal;

public partial class Vistas_ViewLogOut : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        
        LogEntry logEntry = new LogEntry();
        logEntry.MachineName = Request.UserHostName;
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        if (principal != null) { 
            logEntry.Message = "Cierre de Sesion de: " + principal.Identity.Name;
            logEntry.TimeStamp = DateTime.Now;
            logEntry.Title = "Cierre de Sesion";
            logEntry.UserName = principal.Identity.Name;
            Gobbi.CoreServices.Logging.Logger.WriteSync(logEntry);
        }
        Session["UserPrincipal"] = null;
        Response.Cookies.Remove("Login");
        Session.RemoveAll();

        Response.Redirect("http://" + Request.ServerVariables["SERVER_NAME"] + "/Login.aspx");
        
    }
}
