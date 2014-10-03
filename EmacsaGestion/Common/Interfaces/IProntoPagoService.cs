using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ProntoPagoDataContracts(EMACSA_NUCLEO.dbo.CFG_Pronto_Pago)
    /// </summary>
    public interface IProntoPagoService
    {
        /// <summary>
        /// Interface para retornar un objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>ProntoPagoDataContracts</value>
        ProntoPagoDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ProntoPagoDataContracts oProntoPago);

        /// <summary>
        /// Interface para eliminar un ProntoPago por ID
        /// </summary>
        /// <param name="id"></param>
        void EliminarPorId(int id);

        /// <summary>
        /// Interface para actualiza un objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ProntoPagoDataContracts oProntoPago);

        /// <summary>
        /// Inteface para Insertar un objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ProntoPagoDataContracts oProntoPago);

        /// <summary>
        /// Interface para  rertornar objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>ProntoPagoDataContracts</value>
        ProntoPagoDataContracts GetProntoPago(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ProntoPagoDataContracts>]]></value>
        List<ProntoPagoDataContracts> GetAllProntoPagos();


        /// <summary>
        /// Interface para  rertornar una lista de objeto ProntoPagoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ProntoPagoDataContracts>]]></value>
        List<ProntoPagoDataContracts> GetAllProntoPagosByIdClienteYIdDeudor(int idCliente, int idDeudor);

        /// <summary>
        /// Interface para retornar una lista de objeto ProntoPagoDataContracts.
        /// </summary>
        /// <param name="idCliente">Identificador de Cliente.</param>
        /// <returns></returns>
        List<ProntoPagoDataContracts> GetAllProntoPagosByIdCliente(int idCliente);

    }
}
