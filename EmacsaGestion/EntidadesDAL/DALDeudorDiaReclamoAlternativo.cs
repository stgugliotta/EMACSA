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
    public class DALDeudorDiaReclamoAlternativo : AbstractMapper<DeudorDiaReclamoAlternativo>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALDeudorDiaReclamoAlternativo()
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
        ~DALDeudorDiaReclamoAlternativo()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  DeudorDiaReclamo
        /// </summary>
        /// <param name="idDiaReclamo"></param>     
        /// <returns></returns>
        public DeudorDiaReclamoAlternativo Load(int idDiaReclamo)
        {
            try
            {
                DeudorDiaReclamoAlternativo oReturn = null;
                CommandText = "PA_MG_FRONT_Deudor_Dia_Reclamo_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_reclamo", DbType.Int32, idDiaReclamo));

                List<DeudorDiaReclamoAlternativo> deudordiareclamos = AbstractFindAll(oParameters);
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
        public void Delete(DeudorDiaReclamoAlternativo oDeudorDiaReclamo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Cobro_Alternativo_Delete";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDeudorDiaReclamo.IdDeudor ));
                oParameters.Add(new DBParametro("@horario_desde", DbType.String , oDeudorDiaReclamo.HorarioDesde ));
                oParameters.Add(new DBParametro("@horario_hasta", DbType.String , oDeudorDiaReclamo.HorarioHasta ));

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
        public void Update(DeudorDiaReclamoAlternativo oDeudorDiaReclamo)
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
        public void Insert(DeudorDiaReclamoAlternativo oDeudorDiaReclamo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Cobro_Alternativo_INSERT";
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
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Deudor_Dia_Reclamo
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        /// <returns></returns>
        public void InsertHorarioAlterntivoDeCobro(DeudorDiaReclamoAlternativo oDeudorDiaReclamo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Horario_Alternativo_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDeudorDiaReclamo.IdDeudor));
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
        public List<DeudorDiaReclamoAlternativo> GetAllDeudorDiaReclamoAlternativo(int id_deudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Reclamo_Alternativo_SelectALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, id_deudor));

                List<DeudorDiaReclamoAlternativo> deudordiareclamos = AbstractFindAll(oParameters);

                return deudordiareclamos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaReclamoAlternativo, GetAllDeudorDiaReclamoAlternativo", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto DeudorDiaReclamo de la tabla dbo.TBL_Deudor_Dia_Reclamo
        /// </summary>
        /// <param name="oDeudorDiaReclamo"></param>
        /// <returns></returns>
        public override DeudorDiaReclamoAlternativo DoLoad(IDataReader registros)
        {
            try
            {
                DeudorDiaReclamoAlternativo deudordiareclamo = new DeudorDiaReclamoAlternativo();
                deudordiareclamo.IdDiaReclamo = registros.GetInt32(0);
                deudordiareclamo.IdDeudor = registros.GetInt32(1);
                deudordiareclamo.IdDia = registros.GetInt32(2);
                deudordiareclamo.HorarioDesde = registros.GetString(3);
                deudordiareclamo.HorarioHasta = registros.GetString(4);
                deudordiareclamo.IdAccion = registros.GetInt32(5);

                return deudordiareclamo;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaReclamo, getDeudorDiaReclamos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override DeudorDiaReclamoAlternativo DoLoad(IDataReader registros, DeudorDiaReclamoAlternativo ent)
        {
            throw new NotImplementedException();
        }
    }
}
