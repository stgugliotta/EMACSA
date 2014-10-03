using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad FacturaDataContracts(EMACSA_NUCLEO.dbo.MTR_Factura)
    /// </summary>
    public interface IFacturaHistorialDeudorService
    {
        /// <summary>
        /// Interface para retornar un objeto FacturaDataContracts
        /// </summary>
        /// <value>FacturaDataContracts</value>
        FacturaHistorialDeudorDataContracts Load(int idFactura);

        /// <summary>
        /// interface para eliminar un FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(FacturaHistorialDeudorDataContracts oFactura);

        /// <summary>
        /// Interface para actualiza un objeto FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(FacturaHistorialDeudorDataContracts oFactura);

        /// <summary>
        /// Inteface para Insertar un objeto FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(FacturaHistorialDeudorDataContracts oFactura);

        /// <summary>
        /// Interface para  rertornar objeto FacturaDataContracts
        /// </summary>
        /// <value>FacturaDataContracts</value>
        FacturaHistorialDeudorDataContracts GetFactura(int idFactura);

        /// <summary>
        /// Interface para  rertornar una lista de objeto FacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<FacturaDataContracts>]]></value>
        List<FacturaHistorialDeudorDataContracts> GetAllFacturas();
        /// <summary>
        /// Interface para  rertornar una lista de objeto FacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<FacturaDataContracts>]]></value>
        List<FacturaHistorialDeudorDataContracts> GetAllFacturasByCriteria(FacturaHistorialDeudorDataContracts oFactura);

        /// <summary>
        /// Interface para  rertornar una lista de objeto FacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<FacturaDataContracts>]]></value>
        List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdDeudor(int idDeudor);

        List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorVariosIdDeudor(string idDeudores);

        List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdDeudorSinFiltroDeEstado(int idDeudor);


        /// <summary>
        /// Interface para retornar una lista de objeto FacturaDataContracts.
        /// </summary>
        /// <param name="idCliente">Identificador del cliente.</param>
        /// <param name="idDeudor">Identificador del Deudor.</param>
        /// <returns>Lista de objetos FacturaDataContracts</returns>
        List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdClienteyIdDeudor(int idCliente, int idDeudor);

        List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdClienteyIdDeudorACobrar(int idCliente, int idDeudor, DateTime fechaProximaGestion);

        List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdDeudorEntreFechas(int idDeudor, DateTime fechaDesde, DateTime fechaHasta);

        List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdClienteEntreFechas(int idCliente, DateTime fechaDesde, DateTime fechaHasta);

        List<FacturaHistorialDeudorDataContracts> GetAllFacturasPorIdClienteyIdDeudorIdEstado(int idCliente, int idDeudor, int idEstado);

        List<DeudorHojaDeRutaDataContracts> getHojaDeRuta(DateTime fechaProximaGestion);
    }
}
