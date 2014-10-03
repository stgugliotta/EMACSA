using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad AccionDataContracts(EMACSA_NUCLEO.dbo.TBL_Accion)
    /// </summary>
    public interface ICambioService
    {
        /// <summary>
        /// Interface para retornar un objeto AccionDataContracts
        /// </summary>
        /// <value>AccionDataContracts</value>
        CambioDataContracts Load(int idCambio);

        /// <summary>
        /// interface para eliminar un AccionDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(CambioDataContracts oCambio);

        /// <summary>
        /// Interface para actualiza un objeto AccionDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(CambioDataContracts oCambio);

        /// <summary>
        /// Inteface para Insertar un objeto AccionDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(CambioDataContracts oCambio);

        /// <summary>
        /// Interface para  rertornar objeto AccionDataContracts
        /// </summary>
        /// <value>AccionDataContracts</value>
        CambioDataContracts GetCambio(int idCambio);

        /// <summary>
        /// Interface para  rertornar una lista de objeto AccionDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<AccionDataContracts>]]></value>
        List<CambioDataContracts> GetAllCambio();

        
    }
}
