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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Transferencia
    /// </summary>
    public class DALTransferencia : AbstractMapper<Transferencia>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALTransferencia()
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
        ~DALTransferencia()
        {
           // ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Transferencia
        /// </summary>
        /// <param name="id"></param>       
        /// <returns></returns>
        public Transferencia Load(int id)
        {
            try
            {
                Transferencia oReturn = null;
                CommandText = "PA_MG_FRONT_Transferencia_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<Transferencia> transferencias = AbstractFindAll(oParameters);
                if (transferencias.Count > 0)
                {
                    oReturn = transferencias[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTransferencia, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Transferencia
        /// </summary>
        /// <param name="oTransferencia"></param>
        /// <returns></returns>
        public void Delete(Transferencia oTransferencia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Transferencia_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTransferencia.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTransferencia, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Transferencia
        /// </summary>
        /// <param name="oTransferencia"></param>
        /// <returns></returns>
        public void Update(Transferencia oTransferencia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Transferencia_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTransferencia.Id));
                oParameters.Add(new DBParametro("@fechadeposito", DbType.DateTime, oTransferencia.FechaDeposito));
                oParameters.Add(new DBParametro("@cuentacredito", DbType.String, oTransferencia.CuentaCredito));
                oParameters.Add(new DBParametro("@cuentadebito", DbType.String, oTransferencia.CuentaDebito));
                oParameters.Add(new DBParametro("@fechacarga", DbType.DateTime, oTransferencia.FechaCarga));
                oParameters.Add(new DBParametro("@numcomprobante", DbType.String, oTransferencia.NumComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oTransferencia.Importe));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTransferencia, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Transferencia
        /// </summary>
        /// <param name="oTransferencia"></param>
        /// <returns></returns>
        public void Insert(Transferencia oTransferencia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Transferencia_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTransferencia.Id));
                oParameters.Add(new DBParametro("@fechadeposito", DbType.DateTime, oTransferencia.FechaDeposito));
                oParameters.Add(new DBParametro("@cuentacredito", DbType.String, oTransferencia.CuentaCredito));
                oParameters.Add(new DBParametro("@cuentadebito", DbType.String, oTransferencia.CuentaDebito));
                oParameters.Add(new DBParametro("@fechacarga", DbType.DateTime, oTransferencia.FechaCarga));
                oParameters.Add(new DBParametro("@numcomprobante", DbType.String, oTransferencia.NumComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oTransferencia.Importe));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTransferencia, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }




        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla TBL_Transferencia
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public int InsertEscalar(Transferencia oTransferencia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Transferencia_Escalar_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, null));
                oParameters.Add(new DBParametro("@fechaDeposito", DbType.DateTime, oTransferencia.FechaDeposito));
                oParameters.Add(new DBParametro("@cuentaCredito", DbType.String, oTransferencia.CuentaCredito));
                oParameters.Add(new DBParametro("@cuentaDebito", DbType.String, oTransferencia.CuentaDebito));
                oParameters.Add(new DBParametro("@fechaCarga", DbType.DateTime,  oTransferencia.FechaCarga));
                oParameters.Add(new DBParametro("@numComprobante", DbType.String, oTransferencia.NumComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oTransferencia.Importe));


                return int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTransferencia, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Transferencia de la tabla dbo.TBL_Transferencia
        /// </summary>
        /// <param name="oTransferencia"></param>
        /// <returns></returns>
        public List<Transferencia> GetAllTransferencias()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Transferencia_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Transferencia> transferencias = AbstractFindAll(oParameters);

                return transferencias;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTransferencia, getTransferencias", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Transferencia de la tabla dbo.TBL_Transferencia
        /// </summary>
        /// <param name="oTransferencia"></param>
        /// <returns></returns>
        public override Transferencia DoLoad(IDataReader registros)
        {
            try
            {
                Transferencia transferencia = new Transferencia();
                transferencia.Id = registros.GetInt32(0);
                transferencia.FechaDeposito = registros.GetDateTime(1);
                transferencia.CuentaCredito = registros.GetString(2);
                transferencia.CuentaDebito = registros.GetString(3);
                transferencia.FechaCarga = registros.GetDateTime(4);
                transferencia.NumComprobante = registros.GetString(5);
                transferencia.Importe = registros.GetDouble(6);

                return transferencia;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTransferencia, getTransferencias", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Transferencia DoLoad(IDataReader registros, Transferencia ent)
        {
            throw new NotImplementedException();
        }
    }
}
