using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DeudorDiaReclamoDataContracts(EMACSA_NUCLEO.dbo.TBL_Deudor_Dia_Reclamo)
    /// </summary>
    public interface IDeudorDiaReclamoService
    {
        /// <summary>
        /// Interface para retornar un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>DeudorDiaReclamoDataContracts</value>
        DeudorDiaReclamoDataContracts Load(int idDiaReclamo);

        /// <summary>
        /// interface para eliminar un DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(DeudorDiaReclamoDataContracts oDeudorDiaReclamo);

        /// <summary>
        /// Interface para actualiza un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(DeudorDiaReclamoDataContracts oDeudorDiaReclamo);

        /// <summary>
        /// Inteface para Insertar un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(DeudorDiaReclamoDataContracts oDeudorDiaReclamo);

        /// <summary>
        /// Interface para  rertornar objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>DeudorDiaReclamoDataContracts</value>
        DeudorDiaReclamoDataContracts GetDeudorDiaReclamo(int idDiaReclamo);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDiaReclamoDataContracts>]]></value>
        List<DeudorDiaReclamoDataContracts> GetAllDeudorDiaReclamo(int id_deudor);
    }
}
