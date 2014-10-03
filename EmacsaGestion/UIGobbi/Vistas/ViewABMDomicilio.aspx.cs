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
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using GoogleMaps;
using Herramientas;
using System.Reflection;
using Implementation;

public partial class Vistas_ViewABMDomicilio : GobbiPage
{
    private String idCliente;
    private String idDeudorInterfaz;
    private String idDeudor;
    private GoogleMapsHelper gmHelper = new GoogleMapsHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.idDeudor = Request.QueryString["Id_Deudor"];
        Boolean connectionAvailable = gmHelper.isInternetConnectionAvailable();
        this.btnDomicilioGeolocalizado.Visible = connectionAvailable;
        this.GoogleMapForASPNet1.Visible = connectionAvailable;

        this.cmbGeoLocations.Visible = connectionAvailable;
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey =
            "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSQ_lADAv5p0VmRdVhcfwwibzpHABRQwumzEz63WA9g7AUiLBfzRk2vkQ";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey =
            "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxTfJTOit7cTdNyZi0-3rP_yLyCMghQQ9WarLGBONAt9MNhg3EfH27IxNA";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxR3EdJHmUzYbv7AOvvHjiyEc3VRdRR5KQlCelmmiBehRf6UcCzMV0V3Zg";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxT3THHYGTp8rSQcCnwaJJWB1HsE_hS_jQHAqsgwsSsBVkGzP9nhQ3Se-Q";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSHKEYf1iLQD9p3LfyOcb3_uyeB3RSRxohHyUP75ct0JO3uOxBWDhfj6w"; //emacsagestion
        if (!connectionAvailable)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "reducirTamanioDiv", "javascript:ReducirTamanioDiv();", true);

        }

        if (!Page.IsPostBack)
        {

            this.btnNuevoDomicilio.Enabled = false;
            List<DomicilioDeudorAlternativoDataContracts> domiciliosAlternativos = new List<DomicilioDeudorAlternativoDataContracts>();
            List<DomicilioDeudorAlternativoParaGrillaDataContracts> domiciliosAlternativosParaGrilla = new List<DomicilioDeudorAlternativoParaGrillaDataContracts>();
            IDomicilioDeudorAlternativoService domiciliosAlternativosServices = ServiceClient<IDomicilioDeudorAlternativoService>.GetService("DomicilioDeudorAlternativoService");
            domiciliosAlternativos = domiciliosAlternativosServices.GetAllDomicilioDeudorsPorIdDeudor(int.Parse(idDeudor));
            foreach (DomicilioDeudorAlternativoDataContracts item in domiciliosAlternativos)
            {
                DomicilioDeudorAlternativoParaGrillaDataContracts domicilioDeudorAlternativoParaGrilla = new DomicilioDeudorAlternativoParaGrillaDataContracts();
                domicilioDeudorAlternativoParaGrilla.Id  = item.IdDeudor;
                domicilioDeudorAlternativoParaGrilla.IdDomicilioDeudorAlternativo = item.IdDeudorDomicilioAlternativo;
                domicilioDeudorAlternativoParaGrilla.Domicilio = item.CalleNombre + item.CalleAltura;
                domicilioDeudorAlternativoParaGrilla.Localidad = ServiceClient<ILocalidadService>.GetService("LocalidadService").GetLocalidad(item.IdLocalidad).Nombre;
                domicilioDeudorAlternativoParaGrilla.Partido = ServiceClient<IDepartamentoService>.GetService("DepartamentoService").GetDepartamento(item.IdDepartamento).Nombre;
                domicilioDeudorAlternativoParaGrilla.Provincia = ServiceClient<IProvinciaService>.GetService("ProvinciaService").GetProvincia(item.IdProvincia).Nombre;
                domicilioDeudorAlternativoParaGrilla.Pais = ServiceClient<IPaisService>.GetService("PaisService").GetPais(item.IdPais).Nombre;
                domicilioDeudorAlternativoParaGrilla.Cp = item.Cp;
                domicilioDeudorAlternativoParaGrilla.DirPpal = item.DirPpal;
                domiciliosAlternativosParaGrilla.Add(domicilioDeudorAlternativoParaGrilla);
            }
            this.GvResultados.DataSource = domiciliosAlternativosParaGrilla;
            this.GvResultados.DataBind();

            List<PaisDataContracts> paises = null;
            IPaisService paisService = ServiceClient<IPaisService>.GetService("PaisService");
            PaisDataContracts seleccionePais = new PaisDataContracts();
            seleccionePais.ID = 0;
            seleccionePais.Nombre = "--- SELECCIONE ---";
            paises = paisService.GetAllPaiss();
            paises.Insert(0, seleccionePais);

            this.cmbPais.DataSource = paises;
            this.cmbPais.DataTextField = "NOMBRE";
            this.cmbPais.DataValueField = "id";
            this.cmbPais.DataBind();

            List<ProvinciaDataContracts> provincias = null;
            IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
            provincias = provinciaService.GetAllProvincias();
            ProvinciaDataContracts seleccioneProvincia = new ProvinciaDataContracts();
            seleccioneProvincia.ID = 0;
            seleccioneProvincia.Nombre = "--- SELECCIONE ---";
            provincias.Insert(0, seleccioneProvincia);

            this.cmbProvincia.DataSource = provincias;
            this.cmbProvincia.DataTextField = "NOMBRE";
            this.cmbProvincia.DataValueField = "id";
            this.cmbProvincia.DataBind();

            List<DepartamentoDataContracts> departamentos = null;
            IDepartamentoService departamentoService = ServiceClient<IDepartamentoService>.GetService("DepartamentoService");
            departamentos = departamentoService.GetAllDepartamentos();

            DepartamentoDataContracts seleccioneDepartamento = new DepartamentoDataContracts();
            seleccioneDepartamento.ID = 0;
            seleccioneDepartamento.Nombre = "--- SELECCIONE ---";
            departamentos.Insert(0, seleccioneDepartamento);

            this.cmbDepartamento.DataSource = departamentos;
            this.cmbDepartamento.DataTextField = "NOMBRE";
            this.cmbDepartamento.DataValueField = "id";
            this.cmbDepartamento.DataBind();

            List<LocalidadDataContracts> localidades = null;
            ILocalidadService localidadService = ServiceClient<ILocalidadService>.GetService("LocalidadService");
            localidades = localidadService.GetAllLocalidadsByDepartamento(int.Parse(cmbDepartamento.SelectedValue));
            LocalidadDataContracts seleccioneLocalidad = new LocalidadDataContracts();
            seleccioneLocalidad.ID = 0;
            seleccioneLocalidad.Nombre = "--- SELECCIONE ---";
            localidades.Insert(0, seleccioneLocalidad);

            this.cmbLocalidad.DataSource = localidades;
            this.cmbLocalidad.DataTextField = "NOMBRE";
            this.cmbLocalidad.DataValueField = "id";
            this.cmbLocalidad.DataBind();

            DeudorService deudorService = new DeudorService();

            DeudorDataContracts deudorDataContract = deudorService.GetDeudor(int.Parse(idDeudor));

            this.lblIdDeudor.Text = deudorDataContract.IdDeudor.ToString();
            this.lblDeudor.Text = deudorDataContract.Nombre.ToString();
        }
    }

    private void CompletarControlesDeDomicilio(DomicilioDeudorAlternativoDataContracts domicilioAlternativo)
    { 
    

    
    
    }
    

    protected void GvResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("ViewAltaDeudor.aspx?Id_Deudor=" + GvResultados.DataKeys[e.NewEditIndex].Value.ToString());
    }

    protected void GvResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    private DataTable GetDataTableDomicilios()
    {


        //List<DomicilioDeudorAlternativoDataContracts> listaDomiciliosAlternativos = ImportadorInterfaces.mostrarResultados();

        //DataTable dataTable = ConvertDataTable<DomicilioDeudorAlternativoDataContracts>.Convert(listaDomiciliosAlternativos);


        //return dataTable;
        return null;
    }

    private DataTable GetDataTableImportaciones()
    {


        List<ImportacionFacturaDataContracts> listaImportacionFac = ImportadorInterfaces.mostrarResultados();

        DataTable dataTable = ConvertDataTable<ImportacionFacturaDataContracts>.Convert(listaImportacionFac);


        return dataTable;
    }
    protected DataTable GvResultados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            dataTable = this.GetDataTableImportaciones();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void GvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
   
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //RequiredFieldValidatorCuitNuevo.Enabled = true;        
        //Response.Redirect("ViewDetalleUltimaImportacionCliente.aspx?idCliente=" + this.idcli.Value);
        //this.HistoryBack();
    }
    protected void btnDomicilioGeolocalizado_Click(object sender, EventArgs e)
    {
        GoogleMapsHelper gmHelper = new GoogleMapsHelper();

        if (!gmHelper.isInternetConnectionAvailable())
        {

            return;
        }

        GeocodeResponse geoResponse = gmHelper.getGeocodeResponse(this.txtDomicilio.Text + "+" + this.txtAltura.Text + "," + this.cmbLocalidad.SelectedItem.Text + "," + this.cmbProvincia.SelectedItem.Text + "," + this.cmbPais.SelectedItem.Text);
        //
        if (geoResponse == null)
        {
            return;
        }

        double lat, lng;
        lat = geoResponse.results[0].geometry.location.lat;
        lng = geoResponse.results[0].geometry.location.lng;

        this.cmbGeoLocations.Items.Clear();
        //this.cmbGeoLocations.Items.Add(new ListItem("No seleccionado", "0,0"));
        List<ListItem> listItems = new List<ListItem>();
        for (int i = 0; i < geoResponse.results.Count; i++)
        {
            listItems.Add(new ListItem(geoResponse.results[i].formatted_address, geoResponse.results[i].geometry.location.lat + "," + geoResponse.results[i].geometry.location.lng));
        }

        if (listItems.Count == 0)
        {

            listItems.Add(new ListItem("No seleccionado", "0,0"));
        }
        this.cmbGeoLocations.Items.AddRange(listItems.ToArray());

        this.cmbGeoLocations.SelectedIndex = 0;
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSQ_lADAv5p0VmRdVhcfwwibzpHABRQwumzEz63WA9g7AUiLBfzRk2vkQ";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxTfJTOit7cTdNyZi0-3rP_yLyCMghQQ9WarLGBONAt9MNhg3EfH27IxNA";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxR3EdJHmUzYbv7AOvvHjiyEc3VRdRR5KQlCelmmiBehRf6UcCzMV0V3Zg";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxT3THHYGTp8rSQcCnwaJJWB1HsE_hS_jQHAqsgwsSsBVkGzP9nhQ3Se-Q";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSHKEYf1iLQD9p3LfyOcb3_uyeB3RSRxohHyUP75ct0JO3uOxBWDhfj6w"; //emacsagestion
        this.GoogleMapForASPNet1.GoogleMapObject.Width = "500px";
        this.GoogleMapForASPNet1.GoogleMapObject.Height = "250px";
        this.GoogleMapForASPNet1.GoogleMapObject.ShowMapTypesControl = true;
        this.GoogleMapForASPNet1.GoogleMapObject.ShowZoomControl = true;
        this.GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("CenterPoint", lat, lng);
        this.GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 15;


        GooglePoint GP = new GooglePoint();
        GP.ID = "1";
        GP.Latitude = lat;
        GP.Longitude = lng;
        this.GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
        this.GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);

    }
    protected void cmbGeoLocations_SelectedIndexChanged(object sender, EventArgs e)
    {

        string latlng = cmbGeoLocations.SelectedValue.ToString();
        string slat = latlng.Split(',')[0] + "," + latlng.Split(',')[1];
        string slng = latlng.Split(',')[2] + "," + latlng.Split(',')[3];
        double lat = double.Parse(slat);
        double lng = double.Parse(slng);

        this.GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("CenterPoint", lat, lng);

        GooglePoint GP = new GooglePoint();
        GP.ID = "1";
        GP.Latitude = lat;
        GP.Longitude = lng;
        this.GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
        this.GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
    }

    protected void EmailValidator_ServerValidate(Object source, ServerValidateEventArgs args)
    {
        //args.IsValid = true;
        string emails = args.Value;
        RegexStringValidator gsv = new RegexStringValidator(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        string[] aEmails = emails.Split(';');

        foreach (string email in aEmails)
        {
            try
            {
                if (email != null && email.Trim().Length > 0)
                {

                    gsv.Validate(email);
                }
            }
            catch (ArgumentException aex)
            {
                args.IsValid = false;
                return;
            }

        }
        args.IsValid = true;
    }

    protected void NumericValidator_ServerValidate(Object source, ServerValidateEventArgs args)
    {
        string numero = args.Value;
        RegexStringValidator gsv = new RegexStringValidator(@"^[0-9]*$");
        if (numero == null || numero.Length == 0)
        {
            args.IsValid = false;
            return;
        }

        try
        {
            gsv.Validate(numero);
        }
        catch (ArgumentException aex)
        {
            args.IsValid = false;
            return;
        }

        args.IsValid = true;
    }

    protected void btnNuevoDomicilio_Click(object sender, EventArgs e)
    {
            if (this.cmbPais.SelectedValue.Equals("0") || this.cmbProvincia.SelectedValue.Equals("0")
                || this.cmbDepartamento.SelectedValue.Equals("0") || this.cmbLocalidad.SelectedValue.Equals("0"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CompletarCombos", "javascript:alert('Por favor verifique completar todos los campos.');", true);
                return;
            }

            string divDatos = this.Request.QueryString["divDatos"];
            DomicilioDeudorAlternativoDataContracts domicilioDeudorAlternativo = new DomicilioDeudorAlternativoDataContracts();

            domicilioDeudorAlternativo.Id =0;
            domicilioDeudorAlternativo.IdDeudor = int.Parse(idDeudor);
            domicilioDeudorAlternativo.CalleAltura = int.Parse(this.txtAltura.Text);
            domicilioDeudorAlternativo.CalleNombre = this.txtDomicilio.Text;
            domicilioDeudorAlternativo.IdLocalidad = int.Parse(this.cmbLocalidad.SelectedValue);
            domicilioDeudorAlternativo.IdDepartamento = int.Parse(this.cmbDepartamento.SelectedValue);
            domicilioDeudorAlternativo.IdPais = int.Parse(this.cmbPais.SelectedValue);
            domicilioDeudorAlternativo.IdProvincia = int.Parse(this.cmbProvincia.SelectedValue);
            domicilioDeudorAlternativo.Cp = this.txtCp.Text;
            domicilioDeudorAlternativo.Depto = this.txtDepto.Text;
            domicilioDeudorAlternativo.Piso = (this.txtPiso.Text.Length > 0 ? int.Parse(this.txtPiso.Text) : 0);
            domicilioDeudorAlternativo.DirPpal = false;

            if (gmHelper.isInternetConnectionAvailable())
            {
                try
                {
                    if (this.cmbGeoLocations.SelectedItem != null)
                    { 
                    domicilioDeudorAlternativo.GmFormattedAddress = this.cmbGeoLocations.SelectedItem.Text;
                    string latlng = cmbGeoLocations.SelectedValue.ToString();
                    string slat = latlng.Split(',')[0] + "," + latlng.Split(',')[1];
                    string slng = latlng.Split(',')[2] + "," + latlng.Split(',')[3];
                    domicilioDeudorAlternativo.GmLat = double.Parse(slat);
                    domicilioDeudorAlternativo.GmLng = double.Parse(slng);
                    }

                    
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return;
                }
            }
            
            DomicilioDeudorAlternativoService domicilioDeudorAlternativoService = new DomicilioDeudorAlternativoService();

            //IDomicilioDeudorAlternativoService domiciliosAlternativosServices = ServiceClient<IDomicilioDeudorAlternativoService>.GetService("DomicilioDeudorAlternativoService");

            domicilioDeudorAlternativoService.Insert(domicilioDeudorAlternativo);


            List<DomicilioDeudorAlternativoDataContracts> domiciliosAlternativos = new List<DomicilioDeudorAlternativoDataContracts>();
            List<DomicilioDeudorAlternativoParaGrillaDataContracts> domiciliosAlternativosParaGrilla = new List<DomicilioDeudorAlternativoParaGrillaDataContracts>();
            IDomicilioDeudorAlternativoService domiciliosAlternativosServices = ServiceClient<IDomicilioDeudorAlternativoService>.GetService("DomicilioDeudorAlternativoService");
            domiciliosAlternativos = domiciliosAlternativosServices.GetAllDomicilioDeudorsPorIdDeudor(int.Parse(idDeudor));
            foreach (DomicilioDeudorAlternativoDataContracts item in domiciliosAlternativos)
            {
                DomicilioDeudorAlternativoParaGrillaDataContracts domicilioDeudorAlternativoParaGrilla = new DomicilioDeudorAlternativoParaGrillaDataContracts();
                domicilioDeudorAlternativoParaGrilla.Id = item.IdDeudor;
                domicilioDeudorAlternativoParaGrilla.IdDomicilioDeudorAlternativo = item.IdDeudorDomicilioAlternativo;
                domicilioDeudorAlternativoParaGrilla.Domicilio = item.CalleNombre + item.CalleAltura;
                domicilioDeudorAlternativoParaGrilla.Localidad = ServiceClient<ILocalidadService>.GetService("LocalidadService").GetLocalidad(item.IdLocalidad).Nombre;
                domicilioDeudorAlternativoParaGrilla.Partido = ServiceClient<IDepartamentoService>.GetService("DepartamentoService").GetDepartamento(item.IdDepartamento).Nombre;
                domicilioDeudorAlternativoParaGrilla.Provincia = ServiceClient<IProvinciaService>.GetService("ProvinciaService").GetProvincia(item.IdProvincia).Nombre;
                domicilioDeudorAlternativoParaGrilla.Pais = ServiceClient<IPaisService>.GetService("PaisService").GetPais(item.IdPais).Nombre;
                domicilioDeudorAlternativoParaGrilla.Cp = item.Cp;
                domicilioDeudorAlternativoParaGrilla.DirPpal = item.DirPpal;
                domiciliosAlternativosParaGrilla.Add(domicilioDeudorAlternativoParaGrilla);
            }
            this.GvResultados.DataSource = domiciliosAlternativosParaGrilla;
            this.GvResultados.DataBind();



    }


    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid)
            {
                cmbPais_SelectedIndexChanged(sender, e);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Se encontraron errores en los datos ingresados y los datos no han sido guardados. Por favor verificar datos ingresados.');", true);

                return;
            }

            #region VALIDACION_COMBOS_DOMICILIO

            if (this.cmbPais.SelectedValue.Equals("0") || this.cmbProvincia.SelectedValue.Equals("0")
                || this.cmbDepartamento.SelectedValue.Equals("0") || this.cmbLocalidad.SelectedValue.Equals("0")) {
                    throw new Exception("Falta seleccionar datos del domicilio");
            }

            #endregion


            string divDatos = this.Request.QueryString["divDatos"];

            //#region VALIDACION_CLIENTE_DEUDOR

            //Boolean validacionClienteDeudor = false;

            //IClienteDeudorService clienteDeudorService = ServiceClient<IClienteDeudorService>.GetService("ClienteDeudorService");
            //string listaClientesDeudorKey = Session.SessionID + "ClientesDeudor";
            //List<ClienteDeudorDataContracts> listaClientesDeudor = null;
            //if (Session[listaClientesDeudorKey] != null)
            //{
            //    listaClientesDeudor = (List<ClienteDeudorDataContracts>)Session[listaClientesDeudorKey];
            //    if (listaClientesDeudor != null && listaClientesDeudor.Count > 0)
            //    {
            //        validacionClienteDeudor = true;
            //    }
            //}
            //if (!validacionClienteDeudor)
            //{
            //    throw new Exception("Debe crear la relación cliente-deudor. (El botón + a la derecha del campo <<Alfanumérico del Cliente>> es para crear la relación)");
            //}

            //#endregion


            DeudorDataContracts deudor = new DeudorDataContracts();
            IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");


            deudor.Domicilio = this.txtDomicilio.Text;
            deudor.Localidad = this.cmbLocalidad.Text;
            deudor.Provincia = this.cmbProvincia.Text;
            deudor.Cp = this.txtCp.Text;
            deudor.FechaReclamo = DateTime.Now; //DateTime.Parse(this.txtFechaReclamo.Text);


            DomicilioDeudorDataContracts domiciliodeudor = new DomicilioDeudorDataContracts();
            IDomicilioDeudorService domiciliodeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
            domiciliodeudor.IdDomicilioAlternativo = int.Parse(this.GvResultados.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultados, "Id. Dom Alt")].Text);
            domiciliodeudor.IdDeudor = int.Parse(this.GvResultados.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultados, "Id")].Text);
            domiciliodeudor.IdPais = int.Parse(this.cmbPais.SelectedValue);
            domiciliodeudor.IdProvincia = int.Parse(this.cmbProvincia.SelectedValue);
            domiciliodeudor.IdDepartamento = int.Parse(this.cmbDepartamento.SelectedValue);
            domiciliodeudor.IdLocalidad = int.Parse(this.cmbLocalidad.SelectedValue);
            domiciliodeudor.CalleNombre = this.txtDomicilio.Text;
            domiciliodeudor.CalleAltura = int.Parse(this.txtAltura.Text);
            domiciliodeudor.Cp = this.txtCp.Text;
            domiciliodeudor.Piso = (this.txtPiso.Text.Length > 0 ? int.Parse(this.txtPiso.Text) : 0);
            domiciliodeudor.Depto = this.txtDepto.Text;
            domiciliodeudor.DirPpal = bool.Parse(this.GvResultados.SelectedRow.Cells[UIUtils.GetPosCol(this.GvResultados, "Dirección Principal")].Text);
            if (gmHelper.isInternetConnectionAvailable())
            {
                try
                {
                    domiciliodeudor.GmFormattedAddress = this.cmbGeoLocations.SelectedItem.Text;
                    string latlng = cmbGeoLocations.SelectedValue.ToString();
                    string slat = latlng.Split(',')[0] + "," + latlng.Split(',')[1];
                    string slng = latlng.Split(',')[2] + "," + latlng.Split(',')[3];
                    domiciliodeudor.GmLat = double.Parse(slat);
                    domiciliodeudor.GmLng = double.Parse(slng);
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }

            }
            //deudor.Domicilio_Deudor.GmLat = double.Parse(slat);
            //deudor.Domicilio_Deudor.GmLng = double.Parse(slng);

            if (domiciliodeudor.IdDeudor != 0)
            {
                domiciliodeudorService.Update(domiciliodeudor);
            }
            else
            {
                domiciliodeudorService.Insert(domiciliodeudor);
            }

            List<DomicilioDeudorAlternativoDataContracts> domiciliosAlternativos = new List<DomicilioDeudorAlternativoDataContracts>();
            List<DomicilioDeudorAlternativoParaGrillaDataContracts> domiciliosAlternativosParaGrilla = new List<DomicilioDeudorAlternativoParaGrillaDataContracts>();
            IDomicilioDeudorAlternativoService domiciliosAlternativosServices = ServiceClient<IDomicilioDeudorAlternativoService>.GetService("DomicilioDeudorAlternativoService");
            domiciliosAlternativos = domiciliosAlternativosServices.GetAllDomicilioDeudorsPorIdDeudor(int.Parse(idDeudor));
            foreach (DomicilioDeudorAlternativoDataContracts item in domiciliosAlternativos)
            {
                DomicilioDeudorAlternativoParaGrillaDataContracts domicilioDeudorAlternativoParaGrilla = new DomicilioDeudorAlternativoParaGrillaDataContracts();
                domicilioDeudorAlternativoParaGrilla.Id = item.IdDeudor;
                domicilioDeudorAlternativoParaGrilla.IdDomicilioDeudorAlternativo = item.IdDeudorDomicilioAlternativo;
                domicilioDeudorAlternativoParaGrilla.Domicilio = item.CalleNombre + item.CalleAltura;
                domicilioDeudorAlternativoParaGrilla.Localidad = ServiceClient<ILocalidadService>.GetService("LocalidadService").GetLocalidad(item.IdLocalidad).Nombre;
                domicilioDeudorAlternativoParaGrilla.Partido = ServiceClient<IDepartamentoService>.GetService("DepartamentoService").GetDepartamento(item.IdDepartamento).Nombre;
                domicilioDeudorAlternativoParaGrilla.Provincia = ServiceClient<IProvinciaService>.GetService("ProvinciaService").GetProvincia(item.IdProvincia).Nombre;
                domicilioDeudorAlternativoParaGrilla.Pais = ServiceClient<IPaisService>.GetService("PaisService").GetPais(item.IdPais).Nombre;
                domicilioDeudorAlternativoParaGrilla.Cp = item.Cp;
                domicilioDeudorAlternativoParaGrilla.DirPpal = item.DirPpal;
                domiciliosAlternativosParaGrilla.Add(domicilioDeudorAlternativoParaGrilla);
            }
            this.GvResultados.DataSource = domiciliosAlternativosParaGrilla;
            this.GvResultados.DataBind();

         



            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup11", "javascript:alert('Los datos han sido guardados satisfactoriamente.');", true);
            //LimpiarDatos();
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Ha ocurrido un error y los datos no han sido guardados. Detalle técnico:  ' " + ex.Message + "');HideEdicionDeudor();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Ha ocurrido un error y los datos no han sido guardados. Detalle técnico:   " + ex.Message + "');", true);
        }
    }

    private void HabilitarValidatorsNuevoDeudor()
    {
        this.RequiredFieldValidatorProvNuevo.Enabled = true;
     
        this.RequiredFieldValidatorLocaNuevo.Enabled = true;
        this.RequiredFieldValidatorDomicilioNuevo.Enabled = true;
   }

    private void DeshabilitarValidatorsNuevoDeudor()
    {
        this.RequiredFieldValidatorProvNuevo.Enabled = false;

        this.RequiredFieldValidatorLocaNuevo.Enabled = false;
        this.RequiredFieldValidatorDomicilioNuevo.Enabled = false;

        this.RequiredFieldValidatorCPNuevo.Enabled = false;

    }

    protected void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////Se bindean las provincias
        //List<ProvinciaDataContracts> provincias = new List<ProvinciaDataContracts>();
        //IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
        //provincias = provinciaService.GetAllProvinciasByPais(int.Parse(cmbPais.SelectedValue));

        //ProvinciaDataContracts seleccioneProvincia = new ProvinciaDataContracts();
        //seleccioneProvincia.ID = 0;
        //seleccioneProvincia.Nombre = "--- SELECCIONE ---";
        //provincias.Insert(0, seleccioneProvincia);

        //this.cmbProvincia.DataSource = provincias;
        //this.cmbProvincia.DataBind();
        ////Se pide bindear los departamentos
        //cmbProvincia_SelectedIndexChanged(sender, e);

    }

    protected void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Se bindean los departamentos
        List<DepartamentoDataContracts> departamentos = null;
        IDepartamentoService departamentoService = ServiceClient<IDepartamentoService>.GetService("DepartamentoService");
        departamentos = departamentoService.GetAllDepartamentosByProvincia(int.Parse(cmbProvincia.SelectedValue));

        DepartamentoDataContracts seleccioneDepartamento = new DepartamentoDataContracts();
        seleccioneDepartamento.ID = 0;
        seleccioneDepartamento.Nombre = "--- SELECCIONE ---";
        departamentos.Insert(0, seleccioneDepartamento);

        this.cmbDepartamento.DataSource = departamentos;
        this.cmbDepartamento.DataBind();
        //Se pide bindear las localidades
        cmbDepartamento_SelectedIndexChanged(sender, e);
    }

    protected void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        //se bindean las localidades
        cmbLocalidad.Items.Clear();
        List<LocalidadDataContracts> localidades = new List<LocalidadDataContracts>();
        ILocalidadService localidadService = ServiceClient<ILocalidadService>.GetService("LocalidadService");
        localidades = localidadService.GetAllLocalidadsByDepartamento(int.Parse(cmbDepartamento.SelectedValue));
        LocalidadDataContracts seleccioneLocalidad = new LocalidadDataContracts();
        seleccioneLocalidad.ID = 0;
        seleccioneLocalidad.Nombre = "--- SELECCIONE ---";
        localidades.Insert(0, seleccioneLocalidad);

        this.cmbLocalidad.DataSource = localidades;
        this.cmbLocalidad.DataBind();
    }

    private void LimpiarDatos()
    {
       
    }
    private void EdicionDeudor(int id_deudor)
    {
        DeudorDataContracts deudor = new DeudorDataContracts();
        IDeudorService deudorService = ServiceClient<IDeudorService>.GetService("DeudorService");
        deudor = deudorService.GetDeudor(id_deudor);

        ClienteDataContracts cliente = new ClienteDataContracts();
        IClienteService clienteService = ServiceClient<IClienteService>.GetService("ClienteService");

        DomicilioDeudorDataContracts domiciliodeudor = new DomicilioDeudorDataContracts();
        IDomicilioDeudorService domiciliodeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
        domiciliodeudor = domiciliodeudorService.GetDomicilioDeudor(id_deudor);

        #region combos_domicilio
        List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
        clientes = clienteServices.GetAllClientes();
        ClienteDataContracts seleccioneCliente = new ClienteDataContracts();
        seleccioneCliente.NOMBRE = "--- SELECCIONE ---";
        seleccioneCliente.IdCliente = 0;
        clientes.Insert(0, seleccioneCliente);

        List<PaisDataContracts> paises = null;
        IPaisService paisService = ServiceClient<IPaisService>.GetService("PaisService");

        PaisDataContracts seleccionePais = new PaisDataContracts();
        seleccionePais.ID = 0;
        seleccionePais.Nombre = "--- SELECCIONE ---";
        paises = paisService.GetAllPaiss();
        paises.Insert(0, seleccionePais);

        string idCmbPaisSelectedValue = this.cmbPais.SelectedValue;
        this.cmbPais.DataSource = paises;
        this.cmbPais.DataTextField = "NOMBRE";
        this.cmbPais.DataValueField = "id";
        this.cmbPais.DataBind();
        if (domiciliodeudor != null)
        {
            this.cmbPais.SelectedValue = domiciliodeudor.IdPais.ToString();
        }

        if (Int32.Parse(idCmbPaisSelectedValue) > 0)
        {
            this.cmbPais.SelectedValue = idCmbPaisSelectedValue;
        }


        List<ProvinciaDataContracts> provincias = new List<ProvinciaDataContracts>();
        IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
        provincias = provinciaService.GetAllProvinciasByPais(int.Parse(cmbPais.SelectedValue));

        ProvinciaDataContracts seleccioneProvincia = new ProvinciaDataContracts();
        seleccioneProvincia.ID = 0;
        seleccioneProvincia.Nombre = "--- SELECCIONE ---";
        provincias.Insert(0, seleccioneProvincia);

        string idCmbProvinciaSelectedValue = this.cmbProvincia.SelectedValue;

        this.cmbProvincia.DataSource = provincias;
        this.cmbProvincia.DataTextField = "NOMBRE";
        this.cmbProvincia.DataValueField = "id";
        this.cmbProvincia.DataBind();
        if (domiciliodeudor != null)
        {
            this.cmbProvincia.SelectedValue = domiciliodeudor.IdProvincia.ToString();
        }
        if (Int32.Parse(idCmbProvinciaSelectedValue) > 0)
        {
            this.cmbProvincia.SelectedValue = idCmbProvinciaSelectedValue;
        }

        List<DepartamentoDataContracts> departamentos = null;
        IDepartamentoService departamentoService = ServiceClient<IDepartamentoService>.GetService("DepartamentoService");
        departamentos = departamentoService.GetAllDepartamentosByProvincia(int.Parse(cmbProvincia.SelectedValue));
        DepartamentoDataContracts seleccioneDepartamento = new DepartamentoDataContracts();
        seleccioneDepartamento.ID = 0;
        seleccioneDepartamento.Nombre = "--- SELECCIONE ---";
        departamentos.Insert(0, seleccioneDepartamento);
        string idCmbDepartamentoSelectedValue = this.cmbDepartamento.SelectedValue;

        this.cmbDepartamento.DataSource = departamentos;
        this.cmbDepartamento.DataTextField = "NOMBRE";
        this.cmbDepartamento.DataValueField = "id";
        this.cmbDepartamento.DataBind();
        if (domiciliodeudor != null)
        {
            this.cmbDepartamento.SelectedValue = domiciliodeudor.IdDepartamento.ToString();
        }
        if (Int32.Parse(idCmbDepartamentoSelectedValue) > 0)
        {
            this.cmbDepartamento.SelectedValue = idCmbDepartamentoSelectedValue;
        }

        List<LocalidadDataContracts> localidades = new List<LocalidadDataContracts>();
        ILocalidadService localidadService = ServiceClient<ILocalidadService>.GetService("LocalidadService");
        localidades = localidadService.GetAllLocalidadsByDepartamento(int.Parse(cmbDepartamento.SelectedValue));
        LocalidadDataContracts seleccioneLocalidad = new LocalidadDataContracts();
        seleccioneLocalidad.ID = 0;
        seleccioneLocalidad.Nombre = "--- SELECCIONE ---";
        localidades.Insert(0, seleccioneLocalidad);

        string idCmbLocalidadSelectedValue = this.cmbLocalidad.SelectedValue;

        this.cmbLocalidad.DataSource = localidades;
        this.cmbLocalidad.DataTextField = "NOMBRE";
        this.cmbLocalidad.DataValueField = "id";
        this.cmbLocalidad.DataBind();
        if (domiciliodeudor != null)
        {
            this.cmbLocalidad.SelectedValue = domiciliodeudor.IdLocalidad.ToString();
        }
        if (Int32.Parse(idCmbLocalidadSelectedValue) > 0)
        {
            this.cmbLocalidad.SelectedValue = idCmbLocalidadSelectedValue;
        }
        #endregion


        if (domiciliodeudor != null)
        {
            if (this.txtDomicilio.Text == null || this.txtDomicilio.Text.Equals(string.Empty)) this.txtDomicilio.Text = domiciliodeudor.CalleNombre;
            if (this.txtAltura.Text == null || this.txtAltura.Text.Equals(string.Empty)) this.txtAltura.Text = domiciliodeudor.CalleAltura.ToString();
            if (this.txtCp.Text == null || this.txtCp.Text.Equals(string.Empty)) this.txtCp.Text = domiciliodeudor.Cp;
            if (this.txtPiso.Text == null || this.txtPiso.Text.Equals(string.Empty)) this.txtPiso.Text = domiciliodeudor.Piso.ToString();
            if (this.txtDepto.Text == null || this.txtDepto.Text.Equals(string.Empty)) this.txtDepto.Text = domiciliodeudor.Depto;
        }


        if (domiciliodeudor != null)
        {
            #region DomicilioGeoLocalizado

            if (gmHelper.isInternetConnectionAvailable())
            {
                try
                {

                    GeocodeResponse geoResponse =
                        gmHelper.getGeocodeResponse(this.txtDomicilio.Text + "+" + this.txtAltura.Text + "," +
                                                    this.cmbLocalidad.SelectedItem.Text + "," +
                                                    this.cmbProvincia.SelectedItem.Text + "," +
                                                    this.cmbPais.SelectedItem.Text);

                    double lat, lng;
                    lat = geoResponse.results[0].geometry.location.lat;
                    lng = geoResponse.results[0].geometry.location.lng;

                    this.cmbGeoLocations.Items.Clear();
                    List<ListItem> listItems = new List<ListItem>();
                    for (int i = 0; i < geoResponse.results.Count; i++)
                    {
                        listItems.Add(new ListItem(geoResponse.results[i].formatted_address,
                                                   geoResponse.results[i].geometry.location.lat + "," +
                                                   geoResponse.results[i].geometry.location.lng));
                    }

                    if (listItems.Count == 0)
                    {

                        listItems.Add(new ListItem("No seleccionado", "0,0"));
                    }
                    this.cmbGeoLocations.Items.AddRange(listItems.ToArray());

                    this.cmbGeoLocations.SelectedIndex = 0;
                    this.GoogleMapForASPNet1.GoogleMapObject.APIKey =
                        "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSQ_lADAv5p0VmRdVhcfwwibzpHABRQwumzEz63WA9g7AUiLBfzRk2vkQ";
                    this.GoogleMapForASPNet1.GoogleMapObject.APIKey =
                        "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxTfJTOit7cTdNyZi0-3rP_yLyCMghQQ9WarLGBONAt9MNhg3EfH27IxNA";
                    this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxT3THHYGTp8rSQcCnwaJJWB1HsE_hS_jQHAqsgwsSsBVkGzP9nhQ3Se-Q";
                    this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSHKEYf1iLQD9p3LfyOcb3_uyeB3RSRxohHyUP75ct0JO3uOxBWDhfj6w"; //emacsagestion
                    this.GoogleMapForASPNet1.GoogleMapObject.Width = "500px";
                    this.GoogleMapForASPNet1.GoogleMapObject.Height = "250px";
                    this.GoogleMapForASPNet1.GoogleMapObject.ShowMapTypesControl = true;
                    this.GoogleMapForASPNet1.GoogleMapObject.ShowZoomControl = true;
                    this.GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("CenterPoint", lat, lng);
                    this.GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 15;

                    GooglePoint GP = new GooglePoint();
                    GP.ID = "1";
                    GP.Latitude = domiciliodeudor.GmLat;
                    GP.Longitude = domiciliodeudor.GmLng;
                    this.GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
                    this.GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
                }
                catch (Exception e)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide",
                                                        "javascript:alert('Ha ocurrido un error durante la búsqueda en Google Maps. Intente presionando F5 para refrescar la pantalla.');",
                                                        true);

                }
            }

            #endregion
        }


   
        fillHorariosCobro();
        fillClientesDeudor();
    }

   

    protected void btnAgregarClienteDeudor_Click(object sender, EventArgs e)
    {

 
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaClientesDeudorKey = Session.SessionID + "ClientesDeudor";
        List<ClienteDeudorDataContracts> listaClientesDeudor = null;
        /* if (mgr.Contains(listaClientesDeudorKey))
         {
             listaClientesDeudor = (List<ClienteDeudorDataContracts>)mgr.GetData(listaClientesDeudorKey);
         }
         else
         {
             listaClientesDeudor = new List<ClienteDeudorDataContracts>();
             mgr.Add(listaClientesDeudorKey, listaClientesDeudor);
         }*/
        if (Session[listaClientesDeudorKey] != null)
        {
            listaClientesDeudor = (List<ClienteDeudorDataContracts>)Session[listaClientesDeudorKey];
        }
        else
        {
            listaClientesDeudor = new List<ClienteDeudorDataContracts>();
            Session[listaClientesDeudorKey] = listaClientesDeudor;
        }

        ClienteDeudorDataContracts cdDTO = new ClienteDeudorDataContracts();
        if (this.idDeudor != null)
        {
            cdDTO.IdDeudor = int.Parse(this.idDeudor);
        }

        if (!listaClientesDeudor.Contains(cdDTO))
        {
            listaClientesDeudor.Insert(listaClientesDeudor.Count, cdDTO);
        }
        else
        {
            int pos = listaClientesDeudor.IndexOf(cdDTO);

            ClienteDeudorDataContracts cdDTOtmp = listaClientesDeudor.ElementAt(pos);
            cdDTOtmp.Alfanumdelcliente = cdDTO.Alfanumdelcliente;

        }
        //fillTableClientesDeudor(listaClientesDeudor);
        //        fillHorariosCobro();
        //IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
        //deudorDiaCobroService.Insert(ddrDTO);
    }
    protected void fillClientesDeudor()
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaClientesDeudorKey = Session.SessionID + "ClientesDeudor";
        List<ClienteDeudorDataContracts> listaClientesDeudor = null;
        //if (mgr.Contains(listaClientesDeudorKey))
        //{
        //    listaClientesDeudor = (List<ClienteDeudorDataContracts>)mgr.GetData(listaClientesDeudorKey);
        //}
        //else
        //{
        //    listaClientesDeudor = new List<ClienteDeudorDataContracts>();
        //    mgr.Add(listaClientesDeudorKey, listaClientesDeudor);
        //}
        if (Session[listaClientesDeudorKey] != null)
        {
            listaClientesDeudor = (List<ClienteDeudorDataContracts>)Session[listaClientesDeudorKey];
        }
        else
        {
            listaClientesDeudor = new List<ClienteDeudorDataContracts>();
            Session[listaClientesDeudorKey] = listaClientesDeudor;
        }


        IClienteDeudorService clienteDeudorService = ServiceClient<IClienteDeudorService>.GetService("ClienteDeudorService");
        if (this.idDeudor != null && listaClientesDeudor.Count == 0)
        {
            listaClientesDeudor.AddRange(clienteDeudorService.GetAllClienteDeudorsByIdDeudor(int.Parse(this.idDeudor)));
        }

        //fillTableClientesDeudor(listaClientesDeudor);

    }

    protected void fillHorariosCobro()
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
        //if (mgr.Contains(listaDiasCobroKey))
        //{
        //    listaDiasCobro = (List<DeudorDiaCobroDataContracts>)mgr.GetData(listaDiasCobroKey);
        //}
        //else
        //{
        //    listaDiasCobro = new List<DeudorDiaCobroDataContracts>();
        //    mgr.Add(listaDiasCobroKey, listaDiasCobro);
        //}
        if (Session[listaDiasCobroKey] != null)
        {
            listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];
        }
        else
        {
            listaDiasCobro = new List<DeudorDiaCobroDataContracts>();
            Session[listaDiasCobroKey] = listaDiasCobro;
        }
        IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
        if (this.idDeudor != null && listaDiasCobro.Count == 0)
        {
            listaDiasCobro.AddRange(deudorDiaCobroService.GetAllDeudorDiaCobrosPorIdDeudor(int.Parse(this.idDeudor)));
        }

        //fillTableHorariosCobro(listaDiasCobro);

    }


    protected void OnDeleteHorarioCobro(object sender, CommandEventArgs e)
    {
        string idToDelete = e.CommandArgument.ToString();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
        //if (mgr.Contains(listaDiasCobroKey))
        if (Session[listaDiasCobroKey] != null)
        {
            //listaDiasCobro = (List<DeudorDiaCobroDataContracts>)mgr.GetData(listaDiasCobroKey);
            listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];
            DeudorDiaCobroDataContracts ddrDTO = listaDiasCobro.ElementAt(int.Parse(idToDelete));

            if (ddrDTO.IdDiaCobro != -1)
            {
                IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
                deudorDiaCobroService.Delete(ddrDTO);
            }

            listaDiasCobro.RemoveAt(int.Parse(idToDelete));
        }

        //fillTableHorariosCobro(listaDiasCobro);
    }


    protected void OnDeleteClienteDeudor(object sender, CommandEventArgs e)
    {
        string idToDelete = e.CommandArgument.ToString();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaClientesDeudorKey = Session.SessionID + "ClientesDeudor";
        List<ClienteDeudorDataContracts> listaClientesDeudor = null;
        IClienteDeudorService clienteDeudorService = ServiceClient<IClienteDeudorService>.GetService("ClienteDeudorService");
        //if (mgr.Contains(listaClientesDeudorKey))
        if (Session[listaClientesDeudorKey] != null)
        {
            //listaClientesDeudor = (List<ClienteDeudorDataContracts>)mgr.GetData(listaClientesDeudorKey);
            listaClientesDeudor = (List<ClienteDeudorDataContracts>)Session[listaClientesDeudorKey];
            ClienteDeudorDataContracts cdDTO = listaClientesDeudor.ElementAt(int.Parse(idToDelete));
            ClienteDeudorDataContracts clienteDeudorDTO = clienteDeudorService.GetClienteDeudor(cdDTO.IdCliente, cdDTO.IdDeudor);

            if (clienteDeudorDTO != null)
            {
                clienteDeudorService.Delete(cdDTO);
            }

            listaClientesDeudor.RemoveAt(int.Parse(idToDelete));
        }

        //fillTableClientesDeudor(listaClientesDeudor);
    }








    protected void GvResultados_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CompletarCombos();

        ListItem item = ((ListItem)cmbPais.Items.FindByText(((System.Web.UI.WebControls.TableRow)(((System.Web.UI.WebControls.GridView)(sender)).SelectedRow)).Cells[UIUtils.GetPosCol(this.GvResultados, "Pais")].Text));
        this.cmbPais.SelectedIndex = this.cmbPais.Items.IndexOf(item);


        ListItem itemProvincia = ((ListItem)cmbProvincia.Items.FindByText(((System.Web.UI.WebControls.TableRow)(((System.Web.UI.WebControls.GridView)(sender)).SelectedRow)).Cells[UIUtils.GetPosCol(this.GvResultados, "Provincia")].Text));
        this.cmbProvincia.SelectedIndex = this.cmbProvincia.Items.IndexOf(itemProvincia);


        ListItem itemPartido = ((ListItem)this.cmbDepartamento.Items.FindByText(((System.Web.UI.WebControls.TableRow)(((System.Web.UI.WebControls.GridView)(sender)).SelectedRow)).Cells[UIUtils.GetPosCol(this.GvResultados, "Partido")].Text));
        this.cmbDepartamento.SelectedIndex = this.cmbDepartamento.Items.IndexOf(itemPartido);


        ListItem itemLocalidad = ((ListItem)this.cmbLocalidad.Items.FindByText(((System.Web.UI.WebControls.TableRow)(((System.Web.UI.WebControls.GridView)(sender)).SelectedRow)).Cells[UIUtils.GetPosCol(this.GvResultados, "Localidad")].Text));
        this.cmbLocalidad.SelectedIndex = this.cmbLocalidad.Items.IndexOf(itemLocalidad);

        DomicilioDeudorDataContracts domiciliodeudor = new DomicilioDeudorDataContracts();
        IDomicilioDeudorService domiciliodeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
        domiciliodeudor = domiciliodeudorService.GetDomicilioDeudor(int.Parse(Request.QueryString["Id_Deudor"]));

        if (domiciliodeudor != null)
        {
            if (this.txtDomicilio.Text == null || this.txtDomicilio.Text.Equals(string.Empty)) this.txtDomicilio.Text = domiciliodeudor.CalleNombre;
            if (this.txtAltura.Text == null || this.txtAltura.Text.Equals(string.Empty)) this.txtAltura.Text = domiciliodeudor.CalleAltura.ToString();
            if (this.txtCp.Text == null || this.txtCp.Text.Equals(string.Empty)) this.txtCp.Text = domiciliodeudor.Cp;
            if (this.txtPiso.Text == null || this.txtPiso.Text.Equals(string.Empty)) this.txtPiso.Text = domiciliodeudor.Piso.ToString();
            if (this.txtDepto.Text == null || this.txtDepto.Text.Equals(string.Empty)) this.txtDepto.Text = domiciliodeudor.Depto;
        }

        
        //string idCmbLocalidadSelectedValue = this.cmbLocalidad.SelectedValue;


        //if (domiciliodeudor != null)
        //{
        //    this.cmbLocalidad.SelectedValue = domiciliodeudor.IdLocalidad.ToString();
        //}
        //if (Int32.Parse(idCmbLocalidadSelectedValue) > 0)
        //{
        //    this.cmbLocalidad.SelectedValue = idCmbLocalidadSelectedValue;
        //}

        if (domiciliodeudor != null)
        {
            #region DomicilioGeoLocalizado

            if (gmHelper.isInternetConnectionAvailable())
            {
                try
                {

                    GeocodeResponse geoResponse =
                        gmHelper.getGeocodeResponse(this.txtDomicilio.Text + "+" + this.txtAltura.Text + "," +
                                                    this.cmbLocalidad.SelectedItem.Text + "," +
                                                    this.cmbProvincia.SelectedItem.Text + "," +
                                                    this.cmbPais.SelectedItem.Text);

                    double lat, lng;
                    lat = geoResponse.results[0].geometry.location.lat;
                    lng = geoResponse.results[0].geometry.location.lng;

                    this.cmbGeoLocations.Items.Clear();
                    List<ListItem> listItems = new List<ListItem>();
                    for (int i = 0; i < geoResponse.results.Count; i++)
                    {
                        listItems.Add(new ListItem(geoResponse.results[i].formatted_address,
                                                   geoResponse.results[i].geometry.location.lat + "," +
                                                   geoResponse.results[i].geometry.location.lng));
                    }

                    if (listItems.Count == 0)
                    {

                        listItems.Add(new ListItem("No seleccionado", "0,0"));
                    }
                    this.cmbGeoLocations.Items.AddRange(listItems.ToArray());

                    this.cmbGeoLocations.SelectedIndex = 0;
                    this.GoogleMapForASPNet1.GoogleMapObject.APIKey =
                        "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSQ_lADAv5p0VmRdVhcfwwibzpHABRQwumzEz63WA9g7AUiLBfzRk2vkQ";
                    this.GoogleMapForASPNet1.GoogleMapObject.APIKey =
                        "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxTfJTOit7cTdNyZi0-3rP_yLyCMghQQ9WarLGBONAt9MNhg3EfH27IxNA";
                    this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxT3THHYGTp8rSQcCnwaJJWB1HsE_hS_jQHAqsgwsSsBVkGzP9nhQ3Se-Q";
                    this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSHKEYf1iLQD9p3LfyOcb3_uyeB3RSRxohHyUP75ct0JO3uOxBWDhfj6w"; //emacsagestion
                    this.GoogleMapForASPNet1.GoogleMapObject.Width = "500px";
                    this.GoogleMapForASPNet1.GoogleMapObject.Height = "250px";
                    this.GoogleMapForASPNet1.GoogleMapObject.ShowMapTypesControl = true;
                    this.GoogleMapForASPNet1.GoogleMapObject.ShowZoomControl = true;
                    this.GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("CenterPoint", lat, lng);
                    this.GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 15;

                    GooglePoint GP = new GooglePoint();
                    GP.ID = "1";
                    GP.Latitude = domiciliodeudor.GmLat;
                    GP.Longitude = domiciliodeudor.GmLng;
                    this.GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
                    this.GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide",
                                                        "javascript:alert('Ha ocurrido un error durante la búsqueda en Google Maps. Intente presionando F5 para refrescar la pantalla.');",
                                                        true);

                }
            }

            #endregion
        }


    }
    protected void radioButtonAbm_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.btnAceptar.Enabled = !this.btnAceptar.Enabled;
        this.btnNuevoDomicilio.Enabled = !this.btnNuevoDomicilio.Enabled;
        this.GvResultados.Enabled = !this.GvResultados.Enabled;
        inicializarControles();
    }

    private void inicializarControles()
    {
        this.txtDomicilio.Text =string.Empty;
        this.txtAltura.Text =string.Empty;
        this.txtCp.Text = string.Empty;
        this.txtPiso.Text = string.Empty;
        this.txtDepto.Text =string.Empty;
        this.CompletarCombos();
        //this.cmbPais.SelectedIndex = -1;
        //this.cmbProvincia.SelectedIndex = -1;
        //this.cmbDepartamento.SelectedIndex = -1;
        //this.cmbLocalidad.SelectedIndex = -1;
        //this.cmbGeoLocations.Items.Clear();
       
    }

    private void CompletarCombos()
    {
        this.cmbPais.Items.Clear();
        this.cmbProvincia.Items.Clear();
        this.cmbDepartamento.Items.Clear();
        this.cmbLocalidad.Items.Clear();

        List<PaisDataContracts> paises = null;
        IPaisService paisService = ServiceClient<IPaisService>.GetService("PaisService");
        PaisDataContracts seleccionePais = new PaisDataContracts();
        seleccionePais.ID = 0;
        seleccionePais.Nombre = "--- SELECCIONE ---";
        paises = paisService.GetAllPaiss();
        paises.Insert(0, seleccionePais);

        this.cmbPais.DataSource = paises;
        this.cmbPais.DataTextField = "NOMBRE";
        this.cmbPais.DataValueField = "id";
        this.cmbPais.DataBind();

        List<ProvinciaDataContracts> provincias = null;
        IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
        provincias = provinciaService.GetAllProvincias();
        ProvinciaDataContracts seleccioneProvincia = new ProvinciaDataContracts();
        seleccioneProvincia.ID = 0;
        seleccioneProvincia.Nombre = "--- SELECCIONE ---";
        provincias.Insert(0, seleccioneProvincia);

        this.cmbProvincia.DataSource = provincias;
        this.cmbProvincia.DataTextField = "NOMBRE";
        this.cmbProvincia.DataValueField = "id";
        this.cmbProvincia.DataBind();

        List<DepartamentoDataContracts> departamentos = null;
        IDepartamentoService departamentoService = ServiceClient<IDepartamentoService>.GetService("DepartamentoService");
        departamentos = departamentoService.GetAllDepartamentos();

        DepartamentoDataContracts seleccioneDepartamento = new DepartamentoDataContracts();
        seleccioneDepartamento.ID = 0;
        seleccioneDepartamento.Nombre = "--- SELECCIONE ---";
        departamentos.Insert(0, seleccioneDepartamento);

        this.cmbDepartamento.DataSource = departamentos;
        this.cmbDepartamento.DataTextField = "NOMBRE";
        this.cmbDepartamento.DataValueField = "id";
        this.cmbDepartamento.DataBind();

        List<LocalidadDataContracts> localidades = null;
        ILocalidadService localidadService = ServiceClient<ILocalidadService>.GetService("LocalidadService");
        localidades = localidadService.GetAllLocalidads();
        LocalidadDataContracts seleccioneLocalidad = new LocalidadDataContracts();
        seleccioneLocalidad.ID = 0;
        seleccioneLocalidad.Nombre = "--- SELECCIONE ---";
        localidades.Insert(0, seleccioneLocalidad);

        this.cmbLocalidad.DataSource = localidades;
        this.cmbLocalidad.DataTextField = "NOMBRE";
        this.cmbLocalidad.DataValueField = "id";
        this.cmbLocalidad.DataBind();

        this.txtAltura.Text = string.Empty;
        this.txtCp.Text = string.Empty;
        this.txtDepto.Text = string.Empty;
        this.txtDomicilio.Text = string.Empty;
        this.txtPiso.Text = string.Empty;
        this.cmbGeoLocations.Items.Clear();

        this.cmbPais.SelectedIndex = 0;
        this.cmbProvincia.SelectedIndex = 0;
        this.cmbDepartamento.SelectedIndex = 0;
        this.cmbLocalidad.SelectedIndex = 0;


        //this.updatePanelPais.Update();
        //this.updatePanelProvincia.Update();
        //this.updatePanelDepartamento.Update();
        //this.updatePanelLocalidad.Update();
    }

}
