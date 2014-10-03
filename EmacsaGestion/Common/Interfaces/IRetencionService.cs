using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad RetencionDataContracts(EMACSA_NUCLEO.dbo.TBL_Retencion)
    /// </summary>
    public interface IRetencionService
    {
        /// <summary>
        /// Interface para retornar un objeto RetencionDataContracts
        /// </summary>
        /// <value>RetencionDataContracts</value>
        RetencionDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un RetencionDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(RetencionDataContracts oRetencion);

        /// <summary>
        /// Interface para actualiza un objeto RetencionDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(RetencionDataContracts oRetencion);

        /// <summary>
        /// Inteface para Insertar un objeto RetencionDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(RetencionDataContracts oRetencion);

        /// <summary>
        /// Interface para  rertornar objeto RetencionDataContracts
        /// </summary>
        /// <value>RetencionDataContracts</value>
        RetencionDataContracts GetRetencion(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto RetencionDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<RetencionDataContracts>]]></value>
        List<RetencionDataContracts> GetAllRetencions();
    }
}
