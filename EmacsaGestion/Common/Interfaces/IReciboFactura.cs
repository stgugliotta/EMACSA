using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ReciboFacturaDataContracts(EMACSA_NUCLEO.dbo.TBL_Recibo_Factura)
    /// </summary>
    public interface IReciboFacturaService
    {
        /// <summary>
        /// Interface para retornar un objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>ReciboFacturaDataContracts</value>
        ReciboFacturaDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un ReciboFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ReciboFacturaDataContracts oReciboFactura);

        /// <summary>
        /// Interface para actualiza un objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ReciboFacturaDataContracts oReciboFactura);

        /// <summary>
        /// Inteface para Insertar un objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ReciboFacturaDataContracts oReciboFactura);

        /// <summary>
        /// Interface para  rertornar objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>ReciboFacturaDataContracts</value>
        ReciboFacturaDataContracts GetReciboFactura(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ReciboFacturaDataContracts>]]></value>
        List<ReciboFacturaDataContracts> GetAllReciboFacturas();

        /// <summary>
        /// Interface para  rertornar una lista de objeto ReciboFacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ReciboFacturaDataContracts>]]></value>
        List<ReciboFacturaDataContracts> GetAllReciboFacturasByIdRecibo(int idRecibo);
    }
}
