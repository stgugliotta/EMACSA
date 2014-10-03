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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Cheque
    /// </summary>
    public class DALCheque : AbstractMapper<Cheque>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALCheque()
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
        ~DALCheque()
        {
            //ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Cheque
        /// </summary>

        /// <returns></returns>
        public Cheque Load(int idCheque)
        {
            try
            {
                Cheque oReturn = null;
                CommandText = "PA_MG_FRONT_Cheque_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, idCheque));

                List<Cheque> cheques = AbstractFindAll(oParameters);
                if (cheques.Count > 0)
                {
                    oReturn = cheques[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCheque, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public void Delete(Cheque oCheque)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cheque_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCheque, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public void Update(Cheque oCheque)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cheque_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

             
                oParameters.Add(new DBParametro("@numero", DbType.Int64, oCheque.Numero));
                oParameters.Add(new DBParametro("@banco", DbType.String, oCheque.Banco));
                oParameters.Add(new DBParametro("@sucursal", DbType.String, oCheque.Sucursal));
                oParameters.Add(new DBParametro("@emision", DbType.DateTime, oCheque.Emision));
                oParameters.Add(new DBParametro("@vencimiento", DbType.DateTime, oCheque.Vencimiento));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oCheque.Importe));
                oParameters.Add(new DBParametro("@cuit", DbType.String, oCheque.Cuit));
                oParameters.Add(new DBParametro("@cp", DbType.String, oCheque.Cp));
                oParameters.Add(new DBParametro("@cuenta", DbType.String, oCheque.Cuenta ));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCheque, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public void Insert(Cheque oCheque)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cheque_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

       
                oParameters.Add(new DBParametro("@numero", DbType.Int64, oCheque.Numero));
                oParameters.Add(new DBParametro("@banco", DbType.String, oCheque.Banco));
                oParameters.Add(new DBParametro("@sucursal", DbType.String, oCheque.Sucursal));
                oParameters.Add(new DBParametro("@emision", DbType.DateTime, oCheque.Emision));
                oParameters.Add(new DBParametro("@vencimiento", DbType.DateTime, oCheque.Vencimiento));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oCheque.Importe));
                oParameters.Add(new DBParametro("@cuit", DbType.String, oCheque.Cuit));
                oParameters.Add(new DBParametro("@cp", DbType.String, oCheque.Cp));
                oParameters.Add(new DBParametro("@cuenta", DbType.String, oCheque.Cuenta));



                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCheque, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public int InsertEscalar(Cheque oCheque)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cheque_Escalar_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, null));
                oParameters.Add(new DBParametro("@numero", DbType.Int64, oCheque.Numero));
                oParameters.Add(new DBParametro("@banco", DbType.String, oCheque.Banco));
                oParameters.Add(new DBParametro("@sucursal", DbType.String, oCheque.Sucursal));
                oParameters.Add(new DBParametro("@emision", DbType.DateTime, oCheque.Emision));
                oParameters.Add(new DBParametro("@vencimiento", DbType.DateTime, oCheque.Vencimiento));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oCheque.Importe));
                oParameters.Add(new DBParametro("@cuit", DbType.String, oCheque.Cuit));
                oParameters.Add(new DBParametro("@cp", DbType.String, oCheque.Cp));
                oParameters.Add(new DBParametro("@cuenta", DbType.String, oCheque.Cuenta));



               return  int.Parse(ExecuteScalar(oParameters,this.ObjConnection ).ToString());
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
        /// Cheque de la tabla dbo.MTR_Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public List<Cheque> GetAllCheques()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cheque_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Cheque> cheques = AbstractFindAll(oParameters);

                return cheques;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCheque, getCheques", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Cheque de la tabla dbo.MTR_Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public Cheque GetChequeByCuit(string cuit)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cheque_SELECTALL_ByCuit";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@cuit", DbType.String, cuit));
                Cheque cheque = AbstractFind(oParameters);

                return cheque;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCheque, getCheques", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que crea un objeto Cheque de la tabla dbo.MTR_Cheque
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public override Cheque DoLoad(IDataReader registros)
        {
            try
            {
                Cheque cheque = new Cheque();
                cheque.Id = registros.GetInt32(0);
                cheque.Numero = registros.GetInt64(1);
                cheque.Banco = registros.GetString(2);
                cheque.Sucursal = registros.GetString(3);
                cheque.Emision = registros.GetDateTime(4);
                cheque.Vencimiento = registros.GetDateTime(5);
                cheque.Importe = registros.GetDouble(6);
                cheque.Cuit  = registros.GetString(7);
                cheque.Cp  = registros.GetString(8);
                //cheque.Cuenta  = registros.GetString(9);


                return cheque;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCheque, getCheques", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Cheque DoLoad(IDataReader registros, Cheque ent)
        {
            throw new NotImplementedException();
        }
    }
}
