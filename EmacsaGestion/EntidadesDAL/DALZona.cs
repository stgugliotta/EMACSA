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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Zona
	/// </summary>
    public class DALZona : AbstractMapper<Zona>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALZona()
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
		~DALZona()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto Zona
		/// </summary>
		/// <param name="id"></param>           
		/// <returns></returns>
		public Zona Load(int id)
		{
            try
            {
				Zona oReturn = null;
				CommandText = "PA_MG_FRONT_MTR_Zona_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Zona> zona = AbstractFindAll(oParameters);
				if (zona.Count > 0)
				{
					oReturn = zona[0];
			    }
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALZona, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Domicilio_Deudor
		/// </summary>
		/// <param name="oDomicilioDeudor"></param>
		/// <returns></returns>
		public void Delete(Zona oZona)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Zona_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oZona.Id));											
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALZona, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Zona
		/// </summary>
		/// <param name="oZona"></param>
		/// <returns></returns>
		public void Update(Zona oZona)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Zona_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oZona.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oZona.Descripcion));
				oParameters.Add(new DBParametro("@cp", DbType.String, oZona.CP));
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALZona, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Zona
		/// </summary>
		/// <param name="oZona"></param>
		/// <returns></returns>
		public void Insert(Zona oZona)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_MTR_Zona_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oZona.Descripcion));
				oParameters.Add(new DBParametro("@cp", DbType.String, oZona.CP));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALZona, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// DomicilioDeudor de la tabla dbo.MTR_Zona
		/// </summary>
		/// <param name="oZona"></param>
		/// <returns></returns>
		public List<Zona> GetAllZona()
		{
            try
            {
				CommandText = "PA_MG_FRONT_MTR_Zona_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Zona> zona = AbstractFindAll(oParameters);
				
				return zona;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALZona, getZona", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// DomicilioDeudor de la tabla dbo.MTR_Zona
        /// </summary>
        /// <param name="oZona"></param>
        /// <returns></returns>
        public List<Zona> GetZonasByCobrador(int id_cobrador)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Zonas_byCobrador";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_cobrador", DbType.Int32, id_cobrador));

                List<Zona> zona = AbstractFindAll(oParameters);

                return zona;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALZona, GetZonasByCobrador", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


		/// <summary>
        /// M?todo que crea un objeto Zona de la tabla dbo.MTR_Zona
		/// </summary>
		/// <param name="oZona"></param>
		/// <returns></returns>
		public override Zona DoLoad(IDataReader registros)
        {
            try
            {
				Zona zona = new Zona();
				zona.Id = registros.GetInt32(0);
				zona.Descripcion = registros.GetString(1);
				zona.CP = registros.GetString(2);
			
				return zona;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALZona, getZona", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}

        public void AsociarCobrador(int id_cobrador, int id_zona)
        {
            try
            {
                CommandText = "PA_MG_FRONT_TBL_Cobrador_Zona_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_cobrador", DbType.Int32, id_cobrador));
                oParameters.Add(new DBParametro("@id_zona", DbType.Int32, id_zona));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALZona, AsociarCobrador", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        public override Zona DoLoad(IDataReader registros, Zona ent)
        {
            throw new NotImplementedException();
        }
    }
}
