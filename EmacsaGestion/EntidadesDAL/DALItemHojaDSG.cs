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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Item_Hoja_DSG
	/// </summary>
    public class DALItemHojaDSG : AbstractMapper<ItemHojaDSG>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALItemHojaDSG()
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
		~DALItemHojaDSG()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  ItemHojaDSG
		/// </summary>
		/// <param name="idHoja"></param> /// <param name="nroItem"></param>             
		/// <returns></returns>
		public ItemHojaDSG Load(decimal idHoja,int nroItem)
		{
            try
            {
				ItemHojaDSG oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_DSG_Select";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, idHoja));				oParameters.Add(new DBParametro("@nro_item", DbType.Int32, nroItem));
				
				List<ItemHojaDSG> itemhojadsgs = AbstractFindAll(oParameters);
				if (itemhojadsgs.Count > 0)
				{
					oReturn = itemhojadsgs[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHojaDSG, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Item_Hoja_DSG
		/// </summary>
		/// <param name="oItemHojaDSG"></param>
		/// <returns></returns>
		public void Delete(ItemHojaDSG oItemHojaDSG)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_DSG_Delete";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oItemHojaDSG.IdHoja));					oParameters.Add(new DBParametro("@nro_item", DbType.Int32, oItemHojaDSG.NroItem));													
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
               Herramientas.Logger.WriteError("Clase: DALItemHojaDSG, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Item_Hoja_DSG
		/// </summary>
		/// <param name="oItemHojaDSG"></param>
		/// <returns></returns>
		public void Update(ItemHojaDSG oItemHojaDSG)
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_DSG_Update";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oItemHojaDSG.IdHoja));
				oParameters.Add(new DBParametro("@nro_item", DbType.Int32, oItemHojaDSG.NroItem));
				oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oItemHojaDSG.IdCliente));
				oParameters.Add(new DBParametro("@id_deudor", DbType.String, oItemHojaDSG.IdDeudor));
				oParameters.Add(new DBParametro("@deudor_razon_social", DbType.String, oItemHojaDSG.DeudorRazonSocial));
				oParameters.Add(new DBParametro("@deudor_domicilio", DbType.String, oItemHojaDSG.DeudorDomicilio));
				oParameters.Add(new DBParametro("@deudor_localidad", DbType.String, oItemHojaDSG.DeudorLocalidad));
				oParameters.Add(new DBParametro("@deudor_dia", DbType.String, oItemHojaDSG.DeudorDia));
				oParameters.Add(new DBParametro("@deudor_horario", DbType.String, oItemHojaDSG.DeudorHorario));
				oParameters.Add(new DBParametro("@id_estado_hoja", DbType.Int16, oItemHojaDSG.IdEstadoHoja));
				oParameters.Add(new DBParametro("@observaciones", DbType.String, oItemHojaDSG.Observaciones));
				oParameters.Add(new DBParametro("@ingresada", DbType.Boolean, oItemHojaDSG.Ingresada));
				oParameters.Add(new DBParametro("@se_pago", DbType.Boolean, oItemHojaDSG.SePago));
				oParameters.Add(new DBParametro("@id_cobrador", DbType.Int32, oItemHojaDSG.IdCobrador));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHojaDSG, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Item_Hoja_DSG
		/// </summary>
		/// <param name="oItemHojaDSG"></param>
		/// <returns></returns>
		public void Insert(ItemHojaDSG oItemHojaDSG)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_DSG_Insert";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, oItemHojaDSG.IdHoja));
				oParameters.Add(new DBParametro("@nro_item", DbType.Int32, oItemHojaDSG.NroItem));
				oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oItemHojaDSG.IdCliente));
				oParameters.Add(new DBParametro("@id_deudor", DbType.String, oItemHojaDSG.IdDeudor));
				oParameters.Add(new DBParametro("@deudor_razon_social", DbType.String, oItemHojaDSG.DeudorRazonSocial));
				oParameters.Add(new DBParametro("@deudor_domicilio", DbType.String, oItemHojaDSG.DeudorDomicilio));
				oParameters.Add(new DBParametro("@deudor_localidad", DbType.String, oItemHojaDSG.DeudorLocalidad));
				oParameters.Add(new DBParametro("@deudor_dia", DbType.String, oItemHojaDSG.DeudorDia));
				oParameters.Add(new DBParametro("@deudor_horario", DbType.String, oItemHojaDSG.DeudorHorario));
				oParameters.Add(new DBParametro("@id_estado_hoja", DbType.Int16, oItemHojaDSG.IdEstadoHoja));
				oParameters.Add(new DBParametro("@observaciones", DbType.String, oItemHojaDSG.Observaciones));
				oParameters.Add(new DBParametro("@ingresada", DbType.Boolean, oItemHojaDSG.Ingresada));
				oParameters.Add(new DBParametro("@se_pago", DbType.Boolean, oItemHojaDSG.SePago));
				oParameters.Add(new DBParametro("@id_cobrador", DbType.Int32, oItemHojaDSG.IdCobrador));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHojaDSG, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// ItemHojaDSG de la tabla dbo.MTR_Item_Hoja_DSG
		/// </summary>
		/// <param name="oItemHojaDSG"></param>
		/// <returns></returns>
		public List<ItemHojaDSG> GetAllItemHojaDSGs()
		{
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_DSG_SelectALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<ItemHojaDSG> itemhojadsgs = AbstractFindAll(oParameters);
				
				return itemhojadsgs;
			}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHojaDSG, getItemHojaDSGs", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<ItemHojaDSG> GetAllItemHojaDSGsByIdHoja(int idHoja)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Item_Hoja_DSG_SelectALL_ByIdHoja";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_hoja", DbType.Decimal, idHoja));
		
                List<ItemHojaDSG> itemhojadsgs = AbstractFindAll(oParameters);

                return itemhojadsgs;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHojaDSG, GetAllItemHojaDSGsByIdHoja", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		

        
        /// <summary>
        /// M?todo que crea un objeto ItemHojaDSG de la tabla dbo.MTR_Item_Hoja_DSG
		/// </summary>
		/// <param name="oItemHojaDSG"></param>
		/// <returns></returns>
		public override ItemHojaDSG DoLoad(IDataReader registros)
        {
            try
            {
				ItemHojaDSG itemhojadsg = new ItemHojaDSG();
				itemhojadsg.IdHoja = registros.GetDecimal(0);
				itemhojadsg.NroItem = registros.GetInt32(1);
				itemhojadsg.IdCliente = registros.GetDecimal(2);
				itemhojadsg.IdDeudor = registros.GetString(3);
				itemhojadsg.DeudorRazonSocial = registros.GetString(4);
				//itemhojadsg.DeudorDomicilio = registros.GetString(5);
                itemhojadsg.DeudorDomicilio = registros.IsDBNull(5) != true ? registros.GetString(5) : "";
                itemhojadsg.DeudorLocalidad = registros.GetString(6);
				itemhojadsg.DeudorDia = registros.GetString(7);
				itemhojadsg.DeudorHorario = registros.GetString(8);
				itemhojadsg.IdEstadoHoja = registros.GetInt16(9);
				itemhojadsg.Observaciones = registros.GetString(10);
				itemhojadsg.Ingresada = registros.GetBoolean(11);
				itemhojadsg.SePago = registros.GetBoolean(12);
				itemhojadsg.IdCobrador = registros.GetInt32(13);
                try
                {
                    itemhojadsg.AlfaNumDelCliente = registros.GetString(14);
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
                
			
				return itemhojadsg;
				}
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALItemHojaDSG, getItemHojaDSGs", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override ItemHojaDSG DoLoad(IDataReader registros, ItemHojaDSG ent)
        {
            throw new NotImplementedException();
        }
    }
}
