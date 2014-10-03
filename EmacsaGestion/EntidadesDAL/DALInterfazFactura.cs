using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Herramientas;
using Common.DataContracts;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.INT_Factura
    /// </summary>
    public class DALInterfazFactura : AbstractMapper<InterfazFactura>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALInterfazFactura()
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
        ~DALInterfazFactura()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  InterfazFactura
        /// </summary>
        /// <param name="idConfiguracion"></param>   
        /// <returns></returns>
        public InterfazFactura Load(decimal idInterfazFactura)
        {
            try
            {
                InterfazFactura oReturn = null;
                //CommandText = "PA_GOBBI_InterfazFactura_SELECT";
                CommandText = "PA_MG_FRONT_INT_Factura_Select";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_interfaz_factura", DbType.Decimal, idInterfazFactura));

                List<InterfazFactura> InterfazFacturas = AbstractFindAll(oParameters);
                if (InterfazFacturas.Count > 0)
                {
                    oReturn = InterfazFacturas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.INT_Factura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        /// <returns></returns>
        public void Delete(InterfazFactura oInterfazFactura)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_DELETE";
                CommandText = "PA_MG_FRONT_INT_Factura_Delete";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_interfaz_factura", DbType.Decimal, oInterfazFactura.IdIntefazFactura));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.INT_Factura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        /// <returns></returns>
        public void Update(InterfazFactura oInterfazFactura)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_UPDATE";
                CommandText = "PA_MG_FRONT_INT_Factura_Update";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_interfaz_factura", DbType.Decimal, oInterfazFactura.IdIntefazFactura));
                oParameters.Add(new DBParametro("@fecha_proceso", DbType.DateTime, oInterfazFactura.FechaProceso));
                oParameters.Add(new DBParametro("@linea", DbType.Int16, oInterfazFactura.Linea));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oInterfazFactura.IdCliente));
                oParameters.Add(new DBParametro("@id_deudor", DbType.String, oInterfazFactura.IdDeudor));
                oParameters.Add(new DBParametro("@id_tipo_comprobante", DbType.String, oInterfazFactura.IdTipoComprobante));
                oParameters.Add(new DBParametro("@letra", DbType.String, oInterfazFactura.Letra));
                oParameters.Add(new DBParametro("@emision", DbType.String, oInterfazFactura.Emision));
                oParameters.Add(new DBParametro("@numero_pag", DbType.Int16, oInterfazFactura.NumeroPag));
                oParameters.Add(new DBParametro("@cantidad_p", DbType.Int16, oInterfazFactura.CantidadP));
                oParameters.Add(new DBParametro("@nro_comprobante", DbType.String, oInterfazFactura.NroComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oInterfazFactura.Importe));
                oParameters.Add(new DBParametro("@saldo", DbType.Double, oInterfazFactura.Saldo));
                oParameters.Add(new DBParametro("@id_moneda", DbType.String, oInterfazFactura.IdMoneda));
                oParameters.Add(new DBParametro("@fecha_emision", DbType.DateTime, oInterfazFactura.FechaEmision));
                oParameters.Add(new DBParametro("@fecha_vencimiento", DbType.DateTime, oInterfazFactura.FechaVencimiento));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oInterfazFactura.Observaciones));
                oParameters.Add(new DBParametro("@estado", DbType.String, oInterfazFactura.Estado));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.INT_Factura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        /// <returns></returns>
        public void Insert(InterfazFactura oInterfazFactura)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_INSERT";
                CommandText = "PA_MG_FRONT_INT_Factura_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@fecha_proceso", DbType.DateTime, oInterfazFactura.FechaProceso));
                oParameters.Add(new DBParametro("@linea", DbType.Int16, oInterfazFactura.Linea));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oInterfazFactura.IdCliente));
                oParameters.Add(new DBParametro("@id_deudor", DbType.String, oInterfazFactura.IdDeudor));
                oParameters.Add(new DBParametro("@id_tipo_comprobante", DbType.String, oInterfazFactura.IdTipoComprobante));
                oParameters.Add(new DBParametro("@letra", DbType.String, oInterfazFactura.Letra));
                oParameters.Add(new DBParametro("@emision", DbType.String, oInterfazFactura.Emision));
                oParameters.Add(new DBParametro("@numero_pag", DbType.Int16, oInterfazFactura.NumeroPag));
                oParameters.Add(new DBParametro("@cantidad_p", DbType.Int16, oInterfazFactura.CantidadP));
                oParameters.Add(new DBParametro("@nro_comprobante", DbType.String, oInterfazFactura.NroComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oInterfazFactura.Importe));
                oParameters.Add(new DBParametro("@saldo", DbType.Double, oInterfazFactura.Saldo));
                oParameters.Add(new DBParametro("@id_moneda", DbType.String, oInterfazFactura.IdMoneda));
                oParameters.Add(new DBParametro("@fecha_emision", DbType.DateTime, oInterfazFactura.FechaEmision));
                oParameters.Add(new DBParametro("@fecha_vencimiento", DbType.DateTime, oInterfazFactura.FechaVencimiento));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oInterfazFactura.Observaciones));
                oParameters.Add(new DBParametro("@estado", DbType.String, oInterfazFactura.Estado));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public void InsertPreview(InterfazFactura oInterfazFactura)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_INSERT";
                CommandText = "PA_MG_FRONT_INT_Factura_Insert_Preview";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@fecha_proceso", DbType.DateTime, oInterfazFactura.FechaProceso));
                oParameters.Add(new DBParametro("@linea", DbType.Int16, oInterfazFactura.Linea));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oInterfazFactura.IdCliente));
                oParameters.Add(new DBParametro("@id_deudor", DbType.String, oInterfazFactura.IdDeudor));
                oParameters.Add(new DBParametro("@id_tipo_comprobante", DbType.String, oInterfazFactura.IdTipoComprobante));
                oParameters.Add(new DBParametro("@letra", DbType.String, oInterfazFactura.Letra));
                oParameters.Add(new DBParametro("@emision", DbType.String, oInterfazFactura.Emision));
                oParameters.Add(new DBParametro("@numero_pag", DbType.Int16, oInterfazFactura.NumeroPag));
                oParameters.Add(new DBParametro("@cantidad_p", DbType.Int16, oInterfazFactura.CantidadP));
                oParameters.Add(new DBParametro("@nro_comprobante", DbType.String, oInterfazFactura.NroComprobante));
                oParameters.Add(new DBParametro("@importe", DbType.Double, oInterfazFactura.Importe));
                oParameters.Add(new DBParametro("@saldo", DbType.Double, oInterfazFactura.Saldo));
                oParameters.Add(new DBParametro("@id_moneda", DbType.String, oInterfazFactura.IdMoneda));
                oParameters.Add(new DBParametro("@fecha_emision", DbType.DateTime, oInterfazFactura.FechaEmision));
                oParameters.Add(new DBParametro("@fecha_vencimiento", DbType.DateTime, oInterfazFactura.FechaVencimiento));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oInterfazFactura.Observaciones));
                oParameters.Add(new DBParametro("@estado", DbType.String, oInterfazFactura.Estado));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, InsertPreview", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        public void TruncateTablePreview()
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_INSERT";
                CommandText = "PA_MG_FRONT_INT_Factura_Truncate_Table_Preview";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

               
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }

        }

        public void DeleteLastImport(int idCliente)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_INSERT";
                CommandText = "PA_MG_FRONT_INT_Factura_DeleteLastImport";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }

        }

        public void DeleteLastImportPreview(int idCliente)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_INSERT";
                CommandText = "PA_MG_FRONT_INT_Factura_DeleteLastImport_Preview";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }

        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// InterfazFactura de la tabla dbo.INT_Factura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        /// <returns></returns>
        public List<InterfazFactura> GetAllInterfazFacturas()
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_SELECTALL";
                CommandText = "PA_MG_FRONT_INT_Factura_SelectALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<InterfazFactura> InterfazFacturas = AbstractFindAll(oParameters);

                return InterfazFacturas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, getInterfazFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro de un cliente dado, convertido e nuna lista de Objetos
        /// InterfazFactura de la tabla dbo.INT_Factura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        /// <returns></returns>
        public List<InterfazFactura> GetAllInterfazFacturasByCliente(int idCliente)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_SELECTALL";
                CommandText = "PA_MG_FRONT_INT_Factura_Select_ByIdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));

                List<InterfazFactura> InterfazFacturas = AbstractFindAll(oParameters);

                return InterfazFacturas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, getInterfazFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<InterfazFactura> GetAllFacturasBajaPorInterfazByClienteFechaProceso(int idCliente, DateTime fechaProceso)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_SELECTALL";
                CommandText = "PA_MG_FRONT_MTR_Factura_baja_int_ByIdCliente_FechaProceso";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fechaProceso", DbType.DateTime , fechaProceso));

                List<InterfazFactura> InterfazFacturas = AbstractFindAll(oParameters);

                return InterfazFacturas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, getInterfazFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


         public List<InterfazFactura> GetAllFacturasBajaPorInterfazByClienteFechaProcesoPreview(int idCliente, DateTime fechaProceso)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_SELECTALL";
                CommandText = "PA_MG_FRONT_MTR_Factura_baja_int_ByIdCliente_FechaProceso_Preview";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fechaProceso", DbType.DateTime , fechaProceso));

                List<InterfazFactura> InterfazFacturas = AbstractFindAll(oParameters);

                return InterfazFacturas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, getInterfazFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<InterfazFactura> GetAllInterfazFacturasByClienteFechaProceso(int idCliente,DateTime fechaProceso)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_SELECTALL";
                CommandText = "PA_MG_FRONT_INT_Factura_Select_ByIdClienteFechaProceso";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fechaProceso", DbType.DateTime , fechaProceso));

                List<InterfazFactura> InterfazFacturas = AbstractFindAll(oParameters);

                return InterfazFacturas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, getInterfazFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        public List<InterfazFactura> GetAllInterfazFacturasByClienteFechaProcesoPreview(int idCliente, DateTime fechaProceso)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_SELECTALL";
                CommandText = "PA_MG_FRONT_INT_Factura_Select_ByIdClienteFechaProceso_Preview";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fechaProceso", DbType.DateTime, fechaProceso));

                List<InterfazFactura> InterfazFacturas = AbstractFindAll(oParameters);

                return InterfazFacturas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, getInterfazFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro de un cliente dado, convertido e nuna lista de Objetos
        /// InterfazFactura de la tabla dbo.INT_Factura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        /// <returns></returns>
        public List<InterfazFactura> GetAllFacturasBajaPorInterfazByCliente(int idCliente)
        {
            try
            {
                //CommandText = "PA_GOBBI_InterfazFactura_SELECTALL";
                CommandText = "PA_MG_FRONT_MTR_Factura_baja_int_ByIdCliente_FechaProceso";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));

                List<InterfazFactura> InterfazFacturas = AbstractFindAll(oParameters);

                return InterfazFacturas;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, getInterfazFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro de un cliente dado, convertido e nuna lista de Objetos
        /// InterfazFactura de la tabla dbo.INT_Factura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        /// <returns></returns>
        public List<ImportacionFacturaDataContracts> ProcessInterfazFacturasByClientePreview(int idCliente, string idUsuario)
        {
            try
            {
                List<InterfazFactura> InterfazFacturas = null;

                CommandText = "p_ingresar_interfaces_preview";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@id_usuario", DbType.String, idUsuario));

                ExecuteNonQuery(oParameters);

                /*InterfazFacturas = GetAllInterfazFacturasByCliente(idCliente);
                return InterfazFacturas;*/
                return getProcessResultInterfazFacturasByClientePreview(idCliente);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, ProcessInterfazFacturasByCliente", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<ImportacionFacturaDataContracts> ProcessInterfazFacturasByCliente(int idCliente, string idUsuario)
        {
            try
            {
                List<InterfazFactura> InterfazFacturas = null;

                CommandText = "p_ingresar_interfaces";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@id_usuario", DbType.String, idUsuario));

                ExecuteNonQuery(oParameters);

                /*InterfazFacturas = GetAllInterfazFacturasByCliente(idCliente);
                return InterfazFacturas;*/
                return getProcessResultInterfazFacturasByCliente(idCliente);
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, ProcessInterfazFacturasByCliente", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<ImportacionFacturaDataContracts>  getProcessResultInterfazFacturasByCliente(int idCliente) {
            CommandText = "p_mostrar_totales_procesamiento";
            CommandType = CommandType.StoredProcedure;
            ArrayList oParameters = new ArrayList();
            oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));

            //ImportacionFacturaDataContracts
            List<IDictionary<string, string>> listDiccionario = ExecuteReader(oParameters);
            List<ImportacionFacturaDataContracts> listaDTO = new List<ImportacionFacturaDataContracts>();
            ImportacionFacturaDataContracts dto = null;
            IEnumerator enume =  listDiccionario.GetEnumerator();

            while (enume.MoveNext())
            {
                IDictionary<string, string> dic = (IDictionary<string, string>)enume.Current;

                dto = new ImportacionFacturaDataContracts();
                string idcli;
                dic.TryGetValue("id_cliente", out idcli);
                dto.IdCliente = Decimal.Parse(idcli);
                string NOMBRE;
                dic.TryGetValue("nombre", out NOMBRE);
                dto.NOMBRE = NOMBRE;
                string CUIT;
                dic.TryGetValue("cuit", out CUIT);
                dto.CUIT = CUIT;
                string RegistrosEnviados;
                dic.TryGetValue("registros_enviados", out RegistrosEnviados);
                dto.RegistrosEnviados = RegistrosEnviados;
                string RegistrosIngresados;
                dic.TryGetValue("registros_ingresados", out RegistrosIngresados);
                dto.RegistrosIngresados = RegistrosIngresados;

                string InsersionModificacion;
                dic.TryGetValue("insersion_modificacion", out InsersionModificacion);
                dto.InsersionModificacion = InsersionModificacion;
                string RegistrosRechazados;
                dic.TryGetValue("registros_rechazados", out RegistrosRechazados);
                dto.RegistrosRechazados = RegistrosRechazados;

                string DocumentosBaja;
                dic.TryGetValue("documentos_baja", out DocumentosBaja);
                dto.DocumentosBaja = DocumentosBaja;
                string fecproc;
                dic.TryGetValue("fecha_proceso", out fecproc);
                dto.FechaProceso = DateTime.Parse( fecproc);
                listaDTO.Add(dto);


            }

            //return ExecuteReader(oParameters);

            return listaDTO;
        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasByClientePreview(int idCliente)
        {
            CommandText = "p_mostrar_totales_procesamiento_preview";
            CommandType = CommandType.StoredProcedure;
            ArrayList oParameters = new ArrayList();
            oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32, idCliente));

            //ImportacionFacturaDataContracts
            List<IDictionary<string, string>> listDiccionario = ExecuteReader(oParameters);
            List<ImportacionFacturaDataContracts> listaDTO = new List<ImportacionFacturaDataContracts>();
            ImportacionFacturaDataContracts dto = null;
            IEnumerator enume = listDiccionario.GetEnumerator();

            while (enume.MoveNext())
            {
                IDictionary<string, string> dic = (IDictionary<string, string>)enume.Current;

                dto = new ImportacionFacturaDataContracts();
                string idcli;
                dic.TryGetValue("id_cliente", out idcli);
                dto.IdCliente = Decimal.Parse(idcli);
                string NOMBRE;
                dic.TryGetValue("nombre", out NOMBRE);
                dto.NOMBRE = NOMBRE;
                string CUIT;
                dic.TryGetValue("cuit", out CUIT);
                dto.CUIT = CUIT;
                string RegistrosEnviados;
                dic.TryGetValue("registros_enviados", out RegistrosEnviados);
                dto.RegistrosEnviados = RegistrosEnviados;
                string RegistrosIngresados;
                dic.TryGetValue("registros_ingresados", out RegistrosIngresados);
                dto.RegistrosIngresados = RegistrosIngresados;

                string InsersionModificacion;
                dic.TryGetValue("insersion_modificacion", out InsersionModificacion);
                dto.InsersionModificacion = InsersionModificacion;
                string RegistrosRechazados;
                dic.TryGetValue("registros_rechazados", out RegistrosRechazados);
                dto.RegistrosRechazados = RegistrosRechazados;

                string DocumentosBaja;
                dic.TryGetValue("documentos_baja", out DocumentosBaja);
                dto.DocumentosBaja = DocumentosBaja;
                string fecproc;
                dic.TryGetValue("fecha_proceso", out fecproc);
                dto.FechaProceso = DateTime.Parse(fecproc);
                listaDTO.Add(dto);


            }

            //return ExecuteReader(oParameters);

            return listaDTO;
        }


        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturas()
        {
            CommandText = "p_mostrar_totales_procesamiento";
            CommandType = CommandType.StoredProcedure;
            ArrayList oParameters = new ArrayList();

            List<IDictionary<string, string>> listDiccionario = ExecuteReader(oParameters);
            List<ImportacionFacturaDataContracts> listaDTO = new List<ImportacionFacturaDataContracts>();
            ImportacionFacturaDataContracts dto = null;
            IEnumerator enume = listDiccionario.GetEnumerator();

            while (enume.MoveNext())
            {
                IDictionary<string, string> dic = (IDictionary<string, string>)enume.Current;

                dto = new ImportacionFacturaDataContracts();
                string idcli;
                dic.TryGetValue("id_cliente", out idcli);
                dto.IdCliente = Decimal.Parse(idcli);
                string NOMBRE;
                dic.TryGetValue("nombre", out NOMBRE);
                dto.NOMBRE = NOMBRE;
                string CUIT;
                dic.TryGetValue("cuit", out CUIT);
                dto.CUIT = CUIT;
                string RegistrosEnviados;
                dic.TryGetValue("registros_enviados", out RegistrosEnviados);
                dto.RegistrosEnviados = RegistrosEnviados;
                string RegistrosIngresados;
                dic.TryGetValue("registros_ingresados", out RegistrosIngresados);
                dto.RegistrosIngresados = RegistrosIngresados;

                string InsersionModificacion;
                dic.TryGetValue("insersion_modificacion", out InsersionModificacion);
                dto.InsersionModificacion = InsersionModificacion;
               

                string RegistrosActualizados;
                dic.TryGetValue("registros_actualizados", out RegistrosActualizados);
                dto.RegistrosActualizados = RegistrosActualizados;

                string RegistrosRechazados;
                dic.TryGetValue("registros_rechazados", out RegistrosRechazados);
                dto.RegistrosRechazados = RegistrosRechazados ;

                string RegistrosExistentes;
                dic.TryGetValue("registros_existentes", out RegistrosExistentes);
                dto.RegistrosExistentes = RegistrosExistentes;


                string DocumentosBaja;
                dic.TryGetValue("documentos_baja", out DocumentosBaja);
                dto.DocumentosBaja = DocumentosBaja;
                string fecproc;
                dic.TryGetValue("fecha_proceso", out fecproc);
                dto.FechaProceso = DateTime.Parse(fecproc);
                listaDTO.Add(dto);


            }

            //return ExecuteReader(oParameters);

            return listaDTO;
        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFecha(DateTime fecha)
        {
            CommandText = "p_mostrar_totales_procesamiento_PorFecha";
            CommandType = CommandType.StoredProcedure;
            ArrayList oParameters = new ArrayList();
            oParameters.Add(new DBParametro("@fecha", DbType.DateTime , fecha));

            List<IDictionary<string, string>> listDiccionario = ExecuteReader(oParameters);
            List<ImportacionFacturaDataContracts> listaDTO = new List<ImportacionFacturaDataContracts>();
            ImportacionFacturaDataContracts dto = null;
            IEnumerator enume = listDiccionario.GetEnumerator();

            while (enume.MoveNext())
            {
                IDictionary<string, string> dic = (IDictionary<string, string>)enume.Current;

                dto = new ImportacionFacturaDataContracts();
                string idcli;
                dic.TryGetValue("id_cliente", out idcli);
                dto.IdCliente = Decimal.Parse(idcli);
                string NOMBRE;
                dic.TryGetValue("nombre", out NOMBRE);
                dto.NOMBRE = NOMBRE;
                string CUIT;
                dic.TryGetValue("cuit", out CUIT);
                dto.CUIT = CUIT;
                string RegistrosEnviados;
                dic.TryGetValue("registros_enviados", out RegistrosEnviados);
                dto.RegistrosEnviados = RegistrosEnviados;
                string RegistrosIngresados;
                dic.TryGetValue("registros_ingresados", out RegistrosIngresados);
                dto.RegistrosIngresados = RegistrosIngresados;

                string InsersionModificacion;
                dic.TryGetValue("insersion_modificacion", out InsersionModificacion);
                dto.InsersionModificacion = InsersionModificacion;


                string RegistrosActualizados;
                dic.TryGetValue("registros_actualizados", out RegistrosActualizados);
                dto.RegistrosActualizados = RegistrosActualizados;

                string RegistrosRechazados;
                dic.TryGetValue("registros_rechazados", out RegistrosRechazados);
                dto.RegistrosRechazados = RegistrosRechazados;

                string RegistrosExistentes;
                dic.TryGetValue("registros_existentes", out RegistrosExistentes);
                dto.RegistrosExistentes = RegistrosExistentes;


                string DocumentosBaja;
                dic.TryGetValue("documentos_baja", out DocumentosBaja);
                dto.DocumentosBaja = DocumentosBaja;
                string fecproc;
                dic.TryGetValue("fecha_proceso", out fecproc);
                dto.FechaProceso = DateTime.Parse(fecproc);
                listaDTO.Add(dto);


            }

            //return ExecuteReader(oParameters);

            return listaDTO;
        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFechaPreview(DateTime fecha)
        {
            CommandText = "p_mostrar_totales_procesamiento_PorFecha_Preview";
            CommandType = CommandType.StoredProcedure;
            ArrayList oParameters = new ArrayList();
            oParameters.Add(new DBParametro("@fecha", DbType.DateTime, fecha));

            List<IDictionary<string, string>> listDiccionario = ExecuteReader(oParameters);
            List<ImportacionFacturaDataContracts> listaDTO = new List<ImportacionFacturaDataContracts>();
            ImportacionFacturaDataContracts dto = null;
            IEnumerator enume = listDiccionario.GetEnumerator();

            while (enume.MoveNext())
            {
                IDictionary<string, string> dic = (IDictionary<string, string>)enume.Current;

                dto = new ImportacionFacturaDataContracts();
                string idcli;
                dic.TryGetValue("id_cliente", out idcli);
                dto.IdCliente = Decimal.Parse(idcli);
                string NOMBRE;
                dic.TryGetValue("nombre", out NOMBRE);
                dto.NOMBRE = NOMBRE;
                string CUIT;
                dic.TryGetValue("cuit", out CUIT);
                dto.CUIT = CUIT;
                string RegistrosEnviados;
                dic.TryGetValue("registros_enviados", out RegistrosEnviados);
                dto.RegistrosEnviados = RegistrosEnviados;
                string RegistrosIngresados;
                dic.TryGetValue("registros_ingresados", out RegistrosIngresados);
                dto.RegistrosIngresados = RegistrosIngresados;

                string InsersionModificacion;
                dic.TryGetValue("insersion_modificacion", out InsersionModificacion);
                dto.InsersionModificacion = InsersionModificacion;


                string RegistrosActualizados;
                dic.TryGetValue("registros_actualizados", out RegistrosActualizados);
                dto.RegistrosActualizados = RegistrosActualizados;

                string RegistrosRechazados;
                dic.TryGetValue("registros_rechazados", out RegistrosRechazados);
                dto.RegistrosRechazados = RegistrosRechazados;

                string RegistrosExistentes;
                dic.TryGetValue("registros_existentes", out RegistrosExistentes);
                dto.RegistrosExistentes = RegistrosExistentes;


                string DocumentosBaja;
                dic.TryGetValue("documentos_baja", out DocumentosBaja);
                dto.DocumentosBaja = DocumentosBaja;
                string fecproc;
                dic.TryGetValue("fecha_proceso", out fecproc);
                dto.FechaProceso = DateTime.Parse(fecproc);
                listaDTO.Add(dto);


            }

            //return ExecuteReader(oParameters);

            return listaDTO;
        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFechaPreview(int idCliente, DateTime fecha)
        {
            CommandText = "p_mostrar_totales_procesamiento_PorFecha_Preview";
            CommandType = CommandType.StoredProcedure;
            ArrayList oParameters = new ArrayList();
            
            oParameters.Add(new DBParametro("@p_id_cliente", DbType.Int32 , idCliente ));
            oParameters.Add(new DBParametro("@fecha", DbType.DateTime, fecha));

            List<IDictionary<string, string>> listDiccionario = ExecuteReader(oParameters);
            List<ImportacionFacturaDataContracts> listaDTO = new List<ImportacionFacturaDataContracts>();
            ImportacionFacturaDataContracts dto = null;
            IEnumerator enume = listDiccionario.GetEnumerator();

            while (enume.MoveNext())
            {
                IDictionary<string, string> dic = (IDictionary<string, string>)enume.Current;

                dto = new ImportacionFacturaDataContracts();
                string idcli;
                dic.TryGetValue("id_cliente", out idcli);
                dto.IdCliente = Decimal.Parse(idcli);
                string NOMBRE;
                dic.TryGetValue("nombre", out NOMBRE);
                dto.NOMBRE = NOMBRE;
                string CUIT;
                dic.TryGetValue("cuit", out CUIT);
                dto.CUIT = CUIT;
                string RegistrosEnviados;
                dic.TryGetValue("registros_enviados", out RegistrosEnviados);
                dto.RegistrosEnviados = RegistrosEnviados;
                string RegistrosIngresados;
                dic.TryGetValue("registros_ingresados", out RegistrosIngresados);
                dto.RegistrosIngresados = RegistrosIngresados;

                string InsersionModificacion;
                dic.TryGetValue("insersion_modificacion", out InsersionModificacion);
                dto.InsersionModificacion = InsersionModificacion;


                string RegistrosActualizados;
                dic.TryGetValue("registros_actualizados", out RegistrosActualizados);
                dto.RegistrosActualizados = RegistrosActualizados;

                string RegistrosRechazados;
                dic.TryGetValue("registros_rechazados", out RegistrosRechazados);
                dto.RegistrosRechazados = RegistrosRechazados;

                string RegistrosExistentes;
                dic.TryGetValue("registros_existentes", out RegistrosExistentes);
                dto.RegistrosExistentes = RegistrosExistentes;


                string DocumentosBaja;
                dic.TryGetValue("documentos_baja", out DocumentosBaja);
                dto.DocumentosBaja = DocumentosBaja;
                string fecproc;
                dic.TryGetValue("fecha_proceso", out fecproc);
                dto.FechaProceso = DateTime.Parse(fecproc);
                listaDTO.Add(dto);


            }

            //return ExecuteReader(oParameters);

            return listaDTO;
        }


        /// <summary>
        /// M?todo que crea un objeto InterfazFactura de la tabla dbo.INT_Factura
        /// </summary>
        /// <param name="oInterfazFactura"></param>
        /// <returns></returns>
        public override InterfazFactura DoLoad(IDataReader registros)
        {
            try
            {
                int i = 0;
                InterfazFactura interfazFactura = new InterfazFactura();
                interfazFactura.IdIntefazFactura = registros.GetDecimal(i++);
                interfazFactura.FechaProceso = registros.GetDateTime(i++);
                interfazFactura.Linea = registros.GetInt16(i++);
                interfazFactura.IdCliente = registros.GetInt32(i++);
                interfazFactura.IdDeudor = registros.GetString(i++);
                interfazFactura.IdTipoComprobante= registros.GetString(i++);
                interfazFactura.Letra = registros.GetString(i++);
                interfazFactura.Emision = registros.GetString(i++);
                interfazFactura.NumeroPag = registros.GetInt16(i++);
                interfazFactura.CantidadP = registros.GetInt16(i++);
                interfazFactura.NroComprobante = registros.GetString(i++);
                interfazFactura.Importe = registros.GetDouble(i++);
                interfazFactura.Saldo = registros.GetDouble(i++);
                interfazFactura.IdMoneda = registros.GetString(i++);
                //interfazFactura.FechaEmision = registros.GetDateTime(i++);
                //interfazFactura.FechaVencimiento = registros.GetDateTime(i++);
                
                interfazFactura.FechaEmision = registros.IsDBNull(i) ? DateTime.MinValue : registros.GetDateTime(i);
                i++;
                interfazFactura.FechaVencimiento = registros.IsDBNull(i) ? DateTime.MinValue : registros.GetDateTime(i);
                i++;
                interfazFactura.Observaciones = registros.GetString(i);
                i++;
                interfazFactura.Estado =  registros.IsDBNull(i) ? string.Empty : registros.GetString(i);
                return interfazFactura;
            }
            catch (Exception ex)
            {
                Herramientas.Logger.WriteError("Clase: DALInterfazFactura, getInterfazFacturas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override InterfazFactura DoLoad(IDataReader registros, InterfazFactura ent)
        {
            throw new NotImplementedException();
        }
    }
}
