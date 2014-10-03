using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad FacturaDataContracts(EMACSA_NUCLEO.dbo.MTR_Factura)
    /// </summary>
    public interface IFacturaService
    {
        /// <summary>
        /// Interface para retornar un objeto FacturaDataContracts
        /// </summary>
        /// <value>FacturaDataContracts</value>
        FacturaDataContracts Load(int idFactura);

        /// <summary>
        /// interface para eliminar un FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(FacturaDataContracts oFactura);

        /// <summary>
        /// Interface para actualiza un objeto FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(FacturaDataContracts oFactura);

        /// <summary>
        /// Inteface para Insertar un objeto FacturaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(FacturaDataContracts oFactura);

        /// <summary>
        /// Interface para  rertornar objeto FacturaDataContracts
        /// </summary>
        /// <value>FacturaDataContracts</value>
        FacturaDataContracts GetFactura(int idFactura);

        /// <summary>
        /// Interface para  rertornar una lista de objeto FacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<FacturaDataContracts>]]></value>
        List<FacturaDataContracts> GetAllFacturas();
        /// <summary>
        /// Interface para  rertornar una lista de objeto FacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<FacturaDataContracts>]]></value>
        List<FacturaDataContracts> GetAllFacturasByCriteria(FacturaDataContracts oFactura);

        List<FacturaDataContracts> GetAllFacturasByCriteriaTodosLosEstados(FacturaDataContracts oFactura);
        
        /// <summary>
        /// Interface para  rertornar una lista de objeto FacturaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<FacturaDataContracts>]]></value>
        List<FacturaDataContracts> GetAllFacturasPorIdDeudor(int idDeudor);
        List<FacturaDataContracts> GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(int idDeudor);
        

        List<FacturaDataContracts> GetDataTableFacturasPorDeudorQueNoEstenEnNingunRecibo(int idDeudor);
        List<FacturaDataContracts> GetAllFacturasPorIdDeudorProximaGestion(int idDeudor);

        List<FacturaDataContracts> GetAllFacturasPorVariosIdDeudor(string idDeudores);

        List<FacturaDataContracts> GetAllFacturasPorIdDeudorSinFiltroDeEstado(int idDeudor);
        List<FacturaDataContracts> GetDataTableFacturasPorDeudorPosiblesDeEdicion(int idDeudor, string numRecibo);
        

        List<FacturaDataContracts> GetAllFacturasByNumeroCompleto(FacturaDataContracts oFactura);

        /// <summary>
        /// Interface para retornar una lista de objeto FacturaDataContracts.
        /// </summary>
        /// <param name="idCliente">Identificador del cliente.</param>
        /// <param name="idDeudor">Identificador del Deudor.</param>
        /// <returns>Lista de objetos FacturaDataContracts</returns>
        List<FacturaDataContracts> GetAllFacturasPorIdClienteyIdDeudor(int idCliente, int idDeudor);
        List<FacturaDataContracts> GetAllFacturasPorIdClienteyIdDeudorParaEstadoDeCuenta(int idCliente, int idDeudor);

        List<FacturaDataContracts> GetAllFacturasPorIdClienteyIdDeudorACobrar(int idCliente, int idDeudor, DateTime fechaProximaGestion);

        List<FacturaDataContracts> GetAllFacturasPorIdDeudorEntreFechas(int idDeudor, DateTime fechaDesde, DateTime fechaHasta);

        List<FacturaDataContracts> GetAllFacturasPorIdClienteEntreFechas(int idCliente, DateTime fechaDesde, DateTime fechaHasta);

        List<FacturaDataContracts> GetAllFacturasPorIdClienteyIdDeudorIdEstado(int idCliente, int idDeudor, int idEstado);

        List<DeudorHojaDeRutaDataContracts> getHojaDeRuta(DateTime fechaProximaGestion);
    }
}
