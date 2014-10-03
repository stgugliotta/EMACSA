using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DeudorDiaCobroDataContracts(EMACSA_NUCLEO.dbo.TBL_Deudor_Dia_Cobro)
    /// </summary>
    public interface IDeudorDiaCobroService
    {
        /// <summary>
        /// Interface para retornar un objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>DeudorDiaCobroDataContracts</value>
        DeudorDiaCobroDataContracts Load(int idDiaCobro);

        /// <summary>
        /// interface para eliminar un DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(DeudorDiaCobroDataContracts oDeudorDiaCobro);

        /// <summary>
        /// Interface para actualiza un objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(DeudorDiaCobroDataContracts oDeudorDiaCobro);

        /// <summary>
        /// Inteface para Insertar un objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(DeudorDiaCobroDataContracts oDeudorDiaCobro);

        /// <summary>
        /// Interface para  rertornar objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>DeudorDiaCobroDataContracts</value>
        DeudorDiaCobroDataContracts GetDeudorDiaCobro(int idDiaCobro);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDiaCobroDataContracts>]]></value>
        List<DeudorDiaCobroDataContracts> GetAllDeudorDiaCobros();

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDiaCobroDataContracts>]]></value>
        List<DeudorDiaCobroDataContracts> GetAllDeudorDiaCobrosPorIdDeudor(int id_deudor);
    }
}
