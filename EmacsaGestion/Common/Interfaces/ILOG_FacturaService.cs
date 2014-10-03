using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad LOG_FacturaDataContracts(EMACSA_NUCLEO.dbo.LOG_Factura)
    /// </summary>
    public interface ILOG_FacturaService
    {
        /// <summary>
        /// Interface para retornar un objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>LOG_FacturaDataContracts</value>
        LOG_FacturaDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(LOG_FacturaDataContracts oLogFactura);

        /// <summary>
        /// Interface para actualiza un objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(LOG_FacturaDataContracts oLogFactura);

        /// <summary>
        /// Inteface para Insertar un objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(LOG_FacturaDataContracts oLogFactura);

        /// <summary>
        /// Interface para  rertornar objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>LOG_FacturaDataContracts</value>
        LOG_FacturaDataContracts GetLogFactura(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<LOG_FacturaDataContracts>]]></value>
        List<LOG_FacturaDataContracts> GetAllLogFacturas();

        /// <summary>
        /// Interface para  rertornar una lista de objeto LOG_FacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<LOG_FacturaDataContracts>]]></value>
        List<LOG_FacturaDataContracts> GetAllLogFacturasByIdFactura(int idFactura);
        
    }
}
