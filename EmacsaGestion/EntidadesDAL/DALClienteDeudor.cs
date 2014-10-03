using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades;
using Herramientas;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;


namespace EntidadesDAL
{
	/// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Cliente_Deudor
	/// </summary>
    public class DALClienteDeudor : AbstractMapper<ClienteDeudor>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALClienteDeudor()
        {
            DBConnection oDbConnection  = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection; 
        }
		
		/// <summary>
        /// Destructor Standard
		/// </summary>
		~DALClienteDeudor()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  ClienteDeudor
		/// </summary>
		/// <param name="idCliente"></param> /// <param name="idDeudor"></param>  
		/// <returns></returns>
		public ClienteDeudor Load(int idCliente,int idDeudor)
		{
            try
            {
				ClienteDeudor oReturn = null;
				CommandText = "PA_MG_FRONT_Cliente_Deudor_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@idcliente", DbType.Int32, idCliente));				oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, idDeudor));
				
				List<ClienteDeudor> clientedeudors = AbstractFindAll(oParameters);
				if (clientedeudors.Count > 0)
				{
					oReturn = clientedeudors[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALClienteDeudor, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Cliente_Deudor
		/// </summary>
		/// <param name="oClienteDeudor"></param>
		/// <returns></returns>
		public void Delete(ClienteDeudor oClienteDeudor)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_Deudor_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oClienteDeudor.IdCliente));					oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oClienteDeudor.IdDeudor));		
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALClienteDeudor, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Cliente_Deudor
		/// </summary>
		/// <param name="oClienteDeudor"></param>
		/// <returns></returns>
		public void Update(ClienteDeudor oClienteDeudor)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_Deudor_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oClienteDeudor.IdCliente));
				oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oClienteDeudor.IdDeudor));
				oParameters.Add(new DBParametro("@alfanumdelcliente", DbType.String, oClienteDeudor.Alfanumdelcliente));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALClienteDeudor, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Cliente_Deudor
		/// </summary>
		/// <param name="oClienteDeudor"></param>
		/// <returns></returns>
		public void Insert(ClienteDeudor oClienteDeudor)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Cliente_Deudor_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oClienteDeudor.IdCliente));
				oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oClienteDeudor.IdDeudor));
				oParameters.Add(new DBParametro("@alfanumdelcliente", DbType.String, oClienteDeudor.Alfanumdelcliente));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALClienteDeudor, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// ClienteDeudor de la tabla dbo.TBL_Cliente_Deudor
		/// </summary>
		/// <param name="oClienteDeudor"></param>
		/// <returns></returns>
		public List<ClienteDeudor> GetAllClienteDeudors()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Cliente_Deudor_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<ClienteDeudor> clientedeudors = AbstractFindAll(oParameters);
				
				return clientedeudors;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALClienteDeudor, getClienteDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ClienteDeudor de la tabla dbo.TBL_Cliente_Deudor
        /// </summary>
        /// <param name="oClienteDeudor"></param>
        /// <returns></returns>
        public List<ClienteDeudor> GetAllClienteDeudorsByIdDeudor( int idDeudor )
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_Deudor_SelectByIdDeudor";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, idDeudor));
                List<ClienteDeudor> clientedeudors = AbstractFindAll(oParameters);

                return clientedeudors;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALClienteDeudor, GetAllClienteDeudorsByIdDeudor", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ClienteDeudor de la tabla dbo.TBL_Cliente_Deudor
        /// </summary>
        /// <param name="oClienteDeudor"></param>
        /// <returns></returns>
        public ClienteDeudor GetClienteAlfanumDelCliente(int idCliente, string alfanumDelCliente)
        {
            try
            {
                ClienteDeudor oReturn = null;
                CommandText = "PA_MG_FRONT_Cliente_Deudor_SelectByIdClienteAlfanumdelcliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@alfanumdelcliente", DbType.String, alfanumDelCliente));
                List<ClienteDeudor> clientedeudors = AbstractFindAll(oParameters);
                if (clientedeudors.Count > 0)
                {
                    oReturn = clientedeudors[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALClienteDeudor, GetClienteAlfanumDelCliente", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


		/// <summary>
        /// M?todo que crea un objeto ClienteDeudor de la tabla dbo.TBL_Cliente_Deudor
		/// </summary>
		/// <param name="oClienteDeudor"></param>
		/// <returns></returns>
		public override ClienteDeudor DoLoad(IDataReader registros)
        {
            try
            {
				ClienteDeudor clientedeudor = new ClienteDeudor();
				clientedeudor.IdCliente = registros.GetInt32(0);
				clientedeudor.IdDeudor = registros.GetInt32(1);
				clientedeudor.Alfanumdelcliente = registros.GetString(2);
			
				return clientedeudor;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALClienteDeudor, getClienteDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override ClienteDeudor DoLoad(IDataReader registros, ClienteDeudor ent)
        {
            throw new NotImplementedException();
        }
    }
}
