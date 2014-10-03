using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad AgendaDataContracts(EMACSA_NUCLEO.dbo.TBL_Agenda)
    /// </summary>
    public interface IMailService
    {
        List<MailDataContracts> GetAllMailsByIdCliente(int idCliente);
    }
}
