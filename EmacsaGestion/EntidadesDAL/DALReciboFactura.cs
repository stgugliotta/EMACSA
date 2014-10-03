using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;
using System.Data.SqlClient;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Recibo_Factura
    /// </summary>
    public class DALReciboFactura : AbstractMapper<ReciboFactura>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALReciboFactura()
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
        ~DALReciboFactura()
        {
            //ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  ReciboFactura
        /// </summary>
        /// <param name="id"></param>       
        /// <returns></returns>
        public ReciboFactura Load(int id)
        {
            try
            {
                ReciboFactura oReturn = null;
                CommandText = "PA_MG_FRONT_ReciboFactura_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<ReciboFactura> recibofacturas = AbstractFindAll(oParameters);
                if (recibofacturas.Count > 0)
                {
                    oReturn = recibofacturas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Recibo_Factura
        /// </summary>
        /// <param name="oReciboFactura"></param>
        /// <returns></returns>
        public void Delete(ReciboFactura oReciboFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_ReciboFactura_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReciboFactura.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Recibo_Factura
        /// </summary>
        /// <param name="oReciboFactura"></param>
        /// <returns></returns>
        public void Update(ReciboFactura oReciboFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_ReciboFactura_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReciboFactura.Id));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oReciboFactura.NumRecibo));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oReciboFactura.IdFactura));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oReciboFactura.Importe));
                oParameters.Add(new DBParametro("@importeaimputar", DbType.Double, oReciboFactura.ImporteAImputar));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oReciboFactura.Observacion));
                oParameters.Add(new DBParametro("@importeprontopago", DbType.String, oReciboFactura.ImporteProntoPago));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Recibo_Factura
        /// </summary>
        /// <param name="oReciboFactura"></param>
        /// <returns></returns>
        public void Insert(ReciboFactura oReciboFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_Factura_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReciboFactura.Id));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oReciboFactura.NumRecibo));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oReciboFactura.IdFactura));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oReciboFactura.Importe));
                oParameters.Add(new DBParametro("@importeaimputar", DbType.Double, oReciboFactura.ImporteAImputar));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oReciboFactura.Observacion));
                oParameters.Add(new DBParametro("@importeprontopago", DbType.String, oReciboFactura.ImporteProntoPago));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Recibo_Factura
        /// </summary>
        /// <param name="oReciboFactura"></param>
        /// <returns></returns>
        public int InsertEscalar(ReciboFactura oReciboFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_Factura_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReciboFactura.Id));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oReciboFactura.NumRecibo));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oReciboFactura.IdFactura));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oReciboFactura.Importe));
                oParameters.Add(new DBParametro("@importeaimputar", DbType.Double, oReciboFactura.ImporteAImputar));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oReciboFactura.Observacion));
                oParameters.Add(new DBParametro("@importeprontopago", DbType.String, oReciboFactura.ImporteProntoPago));
                oParameters.Add(new DBParametro("@saldo", DbType.Double, oReciboFactura.Saldo));
             

                //ExecuteNonQuery(oParameters);

               ExecuteScalar(oParameters, this.ObjConnection);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
            return 0;
        }


        //public int InsertEscalar(ReciboFactura oReciboFactura, int idRecibo)
        //{
        //    try
        //    {
        //        CommandText = "PA_MG_FRONT_Recibo_Factura_Insert_2";
        //        CommandType = CommandType.StoredProcedure;
        //        ArrayList oParameters = new ArrayList();

        //        oParameters.Add(new SqlParameter("@id", oReciboFactura.Id));
                
        //        oParameters.Add(new SqlParameter("@numrecibo", oReciboFactura.NumRecibo));
        //        oParameters.Add(new SqlParameter("@idfactura", oReciboFactura.IdFactura));
        //        oParameters.Add(new SqlParameter("@importe",oReciboFactura.Importe));
        //        oParameters.Add(new SqlParameter("@importeaimputar", oReciboFactura.ImporteAImputar));
        //        oParameters.Add(new SqlParameter("@observacion", oReciboFactura.Observacion));
        //        oParameters.Add(new SqlParameter("@importeprontopago", oReciboFactura.ImporteProntoPago));
        //        SqlParameter pa = new SqlParameter();
        //        pa.DbType  = DbType.Decimal;
        //        pa.ParameterName = "@saldo";
        //        pa.Scale = 4;
        //        pa.Value = Convert.ToDecimal(oReciboFactura.Saldo);

        //        oParameters.Add(pa);

        //        //oParameters.Add(new SqlParameter("@saldo", SqlDbType.Decimal  ,4,ParameterDirection.Input ,true,4,4,null,null, Convert.ToDecimal(oReciboFactura.Saldo)));

        //        //oParameters.Add(param);
        //        oParameters.Add(new SqlParameter("@idRecibo",idRecibo));


        //        //ExecuteNonQuery(oParameters);

        //        ExecuteScalarWithScale(oParameters, this.ObjConnection);
        //    }
        //    catch (Exception ex)
        //    {
        //        Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, Insert", ex.Message);

        //        throw new GobbiTechnicalException(
        //            string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
        //    }
        //    return 0;
        //}

        public int InsertEscalar(ReciboFactura oReciboFactura, int idRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_Factura_Insert_2";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReciboFactura.Id));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oReciboFactura.NumRecibo));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oReciboFactura.IdFactura));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oReciboFactura.Importe));
                oParameters.Add(new DBParametro("@importeaimputar", DbType.Double, oReciboFactura.ImporteAImputar));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oReciboFactura.Observacion));
                oParameters.Add(new DBParametro("@importeprontopago", DbType.String, oReciboFactura.ImporteProntoPago));
                oParameters.Add(new DBParametro("@saldo", DbType.Double, oReciboFactura.Saldo));
                oParameters.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));

               
                //ExecuteNonQuery(oParameters);

                ExecuteScalar(oParameters, this.ObjConnection);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
            return 0;
        }

        public int InsertEscalar(ReciboFactura oReciboFactura, int idRecibo, System.Data.Common.DbConnection con)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Recibo_Factura_Insert_2";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oReciboFactura.Id));
                oParameters.Add(new DBParametro("@numrecibo", DbType.String, oReciboFactura.NumRecibo));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oReciboFactura.IdFactura));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oReciboFactura.Importe));
                oParameters.Add(new DBParametro("@importeaimputar", DbType.Double, oReciboFactura.ImporteAImputar));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oReciboFactura.Observacion));
                oParameters.Add(new DBParametro("@importeprontopago", DbType.String, oReciboFactura.ImporteProntoPago));
                oParameters.Add(new DBParametro("@saldo", DbType.Double, oReciboFactura.Saldo));
                oParameters.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));


                //ExecuteNonQuery(oParameters);

                ExecuteScalar(oParameters, con);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
            return 0;
        }
        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// ReciboFactura de la tabla dbo.TBL_Recibo_Factura
        /// </summary>
        /// <param name="oReciboFactura"></param>
        /// <returns></returns>
        public List<ReciboFactura> GetAllReciboFacturas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_ReciboFactura_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<ReciboFactura> recibofacturas = AbstractFindAll(oParameters);

                return recibofacturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, getReciboFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<ReciboFactura> GetAllReciboFacturasByIdRecibo(int idRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_ReciboFactura_SELECTALL_ByIdRecibo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));
                List<ReciboFactura> recibofacturas = AbstractFindAll(oParameters);

                return recibofacturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, getReciboFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que crea un objeto ReciboFactura de la tabla dbo.TBL_Recibo_Factura
        /// </summary>
        /// <param name="oReciboFactura"></param>
        /// <returns></returns>
        public override ReciboFactura DoLoad(IDataReader registros)
        {
            try
            {
                ReciboFactura recibofactura = new ReciboFactura();
                recibofactura.Id = registros.GetInt32(0);
                recibofactura.NumRecibo = registros.GetString(1);
                recibofactura.IdFactura = registros.GetInt32(2);
                recibofactura.Importe = registros.GetDouble(3);
                recibofactura.ImporteAImputar = registros.GetDouble(4);
                recibofactura.Observacion = registros.GetString(5);
                recibofactura.ImporteProntoPago = registros.GetDouble(6).ToString();
                recibofactura.Moneda = registros.GetString(8).ToString();
                                
                //recibofactura.Saldo = registros.GetDouble(7);

                return recibofactura;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALReciboFactura, getReciboFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override ReciboFactura DoLoad(IDataReader registros, ReciboFactura ent)
        {
            throw new NotImplementedException();
        }
    }
}
