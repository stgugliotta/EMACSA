using System;
using System.Collections;
using System.Collections.Generic;
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
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using Herramientas;
using System.IO;
using CarlosAg.ExcelXmlWriter;
using Gobbi.CoreServices.Security.Principal;
using ExcelXmlWriter;
using System.Net;

public partial class Vistas_ViewHojaDeRutaABM : GobbiPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewHojaDeRutaABM));

            pnlAlta.Visible = true;
            pnlModificacion.Visible = false;
            pnlConsulta.Visible = true;
            toggleDivDSG(false);
            pnlModificacionDeudoresSinGestion.Visible = false;

            List<ClienteDataContracts> clientes = new List<ClienteDataContracts>();
            IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");

            clientes = clienteServices.GetAllClientes();
            this.cmbClientes.DataSource = clientes;
            this.cmbClientes.DataTextField = "NOMBRE";
            this.cmbClientes.DataValueField = "idCliente";
            this.cmbClientes.DataBind();

            this.cmbCobrador.DataSource = GetTableCobrador();
            this.cmbCobrador.DataTextField = "Apellido";
            this.cmbCobrador.DataValueField = "Id";
            this.cmbCobrador.DataBind();


        }
    }
    protected void btnBuscarActivas_Click(object sender, EventArgs e)
    {

        //pnlAlta.Visible = false;
        pnlModificacion.Visible = false;
        toggleDivDSG(false);
        pnlModificacionDeudoresSinGestion.Visible = false;

        IHojaService hojaService = ServiceClient<IHojaService>.GetService("HojaService");
        IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");

        List<HojaDataContracts> hojasDC = null; //hojaService.GetAllHojas();

        if (this.txtFechaDesdeActivas.Text != "" && this.txtFechaHastaActivas.Text != "")
        {

            hojasDC = hojaService.GetAllHojasEntreFechas(DateTime.Parse(this.txtFechaDesdeActivas.Text), DateTime.Parse(this.txtFechaHastaActivas.Text));

        }
        else if (this.txtHojaDeRuta.Text != "")
        {
            HojaDataContracts hojaDC = hojaService.Load(decimal.Parse(this.txtHojaDeRuta.Text));
            if (hojaDC != null)
            {
                hojasDC = new List<HojaDataContracts>();
                hojasDC.Add(hojaDC);
            }
        }

        gvHojasActivas.DataSource = hojasDC;
        gvHojasActivas.DataBind();
        Session["hojasDC"] = hojasDC;


    }
    private void toggleDivDSG(Boolean visible)
    {

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "accionToogleDSG", "javascript:toogleDSG(" + visible.ToString().ToLower() + ");", true);
    }
    protected void gvHojasActivas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /*if (e.Row.RowType == DataControlRowType.DataRow)
        {
            IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
            List<FacturaDataContracts> facturasACobrar = null;
            facturasACobrar = facturaService.GetAllFacturasPorIdClienteyIdDeudorACobrar(Int32.Parse(e.Row.Cells[1].Text), Int32.Parse(e.Row.Cells[3].Text));
            GridView gvFacturas = (GridView)e.Row.FindControl("gvFacturas");
            gvFacturas.DataSource = facturasACobrar;
            gvFacturas.DataBind();

        }*/
        // e.Row.Cells[4].Visible = false;
    }
    protected void gvHojasActivas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.pnlAlta.Visible = false;
        this.gvDeudores.Visible = false;
        List<HojaDataContracts> hojasDC = (List<HojaDataContracts>)Session["hojasDC"];
        gvModificacion.SelectedIndex = e.NewEditIndex;
        //this.cmbCobrador.SelectedIndex = 0;
        cargarHojasActivas(Convert.ToInt32(hojasDC[e.NewEditIndex].IdHoja));
        Session["nroHojaParaExportar"] = hojasDC[e.NewEditIndex].IdHoja;

    }

    private void cargarHojasActivas(int nroHoja)
    {
        IHojaService hojaService = ServiceClient<IHojaService>.GetService("HojaService");
        IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");
        IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
        IClienteService clienteService = ServiceClient<IClienteService>.GetService("ClienteService");
        IDomicilioDeudorService domicilioDeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
        ILocalidadService localidadService = ServiceClient<ILocalidadService>.GetService("LocalidadService");
        IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
        IDeudorService deudorService = ServiceClient<IDeudorService>.GetService("DeudorService");
        IAccionService accionService = ServiceClient<IAccionService>.GetService("AccionService");
        ICobradorService cobradorServices = ServiceClient<ICobradorService>.GetService("CobradorService");

        //int idCobrador = int.Parse(this.cmbCobradorActivas.SelectedValue);

        List<HojaDataContracts> hojasDC = (List<HojaDataContracts>)Session["hojasDC"];
        HojaDataContracts hoja = hojaService.Load(nroHoja);
        List<ItemHojaDataContracts> itemsHoja = itemHojaService.GetItemsHojaByIdHoja(nroHoja);

        // Cargo los deudores
        List<DeudorDataContracts> lstDeudores = new List<DeudorDataContracts>();
        List<FacturaDataContracts> facturasACobrar = new List<FacturaDataContracts>();
        List<string> lstDeu = new List<string>();
        foreach (ItemHojaDataContracts itemHoja in itemsHoja)
        {

            if (lstDeu.IndexOf(itemHoja.IdDeudor.ToString()) == -1)
            {
                lstDeu.Add(itemHoja.IdDeudor.ToString());
            }
        }

        foreach (string deu in lstDeu)
        {

            lstDeudores.Add(deudorService.Load(Int32.Parse(deu)));
        }


        // muestro la tabla

        List<DeudorHojaDeRutaDataContracts> lstDeudoresHojaDeRuta = new List<Common.DataContracts.DeudorHojaDeRutaDataContracts>();


        //this.tblHojaDeRuta.Rows.Add(hr);
        foreach (DeudorDataContracts deudorDC in lstDeudores)
        {
            // Cargo cliente
            ClienteDataContracts clienteDC = clienteService.GetClientePorDeudor(deudorDC.IdDeudor);
            int idcli = Convert.ToInt32(clienteDC.IdCliente);
            int iddeu = Convert.ToInt32(deudorDC.IdDeudor);


            //DomicilioDeudorDataContracts domi = domicilioDeudorService.GetDomicilioDeudor(iddeu); //TODO: buscar segun iddeudor, idhoja 30/07/2011
            DomicilioDeudorDataContracts domi = domicilioDeudorService.GetDomicilioDeudorByIdDeudorIdHoja(iddeu, nroHoja); //TODO: buscar segun iddeudor, idhoja 30/07/2011

            DeudorHojaDeRutaDataContracts deudorHojaDeRuta = new DeudorHojaDeRutaDataContracts();

            deudorHojaDeRuta.IdDeudor = deudorDC.IdDeudor.ToString();
            deudorHojaDeRuta.AlfaNumDelCliente = deudorDC.AlfaNumDelCliente;
            deudorHojaDeRuta.IdCliente = clienteDC.IdCliente.ToString();
            deudorHojaDeRuta.Cliente = clienteDC.NOMBRE;
            deudorHojaDeRuta.Deudor = deudorDC.Nombre;
            deudorHojaDeRuta.Domicilio = domi.CalleNombre + " " + domi.CalleAltura;
            deudorHojaDeRuta.Localidad = localidadService.Load(domi.IdLocalidad).Nombre;
            deudorHojaDeRuta.Provincia = provinciaService.Load(domi.IdProvincia).Nombre;
            deudorHojaDeRuta.Cp = domi.Cp;
            //deudorHojaDeRuta.Horario = "Lun y Mie 10 a 12 hs";
            deudorHojaDeRuta.Horario = getDiasCobroDeudor(deudorDC.IdDeudor, hoja.FechaCreacion);

            foreach (ItemHojaDataContracts ih in itemsHoja)
            {
                if (ih.IdDeudor == Int32.Parse(deudorHojaDeRuta.IdDeudor))
                {
                    deudorHojaDeRuta.IdEstadoHoja = ih.IdEstadoHoja;
                    deudorHojaDeRuta.Ingresada = ih.Ingresada;
                    deudorHojaDeRuta.Observaciones = ih.Observaciones;
                    List<AccionDataContracts> accionesFactura = accionService.GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(ih.IdFactura, ih.IdCliente, ih.FechaVenc, 3);
                    string observHistoria = "";

                    foreach (AccionDataContracts accion in accionesFactura)
                    {
                        if (accion.Observacion != null)
                        {

                            observHistoria += accion.Observacion.Substring(accion.Observacion.IndexOf("/") + 1) + "\n";

                        }
                        //observHistoria += accion.Observacion + "\n";
                    }

                    deudorHojaDeRuta.ObservacionesHistoria = observHistoria;
                    deudorHojaDeRuta.TieneObservacionesHistoria = (observHistoria.Length > 0);
                    deudorHojaDeRuta.IdCobrador = ih.IdCobrador;
                    deudorHojaDeRuta.Cobrador = cobradorServices.Load(ih.IdCobrador).NombreApellido;
                    break;
                }
            }




            lstDeudoresHojaDeRuta.Add(deudorHojaDeRuta);
            //this.tblHojaDeRuta.Rows.Add(tr);

        }

        lstDeudoresHojaDeRuta.Sort(new DeudorHojaDeRutaComparator());

        Session["DeudoresHojaDeRuta"] = lstDeudoresHojaDeRuta;
        Session["nroHoja"] = nroHoja;
        gvModificacion.DataSource = lstDeudoresHojaDeRuta;
        gvModificacion.DataBind();
        Session["gvModificacion"] = gvModificacion;
        pnlModificacion.Visible = true;
        toggleDivDSG(true);
        pnlModificacionDeudoresSinGestion.Visible = true;

        fillItemHojaDSG();
    }
    private DataTable GetTableLocalidadCp()
    {
        List<DeudorDataContracts> deudores = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        deudores = deudorServices.GetAllLocalidadCp();
        return ConvertDataTable<DeudorDataContracts>.Convert(deudores);
    }
    public DataTable GetTableCobrador()
    {
        List<CobradorDataContracts> cobradores = new List<CobradorDataContracts>();
        ICobradorService cobradorServices = ServiceClient<ICobradorService>.GetService("CobradorService");
        cobradores = cobradorServices.GetAllCobrador();
        CobradorDataContracts cob = new CobradorDataContracts();
        cob.Id = 0;
        cob.Nombre = "--- Todos ---";
        cob.Apellido = "--- Todos ---";
        cobradores.Insert(0, cob);
        return ConvertDataTable<CobradorDataContracts>.Convert(cobradores);
    }

    public DataSet getDataSetCobrador()
    {

        return GetTableCobrador().DataSet;
    }
    private DataTable GetTableZona()
    {
        List<ZonaDataContracts> zonas = new List<ZonaDataContracts>();
        IZonaService zonaServices = ServiceClient<IZonaService>.GetService("ZonaService");
        zonas = zonaServices.GetAllZona();
        return ConvertDataTable<ZonaDataContracts>.Convert(zonas);
    }

  /*  private String getDiasCobroDeudor(int idDeudor, DateTime fechaCreacion)
    {
        List<DeudorDiaCobroDataContracts> deudordiacobro = new List<DeudorDiaCobroDataContracts>();
        IDeudorDiaCobroService deudordiacobroServices = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
        IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");

        IDeudorDiaReclamoAlternativoService ddalterService = ServiceClient<IDeudorDiaReclamoAlternativoService>.GetService("DeudorDiaReclamoAlternativoService");

        List<DeudorDiaReclamoAlternativoDataContracts> listHorariosCobroAlternativos = ddalterService.GetAllDeudorDiaReclamoAlternativo(idDeudor);
        if (listHorariosCobroAlternativos != null && listHorariosCobroAlternativos.Count > 0)
        {
            string cuandoCobrar = "";
            foreach (DeudorDiaReclamoAlternativoDataContracts ddc in listHorariosCobroAlternativos)
            {
                DiasDataContracts dia = new DiasDataContracts();
                dia = diasService.GetDias(ddc.IdDia);
                short idDia = -1;
                if (ddc.IdDia == 7)
                {
                    idDia = 0;
                }
                else
                {
                    idDia = (short)ddc.IdDia;
                }
                if (fechaCreacion.DayOfWeek.CompareTo(((DayOfWeek)idDia)) == 0)
                {
                    //cuandoCobrar += dia.Descripcion.Substring(0, 3) + " " + ddc.HorarioDesde + " a " + ddc.HorarioHasta + "<br/>";
                    cuandoCobrar += ddc.HorarioDesde + " a " + ddc.HorarioHasta + "<br/>";
                }


            }

            return cuandoCobrar;
        }
        else
        {


            deudordiacobro = deudordiacobroServices.GetAllDeudorDiaCobrosPorIdDeudor(idDeudor);

            string cuandoCobrar = "";
            foreach (DeudorDiaCobroDataContracts ddc in deudordiacobro)
            {
                DiasDataContracts dia = new DiasDataContracts();
                dia = diasService.GetDias(ddc.IdDia);
                short idDia = -1;
                if (ddc.IdDia == 7)
                {
                    idDia = 0;
                }
                else
                {
                    idDia = (short)ddc.IdDia;
                }
                if (fechaCreacion.DayOfWeek.CompareTo(((DayOfWeek)idDia)) == 0)
                {
                    //cuandoCobrar += dia.Descripcion.Substring(0, 3) + " " + ddc.HorarioDesde + " a " + ddc.HorarioHasta + "<br/>";
                    cuandoCobrar += ddc.HorarioDesde + " a " + ddc.HorarioHasta + "<br/>";
                }


            }

            return cuandoCobrar;
        }
    }
    */

    private String getDiasCobroDeudor(int idDeudor, DateTime fechaCreacion)
    {
        List<DeudorDiaCobroDataContracts> deudordiacobro = new List<DeudorDiaCobroDataContracts>();
        IDeudorDiaCobroService deudordiacobroServices = ServiceClient<IDeudorDiaCobroService>.GetService("DeudorDiaCobroService");
        IDiasService diasService = ServiceClient<IDiasService>.GetService("DiasService");

        IDeudorDiaReclamoAlternativoService ddalterService = ServiceClient<IDeudorDiaReclamoAlternativoService>.GetService("DeudorDiaReclamoAlternativoService");

        List<DeudorDiaReclamoAlternativoDataContracts> listHorariosCobroAlternativos = ddalterService.GetAllDeudorDiaReclamoAlternativo(idDeudor);
        string cuandoCobrar = "";

        if (listHorariosCobroAlternativos != null && listHorariosCobroAlternativos.Count > 0)
        {
            foreach (DeudorDiaReclamoAlternativoDataContracts ddc in listHorariosCobroAlternativos)
            {
                DiasDataContracts dia = new DiasDataContracts();
                dia = diasService.GetDias(ddc.IdDia);
                short idDia = -1;
                if (ddc.IdDia == 7)
                {
                    idDia = 0;
                }
                else
                {
                    idDia = (short)ddc.IdDia;
                }
                if (fechaCreacion.DayOfWeek.CompareTo(((DayOfWeek)idDia)) == 0)
                {
                    //cuandoCobrar += dia.Descripcion.Substring(0, 3) + " " + ddc.HorarioDesde + " a " + ddc.HorarioHasta + "<br/>";
                    cuandoCobrar += "[" + ddc.HorarioDesde + " a " + ddc.HorarioHasta + "]<br/>";
                }


            }

            //return cuandoCobrar;
        }

        deudordiacobro = deudordiacobroServices.GetAllDeudorDiaCobrosPorIdDeudor(idDeudor);

        //string cuandoCobrar = "";
        foreach (DeudorDiaCobroDataContracts ddc in deudordiacobro)
        {
            DiasDataContracts dia = new DiasDataContracts();
            dia = diasService.GetDias(ddc.IdDia);
            short idDia = -1;
            if (ddc.IdDia == 7)
            {
                idDia = 0;
            }
            else
            {
                idDia = (short)ddc.IdDia;
            }
            if (fechaCreacion.DayOfWeek.CompareTo(((DayOfWeek)idDia)) == 0)
            {
                //cuandoCobrar += dia.Descripcion.Substring(0, 3) + " " + ddc.HorarioDesde + " a " + ddc.HorarioHasta + "<br/>";
                cuandoCobrar += ddc.HorarioDesde + " a " + ddc.HorarioHasta + "<br/>";
            }
        }

        return cuandoCobrar;

    }

    private class DeudorHojaDeRutaComparator : IComparer<DeudorHojaDeRutaDataContracts>
    {
        public int Compare(DeudorHojaDeRutaDataContracts aX, DeudorHojaDeRutaDataContracts aY)
        {
            //return (aY.IdCobrador + aY.Horario + aY.Localidad + aY.Provincia).CompareTo(aX.IdCobrador + aX.Horario + aX.Localidad + aX.Provincia);
            return (aX.IdCobrador + aX.Horario + aX.Localidad + aX.Provincia).CompareTo(aY.IdCobrador + aY.Horario + aY.Localidad + aY.Provincia);

        }
    }
    private void fillItemHojaDSG()
    {
        List<DeudorHojaDeRutaDataContracts> lstDeudoresSinGestionHojaDeRuta = new List<Common.DataContracts.DeudorHojaDeRutaDataContracts>();


        IItemHojaDSGService itemHojaDSGServices = ServiceClient<IItemHojaDSGService>.GetService("ItemHojaDSGService");
        IClienteService clienteService = ServiceClient<IClienteService>.GetService("ClienteService");

        int nroHoja = Int32.Parse(Session["nroHoja"].ToString());

        List<ItemHojaDSGDataContracts> deudoresDTO = itemHojaDSGServices.GetAllItemHojaDSGsByIdHoja(nroHoja);
        DeudorHojaDeRutaDataContracts dh = null;
        foreach (ItemHojaDSGDataContracts deudorDTO in deudoresDTO)
        {
            dh = new DeudorHojaDeRutaDataContracts();

            dh.IdCliente = deudorDTO.IdCliente.ToString();
            dh.Cliente = clienteService.GetCliente(deudorDTO.IdCliente).NOMBRE;
            dh.AlfaNumDelCliente = deudorDTO.IdDeudor;
            dh.IdDeudor = deudorDTO.IdDeudor;
            dh.Deudor = deudorDTO.DeudorRazonSocial;
            dh.Localidad = deudorDTO.DeudorLocalidad;
            dh.Observaciones = deudorDTO.Observaciones;
            dh.Domicilio = deudorDTO.DeudorDomicilio;
            dh.Horario = deudorDTO.DeudorDia + " " + deudorDTO.DeudorHorario;
            dh.NroItem = deudorDTO.NroItem.ToString();
            dh.IdEstadoHoja = deudorDTO.IdEstadoHoja;
            dh.Ingresada = deudorDTO.Ingresada;
            dh.IdCobrador = deudorDTO.IdCobrador;

            lstDeudoresSinGestionHojaDeRuta.Add(dh);
        }

        lstDeudoresSinGestionHojaDeRuta.Sort(new DeudorHojaDeRutaComparator());

        Session["DeudoresSinGestionHojaDeRuta"] = lstDeudoresSinGestionHojaDeRuta;
        List<DeudorHojaDeRutaDataContracts> lstDeudoresHojaDeRuta = (List<DeudorHojaDeRutaDataContracts>)gvModificacion.DataSource;
        if (lstDeudoresHojaDeRuta != null)
        {
            lstDeudoresHojaDeRuta.AddRange(lstDeudoresSinGestionHojaDeRuta);
            //gvModificacionDeudoresSinGestion.DataSource = lstDeudoresHojaDeRuta;
            gvModificacion.DataSource = lstDeudoresHojaDeRuta;

        }
        //else {
        //  gvModificacionDeudoresSinGestion.DataSource = lstDeudoresSinGestionHojaDeRuta;

        // }
        //gvModificacionDeudoresSinGestion.DataBind();
        gvModificacion.DataBind();

        //Session["gvModificacionDeudoresSinGestion"] = gvModificacionDeudoresSinGestion;
        Session["gvModificacion"] = gvModificacion;

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        this.btnCrearHoja.Visible = false;
        this.gvDeudores.Visible = true;
        IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
        DateTime fechaIngresada = DateTime.Now;
        try
        {
            fechaIngresada = DateTime.Parse(txtFechaDesde.Text);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Hide", "javascript:alert('Debe ingresar la Fecha.');", true);
            return;
        }

        List<DeudorHojaDeRutaDataContracts> dhdrDtoList = facturaService.getHojaDeRuta(fechaIngresada);

        foreach (DeudorHojaDeRutaDataContracts deudorHojaDeRuta in dhdrDtoList)
        {
            deudorHojaDeRuta.Horario = getDiasCobroDeudor(Int32.Parse(deudorHojaDeRuta.IdDeudor), fechaIngresada);
        }

        if (dhdrDtoList.Count > 0)
        {
            this.btnCrearHoja.Visible = true;
        }

        dhdrDtoList.Sort(new DeudorHojaDeRutaComparator());

        Session["DeudoresHojaDeRuta"] = dhdrDtoList;
        gvDeudores.DataSource = dhdrDtoList;
        try
        {
            gvDeudores.DataBind();
        }
        catch (Exception ee)
        {
            Console.Write(ee);
        }


        //TODO: hacer consulta sql 
        /*-- Resultados
        Cobrador ( lo saco del combo )
           Zona Almagro  ( descripcion, cp )   usar -> ZonaService.GetZonasByCobrador(int id_cobrador)
         
             -- Para buscar los deudores ->  DeudorService.GetAllDeudorsPorCriterioZona(int idZona)
             -- Para buscar el domicilio del deudor -> DomicilioDeudorService.DomicilioDeudorDataContracts Load(int idDeudor);
             -- Para buscar el cliente -> ClienteService.ClienteDataContracts GetClientePorDeudor(decimal idDeudor);
              Cliente (Nombre) , Deudor (nombre y domicilio completo + horario de cobro)
         * 
         -- Para buscar las facturas -> FacturaService. List<FacturaDataContracts> GetAllFacturasPorIdDeudor(int idDeudor);  + filtrar por idEstadoFactura = 3 (A_COBRAR)
	             Factura 1  (nro, fec venc, importe, saldo, combo estado hoja, observaciones, chk ingresada)
                 Factura 2 */

    }
    protected void gvDeudores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
            List<FacturaDataContracts> facturasACobrar = null;
            //facturasACobrar = facturaService.GetAllFacturasPorIdClienteyIdDeudorACobrar(Int32.Parse(e.Row.Cells[1].Text), Int32.Parse(e.Row.Cells[3].Text));
            //Id. Deudor
            facturasACobrar = facturaService.GetAllFacturasPorIdClienteyIdDeudorACobrar(Int32.Parse(e.Row.Cells[UIUtils.GetPosCol(gvDeudores, "IdCli")].Text), Int32.Parse(e.Row.Cells[UIUtils.GetPosCol(gvDeudores, "Id. Deudor")].Text), DateTime.Parse(txtFechaDesde.Text));

            GridView gvFacturas = (GridView)e.Row.FindControl("gvFacturas");
            gvFacturas.DataSource = facturasACobrar;
            gvFacturas.DataBind();

        }
        // e.Row.Cells[4].Visible = false;
    }
    protected void btnCrear_Click(object sender, EventArgs e)
    {
        try
        {
            List<DeudorHojaDeRutaDataContracts> lstDeudoresHojaDeRuta = (List<DeudorHojaDeRutaDataContracts>)Session["DeudoresHojaDeRuta"];
            IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
            IHojaService hojaService = ServiceClient<IHojaService>.GetService("HojaService");
            IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");

            HojaDataContracts hojaDC = null;
            ItemHojaDataContracts itemHojaDC = null;
            List<ItemHojaDataContracts> itemsHoja = null;
            hojaDC = new HojaDataContracts();
            hojaDC.FechaCreacion = DateTime.Parse(txtFechaDesde.Text);

            if (hojaDC.FechaCreacion.Date.CompareTo(DateTime.Now.Date) < 0)
            {
                throw new Exception("No se pueden crear hojas de ruta con fechas pasadas.");
            }

            //hojaDC.IdCobrador = int.Parse(this.cmbCobrador.SelectedValue);
            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            string usuario = (principal.Identity.Name);

            hojaDC.Usuario = usuario;
            itemsHoja = new List<ItemHojaDataContracts>();
            int nroItem = 0;
            foreach (DeudorHojaDeRutaDataContracts deudor in lstDeudoresHojaDeRuta)
            {

                List<FacturaDataContracts> facturasACobrar = null;
                facturasACobrar = facturaService.GetAllFacturasPorIdClienteyIdDeudorACobrar(Int32.Parse(deudor.IdCliente), Int32.Parse(deudor.IdDeudor), hojaDC.FechaCreacion);

                foreach (FacturaDataContracts facturaDC in facturasACobrar)
                {

                    itemHojaDC = new ItemHojaDataContracts();
                    itemHojaDC.IdCliente = facturaDC.IdCliente;
                    itemHojaDC.IdDeudor = facturaDC.IdDeudor;
                    itemHojaDC.IdFactura = facturaDC.IdFactura;
                    itemHojaDC.FechaVenc = facturaDC.FechaVenc;
                    itemHojaDC.NroItem = nroItem++;
                    itemHojaDC.IdCobrador = deudor.IdCobrador;
                    itemHojaDC.Cobrador = deudor.Cobrador;

                    itemsHoja.Add(itemHojaDC);
                }
            }

            hojaDC.ItemsHoja = itemsHoja;

            hojaService.Insert(hojaDC);
            gvDeudores.DataSource = "";
            gvDeudores.DataBind();
            //gvDeudores.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HojaDeRuta", "javascript:alert('Se creó con éxito la hoja de ruta');", true);

            this.pnlAlta.Visible = false;
            this.pnlModificacion.Visible = false;
            toggleDivDSG(false);
            this.pnlModificacionDeudoresSinGestion.Visible = false;
            this.btnBuscarActivas_Click(sender, e);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error HojaDeRuta", "javascript:alert('" + ex.Message + "');", true);
        }

    }


    protected void cmbCobrador_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<DeudorHojaDeRutaDataContracts> lstDeudoresHojaDeRuta = (List<DeudorHojaDeRutaDataContracts>)Session["DeudoresHojaDeRuta"];
        int idCob = int.Parse(cmbCobrador.SelectedValue);
        if (idCob > 0)
        {
            IQueryable<DeudorHojaDeRutaDataContracts> queryable = lstDeudoresHojaDeRuta.AsQueryable<DeudorHojaDeRutaDataContracts>().Where(deudor => deudor.IdCobrador == idCob);

            gvModificacion.DataSource = queryable.ToList<DeudorHojaDeRutaDataContracts>();
        }
        else
        {
            gvModificacion.DataSource = lstDeudoresHojaDeRuta;
        }
        // Filtrar la grilla de gvModificacion.


        gvModificacion.DataBind();
        pnlModificacion.Visible = true;
        toggleDivDSG(true);
        pnlModificacionDeudoresSinGestion.Visible = true;
    }
    protected void gvModificacion_OnChanged(object src, EventArgs e)
    {

        TableRow tr = ((System.Web.UI.WebControls.TableRow)(((WebControl)src).NamingContainer));
        tr.Font.Italic = true;
        tr.BackColor = System.Drawing.Color.LightBlue;

    }


    protected void gvModificacionDeudoresSinGestion_OnChanged(object src, EventArgs e)
    {

        TableRow tr = ((System.Web.UI.WebControls.TableRow)(((WebControl)src).NamingContainer));
        tr.Font.Italic = true;
        tr.BackColor = System.Drawing.Color.LightBlue;
    }


    protected void gvFacturasModificacion_OnChanged(object src, EventArgs e)
    {


        TableRow tr = ((System.Web.UI.WebControls.TableRow)(((WebControl)src).NamingContainer));
        tr.Font.Italic = true;
        tr.BackColor = System.Drawing.Color.LightBlue;
        GridView gvFacturasModificacion = (GridView)tr.NamingContainer;
        int idDeudor = Int32.Parse(tr.Cells[UIUtils.GetPosCol(gvFacturasModificacion, "IdDeudor")].Text);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup12", "javascript:CambiarVistas('div" + idDeudor.ToString() + "','one');", true);

    }

    protected void verObservacionesHistoria(Object sender, EventArgs e)
    {
        IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");
        IAccionService accionService = ServiceClient<IAccionService>.GetService("AccionService");
        List<string> lista = new List<string>();

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        int nroHoja = Int32.Parse(Session["nroHoja"].ToString());
        List<ItemHojaDataContracts> itemsHoja = itemHojaService.GetItemsHojaByIdHoja(nroHoja);
        TableRow tr = ((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer));
        GridView gvModificacion = (GridView)tr.NamingContainer;
        int idDeudor = Int32.Parse(tr.Cells[UIUtils.GetPosCol(gvModificacion, "Id. Deudor")].Text);
        int idCliente = Int32.Parse(tr.Cells[UIUtils.GetPosCol(gvModificacion, "IdCli")].Text);

        foreach (ItemHojaDataContracts itemHojaDC in itemsHoja)
        {
            if (itemHojaDC.IdDeudor == idDeudor && itemHojaDC.IdCliente == idCliente)
            {
                List<AccionDataContracts> accionesFactura = accionService.GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(itemHojaDC.IdFactura, idCliente, itemHojaDC.FechaVenc, 3);
                string observHistoria = "";

                foreach (AccionDataContracts accion in accionesFactura)
                {
                    if (accion.Observacion != null)
                    {

                        //observHistoria += accion.Observacion.Substring(accion.Observacion.IndexOf("/") + 1) + "\n";

                        //lista.Add(accion.FechaAccion.ToString("dd/MM/yyyy") + ": " + accion.Observacion.Substring(accion.Observacion.IndexOf("/") + 1));

                        lista.Add(accion.Observacion.Substring(accion.Observacion.IndexOf("/") + 1));
                    }
                    //observHistoria += accion.Observacion + "\n";
                }
            }
        }

        //mgr.Add("historia", lista);
        //mgr.Add("lblClienteSeleccionado", idCliente);
        //mgr.Add("lblDeudorSeleccionado", idDeudor);
        Session["historia"] = lista;
        Session["lblClienteSeleccionado"] = idCliente;
        Session["lblDeudorSeleccionado"] = idDeudor;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentana2('http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/ViewPopUpHistoriaFactura.aspx','_blank', 480, 180);", true);
    }
    protected void btnActualizarDeudorHoja_Click(object sender, EventArgs e)
    {
        try
        {
            btnActualizarDeudorSinGestionHoja_Click(sender, e);
            return;
        }
        catch (Exception ex)
        {
        }


        IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");
        GridView gvModificacion = (GridView)Session["gvModificacion"];

        ItemHojaDataContracts itemDC = new ItemHojaDataContracts();
        DropDownList ddl = (DropDownList)((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer)).Cells[UIUtils.GetPosCol(gvModificacion, "Estado")].FindControl("ddlEstadosHoja");
        DropDownList ddlCobrador = (DropDownList)((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer)).Cells[UIUtils.GetPosCol(gvModificacion, "Estado")].FindControl("ddlCobrador");
        DropDownList ddlIngresada = (DropDownList)((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer)).Cells[UIUtils.GetPosCol(gvModificacion, "Estado")].FindControl("ddlIngresada");
        TextBox txtObservaciones = (TextBox)((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer)).Cells[UIUtils.GetPosCol(gvModificacion, "Observaciones")].FindControl("txtObservaciones")
            ;
        TableRow tr = ((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer));
        tr.Font.Italic = false;
        tr.BackColor = System.Drawing.Color.Empty;

        itemDC.IdHoja = Convert.ToInt32(Session["nroHoja"]);
        itemDC.IdCliente = decimal.Parse(tr.Cells[UIUtils.GetPosCol(gvModificacion, "IdCli")].Text);
        itemDC.IdDeudor = Int32.Parse(tr.Cells[UIUtils.GetPosCol(gvModificacion, "Id. Deudor")].Text);

        itemDC.IdEstadoHoja = short.Parse(ddl.SelectedValue);
        itemDC.Observaciones = txtObservaciones.Text;
        itemDC.Ingresada = bool.Parse(ddlIngresada.SelectedValue);
        itemDC.IdCobrador = short.Parse(ddlCobrador.SelectedValue);
        itemDC.Cobrador = ddlCobrador.SelectedItem.Text;

        List<ItemHojaDataContracts> items = itemHojaService.GetItemsHojaByIdHoja(Convert.ToInt32(itemDC.IdHoja));

        foreach (ItemHojaDataContracts ih in items)
        {
            if (ih.IdCliente == itemDC.IdCliente && ih.IdDeudor == itemDC.IdDeudor)
            {

                ih.IdEstadoHoja = itemDC.IdEstadoHoja;
                ih.Observaciones = itemDC.Observaciones;
                ih.Ingresada = itemDC.Ingresada;
                ih.IdCobrador = itemDC.IdCobrador;
                ih.Cobrador = itemDC.Cobrador;
                itemHojaService.Update(ih);
            }
        }

    }


    protected void btnActualizarDeudorSinGestionHoja_Click(object sender, EventArgs e)
    {
        IItemHojaDSGService itemHojaDSGServices = ServiceClient<IItemHojaDSGService>.GetService("ItemHojaDSGService");
        //  GridView gvModificacionDeudoresSinGestion = (GridView)Session["gvModificacionDeudoresSinGestion"];
        GridView gvModificacionDeudoresSinGestion = (GridView)Session["gvModificacion"];


        ItemHojaDSGDataContracts itemDC = new ItemHojaDSGDataContracts();
        DropDownList ddl = (DropDownList)((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer)).Cells[UIUtils.GetPosCol(gvModificacionDeudoresSinGestion, "Estado")].FindControl("ddlEstadosHoja");
        DropDownList ddlCobrador = (DropDownList)((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer)).Cells[UIUtils.GetPosCol(gvModificacionDeudoresSinGestion, "Estado")].FindControl("ddlCobrador");
        DropDownList ddlIngresada = (DropDownList)((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer)).Cells[UIUtils.GetPosCol(gvModificacionDeudoresSinGestion, "Estado")].FindControl("ddlIngresada");
        TextBox txtObservaciones = (TextBox)((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer)).Cells[UIUtils.GetPosCol(gvModificacionDeudoresSinGestion, "Observaciones")].FindControl("txtObservaciones")
            ;

        TableRow tr = ((System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer));
        tr.Font.Italic = false;
        tr.BackColor = System.Drawing.Color.Empty;

        // int nroItem = Int32.Parse(tr.Cells[UIUtils.GetPosCol(gvModificacionDeudoresSinGestion, "NroItem")].Text);
        int nroItem = Int32.Parse(tr.Cells[UIUtils.GetPosCol(gvModificacion, "NroItem")].Text);
        itemDC = itemHojaDSGServices.Load(Convert.ToInt32(Session["nroHoja"]), nroItem);


        itemDC.IdEstadoHoja = short.Parse(ddl.SelectedValue);
        itemDC.Observaciones = txtObservaciones.Text;
        itemDC.Ingresada = bool.Parse(ddlIngresada.SelectedValue);
        itemDC.IdCobrador = short.Parse(ddlCobrador.SelectedValue);


        itemHojaDSGServices.Update(itemDC);
    }
    protected void btnActuualizarItemHoja_Click(object sender, EventArgs e)
    {


        IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");
        GridView gvFacturasModificacion = (GridView)Session["gvFacturasModificacion"];

        ItemHojaDataContracts itemDC = null;
        TableRow tr = (System.Web.UI.WebControls.TableRow)(((WebControl)sender).NamingContainer);


        TextBox txtImporteModificado = (TextBox)tr.Cells[UIUtils.GetPosCol(gvFacturasModificacion, "Importe Modificado")].FindControl("txtImporteModificado");
        CheckBox chkSePago = (CheckBox)tr.Cells[UIUtils.GetPosCol(gvFacturasModificacion, "Se Pagó")].FindControl("chkSePago");
        int nroItem = Int32.Parse(tr.Cells[UIUtils.GetPosCol(gvFacturasModificacion, "NroItem")].Text);
        int idHoja = Int32.Parse(tr.Cells[UIUtils.GetPosCol(gvFacturasModificacion, "IdHoja")].Text);

        itemDC = itemHojaService.Load(idHoja, nroItem);

        double importeModificado = 0;
        try
        {
            importeModificado = double.Parse(txtImporteModificado.Text);
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup12", "javascript:CambiarVistas('div" + itemDC.IdDeudor.ToString() + "','one');", true);
            //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popupError", "javascript:CambiarVistas('div" + itemDC.IdDeudor.ToString() + "','one');alert('Debe ingresar un importe válido mayor que 0.00.');", true);

            return;
        }



        itemDC.ImporteModificado = importeModificado;
        itemDC.SePago = chkSePago.Checked;
        itemHojaService.Update(itemDC);
        tr.Font.Italic = false;
        tr.BackColor = System.Drawing.Color.Empty;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup12", "javascript:CambiarVistas('div" + itemDC.IdDeudor.ToString() + "','one');", true);

    }
    protected void gvFacturasModificacion_RowEditing(object sender, GridViewEditEventArgs e)
    {
        IEstadoHojaService estadoHojaService = ServiceClient<IEstadoHojaService>.GetService("EstadoHojaService");

        int idx = e.NewEditIndex;
        GridView gvFacturasModificacion = (GridView)Session["gvFacturasModificacion"];

    }
    protected void gvModificacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");
        IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            List<HojaDataContracts> hojasDC = (List<HojaDataContracts>)Session["hojasDC"];
            int nroHoja = Int32.Parse(Session["nroHoja"].ToString());
            //int nroHoja = Convert.ToInt32(hojasDC[gvHojasActivas.SelectedIndex].IdHoja);
            List<ItemHojaDataContracts> itemsHoja = itemHojaService.GetItemsHojaByIdHoja(nroHoja);
            List<ItemHojaDataContracts> itemsHojaGv = new List<ItemHojaDataContracts>();

            List<FacturaDataContracts> facturasACobrar = new List<FacturaDataContracts>();
            //int idDeudor = Int32.Parse(e.Row.Cells[3].Text);
            //Id. Deudor
            int idDeudor = Int32.Parse(e.Row.Cells[UIUtils.GetPosCol(gvModificacion, "Id. Deudor")].Text);
            foreach (ItemHojaDataContracts item in itemsHoja)
            {
                if (item.IdDeudor == idDeudor)
                {
                    FacturaDataContracts facturaDC = facturaService.Load(item.IdFactura);
                    item.FechaCobro = facturaDC.FechaCobro;
                    item.Importe = facturaDC.Importe;
                    item.Saldo = facturaDC.Saldo;
                    item.ComprobanteFormateado = facturaDC.ComprobanteFormateado;
                    itemsHojaGv.Add(item);
                    //facturasACobrar.Add(facturaService.Load(item.IdFactura));
                }
            }
            //facturasACobrar = facturaService.GetAllFacturasPorIdClienteyIdDeudorACobrar(Int32.Parse(e.Row.Cells[1].Text), Int32.Parse(e.Row.Cells[3].Text));
            GridView gvFacturasModificacion = (GridView)e.Row.FindControl("gvFacturasModificacion");
            Session["gvFacturasModificacion"] = gvFacturasModificacion;
            gvFacturasModificacion.DataSource = itemsHojaGv;
            gvFacturasModificacion.DataBind();

        }

    }
    protected void gvFacturasModificacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int idx = e.Row.RowIndex;
            GridView gvFacturasModificacion = (GridView)Session["gvFacturasModificacion"];

            //DropDownList ddl = (DropDownList)e.Row.Cells[6].FindControl("ddlEstadosHoja");
            DropDownList ddl = (DropDownList)e.Row.Cells[UIUtils.GetPosCol(gvFacturasModificacion, "Estado")].FindControl("ddlEstadosHoja");


        }
    }

    protected void btnExportarExcelDSG_Click(object sender, EventArgs e)
    {

        GridViewExportUtil.Export("HojaDeRutaDSG_2.xls", this.gvModificacionDeudoresSinGestion);

    }

    protected void btnImportarDSG_Click(object sender, EventArgs e)
    {
        lblResultadoImportacion.Text = "";
        string resultado = "";
        try
        {

            String idCliente = this.cmbClientes.SelectedValue;
            int nroHoja = Int32.Parse(Session["nroHoja"].ToString());
            FileUpload fileUploaded = this.archivo;
            resultado = "";
            ImportadorInterfaces.importarDeudoresSinGestion(idCliente, nroHoja, archivo.FileName, fileUploaded.FileBytes);


            resultado = "Se ha enviado el archivo con éxito";
            cargarHojasActivas(nroHoja);
        }
        catch (Exception ex)
        {
            resultado = "Ha ocurrido un error durante la importación de deudores sin gestión. " + "\n" + ex.Message;
        }
        finally
        {
            toggleDivDSG(true);
            lblResultadoImportacion.Text = resultado;
        }

    }

    protected void btnExportarExcel_Click(object sender, EventArgs e)
    {

        //Export the GridView to Excel

        //GridView aa = new GridView();
        //aa.DataSource = gvModificacion.DataSource;
        HojaDeRutaExcelDataContracts hrAExportar = new HojaDeRutaExcelDataContracts();

        //////////////////////////////////////////////////////

        IHojaService hojaService = ServiceClient<IHojaService>.GetService("HojaService");
        IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");
        IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
        IClienteService clienteService = ServiceClient<IClienteService>.GetService("ClienteService");
        IDomicilioDeudorService domicilioDeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
        ILocalidadService localidadService = ServiceClient<ILocalidadService>.GetService("LocalidadService");
        IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
        IDeudorService deudorService = ServiceClient<IDeudorService>.GetService("DeudorService");
        IAccionService accionService = ServiceClient<IAccionService>.GetService("AccionService");
        ICobradorService cobradorServices = ServiceClient<ICobradorService>.GetService("CobradorService");

        //int idCobrador = int.Parse(this.cmbCobradorActivas.SelectedValue);

        //List<HojaDataContracts> hojasDC = (List<HojaDataContracts>)Session["hojasDC"];
        int nroHoja = int.Parse(Session["nroHojaParaExportar"].ToString());
        HojaDataContracts hoja = hojaService.Load(nroHoja);
        List<ItemHojaDataContracts> itemsHoja = itemHojaService.GetItemsHojaByIdHoja(nroHoja);


        foreach (var item in itemsHoja)
        {
            FacturaDataContracts facturaDC = facturaService.Load(item.IdFactura);
            item.Importe = facturaDC.Importe;
            item.Saldo = facturaDC.Saldo;
        }
        // Cargo los deudores
        List<DeudorDataContracts> lstDeudores = new List<DeudorDataContracts>();
        List<FacturaDataContracts> facturasACobrar = new List<FacturaDataContracts>();
        List<string> lstDeu = new List<string>();
        foreach (ItemHojaDataContracts itemHoja in itemsHoja)
        {

            if (lstDeu.IndexOf(itemHoja.IdDeudor.ToString()) == -1)
            {
                lstDeu.Add(itemHoja.IdDeudor.ToString());
            }
        }

        foreach (string deu in lstDeu)
        {

            lstDeudores.Add(deudorService.Load(Int32.Parse(deu)));
        }


        // muestro la tabla

        List<DeudorHojaDeRutaDataContracts> lstDeudoresHojaDeRuta = new List<Common.DataContracts.DeudorHojaDeRutaDataContracts>();


        //this.tblHojaDeRuta.Rows.Add(hr);
        foreach (DeudorDataContracts deudorDC in lstDeudores)
        {
            // Cargo cliente
            ClienteDataContracts clienteDC = clienteService.GetClientePorDeudor(deudorDC.IdDeudor);
            int idcli = Convert.ToInt32(clienteDC.IdCliente);
            int iddeu = Convert.ToInt32(deudorDC.IdDeudor);


            //DomicilioDeudorDataContracts domi = domicilioDeudorService.GetDomicilioDeudor(iddeu); //TODO: buscar segun iddeudor, idhoja 30/07/2011
            DomicilioDeudorDataContracts domi = domicilioDeudorService.GetDomicilioDeudorByIdDeudorIdHoja(iddeu, nroHoja); //TODO: buscar segun iddeudor, idhoja 30/07/2011

            DeudorHojaDeRutaDataContracts deudorHojaDeRuta = new DeudorHojaDeRutaDataContracts();

            deudorHojaDeRuta.IdDeudor = deudorDC.IdDeudor.ToString();
            deudorHojaDeRuta.AlfaNumDelCliente = deudorDC.AlfaNumDelCliente;
            deudorHojaDeRuta.IdCliente = clienteDC.IdCliente.ToString();
            deudorHojaDeRuta.Cliente = clienteDC.NOMBRE;
            deudorHojaDeRuta.Deudor = deudorDC.Nombre;
            deudorHojaDeRuta.Domicilio = domi.CalleNombre + " " + domi.CalleAltura;
            deudorHojaDeRuta.Localidad = localidadService.Load(domi.IdLocalidad).Nombre;
            deudorHojaDeRuta.Provincia = provinciaService.Load(domi.IdProvincia).Nombre;
            deudorHojaDeRuta.Cp = domi.Cp;
            //deudorHojaDeRuta.Horario = "Lun y Mie 10 a 12 hs";
            deudorHojaDeRuta.Horario = getDiasCobroDeudor(deudorDC.IdDeudor, hoja.FechaCreacion);

            foreach (ItemHojaDataContracts ih in itemsHoja)
            {
                if (ih.IdDeudor == Int32.Parse(deudorHojaDeRuta.IdDeudor))
                {
                    deudorHojaDeRuta.IdEstadoHoja = ih.IdEstadoHoja;
                    deudorHojaDeRuta.Ingresada = ih.Ingresada;
                    deudorHojaDeRuta.Observaciones = ih.Observaciones;
                    //List<AccionDataContracts> accionesFactura = accionService.GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(ih.IdFactura, ih.IdCliente, ih.FechaVenc, 3);
                    AccionDataContracts accionFactura = accionService.GetLastActionByIdFactura(ih.IdFactura);
                    string observHistoria = "";

                    //foreach (AccionDataContracts accion in accionesFactura)
                    //{

                    if (accionFactura.Observacion != null)
                        {

                            //observHistoria += accion.Observacion.Substring(accion.Observacion.IndexOf("/") + 1) + "\n";
                            //observHistoria += accion.Observacion.Split('/')[0] + "; " + accion.Observacion.Split('/')[1];
                            observHistoria = accionFactura.Observacion.Split('/')[0] + "; " + accionFactura.Observacion.Split('/')[1];

                        }
                        //observHistoria += accion.Observacion + "\n";
                    //}

                    deudorHojaDeRuta.ObservacionesHistoria = observHistoria;
                    deudorHojaDeRuta.TieneObservacionesHistoria = (observHistoria.Length > 0);
                    deudorHojaDeRuta.IdCobrador = ih.IdCobrador;
                    deudorHojaDeRuta.Cobrador = cobradorServices.Load(ih.IdCobrador).NombreApellido;
                    break;
                }
            }




            lstDeudoresHojaDeRuta.Add(deudorHojaDeRuta);

            //this.tblHojaDeRuta.Rows.Add(tr);

        }

        lstDeudoresHojaDeRuta.Sort(new DeudorHojaDeRutaComparator());

        hrAExportar.DeudoresDeLahojaConGestion = lstDeudoresHojaDeRuta;
        hrAExportar.ItemsHoja = itemsHoja;
        hrAExportar.UsuarioCreador = hoja.Usuario;
        hrAExportar.IdHojaDeRuta = int.Parse(hoja.IdHoja.ToString());


        Session["CACHE_HOJADERUTA_A_EXPORTAR"] = null;
        Session["CACHE_HOJADERUTA_A_EXPORTAR"] = hrAExportar;


        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaPequenia('ViewExportToExcelHDR.aspx','_blank');", true);
        this.StartupScriptKey++;

    }
}
