using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.DataContracts;
using Common.Interfaces;
using System.Collections.Generic;
using Gobbi.services;
using Herramientas;

namespace UIGobbi.Vistas
{
    public partial class ViewLocalizarFactura : GobbiPage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["__EVENTTARGET"] != null)
            {
                var sourceControl = Request.Params["__EVENTTARGET"].ToString();
                if (sourceControl.Contains("UpdateTimer"))
                    return;
            }
        }
         protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            DataTable dataTable = GetDataTableFacturas();
            this.gvResultados.DataSource = dataTable;
            this.gvResultados.DataBind();
        }

        private DataTable GetDataTableFacturas()
        {
            List<FacturaDataContracts> resultadoObtenidos = new List<FacturaDataContracts>();
            IFacturaService facturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
            FacturaDataContracts factura=new FacturaDataContracts();
            factura.NumeroComp=int.Parse(this.txtNumFactura.Text);
            resultadoObtenidos = facturaServices.GetAllFacturasByCriteriaTodosLosEstados(factura);
            return ConvertDataTable<FacturaDataContracts>.Convert(resultadoObtenidos);
        }

        protected DataTable GvResultados_Filling(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = this.GetDataTableFacturas();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataTable;
        }


        protected void gvResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridView)sender).SelectedRow;

            if (row.Cells[UIUtils.GetPosCol(this.gvResultados, "Estado Remision")].Text.Equals("CERRADA") || row.Cells[UIUtils.GetPosCol(this.gvResultados, "Estado")].Text.Equals("BAJA POR INTERFAZ"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "RemisionAsignada", "alert('No puede realizar esta operación. Esta factura se encuentra en una remisión ya cerrada o la factura se encuentra dada de baja (ya gestionada).');", true);
                return;
            }
            Response.Redirect("ViewRemisionDeValores.aspx?idCliente=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "idCliente")].Text + "&idDeudor=" + row.Cells[UIUtils.GetPosCol(this.gvResultados, "idDeudor")].Text);
        }
    }
}
