using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad OtroPagoDataContracts(EMACSA_NUCLEO.dbo.TBL_OtroPago)
    /// </summary>
    public interface IOtroPagoService
    {
        /// <summary>
        /// Interface para retornar un objeto OtroPagoDataContracts
        /// </summary>
        /// <value>OtroPagoDataContracts</value>
        OtroPagoDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un OtroPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(OtroPagoDataContracts oOtroPago);

        /// <summary>
        /// Interface para actualiza un objeto OtroPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(OtroPagoDataContracts oOtroPago);

        /// <summary>
        /// Inteface para Insertar un objeto OtroPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(OtroPagoDataContracts oOtroPago);

        /// <summary>
        /// Interface para  rertornar objeto OtroPagoDataContracts
        /// </summary>
        /// <value>OtroPagoDataContracts</value>
        OtroPagoDataContracts GetOtroPago(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto OtroPagoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<OtroPagoDataContracts>]]></value>
        List<OtroPagoDataContracts> GetAllOtroPagos();
    }
}
