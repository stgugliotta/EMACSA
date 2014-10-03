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
    public class DALFacturaHistorialDeudor : AbstractMapper<FacturaHistorialDeudor>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALFacturaHistorialDeudor()
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
        ~DALFacturaHistorialDeudor()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Factura
        /// </summary>
        /// <param name="idFactura"></param>                 
        /// <returns></returns>
        public FacturaHistorialDeudor Load(int idFactura)
        {
            try
            {
                FacturaHistorialDeudor oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Factura_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_factura", DbType.Int32, idFactura));

                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);
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
        public void Delete(FacturaHistorialDeudor oFactura)
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
        public void Update(FacturaHistorialDeudor oFactura)
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
        public void Insert(FacturaHistorialDeudor oFactura)
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
        public List<FacturaHistorialDeudor> GetAllFacturas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Factura_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

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
        public List<FacturaHistorialDeudor> GetAllFacturasPorIdDeudor(int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SELECT_PorIdDeudor";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<FacturaHistorialDeudor> GetAllFacturasPorVariosIdDeudor(string idDeudores)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SELECT_PorVariosIdDeudores";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudores", DbType.String, idDeudores));
                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<FacturaHistorialDeudor> GetAllFacturasPorIdDeudorSinFiltroDeEstado(int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdDeudor_SinFiltroDeEstado";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

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
        public List<FacturaHistorialDeudor> GetAllFacturasByCriteria(FacturaHistorialDeudor oFactura)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAll_ByCriteria";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@nro_comprobante", DbType.Int32, oFactura.NumeroComp));

                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

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
        public List<FacturaHistorialDeudor> GetAllFacturasPorIdClienteyIdDeudor(int idCliente, int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAll_ByIdClienteYIdDeudor";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));

                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, GetAllFacturasPorIdClienteyIdDeudor", ex.Message);

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
        public List<FacturaHistorialDeudor> GetAllFacturasPorIdClienteyIdDeudorACobrar(int idCliente, int idDeudor, DateTime fechaProximaGestion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_SelectAll_ByIdClienteYIdDeudorACobrar";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@fecha_proxima_gestion", DbType.DateTime, fechaProximaGestion));
                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        
        
        /// <summary>
        /// M?todo que crea un objeto Factura de la tabla dbo.MTR_Factura
        /// </summary>
        /// <param name="oFactura"></param>
        /// <returns></returns>
        public override FacturaHistorialDeudor DoLoad(IDataReader registros)
        {
            try
            {
                FacturaHistorialDeudor factura = new FacturaHistorialDeudor();
                factura.IdFactura = registros.GetInt32(0);
                factura.Letra = registros.GetString(1);
                factura.NumeroComp = registros.IsDBNull(2)? 0: decimal.Parse(registros.GetInt32(2).ToString());
                factura.FechaVenc = registros.GetDateTime(3);
                factura.Importe = registros.GetDouble(4);
                factura.FechaActividad =registros.GetDateTime(5);
                factura.Usuario = registros.GetString(6);
                factura.Observaciones = registros.GetString(7);
                factura.Estado = registros.GetString(8);
                return factura;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<FacturaHistorialDeudor> GetAllFacturasPorIdDeudorEntreFechas(int idDeudor, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdDeudorEntreFechas_ParaHistorial";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@fechaDesde", DbType.DateTime, fechaDesde));
                oParameters.Add(new DBParametro("@fechaHasta", DbType.DateTime, fechaHasta));
                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

                return facturas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALFactura, getFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<FacturaHistorialDeudor> GetAllFacturasPorIdClienteEntreFechas(int idCliente, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Factura_Select_PorIdClienteEntreFechas";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fechaDesde", DbType.DateTime, fechaDesde));
                oParameters.Add(new DBParametro("@fechaHasta", DbType.DateTime, fechaHasta));
                List<FacturaHistorialDeudor> facturas = AbstractFindAll(oParameters);

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



        public override FacturaHistorialDeudor DoLoad(IDataReader registros, FacturaHistorialDeudor ent)
        {
            throw new NotImplementedException();
        }
    }
}
