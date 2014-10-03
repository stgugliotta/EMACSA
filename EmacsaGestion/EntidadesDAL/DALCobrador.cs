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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Cobrador
	/// </summary>
    public class DALCobrador : AbstractMapper<Cobrador>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALCobrador()
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
		~DALCobrador()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto Cobrador
		/// </summary>
		/// <param name="id"></param>           
		/// <returns></returns>
		public Cobrador Load(int id)
		{
            try
            {
				Cobrador oReturn = null;
				CommandText = "PA_MG_FRONT_MTR_Cobrador_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Cobrador> cobrador = AbstractFindAll(oParameters);
				if (cobrador.Count > 0)
				{
					oReturn = cobrador[0];
			    }
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALCobrador, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Cobrador
		/// </summary>
		/// <param name="oCobrador"></param>
		/// <returns></returns>
		public void Delete(Cobrador oCobrador)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Cobrador_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCobrador.Id));											
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALCobrador, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Cobrador
		/// </summary>
		/// <param name="oCobrador"></param>
		/// <returns></returns>
		public void Update(Cobrador oCobrador)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Cobrador_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCobrador.Id));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oCobrador.Nombre));
				oParameters.Add(new DBParametro("@apellido", DbType.String, oCobrador.Apellido));
                oParameters.Add(new DBParametro("@dni", DbType.String, oCobrador.DNI));
                oParameters.Add(new DBParametro("@telefono", DbType.String, oCobrador.Telefono));
                oParameters.Add(new DBParametro("@horario", DbType.String, oCobrador.Horario));
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALCobrador, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Cobrador
		/// </summary>
		/// <param name="oCobrador"></param>
		/// <returns></returns>
		public void Insert(Cobrador oCobrador)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_MTR_Cobrador_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@nombre", DbType.String, oCobrador.Nombre));
                oParameters.Add(new DBParametro("@apellido", DbType.String, oCobrador.Apellido));
                oParameters.Add(new DBParametro("@dni", DbType.String, oCobrador.DNI));
                oParameters.Add(new DBParametro("@telefono", DbType.String, oCobrador.Telefono));
                oParameters.Add(new DBParametro("@horario", DbType.String, oCobrador.Horario));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALCobrador, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// DomicilioDeudor de la tabla dbo.MTR_Cobrador
		/// </summary>
		/// <param name="oCobrador"></param>
		/// <returns></returns>
		public List<Cobrador> GetAllCobrador()
		{
            try
            {
				CommandText = "PA_MG_FRONT_MTR_Cobrador_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Cobrador> cobrador = AbstractFindAll(oParameters);
				
				return cobrador;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALCobrador, getCobrador", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Cobrador> GetAllCobradorPorZonaAsignada(int idZona)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Cobrador_SelectAll_ByIdZona";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_Zona", DbType.Int32, idZona));
                List<Cobrador> cobrador = AbstractFindAll(oParameters);

                return cobrador;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALCobrador, GetAllCobradorPorZonaAsignada", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


		/// <summary>
        /// M?todo que crea un objeto Zona de la tabla dbo.MTR_Cobrador
		/// </summary>
		/// <param name="oCobrador"></param>
		/// <returns></returns>
		public override Cobrador DoLoad(IDataReader registros)
        {
            try
            {
				Cobrador cobrador = new Cobrador();
				cobrador.Id = registros.GetInt32(0);
				cobrador.Nombre = registros.GetString(1);
                cobrador.Apellido = registros.GetString(2);
                cobrador.DNI = registros.GetString(3);
                cobrador.Telefono = registros.GetString(4);
                cobrador.Horario = registros.GetString(5);

				return cobrador;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALCobrador, getCobrador", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Cobrador DoLoad(IDataReader registros, Cobrador ent)
        {
            throw new NotImplementedException();
        }
    }
}
