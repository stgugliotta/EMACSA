using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ConfigurationDataContracts(GOBBI_NUCLEO.dbo.INT_Factura)
    /// </summary>
    public interface IInterfazFacturaService
    {
        /// <summary>
        /// Interface para retornar un objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>InterfazFacturaDataContracts</value>
        InterfazFacturaDataContracts Load(short idInterfazFactura);

        /// <summary>
        /// interface para eliminar un InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(InterfazFacturaDataContracts oInterfazFactura);

        /// <summary>
        /// Interface para actualiza un objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(InterfazFacturaDataContracts oInterfazFactura);

        /// <summary>
        /// Inteface para Insertar un objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(InterfazFacturaDataContracts oInterfazFactura);

        void InsertPreview(InterfazFacturaDataContracts oInterfazFactura);

        void TruncateTablePreview();

        void DeleteLastImport(int idCliente);

        void DeleteLastImportPreview(int idCliente);
        /// <summary>
        /// Interface para  rertornar objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>InterfazFacturaDataContracts</value>
        InterfazFacturaDataContracts GetInterfazFactura(short idInterfazFactura);

        /// <summary>
        /// Interface para  rertornar una lista de objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<InterfazFacturaDataContracts>]]></value>
        List<InterfazFacturaDataContracts> GetAllInterfazFacturas();

        /// <summary>
        /// Interface para  rertornar una lista de objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<InterfazFacturaDataContracts>]]></value>
        List<InterfazFacturaDataContracts> GetAllInterfazFacturasByCliente(int idCliente);
        List<InterfazFacturaDataContracts> GetAllInterfazFacturasByClienteFechaProceso(int idCliente, DateTime fechaProceso);
        List<InterfazFacturaDataContracts> GetAllInterfazFacturasByClienteFechaProcesoPreview(int idCliente, DateTime fechaProceso);
        
        /// <summary>
        /// Interface para  rertornar una lista de objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<InterfazFacturaDataContracts>]]></value>
        List<ImportacionFacturaDataContracts> ProcessInterfazFacturasByCliente(int idCliente, string idUsuario);
        
        List<ImportacionFacturaDataContracts> ProcessInterfazFacturasByClientePreview(int idCliente, string idUsuario);
 
        /// <summary>
        /// Interface para  rertornar una lista de objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<InterfazFacturaDataContracts>]]></value>
        List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturas();


        List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFecha(DateTime fecha);
        List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFechaPreview(DateTime fecha);
        List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFechaPreview(int idCliente, DateTime fecha);
        /// <summary>
        /// Interface para  rertornar una lista de objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<InterfazFacturaDataContracts>]]></value>
        List<InterfazFacturaDataContracts> GetAllFacturasBajaPorInterfazByCliente(int idCliente);
        List<InterfazFacturaDataContracts> GetAllFacturasBajaPorInterfazByClienteFechaProceso(int idCliente,DateTime fechaProceso);
        List<InterfazFacturaDataContracts> GetAllFacturasBajaPorInterfazByClienteFechaProcesoPreview(int idCliente, DateTime fechaProceso);

        
        



        
    }
}
