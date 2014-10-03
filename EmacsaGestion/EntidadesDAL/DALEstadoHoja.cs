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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Estado_Hoja
	/// </summary>
    public class DALEstadoHoja : AbstractMapper<EstadoHoja>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALEstadoHoja()
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
		~DALEstadoHoja()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  EstadoHoja
		/// </summary>
		/// <param name="idEstado"></param>   
		/// <returns></returns>
		public EstadoHoja Load(short idEstado)
		{
            try
            {
				EstadoHoja oReturn = null;
                CommandText = "PA_MG_FRONT_Estado_Hoja_Select";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_estado", DbType.Int16, idEstado));
				
				List<EstadoHoja> estadohojas = AbstractFindAll(oParameters);
				if (estadohojas.Count > 0)
				{
					oReturn = estadohojas[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALEstadoHoja, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Estado_Hoja
		/// </summary>
		/// <param name="oEstadoHoja"></param>
		/// <returns></returns>
		public void Delete(EstadoHoja oEstadoHoja)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Estado_Hoja_Delete";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_estado", DbType.Int16, oEstadoHoja.IdEstadoHoja));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALEstadoHoja, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Estado_Hoja
		/// </summary>
		/// <param name="oEstadoHoja"></param>
		/// <returns></returns>
		public void Update(EstadoHoja oEstadoHoja)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Estado_Hoja_Update";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_estado", DbType.Int16, oEstadoHoja.IdEstadoHoja));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oEstadoHoja.Descripcion));
				oParameters.Add(new DBParametro("@requiere_observacion", DbType.Boolean, oEstadoHoja.RequiereObservacion));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALEstadoHoja, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Estado_Hoja
		/// </summary>
		/// <param name="oEstadoHoja"></param>
		/// <returns></returns>
		public void Insert(EstadoHoja oEstadoHoja)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Estado_Hoja_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_estado", DbType.Int16, oEstadoHoja.IdEstadoHoja));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oEstadoHoja.Descripcion));
				oParameters.Add(new DBParametro("@requiere_observacion", DbType.Boolean, oEstadoHoja.RequiereObservacion));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALEstadoHoja, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// EstadoHoja de la tabla dbo.TBL_Estado_Hoja
		/// </summary>
		/// <param name="oEstadoHoja"></param>
		/// <returns></returns>
		public List<EstadoHoja> GetAllEstadoHojas()
		{
            try
            {
                CommandText = "PA_MG_FRONT_Estado_Hoja_SelectALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<EstadoHoja> estadohojas = AbstractFindAll(oParameters);
				
				return estadohojas;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALEstadoHoja, getEstadoHojas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto EstadoHoja de la tabla dbo.TBL_Estado_Hoja
		/// </summary>
		/// <param name="oEstadoHoja"></param>
		/// <returns></returns>
		public override EstadoHoja DoLoad(IDataReader registros)
        {
            try
            {
				EstadoHoja estadohoja = new EstadoHoja();
				estadohoja.IdEstadoHoja = registros.GetInt16(0);
				estadohoja.Descripcion = registros.GetString(1);
				estadohoja.RequiereObservacion = registros.GetBoolean(2);
			
				return estadohoja;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALEstadoHoja, getEstadoHojas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override EstadoHoja DoLoad(IDataReader registros, EstadoHoja ent)
        {
            throw new NotImplementedException();
        }
    }
}
