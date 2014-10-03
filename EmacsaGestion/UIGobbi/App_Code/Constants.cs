using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

/// <summary>
/// Constants  Class
/// </summary>
public static class Constants
{
    /// <summary>
    ///   CACHE_CASO
    /// </summary>
    /// <value>string</value>
    public static string CACHE_CASO
    {
        get { return "CASO"; }
    }

    public static string CACHE_LISTACASO
    {
        get { return "LISTACASO"; }
    }

    public static string DOCUMENTO
    {
        get { return "DOCUMENTO"; }
    }

    public static string TIPOCASO
    {
        get { return "TIPOCASO"; }
    }

    public static string PROCEDENCIA 
    {
        get { return "PROCEDENCIA"; }
    }
   
    public static string ESTADOCASO 
    {   
        get { return "ESTADOCASO"; }
    }

    public static string LISTAASINAR
    {
            get { return "LISTAASINAR"; }
    }

    public static string USUARIOS
    {
        get { return "USUARIOS"; }
    }

    public static string CACHE_CRITERIO
    {
        get { return "CACHE_CRITERIO"; }
    }

    public static string CACHE_CASORELACIONADO
    {
        get { return "CACHE_CASORELACIONADO"; }
    }
        
    public static string CACHE_CASOSERVICIO
    {
        get { return "CACHE_CASOSERVICIO"; } 
    }

    public static string CACHE_CASODOCUMENTOS
    {
        get { return "CACHE_CASODOCUMENTOS"; }
    }

    public static string CACHE_CASOMACROCONCEPTOS
    {
        get { return "CACHE_CASOMACROCONCEPTOS"; }
    }

    public static string CACHE_CASOCARTAS
    {
        get { return "CACHE_CASOCARTAS"; }
    }

    public static string TIPOCARTA
    {
        get { return "TIPOCARTA"; }
    }

    public static string CACHE_LISTADOREPORTES
    {
        get { return "CACHE_LISTADOREPORTES"; }
    }

    public static string CACHE_COMBOESTADOS
    {
        get { return "CACHE_COMBOESTADOS"; }
    }

    public static string CACHE_RESULTADO_ESTADO_DOCUMENTO
    {
        get { return "CACHE_RESULTADO_ESTADO_DOCUMENTO"; }
    }

    public static string CACHE_GESTORESTADODOCUMENTOS_LISTADORESULTADOS
    {
        get { return "CACHE_GESTORESTADODOCUMENTOS_LISTADORESULTADOS"; }
    }

    public static string IMPRESION
    {
        get { return "Impresion"; }
    }

    public static string PREVIEW
    {
        get { return "Preview"; }
    }

  public static string MOTIVOAR  
  {        
      get { return "MOTIVOAR"; }    
  }
    
  public static string CACHE_SISTEMAORIGEN    
    {
      get { return "CACHE_SISTEMAORIGEN"; }
  }   

    public static string CACHE_SISTEMAORIGENDOC  
    {
        get { return "CACHE_SISTEMAORIGENDOC"; }    
    }
    
    public static string CACHE_MACROCONCEPTOS    
    {        
        get { return "CACHE_MACROCONCEPTOS"; }    
    }

    public static string CACHE_DOCUMENTOS_A_EXPORTAR
    {
        get { return "CACHE_DOCUMENTOS_A_EXPORTAR"; }
    }

    public static string DEFAULT_CHANGE
    {
        get { return "1,00"; }
    }
    public static string ESTILO_REMISION_EN_USO
    {
        get { return "RemisionEnUso"; }
    }

    public static string ESTILO_REMISION_NUEVA
    {
        get { return "RemisionNueva"; }
    }

    public static string ESTILO_EDICION_DE_REMISION
    {
        get { return "EdicionDeRemision"; }
    }
}










