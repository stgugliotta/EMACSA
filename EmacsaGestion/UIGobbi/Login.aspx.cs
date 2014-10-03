using System;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using Gobbi.CoreServices.Caching;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Logging;
using Gobbi.CoreServices.Security;
using Gobbi.CoreServices.Security.Authentication;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.CoreServices.Context;
using System.Web;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

/// <summary>
/// Pagina que se utiliza para loguearse
/// </summary>
public partial class _Login : Page
{
    private int startupScriptKey;

    /// <summary>
    ///  startupScriptKey property
    /// </summary>
    /// <value>int</value>
    public int StrarupScriptKey
    {
        get { return this.startupScriptKey; }
        set { this.startupScriptKey = value; }
    }
    
    /// <summary>
    /// Metodo que define la función javascript que valida que los campos Usuario y Clave no esten en blanco.
    /// </summary>
    public void Page_Load(object sender, EventArgs E)
    {
        string usedBrowser = Request.ServerVariables["HTTP_USER_AGENT"];
        if (!usedBrowser.ToUpper().Contains("CHROME"))
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "validacionDeNavegador", "javascript:alert('Esta aplicación solo puede ser ejecutada en Google Chrome.');", true);
            return;
        }

        if (!IsPostBack)
        {
            this.btnAceptar.Attributes.Add("onclick", "javascript: if (checkFormData() == false) return false;");
        }

        /*
         * Muestro la versión actual de la aplicación.
         */
        string revision = ConfigurationManager.AppSettings["AppVersion"].Replace("$", String.Empty);

        revision = revision.Replace("Rev:", String.Empty);
        revision = revision.Replace("Date:", String.Empty);
        revision = revision.Replace(revision.Substring(revision.IndexOf("-0500", 1), revision.Length - revision.IndexOf("-0500", 1)), String.Empty);

        lblAppVersion.Text = revision.ToString();
    }
    
    /// <summary>
    /// Método que realiza la autenticacion del usuario
    /// Si las credenciales son correctas se genera el objeto EvaPrincipal con la información del usuario
    /// </summary>
    protected void BtnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            string usedBrowser = Request.ServerVariables["HTTP_USER_AGENT"];
            if (!usedBrowser.ToUpper().Contains("CHROME"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "validacionDeNavegador", "javascript:alert('Esta aplicación solo puede ser ejecutada en Google Chrome.');", true);
                return;
            }
            string authenticatorManagerName = ConfigurationManager.AppSettings["AuthenticatorManagerName"];

            // Obtiene el proveedor de autenticación
            IAuthenticationProvider authprovider;

            authprovider = AuthenticationProviderFactory.GetAuthenticationProviderManager(authenticatorManagerName);

            // Ejecuta la operación de autenticación


            Gobbi.CoreServices.Security.Principal.GobbiIdentity identity = authprovider.ValidateUserGobbi(txtUsuario.Text, txtClave.Text);


            if (identity != null)
            {
                
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(txtUsuario.Text, true, int.Parse(ConfigurationManager.AppSettings["CookieTimeOut"]));

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                string path = authTicket.CookiePath;
                Response.Cookies.Add(authCookie);

                // Genera el principal para el usuario y lo deja como información de sesión
                GobbiPrincipal principal = new GobbiPrincipal(identity);
                Gobbi.CoreServices.Security.Authorization.IAuthorizationProvider authorizationProvider = Gobbi.CoreServices.Security.Authorization.AuthorizationProviderFactory.GetAuthorizationProviderManager();
                IList<Gobbi.CoreServices.Security.Authorization.GobbiResource> resources = authorizationProvider.GetAllAuthorizedResource(principal);
                IList<string> permissions = new List<string>();
                foreach (Gobbi.CoreServices.Security.Authorization.GobbiResource item in resources)
                {
                    permissions.Add(item.FullPath);
                }

                principal.Permissions = permissions;

                Session["UserPrincipal"] = principal;

                // Redirecciona a la página original                
                LogEntry logEntry=new LogEntry();
                logEntry.MachineName = Request.UserHostName;
                logEntry.Message = "Inicio de Sesion de: " + principal.Identity.Name;
                logEntry.TimeStamp = DateTime.Now;
                logEntry.Title = "Inicio de Sesion";
                logEntry.UserName = principal.Identity.Name;
                Gobbi.CoreServices.Logging.Logger.WriteSync(logEntry);


                CultureInfo culture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
                culture = new CultureInfo("es-AR");
                
                //culture.NumberFormat.NumberDecimalSeparator = ".";
                //culture.NumberFormat.NumberGroupSeparator = ",";
                Thread.CurrentThread.CurrentCulture = culture;
                //Thread.CurrentThread.CurrentUICulture = culture;


                FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, true);
            }
            else
            {
                MessageBoxAlert("Usuario o clave incorrecta");
            }

        }
        catch (Exception ex)
        {
            MessageBoxAlert("Se ha Producido el siguiente error: " + ex.Message);
        }

                
    }

    protected void MessageBoxAlert(string msg)
    {
        string str = "<SCRIPT language='javascript'>alert('" + msg + "');</SCRIPT>";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBoxAlert", str);
    }
}
