using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad PagoDataContracts(EMACSA_NUCLEO.dbo.TBL_Pago)
    /// </summary>
    public interface IPagoService
    {
        /// <summary>
        /// Interface para retornar un objeto PagoDataContracts
        /// </summary>
        /// <value>PagoDataContracts</value>
        PagoDataContracts Load(int idPago);

        /// <summary>
        /// interface para eliminar un PagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(PagoDataContracts oPago);

        /// <summary>
        /// Interface para actualiza un objeto PagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(PagoDataContracts oPago);

        /// <summary>
        /// Inteface para Insertar un objeto PagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(PagoDataContracts oPago);

        /// <summary>
        /// Interface para  rertornar objeto PagoDataContracts
        /// </summary>
        /// <value>PagoDataContracts</value>
        PagoDataContracts GetPago(int idPago);

        /// <summary>
        /// Interface para  rertornar una lista de objeto PagoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<PagoDataContracts>]]></value>
        List<PagoDataContracts> GetAllPagos();
    }

}
