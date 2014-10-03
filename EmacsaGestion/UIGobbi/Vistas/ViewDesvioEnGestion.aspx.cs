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


public partial class Vistas_ViewDesvioEnGestion : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Vistas_ViewDesvioEnGestion));

   
           // this.GvResultados.DataSource = GetTableLocalidadPorIdZona(int.Parse(this.cmbZona.SelectedItem.Value));
            this.GvResultados.DataBind();

            this.listBoxCobradores.Items.Clear();
           // this.listBoxCobradores.DataSource = GetTableCobradorPorZonaAsignada(int.Parse(this.cmbZona.SelectedItem.Value));
            this.listBoxCobradores.DataTextField = "Apellido";
            this.listBoxCobradores.DataValueField = "Id";
            this.listBoxCobradores.DataBind();

        }
    }


    protected void cmbAnalistas_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }

    private DataTable GetTableLocalidadPorIdZona(int idZona)
    {
        List<DeudorDataContracts> deudores = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        deudores = deudorServices.GetAllLocalidadPorCriterioIdZona(idZona);
        return ConvertDataTable<DeudorDataContracts>.Convert(deudores);
    }

    private DataTable GetTableLocalidadCp()
    {
        List<DeudorDataContracts> deudores = new List<DeudorDataContracts>();
        IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
        deudores = deudorServices.GetAllLocalidadCp();
        return ConvertDataTable<DeudorDataContracts>.Convert(deudores);
    }

    private DataTable GetTableCobradorPorZonaAsignada(int idZona)
    {
        List<CobradorDataContracts> cobradores = new List<CobradorDataContracts>();
        ICobradorService cobradorServices = ServiceClient<ICobradorService>.GetService("CobradorService");
        cobradores = cobradorServices.GetAllCobradorPorZonaAsignada(idZona);
        return ConvertDataTable<CobradorDataContracts>.Convert(cobradores);
    }

    private DataTable GetTableZona()
    {
        List<ZonaDataContracts> zonas = new List<ZonaDataContracts>();
        IZonaService zonaServices = ServiceClient<IZonaService>.GetService("ZonaService");
        zonas = zonaServices.GetAllZona();
        return ConvertDataTable<ZonaDataContracts>.Convert(zonas);
    }

    protected DataTable GvResultados_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        try
        {
            //dataTable = GetTableLocalidadPorIdZona(int.Parse(this.cmbZona.SelectedItem.Value));

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dataTable;
    }
    protected void GvResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GvResultados.PageIndex = e.NewPageIndex;
        this.GvResultados.Fill();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Bindear", "BindearCP();", true);
    }
   

   
}
