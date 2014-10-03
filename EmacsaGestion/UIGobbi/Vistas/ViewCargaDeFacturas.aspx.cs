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
using Security;
using Interfaces;
using GoogleMaps;
using System.Net;
using System.IO;

public partial class Vistas_ViewCargaDeFacturas : System.Web.UI.Page 
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



        this.Title = "Emacsa Gestión";
        
        string accessControl = Session["NotAuthorized"]!=null ? Session["NotAuthorized"].ToString() : "";

        if (accessControl == "NotAuthorized")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), GetType().FullName + "ResourceNotAuthorized" + this.StartupScriptKey, "alert('No tiene permisos para acceder a éste recurso.')", true);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), GetType().FullName + "ResourceNotAuthorized", " setTimeout('alert('No tiene permisos para acceder a éste recurso.')', 2000);", true);
            Session["NotAuthorized"] = null;
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "cerrarPanelProntoPago", "javascript:PopupSinRecursoConTiempo();", true);
            ClientScript.RegisterStartupScript(GetType(), GetType().FullName + this.StartupScriptKey, "<script>history.back(1);</script>");
            this.StartupScriptKey++;
            
            

        }



        //try
        //{

        //    IConfigurationService configurationServices = ServiceClient<IConfigurationService>.GetService("ConfigurationService");

        //    String idCliente = this.cmbClientes.SelectedValue;
        //    FileUpload  fileUploaded = this.archivo;
        //    lblResultado.Text = "";

        //    List<ImportacionFacturaDataContracts> resultado = ImportadorInterfaces.importar("Facturas", idCliente,
        //                                   fileUploaded.PostedFile.ContentType,
        //                                   archivo.FileName,
        //                                   fileUploaded.FileBytes);



        //    if (hayRechazos(resultado))
        //    {

        //        // levantar popup con resultados
        //        lblResultado.Text = "Existen rechazos en la importación";
        //        Response.Redirect("ViewResultadosImportacionMaster.aspx", false);
        //        // abrirPopup();

        //    }

        //}
        //catch (Exception ex)
        //{

        //    lblResultado.Text = "Ha ocurrido un error durante la importación de facturas. " + "\n" + ex.Message;
        //}





    }
}
