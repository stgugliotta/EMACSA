using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad EfectivoDataContracts(EMACSA_NUCLEO.dbo.TBL_Efectivo)
    /// </summary>
    public interface IEfectivoService
    {
        /// <summary>
        /// Interface para retornar un objeto EfectivoDataContracts
        /// </summary>
        /// <value>EfectivoDataContracts</value>
        EfectivoDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un EfectivoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(EfectivoDataContracts oEfectivo);

        /// <summary>
        /// Interface para actualiza un objeto EfectivoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(EfectivoDataContracts oEfectivo);

        /// <summary>
        /// Inteface para Insertar un objeto EfectivoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(EfectivoDataContracts oEfectivo);

        /// <summary>
        /// Interface para  rertornar objeto EfectivoDataContracts
        /// </summary>
        /// <value>EfectivoDataContracts</value>
        EfectivoDataContracts GetEfectivo(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto EfectivoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<EfectivoDataContracts>]]></value>
        List<EfectivoDataContracts> GetAllEfectivos();
    }
}
