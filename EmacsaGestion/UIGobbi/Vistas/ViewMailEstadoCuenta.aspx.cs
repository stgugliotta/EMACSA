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
using System.Collections.Generic;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Interfaces;
using Herramientas;
using System.Reflection;
using Gobbi.CoreServices.Security.Principal;

public partial class Vistas_ViewMailEstadoCuenta : GobbiPage 
{
    private double saldoTotal = 0;
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
            lblFecha.Text = DateTime.Today.ToString("dddd dd MMMM yyyy");
            
            IClienteService ClienteService = ServiceClient<IClienteService>.GetService("ClienteService");
            ClienteDataContracts Cliente = ClienteService.GetCliente(int.Parse(Request.QueryString["id_cliente"]));
            lblNombreCliente.Text = Cliente.NOMBRE;
            lblCuit.Text = Cliente.CUIT;

            //Bind del GridView
            IFacturaService FacturaServices = ServiceClient<IFacturaService>.GetService("FacturaService");
            List<FacturaDataContracts> resultadosObtenidos = FacturaServices.GetAllFacturasPorIdClienteyIdDeudorParaEstadoDeCuenta(int.Parse(Request.QueryString["id_cliente"]),int.Parse(Request.QueryString["id_deudor"]));
            gvFacturas.DataSource = resultadosObtenidos;
            gvFacturas.DataBind();
            lblSaldoTotal.Text = "Saldo total adeudado: " + saldoTotal.ToString();
        }                
    }
    protected void gvFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        e.Row.Cells[1].Visible = e.Row.Cells[2].Visible = e.Row.Cells[3].Visible = e.Row.Cells[4].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = e.Row.Cells[1].Text + "-" + e.Row.Cells[2].Text + "-" + e.Row.Cells[3].Text +"-" + e.Row.Cells[4].Text;
            saldoTotal += double.Parse(e.Row.Cells[6].Text);
        }
        lblSaldoTotal.Text = saldoTotal.ToString();
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        string[] copias={};// = { ((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).Email };
        string[] bCC = { ((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).Email };
        IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
        ClienteDataContracts clienteDataContracts = clienteServices.GetCliente(int.Parse(Session["clienteSeleccionado"].ToString()));
        string destinatario = clienteDataContracts.EMAIL;
        foreach (GridViewRow item in this.gvResultadosMails.Rows)
        {
            CheckBox chk = ((CheckBox)((System.Web.UI.Control)(item.Cells[3])).Controls[1]);

            if (chk.Checked)
            {
                
                copias.ToList().Add(item.Cells[2].ToString());
            }
        }


        if (ConfigurationManager.AppSettings["isTest"] == "Test")
        {
            destinatario = ConfigurationManager.AppSettings["destinatarioTest"];
            copias.ToList().Clear();
            bCC.ToList().Clear();
        
        }
        string subject = "Estado de Cuenta"; 
        string body = ObtenerContenido();
        
    //    Correo.Priority = System.Net.Mail.MailPriority.Normal;
        //System.Net.Mail.MailMessage Correo = new System.Net.Mail.MailMessage();
        //Correo.From = new System.Net.Mail.MailAddress("eduardob@emacsa.com.ar");//Si se quiere comprobar, agregar una cuenta de yahoo         
        //Correo.To.Add("stgugliotta@gmail.com");   //Si se quiere probar, poner cualquier cuenta

        //foreach (GridViewRow item in this.gvResultadosMails.Rows)
        //{
        //    CheckBox chk = ((CheckBox)((System.Web.UI.Control)(item.Cells[3])).Controls[1]);

        //    if (chk.Checked)
        //    {

        //        Correo.CC.Add(item.Cells[2].ToString());
        //    }
        //}

        //Correo.CC.Add("fmperfetti@hotmail.com");
        //Correo.CC.Add("gabrielsanblas@gmail.com");    //Si se quiere probar, poner cualquier cuenta
        //Correo.Subject = "Estado de Cuenta";      //Completar el asunto
        //Correo.Body = ObtenerContenido();
        //Correo.IsBodyHtml = true;
        //Correo.Priority = System.Net.Mail.MailPriority.Normal;

        //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //smtp.Host = "192.168.0.10";
        ////Si se quiere probar, usar el smtp de yahoo (smtp.mail.yahoo)
        //smtp.Credentials = new System.Net.NetworkCredential("eduardob", "edEMA01");
        ////Si se quiere prbar, completar con el nombre de usuario (sin @yahoo.com ni nada) y el pass.
        try
        {
            //smtp.Send(Correo);
            //smtp.Send(((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).Email, destinatario, copias, "Estado de Cuenta", "", false, false, "", ConfigurationManager.AppSettings["smtp"], ((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).Email, ((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).PasswordEmail, ((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).Email);
            MailSender.Send(((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).Email, destinatario, copias, subject, body, true, false, "", ConfigurationManager.AppSettings["smtp"], ((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).Email, ((GobbiIdentity)((GobbiPrincipal)Session["UserPrincipal"]).Identity).PasswordEmail, bCC.ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Enviado", "alert('Mensaje enviado.');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Enviado", "alert('Mensaje no enviado: No se puede conectar al servidor de correo.');", true);
        }
    }
    private string ObtenerContenido()
    {
        System.IO.StringWriter stringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
        pnlContenido.RenderControl(htmlWriter);
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        stringBuilder.Append("<html>");
        stringBuilder.Append("<head>");
        stringBuilder.Append("</head>");
        stringBuilder.Append("<body>");
        stringBuilder.Append(stringWriter.ToString());
        stringBuilder.Append("</body>");
        stringBuilder.Append("</html>");
        return stringBuilder.ToString();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void VerPosiblesDestinatarios(object sender, ImageClickEventArgs e)
    {
        ActualizarGrillaPosiblesDestinatarios(int.Parse(Request.QueryString["id_cliente"]));
        this.ModalPopupPosiblesDestinatarios.Show();
    }

    private void ActualizarGrillaPosiblesDestinatarios(int idCliente)
    {



        IMailService ClienteService = ServiceClient<IMailService>.GetService("MailService");
        List<MailDataContracts> mail = ClienteService.GetAllMailsByIdCliente(idCliente);

        this.gvResultadosMails.DataSource = mail;
        this.gvResultadosMails.DataBind();

        //List<PagoDataContracts> listaDePagosCargados = new List<PagoDataContracts>();

        //if (Session["ListaDePagos"] != null)
        //{
        //    listaDePagosCargados = (List<PagoDataContracts>)Session["ListaDePagos"];
            
        //}
        //int a = 1;
        //List<ChequeDataContracts> listaDeCheques = new List<ChequeDataContracts>();
        //foreach (PagoDataContracts pago in listaDePagosCargados)
        //{
        //    if (pago.FormaPago.Descripcion == "CHEQUE")
        //    {
        //        pago.Orden = a++;
        //        ChequeDataContracts nuevoCheque = new ChequeDataContracts();
        //        UIUtils.MappingEntity(pago, nuevoCheque);
        //        listaDeCheques.Add(nuevoCheque);
        //    }
        //}


        //DataTable dataTable = new DataTable();
        //Type itemsType = typeof(ChequeDataContracts);

        //foreach (PropertyInfo property in itemsType.GetProperties())
        //{
        //    DataColumn column = new DataColumn(property.Name);
        //    column.DataType = property.PropertyType;
        //    dataTable.Columns.Add(column);

        //}

        //foreach (ChequeDataContracts cheque in listaDeCheques)
        //{
        //    DataRow row = dataTable.NewRow();

        //    foreach (PropertyInfo property in itemsType.GetProperties())
        //    {
        //        row[property.Name] = property.GetValue(cheque, null);
        //    }

        //    dataTable.Rows.Add(row);
        //}


        //this.gvResultadosCheques.DataSource = dataTable;
        //this.gvResultadosCheques.DataBind();
        //Session["ListaDePagos"] = null;

    }

    protected void btnAceptarDestinatarios_Click(object sender, EventArgs e)
    {
       
    }



}
