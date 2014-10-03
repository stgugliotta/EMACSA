using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ReciboPagoDataContracts(EMACSA_NUCLEO.dbo.TBL_Recibo_Pago)
    /// </summary>
    public interface IReciboPagoService
    {
        /// <summary>
        /// Interface para retornar un objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>ReciboPagoDataContracts</value>
        ReciboPagoDataContracts Load(int idRecibo, int idPago);

        /// <summary>
        /// interface para eliminar un ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ReciboPagoDataContracts oReciboPago);

        /// <summary>
        /// Interface para actualiza un objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ReciboPagoDataContracts oReciboPago);

        /// <summary>
        /// Inteface para Insertar un objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ReciboPagoDataContracts oReciboPago);

        /// <summary>
        /// Interface para  rertornar objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>ReciboPagoDataContracts</value>
        ReciboPagoDataContracts GetReciboPago(int idRecibo, int idPago);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ReciboPagoDataContracts>]]></value>
        List<ReciboPagoDataContracts> GetAllReciboPagos();

        /// <summary>
        /// Interface para  rertornar una lista de objeto ReciboPagoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ReciboPagoDataContracts>]]></value>
        List<ReciboPagoDataContracts> GetAllReciboPagosByIdRecibo(int idRecibo);

    }
}
