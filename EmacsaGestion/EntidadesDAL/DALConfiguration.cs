using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Herramientas;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.CFG_Application
    /// </summary>
    public class DALConfiguration : AbstractMapper<Configuration>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALConfiguration()
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
        ~DALConfiguration()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Configuration
        /// </summary>
        /// <param name="idConfiguracion"></param>   
        /// <returns></returns>
        public Configuration Load(short idConfiguracion)
        {
            try
            {
                Configuration oReturn = null;
                //CommandText = "PA_GOBBI_Configuration_SELECT";
                CommandText = "PA_MG_FRONT_CFG_Application_Select";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_configuracion", DbType.Int16, idConfiguracion));

                List<Configuration> configurations = AbstractFindAll(oParameters);
                if (configurations.Count > 0)
                {
                    oReturn = configurations[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALConfiguration, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.CFG_Application
        /// </summary>
        /// <param name="oConfiguration"></param>
        /// <returns></returns>
        public void Delete(Configuration oConfiguration)
        {
            try
            {
                //CommandText = "PA_GOBBI_Configuration_DELETE";
                CommandText = "PA_MG_FRONT_CFG_Application_Delete";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_configuracion", DbType.Int16, oConfiguration.IdConfiguracion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALConfiguration, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.CFG_Application
        /// </summary>
        /// <param name="oConfiguration"></param>
        /// <returns></returns>
        public void Update(Configuration oConfiguration)
        {
            try
            {
                //CommandText = "PA_GOBBI_Configuration_UPDATE";
                CommandText = "PA_MG_FRONT_CFG_Application_Update";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_configuracion", DbType.Int16, oConfiguration.IdConfiguracion));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oConfiguration.Nombre));
                oParameters.Add(new DBParametro("@valor", DbType.String, oConfiguration.Valor));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALConfiguration, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.CFG_Application
        /// </summary>
        /// <param name="oConfiguration"></param>
        /// <returns></returns>
        public void Insert(Configuration oConfiguration)
        {
            try
            {
                //CommandText = "PA_GOBBI_Configuration_INSERT";
                CommandText = "PA_MG_FRONT_CFG_Application_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_configuracion", DbType.Int16, oConfiguration.IdConfiguracion));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oConfiguration.Nombre));
                oParameters.Add(new DBParametro("@valor", DbType.String, oConfiguration.Valor));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALConfiguration, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Configuration de la tabla dbo.CFG_Application
        /// </summary>
        /// <param name="oConfiguration"></param>
        /// <returns></returns>
        public List<Configuration> GetAllConfigurations()
        {
            try
            {
                //CommandText = "PA_GOBBI_Configuration_SELECTALL";
                CommandText = "PA_MG_FRONT_CFG_Application_SelectALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Configuration> configurations = AbstractFindAll(oParameters);

                return configurations;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALConfiguration, getConfigurations", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Configuration de la tabla dbo.CFG_Application
        /// </summary>
        /// <param name="oConfiguration"></param>
        /// <returns></returns>
        public override Configuration DoLoad(IDataReader registros)
        {
            try
            {
                Configuration configuration = new Configuration();
                configuration.IdConfiguracion = registros.GetInt16(0);
                configuration.Nombre = registros.GetString(1);
                configuration.Valor = registros.GetString(2);

                return configuration;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALConfiguration, getConfigurations", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Configuration DoLoad(IDataReader registros, Configuration ent)
        {
            throw new NotImplementedException();
        }
    }
}
