using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ClienteCuentaDataContracts(EMACSA_NUCLEO.dbo.TBL_Cliente_Cuenta)
    /// </summary>
    public interface IClienteCuentaService
    {
        /// <summary>
        /// Interface para retornar un objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>ClienteCuentaDataContracts</value>
        ClienteCuentaDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ClienteCuentaDataContracts oClienteCuenta);

        /// <summary>
        /// Interface para actualiza un objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ClienteCuentaDataContracts oClienteCuenta);

        /// <summary>
        /// Inteface para Insertar un objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ClienteCuentaDataContracts oClienteCuenta);

        /// <summary>
        /// Interface para  rertornar objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>ClienteCuentaDataContracts</value>
        ClienteCuentaDataContracts GetClienteCuenta(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ClienteCuentaDataContracts>]]></value>
        List<ClienteCuentaDataContracts> GetAllClienteCuentas();

        /// <summary>
        /// Interface para  rertornar una lista de objeto ClienteCuentaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ClienteCuentaDataContracts>]]></value>
        List<ClienteCuentaDataContracts> GetAllClienteCuentasByIdCliente(int idCliente);

    }
}
