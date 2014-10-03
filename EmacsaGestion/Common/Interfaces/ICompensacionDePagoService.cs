using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad CompensacionDePagoDataContracts(EMACSA_NUCLEO.dbo.TBL_CompensacionDePago)
    /// </summary>
    public interface ICompensacionDePagoService
    {
        /// <summary>
        /// Interface para retornar un objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>CompensacionDePagoDataContracts</value>
        CompensacionDePagoDataContracts Load(int idCompensacion);

        /// <summary>
        /// interface para eliminar un CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(CompensacionDePagoDataContracts oCompensacionDePago);

        /// <summary>
        /// Interface para actualiza un objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(CompensacionDePagoDataContracts oCompensacionDePago);

        /// <summary>
        /// Inteface para Insertar un objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(CompensacionDePagoDataContracts oCompensacionDePago);

        /// <summary>
        /// Interface para  rertornar objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>CompensacionDePagoDataContracts</value>
        CompensacionDePagoDataContracts GetCompensacionDePago(int idCompensacion);

        /// <summary>
        /// Interface para  rertornar una lista de objeto CompensacionDePagoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<CompensacionDePagoDataContracts>]]></value>
        List<CompensacionDePagoDataContracts> GetAllCompensacionDePagos();

        CompensacionDePagoDataContracts GetCompensacionDePagoPorNumeroDeRecibo(string numRecibo);
    }
}
