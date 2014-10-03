using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.services;

public partial class Vistas_ViewGestionCobradores : GobbiPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Configuración Inicial

        if (Request.Params["__EVENTTARGET"] != null)
        {
            string sourceControl = Request.Params["__EVENTTARGET"];
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        if (!IsPostBack)
        {
            List<ClienteDataContracts> lstCliente;
            new List<ClienteDataContracts>();
            IClienteService clienteService = ServiceClient<IClienteService>.GetService("ClienteService");
            lstCliente = clienteService.GetAllClientes();
            cmbClientes.DataTextField = "NOMBRE";
            cmbClientes.DataValueField = "IdCliente";
            cmbClientes.DataSource = lstCliente;
            cmbClientes.DataBind();
            cmbClientes.Items.Insert(0, "--Seleccione--");
            cmbClientes_SelectedIndexChanged(null, null);


            var lstCobrador = new List<CobradorDataContracts>();
            ICobradorService cobradorService = ServiceClient<ICobradorService>.GetService("CobradorService");
            lstCobrador = cobradorService.GetAllCobrador();
            ddlMotoquero.DataTextField = "NOMBRE";
            ddlMotoquero.DataValueField = "id";
            ddlMotoquero.DataSource = lstCobrador;
            ddlMotoquero.DataBind();
            ddlMotoquero.Items.Insert(0, "--Seleccione--");

            //btnAsignar.Enabled = btnAsignar.Visible = false;
        }

        #endregion
    }

    protected void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbClientes.SelectedIndex != 0)
        {
            XGridViewRecibos.DataSource = GetDataTableRecibos();
            XGridViewRecibos.DataBind();

            /*lstDeudor = deudorService.GetAllDeudorsPorCriterioCliente(int.Parse(this.cmbClientes.SelectedValue));
            this.ddlCuenta.DataSource = lstDeudor;
            this.ddlCuenta.DataBind();*/
        }
        /*else
            this.ddlCuenta.Items.Clear();
        this.ddlCuenta.Items.Insert(0, "--Seleccione--");*/
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int cantInsert = 0;
        if (cmbClientes.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Selección invalida",
                                                "javascript:alert('Debe seleccionar cliente.');", true);
            return;
        }
        else
        {
            Int32 iRecibo = int.Parse(txtRecibo.Text.Substring(5));
            Int32 iReciboHasta = int.Parse(txtReciboHasta.Text.Substring(5));
            Int32 cantRecibos = iReciboHasta - iRecibo;
            if (cantRecibos <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Selección invalida",
                                                    "javascript:alert('El Nro. de Recibo Hasta debe ser mayor al Nro. de Recibo Desde.');",
                                                    true);
                return;
            }

            for (int i = 0; i <= cantRecibos; i++)
            {
                var oRecibo = new ReciboDataContracts();
                IReciboService reciboService = ServiceClient<IReciboService>.GetService("ReciboService");
                oRecibo.Numero = txtRecibo.Text.Substring(0, 5) + (iRecibo + i).ToString("00000000");
                oRecibo.Cliente = new ClienteDataContracts();
                oRecibo.Cliente.IdCliente = int.Parse(cmbClientes.SelectedValue);
                oRecibo.Deudor = null;
                //oRecibo.Deudor.IdDeudor = int.Parse(ddlCuenta.SelectedValue);
                oRecibo.Cobrador = new CobradorDataContracts();
                oRecibo.Cobrador.Id = ddlMotoquero.SelectedIndex != 0 ? int.Parse(ddlMotoquero.SelectedValue) : 0;
                oRecibo.FechaCarga = DateTime.Now;
                try
                {
                    if (
                        reciboService.GetReciboByNumReciboIdCliente(oRecibo.Numero,
                                                                    Int32.Parse(oRecibo.Cliente.IdCliente.ToString())) ==
                        null)
                    {
                        reciboService.Insert(oRecibo);
                        cantInsert++;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Insert Error",
                                                        "javascript:alert('Ocurrió un error al intentar insertar el recibo " +
                                                        oRecibo.Numero + ". ' " + ex.Message + ");", true);
                }
            }
            if (cantInsert > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Insert OK",
                                                    "javascript:alert('" + cantInsert +
                                                    " recibo/s insertado/s correctamente.');", true);
                cmbClientes_SelectedIndexChanged(null, null);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Insert OK",
                                                    "javascript:alert('No se han creado nuevos recibos. Es probable que ya existan recibos coincidentes con su selección.');",
                                                    true);
            }
        }
    }

    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        //Obtener el Id del recibo para poder vincularlo
        //Actualizar el recibo con el motoquero e insertar la relación
        ReciboDataContracts oRecibo = null;
        IReciboService reciboService = ServiceClient<IReciboService>.GetService("ReciboService");
        int cantActualizados = 0;
        if (cmbClientes.SelectedIndex < 1) return;

        Int32 iRecibo = int.Parse(txtRecibo.Text.Substring(5));
        Int32 iReciboHasta = int.Parse(txtReciboHasta.Text.Substring(5));
        Int32 cantRecibos = iReciboHasta - iRecibo;

        if (cantRecibos <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Selección invalida",
                                                "javascript:alert('El Nro. de Recibo Hasta debe ser mayor al Nro. de Recibo Desde.');",
                                                true);
            return;
        }

        for (int i = 0; i <= cantRecibos; i++)
        {
            string nroRecibo = txtRecibo.Text.Substring(0, 5) + (iRecibo + i).ToString("00000000");

            oRecibo = reciboService.GetReciboByNumReciboIdCliente(nroRecibo, int.Parse(cmbClientes.SelectedValue));
            //Una vez que se obtiene el recibo...
            if (oRecibo != null)
            {
                if (!oRecibo.UsadoRemision && ddlMotoquero.SelectedIndex != 0)
                {
                    oRecibo.Cobrador = new CobradorDataContracts();
                    oRecibo.Cobrador.Id = int.Parse(ddlMotoquero.SelectedValue);
                    reciboService.Update(oRecibo); //Actualiza el motoquero
                    cantActualizados++;
                }
            }
        }
        cmbClientes_SelectedIndexChanged(this, null);

        if (cantActualizados > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "UPDATE OK",
                                                "javascript:alert('" + cantActualizados +
                                                " cobrador/es asignado/s correctamente.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "UPDATE OK",
                                                "javascript:alert('No se han modificado recibos. Es probable que su selección no coincida con los recibos existentes.');",
                                                true);
        }
    }


    private DataTable GetDataTableRecibos()
    {
        IReciboService reciboService = ServiceClient<IReciboService>.GetService("ReciboService");


        List<ReciboDataContracts> listaRecibos =
            reciboService.GetAllRecibosByIdCliente(int.Parse(cmbClientes.SelectedValue));

        DataTable dataTable = ConvertDataTable<ReciboDataContracts>.Convert(listaRecibos);

        return dataTable;
    }

    protected DataTable XGridViewRecibos_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            dataTable = GetDataTableRecibos();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }

    protected void XGridViewRecibos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        XGridViewRecibos.PageIndex = e.NewPageIndex;
        XGridViewRecibos.Fill();
    }
}