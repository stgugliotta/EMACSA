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

public partial class Vistas_ViewAltaDeudor : GobbiPage
{
    private String idCliente;
    private String idDeudorInterfaz;
    private String idDeudor;
    private GoogleMapsHelper gmHelper = new GoogleMapsHelper();

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        fillHorariosCobro();
        fillHorariosReclamo();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //  Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewAltaDeudor));

        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        this.idCliente = Request.Params.Get("idCliente");
        this.idcli.Value = idCliente;
        this.idDeudorInterfaz = Request.Params.Get("idDeudor");
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
            //fillHorariosReclamo();
            //fillHorariosCobro();
            //fillClientesDeudor();

            ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

            #region CLIENTE_DEUDOR

            string listaClienteDeudorKey = Session.SessionID + "ClientesDeudor";
            List<ClienteDeudorDataContracts> listaClientesDeudor = null;

            listaClientesDeudor = new List<ClienteDeudorDataContracts>();
            //mgr.Add(listaClienteDeudorKey, listaClientesDeudor);
            Session[listaClienteDeudorKey] = listaClientesDeudor;

            #endregion

            #region horarios


            string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
            string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
            List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
            List<DeudorDiaCobroDataContracts> listaDiasCobro = null;

            listaDiasReclamo = new List<DeudorDiaReclamoDataContracts>();
            listaDiasCobro = new List<DeudorDiaCobroDataContracts>();
            //mgr.Add(listaDiasReclamoKey, listaDiasReclamo);
            //mgr.Add(listaDiasCobroKey, listaDiasCobro);
            Session[listaDiasReclamoKey] = listaDiasReclamo;
            Session[listaDiasCobroKey] = listaDiasCobro;


            List<DiasDataContracts> dias = new List<DiasDataContracts>();
            IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
            dias = diasService.GetAllDiass();

            this.cmbDiasReclamo.DataSource = dias;
            this.cmbDiasReclamo.DataTextField = "Descripcion";
            this.cmbDiasReclamo.DataValueField = "IdDia";
            this.cmbDiasReclamo.DataBind();

            this.cmbDiasCobro.DataSource = dias;
            this.cmbDiasCobro.DataTextField = "Descripcion";
            this.cmbDiasCobro.DataValueField = "IdDia";
            this.cmbDiasCobro.DataBind();

            #endregion


            this.txtCuit.Attributes.Add("OnBlur", "javascript:return CPcuitValido(this.value);");


            this.txtAlfaNumDelCliente.Text = this.idDeudorInterfaz;




            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
            clientes = clienteServices.GetAllClientes();

            ClienteDataContracts seleccioneCliente = new ClienteDataContracts();
            seleccioneCliente.NOMBRE = "--- SELECCIONE ---";
            seleccioneCliente.IdCliente = 0;
            clientes.Insert(0, seleccioneCliente);

            this.cmbClientes.DataSource = clientes;
            this.cmbClientes.DataTextField = "NOMBRE";
            this.cmbClientes.DataValueField = "idCliente";
            this.cmbClientes.DataBind();
            this.cmbClientes.SelectedValue = this.idCliente;

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
            provincias = provinciaService.GetAllProvinciasByPais(int.Parse(cmbPais.SelectedValue));
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
            departamentos = departamentoService.GetAllDepartamentosByProvincia(int.Parse(cmbProvincia.SelectedValue));

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

            this.cmbGeoLocations.Items.Add(new ListItem("No seleccionado", "0,0"));

            this.GoogleMapForASPNet1.GoogleMapObject.Width = "500px";
            this.GoogleMapForASPNet1.GoogleMapObject.Height = "200px";
            this.GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("CenterPoint", 0, 0);
            this.GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 12;


            GooglePoint GP = new GooglePoint();
            GP.ID = "1";
            GP.Latitude = 0;
            GP.Longitude = 0;

