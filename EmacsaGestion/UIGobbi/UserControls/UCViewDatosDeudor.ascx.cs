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
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;

public partial class UserControls_UCViewDatosDeudor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");
        if ((DeudorDataContracts)mgr.GetData(Session.SessionID + "deudorSeleccionado") != null)
        {

            DeudorDataContracts deudor = (DeudorDataContracts)mgr.GetData(Session.SessionID + "deudorSeleccionado");

            this.txtDomicilio.Text = deudor.Domicilio;
            this.txtNombre.Text = deudor.Nombre;
            this.txtTelefono.Text = deudor.Telefono;

        
        }
            
            


    }
}
