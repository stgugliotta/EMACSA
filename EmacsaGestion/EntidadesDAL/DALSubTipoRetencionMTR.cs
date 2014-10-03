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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_SubTipoRetencion
    /// </summary>
    public class DALSubTipoRetencionMTR : AbstractMapper<SubTipoRetencionMTR>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALSubTipoRetencionMTR()
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
        ~DALSubTipoRetencionMTR()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  SubTipoRetencionMTR
        /// </summary>

        /// <returns></returns>
        public SubTipoRetencionMTR Load()
        {
            try
            {
                SubTipoRetencionMTR oReturn = null;
                CommandText = "PA_MG_FRONT_SubTipoRetencionMTR_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                List<SubTipoRetencionMTR> subtiporetencionmtrs = AbstractFindAll(oParameters);
                if (subtiporetencionmtrs.Count > 0)
                {
                    oReturn = subtiporetencionmtrs[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALSubTipoRetencionMTR, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_SubTipoRetencion
        /// </summary>
        /// <param name="oSubTipoRetencionMTR"></param>
        /// <returns></returns>
        public void Delete(SubTipoRetencionMTR oSubTipoRetencionMTR)
        {
            try
            {
                CommandText = "PA_MG_FRONT_SubTipoRetencionMTR_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();



                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALSubTipoRetencionMTR, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_SubTipoRetencion
        /// </summary>
        /// <param name="oSubTipoRetencionMTR"></param>
        /// <returns></returns>
        public void Update(SubTipoRetencionMTR oSubTipoRetencionMTR)
        {
            try
            {
                CommandText = "PA_MG_FRONT_SubTipoRetencionMTR_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oSubTipoRetencionMTR.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oSubTipoRetencionMTR.Descripcion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALSubTipoRetencionMTR, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_SubTipoRetencion
        /// </summary>
        /// <param name="oSubTipoRetencionMTR"></param>
        /// <returns></returns>
        public void Insert(SubTipoRetencionMTR oSubTipoRetencionMTR)
        {
            try
            {
                CommandText = "PA_MG_FRONT_SubTipoRetencionMTR_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oSubTipoRetencionMTR.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oSubTipoRetencionMTR.Descripcion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALSubTipoRetencionMTR, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// SubTipoRetencionMTR de la tabla dbo.MTR_SubTipoRetencion
        /// </summary>
        /// <param name="oSubTipoRetencionMTR"></param>
        /// <returns></returns>
        public List<SubTipoRetencionMTR> GetAllSubTipoRetencionMTRs()
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_SubTipoRetencion_SelectALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<SubTipoRetencionMTR> subtiporetencionmtrs = AbstractFindAll(oParameters);

                return subtiporetencionmtrs;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALSubTipoRetencionMTR, getSubTipoRetencionMTRs", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto SubTipoRetencionMTR de la tabla dbo.MTR_SubTipoRetencion
        /// </summary>
        /// <param name="oSubTipoRetencionMTR"></param>
        /// <returns></returns>
        public override SubTipoRetencionMTR DoLoad(IDataReader registros)
        {
            try
            {
                SubTipoRetencionMTR subtiporetencionmtr = new SubTipoRetencionMTR();
                subtiporetencionmtr.Id = registros.GetInt32(0);
                subtiporetencionmtr.Descripcion = registros.GetString(1);

                return subtiporetencionmtr;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALSubTipoRetencionMTR, getSubTipoRetencionMTRs", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override SubTipoRetencionMTR DoLoad(IDataReader registros, SubTipoRetencionMTR ent)
        {
            throw new NotImplementedException();
        }
    }
}
