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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Deudor
    /// </summary>
    public class DALDeudor : AbstractMapper<Deudor>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALDeudor()
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
        ~DALDeudor()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Deudor
        /// </summary>
        /// <param name="idDeudor"></param>                   
        /// <returns></returns>
        public Deudor Load(int idDeudor)
        {
            try
            {
                Deudor oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, idDeudor));

                List<Deudor> deudors = AbstractFindAll(oParameters);
                if (deudors.Count > 0)
                {
                    oReturn = deudors[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        
        public Deudor GetDeudorConDireccionCompleta(int idDeudor)
        {
            try
            {
                Deudor oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_GetDeudorConDireccionCompleta";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, idDeudor));

                List<Deudor> deudors = AbstractFindAll(oParameters);
                if (deudors.Count > 0)
                {
                    oReturn = deudors[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public Deudor GetLastId()
        {
            try
            {
                Deudor oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Deudor_GetLastId";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Deudor> deudors = AbstractFindAll(oParameters);
                if (deudors.Count > 0)
                {
                    oReturn = deudors[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, GetLastId", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Deudor
        /// </summary>
        /// <param name="oDeudor"></param>
        /// <returns></returns>
        public void Delete(Deudor oDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDeudor.IdDeudor));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Deudor
        /// </summary>
        /// <param name="oDeudor"></param>
        /// <returns></returns>
        public void Update(Deudor oDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, oDeudor.IdDeudor));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oDeudor.Nombre));
                oParameters.Add(new DBParametro("@apellido", DbType.String, oDeudor.Apellido));
                oParameters.Add(new DBParametro("@domicilio", DbType.String, oDeudor.Domicilio));
                oParameters.Add(new DBParametro("@localidad", DbType.String, oDeudor.Localidad));
                oParameters.Add(new DBParametro("@provincia", DbType.String, oDeudor.Provincia));
                oParameters.Add(new DBParametro("@cp", DbType.String, oDeudor.Cp));
                oParameters.Add(new DBParametro("@telefono", DbType.String, oDeudor.Telefono));
                oParameters.Add(new DBParametro("@fax", DbType.String, oDeudor.Fax));
                oParameters.Add(new DBParametro("@email", DbType.String, oDeudor.Email));
                oParameters.Add(new DBParametro("@codigozona", DbType.String, oDeudor.CodigoZona));
                oParameters.Add(new DBParametro("@mapa", DbType.String, oDeudor.Mapa));
                oParameters.Add(new DBParametro("@sucursal", DbType.Byte, oDeudor.Sucursal));
                oParameters.Add(new DBParametro("@anticipo_gestion", DbType.Int32, oDeudor.AnticipoGestion));
                oParameters.Add(new DBParametro("@cuit", DbType.String, oDeudor.Cuit));
                oParameters.Add(new DBParametro("@todos", DbType.String, oDeudor.TODOS));
                oParameters.Add(new DBParametro("@zona", DbType.String, oDeudor.Zona));
                oParameters.Add(new DBParametro("@zona_cobro", DbType.String, oDeudor.ZonaCobro));
                oParameters.Add(new DBParametro("@tipo", DbType.String, oDeudor.Tipo));
                oParameters.Add(new DBParametro("@telefono_aux", DbType.String, oDeudor.Telefono_Aux));
                oParameters.Add(new DBParametro("@fecha_reclamo", DbType.DateTime, oDeudor.FechaReclamo));
                oParameters.Add(new DBParametro("@alfanumdelcliente", DbType.String, oDeudor.AlfaNumDelCliente.Trim()));                

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Deudor
        /// </summary>
        /// <param name="oDeudor"></param>
        /// <returns></returns>
        public void Insert(Deudor oDeudor)
        {
            try
            {
                this.BeginTransaction();
                
                CommandText = "PA_MG_FRONT_MTR_Deudor_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                
                oParameters.Add(new DBParametro("@nombre", DbType.String, oDeudor.Nombre));
                oParameters.Add(new DBParametro("@apellido", DbType.String, oDeudor.Apellido));
                oParameters.Add(new DBParametro("@domicilio", DbType.String, oDeudor.Domicilio));
                oParameters.Add(new DBParametro("@localidad", DbType.String, oDeudor.Localidad));
                oParameters.Add(new DBParametro("@provincia", DbType.String, oDeudor.Provincia));
                oParameters.Add(new DBParametro("@cp", DbType.String, oDeudor.Cp));
                oParameters.Add(new DBParametro("@telefono", DbType.String, oDeudor.Telefono));
                oParameters.Add(new DBParametro("@fax", DbType.String, oDeudor.Fax));
                oParameters.Add(new DBParametro("@email", DbType.String, oDeudor.Email));
                oParameters.Add(new DBParametro("@codigozona", DbType.String, oDeudor.CodigoZona));
                oParameters.Add(new DBParametro("@mapa", DbType.String, oDeudor.Mapa));
                oParameters.Add(new DBParametro("@sucursal", DbType.Byte, oDeudor.Sucursal));
                oParameters.Add(new DBParametro("@anticipo_gestion", DbType.Int32, oDeudor.AnticipoGestion));
                oParameters.Add(new DBParametro("@cuit", DbType.String, oDeudor.Cuit));
                oParameters.Add(new DBParametro("@todos", DbType.String, oDeudor.TODOS));
                oParameters.Add(new DBParametro("@zona", DbType.String, oDeudor.Zona));
                oParameters.Add(new DBParametro("@zona_cobro", DbType.String, oDeudor.ZonaCobro));
                oParameters.Add(new DBParametro("@tipo", DbType.String, oDeudor.Tipo));
                oParameters.Add(new DBParametro("@activo", DbType.Boolean , true));
                oParameters.Add(new DBParametro("@telefono_aux",DbType.String,oDeudor.Telefono_Aux));
                oParameters.Add(new DBParametro("@fecha_reclamo", DbType.DateTime, DateTime.Now));
                oParameters.Add(new DBParametro("@alfanumdelcliente", DbType.String, oDeudor.AlfaNumDelCliente));

                int idDeudor = int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());
                oDeudor.IdDeudor = idDeudor;

                this.CommitTransaction();

            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public int Insert2(Deudor oDeudor)
        {
            try
            {
                this.BeginTransaction();

                CommandText = "PA_MG_FRONT_MTR_Deudor_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();


                oParameters.Add(new DBParametro("@nombre", DbType.String, oDeudor.Nombre));
                oParameters.Add(new DBParametro("@apellido", DbType.String, oDeudor.Apellido));
                oParameters.Add(new DBParametro("@domicilio", DbType.String, oDeudor.Domicilio));
                oParameters.Add(new DBParametro("@localidad", DbType.String, oDeudor.Localidad));
                oParameters.Add(new DBParametro("@provincia", DbType.String, oDeudor.Provincia));
                oParameters.Add(new DBParametro("@cp", DbType.String, oDeudor.Cp));
                oParameters.Add(new DBParametro("@telefono", DbType.String, oDeudor.Telefono));
                oParameters.Add(new DBParametro("@fax", DbType.String, oDeudor.Fax));
                oParameters.Add(new DBParametro("@email", DbType.String, oDeudor.Email));
                oParameters.Add(new DBParametro("@codigozona", DbType.String, oDeudor.CodigoZona));
                oParameters.Add(new DBParametro("@mapa", DbType.String, oDeudor.Mapa));
                oParameters.Add(new DBParametro("@sucursal", DbType.Byte, oDeudor.Sucursal));
                oParameters.Add(new DBParametro("@anticipo_gestion", DbType.Int32, oDeudor.AnticipoGestion));
                oParameters.Add(new DBParametro("@cuit", DbType.String, oDeudor.Cuit));
                oParameters.Add(new DBParametro("@todos", DbType.String, oDeudor.TODOS));
                oParameters.Add(new DBParametro("@zona", DbType.String, oDeudor.Zona));
                oParameters.Add(new DBParametro("@zona_cobro", DbType.String, oDeudor.ZonaCobro));
                oParameters.Add(new DBParametro("@tipo", DbType.String, oDeudor.Tipo));
                oParameters.Add(new DBParametro("@activo", DbType.Boolean, true));
                oParameters.Add(new DBParametro("@telefono_aux", DbType.String, oDeudor.Telefono_Aux));
                oParameters.Add(new DBParametro("@fecha_reclamo", DbType.DateTime, DateTime.Now));
                oParameters.Add(new DBParametro("@alfanumdelcliente", DbType.String, oDeudor.AlfaNumDelCliente));

                int idDeudor = int.Parse(ExecuteScalar(oParameters, this.ObjConnection).ToString());
                oDeudor.IdDeudor = idDeudor;
                
                this.CommitTransaction();

                return idDeudor; 

            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Deudor de la tabla dbo.MTR_Deudor
        /// </summary>
        /// <param name="oDeudor"></param>
        /// <returns></returns>
        /// 
        public List<Deudor> GetAllDeudors()
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }

        }

        public List<Deudor> GetAllLocalidadCp()
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_Localidad_Cp";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }




        public List<Deudor> GetAllLocalidadPorCriterioIdZona(int id)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_Localidad_PorCriterioIdZona";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_zona", DbType.Int32, id));

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Deudor> GetAllDeudorByAlfaNum(int id)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_Localidad_PorCriterioIdZona";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_zona", DbType.Int32, id));

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Deudor> GetAllLocalidadCp_PorCP(string Cp)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_Localidad_Cp_PorCp";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@Cp", DbType.String, Cp));
                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Deudor> GetAllLocalidadCp_PorLocalidad(string Localidad)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_Localidad_Cp_PorLocalidad";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@Localidad", DbType.String, Localidad));
                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Deudor de la tabla dbo.MTR_Deudor
        /// </summary>
        /// <param name="oDeudor"></param>
        /// <returns></returns>
        public override Deudor DoLoad(IDataReader registros)
        {
            try
            {
                Deudor deudor = new Deudor();
                deudor.IdDeudor = registros.GetInt32(0);
                deudor.Nombre = registros.IsDBNull(1) != true ? registros.GetString(1) : string.Empty;
                deudor.Apellido = registros.IsDBNull(2) != true ? registros.GetString(2) : string.Empty;
                deudor.Domicilio = registros.IsDBNull(3) != true ? registros.GetString(3) : string.Empty;
                deudor.Localidad = registros.IsDBNull(4) != true ? registros.GetString(4) : string.Empty;
                deudor.Provincia = registros.IsDBNull(5) != true ? registros.GetString(5) : string.Empty;
                deudor.Cp = registros.IsDBNull(6) != true  ? registros.GetString(6) : string.Empty;
                deudor.Telefono = registros.IsDBNull(7) != true ? registros.GetString(7) : string.Empty;
                deudor.Fax = registros.IsDBNull(8) != true ? registros.GetString(8) : string.Empty;
                deudor.Email = registros.IsDBNull(9) != true ? registros.GetString(9) : string.Empty;
                deudor.CodigoZona = registros.IsDBNull(10) != true ? registros.GetString(10) : string.Empty;
                deudor.Mapa = registros.IsDBNull(11) != true ? registros.GetString(11) : string.Empty;
                deudor.Sucursal = registros.IsDBNull(12) != true ? int.Parse(registros.GetValue(12).ToString()) : 0;
                deudor.AnticipoGestion = registros.IsDBNull(13) != true ? int.Parse(registros.GetValue(13).ToString()) : 0;
                deudor.Cuit = registros.IsDBNull(14) != true ? registros.GetString(14) : string.Empty;
                deudor.TODOS = registros.IsDBNull(15) != true ? registros.GetString(15) : string.Empty;
                deudor.Zona = registros.IsDBNull(16) != true ? registros.GetString(16) : string.Empty;
                deudor.ZonaCobro = registros.IsDBNull(17) != true ? registros.GetString(17) : string.Empty;
                deudor.Tipo = registros.IsDBNull(18) != true ? registros.GetString(18) : string.Empty;
                deudor.FechaReclamo = registros.IsDBNull(19) != true ? registros.GetDateTime(19) : DateTime.Now;
                deudor.Telefono_Aux = registros.IsDBNull(20) != true ? registros.GetString(20) : string.Empty;
                deudor.AlfaNumDelCliente = registros.IsDBNull(21) != true ? registros.GetString(21) : string.Empty;



                try
                {
                    deudor.IdDomicilioDeudor = registros.IsDBNull(22) != true ? registros.GetInt32(22) : 0;
                }
                catch (Exception)
                {
               
                }

                try
                {
                    deudor.Cliente=registros.IsDBNull(23) != true ? registros.GetString(23) : string.Empty;
                }
                catch (Exception)
                {

                    deudor.Cliente = string.Empty;
                }

                return deudor;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Deudor> GetAllDeudorsPorCriterioDeudor(string nombre)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_PorCriterioDeudor";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@nombre", DbType.String, nombre));
                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        
        public List<Deudor> GetAllDeudorsPorAlfaNum(string alfaNum)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_PorAlfaNum";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@alfaNum", DbType.String, alfaNum));
                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Deudor> GetAllDeudorsPorAlfaNumAndIdCliente(string alfaNum, int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_PorAlfaNum_IdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@alfaNum", DbType.String, alfaNum));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, idCliente));
                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, GetAllDeudorsPorAlfaNumAndIdCliente", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Deudor> GetAllDeudorsOpt(string ids)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_Select_Opt";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_deudor", DbType.String, ids));
                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Deudor> GetAllDeudorsPorCriterioCliente(string cliente, int idFiltro)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_PorCriterioCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                
                oParameters.Add(new DBParametro("@cliente", DbType.String, cliente));
                oParameters.Add(new DBParametro("@idFiltro", DbType.Int16 , idFiltro));
                
                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Deudor> GetAllDeudorsPorCriterioCliente(int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_PorCriterioIdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idCliente", DbType.Int16, idCliente));
                

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


       

        public List<Deudor> GetAllDeudorsPorCriterioZona(int idZona)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_PorCriterioIdZona";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_zona", DbType.Int32, idZona));


                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, GetAllDeudorsPorCriterioZona", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Deudor> GetAllDeudorsPorCriterioClienteFecha(string cliente, DateTime vencimientoDesde, DateTime vencimientoHasta)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_PorCriterioClienteFecha";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
             
                oParameters.Add(new DBParametro("@cliente", DbType.String, cliente));
                oParameters.Add(new DBParametro("@vencimientoDesde", DbType.DateTime , vencimientoDesde ));
                oParameters.Add(new DBParametro("@vencimientoHasta", DbType.DateTime, vencimientoHasta ));
             

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
       
        public List<Deudor> GetAllDeudorsPorCriterioAnalista(string analista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_PorCriterioAnalista";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@nombre", DbType.String, analista));
             
                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Deudor> GetAllDeudorsGestionAnalista(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_Gestion";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@nombre_analista", DbType.String, analista));
                oParameters.Add(new DBParametro("@todos", DbType.Boolean, todos));
                oParameters.Add(new DBParametro("@a_vencer", DbType.Boolean, aVencer));
                oParameters.Add(new DBParametro("@cant_dias", DbType.Int16, cantDias));
                oParameters.Add(new DBParametro("@incluye_vencidas", DbType.Boolean, incluyeVencidas));
                oParameters.Add(new DBParametro("@validar_fecha_reclamo", DbType.Boolean, validarFechaReclamo));
                if (idCliente < 0)
                {
                    oParameters.Add(new DBParametro("@idCliente", DbType.Int32, DBNull.Value));
                }
                else {
                    oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                }
                oParameters.Add(new DBParametro("@proxima_gestion", DbType.Boolean, proximaGestion));

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, GetAllDeudorsGestionAnalista", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public List<Deudor> GetAllDeudorsGestionAnalistaConFiltroFechaReclamo(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion, DateTime filtroFechaReclamo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_Gestion_FechaReclamo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@nombre_analista", DbType.String, analista));
                oParameters.Add(new DBParametro("@todos", DbType.Boolean, todos));
                oParameters.Add(new DBParametro("@a_vencer", DbType.Boolean, aVencer));
                oParameters.Add(new DBParametro("@cant_dias", DbType.Int16, cantDias));
                oParameters.Add(new DBParametro("@incluye_vencidas", DbType.Boolean, incluyeVencidas));
                oParameters.Add(new DBParametro("@validar_fecha_reclamo", DbType.Boolean, validarFechaReclamo));
                oParameters.Add(new DBParametro("@filtroFechaReclamo", DbType.DateTime, filtroFechaReclamo));
                if (idCliente < 0)
                {
                    oParameters.Add(new DBParametro("@idCliente", DbType.Int32, DBNull.Value));
                }
                else
                {
                    oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                }
                oParameters.Add(new DBParametro("@proxima_gestion", DbType.Boolean, proximaGestion));

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, GetAllDeudorsGestionAnalista", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Deudor> GetAllDeudorsByClienteYAnalista(int idCliente,string analista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_ByClienteYAnalista";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idCliente", DbType.Int16, idCliente));
                oParameters.Add(new DBParametro("@analista", DbType.String, analista));

                List<Deudor> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public void AsignarAnalista(int idDeudor, int idAnalista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_TBL_Deudor_Analista_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idDeudor",DbType.Int32,idDeudor));
                oParameters.Add(new DBParametro("@idAnalista", DbType.Int32, idAnalista));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, AsignarAnalista", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public void AsignarAnalista_Cliente(int idCliente, int idDeudor, int idAnalista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_TBL_Deudor_Analista_Insert_Cli";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@idAnalista", DbType.Int32, idAnalista));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, AsignarAnalista_Cliente", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public void EliminarAnalista(int idDeudor, int idAnalista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_TBL_Deudor_Analista_Delete";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, idDeudor));
                oParameters.Add(new DBParametro("@idAnalista", DbType.Int32, idAnalista));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, EliminarAnalista", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public void DesactivarPorId(int idDeudor)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_DesactivarPorId";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, idDeudor));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, DesactivarPorId", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Deudor
        /// </summary>
        /// <param name="idDeudor"></param>                   
        /// <returns></returns>
        public Deudor getDeudorByCuit(string cuit)
        {
            try
            {
                Deudor oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_ByCuit";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@cuit", DbType.String, cuit));
            
                List<Deudor> deudors = AbstractFindAll(oParameters);
                if (deudors.Count > 0)
                {
                    oReturn = deudors[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudorByCuit("+cuit+")", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        public override Deudor DoLoad(IDataReader registros, Deudor ent)
        {
            throw new NotImplementedException();
        }
    }
}
