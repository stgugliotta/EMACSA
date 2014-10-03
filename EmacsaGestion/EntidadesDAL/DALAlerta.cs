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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Alerta
    /// </summary>
    public class DALAlerta : AbstractMapper<Alerta>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALAlerta()
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
        ~DALAlerta()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Alerta
        /// </summary>
        /// <param name="idAlerta"></param>  
        /// <returns></returns>
        public Alerta Load(int idAlerta)
        {
            try
            {
                Alerta oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Alerta_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idalerta", DbType.Int32, idAlerta));

                List<Alerta> alertas = AbstractFindAll(oParameters);
                if (alertas.Count > 0)
                {
                    oReturn = alertas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAlerta, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Alerta
        /// </summary>
        /// <param name="oAlerta"></param>
        /// <returns></returns>
        public void Delete(Alerta oAlerta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Alerta_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idalerta", DbType.Int32, oAlerta.IdAlerta));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAlerta, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Alerta
        /// </summary>
        /// <param name="oAlerta"></param>
        /// <returns></returns>
        public void Update(Alerta oAlerta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Alerta_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idalerta", DbType.Int32, oAlerta.IdAlerta));
                oParameters.Add(new DBParametro("@alerta", DbType.String, oAlerta.AlertaDes));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAlerta, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Alerta
        /// </summary>
        /// <param name="oAlerta"></param>
        /// <returns></returns>
        public void Insert(Alerta oAlerta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Alerta_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idalerta", DbType.Int32, oAlerta.IdAlerta));
                oParameters.Add(new DBParametro("@alerta", DbType.String, oAlerta.AlertaDes));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAlerta, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Alerta de la tabla dbo.MTR_Alerta
        /// </summary>
        /// <param name="oAlerta"></param>
        /// <returns></returns>
        public List<Alerta> GetAllAlertas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Alerta_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Alerta> alertas = AbstractFindAll(oParameters);

                return alertas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAlerta, getAlertas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Alerta de la tabla dbo.MTR_Alerta
        /// </summary>
        /// <param name="oAlerta"></param>
        /// <returns></returns>
        public override Alerta DoLoad(IDataReader registros)
        {
            try
            {
                Alerta alerta = new Alerta();
                alerta.IdAlerta = registros.GetInt32(0);
                alerta.AlertaDes = registros.GetString(1);

                return alerta;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAlerta, getAlertas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Alerta DoLoad(IDataReader registros, Alerta ent)
        {
            throw new NotImplementedException();
        }
    }
}
