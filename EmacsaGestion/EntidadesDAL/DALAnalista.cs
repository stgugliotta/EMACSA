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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Analista
    /// </summary>
    public class DALAnalista : AbstractMapper<Analista>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALAnalista()
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
        ~DALAnalista()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Analista
        /// </summary>

        /// <returns></returns>
        public Analista Load()
        {
            try
            {
                Analista oReturn = null;
                CommandText = "PA_MG_FRONT_Analista_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                List<Analista> analistas = AbstractFindAll(oParameters);
                if (analistas.Count > 0)
                {
                    oReturn = analistas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAnalista, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Analista
        /// </summary>
        /// <param name="oAnalista"></param>
        /// <returns></returns>
        public void Delete(Analista oAnalista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Analista_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAnalista, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Analista
        /// </summary>
        /// <param name="oAnalista"></param>
        /// <returns></returns>
        public void Update(Analista oAnalista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Analista_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idanalista", DbType.Int32, oAnalista.IdAnalista));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oAnalista.Nombre));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAnalista, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Analista
        /// </summary>
        /// <param name="oAnalista"></param>
        /// <returns></returns>
        public void Insert(Analista oAnalista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Analista_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idanalista", DbType.Int32, oAnalista.IdAnalista));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oAnalista.Nombre));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAnalista, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Analista de la tabla dbo.MTR_Analista
        /// </summary>
        /// <param name="oAnalista"></param>
        /// <returns></returns>
        public List<Analista> GetAllAnalistas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Analista_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Analista> analistas = AbstractFindAll(oParameters);

                return analistas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAnalista, getAnalistas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Analista de la tabla dbo.MTR_Analista
        /// </summary>
        /// <param name="oAnalista"></param>
        /// <returns></returns>
        public override Analista DoLoad(IDataReader registros)
        {
            try
            {
                Analista analista = new Analista();
                analista.IdAnalista = registros.GetInt32(0);
                analista.Nombre = registros.GetString(1);

                return analista;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAnalista, getAnalistas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Analista DoLoad(IDataReader registros, Analista ent)
        {
            throw new NotImplementedException();
        }
    }
}

