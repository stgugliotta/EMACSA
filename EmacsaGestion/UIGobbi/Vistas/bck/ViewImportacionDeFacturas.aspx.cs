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
using GoogleMaps;
using System.Net;
using System.IO;

public partial class Vistas_ViewImportacionDeFacturas : GobbiPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        ConfigurationLoader.configuracionXML = Server.MapPath("..\\InterfacesConfiguration.xml");
           
        if (!Page.IsPostBack)
        {

            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewImportacionDeFacturas));


            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            clientes = clienteServices.GetClientesInterfaces();
            this.cmbClientes.DataSource = clientes;
            this.cmbClientes.DataTextField = "NOMBRE";
            this.cmbClientes.DataValueField = "idCliente";
            this.cmbClientes.DataBind();

        }

    }


    protected void Visualizar_Click(object sender, EventArgs e)
    {

        lblResultado.Text = "";

        try
        {

            IConfigurationService configurationServices = ServiceClient<IConfigurationService>.GetService("ConfigurationService");

            String idCliente = this.cmbClientes.SelectedValue;
            //FileUpload fileUploaded = this.archivo;
            lblResultado.Text = "";
           
            //List<ImportacionFacturaDataContracts> resultado = ImportadorInterfaces.importar("Facturas", idCliente,
            //                               fileUploaded.PostedFile.ContentType,
            //                               archivo.FileName,
            //                               fileUploaded.FileBytes);


            lblResultado.Text = "Se ha enviado el archivo con éxito";

            for (int i = 0; i < 9999999; i++)
            {
                if (i==1000)
                i = 0;
            }

            //if (hayRechazos(resultado)) { 

            //    // levantar popup con resultados
            //    lblResultado.Text = "Existen rechazos en la importación";
            //    Response.Redirect("ViewResultadosImportacionMaster.aspx",false);
            //   // abrirPopup();

            //}

        }
        catch (Exception ex) {

            lblResultado.Text = "Ha ocurrido un error durante la importación de facturas. " + "\n" + ex.Message;
        }
        
    }
    private void abrirPopup() {

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentana3('ViewResultadosImportacion.aspx','_blank',830,350);", true);
    }
    private Boolean hayRechazos(List<ImportacionFacturaDataContracts> resultado ) {
        Boolean retval = false;

        
        foreach (ImportacionFacturaDataContracts importacionFactura in resultado) {

            if (Int32.Parse( importacionFactura.RegistrosRechazados) > 0 ) {
                retval = true;
                break;
            }
        }


        return retval;
    }
    protected void btnResultados_Click(object sender, EventArgs e)
    {
        //List<IDictionary<string, string>> dicResultado = ImportadorInterfaces.mostrarResultados();

        GoogleMapsHelper gmHelper = new GoogleMapsHelper();
        gmHelper.getGeocodeResponse("San+Juan,3148,Buenos+Aires");

       // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentana3('ViewResultadosImportacion.aspx','_blank',830,350);", true);
       Response.Redirect("ViewResultadosImportacionMaster.aspx");

    }
    protected void btnDescargarResultados_Click(object sender, EventArgs e)
    {
        WebClient webClient = new WebClient();
        try
        {

        
        string fileName = (this.cmbClientes.SelectedItem.Text.Contains("*")) ? "FormatoGenerico.xls" : this.cmbClientes.SelectedItem.Text + ".xls";
        string curFile = @"c:\Pub\Templates\" + fileName;
        if (!File.Exists(curFile))
            throw new Exception();

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.Flush();
        Response.WriteFile("/Templates/" + fileName);
        Response.End();

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('No se encontró un archivo con el formato específicado. Reclámelo por favor o ingrese los datos en un formato genérico. (**)');", true);
        }

    }
}
    
