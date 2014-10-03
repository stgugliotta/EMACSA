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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Efectivo
    /// </summary>
    public class DALEfectivo : AbstractMapper<Efectivo>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALEfectivo()
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
        ~DALEfectivo()
        {
            //ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Efectivo
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        public Efectivo Load(int id)
        {
            try
            {
                Efectivo oReturn = null;
                CommandText = "PA_MG_FRONT_Efectivo_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<Efectivo> efectivos = AbstractFindAll(oParameters);
                if (efectivos.Count > 0)
                {
                    oReturn = efectivos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEfectivo, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Efectivo
        /// </summary>
        /// <param name="oEfectivo"></param>
        /// <returns></returns>
        public void Delete(Efectivo oEfectivo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Efectivo_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oEfectivo.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEfectivo, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Efectivo
        /// </summary>
        /// <param name="oEfectivo"></param>
        /// <returns></returns>
        public void Update(Efectivo oEfectivo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Efectivo_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oEfectivo.Id));
                oParameters.Add(new DBParametro("@fechapago", DbType.DateTime, oEfectivo.FechaPago));
                oParameters.Add(new DBParametro("@monto", DbType.Double, oEfectivo.Monto));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEfectivo, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Efectivo
        /// </summary>
        /// <param name="oEfectivo"></param>
        /// <returns></returns>
        public void Insert(Efectivo oEfectivo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Efectivo_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oEfectivo.Id));
                oParameters.Add(new DBParametro("@fechapago", DbType.DateTime, oEfectivo.FechaPago));
                oParameters.Add(new DBParametro("@monto", DbType.Double, oEfectivo.Monto));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEfectivo, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }




        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla TBL_Efectivo
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public int InsertEscalar(Efectivo oEfectivo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Efectivo_Escalar_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, null));
                oParameters.Add(new DBParametro("@monto", DbType.Double, oEfectivo.Importe));
                oParameters.Add(new DBParametro("@fechapago", DbType.DateTime, oEfectivo.FechaPago));




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
        /// Efectivo de la tabla dbo.TBL_Efectivo
        /// </summary>
        /// <param name="oEfectivo"></param>
        /// <returns></returns>
        public List<Efectivo> GetAllEfectivos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Efectivo_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Efectivo> efectivos = AbstractFindAll(oParameters);

                return efectivos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEfectivo, getEfectivos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Efectivo de la tabla dbo.TBL_Efectivo
        /// </summary>
        /// <param name="oEfectivo"></param>
        /// <returns></returns>
        public override Efectivo DoLoad(IDataReader registros)
        {
            try
            {
                Efectivo efectivo = new Efectivo();
                efectivo.Id = registros.GetInt32(0);
                efectivo.FechaPago = registros.GetDateTime(1);
                efectivo.Monto = registros.GetDouble(2);

                return efectivo;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEfectivo, getEfectivos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Efectivo DoLoad(IDataReader registros, Efectivo ent)
        {
            throw new NotImplementedException();
        }
    }
}
