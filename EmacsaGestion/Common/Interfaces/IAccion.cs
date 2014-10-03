using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad AccionDataContracts(EMACSA_NUCLEO.dbo.TBL_Accion)
    /// </summary>
    public interface IAccionService
    {
        /// <summary>
        /// Interface para retornar un objeto AccionDataContracts
        /// </summary>
        /// <value>AccionDataContracts</value>
        AccionDataContracts Load(int idAccion);

        /// <summary>
        /// interface para eliminar un AccionDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(AccionDataContracts oAccion);

        /// <summary>
        /// Interface para actualiza un objeto AccionDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(AccionDataContracts oAccion);

        /// <summary>
        /// Inteface para Insertar un objeto AccionDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(AccionDataContracts oAccion);

        /// <summary>
        /// Interface para  rertornar objeto AccionDataContracts
        /// </summary>
        /// <value>AccionDataContracts</value>
        AccionDataContracts GetAccion(int idAccion);

        /// <summary>
        /// Interface para  rertornar una lista de objeto AccionDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<AccionDataContracts>]]></value>
        List<AccionDataContracts> GetAllAccions();

        List<AccionDataContracts> GetAllAccionsByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc);
        List<AccionDataContracts> GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado);

        AccionDataContracts GetLastActionByIdFactura(int idFactura);
    }
}
