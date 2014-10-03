using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DiasDataContracts(EMACSA_NUCLEO.dbo.TBL_Dias)
    /// </summary>
    public interface IDiasService
    {
        /// <summary>
        /// Interface para retornar un objeto DiasDataContracts
        /// </summary>
        /// <value>DiasDataContracts</value>
        DiasDataContracts Load(int idDia);

        /// <summary>
        /// interface para eliminar un DiasDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(DiasDataContracts oDias);

        /// <summary>
        /// Interface para actualiza un objeto DiasDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(DiasDataContracts oDias);

        /// <summary>
        /// Inteface para Insertar un objeto DiasDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(DiasDataContracts oDias);

        /// <summary>
        /// Interface para  rertornar objeto DiasDataContracts
        /// </summary>
        /// <value>DiasDataContracts</value>
        DiasDataContracts GetDias(int idDia);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DiasDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DiasDataContracts>]]></value>
        List<DiasDataContracts> GetAllDiass();
    }
}
