using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Recibo
    /// </summary>
    public class DALRecibo : AbstractMapper<Recibo>
    {

        protected DALCobrador dalCobrador = new DALCobrador();
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALRecibo()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

        /// <summary>
        /// Destructor Standard
        /// </summary>
        ~DALRecibo()
        {
            //ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Recibo
        /// </summary>
        /// <param name="idRecibo"></param>      
        /// <returns></returns>
        public Recibo Load(int idRecibo)
        {
            try
            {
                Recibo oReturn = null;
                CommandText = "PA_MG_FRONT_Recibo_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_recibo", DbType.Int32, idRecibo));

                List<Recibo> recibos = AbstractFindAll(oParameters);
                if (recibos.Count > 0)
                {
                    oReturn = recibos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que retorna solo un objeto  Recibo
        /// </summary>
        /// <param name="idRecibo"></param>      
        /// <returns></returns>
        public Recibo Load(Recibo oRecibo)
        {
            try
            {
                Recibo oReturn = null;
                CommandText = "PA_MG_FRONT_Recibo_SELECT_ByNumRecibo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@numRecibo", DbType.String, oRecibo.Numero));

                List<Recibo> recibos = AbstractFindAll(oParameters);
                if (recibos.Count > 0)
                {
                    oReturn = recibos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna solo un objeto  Recibo
        /// </summary>
        /// <param name="oRecibo"></param>      
        /// <param name="idCliente"></param>   
        /// <returns></returns>
        public Recibo Load(Recibo oRecibo,int idCliente)
        {
            try
            {
                Recibo oReturn = null;
                CommandText = "PA_MG_FRONT_Recibo_SELECT_ByNumReciboYCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@numRecibo", DbType.String, oRecibo.Numero));
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));

                List<Recibo> recibos = AbstractFindAll(oParameters);
                if (recibos.Count > 0)
                {
                    oReturn = recibos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Recibo
        /// </summary>
        /// <param name="oRecibo"></param>
        /// <returns></returns>
        public void Delete(Recibo oRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_recibo", DbType.Int32, oRecibo.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public void Delete(Recibo oRecibo,int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_recibo", DbType.Int32, oRecibo.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Recibo
        /// </summary>
        /// <param name="oRecibo"></param>
        /// <returns></returns>
        public void Update(Recibo oRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_recibo", DbType.Int32, oRecibo.Id));
                oParameters.Add(new DBParametro("@numRecibo", DbType.String, oRecibo.Numero));
                oParameters.Add(new DBParametro("@idMotoquero", DbType.Int32, oRecibo.Cobrador.Id));
                if (oRecibo.Deudor != null)
                {
                    oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oRecibo.Deudor.IdDeudor));
                }
                else
                {
                    oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, null));
                } 
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oRecibo.Cliente.IdCliente));
                oParameters.Add(new DBParametro("@fechacarga", DbType.DateTime, oRecibo.FechaCarga));
                oParameters.Add(new DBParametro("@nsap", DbType.String, oRecibo.SAP));
                oParameters.Add(new DBParametro("@tipoDeCambio", DbType.Double, oRecibo.TipoDeCambio));
                oParameters.Add(new DBParametro("@usado_remision", DbType.Boolean, oRecibo.UsadoRemision));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        public int InsertEscalar(Recibo oRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_Escalar_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();


                oParameters.Add(new DBParametro("@numRecibo", DbType.String, oRecibo.Numero));
                oParameters.Add(new DBParametro("@idmotoquero", DbType.Int32, 0));
                if (oRecibo.Deudor != null)
                {
                    oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oRecibo.Deudor.IdDeudor));
                }
                else
                {
                    oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, null));
                } 
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oRecibo.Cliente.IdCliente));
                oParameters.Add(new DBParametro("@fechacarga", DbType.DateTime, oRecibo.FechaCarga));
                oParameters.Add(new DBParametro("@nsap", DbType.String, oRecibo.SAP));
                oParameters.Add(new DBParametro("@tipoDeCambio", DbType.Double, oRecibo.TipoDeCambio));
                oParameters.Add(new DBParametro("@usado_remision", DbType.Boolean, oRecibo.UsadoRemision));


                return int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());


            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }


        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Recibo
        /// </summary>
        /// <param name="oRecibo"></param>
        /// <returns></returns>
        public void Insert(Recibo oRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_recibo", DbType.Int32, 0));
                oParameters.Add(new DBParametro("@numRecibo", DbType.String, oRecibo.Numero));
                oParameters.Add(new DBParametro("@idmotoquero", DbType.Int32, oRecibo.Cobrador.Id));
                if (oRecibo.Deudor != null)
                {
                    oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oRecibo.Deudor.IdDeudor));
                }
                else
                {
                    oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, null));
                }
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oRecibo.Cliente.IdCliente));
                oParameters.Add(new DBParametro("@fechacarga", DbType.DateTime, oRecibo.FechaCarga));
                oParameters.Add(new DBParametro("@nsap", DbType.String, oRecibo.SAP));
                oParameters.Add(new DBParametro("@tipoDeCambio", DbType.Double, oRecibo.TipoDeCambio));
                oParameters.Add(new DBParametro("@usado_remision", DbType.Boolean, oRecibo.UsadoRemision));

                ExecuteNonQuery(oParameters);


            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Recibo de la tabla dbo.TBL_Recibo
        /// </summary>
        /// <param name="oRecibo"></param>
        /// <returns></returns>
        public List<Recibo> GetAllRecibos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Recibo> recibos = AbstractFindAll(oParameters);

                return recibos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, getRecibos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Recibo de la tabla dbo.TBL_Recibo
        /// </summary>
        /// <param name="oRecibo"></param>
        /// <returns></returns>
        public List<Recibo> GetAllRecibosByIdRemision(int idRemision)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_SELECTALL_ByIdRemision";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idRemision", DbType.Int32, idRemision));

                List<Recibo> recibos = AbstractFindAll(oParameters);

                return recibos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, getRecibos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Recibo de la tabla dbo.TBL_Recibo
        /// </summary>
        /// <param name="oRecibo"></param>
        /// <returns></returns>
        public List<Recibo> GetAllRecibosByIdCliente(int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_SelectALL_ByIdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));

                List<Recibo> recibos = AbstractFindAll(oParameters);

                return recibos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, getRecibos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Recibo> GetAllRecibosByIdClienteSinUsar(int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_SelectALL_ByIdCliente_SinUsar";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));

                List<Recibo> recibos = AbstractFindAll(oParameters);

                return recibos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, getRecibos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Recibo de la tabla dbo.TBL_Recibo
        /// </summary>
        /// <param name="oRecibo"></param>
        /// <returns></returns>
        //public override Recibo DoLoad(IDataReader registros)
        //{
        //    try
        //    {
        //        Recibo recibo = new Recibo();
        //        recibo.Id = registros.GetInt32(0);
        //        recibo.Numero = registros.GetString(1);
        //        Cobrador oCobrador = new Cobrador();

        //        recibo.Cobrador = oCobrador;
        //        try
        //        {
        //            if (!registros.IsDBNull(2))
        //            {

        //                DALCobrador dalCobrador = new DALCobrador();
        //                recibo.Cobrador = dalCobrador.Load(registros.GetInt32(2));
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            if (!registros.IsDBNull(2))
        //            {

        //                recibo.Cobrador = oCobrador;
        //                recibo.Cobrador.Id = registros.GetInt32(2);
        //            }
        //            else {
        //                recibo.Cobrador = oCobrador;
        //            }
        //        }
        //        if (recibo.Cobrador == null) {
        //            recibo.Cobrador = oCobrador;
        //        }


        //        if (!registros.IsDBNull(3))
        //        {
        //            DALDeudor dalDeudor = new DALDeudor();
        //            recibo.Deudor = dalDeudor.Load(registros.GetInt32(3));
        //        }
        //        DALCliente dalCliente = new DALCliente();
        //        recibo.Cliente = dalCliente.Load(registros.GetInt32(4));
        //        recibo.FechaCarga = registros.GetDateTime(5);
        //        recibo.SAP = registros.IsDBNull(6) ? "" : registros.GetString(6);
        //        recibo.TipoDeCambio = registros.IsDBNull(7) ? 0 : registros.GetDouble(7);
        //        recibo.UsadoRemision = registros.IsDBNull(8) ? false : registros.GetBoolean(8);

                
        //        return recibo;
        //    }
        //    catch (Exception ex)
        //    {
        //        Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, getRecibos", ex.Message);

        //        throw new GobbiTechnicalException(
        //            string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
        //    }
        //}


        public override  Recibo DoLoad(IDataReader registros)
        {
            try
            {
                Recibo recibo = new Recibo();
                recibo.Id = registros.GetInt32(0);
                recibo.Numero = registros.GetString(1);
                Cobrador oCobrador = new Cobrador();
                
                //try
                //{
                //    if (!registros.IsDBNull(2))
                //    {

                        
                //        recibo.Cobrador = dalCobrador.Load(registros.GetInt32(2));
                //    }
                //}
                //catch (Exception e)
                //{
                //    if (!registros.IsDBNull(2))
                //    {

                //        recibo.Cobrador = oCobrador;
                //        recibo.Cobrador.Id = registros.GetInt32(2);
                //    }
                //    else
                //    {
                //        recibo.Cobrador = oCobrador;
                //    }
                //}

                if (recibo.Cobrador == null)
                {
                    recibo.Cobrador = oCobrador;
                }

                recibo.FechaCarga = registros.GetDateTime(5);
                recibo.SAP = registros.IsDBNull(6) ? "" : registros.GetString(6);
                recibo.TipoDeCambio = registros.IsDBNull(7) ? 0 : registros.GetDouble(7);
                recibo.UsadoRemision = registros.IsDBNull(8) ? false : registros.GetBoolean(8);
                
                if (!registros.IsDBNull(3) && recibo.Deudor == null)
                {
                    DALDeudor dalDeudor = new DALDeudor();
                    recibo.Deudor = dalDeudor.Load(registros.GetInt32(3));
                }
               
                if (!registros.IsDBNull(4) && recibo.Cliente == null)
                {
                    DALCliente dalCliente = new DALCliente();

                    recibo.Cliente = dalCliente.Load(registros.GetInt32(4));
                }      
                return recibo;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, DoLoad", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public Recibo DoLoad(IDataReader registros, Cliente cliente)
        {
            try
            {
                Recibo recibo = new Recibo();
                recibo.Id = registros.GetInt32(0);
                recibo.Numero = registros.GetString(1);
                Cobrador oCobrador = new Cobrador();

                try
                {
                    if (!registros.IsDBNull(2))
                    {


                        recibo.Cobrador = dalCobrador.Load(registros.GetInt32(2));
                    }
                }
                catch (Exception e)
                {
                    if (!registros.IsDBNull(2))
                    {

                        recibo.Cobrador = oCobrador;
                        recibo.Cobrador.Id = registros.GetInt32(2);
                    }
                    else
                    {
                        recibo.Cobrador = oCobrador;
                    }
                }

                if (recibo.Cobrador == null)
                {
                    recibo.Cobrador = oCobrador;
                }

                recibo.FechaCarga = registros.GetDateTime(5);
                recibo.SAP = registros.IsDBNull(6) ? "" : registros.GetString(6);
                recibo.TipoDeCambio = registros.IsDBNull(7) ? 0 : registros.GetDouble(7);
                recibo.UsadoRemision = registros.IsDBNull(8) ? false : registros.GetBoolean(8);

                if (!registros.IsDBNull(3) && recibo.Deudor == null)
                {
                    DALDeudor dalDeudor = new DALDeudor();
                    recibo.Deudor = dalDeudor.Load(registros.GetInt32(3));
                }

                recibo.Cliente = cliente;

                return recibo;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, DoLoad", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public Recibo GetReciboByNumReciboIdDeudorIdCliente(string pszNumRecibo, int IdDeudor, int IdCliente)
        {
            try
            {
                Recibo oReturn = null;
                CommandText = "PA_MG_FRONT_Recibo_SelectByNumReciboIdDeudorIdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@numRecibo", DbType.String, pszNumRecibo));
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, IdDeudor));
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, IdCliente));

                List<Recibo> recibos = AbstractFindAll(oParameters);
                if (recibos.Count > 0)
                {
                    oReturn = recibos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, GetReciboByNumReciboIdDeudorIdCliente", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public Recibo GetReciboByNumReciboIdCliente(string pszNumRecibo, int IdCliente)
        {
            try
            {
                Recibo oReturn = null;
                CommandText = "PA_MG_FRONT_Recibo_SelectByNumReciboIdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@numRecibo", DbType.String, pszNumRecibo));
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, IdCliente));

                List<Recibo> recibos = AbstractFindAll(oParameters);
                if (recibos.Count > 0)
                {
                    oReturn = recibos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, GetReciboByNumReciboIdCliente", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public void InsertRelacion(int idRecibo, int idRemision)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_Remision_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_recibo", DbType.Int32, idRecibo));
                oParameters.Add(new DBParametro("@id_remision", DbType.Int32, idRemision));

                ExecuteNonQuery(oParameters);


            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRecibo, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Recibo DoLoad(IDataReader registros, Recibo ent)
        {
            throw new NotImplementedException();
        }
    }


}
