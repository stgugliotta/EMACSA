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

public partial class Vistas_ViewHojaDeRutaAlta : GobbiPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        this.btnCrearHoja.Visible = false;
        this.gvDeudores.Visible = true;
        IFacturaService facturaService = ServiceClient<IFacturaService>.GetService("FacturaService");
        DateTime fechaIngresada;
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

            this.btnBuscarActivas_Click(sender, e);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error HojaDeRuta", "javascript:alert('" + ex.Message + "');", true);
        }

    }

    protected void btnBuscarActivas_Click(object sender, EventArgs e)
    {

        //pnlAlta.Visible = false;
        //pnlModificacion.Visible = false;
       // toggleDivDSG(false);
        //pnlModificacionDeudoresSinGestion.Visible = false;

        //IHojaService hojaService = ServiceClient<IHojaService>.GetService("HojaService");
        //IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");

        //List<HojaDataContracts> hojasDC = null; //hojaService.GetAllHojas();

        //if (this.txtFechaDesdeActivas.Text != "" && this.txtFechaHastaActivas.Text != "")
        //{

        //    hojasDC = hojaService.GetAllHojasEntreFechas(DateTime.Parse(this.txtFechaDesdeActivas.Text), DateTime.Parse(this.txtFechaHastaActivas.Text));

        //}
        //else if (this.txtHojaDeRuta.Text != "")
        //{
        //    HojaDataContracts hojaDC = hojaService.Load(decimal.Parse(this.txtHojaDeRuta.Text));
        //    if (hojaDC != null)
        //    {
        //        hojasDC = new List<HojaDataContracts>();
        //        hojasDC.Add(hojaDC);
        //    }
        //}

        //gvHojasActivas.DataSource = hojasDC;
        //gvHojasActivas.DataBind();
        //Session["hojasDC"] = hojasDC;


    }

    private class DeudorHojaDeRutaComparator : IComparer<DeudorHojaDeRutaDataContracts>
    {
        public int Compare(DeudorHojaDeRutaDataContracts aX, DeudorHojaDeRutaDataContracts aY)
        {
            //return (aY.IdCobrador + aY.Horario + aY.Localidad + aY.Provincia).CompareTo(aX.IdCobrador + aX.Horario + aX.Localidad + aX.Provincia);
            return (aX.IdCobrador + aX.Horario + aX.Localidad + aX.Provincia).CompareTo(aY.IdCobrador + aY.Horario + aY.Localidad + aY.Provincia);

        }
    }
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
}
