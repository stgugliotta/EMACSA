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
using System.Collections;
using System.Collections.Generic;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.services;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using Herramientas;
using Gobbi.CoreServices.Security.Principal;

public partial class Vistas_ViewPopUpHitoFactura : GobbiPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        this.btnAplicar.Enabled = true;
        List<string> lista = new List<string>();
        if (Request.Params["window"] != null && Request.Params["window"] != string.Empty)
        {
            string window = Request.Params["window"];
            this.HiddenFieldWindowsName.Value = window;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "window", "javascript:var windowsOpen=" + window + ";');", true);
        }

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        //int idDeudor = int.Parse((string)mgr.GetData("deudorSeleccionado"));
        int idDeudor = int.Parse((string)Session["deudorSeleccionado"]);
        //lista = (List<string>)mgr.GetData("SeleccionGrillaFacturasSeleccionadas");
        lista = (List<string>)Session["SeleccionGrillaFacturasSeleccionadas"];
        //this.lblResNombreCliente.Text = (string)mgr.GetData("lblClienteSeleccionado");
        //this.lblResNombreDeudor.Text = (string)mgr.GetData("lblDeudorSeleccionado");
        this.lblResNombreCliente.Text = (string)Session["lblClienteSeleccionado"];
        this.lblResNombreDeudor.Text = (string)Session["lblDeudorSeleccionado"];
        List<FacturaDataContracts> listaFacturasSeleccionadas = new List<FacturaDataContracts>();

        IDomicilioDeudorAlternativoService domicilioAlternativoService = ServiceClient<IDomicilioDeudorAlternativoService>.GetService("DomicilioDeudorAlternativoService");
        List<DomicilioDeudorAlternativoDataContracts> resultadoObtenidosDomiciliosAlternativos = new List<DomicilioDeudorAlternativoDataContracts>();
        resultadoObtenidosDomiciliosAlternativos = domicilioAlternativoService.GetAllDomicilioDeudorsPorIdDeudor(idDeudor);
        this.cmbDomicilioAlternativo.DataTextField = "CalleNombre";
        this.cmbDomicilioAlternativo.DataValueField = "IdDeudorDomicilioAlternativo";
        this.cmbDomicilioAlternativo.DataSource = resultadoObtenidosDomiciliosAlternativos;
        this.cmbDomicilioAlternativo.DataBind();

        List<FacturaDataContracts> resultadoObtenidos = new List<FacturaDataContracts>();
        IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
        resultadoObtenidos = facturaServices.GetAllFacturasPorIdDeudor(idDeudor);

        DataTable dataTable = ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);

        foreach (string dataKey in lista)
        {
            if (dataTable.Select("idFactura = '" + dataKey + "'").Length > 0)
            {

                foreach (DataRow dr in dataTable.Select("idFactura =  '" + dataKey + "'"))
                {
                    FacturaDataContracts nuevaFactura = null;
                    nuevaFactura = facturaServices.Load(int.Parse(dataKey));
                    listaFacturasSeleccionadas.Add(nuevaFactura);
                }
            }
        }


        if (!IsPostBack)
        {
            this.PanelDomicilioAlternativo.Enabled = false;
            hdDiaCobro.Value = hdDiasDeCobro.Value = "";

            List<DeudorDiaCobroDataContracts> lstDeudorDiaCobro = new List<DeudorDiaCobroDataContracts>();
            IDeudorDiaCobroService DeudorDiaCobroService = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
            lstDeudorDiaCobro = DeudorDiaCobroService.GetAllDeudorDiaCobrosPorIdDeudor(idDeudor);

            foreach (DeudorDiaCobroDataContracts ddc in lstDeudorDiaCobro)
            {
                hdDiaCobro.Value += ddc.IdDia + " - ";

                DiasDataContracts Dia = new DiasDataContracts();
                IDiasService DiasService = ServiceClient<IDiasService>.GetService("DiasService");
                Dia = DiasService.GetDias(ddc.IdDia);
                hdDiasDeCobro.Value += Dia.Descripcion + " , ";

            }

        }
        cargarHorariosCobro();

        DataTable dataTable2 = ConvertDataTable<FacturaDataContracts>.Convert(listaFacturasSeleccionadas);
        this.GvResultados.DataSource = dataTable2;
        this.GvResultados.DataBind();

        if (dataTable2.Rows.Count == 0)
        {
            this.btnAplicar.Enabled = false;

        }

    }

    protected void fillTableHorariosReclamo(List<DeudorDiaReclamoAlternativoDataContracts> listaDiasReclamoAlternativo)
    {
        IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");
        TableCell cell = null;
        TableRow row = null;
        int pos=0;
        foreach (DeudorDiaReclamoAlternativoDataContracts item in listaDiasReclamoAlternativo)
        {
            pos++;
            item.Position = pos;
        }

            myRepeater.DataSource = listaDiasReclamoAlternativo;
            myRepeater.DataBind();
        this.UpdatePanelHorariosAlternativos.Update();
        
    }

    protected void OnDeleteHorarioReclamo(object sender, CommandEventArgs e)
    {
        string idToDelete = e.CommandArgument.ToString();
        List<DeudorDiaReclamoAlternativoDataContracts> listaDiasReclamoAlternativo = (List<DeudorDiaReclamoAlternativoDataContracts>)Session["HorariosAlternativos"];

            DeudorDiaReclamoAlternativoDataContracts ddrDTO = listaDiasReclamoAlternativo.ElementAt(int.Parse(idToDelete)-1);

            if (ddrDTO.IdDiaReclamo != -1)
            {
                IDeudorDiaReclamoAlternativoService deudorDiaReclamoAlternativoService = ServiceClient<IDeudorDiaReclamoAlternativoService>.GetService("DeudorDiaReclamoAlternativoService");
                deudorDiaReclamoAlternativoService.Delete(ddrDTO);



            }

            listaDiasReclamoAlternativo.RemoveAt(int.Parse(idToDelete)-1);


        fillTableHorariosReclamo(listaDiasReclamoAlternativo);
    }

    protected void HabilitarPanelDomicilioAlternativo_CheckedChanged(object sender, EventArgs e)
    {

        if (this.chkDomicilioAlternativo.Checked)
        {
            this.PanelDomicilioAlternativo.Enabled = true;
            this.chkDomicilioAlternativo.Checked = true;
        }
        else
        {
            this.PanelDomicilioAlternativo.Enabled = false;
            this.chkDomicilioAlternativo.Checked = false;
        }
    }
    private void cargarHorariosCobro() { 
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int idDeudor = Int32.Parse(Session["deudorSeleccionado"].ToString());
        IDeudorDiaReclamoAlternativoService deudorDiaReclamoServiceAlternativo = ServiceClient<IDeudorDiaReclamoAlternativoService>.GetService("DeudorDiaReclamoAlternativoService");
        List<DeudorDiaReclamoAlternativoDataContracts> listaDiaReclamoAlternativo = deudorDiaReclamoServiceAlternativo.GetAllDeudorDiaReclamoAlternativo(idDeudor);
        fillTableHorariosReclamo(listaDiaReclamoAlternativo);

        if (Session["HorariosAlternativos"]!=null)
               Session["HorariosAlternativos"]=null;
        Session["HorariosAlternativos"]=listaDiaReclamoAlternativo;

    }

    protected void btnAgregarHorarioReclamo_Click(object sender, EventArgs e)
    {

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int idDeudor = Int32.Parse(Session["deudorSeleccionado"].ToString());

        DeudorDiaReclamoAlternativoDataContracts ddrDTO = new DeudorDiaReclamoAlternativoDataContracts();
        if (idDeudor > 0)
        {
            ddrDTO.IdDeudor = idDeudor;
        }
        ddrDTO.IdDiaReclamo = (int)DateTime.Now.DayOfWeek;
        ddrDTO.IdAccion = 0;
        ddrDTO.IdDia = (int)DateTime.Now.DayOfWeek;
        //int horaDesdeAMPM = this.tsHorarioDesde.this.tsHorarioDesde.SelectedItem.Value
        //int horaHastaAMPM = this.tsHorarioHasta.Hour;

        ddrDTO.HorarioDesde = this.tsHorarioDesde.SelectedItem.Value;
        ddrDTO.HorarioHasta = this.tsHorarioHasta.SelectedItem.Value;
        List<DeudorDiaReclamoAlternativoDataContracts>  listaDiasReclamo = new List<DeudorDiaReclamoAlternativoDataContracts>();
        IDeudorDiaReclamoAlternativoService deudorDiaReclamoServiceAlternativo = ServiceClient<IDeudorDiaReclamoAlternativoService>.GetService("DeudorDiaReclamoAlternativoService");
    deudorDiaReclamoServiceAlternativo.InsertHorarioAlterntivoDeCobro(ddrDTO);
        listaDiasReclamo = deudorDiaReclamoServiceAlternativo.GetAllDeudorDiaReclamoAlternativo(idDeudor);
        if (Session["HorariosAlternativos"] != null)
            Session["HorariosAlternativos"]=null;
        Session["HorariosAlternativos"] = listaDiasReclamo;

      
        

        fillTableHorariosReclamo(listaDiasReclamo);


    }


    protected void GvResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {

        List<LOG_FacturaDataContracts> resultadoObtenidos = new List<LOG_FacturaDataContracts>();
        ILOG_FacturaService logFacturaServices = ServiceClient<ILOG_FacturaService>.GetService("LOG_FacturaService");
        this.GvResultados.SelectedIndex = e.NewEditIndex;
        resultadoObtenidos = logFacturaServices.GetAllLogFacturasByIdFactura(int.Parse(GvResultados.Rows[e.NewEditIndex].Cells[1].Text));

        this.lstResHistorial.Items.Clear();
        foreach (LOG_FacturaDataContracts item in resultadoObtenidos)
        {
            this.lstResHistorial.Items.Add("Fecha Actividad: " + item.FechaActividad.ToString() + " - Usuario: " + item.Usuario + " - Actividad: " + item.Observacion);
        }
    }

    private void ObtenerHistorial(int idFactura)
    {
        List<LOG_FacturaDataContracts> resultadoObtenidos = new List<LOG_FacturaDataContracts>();
        ILOG_FacturaService logFacturaServices = ServiceClient<ILOG_FacturaService>.GetService("LOG_FacturaService");
        resultadoObtenidos = logFacturaServices.GetAllLogFacturasByIdFactura(idFactura);

        this.lstResHistorial.Items.Clear();
        foreach (LOG_FacturaDataContracts item in resultadoObtenidos)
        {
            this.lstResHistorial.Items.Add("Fecha Actividad: " + item.FechaActividad.ToString() + " - Usuario: " + item.Usuario + " - Actividad: " + item.Observacion);
        }

    }





    protected void Aplicar_Click(object sender, EventArgs e)
    {
        string esParaCobrar = this.cmbAccion.SelectedValue;
        string domicilioDeCobroDeudor = string.Empty;
        string telefonoDeudor = string.Empty;
        string alfanum = string.Empty;
        string observacionesDeudor = string.Empty;
        if (!validarAgendarParaField(esParaCobrar.Equals("A_COBRAR")))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Ingrese una fecha de gestión correcta.');", true);
            return;
        }
        DateTime minFechaVencimiento = new DateTime();
        List<int> listaFacturas = new List<int>();

        foreach (System.Web.UI.WebControls.GridViewRow dr in this.GvResultados.Rows)
        {
            AccionDataContracts accion = new AccionDataContracts();

            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            accion.Usuario = (principal.Identity.Name);

            accion.FechaAccion = DateTime.Now;

            accion.IdFactura = int.Parse(dr.Cells[1].Text);

            listaFacturas.Add(accion.IdFactura);
            accion.Observacion =  this.cmbObservaciones.SelectedValue + " / " + this.txtInfoComplementaria.Text;

            int idCliente = int.Parse(Session["clienteSeleccionado"].ToString());

            accion.IdCliente = idCliente;

            accion.FechaVencimiento = DateTime.Parse(dr.Cells[3].Text);

            if (accion.FechaVencimiento <= DateTime.MaxValue)
                minFechaVencimiento = accion.FechaVencimiento;

            accion.IdDeudor = int.Parse(Session["deudorSeleccionado"].ToString());
            IDeudorService deudorService = ServiceClient<IDeudorService>.GetService("DeudorService");

            DeudorDataContracts deudor = deudorService.GetDeudor(accion.IdDeudor);
            telefonoDeudor = deudor.Telefono + " / " + deudor.Telefono_Aux;
            alfanum = deudor.AlfaNumDelCliente;
            observacionesDeudor = deudor.Tipo; // Se utiliza el campo Tipo para guardar las observaciones
            IDomicilioDeudorService domicilioDeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
            DomicilioDeudorDataContracts domicilioDeudorDataContract = domicilioDeudorService.GetDomicilioDeudor(accion.IdDeudor);
            domicilioDeCobroDeudor = domicilioDeudorDataContract.CalleNombre + " " + domicilioDeudorDataContract.CalleAltura + ", " + domicilioDeudorDataContract.Depto;
            if (domicilioDeudorDataContract == null && this.cmbAccion.SelectedValue == "A_COBRAR")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "AvisoSinDomicilio", "javascript:ConfirmarCargarDomicilioSiNoExiste('" + accion.IdDeudor + "');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "AvisoSinDomicilio", "javascript:alert('No puede realizar la operación si el deudor no tiene domicilio asociado.');", true);
                return;
            }

            //quitar este hardcodeo
            if (this.cmbAccion.SelectedValue == "INGRESADA")
                accion.IdEstado = 1;

            if (this.cmbAccion.SelectedValue == "A_GESTION")
            {
                accion.IdEstado = 2;
                accion.Observacion =accion.Observacion + " / Fecha de nueva gestión: " + DateTime.Parse(this.txtFecha.Text + " " + timeSelector.Hour.ToString() + ":" + timeSelector.Minute.ToString() + " " + timeSelector.AmPm.ToString()); 
            }
            if (this.cmbAccion.SelectedValue == "A_COBRAR")
            {
                accion.IdEstado = 3;
                accion.Observacion = accion.Observacion + " / Fecha de cobro Agendada: " + DateTime.Parse(this.txtFecha.Text);
                accion.InformacionComplementaria = ((string)Session["lblCuandoCobrar"]).Replace("<br/>", "; ");
            }
            //
            if (this.cmbAccion.SelectedValue == "BAJA DEFINITIVA GEST.")
            {
                accion.IdEstado = 8;
                accion.Observacion = accion.Observacion + " / Baja Definitiva Gestión ";
            }

            if (this.cmbAccion.SelectedValue == "PRONTO_PAGO")
                accion.IdEstado = 4;

            if (this.cmbAccion.SelectedValue == "COBRADA")
                accion.IdEstado = 5;

            accion.ProximaGestion = DateTime.Parse(this.txtFecha.Text + " " + timeSelector.Hour.ToString() + ":" + timeSelector.Minute.ToString() + " " + timeSelector.AmPm.ToString());
           
            if (this.chkDomicilioAlternativo.Checked)
            {
                if (cmbDomicilioAlternativo.Items.Count == 0)
             
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso2", "alert('Tiene tildada la opción de Domicilio alternativo y no tiene seleccionado ninguno.');", true);
                    return;
                }

                DomicilioDeudorAlternativoDataContracts domicilioAlternativo = new DomicilioDeudorAlternativoDataContracts();
                IDomicilioDeudorAlternativoService domicilioDeudorAlternativoService = ServiceClient<IDomicilioDeudorAlternativoService>.GetService("DomicilioDeudorAlternativoService");
                accion.IdDomicilioAlternativo = int.Parse(cmbDomicilioAlternativo.SelectedItem.Value);
            }
            else
                accion.IdDomicilioAlternativo = 0;



            IAccionService AccionServices = ServiceClient<IAccionService>.GetService("AccionService");
            AccionServices.Insert(accion);
            this.lstResHistorial.Items.Clear();

            //AgendaDataContracts agendaDataContracts = new AgendaDataContracts();

            //agendaDataContracts.Estado = "PENDIENTE";
            //agendaDataContracts.FechaDeAlerta = DateTime.Parse(this.txtFecha.Text + " " + this.timeSelector.Hour.ToString() + ":" + this.timeSelector.Minute.ToString() + ":00 " + this.timeSelector.AmPm.ToString());
            //agendaDataContracts.Tarea = this.cmbObservaciones.SelectedValue + " / " + this.txtInfoComplementaria.Text;
            //agendaDataContracts.Usuario = accion.Usuario;
            //agendaDataContracts.Criticidad = "ALTA";

            //IAgendaService agendaService = ServiceClient<IAgendaService>.GetService("AgendaService");
            //agendaService.Insert(agendaDataContracts);

            if (GvResultados.SelectedRow != null)
            {
                ObtenerHistorial(int.Parse(GvResultados.SelectedRow.Cells[1].Text));
            }


        }

        try
        {





            if (this.chkEnviarEmail.Checked)
            {

                string pszParametros = "?id_cliente=" + Session["ClienteSeleccionado"].ToString();
                pszParametros += "&id_deudor=" + (string)Session["deudorSeleccionado"];
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up", "javascript:AbrirVentanaAjustable('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewMailEstadoCuenta.aspx" + pszParametros + "','_blank',800,600);", true);
         }



        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso2", "alert('Hubo un error al enviar el email.');", true);

        }

        finally
        {
            Page_Load(sender, e);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso3", "alert('La acción fue realizada con exito.');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "cerrar", "self.close();", true);
        string pszParametrosParte = "?id_cliente=" + Session["ClienteSeleccionado"].ToString();
        pszParametrosParte += "&id_deudor=" + (string)Session["deudorSeleccionado"];
  
        Session["lblCobrador"] = "Cobrador";
        Session["lblFechaPrimVenc"] = minFechaVencimiento.ToShortDateString();
        Session["lblFechaGeneracion"] = DateTime.Now.ToShortDateString();
        Session["lblFechaEmision"] = DateTime.Now.ToShortDateString();
        Session["lblDireccionCliente"] = string.Empty;
        Session["lblTelefonoCliente"] = string.Empty;
        Session["lblNombreCliente"] = (string)Session["lblClienteSeleccionado"];
        Session["lblAlfanum"] = alfanum;
        Session["lblTelefonoDeudor"] = telefonoDeudor;
        Session["lblObservaciones"] = string.IsNullOrEmpty(observacionesDeudor) ? string.Empty : observacionesDeudor;
        Session["listaIdsFacturas"] = listaFacturas;

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Abrir Pop Up Parte", "javascript:AbrirVentanaAjustable('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewParte.aspx" + pszParametrosParte + "','_blank',800,600);", true);
 
    }

   

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "cerrarPopUp", "javascript:window.close();", true);

    }

    protected void agendarParaFieldValidate(object source, ServerValidateEventArgs args)
    {

        try
        {

            if (this.cmbObservaciones.SelectedValue.Trim().IndexOf("llamar") > 0)
            {

                if (this.txtFecha.Text == null || this.txtFecha.Text.Trim() == "")
                {

                    throw new Exception();
                }


            }

        }

        catch (Exception ex)
        {

            args.IsValid = false;

        }

    }

    private Boolean validarAgendarParaField()
    {


        if (this.txtFecha.Text == null || this.txtFecha.Text.Trim() == "" ||DateTime.Parse(this.txtFecha.Text)<DateTime.Now)
        {

            return false;
        }



        return true;

    }

    private Boolean validarAgendarParaField(bool esParaCobrar)
    {

        if (esParaCobrar)
        {

            if (this.txtFecha.Text == null || this.txtFecha.Text.Trim() == "" || DateTime.Parse(this.txtFecha.Text) <= DateTime.Now)
            {

                return false;
            }
            
        }
        else
        {
            if (this.txtFecha.Text == null || this.txtFecha.Text.Trim() == "" || DateTime.Parse(this.txtFecha.Text).Date < DateTime.Now.Date)
            {

                return false;
            }
        }

        return true;

    }

    protected void btnShowPopupHorariosReclamo_Click(object sender, EventArgs e)
    {
        string listaDiasReclamoKey = Session.SessionID + "HorariosReclamoPopupHitoFactura";
        List<DeudorDiaReclamoAlternativoDataContracts> listaDiasReclamo = null; //new List<DeudorDiaReclamoAlternativoDataContracts>();
        if (Session[listaDiasReclamoKey] != null)
        {
            listaDiasReclamo = (List<DeudorDiaReclamoAlternativoDataContracts>)Session[listaDiasReclamoKey];
        }
        else
        {
            listaDiasReclamo = new List<DeudorDiaReclamoAlternativoDataContracts>();
            Session[listaDiasReclamoKey] = listaDiasReclamo;
        }


        fillTableHorariosReclamo(listaDiasReclamo);

        //        initializeHorariosReclamoDeudor();
//        this.ModalPopupHorariosReclamo.Show();
    }


    protected void btnAgregarDomicilioAlternativo_Click(object sender, EventArgs e)
    {
        string url = "ViewABMDomicilio.aspx?Id_Deudor="  + Session["deudorSeleccionado"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewOpenParent", "javascript:OpenViewParent('" + url + "');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "cerrar", "self.close();", true);
    }

    protected void txtInfoComplementaria_TextChanged(object sender, EventArgs e)
    {

    }
}
