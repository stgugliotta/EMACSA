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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Item_Hoja
	/// </summary>
    public class DALItemHoja : AbstractMapper<ItemHoja>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALItemHoja()
        {
            DBConnection oDbConnection  = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection; 
        }

        public DALItemHoja(DBConnection oDbConnection)
        {
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }        
		
		/// <summary>
        /// Destructor Standard
		/// </summary>
		~DALItemHoja()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  ItemHoja
		/// </summary>
		/// <param name="idHoja"></param> /// <param name="nroItem"></param>         
		/// <returns></returns>
		public ItemHoja Load(decimal idHoja,int nroItem)
		{
            try
            {
				ItemHoja oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_Select";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, idHoja));				oParameters.Add(new DBParametro("@nro_item", DbType.Int32, nroItem));
				
				List<ItemHoja> itemhojas = AbstractFindAll(oParameters);
				if (itemhojas.Count > 0)
				{
					oReturn = itemhojas[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHoja, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Item_Hoja
		/// </summary>
		/// <param name="oItemHoja"></param>
		/// <returns></returns>
		public void Delete(ItemHoja oItemHoja)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_Delete";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oItemHoja.IdHoja));
                oParameters.Add(new DBParametro("@nro_item", DbType.Int32, oItemHoja.NroItem));									
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALItemHoja, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Item_Hoja
		/// </summary>
		/// <param name="oItemHoja"></param>
		/// <returns></returns>
		public void Update(ItemHoja oItemHoja)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_Update";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oItemHoja.IdHoja));
				oParameters.Add(new DBParametro("@nro_item", DbType.Int32, oItemHoja.NroItem));
				oParameters.Add(new DBParametro("@id_factura", DbType.Int32, oItemHoja.IdFactura));
				oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oItemHoja.IdCliente));
				oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oItemHoja.FechaVenc));
				oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oItemHoja.IdDeudor));
				oParameters.Add(new DBParametro("@importe_modificado", DbType.Double, oItemHoja.ImporteModificado));
				oParameters.Add(new DBParametro("@id_estado_hoja", DbType.Int16, oItemHoja.IdEstadoHoja));
				oParameters.Add(new DBParametro("@observaciones", DbType.String, oItemHoja.Observaciones));
				oParameters.Add(new DBParametro("@ingresada", DbType.Boolean, oItemHoja.Ingresada));
                oParameters.Add(new DBParametro("@se_pago", DbType.Boolean, oItemHoja.SePago));
                oParameters.Add(new DBParametro("@id_cobrador", DbType.Int32, oItemHoja.IdCobrador));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHoja, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Item_Hoja
		/// </summary>
		/// <param name="oItemHoja"></param>
		/// <returns></returns>
		public void Insert(ItemHoja oItemHoja)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oItemHoja.IdHoja));
				oParameters.Add(new DBParametro("@nro_item", DbType.Int32, oItemHoja.NroItem));
				oParameters.Add(new DBParametro("@id_factura", DbType.Int32, oItemHoja.IdFactura));
				oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oItemHoja.IdCliente));
				oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oItemHoja.FechaVenc));
				oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oItemHoja.IdDeudor));
				oParameters.Add(new DBParametro("@importe_modificado", DbType.Double, oItemHoja.ImporteModificado));
				oParameters.Add(new DBParametro("@id_estado_hoja", DbType.Int16, oItemHoja.IdEstadoHoja));
				oParameters.Add(new DBParametro("@observaciones", DbType.String, oItemHoja.Observaciones));
				oParameters.Add(new DBParametro("@ingresada", DbType.Boolean, oItemHoja.Ingresada));
                oParameters.Add(new DBParametro("@se_pago", DbType.Boolean, oItemHoja.SePago));
                oParameters.Add(new DBParametro("@id_cobrador", DbType.Int32, oItemHoja.IdCobrador));

				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHoja, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// ItemHoja de la tabla dbo.MTR_Item_Hoja
		/// </summary>
		/// <param name="oItemHoja"></param>
		/// <returns></returns>
		public List<ItemHoja> GetAllItemHojas()
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_SelectALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<ItemHoja> itemhojas = AbstractFindAll(oParameters);
				
				return itemhojas;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHoja, getItemHojas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<ItemHoja> GetItemsHojaByIdHoja(int idHoja)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_SelectALL_ByIdHoja";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, idHoja));
                List<ItemHoja> itemhojas = AbstractFindAll(oParameters);

                return itemhojas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHoja, getItemHojas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        

		/// <summary>
        /// M?todo que crea un objeto ItemHoja de la tabla dbo.MTR_Item_Hoja
		/// </summary>
		/// <param name="oItemHoja"></param>
		/// <returns></returns>
		public override ItemHoja DoLoad(IDataReader registros)
        {
            try
            {
				ItemHoja itemhoja = new ItemHoja();
				itemhoja.IdHoja = registros.GetDecimal(0);
				itemhoja.NroItem = registros.GetInt32(1);
				itemhoja.IdFactura = registros.GetInt32(2);
				itemhoja.IdCliente = registros.GetDecimal(3);
				itemhoja.FechaVenc = registros.GetDateTime(4);
				itemhoja.IdDeudor = registros.GetInt32(5);
				itemhoja.ImporteModificado = registros.GetDouble(6);
				itemhoja.IdEstadoHoja = registros.GetInt16(7);
                itemhoja.Observaciones = registros.IsDBNull(8) != true ? registros.GetString(8) : "";
				itemhoja.Ingresada = registros.GetBoolean(9);
                itemhoja.SePago = registros.GetBoolean(10);
                itemhoja.IdCobrador = registros.GetInt32(11);
			
				return itemhoja;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHoja, getItemHojas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override ItemHoja DoLoad(IDataReader registros, ItemHoja ent)
        {
            throw new NotImplementedException();
        }
    }
}
