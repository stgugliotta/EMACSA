using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad BancoDataContracts(EMACSA_NUCLEO.dbo.TBL_Banco)
    /// </summary>
    public interface IBancoService
    {
        /// <summary>
        /// Interface para retornar un objeto BancoDataContracts
        /// </summary>
        /// <value>BancoDataContracts</value>
        BancoDataContracts Load(int idBanco);

        /// <summary>
        /// interface para eliminar un BancoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(BancoDataContracts oBanco);

        /// <summary>
        /// Interface para actualiza un objeto BancoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(BancoDataContracts oBanco);

        /// <summary>
        /// Inteface para Insertar un objeto BancoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(BancoDataContracts oBanco);

        /// <summary>
        /// Interface para  rertornar objeto BancoDataContracts
        /// </summary>
        /// <value>BancoDataContracts</value>
        BancoDataContracts GetBanco(int idBanco);

        /// <summary>
        /// Interface para  rertornar una lista de objeto BancoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<BancoDataContracts>]]></value>
        List<BancoDataContracts> GetAllBancos();

        List<BancoDataContracts> GetAllBancosByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc);
        List<BancoDataContracts> GetAllBancosByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado);
    }
}
