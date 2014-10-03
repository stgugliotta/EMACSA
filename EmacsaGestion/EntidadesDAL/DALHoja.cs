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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Hoja
	/// </summary>
    public class DALHoja : AbstractMapper<Hoja>
    {

        private DBConnection oDbConnection = DBConnection.Instancia;
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALHoja()
        {
            
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection; 
        }
		
		/// <summary>
        /// Destructor Standard
		/// </summary>
		~DALHoja()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Hoja
		/// </summary>
		/// <param name="idHoja"></param>    
		/// <returns></returns>
		public Hoja Load(decimal idHoja)
		{
            try
            {
				Hoja oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Hoja_Select";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, idHoja));
				
				List<Hoja> hojas = AbstractFindAll(oParameters);
				if (hojas.Count > 0)
				{
					oReturn = hojas[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALHoja, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Hoja
		/// </summary>
		/// <param name="oHoja"></param>
		/// <returns></returns>
		public void Delete(Hoja oHoja)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Hoja_Delete";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oHoja.IdHoja));				
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALHoja, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Hoja
		/// </summary>
		/// <param name="oHoja"></param>
		/// <returns></returns>
		public void Update(Hoja oHoja)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Hoja_Update";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oHoja.IdHoja));
				oParameters.Add(new DBParametro("@fecha_creacion", DbType.DateTime, oHoja.FechaCreacion));
				oParameters.Add(new DBParametro("@usuario", DbType.String, oHoja.Usuario));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALHoja, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Hoja
		/// </summary>
		/// <param name="oHoja"></param>
		/// <returns></returns>
		public void Insert(Hoja oHoja)
		{
			 try
            {
                this.BeginTransaction();

                CommandText = "PA_MG_FRONT_MTR_Hoja_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oHoja.IdHoja));
				oParameters.Add(new DBParametro("@fecha_creacion", DbType.DateTime, oHoja.FechaCreacion));
				oParameters.Add(new DBParametro("@usuario", DbType.String, oHoja.Usuario));
				
				//ExecuteNonQuery(oParameters);
                int idHoja = int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());

                foreach (ItemHoja itemHoja in oHoja.ItemsHoja) {
                    DALItemHoja dalItemHoja = new DALItemHoja(oDbConnection);
                    itemHoja.IdHoja = idHoja;
                    dalItemHoja.Insert(itemHoja);
                }

                this.CommitTransaction();
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALHoja, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Hoja de la tabla dbo.MTR_Hoja
		/// </summary>
		/// <param name="oHoja"></param>
		/// <returns></returns>
		public List<Hoja> GetAllHojas()
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Hoja_SelectALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Hoja> hojas = AbstractFindAll(oParameters);
				
				return hojas;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALHoja, getHojas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Hoja> GetAllHojasEntreFechas(DateTime fechaCreacionDesde, DateTime fechaCreacionHasta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Hoja_SelectEntreFechas";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@fecha_desde", DbType.DateTime, fechaCreacionDesde));
                oParameters.Add(new DBParametro("@fecha_hasta", DbType.DateTime, fechaCreacionHasta));
                List<Hoja> hojas = AbstractFindAll(oParameters);

                return hojas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALHoja, GetAllHojasEntreFechas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Hoja de la tabla dbo.MTR_Hoja
		/// </summary>
		/// <param name="oHoja"></param>
		/// <returns></returns>
		public override Hoja DoLoad(IDataReader registros)
        {
            try
            {
				Hoja hoja = new Hoja();
				hoja.IdHoja = registros.GetDecimal(0);
				hoja.FechaCreacion = registros.GetDateTime(1);
				hoja.Usuario = registros.GetString(2);
			
				return hoja;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALHoja, getHojas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Hoja DoLoad(IDataReader registros, Hoja ent)
        {
            throw new NotImplementedException();
        }
    }
}
