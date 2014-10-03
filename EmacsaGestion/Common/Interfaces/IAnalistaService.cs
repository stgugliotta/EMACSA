using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad AnalistaDataContracts(EMACSA_NUCLEO.dbo.MTR_Analista)
    /// </summary>
    public interface IAnalistaService
    {
        /// <summary>
        /// Interface para retornar un objeto AnalistaDataContracts
        /// </summary>
        /// <value>AnalistaDataContracts</value>
        AnalistaDataContracts Load();

        /// <summary>
        /// interface para eliminar un AnalistaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(AnalistaDataContracts oAnalista);

        /// <summary>
        /// Interface para actualiza un objeto AnalistaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(AnalistaDataContracts oAnalista);

        /// <summary>
        /// Inteface para Insertar un objeto AnalistaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(AnalistaDataContracts oAnalista);

        /// <summary>
        /// Interface para  rertornar objeto AnalistaDataContracts
        /// </summary>
        /// <value>AnalistaDataContracts</value>
        AnalistaDataContracts GetAnalista();

        /// <summary>
        /// Interface para  rertornar una lista de objeto AnalistaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<AnalistaDataContracts>]]></value>
        List<AnalistaDataContracts> GetAllAnalistas();
    }
}
