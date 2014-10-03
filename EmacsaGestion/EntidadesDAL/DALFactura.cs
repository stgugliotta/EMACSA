using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;
using Common.DataContracts;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Factura
    /// </summary>
    public class DALFactura : AbstractMapper<Factura>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALFactura()
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
        ~DALFactura()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Factura
        /// </summary>
        /// <param name="idFactura"></param>                 
        /// <returns></returns>
        public Factura Load(int idFactura)
        {
            try
            {
                Factura oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Factura_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_factura", DbType.Int32, idFactura));

                List<Factura> facturas = AbstractFindAll(oParameters);
                if (facturas.Count > 0)
                {
                    oReturn = facturas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public void Delete(Factura oFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Factura_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_factura", DbType.Int32, oFactura.IdFactura));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public void Update(Factura oFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Factura_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_factura", DbType.Int32, oFactura.IdFactura));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oFactura.IdCliente));
                oParameters.Add(new DBParametro("@tipocobro", DbType.String, oFactura.TipoCobro));
                oParameters.Add(new DBParametro("@letra", DbType.String, oFactura.Letra));
                oParameters.Add(new DBParametro("@emision", DbType.Decimal, oFactura.Emision));
                oParameters.Add(new DBParametro("@numero_comp", DbType.Decimal, oFactura.NumeroComp));
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oFactura.IdDeudor));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oFactura.FechaVenc));
                oParameters.Add(new DBParametro("@fecha_cobro", DbType.DateTime, oFactura.FechaCobro));
                oParameters.Add(new DBParametro("@moneda", DbType.String, oFactura.Moneda));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oFactura.Importe));
                oParameters.Add(new DBParametro("@saldo", DbType.Double, oFactura.Saldo));
                oParameters.Add(new DBParametro("@id_estado_factura", DbType.Int32, oFactura.IdEstadoFactura));
                oParameters.Add(new DBParametro("@avisada", DbType.String, oFactura.Avisada));
                oParameters.Add(new DBParametro("@proxima_gestion", DbType.DateTime, oFactura.ProximaGestion));
                oParameters.Add(new DBParametro("@fecha_ingreso", DbType.DateTime, oFactura.FechaIngreso));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oFactura.Observaciones));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public void Insert(Factura oFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Factura_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_factura", DbType.Int32, oFactura.IdFactura));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oFactura.IdCliente));
                oParameters.Add(new DBParametro("@tipocobro", DbType.String, oFactura.TipoCobro));
                oParameters.Add(new DBParametro("@letra", DbType.String, oFactura.Letra));
                oParameters.Add(new DBParametro("@emision", DbType.Decimal, oFactura.Emision));
                oParameters.Add(new DBParametro("@numero_comp", DbType.Decimal, oFactura.NumeroComp));
                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oFactura.IdDeudor));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oFactura.FechaVenc));
                oParameters.Add(new DBParametro("@fecha_cobro", DbType.DateTime, oFactura.FechaCobro));
                oParameters.Add(new DBParametro("@moneda", DbType.String, oFactura.Moneda));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oFactura.Importe));
                oParameters.Add(new DBParametro("@saldo", DbType.Double, oFactura.Saldo));
                oParameters.Add(new DBParametro("@id_estado_factura", DbType.Int32, oFactura.IdEstadoFactura));
                oParameters.Add(new DBParametro("@avisada", DbType.String, oFactura.Avisada));
                oParameters.Add(new DBParametro("@proxima_gestion", DbType.DateTime, oFactura.ProximaGestion));
                oParameters.Add(new DBParametro("@fecha_ingreso", DbType.DateTime, oFactura.FechaIngreso));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oFactura.Observaciones));
                

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Factura de la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public List<Factura> GetAllFacturas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Factura_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Factura de la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public List<Factura> GetAllFacturasPorIdDeudor(int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SELECT_PorIdDeudor";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdDeudor", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public List<Factura> GetDataTableFacturasPorDeudorExclusivasParaUnaNuevaRendicionDeValores(int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdDeudor_ExclusivasParaUnaNuevaRendicionDeValores";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdDeudor", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        

        public List<Factura> GetDataTableFacturasPorDeudorQueNoEstenEnNingunRecibo(int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SELECT_PorIdDeudor_QueNoEstenEnNingunRecibo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdDeudor", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Factura de la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public List<Factura> GetAllFacturasPorIdDeudorProximaGestion(int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdDeudor_ProxGest";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdDeudorProximaGestion", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Factura> GetAllFacturasPorVariosIdDeudor(string idDeudores)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SELECT_PorVariosIdDeudores";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudores", DbType.String, idDeudores));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorVariosIdDeudor", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        
        public List<Factura> GetDataTableFacturasPorDeudorPosiblesDeEdicion(int idDeudor,string numRecibo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdDeudor_PosiblesDeEdicion";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@numRecibo", DbType.String, numRecibo));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdDeudorSinFiltroDeEstado", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public List<Factura> GetAllFacturasPorIdDeudorSinFiltroDeEstado(int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdDeudor_SinFiltroDeEstado";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdDeudorSinFiltroDeEstado", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        
             /// <summary>
        /// Metodo que retorna  todos los registros convertidos en una lista de Objetos
        /// Factura de la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        /// 
        

        public List<Factura> GetAllFacturasByCriteria(Factura oFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAll_ByCriteria";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@nro_comprobante", DbType.Int32, oFactura.NumeroComp));

                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasByCriteria", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Factura> GetAllFacturasByCriteriaTodosLosEstados(Factura oFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAllTodosLosEstados_ByCriteria";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@nro_comprobante", DbType.Int32, oFactura.NumeroComp));

                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasByCriteriaTodosLosEstados", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Factura> GetAllFacturasByNumeroCompleto(Factura oFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAll_NumeroCompleto";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@nro_comprobanteCompleto", DbType.String, oFactura.NumFacturaCompleto));

                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasByCriteria", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// Metodo que retorna  todos los registros convertidos en una lista de Objetos
        /// Factura de la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public List<Factura> GetAllFacturasPorIdClienteyIdDeudor(int idCliente, int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAll_ByIdClienteYIdDeudor";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdClienteyIdDeudor", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }




        public List<Factura> GetAllFacturasPorIdClienteyIdDeudorParaEstadoDeCuenta(int idCliente, int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAll_ByIdClienteYIdDeudorParaEstadoDeCuenta";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdClienteyIdDeudorParaEstadoDeCuenta", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// Metodo que retorna  todos los registros convertidos en una lista de Objetos
        /// Factura de la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public List<Factura> GetAllFacturasPorIdClienteyIdDeudorACobrar(int idCliente, int idDeudor, DateTime fechaProximaGestion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAll_ByIdClienteYIdDeudorACobrar";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@fecha_proxima_gestion", DbType.DateTime, fechaProximaGestion));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdClienteyIdDeudorACobrar", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        
        
        /// <summary>
        /// M?todo que crea un objeto Factura de la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public override Factura DoLoad(IDataReader registros)
        {
            try
            {
                Factura factura = new Factura();
                factura.IdFactura = registros.GetInt32(0);
                factura.IdCliente = registros.GetDecimal(1);
                factura.TipoCobro = registros.IsDBNull(2) ? string.Empty : registros.GetString(2);
                factura.Letra = registros.GetString(3);
                factura.Emision = registros.IsDBNull(4)? 0: registros.GetDecimal(4);
                factura.NumeroComp = registros.IsDBNull(5)? 0: decimal.Parse(registros.GetInt32(5).ToString());
                factura.IdDeudor = registros.GetInt32(6);
                factura.FechaVenc = registros.GetDateTime(7);
                factura.FechaCobro = registros.IsDBNull(8)? DateTime.MinValue : registros.GetDateTime(8);
                factura.Moneda = registros.IsDBNull(9)? "N/A":registros.GetString(9);
                factura.Importe = registros.GetDouble(10);
                factura.Saldo = registros.GetDouble(11);
                factura.IdEstadoFactura = registros.IsDBNull(12) ? 0 : registros.GetInt32(12);
                factura.Avisada = registros.IsDBNull(13) ? string.Empty : registros.GetString(13);
                factura.ProximaGestion = registros.IsDBNull(14) ? DateTime.MinValue  :  registros.GetDateTime(14);
                factura.FechaIngreso = registros.GetDateTime(15);
                factura.Observaciones = registros.IsDBNull(16) ? string.Empty : registros.GetString(16);
                factura.Estado = registros.IsDBNull(17) ? string.Empty : registros.GetString(17);
                
                factura.FechaEmision = registros.IsDBNull(18) ? DateTime.Now : registros.GetDateTime(18);
                factura.Id_Tipo_Comprobante = registros.IsDBNull(19) ? string.Empty : registros.GetString(19);
                try
                {
                    factura.IdRemision = registros.IsDBNull(20) ? 0 : registros.GetInt32(20);
                }
                catch (Exception)
                {

                    factura.IdRemision = 0;
                }
                try
                {
                    factura.EstadoRemision = registros.IsDBNull(21) ? string.Empty : registros.GetString(21); 
                }
                catch (Exception)
                {

                    factura.EstadoRemision = string.Empty; 
                }
                try
                {
                    factura.NumeroRecibo = registros.IsDBNull(22) ? string.Empty : registros.GetString(22);
                }
                catch (Exception)
                {

                    factura.NumeroRecibo = string.Empty;
                }

                try
                {
                    factura.MontoUltimaImputacion = registros.IsDBNull(23) ? 0 : double.Parse(registros.GetDecimal(23).ToString());
                }
                catch (Exception)
                {

                    factura.MontoUltimaImputacion = 0;
                }

                return factura;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Factura> GetAllFacturasPorIdDeudorEntreFechas(int idDeudor,DateTime fechaDesde,DateTime fechaHasta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdDeudorEntreFechas";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@fechaDesde", DbType.DateTime, fechaDesde));
                oParameters.Add(new DBParametro("@fechaHasta", DbType.DateTime, fechaHasta));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Factura> GetAllFacturasPorIdClienteEntreFechas(int idCliente, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdClienteEntreFechas";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fechaDesde", DbType.DateTime, fechaDesde));
                oParameters.Add(new DBParametro("@fechaHasta", DbType.DateTime, fechaHasta));
                List<Factura> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorClienteEntreFechas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<DeudorHojaDeRutaDataContracts> getHojaDeRuta(DateTime fechaProximaGestion)
        {
            CommandText = "p_select_crear_hoja_ruta";
            CommandType = CommandType.StoredProcedure;
            ArrayList oParameters = new ArrayList();
            oParameters.Add(new DBParametro("@proxima_gestion", DbType.Date, fechaProximaGestion));
            try
            {
                //ImportacionFacturaDataContracts
                List<IDictionary<string, string>> listDiccionario = ExecuteReader(oParameters);
                List<DeudorHojaDeRutaDataContracts> listaDTO = new List<DeudorHojaDeRutaDataContracts>();
                DeudorHojaDeRutaDataContracts dto = null;
                IEnumerator enume = listDiccionario.GetEnumerator();

                while (enume.MoveNext())
                {
                    IDictionary<string, string> dic = (IDictionary<string, string>)enume.Current;

                    dto = new DeudorHojaDeRutaDataContracts();
                    string aux;
                    dic.TryGetValue("id_deudor", out aux);
                    dto.IdDeudor = aux;
                    dic.TryGetValue("id_cliente", out aux);
                    dto.IdCliente = aux;
                    dic.TryGetValue("nombre_cliente", out aux);
                    dto.Cliente = aux;
                    dic.TryGetValue("nombre_deudor", out aux);
                    dto.Deudor = aux;
                    dic.TryGetValue("calle_nombre", out aux);
                    dto.Domicilio = aux;
                    dic.TryGetValue("calle_altura", out aux);
                    dto.Domicilio += " " + aux;
                    dic.TryGetValue("localidad", out aux);
                    dto.Localidad = aux;
                    dic.TryGetValue("provincia", out aux);
                    dto.Provincia = aux;
                    dic.TryGetValue("cp", out aux);
                    dto.Cp = aux;
                    //deudorHojaDeRuta.Horario = getDiasCobroDeudor(deudorDC.IdDeudor);
                    dic.TryGetValue("id_cobrador", out aux);
                    dto.IdCobrador = Int32.Parse(aux);
                    dic.TryGetValue("nombreApellidoCobrador", out aux);
                    dto.Cobrador = aux;

                    listaDTO.Add(dto);
                }

                //return ExecuteReader(oParameters);

                return listaDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return null;
        }



        public override Factura DoLoad(IDataReader registros, Factura ent)
        {
            throw new NotImplementedException();
        }
    }
}
