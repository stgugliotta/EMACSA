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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_OtroPago
    /// </summary>
    public class DALOtroPago : AbstractMapper<OtroPago>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALOtroPago()
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
        ~DALOtroPago()
        {
            //ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  OtroPago
        /// </summary>
        /// <param name="id"></param>    
        /// <returns></returns>
        public OtroPago Load(int id)
        {
            try
            {
                OtroPago oReturn = null;
                CommandText = "PA_MG_FRONT_OtroPago_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<OtroPago> otropagos = AbstractFindAll(oParameters);
                if (otropagos.Count > 0)
                {
                    oReturn = otropagos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALOtroPago, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_OtroPago
        /// </summary>
        /// <param name="oOtroPago"></param>
        /// <returns></returns>
        public void Delete(OtroPago oOtroPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_OtroPago_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oOtroPago.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALOtroPago, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_OtroPago
        /// </summary>
        /// <param name="oOtroPago"></param>
        /// <returns></returns>
        public void Update(OtroPago oOtroPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_OtroPago_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oOtroPago.Id));
                oParameters.Add(new DBParametro("@fechapago", DbType.DateTime, oOtroPago.FechaPago));
                oParameters.Add(new DBParametro("@numcomprobante", DbType.String, oOtroPago.NumComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oOtroPago.Importe));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALOtroPago, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_OtroPago
        /// </summary>
        /// <param name="oOtroPago"></param>
        /// <returns></returns>
        public void Insert(OtroPago oOtroPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_OtroPago_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oOtroPago.Id));
                oParameters.Add(new DBParametro("@fechapago", DbType.DateTime, oOtroPago.FechaPago));
                oParameters.Add(new DBParametro("@numcomprobante", DbType.String, oOtroPago.NumComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oOtroPago.Importe));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALOtroPago, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_OtroPago
        /// </summary>
        /// <param name="oOtroPago"></param>
        /// <returns></returns>
        public int InsertEscalar(OtroPago oOtroPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_OtroPago_Escalar_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, null));
                oParameters.Add(new DBParametro("@fechaPago", DbType.DateTime, oOtroPago.FechaPago));
                oParameters.Add(new DBParametro("@numComprobante", DbType.String, oOtroPago.NumComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double,  oOtroPago.Importe ));
                oParameters.Add(new DBParametro("@idTipoPagoRaro", DbType.Double, oOtroPago.IdTipoPagoRaro));



                return int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALOtroPago, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// OtroPago de la tabla dbo.TBL_OtroPago
        /// </summary>
        /// <param name="oOtroPago"></param>
        /// <returns></returns>
        public List<OtroPago> GetAllOtroPagos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_OtroPago_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<OtroPago> otropagos = AbstractFindAll(oParameters);

                return otropagos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALOtroPago, getOtroPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto OtroPago de la tabla dbo.TBL_OtroPago
        /// </summary>
        /// <param name="oOtroPago"></param>
        /// <returns></returns>
        public override OtroPago DoLoad(IDataReader registros)
        {
            try
            {
                OtroPago otropago = new OtroPago();
                otropago.Id = registros.GetInt32(0);
                otropago.FechaPago = registros.GetDateTime(1);
                otropago.NumComprobante = registros.GetString(2);
                otropago.Importe = registros.GetDouble(3);

                return otropago;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALOtroPago, getOtroPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override OtroPago DoLoad(IDataReader registros, OtroPago ent)
        {
            throw new NotImplementedException();
        }
    }
}
