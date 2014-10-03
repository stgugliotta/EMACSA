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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Dias
    /// </summary>
    public class DALDias : AbstractMapper<Dias>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALDias()
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
        ~DALDias()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Dias
        /// </summary>
        /// <param name="idDia"></param>  
        /// <returns></returns>
        public Dias Load(int idDia)
        {
            try
            {
                Dias oReturn = null;
                CommandText = "PA_MG_FRONT_Dias_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia", DbType.Int32, idDia));

                List<Dias> diass = AbstractFindAll(oParameters);
                if (diass.Count > 0)
                {
                    oReturn = diass[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDias, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Dias
        /// </summary>
        /// <param name="oDias"></param>
        /// <returns></returns>
        public void Delete(Dias oDias)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Dias_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia", DbType.Int32, oDias.IdDia));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDias, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Dias
        /// </summary>
        /// <param name="oDias"></param>
        /// <returns></returns>
        public void Update(Dias oDias)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Dias_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia", DbType.Int32, oDias.IdDia));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oDias.Descripcion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDias, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Dias
        /// </summary>
        /// <param name="oDias"></param>
        /// <returns></returns>
        public void Insert(Dias oDias)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Dias_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_dia", DbType.Int32, oDias.IdDia));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oDias.Descripcion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDias, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Dias de la tabla dbo.TBL_Dias
        /// </summary>
        /// <param name="oDias"></param>
        /// <returns></returns>
        public List<Dias> GetAllDiass()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Dias_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Dias> diass = AbstractFindAll(oParameters);

                return diass;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDias, getDiass", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Dias de la tabla dbo.TBL_Dias
        /// </summary>
        /// <param name="oDias"></param>
        /// <returns></returns>
        public override Dias DoLoad(IDataReader registros)
        {
            try
            {
                Dias dias = new Dias();
                dias.IdDia = registros.GetInt32(0);
                dias.Descripcion = registros.GetString(1);

                return dias;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDias, getDiass", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Dias DoLoad(IDataReader registros, Dias ent)
        {
            throw new NotImplementedException();
        }
    }
}
