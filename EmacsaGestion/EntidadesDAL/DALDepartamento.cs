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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Departamento
	/// </summary>
    public class DALDepartamento : AbstractMapper<Departamento>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALDepartamento()
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
		~DALDepartamento()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Departamento
		/// </summary>
		/// <param name="id"></param>   
		/// <returns></returns>
		public Departamento Load(int id)
		{
            try
            {
				Departamento oReturn = null;
                CommandText = "PA_MG_FRONT_Departamento_Select";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Departamento> departamentos = AbstractFindAll(oParameters);
				if (departamentos.Count > 0)
				{
					oReturn = departamentos[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDepartamento, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Departamento
		/// </summary>
		/// <param name="oDepartamento"></param>
		/// <returns></returns>
		public void Delete(Departamento oDepartamento)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Departamento_Delete";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDepartamento.ID));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALDepartamento, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Departamento
		/// </summary>
		/// <param name="oDepartamento"></param>
		/// <returns></returns>
		public void Update(Departamento oDepartamento)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Departamento_Update";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDepartamento.ID));
				oParameters.Add(new DBParametro("@idprovincia", DbType.Int32, oDepartamento.IdProvincia));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oDepartamento.Nombre));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDepartamento, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Departamento
		/// </summary>
		/// <param name="oDepartamento"></param>
		/// <returns></returns>
		public void Insert(Departamento oDepartamento)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Departamento_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDepartamento.ID));
				oParameters.Add(new DBParametro("@idprovincia", DbType.Int32, oDepartamento.IdProvincia));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oDepartamento.Nombre));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDepartamento, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Departamento de la tabla dbo.TBL_Departamento
		/// </summary>
		/// <param name="oDepartamento"></param>
		/// <returns></returns>
		public List<Departamento> GetAllDepartamentos()
		{
            try
            {
                CommandText = "PA_MG_FRONT_Departamento_SelectALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Departamento> departamentos = AbstractFindAll(oParameters);
				
				return departamentos;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDepartamento, getDepartamentos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// Metodo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Departamento de la tabla dbo.TBL_Departamento
        /// </summary>
        /// <param name="oDepartamento"></param>
        /// <returns></returns>
        public List<Departamento> GetAllDepartamentosByProvincia(int idProvincia)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Departamento_SELECT_PorProvincia";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idProvincia", DbType.Int32, idProvincia));

                List<Departamento> departamentos = AbstractFindAll(oParameters);

                return departamentos;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDepartamento, getDepartamentos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

		/// <summary>
        /// M?todo que crea un objeto Departamento de la tabla dbo.TBL_Departamento
		/// </summary>
		/// <param name="oDepartamento"></param>
		/// <returns></returns>
		public override Departamento DoLoad(IDataReader registros)
        {
            try
            {
				Departamento departamento = new Departamento();
				departamento.ID = registros.GetInt32(0);
				departamento.IdProvincia = registros.GetInt32(1);
				departamento.Nombre = registros.GetString(2);
			
				return departamento;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDepartamento, getDepartamentos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Departamento DoLoad(IDataReader registros, Departamento ent)
        {
            throw new NotImplementedException();
        }
    }
}
