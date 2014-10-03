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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Pago
    /// </summary>
    public class DALPago : AbstractMapper<Pago>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALPago()
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
        ~DALPago()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Pago
        /// </summary>
        /// <param name="idPago"></param>    
        /// <returns></returns>
        public Pago Load(int idPago)
        {
            try
            {
                Pago oReturn = null;
                CommandText = "PA_MG_FRONT_Pago_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_pago", DbType.Int32, idPago));

                List<Pago> pagos = AbstractFindAll(oParameters);
                if (pagos.Count > 0)
                {
                    oReturn = pagos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPago, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Pago
        /// </summary>
        /// <param name="oPago"></param>
        /// <returns></returns>
        public void Delete(Pago oPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Pago_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_pago", DbType.Int32, oPago.IDPago));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPago, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Pago
        /// </summary>
        /// <param name="oPago"></param>
        /// <returns></returns>
        public void Update(Pago oPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Pago_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_pago", DbType.Int32, oPago.IDPago));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oPago.Importe));
                oParameters.Add(new DBParametro("@id_tipo_pago", DbType.Int32, oPago.IdTipoPago));
                oParameters.Add(new DBParametro("@id_moneda", DbType.Int32, oPago.IdMoneda));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPago, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Pago
        /// </summary>
        /// <param name="oPago"></param>
        /// <returns></returns>
        public void Insert(Pago oPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Pago_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_pago", DbType.Int32, oPago.IDPago));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oPago.Importe));
                oParameters.Add(new DBParametro("@id_tipo_pago", DbType.Int32, oPago.IdTipoPago));
                oParameters.Add(new DBParametro("@id_moneda", DbType.Int32, oPago.IdMoneda));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPago, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Pago de la tabla dbo.TBL_Pago
        /// </summary>
        /// <param name="oPago"></param>
        /// <returns></returns>
        public List<Pago> GetAllPagos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Pago_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Pago> pagos = AbstractFindAll(oParameters);

                return pagos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPago, getPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Pago de la tabla dbo.TBL_Pago
        /// </summary>
        /// <param name="oPago"></param>
        /// <returns></returns>
        public override Pago DoLoad(IDataReader registros)
        {
            try
            {
                Pago pago = new Pago();
                pago.IDPago = registros.IsDBNull(0) ? 0 : registros.GetInt32(0);
                pago.Importe = registros.IsDBNull(1) ? 0.0f : registros.GetDouble(1);
                pago.IdTipoPago = registros.IsDBNull(2) ? 0 : registros.GetInt32(2);
                pago.IdMoneda = registros.IsDBNull(3) ? 0: registros.GetInt32(3);

                return pago;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPago, getPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Pago DoLoad(IDataReader registros, Pago ent)
        {
            throw new NotImplementedException();
        }
    }
}
