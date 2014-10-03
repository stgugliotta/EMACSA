using System;
using System.Collections.Generic;
using Common.DataContracts;
using Gobbi.CoreServices.Context;
using Gobbi.services;
using Gobbi.CoreServices.Security.Authentication;
using Common.Interfaces;
using System.Web.UI;
using System.IO;
using System.Xml;


/// <summary>
/// Pagina Master,incluidas en todas las pagians 
/// </summary>
public partial class MasterPage : System.Web.UI.MasterPage
{
    public static string sourceControl;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        menuCaller.Text = printMenuCallerStructure();
        menuStructure.Text = printMenuStructure();
        Gobbi.CoreServices.Security.Principal.GobbiPrincipal principal=(Gobbi.CoreServices.Security.Principal.GobbiPrincipal)Session["UserPrincipal"];
        if (principal == null || principal.Identity == null) {
            Response.Redirect("ViewLogOut.aspx");
        }
        this.lblUsuario.Text = principal.Identity.Name;

        
    }
    
    protected void Init(object sender, EventArgs e) {
        

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = 10;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        Response.AddHeader("pragma", "no-cache");
        Response.AddHeader("cache-control", "private");
        Response.CacheControl = "no-cache";

    }

    protected void EvaMenu1_MenuItemClick(object sender, System.Web.UI.WebControls.MenuEventArgs e)
    {

    }

    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {

        //List<AlertaDataContracts> resultadoObtenidos = new List<AlertaDataContracts>();
        //IAlertaService alertaServices = ServiceClient<IAlertaService>.GetService("AlertaService");

        //AlertaDataContracts alertaDataContracts = alertaServices.Load(1);

        //this.lblAlerta.Text = alertaDataContracts.AlertaDes;


    }

    protected String printMenuCallerStructure()
    {

        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("..\\menu.xml"));

        string js = string.Empty;

        js += "<script> ";
        js+="function openMenu(opcion) { ";

        XmlNodeList liElements = myDoc.DocumentElement.GetElementsByTagName("li");

        foreach (XmlNode node in liElements) {


            if (node.FirstChild != null)
            {
                js += "if (opcion == '" + node.FirstChild.InnerText.Replace ('\t',' ').Replace ('\n',' ').Replace ('\r',' ').Trim() + "') {";
                if (node.Attributes.Count > 0) {
                    if (node.Attributes.GetNamedItem("action")!=null && !node.Attributes.GetNamedItem("action").Equals(string.Empty))
                    {
                        if (node.Attributes.GetNamedItem("action").Value == "salir")
                        {
                            js += "    window.close();";
                        } else {
                            string sProtocol = ( Request.ServerVariables["HTTPS"].Equals( "ON") ? "https" : "http"  );

                            js += "    document.location = '" + sProtocol + "://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Vistas/" + node.Attributes.GetNamedItem("action").Value + "';";
                            //   js += "    document.location.href = '"  + node.Attributes.GetNamedItem("action").Value + "';";
                        }
                    }
                }
                js += "}";
            }
        
        }
        js += "}</script>";


        return js;
    }

    protected String printMenuStructure() {

        

        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("..\\menu.xml"));

        return myDoc.InnerXml;
    }

    protected String printMenuCaller()
    { 
    
        string js = string.Empty;
        js +="<script type=\"text/javascript\">";
        js +="<!--";

        js +="$(document).ready(function()";
        js +="{";
        js +="	var options = {minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem){";
		
        
        js +="alert('you clicked item \"' + $(this).text() + e  + '\"');";

            
        js +="	}};";
	        js +="$('#menuone').menu(options);";

        js +="	var items = [	{src: 'test', url:'http://www.jquery.com'},";
        js +="					{src: ''}, // separator";
        js +="					{src: 'test2', subMenu: [	{src: 'sub 1'},";
        js +="												{src: 'sub 2', url: 'http://p.sohei.org', target: '_blank'},";
        js +="												{src: 'sub 3'}]}];";
        js +="	$('#menutwo').menu(options, items);";
        js += "	$('#menuthree').menu(options);";
        js +="	$('#menufive>img').menu(options, '#menufivelist');";

        js +="	//creating a menu without items";
        js +="	var menu = new $.Menu('#menufour', null, options);";
        js +="	//adding items to the menu";
        js +="	menu.addItems([";
        js +="		new $.MenuItem({src: 'test', url:'http://www.jquery.com'}, options),";
        js +="		new $.MenuItem({src: ''}) // separator";
        js +="	]);";
        js +="	var itemWithSubmenu = new $.MenuItem({src: 'test2'}, options);";
        js +="	//creating a menu with items (as child of itemWithSubmenu)";
        js +="	new $.Menu(itemWithSubmenu, [";
        js +="		new $.MenuItem({src: 'sub 1'}, options),";
        js +="		new $.MenuItem({src: 'sub 2', url: 'http://p.sohei.org', target: '_blank'}, options),";
        js +="		new $.MenuItem({src: 'sub 3'}, options)";
        js +="	], options);";
	        //adding the submenu to the main menu
        js +="	menu.addItem(itemWithSubmenu);";

        js +="	//highlight stuff..";
        js +="	///dp.SyntaxHighlighter.ClipboardSwf = 'http://p.sohei.org/wp-content/plugins/syntaxhighlighter-plus/files/clipboard.swf';";
        js +="	//dp.SyntaxHighlighter.HighlightAll('code');";
        js +="});";
        js +="-->";
         
        js +="</script>	 ";

        return js;

    }

    

}
