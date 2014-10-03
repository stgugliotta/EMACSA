using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for SessionAlive
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SessionAlive : System.Web.Services.WebService
{

    public SessionAlive()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public void UpdateSession()
    {
        try
        {
            HttpContext.Current.Session["tempVariable"] = DateTime.Now;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

}

