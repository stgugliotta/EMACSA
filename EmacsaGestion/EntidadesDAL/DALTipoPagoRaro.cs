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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_TipoPagoRaro
    /// </summary>
    public class DALTipoPagoRaro : AbstractMapper<TipoPagoRaro>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALTipoPagoRaro()
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
        ~DALTipoPagoRaro()
        {
          //  ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  TipoPagoRaro
        /// </summary>
        /// <param name="id"></param>  
        /// <returns></returns>
        public TipoPagoRaro Load(int id)
        {
            try
            {
                TipoPagoRaro oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_TipoPagoRaro_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<TipoPagoRaro> tipopagoraros = AbstractFindAll(oParameters);
                if (tipopagoraros.Count > 0)
                {
                    oReturn = tipopagoraros[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoPagoRaro, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_TipoPagoRaro
        /// </summary>
        /// <param name="oTipoPagoRaro"></param>
        /// <returns></returns>
        public void Delete(TipoPagoRaro oTipoPagoRaro)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_TipoPagoRaro_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTipoPagoRaro.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoPagoRaro, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_TipoPagoRaro
        /// </summary>
        /// <param name="oTipoPagoRaro"></param>
        /// <returns></returns>
        public void Update(TipoPagoRaro oTipoPagoRaro)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_TipoPagoRaro_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTipoPagoRaro.Id));
                oParameters.Add(new DBParametro("@tipopagoraro", DbType.String, oTipoPagoRaro.TipoPago));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoPagoRaro, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_TipoPagoRaro
        /// </summary>
        /// <param name="oTipoPagoRaro"></param>
        /// <returns></returns>
        public void Insert(TipoPagoRaro oTipoPagoRaro)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_TipoPagoRaro_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTipoPagoRaro.Id));
                oParameters.Add(new DBParametro("@tipopagoraro", DbType.String, oTipoPagoRaro.TipoPago));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoPagoRaro, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// TipoPagoRaro de la tabla dbo.MTR_TipoPagoRaro
        /// </summary>
        /// <param name="oTipoPagoRaro"></param>
        /// <returns></returns>
        public List<TipoPagoRaro> GetAllTipoPagoRaros()
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_TipoPagoRaro_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<TipoPagoRaro> tipopagoraros = AbstractFindAll(oParameters);

                return tipopagoraros;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoPagoRaro, getTipoPagoRaros", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto TipoPagoRaro de la tabla dbo.MTR_TipoPagoRaro
        /// </summary>
        /// <param name="oTipoPagoRaro"></param>
        /// <returns></returns>
        public override TipoPagoRaro DoLoad(IDataReader registros)
        {
            try
            {
                TipoPagoRaro tipopagoraro = new TipoPagoRaro();
                tipopagoraro.Id = registros.GetInt32(0);
                tipopagoraro.TipoPago = registros.GetString(1);

                return tipopagoraro;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoPagoRaro, getTipoPagoRaros", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override TipoPagoRaro DoLoad(IDataReader registros, TipoPagoRaro ent)
        {
            throw new NotImplementedException();
        }
    }
}
