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
using Gobbi.services;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;

public partial class Vistas_ViewPopUpHistoriaFactura : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        List<string> lista = null;

        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        //lista = (List<string>)mgr.GetData("historia");
        lista = (List<string>)Session["historia"];
        this.lstResHistorial.DataSource = lista;
        this.lstResHistorial.DataBind();
    }


    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ViewPopUpHistoriaFactura_cerrarPopUp", "javascript:window.close();", true);

    }

}
