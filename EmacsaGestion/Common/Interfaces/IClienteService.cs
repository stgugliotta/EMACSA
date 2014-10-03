using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ClienteDataContracts(EMACSA_NUCLEO.dbo.MTR_Cliente)
    /// </summary>
    public interface IClienteService
    {
        /// <summary>
        /// Interface para retornar un objeto ClienteDataContracts
        /// </summary>
        /// <value>ClienteDataContracts</value>
        ClienteDataContracts Load(decimal idCliente);

        /// <summary>
        /// interface para eliminar un ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ClienteDataContracts oCliente);

        /// <summary>
        /// Interface para actualiza un objeto ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ClienteDataContracts oCliente);

        /// <summary>
        /// Inteface para Insertar un objeto ClienteDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ClienteDataContracts oCliente);

        /// <summary>
        /// Interface para  rertornar objeto ClienteDataContracts
        /// </summary>
        /// <value>ClienteDataContracts</value>
        ClienteDataContracts GetCliente(decimal idCliente);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ClienteDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ClienteDataContracts>]]></value>
        List<ClienteDataContracts> GetAllClientes();

        
        /// <summary>
        /// Interface para  rertornar una lista de objeto ClienteDataContracts con interfaces definidas en Configuration.xml
        /// </summary>
        /// <value>ListList<![CDATA[<ClienteDataContracts>]]></value>
        List<ClienteDataContracts> GetClientesInterfaces();
        
        /// <summary>
        /// Interface para retornar un objeto ClienteDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ClienteDataContracts>]]></value>
        ClienteDataContracts GetClientePorDeudor(decimal idDeudor);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ClienteDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ClienteDataContracts>]]></value>
        List<ClienteDataContracts> GetAllClientesByAnalista(string analista);

    }
}
