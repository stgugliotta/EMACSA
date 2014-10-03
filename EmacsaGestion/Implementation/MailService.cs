using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Accion		: Implementacion de la Interface de la Entidad Agenda
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_agenda
    /// Descripcion	: 
    /// </summary>
    public class MailService : IMailService
    {

              
            
        #region IMailService Members

        public List<MailDataContracts>  GetAllMailsByIdCliente(int idCliente)
        {
            try
            {
                MailAdmin mailAdmin = new MailAdmin();
                List<Mail> resultList = mailAdmin.GetAllMailsByIdCliente(idCliente);

                return resultList.ConvertAll<MailDataContracts>(
                    delegate(Mail tempMail) { return (MailDataContracts)tempMail; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllMails : MailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
}
}