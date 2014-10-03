using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DescuentoDataContracts(EMACSA_NUCLEO.dbo.TBL_Descuento)
    /// </summary>
    public interface IDescuentoService
    {
        /// <summary>
        /// Interface para retornar un objeto DescuentoDataContracts
        /// </summary>
        /// <value>DescuentoDataContracts</value>
        DescuentoDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un DescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(DescuentoDataContracts oDescuento);

        /// <summary>
        /// Interface para actualiza un objeto DescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(DescuentoDataContracts oDescuento);

        /// <summary>
        /// Inteface para Insertar un objeto DescuentoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(DescuentoDataContracts oDescuento);

        /// <summary>
        /// Interface para  rertornar objeto DescuentoDataContracts
        /// </summary>
        /// <value>DescuentoDataContracts</value>
        DescuentoDataContracts GetDescuento(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DescuentoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DescuentoDataContracts>]]></value>
        List<DescuentoDataContracts> GetAllDescuentos();
    }
}
