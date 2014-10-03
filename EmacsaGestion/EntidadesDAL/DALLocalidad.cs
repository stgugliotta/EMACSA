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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Localidad
	/// </summary>
    public class DALLocalidad : AbstractMapper<Localidad>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALLocalidad()
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
		~DALLocalidad()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Localidad
		/// </summary>
		/// <param name="id"></param>   
		/// <returns></returns>
		public Localidad Load(int id)
		{
            try
            {
				Localidad oReturn = null;
                CommandText = "PA_MG_FRONT_Localidad_Select";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Localidad> localidads = AbstractFindAll(oParameters);
				if (localidads.Count > 0)
				{
					oReturn = localidads[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALLocalidad, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Localidad
		/// </summary>
		/// <param name="oLocalidad"></param>
		/// <returns></returns>
		public void Delete(Localidad oLocalidad)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Localidad_Delete";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oLocalidad.ID));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALLocalidad, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Localidad
		/// </summary>
		/// <param name="oLocalidad"></param>
		/// <returns></returns>
		public void Update(Localidad oLocalidad)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Localidad_Update";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oLocalidad.ID));
				oParameters.Add(new DBParametro("@iddepartamento", DbType.Int32, oLocalidad.IdDepartamento));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oLocalidad.Nombre));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALLocalidad, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Localidad
		/// </summary>
		/// <param name="oLocalidad"></param>
		/// <returns></returns>
		public void Insert(Localidad oLocalidad)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Localidad_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oLocalidad.ID));
				oParameters.Add(new DBParametro("@iddepartamento", DbType.Int32, oLocalidad.IdDepartamento));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oLocalidad.Nombre));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALLocalidad, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Localidad de la tabla dbo.TBL_Localidad
		/// </summary>
		/// <param name="oLocalidad"></param>
		/// <returns></returns>
		public List<Localidad> GetAllLocalidads()
		{
            try
            {
                CommandText = "PA_MG_FRONT_Localidad_SelectALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Localidad> localidads = AbstractFindAll(oParameters);
				
				return localidads;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALLocalidad, getLocalidads", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido en una lista de Objetos por Departamento
        /// Localidad de la tabla dbo.TBL_Localidad
        /// </summary>
        /// <param name="oLocalidad"></param>
        /// <returns></returns>
        public List<Localidad> GetAllLocalidadsByDepartamento(int idDepartamento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Localidad_SELECT_PorDepartamento";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDepartamento", DbType.Int32, idDepartamento));

                List<Localidad> localidads = AbstractFindAll(oParameters);

                return localidads;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALLocalidad, getLocalidads", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }		

		/// <summary>
        /// M?todo que crea un objeto Localidad de la tabla dbo.TBL_Localidad
		/// </summary>
		/// <param name="oLocalidad"></param>
		/// <returns></returns>
		public override Localidad DoLoad(IDataReader registros)
        {
            try
            {
				Localidad localidad = new Localidad();
				localidad.ID = registros.GetInt32(0);
				localidad.IdDepartamento = registros.GetInt32(1);
				localidad.Nombre = registros.GetString(2);
			
				return localidad;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALLocalidad, getLocalidads", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Localidad DoLoad(IDataReader registros, Localidad ent)
        {
            throw new NotImplementedException();
        }
    }
}
