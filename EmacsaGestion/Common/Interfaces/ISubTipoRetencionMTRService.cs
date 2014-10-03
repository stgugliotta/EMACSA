using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad SubTipoRetencionMTRDataContracts(EMACSA_NUCLEO.dbo.MTR_SubTipoRetencion)
    /// </summary>
    public interface ISubTipoRetencionMTRService
    {
        /// <summary>
        /// Interface para retornar un objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>SubTipoRetencionMTRDataContracts</value>
        SubTipoRetencionMTRDataContracts Load();

        /// <summary>
        /// interface para eliminar un SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(SubTipoRetencionMTRDataContracts oSubTipoRetencionMTR);

        /// <summary>
        /// Interface para actualiza un objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(SubTipoRetencionMTRDataContracts oSubTipoRetencionMTR);

        /// <summary>
        /// Inteface para Insertar un objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(SubTipoRetencionMTRDataContracts oSubTipoRetencionMTR);

        /// <summary>
        /// Interface para  rertornar objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>SubTipoRetencionMTRDataContracts</value>
        SubTipoRetencionMTRDataContracts GetSubTipoRetencionMTR();

        /// <summary>
        /// Interface para  rertornar una lista de objeto SubTipoRetencionMTRDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<SubTipoRetencionMTRDataContracts>]]></value>
        List<SubTipoRetencionMTRDataContracts> GetAllSubTipoRetencionMTRs();
    }
}
