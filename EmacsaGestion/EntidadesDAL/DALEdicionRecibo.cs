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
    /// Clase que maneja la persistencia de la tabla dbo.DatosEdicionRecibo
    /// </summary>
    public class DALDatosEdicionRecibo : AbstractMapper<DatosEdicionRecibo>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALDatosEdicionRecibo()
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
        ~DALDatosEdicionRecibo()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  DatosEdicionRecibo
        /// </summary>

        /// <returns></returns>
        public DatosEdicionRecibo Load()
        {
            try
            {
                DatosEdicionRecibo oReturn = null;
                CommandText = "PA_MG_FRONT_DatosEdicionRecibo_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                List<DatosEdicionRecibo> datosedicionrecibos = AbstractFindAll(oParameters);
                if (datosedicionrecibos.Count > 0)
                {
                    oReturn = datosedicionrecibos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDatosEdicionRecibo, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.DatosEdicionRecibo
        /// </summary>
        /// <param name="oDatosEdicionRecibo"></param>
        /// <returns></returns>
        public void Delete(DatosEdicionRecibo oDatosEdicionRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_DatosEdicionRecibo_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDatosEdicionRecibo, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.DatosEdicionRecibo
        /// </summary>
        /// <param name="oDatosEdicionRecibo"></param>
        /// <returns></returns>
        public void Update(DatosEdicionRecibo oDatosEdicionRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_DatosEdicionRecibo_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@fechacreacion", DbType.DateTime, oDatosEdicionRecibo.FechaCreacion));
                oParameters.Add(new DBParametro("@idremision", DbType.Int32, oDatosEdicionRecibo.IdRemision));
                oParameters.Add(new DBParametro("@usuariocreador", DbType.String, oDatosEdicionRecibo.UsuarioCreador));
                oParameters.Add(new DBParametro("@estado", DbType.String, oDatosEdicionRecibo.Estado));
                oParameters.Add(new DBParametro("@id_recibo", DbType.Int32, oDatosEdicionRecibo.IdRecibo));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oDatosEdicionRecibo.NumRecibo));
                oParameters.Add(new DBParametro("@n_sap", DbType.String, oDatosEdicionRecibo.NSap));
                oParameters.Add(new DBParametro("@tipodecambio", DbType.Double, oDatosEdicionRecibo.TipoDeCambio));
                oParameters.Add(new DBParametro("@usado_remision", DbType.Boolean, oDatosEdicionRecibo.UsadoRemision));


                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDatosEdicionRecibo, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.DatosEdicionRecibo
        /// </summary>
        /// <param name="oDatosEdicionRecibo"></param>
        /// <returns></returns>
        public void Insert(DatosEdicionRecibo oDatosEdicionRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_DatosEdicionRecibo_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@fechacreacion", DbType.DateTime, oDatosEdicionRecibo.FechaCreacion));
                oParameters.Add(new DBParametro("@idremision", DbType.Int32, oDatosEdicionRecibo.IdRemision));
                oParameters.Add(new DBParametro("@usuariocreador", DbType.String, oDatosEdicionRecibo.UsuarioCreador));
                oParameters.Add(new DBParametro("@estado", DbType.String, oDatosEdicionRecibo.Estado));
                oParameters.Add(new DBParametro("@id_recibo", DbType.Int32, oDatosEdicionRecibo.IdRecibo));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oDatosEdicionRecibo.NumRecibo));
                oParameters.Add(new DBParametro("@n_sap", DbType.String, oDatosEdicionRecibo.NSap));
                oParameters.Add(new DBParametro("@tipodecambio", DbType.Double, oDatosEdicionRecibo.TipoDeCambio));
                oParameters.Add(new DBParametro("@usado_remision", DbType.Boolean, oDatosEdicionRecibo.UsadoRemision));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDatosEdicionRecibo, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// DatosEdicionRecibo de la tabla dbo.DatosEdicionRecibo
        /// </summary>
        /// <param name="oDatosEdicionRecibo"></param>
        /// <returns></returns>
        public List<DatosEdicionRecibo> GetAllDatosEdicionRecibos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_DatosEdicionRecibo_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<DatosEdicionRecibo> datosedicionrecibos = AbstractFindAll(oParameters);

                return datosedicionrecibos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDatosEdicionRecibo, getDatosEdicionRecibos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<DatosEdicionRecibo> GetAllDatosEdicionRecibosPorNumeroRemision(int idRemision)
        {
            try
            {
                CommandText = "PA_MG_FRONT_EdicionRecibo_SelectALLPorIdRemision";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idRemision", DbType.Int32, idRemision));
                List<DatosEdicionRecibo> datosedicionrecibos = AbstractFindAll(oParameters);

                return datosedicionrecibos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDatosEdicionRecibo, GetAllDatosEdicionRecibosPorNumeroRemision", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<DatosEdicionRecibo> GetAllDatosEdicionRecibosPorNumeroRecibo(string numRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_EdicionRecibo_SelectALLPorNumRecibo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@numRecibo", DbType.String, numRecibo));
                List<DatosEdicionRecibo> datosedicionrecibos = AbstractFindAll(oParameters);

                return datosedicionrecibos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDatosEdicionRecibo, GetAllDatosEdicionRecibosPorNumeroRecibo", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que crea un objeto DatosEdicionRecibo de la tabla dbo.DatosEdicionRecibo
        /// </summary>
        /// <param name="oDatosEdicionRecibo"></param>
        /// <returns></returns>
        public override DatosEdicionRecibo DoLoad(IDataReader registros)
        {
            try
            {
                DatosEdicionRecibo datosedicionrecibo = new DatosEdicionRecibo();
                datosedicionrecibo.FechaCreacion = registros.GetDateTime(0);
                datosedicionrecibo.IdRemision = registros.GetInt32(1);
                datosedicionrecibo.UsuarioCreador = registros.GetString(2);
                datosedicionrecibo.Estado = registros.GetString(3);
                datosedicionrecibo.IdRecibo = registros.GetInt32(4);
                datosedicionrecibo.NumRecibo = registros.GetString(5);
                datosedicionrecibo.NSap = registros.GetString(6);
                datosedicionrecibo.TipoDeCambio = registros.GetDouble(7);
                datosedicionrecibo.UsadoRemision = registros.GetBoolean(8);
                datosedicionrecibo.IdDeudor = registros.GetInt32(9);
                datosedicionrecibo.NombreDeudor = registros.GetString(10);
                datosedicionrecibo.IdCliente = registros.GetInt32(11);
                datosedicionrecibo.NombreCliente = registros.GetString(12);
                try
                {
                    datosedicionrecibo.CuitCliente = registros.GetString(13);
                }
                catch (Exception)
                {

                    datosedicionrecibo.CuitCliente = string.Empty;
                }
                


                return datosedicionrecibo;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDatosEdicionRecibo, getDatosEdicionRecibos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override DatosEdicionRecibo DoLoad(IDataReader registros, DatosEdicionRecibo ent)
        {
            throw new NotImplementedException();
        }
    }
}
