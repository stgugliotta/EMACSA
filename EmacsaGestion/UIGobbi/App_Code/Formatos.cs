using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


/// <summary>
/// Formatos
/// </summary>
public class Formatos
{
    /// <summary>
    /// Contructor standard de la clase
    /// </summary>
    public Formatos()
    {
    }

    /// <summary>
    ///  tipo de fecha posible
    /// </summary>
    public enum TipoFecha 
            { 
                    /// <summary>
                    /// Formato de dia normal
                    /// </summary>
                    FormatoBaseDia, 
                    
                    /// <summary>
                    /// Formato de cias con muinutos
                    /// </summary>
                    FormatoBaseConMinutos, 
                    
                    /// <summary>
                    /// Formato con segundos
                    /// </summary>
                    FormatoBaseConSegundos, 
                   
                    /// <summary>
                    /// Fecha
                    /// </summary>
                    VisualizarFecha, 
                    
                    /// <summary>
                    ///  VisualizarFechaHora
                    /// </summary>
                    VisualizarFechaHora 
            } 


    public static string FechayyyyMMdd(string sFecha)
    {
        string fecha = null;
        if (sFecha != null && sFecha.Trim() != string.Empty)
        {
            if (sFecha.Trim().Length.Equals(8) && sFecha.IndexOf("/") == -1 && sFecha.IndexOf("-") == -1)
            {
                fecha = sFecha;
            }
            else
            {
                try
                {
                    DateTime dtFechaTemp = DateTime.Parse(sFecha, Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
                    fecha = dtFechaTemp.ToString("yyyyMMdd");
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message + " " + Thread.CurrentThread.CurrentUICulture.DisplayName);
                }
            }
        }
        return fecha;
    }

