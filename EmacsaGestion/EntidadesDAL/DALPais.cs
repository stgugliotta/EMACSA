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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Pais
	/// </summary>
    public class DALPais : AbstractMapper<Pais>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALPais()
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
		~DALPais()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Pais
		/// </summary>
		/// <param name="id"></param>  
		/// <returns></returns>
		public Pais Load(int id)
		{
            try
            {
				Pais oReturn = null;
				CommandText = "PA_MG_FRONT_Pais_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Pais> paiss = AbstractFindAll(oParameters);
				if (paiss.Count > 0)
				{
					oReturn = paiss[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALPais, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Pais
		/// </summary>
		/// <param name="oPais"></param>
		/// <returns></returns>
		public void Delete(Pais oPais)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Pais_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPais.ID));		
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALPais, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Pais
		/// </summary>
		/// <param name="oPais"></param>
		/// <returns></returns>
		public void Update(Pais oPais)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Pais_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPais.ID));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oPais.Nombre));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALPais, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Pais
		/// </summary>
		/// <param name="oPais"></param>
		/// <returns></returns>
		public void Insert(Pais oPais)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Pais_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPais.ID));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oPais.Nombre));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALPais, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Pais de la tabla dbo.TBL_Pais
		/// </summary>
		/// <param name="oPais"></param>
		/// <returns></returns>
		public List<Pais> GetAllPaiss()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Pais_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Pais> paiss = AbstractFindAll(oParameters);
				
				return paiss;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALPais, getPaiss", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Pais de la tabla dbo.TBL_Pais
		/// </summary>
		/// <param name="oPais"></param>
		/// <returns></returns>
		public override Pais DoLoad(IDataReader registros)
        {
            try
            {
				Pais pais = new Pais();
				pais.ID = registros.GetInt32(0);
				pais.Nombre = registros.GetString(1);
			
				return pais;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALPais, getPaiss", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Pais DoLoad(IDataReader registros, Pais ent)
        {
            throw new NotImplementedException();
        }
    }
}
