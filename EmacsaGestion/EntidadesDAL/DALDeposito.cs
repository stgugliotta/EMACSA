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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Deposito
	/// </summary>
    public class DALDeposito : AbstractMapper<Deposito>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALDeposito()
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
		~DALDeposito()
        {
           // ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Deposito
		/// </summary>
		/// <param name="id"></param>     
		/// <returns></returns>
		public Deposito Load(int id)
		{
            try
            {
				Deposito oReturn = null;
				CommandText = "PA_MG_FRONT_Deposito_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Deposito> depositos = AbstractFindAll(oParameters);
				if (depositos.Count > 0)
				{
					oReturn = depositos[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeposito, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Deposito
		/// </summary>
		/// <param name="oDeposito"></param>
		/// <returns></returns>
		public void Delete(Deposito oDeposito)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Deposito_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDeposito.Id));					
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeposito, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Deposito
		/// </summary>
		/// <param name="oDeposito"></param>
		/// <returns></returns>
		public void Update(Deposito oDeposito)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Deposito_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDeposito.Id));
				oParameters.Add(new DBParametro("@idcuenta", DbType.String, oDeposito.IdCuenta));
				oParameters.Add(new DBParametro("@fechadeposito", DbType.DateTime, oDeposito.FechaDeposito));
				oParameters.Add(new DBParametro("@numcomprobante", DbType.String, oDeposito.NumComprobante));
				oParameters.Add(new DBParametro("@importe", DbType.Double, oDeposito.Importe));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeposito, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Deposito
		/// </summary>
		/// <param name="oDeposito"></param>
		/// <returns></returns>
		public void Insert(Deposito oDeposito)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Deposito_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDeposito.Id));
				oParameters.Add(new DBParametro("@idcuenta", DbType.String, oDeposito.IdCuenta));
				oParameters.Add(new DBParametro("@fechadeposito", DbType.DateTime, oDeposito.FechaDeposito));
				oParameters.Add(new DBParametro("@numcomprobante", DbType.String, oDeposito.NumComprobante));
				oParameters.Add(new DBParametro("@importe", DbType.Double, oDeposito.Importe));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeposito, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}



        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla TBL_Deposito
        /// </summary>
        /// <param name="oCheque"></param>
        /// <returns></returns>
        public int InsertEscalar(Deposito oDeposito)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Deposito_Escalar_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, null));
                oParameters.Add(new DBParametro("@idCuenta", DbType.String, oDeposito.IdCuenta));
                oParameters.Add(new DBParametro("@fechaDeposito", DbType.DateTime, oDeposito.FechaDeposito));
                oParameters.Add(new DBParametro("@numComprobante", DbType.String, oDeposito.NumComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oDeposito.Importe));


                return int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeposito, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Deposito de la tabla dbo.TBL_Deposito
		/// </summary>
		/// <param name="oDeposito"></param>
		/// <returns></returns>
		public List<Deposito> GetAllDepositos()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Deposito_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Deposito> depositos = AbstractFindAll(oParameters);
				
				return depositos;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeposito, getDepositos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Deposito de la tabla dbo.TBL_Deposito
		/// </summary>
		/// <param name="oDeposito"></param>
		/// <returns></returns>
		public override Deposito DoLoad(IDataReader registros)
        {
            try
            {
				Deposito deposito = new Deposito();
				deposito.Id = registros.GetInt32(0);
				deposito.IdCuenta = registros.GetString(1);
				deposito.FechaDeposito = registros.GetDateTime(2);
				deposito.NumComprobante = registros.GetString(3);
				deposito.Importe = registros.GetDouble(4);
			
				return deposito;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeposito, getDepositos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Deposito DoLoad(IDataReader registros, Deposito ent)
        {
            throw new NotImplementedException();
        }
    }
}
