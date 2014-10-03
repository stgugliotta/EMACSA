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
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using System.Collections.Generic;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.services;

public partial class Vistas_ViewPopUpAgenda : GobbiPage 
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

            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            CargarTareas(DateTime.Now, principal.Identity.Name);

            List<DeudorDataContracts> Deudores = new List<DeudorDataContracts>();
            IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
            
            Deudores = deudorServices.GetAllDeudorsPorCriterioAnalista(principal.Identity.Name);

            foreach (DeudorDataContracts deudor in Deudores)
            {
                ListItem li = new ListItem();
                li.Text = deudor.Nombre;
                li.Value = deudor.IdDeudor.ToString();
                lstDeudoresAsignados.Items.Add(li);
            }
        }
    }

    protected void txtFecha_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            CargarTareas(DateTime.Parse(((System.Web.UI.WebControls.TextBox)sender).Text), principal.Identity.Name);

        }
        catch
        { }
    }
    protected void btnCrearTarea_Click(object sender, EventArgs e)
    {
        try
        {
            IAgendaService AgendaServices = ServiceClient<IAgendaService>.GetService("AgendaService");

            AgendaDataContracts agenda = new AgendaDataContracts();

            TimeSpan dt = this.TimeSelector1.Date.TimeOfDay;
            agenda.FechaDeAlerta = DateTime.Parse(this.txtFechaNuevaTarea.Text + " " + dt.ToString());
            agenda.Tarea = this.txtTareaDescripcion.Text;
            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            agenda.Usuario = principal.Identity.Name;
            agenda.Criticidad = this.cmbCriticidad.SelectedValue;
            agenda.Estado = "PENDIENTE";

            AgendaServices.Insert(agenda);
            // this.UpdatePanelCalendarioAgenda.Update();

            CargarTareas(DateTime.Now, principal.Identity.Name);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alerta", "javascript:alert('La tarea fue agregada a su agenda satisfactoriamente.');", true);

            this.txtTareaDescripcion.Text = "";
            this.txtFechaNuevaTarea.Text = "";
        }
        catch
        {

        }
    }

    private void CargarTareas(DateTime fecha, string analista)
    {
        List<AgendaDataContracts> resultadoObtenidos = new List<AgendaDataContracts>();


        IAgendaService AgendaServices = ServiceClient<IAgendaService>.GetService("AgendaService");

        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        resultadoObtenidos = AgendaServices.GetAllAgendasByAnalistaYFecha(principal.Identity.Name, fecha);
        this.lstTareasAsignadas.Items.Clear();
        resultadoObtenidos.Sort(CompararFechas);
        foreach (AgendaDataContracts agenda in resultadoObtenidos)
        {


            this.lstTareasAsignadas.Items.Add(agenda.FechaDeAlerta.TimeOfDay.ToString() + ": " + agenda.Tarea);

        }


    }

    public int CompararFechas(AgendaDataContracts fecha1, AgendaDataContracts fecha2)
    {


        return fecha1.FechaDeAlerta.CompareTo(fecha2.FechaDeAlerta);


    }

    private void CargarTareas()
    {
        List<AgendaDataContracts> resultadoObtenidos = new List<AgendaDataContracts>();
        IAgendaService AgendaServices = ServiceClient<IAgendaService>.GetService("AgendaService");
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        resultadoObtenidos = AgendaServices.GetAllAgendasByAnalista(principal.Identity.Name);
        this.lstTareasAsignadas.Items.Clear();
        foreach (AgendaDataContracts agenda in resultadoObtenidos)
        {
            if (agenda.FechaDeAlerta.Date == DateTime.Now.Date)
            {
                this.lstTareasAsignadas.Items.Add(agenda.Tarea);
            }
        }
    }
}
