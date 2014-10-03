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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Cliente_Cuenta
    /// </summary>
    public class DALClienteCuenta : AbstractMapper<ClienteCuenta>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALClienteCuenta()
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
        ~DALClienteCuenta()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  ClienteCuenta
        /// </summary>
        /// <param name="id"></param>     
        /// <returns></returns>
        public ClienteCuenta Load(int id)
        {
            try
            {
                ClienteCuenta oReturn = null;
                CommandText = "PA_MG_FRONT_Cliente_Cuenta_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<ClienteCuenta> clientecuentas = AbstractFindAll(oParameters);
                if (clientecuentas.Count > 0)
                {
                    oReturn = clientecuentas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALClienteCuenta, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Cliente_Cuenta
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        /// <returns></returns>
        public void Delete(ClienteCuenta oClienteCuenta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_Cuenta_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oClienteCuenta.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALClienteCuenta, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Cliente_Cuenta
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        /// <returns></returns>
        public void Update(ClienteCuenta oClienteCuenta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_Cuenta_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oClienteCuenta.Id));
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oClienteCuenta.IdCliente));
                oParameters.Add(new DBParametro("@nombrecliente", DbType.String, oClienteCuenta.NombreCliente));
                oParameters.Add(new DBParametro("@cuenta", DbType.String, oClienteCuenta.Cuenta));
                oParameters.Add(new DBParametro("@habilitada", DbType.Boolean, oClienteCuenta.Habilitada));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALClienteCuenta, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Cliente_Cuenta
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        /// <returns></returns>
        public void Insert(ClienteCuenta oClienteCuenta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_Cuenta_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oClienteCuenta.Id));
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oClienteCuenta.IdCliente));
                oParameters.Add(new DBParametro("@nombrecliente", DbType.String, oClienteCuenta.NombreCliente));
                oParameters.Add(new DBParametro("@cuenta", DbType.String, oClienteCuenta.Cuenta));
                oParameters.Add(new DBParametro("@habilitada", DbType.Boolean, oClienteCuenta.Habilitada));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALClienteCuenta, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ClienteCuenta de la tabla dbo.TBL_Cliente_Cuenta
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        /// <returns></returns>
        public List<ClienteCuenta> GetAllClienteCuentas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_Cuenta_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<ClienteCuenta> clientecuentas = AbstractFindAll(oParameters);

                return clientecuentas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALClienteCuenta, getClienteCuentas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        
        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ClienteCuenta de la tabla dbo.TBL_Cliente_Cuenta
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        /// <returns></returns>
        public List<ClienteCuenta> GetAllClienteCuentasByIdCliente(int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_Cuenta_SELECTALL_ByIdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                List<ClienteCuenta> clientecuentas = AbstractFindAll(oParameters);

                return clientecuentas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALClienteCuenta, getClienteCuentas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        
        




        /// <summary>
        /// M?todo que crea un objeto ClienteCuenta de la tabla dbo.TBL_Cliente_Cuenta
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        /// <returns></returns>
        public override ClienteCuenta DoLoad(IDataReader registros)
        {
            try
            {
                ClienteCuenta clientecuenta = new ClienteCuenta();
                clientecuenta.Id = registros.GetInt32(0);
                clientecuenta.IdCliente = registros.GetInt32(1);
                clientecuenta.NombreCliente = registros.GetString(2);
                clientecuenta.Cuenta = registros.GetString(3);
                clientecuenta.Habilitada = registros.GetBoolean(4);

                return clientecuenta;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALClienteCuenta, getClienteCuentas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override ClienteCuenta DoLoad(IDataReader registros, ClienteCuenta ent)
        {
            throw new NotImplementedException();
        }
    }
}
