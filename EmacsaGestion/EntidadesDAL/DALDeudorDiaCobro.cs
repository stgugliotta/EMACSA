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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Deudor_Dia_Cobro
    /// </summary>
    public class DALDeudorDiaCobro : AbstractMapper<DeudorDiaCobro>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALDeudorDiaCobro()
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
        ~DALDeudorDiaCobro()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  DeudorDiaCobro
        /// </summary>
        /// <param name="idDiaCobro"></param>     
        /// <returns></returns>
        public DeudorDiaCobro Load(int idDiaCobro)
        {
            try
            {
                DeudorDiaCobro oReturn = null;
                CommandText = "PA_MG_FRONT_Deudor_Dia_Cobro_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_cobro", DbType.Int32, idDiaCobro));

                List<DeudorDiaCobro> deudordiacobros = AbstractFindAll(oParameters);
                if (deudordiacobros.Count > 0)
                {
                    oReturn = deudordiacobros[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaCobro, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Deudor_Dia_Cobro
        /// </summary>
        /// <param name="oDeudorDiaCobro"></param>
        /// <returns></returns>
        public void Delete(DeudorDiaCobro oDeudorDiaCobro)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Cobro_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_cobro", DbType.Int32, oDeudorDiaCobro.IdDiaCobro));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaCobro, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Deudor_Dia_Cobro
        /// </summary>
        /// <param name="oDeudorDiaCobro"></param>
        /// <returns></returns>
        public void Update(DeudorDiaCobro oDeudorDiaCobro)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Cobro_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_cobro", DbType.Int32, oDeudorDiaCobro.IdDiaCobro));
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDeudorDiaCobro.IdDeudor));
                oParameters.Add(new DBParametro("@id_dia", DbType.Int32, oDeudorDiaCobro.IdDia));
                oParameters.Add(new DBParametro("@horario_desde", DbType.String, oDeudorDiaCobro.HorarioDesde));
                oParameters.Add(new DBParametro("@horario_hasta", DbType.String, oDeudorDiaCobro.HorarioHasta));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaCobro, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Deudor_Dia_Cobro
        /// </summary>
        /// <param name="oDeudorDiaCobro"></param>
        /// <returns></returns>
        public void Insert(DeudorDiaCobro oDeudorDiaCobro)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Cobro_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia_cobro", DbType.Int32, oDeudorDiaCobro.IdDiaCobro));
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDeudorDiaCobro.IdDeudor));
                oParameters.Add(new DBParametro("@id_dia", DbType.Int32, oDeudorDiaCobro.IdDia));
                oParameters.Add(new DBParametro("@horario_desde", DbType.String, oDeudorDiaCobro.HorarioDesde));
                oParameters.Add(new DBParametro("@horario_hasta", DbType.String, oDeudorDiaCobro.HorarioHasta));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaCobro, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// DeudorDiaCobro de la tabla dbo.TBL_Deudor_Dia_Cobro
        /// </summary>
        /// <param name="oDeudorDiaCobro"></param>
        /// <returns></returns>
        public List<DeudorDiaCobro> GetAllDeudorDiaCobros()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Cobro_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<DeudorDiaCobro> deudordiacobros = AbstractFindAll(oParameters);

                return deudordiacobros;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaCobro, getDeudorDiaCobros", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<DeudorDiaCobro> GetAllDeudorDiaCobrosPorIdDeudor(int id_deudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deudor_Dia_Cobro_SelectALL_PorIdDeudor";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, id_deudor));

                List<DeudorDiaCobro> deudordiacobros = AbstractFindAll(oParameters);

                return deudordiacobros;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaCobro, getDeudorDiaCobros", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto DeudorDiaCobro de la tabla dbo.TBL_Deudor_Dia_Cobro
        /// </summary>
        /// <param name="oDeudorDiaCobro"></param>
        /// <returns></returns>
        public override DeudorDiaCobro DoLoad(IDataReader registros)
        {
            try
            {
                DeudorDiaCobro deudordiacobro = new DeudorDiaCobro();
                deudordiacobro.IdDiaCobro = registros.GetInt32(0);
                deudordiacobro.IdDeudor = registros.GetInt32(1);
                deudordiacobro.IdDia = registros.GetInt32(2);
                deudordiacobro.HorarioDesde = registros.GetString(3);
                deudordiacobro.HorarioHasta = registros.GetString(4);

                return deudordiacobro;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorDiaCobro, getDeudorDiaCobros", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override DeudorDiaCobro DoLoad(IDataReader registros, DeudorDiaCobro ent)
        {
            throw new NotImplementedException();
        }
    }
}
