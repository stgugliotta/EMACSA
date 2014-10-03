using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Agenda 
    /// </summary>
    public class MailAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Agenda 
        /// </summary>
        /// <param name="idTarea"></param>		
        /// <returns></returns>
        /// 

        public List<Mail> GetAllMailsByIdCliente(int idCliente)
        {
            List<Mail> lstMail = new List<Mail>();
            try
            {
                using (DALMail dalMail = new DALMail())
                {
                    lstMail = dalMail.GetAllMailsByIdCliente(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstMail;

        }
        
    }
}
