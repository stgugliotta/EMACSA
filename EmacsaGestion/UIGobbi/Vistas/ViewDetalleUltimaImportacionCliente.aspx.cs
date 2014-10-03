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
using Gobbi.CoreServices.Security.Principal;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using System.Collections.Generic;



public partial class Vistas_ViewDetalleUltimaImportacionCliente : GobbiPage
{
    private String idCliente;
    private DateTime fechaProceso;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        this.idCliente = Request.Params.Get("idCliente");
        this.fechaProceso =  DateTime.Parse(Request.Params.Get("fechaProceso"));
        this.idcli.Value = idCliente;

        if (!Page.IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewDetalleUltimaImportacionCliente));
            inicializarTablas();
        }

    }

    private void inicializarTablas() {
        this.idCliente = Request.Params.Get("idCliente");
        this.idcli.Value = idCliente;

        this.XGridViewRegistrosRechazados.DataSource = GetDataTableUltimaImportacionClienteRechazados();
        this.XGridViewRegistrosRechazados.DataBind();

        this.XGridFacturasBajaPorInterfaz.DataSource = GetDataTableUltimaImportacionFacturasBajaPorInterfaz();
        this.XGridFacturasBajaPorInterfaz.DataBind();

        this.XGridViewFacturasExistentes.DataSource = GetDataTableUltimaImportacionClienteFacturasExistentes();
        this.XGridViewFacturasExistentes.DataBind();

        this.XGridViewErrorSigno.DataSource = GetDataTableUltimaImportacionClienteErrorSigno();
        this.XGridViewErrorSigno.DataBind();


        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
        ClienteDataContracts cliente = clienteServices.Load(Decimal.Parse(this.idCliente));

        this.nombreCliente.Text = "(" + cliente.IdCliente + ") " + cliente.NOMBRE;
    }


    private DataTable GetDataTableUltimaImportacionClienteErrorSigno()
    {


        IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

        List<InterfazFacturaDataContracts> listaIFDto = interfazFacturaService.GetAllInterfazFacturasByClienteFechaProceso(Int32.Parse(this.idcli.Value), this.fechaProceso);

        List<InterfazFacturaDataContracts> listaIFDtoFiltrado = new List<InterfazFacturaDataContracts>();

        foreach (InterfazFacturaDataContracts dto in listaIFDto)
        {

            if (dto.Estado.Equals("3"))
            {

                listaIFDtoFiltrado.Add(dto);
            }
        }

        DataTable dataTable = ConvertDataTable<InterfazFacturaDataContracts>.Convert(listaIFDtoFiltrado);

        lblCantidadErrorSigno.Text = "(" + listaIFDtoFiltrado.Count + ")";
        return dataTable;
    }

    private DataTable GetDataTableUltimaImportacionClienteFacturasExistentes()
    {


        IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

        List<InterfazFacturaDataContracts> listaIFDto = interfazFacturaService.GetAllInterfazFacturasByClienteFechaProceso(Int32.Parse(this.idcli.Value), this.fechaProceso);

        List<InterfazFacturaDataContracts> listaIFDtoFiltrado = new List<InterfazFacturaDataContracts>();
        int cantSaldosActualizados = 0;
        foreach (InterfazFacturaDataContracts dto in listaIFDto)
        {

            if (dto.Estado.Equals("1") || dto.Estado.Equals("4"))
            {

                listaIFDtoFiltrado.Add(dto);

                if (dto.Estado.Equals("4"))
                {
                    cantSaldosActualizados++;
                }
            }
        }

        DataTable dataTable = ConvertDataTable<InterfazFacturaDataContracts>.Convert(listaIFDtoFiltrado);

        lblCantidadFacturasExistentes.Text = "(" + (listaIFDtoFiltrado.Count-cantSaldosActualizados) + ") - Documentos Actualizados (" + cantSaldosActualizados+")";
        return dataTable;
    }


    private DataTable GetDataTableUltimaImportacionClienteRechazados()
    {


        IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

        List<InterfazFacturaDataContracts> listaIFDto = interfazFacturaService.GetAllInterfazFacturasByClienteFechaProceso(Int32.Parse(this.idcli.Value),this.fechaProceso);

        List<InterfazFacturaDataContracts> listaIFDtoFiltrado = new List<InterfazFacturaDataContracts>();

        foreach (InterfazFacturaDataContracts dto in listaIFDto)
        {

            //if (!dto.Estado.Equals("0") && !dto.Estado.Equals("1"))
            if (dto.Estado.Equals("2"))
            {

                listaIFDtoFiltrado.Add(dto);
            }
        }

        DataTable dataTable = ConvertDataTable<InterfazFacturaDataContracts>.Convert(listaIFDtoFiltrado);
        lblCantidadNoExisteDeudor.Text = "(" + listaIFDtoFiltrado.Count + ")";

        return dataTable;
    }


    private DataTable GetDataTableUltimaImportacionFacturasBajaPorInterfaz()
    {


        IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

        List<InterfazFacturaDataContracts> listaIFDto = interfazFacturaService.GetAllFacturasBajaPorInterfazByClienteFechaProceso(Int32.Parse(this.idcli.Value), this.fechaProceso);

        DataTable dataTable = ConvertDataTable<InterfazFacturaDataContracts>.Convert(listaIFDto);

        lblCantidadFacturasBaja.Text = "(" + listaIFDto.Count + ")";

        return dataTable;
    }


    protected DataTable XGridViewErrorSigno_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            dataTable = this.GetDataTableUltimaImportacionClienteErrorSigno();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }


    protected DataTable XGridViewRegistrosRechazados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            dataTable = this.GetDataTableUltimaImportacionClienteRechazados();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }

    protected DataTable XGridViewFacturasExistentes_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            dataTable = this.GetDataTableUltimaImportacionClienteFacturasExistentes();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }

    protected DataTable XGridFacturasBajaPorInterfaz_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            dataTable = this.GetDataTableUltimaImportacionFacturasBajaPorInterfaz();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }

    protected void Exportar_Click(object sender, EventArgs e)
    {


        List<string> listaSeleccionados = new List<string>();
        DataTable dt = new DataTable();

        List<string> lista = new List<string>();
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

        DataTable dataTable = XGridViewRegistrosRechazados_Filling(null, null);

        //if (mgr.Contains(Session.SessionID + "SeleccionGrilla"))
        //    lista = (List<string>)mgr.GetData(Session.SessionID + "SeleccionGrilla");
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

    protected void XGridViewFacturasExistentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.XGridViewFacturasExistentes.PageIndex = e.NewPageIndex;
        this.XGridViewFacturasExistentes.Fill();
    }


    protected void XGridViewRegistrosRechazados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.XGridViewRegistrosRechazados.PageIndex = e.NewPageIndex;
        this.XGridViewRegistrosRechazados.Fill();
    }


    protected void XGridFacturasBajaPorInterfaz_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.XGridFacturasBajaPorInterfaz.PageIndex = e.NewPageIndex;
        this.XGridFacturasBajaPorInterfaz.Fill();
    }

    protected void XGridViewErrorSigno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.XGridViewErrorSigno.PageIndex = e.NewPageIndex;
        this.XGridViewErrorSigno.Fill();
    }


    protected void btnReprocesar_Click(object sender, EventArgs e)
    {
        GobbiPrincipal principal = (GobbiPrincipal) Session["UserPrincipal"];
        ImportadorInterfaces.reprocesar(this.idcli.Value, principal.Identity.Name);
        this.inicializarTablas();        

    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewResultadosImportacionMaster.aspx");
    }
}

