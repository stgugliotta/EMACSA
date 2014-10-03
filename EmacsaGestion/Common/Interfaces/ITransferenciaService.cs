using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad TransferenciaDataContracts(EMACSA_NUCLEO.dbo.TBL_Transferencia)
    /// </summary>
    public interface ITransferenciaService
    {
        /// <summary>
        /// Interface para retornar un objeto TransferenciaDataContracts
        /// </summary>
        /// <value>TransferenciaDataContracts</value>
        TransferenciaDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un TransferenciaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(TransferenciaDataContracts oTransferencia);

        /// <summary>
        /// Interface para actualiza un objeto TransferenciaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(TransferenciaDataContracts oTransferencia);

        /// <summary>
        /// Inteface para Insertar un objeto TransferenciaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(TransferenciaDataContracts oTransferencia);

        /// <summary>
        /// Interface para  rertornar objeto TransferenciaDataContracts
        /// </summary>
        /// <value>TransferenciaDataContracts</value>
        TransferenciaDataContracts GetTransferencia(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto TransferenciaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<TransferenciaDataContracts>]]></value>
        List<TransferenciaDataContracts> GetAllTransferencias();
    }
}