    public static string FechayyyyMMddHHmm(string sFecha)
    {
        string fecha = null;
        if (sFecha != null && sFecha.Trim() != string.Empty)
        {
            if (sFecha.Trim().Length.Equals(14) && sFecha.IndexOf("/") == -1 && sFecha.IndexOf("-") == -1)
            {
                fecha = sFecha;
            }
            else
            {
                try
                {
                    DateTime dtFechaTemp = DateTime.Parse(sFecha, Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
                    fecha = dtFechaTemp.ToString("yyyyMMdd hh:mm");
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }
        return fecha;
    }

    public static string Fecha2Cultura(string sFecha)
    {
        return FechaFormato2Cultura(sFecha, 'd', "yyyyMMdd");
    }

    public static string FechaHora2Cultura(string sFecha, string formato)
    {
        return FechaFormato2Cultura(sFecha, 'g', formato);
    }

    private static string FechaFormato2Cultura(string sFecha, char cFormato, string formatoUniversal)
    {
        string fecha = null;
        try
        {
            if (sFecha != null && sFecha.Trim() != string.Empty)
            {
                if (sFecha.IndexOf(Thread.CurrentThread.CurrentUICulture.DateTimeFormat.DateSeparator) != -1)
                {
                    DateTime dtFechaTemp = DateTime.Parse(sFecha);
                    fecha = dtFechaTemp.ToString(cFormato.ToString(), Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
                }
                else
                {
                    string myFormato = formatoUniversal;
                    System.IFormatProvider provider = Thread.CurrentThread.CurrentUICulture;
                    fecha = DateTime.ParseExact(sFecha, myFormato, provider).ToString(cFormato.ToString());
                }
            }
            else
            {
                fecha = string.Empty;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return fecha;
    }

    public static string Importe2Cultura(string sImporte)
    {
        string sImporteSalida = string.Empty;
        double importe = 0;

        try
        {
            if (sImporte != null && sImporte.Trim() != string.Empty)
            {
                importe = double.Parse(sImporte, System.Globalization.NumberStyles.Currency);
            }
        }
        catch (Exception e)
        {
            throw e;
        }

        if (importe == 0)
        {
            sImporteSalida = importe.ToString();
        }
        else
        {
            sImporteSalida = importe.ToString("N");
        }

        return sImporteSalida;
    }

    public static string Importe2Cultura3Decimales(string sImporte)
    {
        string sImporteSalida = string.Empty;
        double importe = 0;

        try
        {
            if (sImporte.Trim() != string.Empty && sImporte != null)
            {
                importe = double.Parse(sImporte, System.Globalization.NumberStyles.Currency);
            }
        }
        catch (Exception e)
        {
            throw e;
        }

        if (importe == 0)
        {
            sImporteSalida = importe.ToString();
        }
        else
        {
            sImporteSalida = importe.ToString("N3");
        }

        return sImporteSalida;
    }

    public static DateTime GetFecha(string sFecha)
    {
        return GetFecha(sFecha, Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
    }

    public static DateTime GetFecha(string sFecha, DateTimeFormatInfo oInfo)
    {

        DateTime dFecha = DateTime.MinValue;
        int iFecha = sFecha.Length;

        if (sFecha != String.Empty)
        {
            string sFormato = string.Empty;

            if (sFecha.IndexOf(oInfo.DateSeparator) >= 0)
            {
                iFecha = -1;
            }

            switch (iFecha)
            {
                case 8:
                    sFormato = "yyyyMMdd";
                    oInfo = DateTimeFormatInfo.InvariantInfo;
                    dFecha = DateTime.ParseExact(sFecha, sFormato, oInfo);
                    break;
                case 14:
                    sFormato = "yyyyMMdd HH:mm";
                    oInfo = DateTimeFormatInfo.InvariantInfo;
                    dFecha = DateTime.ParseExact(sFecha, sFormato, oInfo);
                    break;
                case 17:
                    sFormato = "yyyyMMdd HH:mm:ss";
                    oInfo = DateTimeFormatInfo.InvariantInfo;
                    dFecha = DateTime.ParseExact(sFecha, sFormato, oInfo);
                    break;
                default:
                    dFecha = DateTime.Parse(sFecha, oInfo);
                    break;
            }
        }
        return dFecha;

    }

    /// <summary>
    /// Obtiene un string a partir de una fecha
    /// </summary>
    /// <param name="dtFecha">Fecha</param>
    /// <returns>La fecha formateada o string vacío en caso de MinValue</returns>
    public static string GetFecha(DateTime dtFecha)
    {
        return GetFecha(dtFecha, TipoFecha.FormatoBaseDia, Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
    }

    /// <summary>
    /// Obtiene un string a partir de una fecha
    /// </summary>
    /// <param name="dtFecha">Fecha</param>
    /// <param name="enTipo">Tipo de formato de fecha a obtener</param>
    /// <returns>La fecha formateada o string vacío en caso de MinValue</returns>
    public static string GetFecha(DateTime dtFecha, TipoFecha enTipo)
    {
        return GetFecha(dtFecha, enTipo, Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
    }

    /// <summary>
    /// Obtiene un string a partir de una fecha
    /// </summary>
    /// <param name="dtFecha">Fecha</param>
    /// <param name="enTipo">Tipo de formato de fecha a obtener</param>
    /// <param name="oInfo">Format Info a utilizar</param>
    /// <returns>La fecha formateada o string vacío en caso de MinValue</returns>
    public static string GetFecha(DateTime dtFecha, TipoFecha enTipo, DateTimeFormatInfo oInfo)
    {
        string sRetorno = String.Empty;

        if (dtFecha != DateTime.MinValue)
        {
            switch (enTipo)
            {
                case TipoFecha.FormatoBaseDia:
                    sRetorno = dtFecha.ToString("yyyyMMdd");
                    break;
                case TipoFecha.FormatoBaseConMinutos:
                    sRetorno = dtFecha.ToString("yyyyMMdd HH:mm");
                    break;
                case TipoFecha.FormatoBaseConSegundos:
                    sRetorno = dtFecha.ToString("yyyyMMdd HH:mm:ss");
                    break;
                case TipoFecha.VisualizarFecha:
                    sRetorno = dtFecha.ToString(oInfo.ShortDatePattern);
                    break;
                case TipoFecha.VisualizarFechaHora:
                    sRetorno = dtFecha.ToString(oInfo.ShortDatePattern) + " " + dtFecha.ToString(oInfo.ShortTimePattern);
                    break;
            }
        }

        return sRetorno;

    }

}
