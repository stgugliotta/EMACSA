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
    /// Clase que maneja la persistencia de la tabla dbo.MTR_Cliente
    /// </summary>
    public class DALCliente : AbstractMapper<Cliente>

    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALCliente()
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
        ~DALCliente()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Cliente
        /// </summary>
        /// <param name="idCliente"></param>                  
        /// <returns></returns>
        public Cliente Load(decimal idCliente)
        {
            try
            {
                Cliente oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Cliente_Select";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, idCliente));

                List<Cliente> clientes = AbstractFindAll(oParameters);
                if (clientes.Count > 0)
                {
                    oReturn = clientes[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCliente, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        public Cliente GetClienteByDeudor(decimal idDeudor)
        {
            try
            {
                Cliente oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_ClientePorDeudor_Select";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Decimal, idDeudor));

                List<Cliente> clientes = AbstractFindAll(oParameters);
                if (clientes.Count > 0)
                {
                    oReturn = clientes[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCliente, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.MTR_Cliente
        /// </summary>
        /// <param name="oCliente"></param>
        /// <returns></returns>
        public void Delete(Cliente oCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oCliente.IdCliente));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCliente, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.MTR_Cliente
        /// </summary>
        /// <param name="oCliente"></param>
        /// <returns></returns>
        public void Update(Cliente oCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oCliente.IdCliente));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oCliente.NOMBRE));
                oParameters.Add(new DBParametro("@cuit", DbType.String, oCliente.CUIT));
                oParameters.Add(new DBParametro("@calle", DbType.String, oCliente.CALLE));
                oParameters.Add(new DBParametro("@altura", DbType.Double, oCliente.ALTURA));
                oParameters.Add(new DBParametro("@departamento", DbType.String, oCliente.DEPARTAMENTO));
                oParameters.Add(new DBParametro("@localidad", DbType.String, oCliente.LOCALIDAD));
                oParameters.Add(new DBParametro("@cp", DbType.Double, oCliente.CP));
                oParameters.Add(new DBParametro("@provincia", DbType.String, oCliente.PROVINCIA));
                oParameters.Add(new DBParametro("@telefonos", DbType.String, oCliente.TELEFONOS));
                oParameters.Add(new DBParametro("@fax", DbType.String, oCliente.FAX));
                oParameters.Add(new DBParametro("@email", DbType.String, oCliente.EMAIL));
                oParameters.Add(new DBParametro("@nombrecorto", DbType.String, oCliente.NOMBRECORTO));
                oParameters.Add(new DBParametro("@moneda_credito", DbType.String, oCliente.MonedaCredito));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oCliente.OBSERVACIONES));
                oParameters.Add(new DBParametro("@sologestion", DbType.String, oCliente.SOLOGESTION));
                oParameters.Add(new DBParametro("@activo", DbType.String, oCliente.ACTIVO));
                oParameters.Add(new DBParametro("@gru_rec", DbType.String, oCliente.GruRec));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCliente, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.MTR_Cliente
        /// </summary>
        /// <param name="oCliente"></param>
        /// <returns></returns>
        public void Insert(Cliente oCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cliente_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_cliente", DbType.Decimal, oCliente.IdCliente));
                oParameters.Add(new DBParametro("@nombre", DbType.String, oCliente.NOMBRE));
                oParameters.Add(new DBParametro("@cuit", DbType.String, oCliente.CUIT));
                oParameters.Add(new DBParametro("@calle", DbType.String, oCliente.CALLE));
                oParameters.Add(new DBParametro("@altura", DbType.Double, oCliente.ALTURA));
                oParameters.Add(new DBParametro("@departamento", DbType.String, oCliente.DEPARTAMENTO));
                oParameters.Add(new DBParametro("@localidad", DbType.String, oCliente.LOCALIDAD));
                oParameters.Add(new DBParametro("@cp", DbType.Double, oCliente.CP));
                oParameters.Add(new DBParametro("@provincia", DbType.String, oCliente.PROVINCIA));
                oParameters.Add(new DBParametro("@telefonos", DbType.String, oCliente.TELEFONOS));
                oParameters.Add(new DBParametro("@fax", DbType.String, oCliente.FAX));
                oParameters.Add(new DBParametro("@email", DbType.String, oCliente.EMAIL));
                oParameters.Add(new DBParametro("@nombrecorto", DbType.String, oCliente.NOMBRECORTO));
                oParameters.Add(new DBParametro("@moneda_credito", DbType.String, oCliente.MonedaCredito));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oCliente.OBSERVACIONES));
                oParameters.Add(new DBParametro("@sologestion", DbType.String, oCliente.SOLOGESTION));
                oParameters.Add(new DBParametro("@activo", DbType.String, oCliente.ACTIVO));
                oParameters.Add(new DBParametro("@gru_rec", DbType.String, oCliente.GruRec));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCliente, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Cliente de la tabla dbo.MTR_Cliente
        /// </summary>
        /// <param name="oCliente"></param>
        /// <returns></returns>
        public List<Cliente> GetAllClientes()
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Cliente_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                

                List<Cliente> clientes = AbstractFindAll(oParameters);

                return clientes;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCliente, getClientes", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Cliente de la tabla dbo.MTR_Cliente
        /// </summary>
        /// <param name="oCliente"></param>
        /// <returns></returns>
        public List<Cliente> GetAllClientesByAnalista(string analista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Cliente_SELECTALL_ByAnalista";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@analista", DbType.String, analista));
                List<Cliente> clientes = AbstractFindAll(oParameters);

                return clientes;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCliente, getClientes", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



        /// <summary>
        /// M?todo que crea un objeto Cliente de la tabla dbo.MTR_Cliente
        /// </summary>
        /// <param name="oCliente"></param>
        /// <returns></returns>
        public override Cliente DoLoad(IDataReader registros)
        {
            try
            {


                

                Cliente cliente = new Cliente();
                //cliente.IdCliente = (decimal)registros.GetInt32(0);
                cliente.IdCliente = (decimal)registros.GetDecimal(0);
                cliente.NOMBRE = registros.IsDBNull(1)!=true ? registros.GetString(1):string.Empty;
                cliente.CUIT = registros.IsDBNull(2) != true ? registros.GetString(2) : string.Empty;
                cliente.CALLE = registros.IsDBNull(3) != true ? registros.GetString(3) : string.Empty;
                cliente.ALTURA = registros.IsDBNull(4) != true ? Double.Parse(registros.GetValue(4).ToString()) : 0; ;
                cliente.DEPARTAMENTO = registros.IsDBNull(5) != true ? registros.GetString(5) : string.Empty;
                cliente.LOCALIDAD = registros.IsDBNull(6) != true ? registros.GetString(6) : string.Empty;
                cliente.CP = registros.IsDBNull(7) != true ? Double.Parse(registros.GetValue(7).ToString()) : 0; ;
                cliente.PROVINCIA = registros.IsDBNull(8) != true ? registros.GetString(8) : string.Empty;
                cliente.TELEFONOS = registros.IsDBNull(9) != true ? registros.GetString(9) : string.Empty;
                cliente.FAX = registros.IsDBNull(10) != true ? registros.GetString(10) : string.Empty;
                cliente.EMAIL = registros.IsDBNull(11) != true ? registros.GetString(11) : string.Empty;
                cliente.NOMBRECORTO = registros.IsDBNull(12) != true ? registros.GetString(12) : string.Empty;
                cliente.MonedaCredito = registros.IsDBNull(13) != true ? registros.GetString(13) : string.Empty;
                cliente.OBSERVACIONES = registros.IsDBNull(14) != true ? registros.GetString(14) : string.Empty;
                cliente.SOLOGESTION = registros.IsDBNull(15) != true ? registros.GetString(15) : string.Empty;
                cliente.ACTIVO = registros.IsDBNull(16) != true ? registros.GetString(16) : string.Empty;
                cliente.GruRec = registros.IsDBNull(17) != true ? registros.GetString(17) : string.Empty;

                return cliente;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCliente, getClientes", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Cliente DoLoad(IDataReader registros, Cliente ent)
        {
            throw new NotImplementedException();
        }
    }
}
