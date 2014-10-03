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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Remision_Descuento
    /// </summary>
    public class DALRemisionDescuento : AbstractMapper<RemisionDescuento>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALRemisionDescuento()
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
        ~DALRemisionDescuento()
        {
           // ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  RemisionDescuento
        /// </summary>
        /// <param name="id"></param>     
        /// <returns></returns>
        public RemisionDescuento Load(int id)
        {
            try
            {
                RemisionDescuento oReturn = null;
                CommandText = "PA_MG_FRONT_RemisionDescuento_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<RemisionDescuento> remisiondescuentos = AbstractFindAll(oParameters);
                if (remisiondescuentos.Count > 0)
                {
                    oReturn = remisiondescuentos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemisionDescuento, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Remision_Descuento
        /// </summary>
        /// <param name="oRemisionDescuento"></param>
        /// <returns></returns>
        public void Delete(RemisionDescuento oRemisionDescuento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_RemisionDescuento_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oRemisionDescuento.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemisionDescuento, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Remision_Descuento
        /// </summary>
        /// <param name="oRemisionDescuento"></param>
        /// <returns></returns>
        public void Update(RemisionDescuento oRemisionDescuento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_RemisionDescuento_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oRemisionDescuento.Id));
                oParameters.Add(new DBParametro("@idremision", DbType.Int32, oRemisionDescuento.IdRemision));
                oParameters.Add(new DBParametro("@iddescuento", DbType.Int32, oRemisionDescuento.IdDescuento));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oRemisionDescuento.Importe));
                oParameters.Add(new DBParametro("@fechadescuento", DbType.DateTime, oRemisionDescuento.FechaDescuento));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemisionDescuento, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Remision_Descuento
        /// </summary>
        /// <param name="oRemisionDescuento"></param>
        /// <returns></returns>
        public void Insert(RemisionDescuento oRemisionDescuento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_RemisionDescuento_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oRemisionDescuento.Id));
                oParameters.Add(new DBParametro("@idremision", DbType.Int32, oRemisionDescuento.IdRemision));
                oParameters.Add(new DBParametro("@iddescuento", DbType.Int32, oRemisionDescuento.IdDescuento));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oRemisionDescuento.Importe));
                oParameters.Add(new DBParametro("@fechadescuento", DbType.DateTime, oRemisionDescuento.FechaDescuento));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemisionDescuento, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public int InsertEscalar(RemisionDescuento oRemisionDescuento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Remision_Descuento_Escalar_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, null));
                oParameters.Add(new DBParametro("@idRemision", DbType.Int32, oRemisionDescuento.IdRemision));
                oParameters.Add(new DBParametro("@idDescuento", DbType.Int32, oRemisionDescuento.IdDescuento));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oRemisionDescuento.Importe));
                oParameters.Add(new DBParametro("@fechaDescuento", DbType.DateTime, oRemisionDescuento.FechaDescuento));

                return int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemisionDescuento, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// RemisionDescuento de la tabla dbo.TBL_Remision_Descuento
        /// </summary>
        /// <param name="oRemisionDescuento"></param>
        /// <returns></returns>
        public List<RemisionDescuento> GetAllRemisionDescuentos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_RemisionDescuento_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<RemisionDescuento> remisiondescuentos = AbstractFindAll(oParameters);

                return remisiondescuentos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemisionDescuento, getRemisionDescuentos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto RemisionDescuento de la tabla dbo.TBL_Remision_Descuento
        /// </summary>
        /// <param name="oRemisionDescuento"></param>
        /// <returns></returns>
        public override RemisionDescuento DoLoad(IDataReader registros)
        {
            try
            {
                RemisionDescuento remisiondescuento = new RemisionDescuento();
                remisiondescuento.Id = registros.GetInt32(0);
                remisiondescuento.IdRemision = registros.GetInt32(1);
                remisiondescuento.IdDescuento = registros.GetInt32(2);
                remisiondescuento.Importe = registros.GetDouble(3);
                remisiondescuento.FechaDescuento = registros.GetDateTime(4);

                return remisiondescuento;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemisionDescuento, getRemisionDescuentos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override RemisionDescuento DoLoad(IDataReader registros, RemisionDescuento ent)
        {
            throw new NotImplementedException();
        }
    }
}
