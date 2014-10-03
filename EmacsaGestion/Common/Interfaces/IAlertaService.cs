using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad AlertaDataContracts(EMACSA_NUCLEO.dbo.MTR_Alerta)
    /// </summary>
    public interface IAlertaService
    {
        /// <summary>
        /// Interface para retornar un objeto AlertaDataContracts
        /// </summary>
        /// <value>AlertaDataContracts</value>
        AlertaDataContracts Load(int idAlerta);

        /// <summary>
        /// interface para eliminar un AlertaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(AlertaDataContracts oAlerta);

        /// <summary>
        /// Interface para actualiza un objeto AlertaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(AlertaDataContracts oAlerta);

        /// <summary>
        /// Inteface para Insertar un objeto AlertaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(AlertaDataContracts oAlerta);

        /// <summary>
        /// Interface para  rertornar objeto AlertaDataContracts
        /// </summary>
        /// <value>AlertaDataContracts</value>
        AlertaDataContracts GetAlerta(int idAlerta);

        /// <summary>
        /// Interface para  rertornar una lista de objeto AlertaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<AlertaDataContracts>]]></value>
        List<AlertaDataContracts> GetAllAlertas();
    }
}
