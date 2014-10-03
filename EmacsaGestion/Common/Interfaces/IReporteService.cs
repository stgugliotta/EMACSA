using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ReporteDataContracts(EMACSA_NUCLEO.dbo.MTR_Reporte)
    /// </summary>
    public interface IReporteService
    {
        /// <summary>
        /// Interface para retornar un objeto ReporteDataContracts
        /// </summary>
        /// <value>ReporteDataContracts</value>
        ReporteDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un ReporteDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ReporteDataContracts oReporte);

        /// <summary>
        /// Interface para actualiza un objeto ReporteDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ReporteDataContracts oReporte);

        /// <summary>
        /// Inteface para Insertar un objeto ReporteDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ReporteDataContracts oReporte);

        /// <summary>
        /// Interface para  rertornar objeto ReporteDataContracts
        /// </summary>
        /// <value>ReporteDataContracts</value>
        ReporteDataContracts GetReporte(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ReporteDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ReporteDataContracts>]]></value>
        List<ReporteDataContracts> GetAllReportes();
    }
}
