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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Control_Concurrencia_Remision
    /// </summary>
    public class DALControlRemisionConcurrencia : AbstractMapper<ControlRemisionConcurrencia>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALControlRemisionConcurrencia()
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
        ~DALControlRemisionConcurrencia()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  ControlRemisionConcurrencia
        /// </summary>
        /// <param name="id"></param>         
        /// <returns></returns>
        public ControlRemisionConcurrencia Load(int id)
        {
            try
            {
                ControlRemisionConcurrencia oReturn = null;
                CommandText = "PA_MG_FRONT_ControlRemisionConcurrencia_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<ControlRemisionConcurrencia> controlremisionconcurrencias = AbstractFindAll(oParameters);
                if (controlremisionconcurrencias.Count > 0)
                {
                    oReturn = controlremisionconcurrencias[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALControlRemisionConcurrencia, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Control_Concurrencia_Remision
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        /// <returns></returns>
        public void Delete(ControlRemisionConcurrencia oControlRemisionConcurrencia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Control_Concurrencia_Remision_Delete";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();


                oParameters.Add(new DBParametro("@valor", DbType.String , oControlRemisionConcurrencia.DatoBloqueado));
                oParameters.Add(new DBParametro("@session", DbType.String, oControlRemisionConcurrencia.EstadoLock));


                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALControlRemisionConcurrencia, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Control_Concurrencia_Remision
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        /// <returns></returns>
        public void Update(ControlRemisionConcurrencia oControlRemisionConcurrencia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Control_Concurrencia_Remision_Update";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oControlRemisionConcurrencia.Id));
                oParameters.Add(new DBParametro("@numremision", DbType.String, oControlRemisionConcurrencia.NumRemision));
                oParameters.Add(new DBParametro("@fechainiciolock", DbType.DateTime, oControlRemisionConcurrencia.FechaInicioLock));
                oParameters.Add(new DBParametro("@usuariolock", DbType.String, oControlRemisionConcurrencia.UsuarioLock));
                oParameters.Add(new DBParametro("@estadolock", DbType.String, oControlRemisionConcurrencia.EstadoLock));
                oParameters.Add(new DBParametro("@forceunlock", DbType.Boolean, oControlRemisionConcurrencia.ForceUnlock));
                oParameters.Add(new DBParametro("@usuarioforceunlock", DbType.String, oControlRemisionConcurrencia.UsuarioForceUnlock));
                oParameters.Add(new DBParametro("@fechaforceunlock", DbType.DateTime, oControlRemisionConcurrencia.FechaForceUnlock));
                oParameters.Add(new DBParametro("@datobloqueado", DbType.String, oControlRemisionConcurrencia.DatoBloqueado));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALControlRemisionConcurrencia, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Control_Concurrencia_Remision
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        /// <returns></returns>
        public void Insert(ControlRemisionConcurrencia oControlRemisionConcurrencia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Control_Concurrencia_Remision_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oControlRemisionConcurrencia.Id));
                oParameters.Add(new DBParametro("@numremision", DbType.String, oControlRemisionConcurrencia.NumRemision));
                oParameters.Add(new DBParametro("@fechainiciolock", DbType.DateTime, oControlRemisionConcurrencia.FechaInicioLock));
                oParameters.Add(new DBParametro("@usuariolock", DbType.String, oControlRemisionConcurrencia.UsuarioLock));
                oParameters.Add(new DBParametro("@estadolock", DbType.String, oControlRemisionConcurrencia.EstadoLock));
                oParameters.Add(new DBParametro("@forceunlock", DbType.Boolean, oControlRemisionConcurrencia.ForceUnlock));
                oParameters.Add(new DBParametro("@usuarioforceunlock", DbType.String, oControlRemisionConcurrencia.UsuarioForceUnlock));
                oParameters.Add(new DBParametro("@fechaforceunlock", DbType.DateTime, oControlRemisionConcurrencia.FechaForceUnlock));
                oParameters.Add(new DBParametro("@datobloqueado", DbType.String, oControlRemisionConcurrencia.DatoBloqueado));

                

                this.ExecuteReaderOnlyString(oParameters);
                
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALControlRemisionConcurrencia, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public string InsertWithResult(ControlRemisionConcurrencia oControlRemisionConcurrencia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Control_Concurrencia_Remision_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oControlRemisionConcurrencia.Id));
                oParameters.Add(new DBParametro("@numremision", DbType.String, oControlRemisionConcurrencia.NumRemision));
                oParameters.Add(new DBParametro("@fechainiciolock", DbType.DateTime, oControlRemisionConcurrencia.FechaInicioLock));
                oParameters.Add(new DBParametro("@usuariolock", DbType.String, oControlRemisionConcurrencia.UsuarioLock));
                oParameters.Add(new DBParametro("@estadolock", DbType.String, oControlRemisionConcurrencia.EstadoLock));
                oParameters.Add(new DBParametro("@forceunlock", DbType.Boolean, oControlRemisionConcurrencia.ForceUnlock));
                oParameters.Add(new DBParametro("@usuarioforceunlock", DbType.String, oControlRemisionConcurrencia.UsuarioForceUnlock));
                oParameters.Add(new DBParametro("@fechaforceunlock", DbType.DateTime, oControlRemisionConcurrencia.FechaForceUnlock));
                oParameters.Add(new DBParametro("@datobloqueado", DbType.String, oControlRemisionConcurrencia.DatoBloqueado));



                return (string)this.ExecuteReaderOnlyString(oParameters);

            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALControlRemisionConcurrencia, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ControlRemisionConcurrencia de la tabla dbo.TBL_Control_Concurrencia_Remision
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        /// <returns></returns>
        public List<ControlRemisionConcurrencia> GetAllControlRemisionConcurrencias()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Control_Concurrencia_Remision_SelectALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<ControlRemisionConcurrencia> controlremisionconcurrencias = AbstractFindAll(oParameters);

                return controlremisionconcurrencias;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALControlRemisionConcurrencia, getControlRemisionConcurrencias", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto ControlRemisionConcurrencia de la tabla dbo.TBL_Control_Concurrencia_Remision
        /// </summary>
        /// <param name="oControlRemisionConcurrencia"></param>
        /// <returns></returns>
        public override ControlRemisionConcurrencia DoLoad(IDataReader registros)
        {
            try
            {
                ControlRemisionConcurrencia controlremisionconcurrencia = new ControlRemisionConcurrencia();
                controlremisionconcurrencia.Id = registros.GetInt32(0);
                controlremisionconcurrencia.NumRemision = registros.GetString(1);
                controlremisionconcurrencia.FechaInicioLock = registros.GetDateTime(2);
                controlremisionconcurrencia.UsuarioLock = registros.GetString(3);
                controlremisionconcurrencia.EstadoLock = registros.GetString(4);
                controlremisionconcurrencia.ForceUnlock = registros.GetBoolean(5);
                controlremisionconcurrencia.UsuarioForceUnlock = registros.GetString(6);
                controlremisionconcurrencia.FechaForceUnlock = registros.GetDateTime(7);
                controlremisionconcurrencia.DatoBloqueado = registros.GetString(8);

                return controlremisionconcurrencia;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALControlRemisionConcurrencia, getControlRemisionConcurrencias", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override ControlRemisionConcurrencia DoLoad(IDataReader registros, ControlRemisionConcurrencia ent)
        {
            throw new NotImplementedException();
        }
    }
}