            this.GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);


            HabilitarValidatorsNuevoDeudor();



        }


        if (this.idDeudorInterfaz != null)
        {
            IClienteDeudorService clienteDeudorService = ServiceClient<IClienteDeudorService>.GetService("ClienteDeudorService");
            ClienteDeudorDataContracts clienteDeudorDTO = null;
            try
            {
                clienteDeudorDTO = clienteDeudorService.GetClienteAlfanumDelCliente(int.Parse(this.idCliente), idDeudorInterfaz);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            int iddeudor = -1;
            if (clienteDeudorDTO != null)
            {
                iddeudor = clienteDeudorDTO.IdDeudor;
            }
            this.idDeudor = iddeudor.ToString();
            EdicionDeudor(iddeudor);
        }
        else
        {
            if (this.idDeudor != null)
                EdicionDeudor(int.Parse(this.idDeudor));
        }

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
    protected void Exportar_Click(object sender, EventArgs e)
    {


        List<string> listaSeleccionados = new List<string>();
        DataTable dt = new DataTable();

        List<string> lista = new List<string>();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        DataTable dataTable = GvResultados_Filling(null, null);

        //if (mgr.Contains(Session.SessionID + "SeleccionGrilla"))
        //   lista = (List<string>)mgr.GetData(Session.SessionID + "SeleccionGrilla");
        if (Session["SeleccionGrilla"] != null)
            lista = (List<string>)Session["SeleccionGrilla"];



        DataColumn column0 = new DataColumn("IdCliente");
        column0.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column0);

        DataColumn column1 = new DataColumn("Nombre");
        column1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column1);
        DataColumn column2 = new DataColumn("CUIT");
        column2.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column2);
        DataColumn column3 = new DataColumn("RegistrosEnviados");
        column3.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column3);
        DataColumn column4 = new DataColumn("RegistrosIngresados");
        column4.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column4);
        DataColumn column5 = new DataColumn("RegistrosRechazados");
        column5.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column5);
        DataColumn column6 = new DataColumn("DocumentosBaja");
        column6.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column6);
        DataColumn column7 = new DataColumn("FechaProceso");
        column6.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(column7);



        foreach (DataRow dr in dataTable.Select())
        {
            dt.ImportRow(dr);
            listaSeleccionados.Add(int.Parse(dr["idCliente"].ToString()).ToString());
        }

        mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        if (Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] != null)
        {
            Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] = null;
        }
        Session[Constants.CACHE_DOCUMENTOS_A_EXPORTAR] = dt;


        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaPequenia('ViewExportToExcel.aspx','_blank');", true);
        this.StartupScriptKey++;


    }
   

    private void InicializarCombos()
    {

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

        List<ProvinciaDataContracts> provincias = new List<ProvinciaDataContracts>();
        ProvinciaDataContracts seleccioneProvincia = new ProvinciaDataContracts();
        this.cmbProvincia.Items.Clear();
        this.cmbProvincia.Items.Add(new ListItem("0", "--- SELECCIONE ---"));

        List<DepartamentoDataContracts> departamentos = new List<DepartamentoDataContracts>();
        DepartamentoDataContracts seleccioneDepartamento = new DepartamentoDataContracts();
 
        this.cmbDepartamento.Items.Clear();
        this.cmbDepartamento.Items.Add(new ListItem("0", "--- SELECCIONE ---"));

        List<LocalidadDataContracts> localidades = new List<LocalidadDataContracts>();
        LocalidadDataContracts seleccioneLocalidad = new LocalidadDataContracts();
        //seleccioneLocalidad.ID = 0;
        //seleccioneLocalidad.Nombre = "--- SELECCIONE ---";
        //localidades.Insert(0, seleccioneLocalidad);

        this.cmbLocalidad.Items.Clear();
        this.cmbLocalidad.Items.Add(new ListItem("0", "--- SELECCIONE ---"));
        //this.cmbLocalidad.DataSource = localidades;
        //this.cmbLocalidad.DataTextField = "NOMBRE";
        //this.cmbLocalidad.DataValueField = "id";
        //this.cmbLocalidad.DataBind();


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
        string gmQuery = string.Empty;


        if (!gmHelper.isInternetConnectionAvailable())
        {
            return;
        }

        if (this.cmbLocalidad.SelectedItem.Text.ToUpper() == "CABA")
        {
            gmQuery = this.txtDomicilio.Text + "+" + this.txtAltura.Text + "," + this.cmbProvincia.SelectedItem.Text + "," + this.cmbPais.SelectedItem.Text;
        }
        else
        {
            gmQuery = this.txtDomicilio.Text + "+" + this.txtAltura.Text + "," + this.cmbLocalidad.SelectedItem.Text + "," + this.cmbProvincia.SelectedItem.Text + "," + this.cmbPais.SelectedItem.Text;
        }

        GeocodeResponse geoResponse = gmHelper.getGeocodeResponse(gmQuery);

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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {      
        try
        {
            if (!Page.IsValid)
            {
              //  cmbPais_SelectedIndexChanged(sender, e);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Existen datos incompletos. Por favort verifíquelos.');", true);

                return;
            }
            
            if (!string.IsNullOrEmpty(this.txtCuit.Text) && !UIUtils.ValidaCuit(this.txtCuit.Text))
            {
                throw new Exception("CUIT Inválido");
            }

            #region VALIDACION_COMBOS_DOMICILIO

            if (this.cmbPais.SelectedValue.Equals("0") || this.cmbProvincia.SelectedValue.Equals("0")
                || this.cmbDepartamento.SelectedValue.Equals("0") || this.cmbLocalidad.SelectedValue.Equals("0")) {
                    throw new Exception("Falta seleccionar datos del domicilio");
            }

            #endregion


            string divDatos = this.Request.QueryString["divDatos"];

            #region VALIDACION_CLIENTE_DEUDOR

            Boolean validacionClienteDeudor = false;

            IClienteDeudorService clienteDeudorService = ServiceClient<IClienteDeudorService>.GetService("ClienteDeudorService");
            string listaClientesDeudorKey = Session.SessionID + "ClientesDeudor";
            List<ClienteDeudorDataContracts> listaClientesDeudor = null;
            if (Session[listaClientesDeudorKey] != null)
            {
                listaClientesDeudor = (List<ClienteDeudorDataContracts>)Session[listaClientesDeudorKey];
                if (listaClientesDeudor != null && listaClientesDeudor.Count > 0)
                {
                    validacionClienteDeudor = true;
                }
            }
            if (!validacionClienteDeudor)
            {
                throw new Exception("Debe crear la relación cliente-deudor. (El botón + a la derecha del campo <<Alfanumérico del Cliente>> es para crear la relación)");
            }

            #endregion


            DeudorDataContracts deudor = new DeudorDataContracts();
            IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");


            deudor.Nombre = this.txtNombre.Text;
            deudor.Cuit = this.txtCuit.Text;
            deudor.Domicilio = this.txtDomicilio.Text + " " +  this.txtAltura.Text;
            deudor.Localidad = this.cmbLocalidad.SelectedItem.ToString();
            deudor.Provincia = this.cmbProvincia.SelectedItem.ToString();
            deudor.Cp = this.txtCp.Text;
            deudor.Telefono = this.txtTelefono.Text;
            deudor.Fax = this.txtFax.Text;
            deudor.Email = this.txtEmail.Text;
            deudor.AnticipoGestion = int.Parse(this.txtAnticipo.Text == "" ? "0" : this.txtAnticipo.Text);
            deudor.AlfaNumDelCliente = this.txtAlfaNumDelCliente.Text;
            deudor.Telefono_Aux = this.txtTelefonoAux.Text;
            deudor.FechaReclamo = DateTime.Now; //DateTime.Parse(this.txtFechaReclamo.Text);

            //if (Request.QueryString["Id_Deudor"] != null)
            if (this.idDeudor != null)
            {
                deudor.IdDeudor = int.Parse(this.idDeudor);
                deudorServices.Update(deudor);
            }
            else
            {
                deudorServices.Insert(deudor);
                deudor = deudorServices.GetLastId(); //Obtiene el ultimo id insertado de deudor, el cual corresponde al de recien.
            }
            this.DeshabilitarValidatorsNuevoDeudor();

            DomicilioDeudorDataContracts domiciliodeudor = new DomicilioDeudorDataContracts();
            IDomicilioDeudorService domiciliodeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");

            domiciliodeudor.IdDeudor = deudor.IdDeudor;
            domiciliodeudor.IdPais = int.Parse(this.cmbPais.SelectedValue);
            domiciliodeudor.IdProvincia = int.Parse(this.cmbProvincia.SelectedValue);
            domiciliodeudor.IdDepartamento = int.Parse(this.cmbDepartamento.SelectedValue);
            domiciliodeudor.IdLocalidad = int.Parse(this.cmbLocalidad.SelectedValue);
            domiciliodeudor.CalleNombre = this.txtDomicilio.Text;
            domiciliodeudor.CalleAltura = int.Parse(this.txtAltura.Text);
            domiciliodeudor.Cp = this.txtCp.Text;
            domiciliodeudor.Piso = (this.txtPiso.Text.Length > 0 ? int.Parse(this.txtPiso.Text) : 0);
            domiciliodeudor.Depto = this.txtDepto.Text;
            
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

            if (Request.Params["idDomicilioDeudor"] != null)
            {
                //deudor.IdDeudor
                //if (domiciliodeudorService.GetDomicilioDeudor(int.Parse(Request.Params["idDomicilioDeudor"])) != null)
                if (domiciliodeudorService.GetDomicilioDeudor(deudor.IdDeudor) != null)
                {
                    domiciliodeudor.IdDomicilioAlternativo = int.Parse(Request.Params["idDomicilioDeudor"]);
                    domiciliodeudorService.Update(domiciliodeudor);
                }
                else
                {
                    domiciliodeudor.IdDomicilioAlternativo = int.Parse(Request.Params["idDomicilioDeudor"]);
                    domiciliodeudorService.InsertNuevo(domiciliodeudor);
                }
            }
            else
            {
                domiciliodeudor.IdDomicilioAlternativo = 0;
                domiciliodeudorService.InsertNuevo(domiciliodeudor);
            
            }

            #region horarios

            IDeudorDiaReclamoService deudorDiaReclamoService = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
            string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
            List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
            ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
            //if (mgr.Contains(listaDiasReclamoKey))
            if (Session[listaDiasReclamoKey] != null)
            {
                //listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)mgr.GetData(listaDiasReclamoKey);
                listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)Session[listaDiasReclamoKey];
                foreach (DeudorDiaReclamoDataContracts ddrDTO in listaDiasReclamo)
                {
                    if (ddrDTO.IdDiaReclamo == -1)
                    {
                        ddrDTO.IdDeudor = deudor.IdDeudor;
                        deudorDiaReclamoService.Insert(ddrDTO);
                    }
                }
            }
            listaDiasReclamo.Clear();
            fillTableHorariosReclamo(listaDiasReclamo);

            IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
            string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
            List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
            //if (mgr.Contains(listaDiasCobroKey))
            if (Session[listaDiasCobroKey] != null)
            {
                //listaDiasCobro = (List<DeudorDiaCobroDataContracts>)mgr.GetData(listaDiasCobroKey);
                listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];

                foreach (DeudorDiaCobroDataContracts ddcDTO in listaDiasCobro)
                {
                    if (ddcDTO.IdDiaCobro == -1)
                    {
                        ddcDTO.IdDeudor = deudor.IdDeudor;
                        deudorDiaCobroService.Insert(ddcDTO);
                    }
                }
            }
            listaDiasCobro.Clear();
            fillTableHorariosCobro(listaDiasCobro);

            #endregion


            #region CLIENTE_DEUDOR


            if (listaClientesDeudor != null)
            {

                foreach (ClienteDeudorDataContracts cdDTO in listaClientesDeudor)
                {
                    ClienteDeudorDataContracts clienteDeudorDTO = clienteDeudorService.GetClienteDeudor(cdDTO.IdCliente, cdDTO.IdDeudor);
                    if (clienteDeudorDTO == null)
                    {
                        cdDTO.IdDeudor = deudor.IdDeudor;
                        clienteDeudorService.Insert(cdDTO);
                    }
                }
            }
            listaClientesDeudor.Clear();
            fillTableClientesDeudor(listaClientesDeudor);

            #endregion

            //LimpiarDatos();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup11", "javascript:alert('Los datos han sido guardados satisfactoriamente. Deudor: " + deudor.IdDeudor + "');window.location = 'ViewAltaDeudor.aspx';", true);
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Ha ocurrido un error y los datos no han sido guardados. Detalle técnico:  ' " + ex.Message + "');HideEdicionDeudor();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Ha ocurrido un error y los datos no han sido guardados. Detalle técnico:   " + ex.Message + "');", true);
        }
    }

    private void HabilitarValidatorsNuevoDeudor()
    {
        //this.RequiredFieldValidatorTelNuevo.Enabled = true;
        //this.RequiredFieldValidatorTelAuxNuevo.Enabled = true;
        this.RequiredFieldValidatorProvNuevo.Enabled = true;
        this.RequiredFieldValidatorNombreNuevo.Enabled = true;
        this.RequiredFieldValidatorLocaNuevo.Enabled = true;
        this.RequiredFieldValidatorDomicilioNuevo.Enabled = true;
        //this.RequiredFieldValidatorCuitNuevo.Enabled = true;
        this.RequiredFieldValidatorCPNuevo.Enabled = true;

    }

    private void DeshabilitarValidatorsNuevoDeudor()
    {
        //this.RequiredFieldValidatorTelNuevo.Enabled = false;
        //this.RequiredFieldValidatorTelAuxNuevo.Enabled = false;
        this.RequiredFieldValidatorProvNuevo.Enabled = false;
        this.RequiredFieldValidatorNombreNuevo.Enabled = false;
        this.RequiredFieldValidatorLocaNuevo.Enabled = false;
        this.RequiredFieldValidatorDomicilioNuevo.Enabled = false;
        //this.RequiredFieldValidatorCuitNuevo.Enabled = false;
        this.RequiredFieldValidatorCPNuevo.Enabled = false;

    }

    protected void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Se bindean las provincias
        List<ProvinciaDataContracts> provincias = new List<ProvinciaDataContracts>();
        IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
        provincias = provinciaService.GetAllProvinciasByPais(int.Parse(cmbPais.SelectedValue));
        this.cmbProvincia.SelectedIndex = 0;
        ProvinciaDataContracts seleccioneProvincia = new ProvinciaDataContracts();
        seleccioneProvincia.ID = 0;
        seleccioneProvincia.Nombre = "--- SELECCIONE ---";
        provincias.Insert(0, seleccioneProvincia);
        this.cmbProvincia.Items.Clear();
        this.cmbProvincia.DataSource = provincias;
        this.cmbProvincia.DataBind();
        

        DepartamentoDataContracts seleccioneDepartamento = new DepartamentoDataContracts();
        List<DepartamentoDataContracts> departamentos = new List<DepartamentoDataContracts>();
        this.cmbDepartamento.Items.Clear();
        //seleccioneDepartamento.ID = 0;
        //seleccioneDepartamento.Nombre = "--- SELECCIONE ---";
        //departamentos.Insert(0, seleccioneDepartamento);
        this.cmbDepartamento.Items.Add(new ListItem("--- SELECCIONE ---", "0"));
        

        //this.cmbDepartamento.DataSource = departamentos;
        //this.cmbDepartamento.DataTextField = "NOMBRE";
        //this.cmbDepartamento.DataValueField = "id";
        //this.cmbDepartamento.DataBind();
        //this.cmbDepartamento.SelectedIndex = 0;
  
        LocalidadDataContracts seleccioneLocalidad = new LocalidadDataContracts();
        List<LocalidadDataContracts> localidades = new List<LocalidadDataContracts>();
        //seleccioneLocalidad.ID = 0;
        //seleccioneLocalidad.Nombre = "--- SELECCIONE ---";
      //  localidades.Insert(0, seleccioneLocalidad);
        this.cmbLocalidad.Items.Clear();

        this.cmbLocalidad.Items.Add(new ListItem("--- SELECCIONE ---","0"));

        //this.cmbLocalidad.DataSource = localidades;
        //this.cmbLocalidad.DataTextField = "NOMBRE";
        //this.cmbLocalidad.DataValueField = "id";
        //this.cmbLocalidad.SelectedIndex = 0;
        //this.cmbLocalidad.DataBind();
        





    }

    protected void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        //Se bindean los departamentos
        List<DepartamentoDataContracts> departamentos = null;
        IDepartamentoService departamentoService = ServiceClient<IDepartamentoService>.GetService("DepartamentoService");
        departamentos = departamentoService.GetAllDepartamentosByProvincia(int.Parse(cmbProvincia.SelectedValue));

        this.cmbDepartamento.SelectedIndex = 0;
        this.cmbDepartamento.Items.Clear();

        DepartamentoDataContracts seleccioneDepartamento = new DepartamentoDataContracts();
        seleccioneDepartamento.ID = 0;
        seleccioneDepartamento.Nombre = "--- SELECCIONE ---";
        departamentos.Insert(0, seleccioneDepartamento);
   
        this.cmbDepartamento.DataSource = departamentos;
        this.cmbDepartamento.DataBind();
        this.cmbDepartamento.SelectedIndex = 0;


        LocalidadDataContracts seleccioneLocalidad = new LocalidadDataContracts();
        List<LocalidadDataContracts> localidades = new List<LocalidadDataContracts>();
        //seleccioneLocalidad.ID = 0;
        //seleccioneLocalidad.Nombre = "--- SELECCIONE ---";
        //  localidades.Insert(0, seleccioneLocalidad);
        this.cmbLocalidad.Items.Clear();

        this.cmbLocalidad.Items.Add(new ListItem("--- SELECCIONE ---", "0"));


        }
        catch (Exception)
        {

        }

        //Se pide bindear las localidades
     //   cmbDepartamento_SelectedIndexChanged(sender, e);
    }

    protected void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

        
        //se bindean las localidades
        List<LocalidadDataContracts> localidades = new List<LocalidadDataContracts>();
        ILocalidadService localidadService = ServiceClient<ILocalidadService>.GetService("LocalidadService");
        localidades = localidadService.GetAllLocalidadsByDepartamento(int.Parse(cmbDepartamento.SelectedValue));
        LocalidadDataContracts seleccioneLocalidad = new LocalidadDataContracts();
        this.cmbLocalidad.SelectedIndex = 0;
        seleccioneLocalidad.ID = 0;
        seleccioneLocalidad.Nombre = "--- SELECCIONE ---";
        localidades.Insert(0, seleccioneLocalidad);
        this.cmbLocalidad.Items.Clear();
        this.cmbLocalidad.DataSource = localidades;
        this.cmbLocalidad.DataBind();
      
        }
        catch (Exception)
        {

           // this.cmbLocalidad.SelectedIndex = 0;
        }
    }

    private void LimpiarDatos()
    {
        Response.Redirect("ViewAltaDeudor.aspx");

        //PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        //// make collection editable
        //isreadonly.SetValue(this.Request.QueryString, false, null);

        //this.Request.QueryString.Remove("Id_Deudor");
        //this.idDeudor = "";
        //// make collection readonly again
        //isreadonly.SetValue(this.Request.QueryString, true, null);

        //this.txtAlfaNumDelCliente.Text = "";
        //this.cmbClientes.SelectedIndex = 0;
        //this.txtNombre.Text = "";
        //this.txtCuit.Text = "";
        //this.txtDomicilio.Text = this.txtAltura.Text = "";
        //this.txtCp.Text = "";
        //this.txtTelefono.Text = "";
        //this.txtTelefonoAux.Text = "";
        //this.txtFax.Text = "";
        //this.txtEmail.Text = "";
        //this.txtAnticipo.Text = "";

        //InicializarCombos();    
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

        if (deudor != null) 
        {
            if (this.txtAlfaNumDelCliente.Text == null || this.txtAlfaNumDelCliente.Text.Equals(string.Empty)) this.txtAlfaNumDelCliente.Text = deudor.AlfaNumDelCliente;
            if (this.txtNombre.Text == null || this.txtNombre.Text.Equals(string.Empty)) this.txtNombre.Text = deudor.Nombre;
            if (this.txtCuit.Text == null || this.txtCuit.Text.Equals(string.Empty)) this.txtCuit.Text = deudor.Cuit;
          
        }
        #region combos_domicilio
        List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
        clientes = clienteServices.GetAllClientes();
        ClienteDataContracts seleccioneCliente = new ClienteDataContracts();
        seleccioneCliente.NOMBRE = "--- SELECCIONE ---";
        seleccioneCliente.IdCliente = 0;
        clientes.Insert(0, seleccioneCliente);

        this.cmbClientes.DataSource = clientes;
        this.cmbClientes.DataTextField = "NOMBRE";
        this.cmbClientes.DataValueField = "idCliente";
        this.cmbClientes.DataBind();

        if (deudor == null) 
        {
            this.cmbClientes.SelectedValue = this.idCliente;
        }

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
            try
            {
                this.cmbDepartamento.SelectedValue = domiciliodeudor.IdDepartamento.ToString();
            }
            catch (Exception)
            {
            }
            
        }
        if (Int32.Parse(idCmbDepartamentoSelectedValue) > 0)
        {
            try
            {
                this.cmbDepartamento.SelectedValue = idCmbDepartamentoSelectedValue;
            }
            catch (Exception)
            {

            }
            
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
            try
            {
           
            this.cmbLocalidad.SelectedValue = domiciliodeudor.IdLocalidad.ToString();

            }
            catch (Exception)
            {

            }
        }
        if (Int32.Parse(idCmbLocalidadSelectedValue) > 0)
        {
            try
            {
                this.cmbLocalidad.SelectedValue = idCmbLocalidadSelectedValue;
            }
            catch (Exception)
            {
            }
           
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

        // TODO: Revisar estoooooooo

        if (deudor != null) {

            if (this.txtTelefono.Text == null || this.txtTelefono.Text.Equals(string.Empty)) this.txtTelefono.Text = deudor.Telefono;
            if (this.txtTelefonoAux.Text == null || this.txtTelefonoAux.Text.Equals(string.Empty)) this.txtTelefonoAux.Text = deudor.Telefono_Aux;
            if (this.txtFax.Text == null || this.txtFax.Text.Equals(string.Empty)) this.txtFax.Text = deudor.Fax;
            if (this.txtEmail.Text == null || this.txtEmail.Text.Equals(string.Empty)) this.txtEmail.Text = deudor.Email;
            if (this.txtAnticipo.Text == null || this.txtAnticipo.Text.Equals(string.Empty)) this.txtAnticipo.Text = deudor.AnticipoGestion.ToString();
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


        fillHorariosReclamo();
        fillHorariosCobro();
        fillClientesDeudor();
    }

    protected void btnAgregarHorarioReclamo_Click(object sender, EventArgs e)
    {

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
        List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
        /*if (mgr.Contains(listaDiasReclamoKey))
        {
            listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)mgr.GetData(listaDiasReclamoKey);
        }
        else {
            listaDiasReclamo = new List<DeudorDiaReclamoDataContracts>();
            mgr.Add(listaDiasReclamoKey, listaDiasReclamo);
        }*/
        if (Session[listaDiasReclamoKey] != null)
        {
            listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)Session[listaDiasReclamoKey];
        }
        else
        {
            listaDiasReclamo = new List<DeudorDiaReclamoDataContracts>();
            Session[listaDiasReclamoKey] = listaDiasReclamo;
        }

        DeudorDiaReclamoDataContracts ddrDTO = new DeudorDiaReclamoDataContracts();
        if (this.idDeudor != null)
        {
            ddrDTO.IdDeudor = int.Parse(this.idDeudor);
        }
        ddrDTO.IdDiaReclamo = -1;
        ddrDTO.IdDia = int.Parse(this.cmbDiasReclamo.SelectedItem.Value);
        int horaDesdeAMPM = this.tsHorarioDesde.Hour;
        int horaHastaAMPM = this.tsHorarioHasta.Hour;

        //if (this.tsHorarioDesde.AmPm == MKB.TimePicker.TimeSelector.AmPmSpec.PM)
        //{
        //    if (this.tsHorarioDesde.Hour == 12)
        //    {
        //        horaDesdeAMPM = 0;
        //    }
        //    else
        //    {
        //        horaDesdeAMPM = this.tsHorarioDesde.Hour + 12;
        //    }
        //}
        //if (this.tsHorarioHasta.AmPm == MKB.TimePicker.TimeSelector.AmPmSpec.PM)
        //{
        //    if (this.tsHorarioHasta.Hour == 12)
        //    {
        //        horaHastaAMPM = 0;
        //    }
        //    else
        //    {
        //        horaHastaAMPM = this.tsHorarioHasta.Hour + 12;
        //    }
        //}

        ddrDTO.HorarioDesde = horaDesdeAMPM.ToString("00") + ":" + this.tsHorarioDesde.Minute.ToString("00");
        ddrDTO.HorarioHasta = horaHastaAMPM.ToString("00") + ":" + this.tsHorarioHasta.Minute.ToString("00");

        listaDiasReclamo.Insert(listaDiasReclamo.Count, ddrDTO);
        fillTableHorariosReclamo(listaDiasReclamo);


        fillHorariosCobro();
       
        //        fillHorariosReclamo();
        //IDeudorDiaReclamoService deudorDiaReclamoService = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
        //deudorDiaReclamoService.Insert(ddrDTO);
    }

    protected void btnAgregarClienteDeudor_Click(object sender, EventArgs e)
    {

        if (int.Parse(this.cmbClientes.SelectedItem.Value) == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Debe seleccionar un cliente.');", true);

            return;
        }

        if (txtAlfaNumDelCliente.Text.Trim().Length == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Debe ingresar Alfanumérico del Cliente.');", true);

            return;
        }


        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaClientesDeudorKey = Session.SessionID + "ClientesDeudor";
        List<ClienteDeudorDataContracts> listaClientesDeudor = null;
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

        cdDTO.IdCliente = int.Parse(this.cmbClientes.SelectedItem.Value);
        cdDTO.Alfanumdelcliente = txtAlfaNumDelCliente.Text;
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
        fillTableClientesDeudor(listaClientesDeudor);
    }

    protected void btnAgregarHorarioCobro_Click(object sender, EventArgs e)
    {

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
        if (Session[listaDiasCobroKey] != null)
        {
            listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];
        }
        else
        {
            listaDiasCobro = new List<DeudorDiaCobroDataContracts>();
            Session[listaDiasCobroKey] = listaDiasCobro;
        }
        DeudorDiaCobroDataContracts ddrDTO = new DeudorDiaCobroDataContracts();
        if (this.idDeudor != null)
        {
            ddrDTO.IdDeudor = int.Parse(this.idDeudor);
        }
        ddrDTO.IdDiaCobro = -1;
        ddrDTO.IdDia = int.Parse(this.cmbDiasCobro.SelectedItem.Value);
        int horaDesdeAMPM = this.tsHorarioDesdeCobro.Hour;
        int horaHastaAMPM = this.tsHorarioHastaCobro.Hour;

        //if (this.tsHorarioDesdeCobro.AmPm == MKB.TimePicker.TimeSelector.AmPmSpec.PM)
        //{
        //    if (this.tsHorarioDesdeCobro.Hour == 12)
        //    {
        //        horaDesdeAMPM = 0;
        //    }
        //    else
        //    {
        //        horaDesdeAMPM = this.tsHorarioDesdeCobro.Hour + 12;
        //    }

        //}
        //if (this.tsHorarioHastaCobro.AmPm == MKB.TimePicker.TimeSelector.AmPmSpec.PM)
        //{
        //    if (this.tsHorarioHastaCobro.Hour == 12)
        //    {
        //        horaHastaAMPM = 0;
        //    }
        //    else
        //    {
        //        horaHastaAMPM = this.tsHorarioHastaCobro.Hour + 12;
        //    }

        //}

        ddrDTO.HorarioDesde = horaDesdeAMPM.ToString("00") + ":" + this.tsHorarioDesdeCobro.Minute.ToString("00");
        ddrDTO.HorarioHasta = horaHastaAMPM.ToString("00") + ":" + this.tsHorarioHastaCobro.Minute.ToString("00");

        listaDiasCobro.Insert(listaDiasCobro.Count, ddrDTO);
        fillTableHorariosCobro(listaDiasCobro);

        fillHorariosReclamo();
    }



    protected void fillTableHorariosReclamo(List<DeudorDiaReclamoDataContracts> listaDiasReclamo)
    {
        IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
        TableCell cell = null;
        TableRow row = null;
        this.tblHorariosReclamo.Rows.Clear();
        this.tblHorariosReclamo.BorderWidth = 1;
        this.tblHorariosReclamo.CellPadding = 1;

        for (int i = 0; i < listaDiasReclamo.Count; i++)
        {
            DeudorDiaReclamoDataContracts ddrDTO = listaDiasReclamo.ElementAt(i);

            row = new TableRow();
            cell = new TableCell();
            cell.Text = diasService.GetDias(ddrDTO.IdDia).Descripcion;
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = ddrDTO.HorarioDesde;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = ddrDTO.HorarioHasta;
            row.Cells.Add(cell);

            cell = new TableCell();
            LinkButton link = new LinkButton();
            link.Attributes.Add("runat", "server");
            link.Command += new CommandEventHandler(OnDeleteHorarioReclamo);
            link.CommandName = i.ToString();
            link.CommandArgument = i.ToString();
            link.Visible = true;
            link.Text = "Eliminar";
            link.ID = "lnkEliminarHR_" + i.ToString(); ;
            cell.Controls.Add(link);
            row.Cells.Add(cell);
            this.tblHorariosReclamo.Rows.Add(row);
            this.tblHorariosReclamo.CssClass = "gvAlternatingItem";
        }
    }

    protected void fillHorariosReclamo()
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
        List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
  
        if (Session[listaDiasReclamoKey] != null)
        {
            listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)Session[listaDiasReclamoKey];
        }
        else
        {
            listaDiasReclamo = new List<DeudorDiaReclamoDataContracts>();
            Session[listaDiasReclamoKey] = listaDiasReclamo;
        }

        IDeudorDiaReclamoService deudorDiaReclamoService = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
        if (this.idDeudor != null && listaDiasReclamo.Count == 0)
        {
            listaDiasReclamo.AddRange(deudorDiaReclamoService.GetAllDeudorDiaReclamo(int.Parse(this.idDeudor)));
        }

        fillTableHorariosReclamo(listaDiasReclamo);
    }


    protected void OnDeleteHorarioReclamo(object sender, CommandEventArgs e)
    {
        string idToDelete = e.CommandArgument.ToString();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamo";
        List<DeudorDiaReclamoDataContracts> listaDiasReclamo = null;
        if (Session[listaDiasReclamoKey] != null)
        {
            listaDiasReclamo = (List<DeudorDiaReclamoDataContracts>)Session[listaDiasReclamoKey];
            DeudorDiaReclamoDataContracts ddrDTO = listaDiasReclamo.ElementAt(int.Parse(idToDelete));

            if (ddrDTO.IdDiaReclamo != -1)
            {
                IDeudorDiaReclamoService deudorDiaReclamoService = ServiceClient<IDeudorDiaReclamoService>.GetService("DeudorDiaReclamoService");
                deudorDiaReclamoService.Delete(ddrDTO);
            }

            listaDiasReclamo.RemoveAt(int.Parse(idToDelete));
        }
        fillTableHorariosReclamo(listaDiasReclamo);
    }

    protected void fillTableClientesDeudor(List<ClienteDeudorDataContracts> listaClientesDeudor)
    {
        IClienteService clienteService = ServiceClient<IClienteService>.GetService("ClienteService");
        TableCell cell = null;
        TableRow row = null;
        this.tblClientesDeudor.Rows.Clear();
        this.tblClientesDeudor.BorderWidth = 1;
        this.tblClientesDeudor.CellPadding = 1;

        for (int i = 0; i < listaClientesDeudor.Count; i++)
        {
            ClienteDeudorDataContracts cdDTO = listaClientesDeudor.ElementAt(i);

            row = new TableRow();

            cell = new TableCell();
            cell.Text = clienteService.GetCliente(cdDTO.IdCliente).NOMBRE;
            row.Cells.Add(cell);

            cell = new TableCell();

            cell.Text = cdDTO.Alfanumdelcliente;
            row.Cells.Add(cell);

            cell = new TableCell();
            LinkButton link = new LinkButton();
            link.Attributes.Add("runat", "server");
            link.Attributes.Add("ValidationGroup", "alfaNumGroup");
            link.Attributes.Add("CausesValidation", "true");
            link.CausesValidation = true;

            link.Command += new CommandEventHandler(OnDeleteClienteDeudor);
            link.CommandName = i.ToString();
            link.CommandArgument = i.ToString();
            link.Visible = true;
            link.Text = "Eliminar";
            link.ID = "lnkEliminarCD_" + i.ToString(); ;
            //link.Click += new CommandEventHandler(OnDeleteHorarioCobro);
            cell.Controls.Add(link);
            row.Cells.Add(cell);

            this.tblClientesDeudor.Rows.Add(row);
            this.tblClientesDeudor.CssClass = "gvAlternatingItem";


        }
    }

    protected void fillTableHorariosCobro(List<DeudorDiaCobroDataContracts> listaDiasCobro)
    {
        IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
        TableCell cell = null;
        TableRow row = null;
        this.tblHorariosCobro.Rows.Clear();
        this.tblHorariosCobro.BorderWidth = 1;
        this.tblHorariosCobro.CellPadding = 1;

        for (int i = 0; i < listaDiasCobro.Count; i++)
        {
            DeudorDiaCobroDataContracts ddrDTO = listaDiasCobro.ElementAt(i);

            row = new TableRow();

            cell = new TableCell();
            cell.Text = diasService.GetDias(ddrDTO.IdDia).Descripcion;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = ddrDTO.HorarioDesde;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = ddrDTO.HorarioHasta;
            row.Cells.Add(cell);

            cell = new TableCell();
            LinkButton link = new LinkButton();
            link.Attributes.Add("runat", "server");
            link.Command += new CommandEventHandler(OnDeleteHorarioCobro);

            link.CommandName = i.ToString();
            link.CommandArgument = i.ToString();
            link.Visible = true;
            link.Text = "Eliminar";
            link.ID = "lnkEliminarHC_" + i.ToString(); ;
            //link.Click += new EventHandler(OnDeleteHorarioCobro);
            cell.Controls.Add(link);
            row.Cells.Add(cell);

            this.tblHorariosCobro.Rows.Add(row);
            this.tblHorariosCobro.CssClass = "gvAlternatingItem";
        }
    }



    protected void fillClientesDeudor()
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaClientesDeudorKey = Session.SessionID + "ClientesDeudor";
        List<ClienteDeudorDataContracts> listaClientesDeudor = null;
 
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

        fillTableClientesDeudor(listaClientesDeudor);

    }

    protected void fillHorariosCobro()
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
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

        fillTableHorariosCobro(listaDiasCobro);

    }


    protected void OnDeleteHorarioCobro(object sender, CommandEventArgs e)
    //protected void OnDeleteHorarioCobro(object sender, EventArgs e)
    {
        string idToDelete = e.CommandArgument.ToString();
        //string idToDelete = ((LinkButton)sender).CommandArgument.ToString();

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaDiasCobroKey = Session.SessionID + "HorariosCobro";
        List<DeudorDiaCobroDataContracts> listaDiasCobro = null;
        if (Session[listaDiasCobroKey] != null)
        {
            listaDiasCobro = (List<DeudorDiaCobroDataContracts>)Session[listaDiasCobroKey];
            DeudorDiaCobroDataContracts ddrDTO = listaDiasCobro.ElementAt(int.Parse(idToDelete));

            if (ddrDTO.IdDiaCobro != -1)
            {
                IDeudorDiaCobroService deudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
                deudorDiaCobroService.Delete(ddrDTO);
            }

            listaDiasCobro.RemoveAt(int.Parse(idToDelete));
        }

        fillTableHorariosCobro(listaDiasCobro);
    }


    protected void OnDeleteClienteDeudor(object sender, CommandEventArgs e)
    {
        string idToDelete = e.CommandArgument.ToString();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        string listaClientesDeudorKey = Session.SessionID + "ClientesDeudor";
        List<ClienteDeudorDataContracts> listaClientesDeudor = null;
        IClienteDeudorService clienteDeudorService = ServiceClient<IClienteDeudorService>.GetService("ClienteDeudorService");
        if (Session[listaClientesDeudorKey] != null)
        {
            listaClientesDeudor = (List<ClienteDeudorDataContracts>)Session[listaClientesDeudorKey];
            ClienteDeudorDataContracts cdDTO = listaClientesDeudor.ElementAt(int.Parse(idToDelete));
            ClienteDeudorDataContracts clienteDeudorDTO = clienteDeudorService.GetClienteDeudor(cdDTO.IdCliente, cdDTO.IdDeudor);

            if (clienteDeudorDTO != null)
            {
                clienteDeudorService.Delete(cdDTO);
            }

            listaClientesDeudor.RemoveAt(int.Parse(idToDelete));
        }

        fillTableClientesDeudor(listaClientesDeudor);
    }
    //protected void btnVolver_Click1(object sender, EventArgs e)
    //{
    //    //Response.Redirect("ViewGestionDeDeudores.aspx?restoreFilters=hola",true);
    //    Server.TransferRequest("ViewGestionDeDeudores.aspx?restoreFilters=hola", true);
    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript: document.open('ViewPopUpProximasGestiones.aspx','_blank','height=470px,width=520px,scrollbars=no,resizable=no,location=no');", true);
    //   // Response.Redirect("ViewAltaDeudor.aspx?Id_Deudor=" + GvResultados.DataKeys[e.NewEditIndex].Value.ToString() + "&idDomicilioDeudor=" + idDomicilioDeudor.ToString(), true);
    //}
}