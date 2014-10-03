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
    /// Clase que maneja la persistencia de la tabla dbo.LOG_Factura
    /// </summary>
    public class DALLogFactura : AbstractMapper<LogFactura>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALLogFactura()
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
        ~DALLogFactura()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  LogFactura
        /// </summary>
        /// <param name="id"></param>     
        /// <returns></returns>
        public LogFactura Load(int id)
        {
            try
            {
                LogFactura oReturn = null;
                CommandText = "PA_MG_FRONT_LogFactura_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<LogFactura> logfacturas = AbstractFindAll(oParameters);
                if (logfacturas.Count > 0)
                {
                    oReturn = logfacturas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALLOG_Factura, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.LOG_Factura
        /// </summary>
        /// <param name="oLogFactura"></param>
        /// <returns></returns>
        public void Delete(LogFactura oLogFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_LogFactura_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oLogFactura.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALLOG_Factura, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.LOG_Factura
        /// </summary>
        /// <param name="oLogFactura"></param>
        /// <returns></returns>
        public void Update(LogFactura oLogFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_LogFactura_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oLogFactura.Id));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oLogFactura.IdFactura));
                oParameters.Add(new DBParametro("@fechaactividad", DbType.DateTime, oLogFactura.FechaActividad));
                oParameters.Add(new DBParametro("@usuario", DbType.String, oLogFactura.Usuario));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oLogFactura.Observacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALLOG_Factura, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.LOG_Factura
        /// </summary>
        /// <param name="oLogFactura"></param>
        /// <returns></returns>
        public void Insert(LogFactura oLogFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_LogFactura_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oLogFactura.Id));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oLogFactura.IdFactura));
                oParameters.Add(new DBParametro("@fechaactividad", DbType.DateTime, oLogFactura.FechaActividad));
                oParameters.Add(new DBParametro("@usuario", DbType.String, oLogFactura.Usuario));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oLogFactura.Observacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALLOG_Factura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// LogFactura de la tabla dbo.LOG_Factura
        /// </summary>
        /// <param name="oLogFactura"></param>
        /// <returns></returns>
        public List<LogFactura> GetAllLogFacturas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_LogFactura_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<LogFactura> logfacturas = AbstractFindAll(oParameters);

                return logfacturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALLOG_Factura, getLOG_Facturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

          /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// LogFactura de la tabla dbo.LOG_Factura
        /// </summary>
        /// <param name="oLogFactura"></param>
        /// <returns></returns>
        public List<LogFactura> GetAllLogFacturasByIdFactura(int idFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_LOG_Factura_SELECTALL_ByIdFactura";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idFactura", DbType.Int32, idFactura));
                List<LogFactura> logfacturas = AbstractFindAll(oParameters);

                return logfacturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALLOG_Factura, getLOG_Facturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
       

        /// <summary>
        /// M?todo que crea un objeto LogFactura de la tabla dbo.LOG_Factura
        /// </summary>
        /// <param name="oLogFactura"></param>
        /// <returns></returns>
        public override LogFactura DoLoad(IDataReader registros)
        {
            try
            {
                LogFactura logfactura = new LogFactura();
                logfactura.Id = registros.GetInt32(0);
                logfactura.IdFactura = registros.GetInt32(1);
                logfactura.FechaActividad = registros.GetDateTime(2);
                logfactura.Usuario = registros.GetString(3);
                logfactura.Observacion = registros.GetString(4);

                return logfactura;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALLOG_Factura, getLOG_Facturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override LogFactura DoLoad(IDataReader registros, LogFactura ent)
        {
            throw new NotImplementedException();
        }
    }
}
