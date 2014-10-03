using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad RemisionDescuentoDataContracts(EMACSA_NUCLEO.dbo.TBL_Remision_Descuento)
    /// </summary>
    public interface IRemisionDescuentoService
    {
        /// <summary>
        /// Interface para retornar un objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>RemisionDescuentoDataContracts</value>
        RemisionDescuentoDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un RemisionDescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(RemisionDescuentoDataContracts oRemisionDescuento);

        /// <summary>
        /// Interface para actualiza un objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(RemisionDescuentoDataContracts oRemisionDescuento);

        /// <summary>
        /// Inteface para Insertar un objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(RemisionDescuentoDataContracts oRemisionDescuento);

        /// <summary>
        /// Interface para  rertornar objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>RemisionDescuentoDataContracts</value>
        RemisionDescuentoDataContracts GetRemisionDescuento(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto RemisionDescuentoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<RemisionDescuentoDataContracts>]]></value>
        List<RemisionDescuentoDataContracts> GetAllRemisionDescuentos();
    }
}
