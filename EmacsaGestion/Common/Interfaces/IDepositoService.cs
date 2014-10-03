using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DepositoDataContracts(EMACSA_NUCLEO.dbo.TBL_Deposito)
    /// </summary>
    public interface IDepositoService
    {
        /// <summary>
        /// Interface para retornar un objeto DepositoDataContracts
        /// </summary>
        /// <value>DepositoDataContracts</value>
        DepositoDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un DepositoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(DepositoDataContracts oDeposito);

        /// <summary>
        /// Interface para actualiza un objeto DepositoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(DepositoDataContracts oDeposito);

        /// <summary>
        /// Inteface para Insertar un objeto DepositoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(DepositoDataContracts oDeposito);

        /// <summary>
        /// Interface para  rertornar objeto DepositoDataContracts
        /// </summary>
        /// <value>DepositoDataContracts</value>
        DepositoDataContracts GetDeposito(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DepositoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DepositoDataContracts>]]></value>
        List<DepositoDataContracts> GetAllDepositos();
    }
}
