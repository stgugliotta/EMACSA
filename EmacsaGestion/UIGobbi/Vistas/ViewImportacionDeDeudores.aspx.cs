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


public partial class Vistas_ViewImportacionDeDeudores : GobbiPage
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

            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewImportacionDeDeudores));
            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            List<ClienteDataContracts> clientesFiltrados = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            clientes = clienteServices.GetClientesInterfaces();
            clientesFiltrados = clientes.FindAll(x => !x.NOMBRE.Contains("*"));
            this.cmbClientes.DataSource = clientesFiltrados;
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

            String idCliente = this.cmbClientes.SelectedValue;
            FileUpload fileUploaded = this.archivo;
            lblResultado.Text = "";

            string nombreCliente = ((System.Web.UI.WebControls.ListControl)(this.cmbClientes)).SelectedItem.ToString();

            if (!archivo.FileName.Contains(nombreCliente.Replace("** ", "")))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "archivoInvalido", "javascript:alert('No concide el nombre del archivo con el cliente seleccionado. Verifique por favor que este escogiendo el archivo correcto. (Debería llamarse: " + nombreCliente.Replace("** ", "") + ".xls)');", true);
                return;
            }


            ImportadorInterfaces.importarDeudores(idCliente, archivo.FileName, fileUploaded.FileBytes);


            lblResultado.Text = "Se ha enviado el archivo con éxito";
            
        }
        catch (Exception ex)
        {

            lblResultado.Text = "Ha ocurrido un error durante la importación de deudores. " + "\n" + ex.Message;
        }

    }

    private void abrirPopup()
    {

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentana('ViewResultadosImportacion.aspx','_blank');", true);
    }

    private Boolean hayRechazos(List<ImportacionFacturaDataContracts> resultado)
    {
        Boolean retval = false;


        foreach (ImportacionFacturaDataContracts importacionFactura in resultado)
        {

            if (Int32.Parse(importacionFactura.RegistrosRechazados) > 0)
            {
                retval = true;
                break;
            }
        }


        return retval;
    }
    protected void btnResultados_Click(object sender, EventArgs e)
    {
        GoogleMapsHelper gmHelper = new GoogleMapsHelper();
        gmHelper.getGeocodeResponse("San+Juan,3148,Buenos+Aires");
        Response.Redirect("ViewResultadosImportacion.aspx");

    }
}

