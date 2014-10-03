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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Deudor_Dia_Reclamo
    /// </summary>
    public class DALDeudorDiaReclamo : AbstractMapper<DeudorDiaReclamo>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALDeudorDiaReclamo()
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
        ~DALDeudorDiaReclamo()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  DeudorDiaReclamo
        /// </summary>
        /// <param name="idDiaReclamo"></param>     
        /// <returns></returns>
        public DeudorDiaReclamo Load(int idDiaReclamo)
        {
            try
            {
                DeudorDiaReclamo oReturn = null;
                CommandText = "PA_MG_FRONT_Deudor_Dia_Reclamo_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_reclamo", DbType.Int32, idDiaReclamo));

                List<DeudorDiaReclamo> deudordiareclamos = AbstractFindAll(oParameters);
                if (deudordiareclamos.Count > 0)
                {
                    oReturn = deudordiareclamos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaReclamo, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Deudor_Dia_Reclamo
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        /// <returns></returns>
        public void Delete(DeudorDiaReclamo oDeudorDiaReclamo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Reclamo_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_reclamo", DbType.Int32, oDeudorDiaReclamo.IdDiaReclamo));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaReclamo, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Deudor_Dia_Reclamo
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        /// <returns></returns>
        public void Update(DeudorDiaReclamo oDeudorDiaReclamo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Reclamo_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_reclamo", DbType.Int32, oDeudorDiaReclamo.IdDiaReclamo));
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDeudorDiaReclamo.IdDeudor));
                oParameters.Add(new DBParametro("@id_dia", DbType.Int32, oDeudorDiaReclamo.IdDia));
                oParameters.Add(new DBParametro("@horario_desde", DbType.String, oDeudorDiaReclamo.HorarioDesde));
                oParameters.Add(new DBParametro("@horario_hasta", DbType.String, oDeudorDiaReclamo.HorarioHasta));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaReclamo, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Deudor_Dia_Reclamo
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        /// <returns></returns>
        public void Insert(DeudorDiaReclamo oDeudorDiaReclamo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Reclamo_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_reclamo", DbType.Int32, oDeudorDiaReclamo.IdDiaReclamo));
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDeudorDiaReclamo.IdDeudor));
                oParameters.Add(new DBParametro("@id_dia", DbType.Int32, oDeudorDiaReclamo.IdDia));
                oParameters.Add(new DBParametro("@horario_desde", DbType.String, oDeudorDiaReclamo.HorarioDesde));
                oParameters.Add(new DBParametro("@horario_hasta", DbType.String, oDeudorDiaReclamo.HorarioHasta));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaReclamo, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// DeudorDiaReclamo de la tabla dbo.TBL_Deudor_Dia_Reclamo
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        /// <returns></returns>
        public List<DeudorDiaReclamo> GetAllDeudorDiaReclamo(int id_deudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Reclamo_SelectALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, id_deudor));

                List<DeudorDiaReclamo> deudordiareclamos = AbstractFindAll(oParameters);

                return deudordiareclamos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaReclamo, getDeudorDiaReclamos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto DeudorDiaReclamo de la tabla dbo.TBL_Deudor_Dia_Reclamo
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        /// <returns></returns>
        public override DeudorDiaReclamo DoLoad(IDataReader registros)
        {
            try
            {
                DeudorDiaReclamo deudordiareclamo = new DeudorDiaReclamo();
                deudordiareclamo.IdDiaReclamo = registros.GetInt32(0);
                deudordiareclamo.IdDeudor = registros.GetInt32(1);
                deudordiareclamo.IdDia = registros.GetInt32(2);
                deudordiareclamo.HorarioDesde = registros.GetString(3);
                deudordiareclamo.HorarioHasta = registros.GetString(4);

                return deudordiareclamo;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaReclamo, getDeudorDiaReclamos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override DeudorDiaReclamo DoLoad(IDataReader registros, DeudorDiaReclamo ent)
        {
            throw new NotImplementedException();
        }
    }
}
