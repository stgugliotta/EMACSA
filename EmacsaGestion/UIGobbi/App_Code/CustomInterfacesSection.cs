using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

public class CustomInterfacesSection : ConfigurationSection
{
    // Create a "interfaz" element.
    [ConfigurationProperty("Interfaz")]
    public InterfazElement Interfaz
    {
        get {return (InterfazElement)this["Interfaz"];}
        set{ this["Interfaz"] = value; }
    }
}

public class InterfazElement : ConfigurationElement
{
    [ConfigurationProperty("idTipoRequerimiento", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoRequerimiento
    {
        get{return (String)this["idTipoRequerimiento"];}
        set{this["idTipoRequerimiento"] = value;}
    }

    [ConfigurationProperty("idTipoCYQComputables", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoCYQComputables
    {
        get {return (String)this["idTipoCYQComputables"];}
        set {this["idTipoCYQComputables"] = value;}
    }

    [ConfigurationProperty("idTipoCYQTotal", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoCYQTotal
    {
        get {return (String)this["idTipoCYQTotal"];}
        set {this["idTipoCYQTotal"] = value;}
    }

    [ConfigurationProperty("idTipoBloqueosBajas", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoBloqueosBajas
    {
        get {return (String)this["idTipoBloqueosBajas"];}
        set {this["idTipoBloqueosBajas"] = value;}
    }

    [ConfigurationProperty("idTipoJuiciosIniciados", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoJuiciosIniciados
    {
        get {return (String)this["idTipoJuiciosIniciados"];}
        set {this["idTipoJuiciosIniciados"] = value;}
    }

    [ConfigurationProperty("idTipoContingenciaServicios", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoContingenciaServicios
    {
        get {return (String)this["idTipoContingenciaServicios"];}
        set{this["idTipoContingenciaServicios"] = value;}
    }

    [ConfigurationProperty("idTipoMotivoBaja", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoMotivoBaja
    {
        get {return (String)this["idTipoMotivoBaja"];}
        set {this["idTipoMotivoBaja"] = value;}
    }

    [ConfigurationProperty("idTipoClienteR2", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoClienteR2
    {
        get {return (String)this["idTipoClienteR2"];}
        set{this["idTipoClienteR2"] = value;}
    }

    [ConfigurationProperty("idTipoInterfacesAutomaticas", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoInterfacesAutomaticas
    {
        get {return (String)this["idTipoInterfacesAutomaticas"];}
        set {this["idTipoInterfacesAutomaticas"] = value;}
    }

    [ConfigurationProperty("idTipoInterfacesCongeladas", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoInterfacesCongeladas
    {
        get {return (String)this["idTipoInterfacesCongeladas"];}
        set {this["idTipoInterfacesCongeladas"] = value;}
    }

    [ConfigurationProperty("idTipoEjecucionGes", DefaultValue = "0", IsRequired = true)]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public String IdTipoEjecucionGes
    {
        get {return (String)this["idTipoEjecucionGes"];}
        set {this["idTipoEjecucionGes"] = value;}
    }

    [ConfigurationProperty("nombreModulo", DefaultValue = "0", IsRequired = true)]
    public String NombreModulo
    {
        get {return (String)this["nombreModulo"];}
        set {this["nombreModulo"] = value;}
    }

    [ConfigurationProperty("nombreModuloCI", DefaultValue = "0", IsRequired = true)]
    public String NombreModuloCI
    {
        get {return (String)this["nombreModuloCI"];}
        set {this["nombreModuloCI"] = value;}
    }

    [ConfigurationProperty("nombreModuloIIBB", DefaultValue = "0", IsRequired = true)]
    public String NombreModuloIIBB
    {
        get {return (String)this["nombreModuloIIBB"];}
        set {this["nombreModuloIIBB"] = value;}
    }

    [ConfigurationProperty("nombreModuloGDC", DefaultValue = "0", IsRequired = true)]
    public String nombreModuloGDC
    {
        get {return (String)this["nombreModuloGDC"];}
        set {this["nombreModuloGDC"] = value;}
    }

    [ConfigurationProperty("idTipoEjecucionCI", DefaultValue = "0", IsRequired = true)]
    public String IdTipoEjecucionCI
    {
        get {return (String)this["idTipoEjecucionCI"];}
        set {this["idTipoEjecucionCI"] = value;}
    }

    [ConfigurationProperty("idTipoInterfacesCongeladasCarga", DefaultValue = "0", IsRequired = true)]
    public String IdTipoInterfacesCongeladasCarga
    {
        get {return (String)this["idTipoInterfacesCongeladasCarga"];}
        set {this["idTipoEjecucionCI"] = value;}
    }
    /*  Properties para CI
     *  ------------------
     *  
     *  Seccion Requerimientos
     * 				idTipoRequerimientoAccesoriedadCI="IS_Job403"
     * 				idTipoRequerimientoGesCI="170"
     * 				
     */

    [ConfigurationProperty("idTipoRequerimientoAccesoriedadCI", DefaultValue = "", IsRequired = true)]
    public String IdTipoRequerimientoAccesoriedadCI
    {
        get {return (String)this["idTipoRequerimientoAccesoriedadCI"];}
        set {this["idTipoRequerimientoAccesoriedadCI"] = value;}
    }

    [ConfigurationProperty("idTipoRequerimientoGesCI", DefaultValue = "", IsRequired = true)]
    public String IdTipoRequerimientoGesCI
    {
        get {return (String)this["idTipoRequerimientoGesCI"];}
        set {this["idTipoRequerimientoGesCI"] = value;}
    }

    [ConfigurationProperty("idTipoFacturasCpp", DefaultValue = "", IsRequired = true)]
    public String IdTipoFacturasCpp
    {
        get {return (String)this["idTipoFacturasCpp"];}
        set {this["idTipoFacturasCpp"] = value;}
    }

    [ConfigurationProperty("idTipoFacturasCobradas", DefaultValue = "", IsRequired = true)]
    public String IdTipoFacturasCobradas
    {
        get {return (String)this["idTipoFacturasCobradas"];}
        set {this["idTipoFacturasCobradas"] = value;}
    }

    //// idTipoMigracionTablasProceso
    [ConfigurationProperty("idTipoMigracionTablasProceso", DefaultValue = "", IsRequired = true)]
    public String IdTipoMigracionTablasProceso
    {
        get {return (String)this["idTipoMigracionTablasProceso"];}
        set {this["idTipoMigracionTablasProceso"] = value;}
    }

    //// idTipoInterfazMigracion
    [ConfigurationProperty("idTipoInterfazMigracion", DefaultValue = "", IsRequired = true)]
    public String IdTipoInterfazMigracion
    {
        get {return (String)this["idTipoInterfazMigracion"];}
        set {this["idTipoInterfazMigracion"] = value;}
    }

    [ConfigurationProperty("idTipoInterfazMigracionCI", DefaultValue = "", IsRequired = true)]
    public String IdTipoInterfazMigracionCI
    {
        get {return (String)this["idTipoInterfazMigracionCI"];}
        set {this["idTipoInterfazMigracionCI"] = value;}
    }


    [ConfigurationProperty("idTipoEjecucionIIBB", DefaultValue = "", IsRequired = true)]
    public String IdTipoEjecucionIIBB
    {
        get {return (String)this["idTipoEjecucionIIBB"];}
        set {this["idTipoEjecucionIIBB"] = value;}
    }

    [ConfigurationProperty("idTipoCorreccionDomicilios", DefaultValue = "", IsRequired = true)]
    public String IdTipoCorreccionDomicilios
    {
        get {return (String)this["idTipoCorreccionDomicilios"];}
        set {this["idTipoCorreccionDomicilios"] = value;}
    }

    [ConfigurationProperty("idTipoEjecucionGDC", DefaultValue = "", IsRequired = true)]
    public String IdTipoEjecucionGDC
    {
        get {return (String)this["idTipoEjecucionGDC"];}
        set {this["idTipoEjecucionGDC"] = value;}
    }

} // class 

public class CustomTiposInterfacesSection : ConfigurationSection
{
    // Create a "interfaz" element.
    [ConfigurationProperty("TiposInterfacesManuales")]
    public TiposInterfacesElement TiposInterfaz
    {
        get { return (TiposInterfacesElement)this["TiposInterfacesManuales"];}
        set{ this["TiposInterfacesManuales"] = value; }
    }
}

public class TiposInterfacesElement : ConfigurationElement
{
    [ConfigurationProperty("MascaraCYQCOMPUTABLES", DefaultValue = "0", IsRequired = false)]
    public String MascaraCYQCOMPUTABLES
    {
        get {return (String)this["MascaraCYQCOMPUTABLES"];}
        set {this["MascaraCYQCOMPUTABLES"] = value;}
    }

    [ConfigurationProperty("MascaraCYQ_EVA_HIS", DefaultValue = "0", IsRequired = false)]
    public String MascaraCYQ_EVA_HIS
    {
        get {return (String)this["MascaraCYQ_EVA_HIS"];}
        set {this["MascaraCYQ_EVA_HIS"] = value;}
    }

    [ConfigurationProperty("MascaraSURBLOQUEOSYBAJAS", DefaultValue = "0", IsRequired = false)]
    public String MascaraSURBLOQUEOSYBAJAS
    {
        get {return (String)this["MascaraSURBLOQUEOSYBAJAS"];}
        set {this["MascaraSURBLOQUEOSYBAJAS"] = value;}
    }

    [ConfigurationProperty("MascaraJUICIOSINICIADOS", DefaultValue = "0", IsRequired = false)]
    public String MascaraJUICIOSINICIADOS
    {
        get {return (String)this["MascaraJUICIOSINICIADOS"];}
        set {this["MascaraJUICIOSINICIADOS"] = value;}
    }

    [ConfigurationProperty("MascaraMAN_EVA_RE2", DefaultValue = "0", IsRequired = false)]
    public String MascaraMAN_EVA_RE2
    {
        get {return (String)this["MascaraMAN_EVA_RE2"];}
        set {this["MascaraMAN_EVA_RE2"] = value;}
    }

    [ConfigurationProperty("MascaraFACTURASCOBRADAS", DefaultValue = "0", IsRequired = false)]
    public String MascaraFACTURASCOBRADAS
    {
        get {return (String)this["MascaraFACTURASCOBRADAS"];}
        set {this["MascaraFACTURASCOBRADAS"] = value;}
    }

    [ConfigurationProperty("MascaraFACTURASCPP", DefaultValue = "0", IsRequired = false)]
    public String MascaraFACTURASCPP
    {
        get { return (String)this["MascaraFACTURASCPP"];}
        set {this["MascaraFACTURASCPP"] = value;}
    }

    [ConfigurationProperty("MascaraCORRECCIONDOMICILIO", DefaultValue = "0", IsRequired = false)]
    public String MascaraCORRECCIONDOMICILIO
    {
        get {return (String)this["MascaraCORRECCIONDOMICILIO"];}
        set {this["MascaraCORRECCIONDOMICILIO"] = value;}
    }


} // class 

public class CustomArchivosInterfacesSection : ConfigurationSection
{
    // Create a "interfaz" element.
    [ConfigurationProperty("directoriosInterfaces")]
    public ArchivosInterfacesElement DirectoriosInterfaces
    {
        get {return (ArchivosInterfacesElement)this["directoriosInterfaces"];}
        set { this["directoriosInterfaces"] = value; }
    }


} // class CustomArchivosInterfacesSection

public class ArchivosInterfacesElement : ConfigurationElement
{
    [ConfigurationProperty("CarpetaDestino", DefaultValue = "0", IsRequired = false)]
    public String CarpetaDestino
    {
        get {return (String)this["CarpetaDestino"];}
        set {this["CarpetaDestino"] = value;}
    }

    [ConfigurationProperty("CarpetaDestinoCI", DefaultValue = "0", IsRequired = false)]
    public String CarpetaDestinoCI
    {
        get {return (String)this["CarpetaDestinoCI"];}
        set {this["CarpetaDestinoCI"] = value;}
    }

} // class 

public class CustomReportGesSection : ConfigurationSection
{
    // Create a "interfaz" element.
    [ConfigurationProperty("Report")]
    public ReportElement Report
    {
        get {return (ReportElement)this["Report"];}
        set { this["Interfaz"] = value; }
    }
}

public class ReportElement : ConfigurationElement
{

    [ConfigurationProperty("ReporteGESInconsistenciasxAcuerdo", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESInconsistenciasxAcuerdo
    {
        get {return (String)this["ReporteGESInconsistenciasxAcuerdo"]; }
        set {this["ReporteGESInconsistenciasxAcuerdo"] = value;}
    }

    [ConfigurationProperty("ReporteGESInconsistenciasxTramiteDeimos", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESInconsistenciasxTramiteDeimos
    {
        get {return (String)this["ReporteGESInconsistenciasxTramiteDeimos"];}
        set {this["ReporteGESInconsistenciasxTramiteDeimos"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoConvenioxAcuerdo", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoConvenioxAcuerdo
    {
        get {return (String)this["ReporteGESResultadoConvenioxAcuerdo"];}
        set {this["ReporteGESResultadoConvenioxAcuerdo"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoConvenioxCliente", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoConvenioxCliente
    {
        get {return (String)this["ReporteGESResultadoConvenioxCliente"];}
        set {this["ReporteGESResultadoConvenioxCliente"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoConvenioxClienteUnificado", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoConvenioxClienteUnificado
    {
        get {return (String)this["ReporteGESResultadoConvenioxClienteUnificado"];}
        set {this["ReporteGESResultadoConvenioxClienteUnificado"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoConvenioxConvenio", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoConvenioxConvenio
    {
        get {return (String)this["ReporteGESResultadoConvenioxConvenio"];}
        set {this["ReporteGESResultadoConvenioxConvenio"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoCyQxAcuerdo", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoCyQxAcuerdo
    {
        get {return (String)this["ReporteGESResultadoCyQxAcuerdo"];}
        set {this["ReporteGESResultadoCyQxAcuerdo"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoCyQxCliente", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoCyQxCliente
    {
        get {return (String)this["ReporteGESResultadoCyQxCliente"];}
        set {this["ReporteGESResultadoCyQxCliente"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoCyQxClienteUnificado", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoCyQxClienteUnificado
    {
        get {return (String)this["ReporteGESResultadoCyQxClienteUnificado"];}
        set {this["ReporteGESResultadoCyQxClienteUnificado"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoCyQxTramiteCyQ", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoCyQxTramiteCyQ
    {
        get {return (String)this["ReporteGESResultadoCyQxTramiteCyQ"];}
        set {this["ReporteGESResultadoCyQxTramiteCyQ"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoFacturaxAcuerdo", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoFacturaxAcuerdo
    {
        get {return (String)this["ReporteGESResultadoFacturaxAcuerdo"];}
        set {this["ReporteGESResultadoFacturaxAcuerdo"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoFacturaxCliente", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoFacturaxCliente
    {
        get {return (String)this["ReporteGESResultadoFacturaxCliente"];}
        set {this["ReporteGESResultadoFacturaxCliente"] = value;}
    }

    [ConfigurationProperty("ReporteGESResultadoFacturaxClienteUnificado", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESResultadoFacturaxClienteUnificado
    {
        get {return (String)this["ReporteGESResultadoFacturaxClienteUnificado"];}
        set {this["ReporteGESResultadoFacturaxClienteUnificado"] = value;}
    }

    [ConfigurationProperty("ReporteGESInconsistenciasxCliente", DefaultValue = "0", IsRequired = false)]
    public String ReporteGESInconsistenciasxCliente
    {
        get {return (String)this["ReporteGESInconsistenciasxCliente"]; }
        set {this["ReporteGESInconsistenciasxCliente"] = value; }
    }

} // class 

public class ReportConfiguration : ConfigurationSection
{

    public static ReportConfiguration GetConfig()
    {
        return ConfigurationSettings.GetConfig("ReportsConfiguration") as ReportConfiguration; // Config File attribute
    }

    [ConfigurationProperty("namePath", DefaultValue = "", IsRequired = false)]
    public string NamePath
    {
        get
        {
            return this["namePath"] as string;
        }
    }

    [ConfigurationProperty("valuePath", IsRequired = true)]
    public string ValuePath
    {
        get
        {
            return (string)this["valuePath"];
        }
    }

    [ConfigurationProperty("finalString", IsRequired = true)]
    public string FinalString
    {
        get
        {
            return (string)this["finalString"];
        }
    }


    [ConfigurationProperty("reports")]
    public ReportsCollection Reports
    {
        get
        {
            return this["Reports"] as ReportsCollection;
        }
    }
}

public class ReportItem : ConfigurationElement
{
    [ConfigurationProperty("nameReport", IsRequired = true)]
    public string Name
    {
        get
        {
            return this["nameReport"] as string;
        }
    }

    [ConfigurationProperty("reportFile", IsRequired = false)]
    public string ReportFile
    {
        get
        {
            return this["reportFile"] as string;
        }
    }
}

public class ReportsCollection : ConfigurationElementCollection
{
    public ReportItem this[int index]
    {
        get
        {
            return base.BaseGet(index) as ReportItem;
        }
        set
        {
            if (base.BaseGet(index) != null)
            {
                base.BaseRemoveAt(index);
            }
            this.BaseAdd(index, value);
        }
    }

    protected override ConfigurationElement CreateNewElement()
    {
        return new ReportItem();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
        return ((ReportItem)element).Name;
    }
}

public class ASPNET2Configuration : ConfigurationSection
{

    public static ASPNET2Configuration GetConfig()
    {
        return ConfigurationSettings.GetConfig("aspnet2CIReportConfiguration") as ASPNET2Configuration;
    }

    [ConfigurationProperty("finalPath", DefaultValue = "", IsRequired = false)]
    public string FinalPath
    {
        get
        {
            return this["finalPath"] as string;
        }
    }

    [ConfigurationProperty("valuePath", IsRequired = true)]
    public string ValuePath
    {
        get
        {
            return (string)this["valuePath"];
        }
    }

    [ConfigurationProperty("valuePathLog", IsRequired = true)]
    public string ValuePathLog
    {
        get
        {
            return (string)this["valuePathLog"];
        }
    }

    [ConfigurationProperty("ValueToolBar", IsRequired = true)]
    public string ValueToolBar
    {
        get
        {
            return (string)this["ValueToolBar"];
        }
    }

    [ConfigurationProperty("finalPathLog", DefaultValue = "", IsRequired = false)]
    public string FinalPathLog
    {
        get
        {
            return this["finalPathLog"] as string;
        }
    }


    [ConfigurationProperty("reports")]
    public ASPNET2ConfigurationStateCollection Reports
    {
        get
        {
            return this["reports"] as ASPNET2ConfigurationStateCollection;
        }
    }
}

public class ASPNET2CIConfiguration : ConfigurationSection
{

    public static ASPNET2CIConfiguration GetConfig()
    {
        return ConfigurationSettings.GetConfig("aspnet2ReportConfiguration") as ASPNET2CIConfiguration;
    }

    [ConfigurationProperty("finalPath", DefaultValue = "", IsRequired = false)]
    public string FinalPath
    {
        get
        {
            return this["finalPath"] as string;
        }
    }

    [ConfigurationProperty("valuePath", IsRequired = true)]
    public string ValuePath
    {
        get
        {
            return (string)this["valuePath"];
        }
    }

    [ConfigurationProperty("valuePathLog", IsRequired = true)]
    public string ValuePathLog
    {
        get
        {
            return (string)this["valuePathLog"];
        }
    }

    [ConfigurationProperty("finalPathLog", DefaultValue = "", IsRequired = false)]
    public string FinalPathLog
    {
        get
        {
            return this["finalPathLog"] as string;
        }
    }

    [ConfigurationProperty("reports")]
    public ASPNET2ConfigurationStateCollection Reports
    {
        get
        {
            return this["reports"] as ASPNET2ConfigurationStateCollection;
        }
    }
}

public class ASPNET2IIBBConfiguration : ConfigurationSection
{

    public static ASPNET2CIConfiguration GetConfig()
    {
        return ConfigurationSettings.GetConfig("aspnet2ReportConfiguration") as ASPNET2CIConfiguration;
    }

    [ConfigurationProperty("finalPath", DefaultValue = "", IsRequired = false)]
    public string FinalPath
    {
        get
        {
            return this["finalPath"] as string;
        }
    }

    [ConfigurationProperty("valuePath", IsRequired = true)]
    public string ValuePath
    {
        get
        {
            return (string)this["valuePath"];
        }
    }

    [ConfigurationProperty("valuePathLog", IsRequired = true)]
    public string ValuePathLog
    {
        get
        {
            return (string)this["valuePathLog"];
        }
    }

    [ConfigurationProperty("finalPathLog", DefaultValue = "", IsRequired = false)]
    public string FinalPathLog
    {
        get
        {
            return this["finalPathLog"] as string;
        }
    }

    [ConfigurationProperty("reports")]
    public ASPNET2ConfigurationStateCollection Reports
    {
        get
        {
            return this["reports"] as ASPNET2ConfigurationStateCollection;
        }
    }
}

public class ASPNET2GDCConfiguration : ConfigurationSection
{

    public static ASPNET2GDCConfiguration GetConfig()
    {
        return ConfigurationSettings.GetConfig("aspnet2ReportConfiguration") as ASPNET2GDCConfiguration;
    }

    [ConfigurationProperty("finalPath", DefaultValue = "", IsRequired = false)]
    public string FinalPath
    {
        get
        {
            return this["finalPath"] as string;
        }
    }

    [ConfigurationProperty("valuePath", IsRequired = true)]
    public string ValuePath
    {
        get
        {
            return (string)this["valuePath"];
        }
    }

    [ConfigurationProperty("valuePathLog", IsRequired = true)]
    public string ValuePathLog
    {
        get
        {
            return (string)this["valuePathLog"];
        }
    }

    [ConfigurationProperty("finalPathLog", DefaultValue = "", IsRequired = false)]
    public string FinalPathLog
    {
        get
        {
            return this["finalPathLog"] as string;
        }
    }

    [ConfigurationProperty("reports")]
    public ASPNET2ConfigurationStateCollection Reports
    {
        get
        {
            return this["reports"] as ASPNET2ConfigurationStateCollection;
        }
    }
}

public class ASPNET2ConfigurationState : ConfigurationElement
{
    [ConfigurationProperty("name", IsRequired = true)]
    public string Name
    {
        get
        {
            return this["name"] as string;
        }
    }

    [ConfigurationProperty("nombreFile", IsRequired = false)]
    public string NombreFile
    {
        get
        {
            return this["nombreFile"] as string;
        }
    }
}

public class ASPNET2ConfigurationStateCollection : ConfigurationElementCollection
{
    public ASPNET2ConfigurationState this[int index]
    {
        get
        {
            return base.BaseGet(index) as ASPNET2ConfigurationState;
        }
        set
        {
            if (base.BaseGet(index) != null)
            {
                base.BaseRemoveAt(index);
            }
            this.BaseAdd(index, value);
        }
    }

    protected override ConfigurationElement CreateNewElement()
    {
        return new ASPNET2ConfigurationState();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
        return ((ASPNET2ConfigurationState)element).Name;
    }
}