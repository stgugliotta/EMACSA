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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_CompensacionDePago
    /// </summary>
    public class DALCompensacionDePago : AbstractMapper<CompensacionDePago>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALCompensacionDePago()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  CompensacionDePago
        /// </summary>
        /// <param name="idCompensacion"></param>      
        /// <returns></returns>
        public CompensacionDePago Load(int idCompensacion)
        {
            try
            {
                CompensacionDePago oReturn = null;
                CommandText = "PA_MG_FRONT_CompensacionDePago_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idcompensacion", DbType.Int32, idCompensacion));

                List<CompensacionDePago> compensaciondepagos = AbstractFindAll(oParameters);
                if (compensaciondepagos.Count > 0)
                {
                    oReturn = compensaciondepagos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCompensacionDePago, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_CompensacionDePago
        /// </summary>
        /// <param name="oCompensacionDePago"></param>
        /// <returns></returns>
        public void Delete(CompensacionDePago oCompensacionDePago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CompensacionDePago_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idcompensacion", DbType.Int32, oCompensacionDePago.IdCompensacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCompensacionDePago, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_CompensacionDePago
        /// </summary>
        /// <param name="oCompensacionDePago"></param>
        /// <returns></returns>
        public void Update(CompensacionDePago oCompensacionDePago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CompensacionDePago_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idcompensacion", DbType.Int32, oCompensacionDePago.IdCompensacion));
                oParameters.Add(new DBParametro("@fecharealizacioncompensacion", DbType.DateTime, oCompensacionDePago.FechaRealizacionCompensacion));
                oParameters.Add(new DBParametro("@monto", DbType.Double, oCompensacionDePago.Monto));
                oParameters.Add(new DBParametro("@reciborelacionado", DbType.String, oCompensacionDePago.ReciboRelacionado));
                oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oCompensacionDePago.IdDeudor));
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oCompensacionDePago.IdCliente));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCompensacionDePago, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_CompensacionDePago
        /// </summary>
        /// <param name="oCompensacionDePago"></param>
        /// <returns></returns>
        public void Insert(CompensacionDePago oCompensacionDePago)
        {
            try
            {
                CommandText = "PA_MG_FRONT_CompensacionDePago_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idcompensacion", DbType.Int32, oCompensacionDePago.IdCompensacion));
                oParameters.Add(new DBParametro("@fecharealizacioncompensacion", DbType.DateTime, oCompensacionDePago.FechaRealizacionCompensacion));
                oParameters.Add(new DBParametro("@monto", DbType.Double, oCompensacionDePago.Monto));
                oParameters.Add(new DBParametro("@reciborelacionado", DbType.String, oCompensacionDePago.ReciboRelacionado));
                oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oCompensacionDePago.IdDeudor));
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oCompensacionDePago.IdCliente));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCompensacionDePago, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// CompensacionDePago de la tabla dbo.TBL_CompensacionDePago
        /// </summary>
        /// <param name="oCompensacionDePago"></param>
        /// <returns></returns>
        public List<CompensacionDePago> GetAllCompensacionDePagos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_CompensacionDePago_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<CompensacionDePago> compensaciondepagos = AbstractFindAll(oParameters);

                return compensaciondepagos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCompensacionDePago, getCompensacionDePagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        public CompensacionDePago GetCompensacionDePagoPorNumeroDeRecibo(string numRecibo)
        {
            try
            {
                CompensacionDePago oReturn = null;
                CommandText = "PA_MG_FRONT_CompensacionDePagoPorNumeroDeRecibo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@numRecibo", DbType.String , numRecibo));

                List<CompensacionDePago> compensaciondepagos = AbstractFindAll(oParameters);
                if (compensaciondepagos.Count > 0)
                {
                    oReturn = compensaciondepagos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCompensacionDePago, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }

        }


        /// <summary>
        /// M?todo que crea un objeto CompensacionDePago de la tabla dbo.TBL_CompensacionDePago
        /// </summary>
        /// <param name="oCompensacionDePago"></param>
        /// <returns></returns>
        public override CompensacionDePago DoLoad(IDataReader registros)
        {
            try
            {
                CompensacionDePago compensaciondepago = new CompensacionDePago();
                compensaciondepago.IdCompensacion = registros.GetInt32(0);
                compensaciondepago.FechaRealizacionCompensacion = registros.GetDateTime(1);
                compensaciondepago.Monto = registros.GetDouble(2);
                compensaciondepago.ReciboRelacionado = registros.GetString(3);
                compensaciondepago.IdDeudor = registros.GetInt32(4);
                compensaciondepago.IdCliente = registros.GetInt32(5);

                return compensaciondepago;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCompensacionDePago, getCompensacionDePagos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override CompensacionDePago DoLoad(IDataReader registros, CompensacionDePago ent)
        {
            throw new NotImplementedException();
        }
    }
}
