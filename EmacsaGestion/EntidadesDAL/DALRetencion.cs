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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Retencion
    /// </summary>
    public class DALRetencion : AbstractMapper<Retencion>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALRetencion()
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
        ~DALRetencion()
        {
        //    ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Retencion
        /// </summary>
        /// <param name="id"></param>    
        /// <returns></returns>
        public Retencion Load(int id)
        {
            try
            {
                Retencion oReturn = null;
                CommandText = "PA_MG_FRONT_Retencion_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<Retencion> retencions = AbstractFindAll(oParameters);
                if (retencions.Count > 0)
                {
                    oReturn = retencions[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencion, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Retencion
        /// </summary>
        /// <param name="oRetencion"></param>
        /// <returns></returns>
        public void Delete(Retencion oRetencion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Retencion_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oRetencion.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencion, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Retencion
        /// </summary>
        /// <param name="oRetencion"></param>
        /// <returns></returns>
        public void Update(Retencion oRetencion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Retencion_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oRetencion.Id));
                oParameters.Add(new DBParametro("@idretencion", DbType.Int32, oRetencion.IdRetencion));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oRetencion.Importe));
                oParameters.Add(new DBParametro("@fechapago", DbType.DateTime, oRetencion.FechaPago));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencion, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Retencion
        /// </summary>
        /// <param name="oRetencion"></param>
        /// <returns></returns>
        public void Insert(Retencion oRetencion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Retencion_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oRetencion.Id));
                oParameters.Add(new DBParametro("@idretencion", DbType.Int32, oRetencion.IdRetencion));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oRetencion.Importe));
                oParameters.Add(new DBParametro("@fechapago", DbType.DateTime, oRetencion.FechaPago));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencion, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla TBL_Retencion
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public int InsertEscalar(Retencion oRetencion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Retencion_Escalar_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, null));
                oParameters.Add(new DBParametro("@idretencion", DbType.Int32, oRetencion.IdRetencion));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oRetencion.Importe));
                oParameters.Add(new DBParametro("@fechapago", DbType.DateTime, oRetencion.FechaPago));
                oParameters.Add(new DBParametro("@numero", DbType.String, oRetencion.NumeroRetencion));
                oParameters.Add(new DBParametro("@idSubTipoRetencion", DbType.Int32 , oRetencion.IdSubTipoRetencion));


                        

                return int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCheque, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Retencion de la tabla dbo.TBL_Retencion
        /// </summary>
        /// <param name="oRetencion"></param>
        /// <returns></returns>
        public List<Retencion> GetAllRetencions()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Retencion_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Retencion> retencions = AbstractFindAll(oParameters);

                return retencions;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencion, getRetencions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Retencion de la tabla dbo.TBL_Retencion
        /// </summary>
        /// <param name="oRetencion"></param>
        /// <returns></returns>
        public override Retencion DoLoad(IDataReader registros)
        {
            try
            {
                Retencion retencion = new Retencion();
                retencion.Id = registros.GetInt32(0);
                retencion.IdRetencion = registros.GetInt32(1);
                retencion.Importe = registros.GetDouble(2);
                retencion.FechaPago = registros.GetDateTime(3);
                retencion.NumeroRetencion = registros.GetInt32(4).ToString();
                retencion.IdSubTipoRetencion = registros.GetInt32(5);


 
                return retencion;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencion, getRetencions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Retencion DoLoad(IDataReader registros, Retencion ent)
        {
            throw new NotImplementedException();
        }
    }
}
