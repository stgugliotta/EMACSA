using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace Security
{
    public class SecurityToControl
    {


        public void ValidatePage(System.Web.UI.Control  page)
        {

            foreach (System.Web.UI.Control item in page.Controls   )
            {
                try
                {
                    if (item.HasControls()) ValidatePage(item);
                    System.Web.UI.WebControls.WebControl wc = (System.Web.UI.WebControls.WebControl)item;
                    // Aca debo buscar este id en la lista de permisos del tipo. Debo tomar el usuario de la sesion
                    // luego la lista de permisos y habilitar o no el contenido del control.Si no encuentra el wc.ID le inhabilitamos
                    // el control con wc.Enabled = false;
                }
                catch
                {}
                
                
            }
        }
    }
}
