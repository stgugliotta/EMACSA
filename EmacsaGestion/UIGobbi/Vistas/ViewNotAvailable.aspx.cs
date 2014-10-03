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

public partial class Default2 : System.Web.UI.Page 
{

    /// <summary>
    /// Varaible privada para las key
    /// </summary>
    private int startupscriptkey;

    /// <summary>
    /// Key 
    /// </summary>
    /// <value>int</value>
    protected int StartupScriptKey
    {
        get { return this.startupscriptkey; }
        set { this.startupscriptkey = value; }
    }


    public void Page_Load(object sender, EventArgs e)
    {

        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }
       

        
        string accessControl = Session["NotAuthorized"]!=null ? Session["NotAuthorized"].ToString() : "";

        if (accessControl == "NotAuthorized")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), GetType().FullName + "ResourceNotAuthorized" + this.StartupScriptKey, "alert('No tiene permisos para acceder a éste recurso.')", true);
            Session["NotAuthorized"] = null;
            ClientScript.RegisterStartupScript(GetType(), GetType().FullName + this.StartupScriptKey, "<script>history.back(1);</script>");
            this.StartupScriptKey++;
        }

    }
}
