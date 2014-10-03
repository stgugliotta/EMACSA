using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DeudorDiaReclamoDataContracts(EMACSA_NUCLEO.dbo.TBL_Deudor_Dia_Reclamo)
    /// </summary>
    public interface IDeudorDiaReclamoAlternativoService
    {
        /// <summary>
        /// Interface para retornar un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>DeudorDiaReclamoDataContracts</value>
        DeudorDiaReclamoAlternativoDataContracts Load(int idDiaReclamo);

        /// <summary>
        /// interface para eliminar un DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(DeudorDiaReclamoAlternativoDataContracts oDeudorDiaReclamo);

        /// <summary>
        /// Interface para actualiza un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(DeudorDiaReclamoAlternativoDataContracts oDeudorDiaReclamo);

        /// <summary>
        /// Inteface para Insertar un objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(DeudorDiaReclamoAlternativoDataContracts oDeudorDiaReclamo);

        /// <summary>
        /// Inteface para Insertar un objeto DomicilioDeudorDataContracts
        /// </summary>
        /// <value>void</value>
        void InsertHorarioAlterntivoDeCobro(DeudorDiaReclamoAlternativoDataContracts oDomicilioDeudor);

        /// <summary>
        /// Interface para  rertornar objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>DeudorDiaReclamoDataContracts</value>
        DeudorDiaReclamoAlternativoDataContracts GetDeudorDiaReclamoAlternativo(int idDiaReclamo);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDiaReclamoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDiaReclamoDataContracts>]]></value>
        List<DeudorDiaReclamoAlternativoDataContracts> GetAllDeudorDiaReclamoAlternativo(int id_deudor);
    }
}
