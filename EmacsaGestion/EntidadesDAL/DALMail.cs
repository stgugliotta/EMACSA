using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Agenda
    /// </summary>
    public class DALMail : AbstractMapper<Mail>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALMail()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

        /// <summary>
        /// Destructor Standard
        /// </summary>
        ~DALMail()
        {
            ObjConnection.Dispose();
        }



        public override Mail DoLoad(IDataReader registros)
        {
            try
            {
                Mail mail = new Mail();
                mail.IdMail = registros.GetInt32(0);
                mail.IdCliente = registros.GetInt32(1);
                mail.Email = registros.GetString(2);
                mail.Contacto = registros.GetString(3);
                return mail;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, getAgendas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Mail> GetAllMailsByIdCliente(int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Mails_SelectALL_ByIdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32 , idCliente));
                List<Mail> mails = AbstractFindAll(oParameters);

                return mails;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALMail, getMails", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Mail DoLoad(IDataReader registros, Mail ent)
        {
            throw new NotImplementedException();
        }
    }
}
