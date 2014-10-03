using System;
using System.Text;
using System.Web.UI;
using Gobbi.CoreServices.Context;
using Gobbi.CoreServices.Security.Authorization;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.CoreServices.Security.Role;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Clase base para las páginas de Gobbi
/// </summary>
public class GobbiPage : Page
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

    /// <summary>
    /// Método onload de la clase base
    /// </summary>
    /// <param name="e"></param>
    protected override void OnLoad(EventArgs e)
    {
        /*
         * Verifico que el usuario este logueado y que posea una session valida.
         */


        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];

        if (principal != null)
        {
            IAuthorizationProvider authorizationProvider = AuthorizationProviderFactory.GetAuthorizationProviderManager();

            string resourceID = Request.ApplicationPath.Length > 1 ?
                                    Request.Path.Substring(Request.ApplicationPath.Length) :
                                        Request.Path;

            IList<string> userResources = principal.Permissions;
           

            bool res = userResources.Contains(resourceID);



            if (res == false)
            {

                Session["NotAuthorized"] = "NotAuthorized";
                Server.Transfer("/Vistas/ViewHome.aspx", true);

            }
            else
            { Session["NotAuthorized"] = null; }

            //
        }
        else
        {

            this.ShowError("Ud. no inicio sesion en el sistema");
            this.RedirectLogin();
        }
        
        
     



        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;

            base.OnLoad(e);   
        }
        else
        {
            base.OnLoad(e);   
        }
      
             
        

        
    }

    /// <summary>
    /// Método para mandar un mensaje
    /// </summary>
    /// <param name="message"></param>
    protected void ShowAlert(string message)
    {
        string alertText = GetAlertText(message);
        ClientScript.RegisterStartupScript(GetType(), GetType().FullName + this.StartupScriptKey, string.Format("<script>{0};</script>", alertText));
        this.StartupScriptKey++;
    }

    /// <summary>
    /// Método para mostrar un error
    /// </summary>
    /// <param name="message"></param>
    protected void ShowError(string message)
    {
        message = "ERROR:\r\n\r\n" + message;
        this.ShowAlert(message);
    }

    protected void ShowAlertWithTime(string message)
    {
        // string alertText = GetAlertText(message);
        //ClientScript.RegisterStartupScript(GetType(), GetType().FullName + this.StartupScriptKey, string.Format("<script>{0};</script>", alertText));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Deudores", " setTimeout(''mensajeDeudoresGestionHoy();', 2000);", true);
        this.StartupScriptKey++;
    }

    protected void RedirectLogin()
    {
        
        string applicationLoginURL = ConfigurationManager.AppSettings["applicationLoginURL"];

        ClientScript.RegisterStartupScript(GetType(), GetType().FullName + this.StartupScriptKey, "<script>window.location='" + applicationLoginURL + "';</script>");
        this.StartupScriptKey++;
    }

    
    protected void RedirectModuleStatus()
    {
        /*
         * Obtengo del WebConfig la URL de mensajes de estado de la aplicación y redirecciono al usuario a la misma.
         */
        string applicationModuleStatusURL = ConfigurationManager.AppSettings["applicationModuleStatusURL"];

        ClientScript.RegisterStartupScript(GetType(), GetType().FullName + this.StartupScriptKey, "<script>window.location='" + applicationModuleStatusURL + "';</script>");
        this.StartupScriptKey++;
    }

  
    protected void HistoryBack()
    {
        /*
         * Hago que el usuario retroceda a la pagina de la cual venia.
         */
        ClientScript.RegisterStartupScript(GetType(), GetType().FullName + this.StartupScriptKey, "<script>history.back(1);</script>");
        this.StartupScriptKey++;
    }

    /// <summary>
    /// Método para traer el texto de la alerta
    /// </summary>
    /// <param name="message"></param>
    /// <returns>string</returns>
    protected static string GetAlertText(string message)
    {
        return string.Format("alert('{0}')", EscapeText(message));
    }

    
    /// <summary>
    /// Método para mostrar un pop up de Confimacion
    /// </summary>
    /// <param name="message"></param>
    /// <returns>string</returns>
    protected static string GetConfirmText(string message)
    {
        return string.Format("confirm('{0}')", EscapeText(message));
    }

    /// <summary>
    ///  NA
    /// </summary>
    /// <param name="text"></param>
    /// <returns>string</returns>
    private static string EscapeText(string text)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in text)
        {
            int asc = Convert.ToInt32(c);
            if (asc >= 0x28 && asc <= 0x5b)
            {
                sb.Append(c);
            }
            else if (asc >= 0x5d && asc <= 0x7e)
                {
                    sb.Append(c);
                }
            else
            {
                string hex = string.Format("{0:x}", asc);
                if (hex.Length < 2)
                {
                    hex = "0" + hex;
                }
                sb.AppendFormat("\\x" + hex);
            }
        }
        return sb.ToString();
    }
}
