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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Domicilio_Deudor
	/// </summary>
    public class DALDomicilioDeudor : AbstractMapper<DomicilioDeudor>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALDomicilioDeudor()
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
		~DALDomicilioDeudor()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  DomicilioDeudor
		/// </summary>
		/// <param name="idDeudor"></param>           
		/// <returns></returns>
		public DomicilioDeudor Load(int idDeudor)
		{
            try
            {
				DomicilioDeudor oReturn = null;
				CommandText = "PA_MG_FRONT_Domicilio_Deudor_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, idDeudor));
				
				List<DomicilioDeudor> domiciliodeudors = AbstractFindAll(oParameters);
				if (domiciliodeudors.Count > 0)
				{
					oReturn = domiciliodeudors[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDomicilioDeudor, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1} " + ex.Message, ex.GetType(), ex.StackTrace), ex);
            }
		}


        public DomicilioDeudor GetDomicilioByIdDeudorIdHoja(int idDeudor, int idHoja)
        {
            try
            {
                DomicilioDeudor oReturn = null;
                CommandText = "PA_MG_FRONT_Domicilio_Deudor_SelectALL_PorIdDeudorIdHoja";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@idHoja", DbType.Int32, idHoja));

                List<DomicilioDeudor> domiciliodeudors = AbstractFindAll(oParameters);
                if (domiciliodeudors.Count > 0)
                {
                    oReturn = domiciliodeudors[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDomicilioDeudor, GetDomicilioByIdDeudorIdHoja", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1} " + ex.Message, ex.GetType(), ex.StackTrace), ex);
            }
        }
		

		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Domicilio_Deudor
		/// </summary>
		/// <param name="oDomicilioDeudor"></param>
		/// <returns></returns>
		public void Delete(DomicilioDeudor oDomicilioDeudor)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Domicilio_Deudor_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDomicilioDeudor.IdDeudor));											
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALDomicilioDeudor, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1} " + ex.Message, ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Domicilio_Deudor
		/// </summary>
		/// <param name="oDomicilioDeudor"></param>
		/// <returns></returns>
		public void Update(DomicilioDeudor oDomicilioDeudor)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Domicilio_Deudor_Update";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oDomicilioDeudor.IdDomicilioAlternativo ));
				oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDomicilioDeudor.IdDeudor));
				oParameters.Add(new DBParametro("@id_pais", DbType.Int32, oDomicilioDeudor.IdPais));
				oParameters.Add(new DBParametro("@id_provincia", DbType.Int32, oDomicilioDeudor.IdProvincia));
				oParameters.Add(new DBParametro("@id_departamento", DbType.Int32, oDomicilioDeudor.IdDepartamento));
				oParameters.Add(new DBParametro("@id_localidad", DbType.Int32, oDomicilioDeudor.IdLocalidad));
				oParameters.Add(new DBParametro("@calle_nombre", DbType.String, oDomicilioDeudor.CalleNombre));
				oParameters.Add(new DBParametro("@calle_altura", DbType.Int32, oDomicilioDeudor.CalleAltura));
				oParameters.Add(new DBParametro("@cp", DbType.String, oDomicilioDeudor.Cp));
				oParameters.Add(new DBParametro("@gm_formatted_address", DbType.String, oDomicilioDeudor.GmFormattedAddress));
				oParameters.Add(new DBParametro("@gm_lat", DbType.Double, oDomicilioDeudor.GmLat));
				oParameters.Add(new DBParametro("@gm_lng", DbType.Double, oDomicilioDeudor.GmLng));
                oParameters.Add(new DBParametro("@piso", DbType.Int32, oDomicilioDeudor.Piso));
                oParameters.Add(new DBParametro("@depto", DbType.String, oDomicilioDeudor.Depto));
                oParameters.Add(new DBParametro("@dirPpal", DbType.Boolean, oDomicilioDeudor.DirPpal));

				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDomicilioDeudor, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1} " + ex.Message, ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Domicilio_Deudor
		/// </summary>
		/// <param name="oDomicilioDeudor"></param>
		/// <returns></returns>
		public void Insert(DomicilioDeudor oDomicilioDeudor)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Domicilio_Deudor_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDomicilioDeudor.IdDeudor));
				oParameters.Add(new DBParametro("@id_pais", DbType.Int32, oDomicilioDeudor.IdPais));
				oParameters.Add(new DBParametro("@id_provincia", DbType.Int32, oDomicilioDeudor.IdProvincia));
				oParameters.Add(new DBParametro("@id_departamento", DbType.Int32, oDomicilioDeudor.IdDepartamento));
				oParameters.Add(new DBParametro("@id_localidad", DbType.Int32, oDomicilioDeudor.IdLocalidad));
				oParameters.Add(new DBParametro("@calle_nombre", DbType.String, oDomicilioDeudor.CalleNombre));
				oParameters.Add(new DBParametro("@calle_altura", DbType.Int32, oDomicilioDeudor.CalleAltura));
				oParameters.Add(new DBParametro("@cp", DbType.String, oDomicilioDeudor.Cp));
				oParameters.Add(new DBParametro("@gm_formatted_address", DbType.String, oDomicilioDeudor.GmFormattedAddress));
				oParameters.Add(new DBParametro("@gm_lat", DbType.Double, oDomicilioDeudor.GmLat));
				oParameters.Add(new DBParametro("@gm_lng", DbType.Double, oDomicilioDeudor.GmLng));
                oParameters.Add(new DBParametro("@piso", DbType.Int32, oDomicilioDeudor.Piso));
                oParameters.Add(new DBParametro("@depto", DbType.String, oDomicilioDeudor.Depto));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDomicilioDeudor, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1} " + ex.Message, ex.GetType(), ex.StackTrace), ex);
            }
		}


        public void InsertNuevo(DomicilioDeudor oDomicilioDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Domicilio_Deudor_Insert_Nuevo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDomicilioDeudor.IdDeudor));
                oParameters.Add(new DBParametro("@id_pais", DbType.Int32, oDomicilioDeudor.IdPais));
                oParameters.Add(new DBParametro("@id_provincia", DbType.Int32, oDomicilioDeudor.IdProvincia));
                oParameters.Add(new DBParametro("@id_departamento", DbType.Int32, oDomicilioDeudor.IdDepartamento));
                oParameters.Add(new DBParametro("@id_localidad", DbType.Int32, oDomicilioDeudor.IdLocalidad));
                oParameters.Add(new DBParametro("@calle_nombre", DbType.String, oDomicilioDeudor.CalleNombre));
                oParameters.Add(new DBParametro("@calle_altura", DbType.Int32, oDomicilioDeudor.CalleAltura));
                oParameters.Add(new DBParametro("@cp", DbType.String, oDomicilioDeudor.Cp));
                oParameters.Add(new DBParametro("@gm_formatted_address", DbType.String, oDomicilioDeudor.GmFormattedAddress));
                oParameters.Add(new DBParametro("@gm_lat", DbType.Double, oDomicilioDeudor.GmLat));
                oParameters.Add(new DBParametro("@gm_lng", DbType.Double, oDomicilioDeudor.GmLng));
                oParameters.Add(new DBParametro("@piso", DbType.Int32, oDomicilioDeudor.Piso));
                oParameters.Add(new DBParametro("@depto", DbType.String, oDomicilioDeudor.Depto));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDomicilioDeudor, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1} " + ex.Message, ex.GetType(), ex.StackTrace), ex);
            }
        }

		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// DomicilioDeudor de la tabla dbo.TBL_Domicilio_Deudor
		/// </summary>
		/// <param name="oDomicilioDeudor"></param>
		/// <returns></returns>
		public List<DomicilioDeudor> GetAllDomicilioDeudors()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Domicilio_Deudor_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<DomicilioDeudor> domiciliodeudors = AbstractFindAll(oParameters);
				
				return domiciliodeudors;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDomicilioDeudor, getDomicilioDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1} " + ex.Message, ex.GetType(), ex.StackTrace), ex);
            }
        }

		/// <summary>
        /// M?todo que crea un objeto DomicilioDeudor de la tabla dbo.TBL_Domicilio_Deudor
		/// </summary>
		/// <param name="oDomicilioDeudor"></param>
		/// <returns></returns>
		public override DomicilioDeudor DoLoad(IDataReader registros)
        {
            try
            {
				DomicilioDeudor domiciliodeudor = new DomicilioDeudor();
				domiciliodeudor.IdDeudor = registros.GetInt32(0);
				domiciliodeudor.IdPais = registros.GetInt32(1);
				domiciliodeudor.IdProvincia = registros.GetInt32(2);
				domiciliodeudor.IdDepartamento = registros.GetInt32(3);
				domiciliodeudor.IdLocalidad = registros.GetInt32(4);
				domiciliodeudor.CalleNombre = registros.GetString(5);
                domiciliodeudor.CalleAltura = registros.IsDBNull(6) ? 0 : registros.GetInt32(6);
				domiciliodeudor.Cp = registros.GetString(7);
				domiciliodeudor.GmFormattedAddress = registros.IsDBNull(8) ? "" : registros.GetString(8);
				domiciliodeudor.GmLat = registros.IsDBNull(9) ? 0 : registros.GetDouble(9);
				domiciliodeudor.GmLng = registros.IsDBNull(10) ? 0 : registros.GetDouble(10);
                domiciliodeudor.Piso = registros.IsDBNull(11) ? 0 : int.Parse(registros.GetValue(11).ToString());
                domiciliodeudor.Depto = registros.IsDBNull(12) ? "" : registros.GetString(12);
                try
                {
                    domiciliodeudor.IdDomicilioAlternativo = registros.IsDBNull(13) ? 0 : registros.GetInt32(13);
                }
                catch (Exception ex) { 
                }
			
				return domiciliodeudor;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALDomicilioDeudor, getDomicilioDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1} " + ex.Message, ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override DomicilioDeudor DoLoad(IDataReader registros, DomicilioDeudor ent)
        {
            throw new NotImplementedException();
        }
    }
}
