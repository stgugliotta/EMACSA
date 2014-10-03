using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ControlRemisionConcurrenciaDataContracts(EMACSA_NUCLEO.dbo.TBL_Control_Concurrencia_Remision)
    /// </summary>
    public interface IControlRemisionConcurrenciaService
    {
        /// <summary>
        /// Interface para retornar un objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>ControlRemisionConcurrenciaDataContracts</value>
        ControlRemisionConcurrenciaDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ControlRemisionConcurrenciaDataContracts oControlRemisionConcurrencia);

        /// <summary>
        /// Interface para actualiza un objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ControlRemisionConcurrenciaDataContracts oControlRemisionConcurrencia);

        /// <summary>
        /// Inteface para Insertar un objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ControlRemisionConcurrenciaDataContracts oControlRemisionConcurrencia);


        string InsertWithResult(ControlRemisionConcurrenciaDataContracts oControlRemisionConcurrencia);

        /// <summary>
        /// Interface para  rertornar objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>ControlRemisionConcurrenciaDataContracts</value>
        ControlRemisionConcurrenciaDataContracts GetControlRemisionConcurrencia(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ControlRemisionConcurrenciaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ControlRemisionConcurrenciaDataContracts>]]></value>
        List<ControlRemisionConcurrenciaDataContracts> GetAllControlRemisionConcurrencias();
    }
}
