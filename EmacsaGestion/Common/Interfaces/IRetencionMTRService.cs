using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad RetencionMTRDataContracts(EMACSA_NUCLEO.dbo.MTR_Retencion)
    /// </summary>
    public interface IRetencionMTRService
    {
        /// <summary>
        /// Interface para retornar un objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>RetencionMTRDataContracts</value>
        RetencionMTRDataContracts Load();

        /// <summary>
        /// interface para eliminar un RetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(RetencionMTRDataContracts oRetencionMTR);

        /// <summary>
        /// Interface para actualiza un objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(RetencionMTRDataContracts oRetencionMTR);

        /// <summary>
        /// Inteface para Insertar un objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(RetencionMTRDataContracts oRetencionMTR);

        /// <summary>
        /// Interface para  rertornar objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>RetencionMTRDataContracts</value>
        RetencionMTRDataContracts GetRetencionMTR();

        /// <summary>
        /// Interface para  rertornar una lista de objeto RetencionMTRDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<RetencionMTRDataContracts>]]></value>
        List<RetencionMTRDataContracts> GetAllRetencionMTRs();
    }
}
