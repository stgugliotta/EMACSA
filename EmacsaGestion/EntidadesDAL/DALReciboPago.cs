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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Recibo_Pago
    /// </summary>
    public class DALReciboPago : AbstractMapper<ReciboPago>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALReciboPago()
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
        ~DALReciboPago()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  ReciboPago
        /// </summary>
        /// <param name="idRecibo"></param> /// <param name="idPago"></param>   
        /// <returns></returns>
        public ReciboPago Load(int idRecibo, int idPago)
        {
            try
            {
                ReciboPago oReturn = null;
                CommandText = "PA_MG_FRONT_ReciboPago_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idrecibo", DbType.Int32, idRecibo)); oParameters.Add(new DBParametro("@idpago", DbType.Int32, idPago));

                List<ReciboPago> recibopagos = AbstractFindAll(oParameters);
                if (recibopagos.Count > 0)
                {
                    oReturn = recibopagos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboPago, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Recibo_Pago
        /// </summary>
        /// <param name="oReciboPago"></param>
        /// <returns></returns>
        public void Delete(ReciboPago oReciboPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_ReciboPago_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idrecibo", DbType.Int32, oReciboPago.IdRecibo)); oParameters.Add(new DBParametro("@idpago", DbType.Int32, oReciboPago.IdPago));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboPago, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Recibo_Pago
        /// </summary>
        /// <param name="oReciboPago"></param>
        /// <returns></returns>
        public void Update(ReciboPago oReciboPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_ReciboPago_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idrecibo", DbType.Int32, oReciboPago.IdRecibo));
                oParameters.Add(new DBParametro("@idpago", DbType.Int32, oReciboPago.IdPago));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oReciboPago.NumRecibo));
                oParameters.Add(new DBParametro("@formapago", DbType.String, oReciboPago.FormaPago));
                oParameters.Add(new DBParametro("@idMoneda", DbType.Int32 , oReciboPago.IdMoneda ));
                oParameters.Add(new DBParametro("@totalPesificado", DbType.Double , oReciboPago.TotalPesificado));
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboPago, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Recibo_Pago
        /// </summary>
        /// <param name="oReciboPago"></param>
        /// <returns></returns>
        public void Insert(ReciboPago oReciboPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_Pago_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idrecibo", DbType.Int32, oReciboPago.IdRecibo));
                oParameters.Add(new DBParametro("@idpago", DbType.Int32, oReciboPago.IdPago));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oReciboPago.NumRecibo));
                oParameters.Add(new DBParametro("@formapago", DbType.String, oReciboPago.FormaPago));
                oParameters.Add(new DBParametro("@idMoneda", DbType.Int32  , oReciboPago.IdMoneda ));
                oParameters.Add(new DBParametro("@totalPesificado", DbType.Double, oReciboPago.TotalPesificado));
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboPago, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ReciboPago de la tabla dbo.TBL_Recibo_Pago
        /// </summary>
        /// <param name="oReciboPago"></param>
        /// <returns></returns>
        public List<ReciboPago> GetAllReciboPagos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_Pago_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<ReciboPago> recibopagos = AbstractFindAll(oParameters);

                return recibopagos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboPago, getReciboPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ReciboPago de la tabla dbo.TBL_Recibo_Pago
        /// </summary>
        /// <param name="oReciboPago"></param>
        /// <returns></returns>
        public List<ReciboPago> GetAllReciboPagosByIdRecibo(int idRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_ReciboPago_SELECTALL_ByIdRecibo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));

                List<ReciboPago> recibopagos = AbstractFindAll(oParameters);

                return recibopagos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboPago, getReciboPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que crea un objeto ReciboPago de la tabla dbo.TBL_Recibo_Pago
        /// </summary>
        /// <param name="oReciboPago"></param>
        /// <returns></returns>
        public override ReciboPago DoLoad(IDataReader registros)
        {
            try
            {
                ReciboPago recibopago = new ReciboPago();
                recibopago.IdRecibo = registros.GetInt32(0);
                recibopago.IdPago = registros.GetInt32(1);
                recibopago.NumRecibo = registros.GetString(2);
                recibopago.FormaPago = registros.GetString(3);
                recibopago.IdMoneda  = registros.GetInt32(4);
                recibopago.TotalPesificado  = registros.GetDouble(5);

                return recibopago;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboPago, getReciboPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override ReciboPago DoLoad(IDataReader registros, ReciboPago ent)
        {
            throw new NotImplementedException();
        }
    }
}
