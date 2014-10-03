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

public partial class Vistas_ViewPopUpRecibosCargados : GobbiPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["NumeroRemision"] != null)
        {
            var numRemision = Request.Params["NumeroRemision"].ToString();
            if (numRemision != string.Empty)
            {
                CargarRecibosDeRemisionActual(numRemision);

            }
            else
            {
                return;
            
            }
        }
        

    }


    protected void CargarRecibosDeRemisionActual(string numeroRecibo)
    {
        List<DatosEdicionReciboDataContracts> recibos = new List<DatosEdicionReciboDataContracts>();
        IDatosEdicionReciboService datosEdicionReciboServices = ServiceClient<IDatosEdicionReciboService>.GetService("DatosEdicionReciboService");
        recibos = datosEdicionReciboServices.GetAllDatosEdicionRecibosPorNumeroRemision(int.Parse(numeroRecibo));
        this.GvResultados.DataSource = recibos;
        this.GvResultados.DataBind();
    }

    protected void GvResultados_SelectedIndexChanged(object sender, EventArgs e)
    {
        int a;

        GridViewRow row = ((GridView)sender).SelectedRow;
        //Response.Redirect("ViewRemisionDeValoresEdicion.aspx?idCliente=" + row.Cells[UIUtils.GetPosCol(this.GvResultados, "ID Cliente")].Text + "&idDeudor=" + row.Cells[UIUtils.GetPosCol(this.GvResultados, "ID Deudor")].Text + "&numRecibo=" + row.Cells[UIUtils.GetPosCol(this.GvResultados, "N° Recibo")].Text + "&idRemision=" + row.Cells[UIUtils.GetPosCol(this.GvResultados, "N° Remisión")].Text);


        string url = "ViewRemisionDeValoresEdicion.aspx?idCliente=" + row.Cells[UIUtils.GetPosCol(this.GvResultados, "ID Cliente")].Text + "&idDeudor=" + row.Cells[UIUtils.GetPosCol(this.GvResultados, "ID Deudor")].Text + "&numRecibo=" + row.Cells[UIUtils.GetPosCol(this.GvResultados, "N° Recibo")].Text + "&idRemision=" + row.Cells[UIUtils.GetPosCol(this.GvResultados, "N° Remisión")].Text;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirEdicionRecibo", "javascript:AbrirVentanaEdicionRecibos('"+ url +"');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "cerrar", "self.close();", true);

    }


}
