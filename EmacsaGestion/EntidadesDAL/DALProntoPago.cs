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
    /// Clase que maneja la persistencia de la tabla dbo.CFG_Pronto_Pago
    /// </summary>
    public class DALProntoPago : AbstractMapper<ProntoPago>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALProntoPago()
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
        ~DALProntoPago()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  ProntoPago
        /// </summary>
        /// <param name="id"></param>       
        /// <returns></returns>
        public ProntoPago Load(int id)
        {
            try
            {
                ProntoPago oReturn = null;
                CommandText = "PA_MG_FRONT_CFG_ProntoPago_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<ProntoPago> prontopagos = AbstractFindAll(oParameters);
                if (prontopagos.Count > 0)
                {
                    oReturn = prontopagos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.CFG_Pronto_Pago
        /// </summary>
        /// <param name="oProntoPago"></param>
        /// <returns></returns>
        public void Delete(ProntoPago oProntoPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CFG_ProntoPago_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oProntoPago.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public void EliminarPorId(int id)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CFG_Pronto_Pago_Delete";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.CFG_Pronto_Pago
        /// </summary>
        /// <param name="oProntoPago"></param>
        /// <returns></returns>
        public void Update(ProntoPago oProntoPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CFG_ProntoPago_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                //oParameters.Add(new DBParametro("@id", DbType.Int32, oProntoPago.Id));
                //oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oProntoPago.IdDeudor));
                //oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oProntoPago.IdCliente));
                //oParameters.Add(new DBParametro("@fechadesde", DbType.Int32, oProntoPago.FechaDesde));
                //oParameters.Add(new DBParametro("@fechahasta", DbType.Int32, oProntoPago.FechaHasta));
                //oParameters.Add(new DBParametro("@porcentajeaplicacion", DbType.Int32, oProntoPago.PorcentajeAplicacion));
                //oParameters.Add(new DBParametro("@activo", DbType.Boolean, oProntoPago.Activo));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.CFG_Pronto_Pago
        /// </summary>
        /// <param name="oProntoPago"></param>
        /// <returns></returns>
        public void Insert(ProntoPago oProntoPago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CFG_Pronto_Pago_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, oProntoPago.IdDeudor));
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, oProntoPago.IdCliente));                
                oParameters.Add(new DBParametro("@diasAnticipacion",DbType.Int32, oProntoPago.DiasDeAnticipacion));
                oParameters.Add(new DBParametro("@porcentajeAplicacion", DbType.Double, oProntoPago.PorcentajeAplicacion));
                oParameters.Add(new DBParametro("@activo", DbType.Boolean, oProntoPago.Activo));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ProntoPago de la tabla dbo.CFG_Pronto_Pago
        /// </summary>
        /// <param name="oProntoPago"></param>
        /// <returns></returns>
        public List<ProntoPago> GetAllProntoPagos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_CFG_Pronto_Pago_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<ProntoPago> prontopagos = AbstractFindAll(oParameters);

                return prontopagos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, getProntoPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        
        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ProntoPago de la tabla dbo.CFG_Pronto_Pago
        /// </summary>
        /// <param name="oProntoPago"></param>
        /// <returns></returns>
        public List<ProntoPago> GetAllProntoPagoByIdClienteYIdDeudor(int idCliente, int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CFG_Pronto_Pago_SelectALL_ByClienteYDeudor";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, idCliente));
               

                List<ProntoPago> prontopagos = AbstractFindAll(oParameters);

                return prontopagos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, getProntoPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<ProntoPago> GetAllProntoPagoByIdCliente(int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CFG_Pronto_Pago_SelectALL_ByCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, idCliente));

                List<ProntoPago> prontopagos = AbstractFindAll(oParameters);

                return prontopagos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, getProntoPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        
        /// <summary>
        /// M?todo que crea un objeto ProntoPago de la tabla dbo.CFG_Pronto_Pago
        /// </summary>
        /// <param name="oProntoPago"></param>
        /// <returns></returns>
        public override ProntoPago DoLoad(IDataReader registros)
        {
            try
            {
                ProntoPago prontopago = new ProntoPago();
                prontopago.Id = registros.GetInt32(0);
                prontopago.IdDeudor = registros.GetInt32(1);
                prontopago.IdCliente = registros.GetInt32(2);
                prontopago.NombreCliente = registros.GetString(3);
                prontopago.NombreDeudor = registros.GetString(4);
                prontopago.DiasDeAnticipacion = registros.GetInt32(5);
                prontopago.PorcentajeAplicacion = registros.GetDouble(6);
                prontopago.Activo = registros.GetBoolean(7);

                return prontopago;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProntoPago, getProntoPagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override ProntoPago DoLoad(IDataReader registros, ProntoPago ent)
        {
            throw new NotImplementedException();
        }
    }
}
