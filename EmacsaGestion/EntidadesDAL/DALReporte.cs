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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Reporte
    /// </summary>
    public class DALReporte : AbstractMapper<Reporte>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALReporte()
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
        ~DALReporte()
        {
            //ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Reporte
        /// </summary>
        /// <param name="id"></param>       
        /// <returns></returns>
        public Reporte Load(int id)
        {
            try
            {
                Reporte oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Reporte_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<Reporte> reportes = AbstractFindAll(oParameters);
                if (reportes.Count > 0)
                {
                    oReturn = reportes[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReporte, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Reporte
        /// </summary>
        /// <param name="oReporte"></param>
        /// <returns></returns>
        public void Delete(Reporte oReporte)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Reporte_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReporte.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReporte, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Reporte
        /// </summary>
        /// <param name="oReporte"></param>
        /// <returns></returns>
        public void Update(Reporte oReporte)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Reporte_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReporte.Id));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oReporte.Nombre));
                oParameters.Add(new DBParametro("@urlcomun", DbType.String, oReporte.UrlComun));
                oParameters.Add(new DBParametro("@directorio", DbType.String, oReporte.Directorio));
                oParameters.Add(new DBParametro("@adicional", DbType.String, oReporte.Adicional));
                oParameters.Add(new DBParametro("@activo", DbType.Boolean, oReporte.Activo));
                oParameters.Add(new DBParametro("@nombrefisico", DbType.String, oReporte.NombreFisico));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReporte, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Reporte
        /// </summary>
        /// <param name="oReporte"></param>
        /// <returns></returns>
        public void Insert(Reporte oReporte)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Reporte_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReporte.Id));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oReporte.Nombre));
                oParameters.Add(new DBParametro("@urlcomun", DbType.String, oReporte.UrlComun));
                oParameters.Add(new DBParametro("@directorio", DbType.String, oReporte.Directorio));
                oParameters.Add(new DBParametro("@adicional", DbType.String, oReporte.Adicional));
                oParameters.Add(new DBParametro("@activo", DbType.Boolean, oReporte.Activo));
                oParameters.Add(new DBParametro("@nombrefisico", DbType.String, oReporte.NombreFisico));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReporte, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Reporte de la tabla dbo.MTR_Reporte
        /// </summary>
        /// <param name="oReporte"></param>
        /// <returns></returns>
        public List<Reporte> GetAllReportes()
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Reporte_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Reporte> reportes = AbstractFindAll(oParameters);

                return reportes;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReporte, getReportes", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Reporte de la tabla dbo.MTR_Reporte
        /// </summary>
        /// <param name="oReporte"></param>
        /// <returns></returns>
        public override Reporte DoLoad(IDataReader registros)
        {
            try
            {
                Reporte reporte = new Reporte();
                reporte.Id =short.Parse( registros.GetInt32(0).ToString());
                reporte.Nombre = registros.GetString(1);
                reporte.UrlComun = registros.GetString(2);
                reporte.Directorio = registros.GetString(3);
                reporte.Adicional = registros.GetString(4);
                reporte.Activo = registros.GetBoolean(5);
                reporte.NombreFisico = registros.GetString(6);
                reporte.Ubicacion = registros.GetString(7);


                return reporte;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReporte, getReportes", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Reporte DoLoad(IDataReader registros, Reporte ent)
        {
            throw new NotImplementedException();
        }
    }
}
