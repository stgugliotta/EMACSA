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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Retencion
    /// </summary>
    public class DALRetencionMTR : AbstractMapper<RetencionMTR>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALRetencionMTR()
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
        ~DALRetencionMTR()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  RetencionMTR
        /// </summary>

        /// <returns></returns>
        public RetencionMTR Load()
        {
            try
            {
                RetencionMTR oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Retencion_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                List<RetencionMTR> retencionmtrs = AbstractFindAll(oParameters);
                if (retencionmtrs.Count > 0)
                {
                    oReturn = retencionmtrs[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencionMTR, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Retencion
        /// </summary>
        /// <param name="oRetencionMTR"></param>
        /// <returns></returns>
        public void Delete(RetencionMTR oRetencionMTR)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Retencion_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencionMTR, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Retencion
        /// </summary>
        /// <param name="oRetencionMTR"></param>
        /// <returns></returns>
        public void Update(RetencionMTR oRetencionMTR)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Retencion_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oRetencionMTR.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oRetencionMTR.Descripcion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencionMTR, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Retencion
        /// </summary>
        /// <param name="oRetencionMTR"></param>
        /// <returns></returns>
        public void Insert(RetencionMTR oRetencionMTR)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Retencion_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oRetencionMTR.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oRetencionMTR.Descripcion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencionMTR, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// RetencionMTR de la tabla dbo.MTR_Retencion
        /// </summary>
        /// <param name="oRetencionMTR"></param>
        /// <returns></returns>
        public List<RetencionMTR> GetAllRetencionMTRs()
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Retencion_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<RetencionMTR> retencionmtrs = AbstractFindAll(oParameters);

                return retencionmtrs;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencionMTR, getRetencionMTRs", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto RetencionMTR de la tabla dbo.MTR_Retencion
        /// </summary>
        /// <param name="oRetencionMTR"></param>
        /// <returns></returns>
        public override RetencionMTR DoLoad(IDataReader registros)
        {
            try
            {
                RetencionMTR retencionmtr = new RetencionMTR();
                retencionmtr.Id = registros.GetInt32(0);
                retencionmtr.Descripcion = registros.GetString(1);

                return retencionmtr;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRetencionMTR, getRetencionMTRs", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override RetencionMTR DoLoad(IDataReader registros, RetencionMTR ent)
        {
            throw new NotImplementedException();
        }
    }
}
