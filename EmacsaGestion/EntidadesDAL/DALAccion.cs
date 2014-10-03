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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Accion
    /// </summary>
    public class DALAccion : AbstractMapper<Accion>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALAccion()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

       

        /// <summary>
        /// M?todo que retorna solo un objeto  Accion
        /// </summary>
        /// <param name="idAccion"></param>        
        /// <returns></returns>
        public Accion Load(int idAccion)
        {
            try
            {
                Accion oReturn = null;
                CommandText = "PA_MG_FRONT_Accion_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idaccion", DbType.Int32, idAccion));

                List<Accion> accions = AbstractFindAll(oParameters);
                if (accions.Count > 0)
                {
                    oReturn = accions[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public Accion GetLastActionByIdFactura(int idFactura)
        {
            try
            {
                Accion oReturn = null;
                CommandText = "PA_MG_FRONT_Accion_SELECT_byIdFactura";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idFactura", DbType.Int32, idFactura));

                List<Accion> accions = AbstractFindAll(oParameters);
                if (accions.Count > 0)
                {
                    oReturn = accions[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Accion
        /// </summary>
        /// <param name="oAccion"></param>
        /// <returns></returns>
        public void Delete(Accion oAccion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Accion_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idaccion", DbType.Int32, oAccion.IdAccion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Accion
        /// </summary>
        /// <param name="oAccion"></param>
        /// <returns></returns>
        public void Update(Accion oAccion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Accion_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idaccion", DbType.Int32, oAccion.IdAccion));
                oParameters.Add(new DBParametro("@usuario", DbType.String, oAccion.Usuario));
                oParameters.Add(new DBParametro("@fechaaccion", DbType.DateTime, oAccion.FechaAccion));
                oParameters.Add(new DBParametro("@idestado", DbType.Int32, oAccion.IdEstado));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oAccion.Observacion));
                oParameters.Add(new DBParametro("@informacioncomplementaria", DbType.String, oAccion.InformacionComplementaria));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oAccion.IdFactura));
                oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oAccion.IdDeudor));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oAccion.IdCliente));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oAccion.FechaVencimiento));
                oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32 , oAccion.IdDomicilioAlternativo));
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Accion
        /// </summary>
        /// <param name="oAccion"></param>
        /// <returns></returns>
        public void Insert(Accion oAccion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Accion_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idaccion", DbType.Int32, oAccion.IdAccion));
                oParameters.Add(new DBParametro("@usuario", DbType.String, oAccion.Usuario));
                oParameters.Add(new DBParametro("@fechaaccion", DbType.DateTime, oAccion.FechaAccion));
                oParameters.Add(new DBParametro("@idestado", DbType.Int32, oAccion.IdEstado));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oAccion.Observacion));
                oParameters.Add(new DBParametro("@informacioncomplementaria", DbType.String, oAccion.InformacionComplementaria));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oAccion.IdFactura));
                oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oAccion.IdDeudor));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oAccion.IdCliente));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oAccion.FechaVencimiento));
                oParameters.Add(new DBParametro("@proxima_gestion", DbType.DateTime, oAccion.ProximaGestion));
                if (oAccion.IdDomicilioAlternativo == 0)
                {
                    oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32, null));
                }
                else
                {
                    oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32, oAccion.IdDomicilioAlternativo));
                }

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public void InsertComplementario(Accion oAccion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Accion_Complementaria_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idaccion", DbType.Int32, oAccion.IdAccion));
                oParameters.Add(new DBParametro("@usuario", DbType.String, oAccion.Usuario));
                oParameters.Add(new DBParametro("@fechaaccion", DbType.DateTime, oAccion.FechaAccion));
                oParameters.Add(new DBParametro("@idestado", DbType.Int32, oAccion.IdEstado));
                oParameters.Add(new DBParametro("@observacion", DbType.String, oAccion.Observacion));
                oParameters.Add(new DBParametro("@informacioncomplementaria", DbType.String, oAccion.InformacionComplementaria));
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oAccion.IdFactura));
                oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oAccion.IdDeudor));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oAccion.IdCliente));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oAccion.FechaVencimiento));
                oParameters.Add(new DBParametro("@proxima_gestion", DbType.DateTime, oAccion.ProximaGestion));
                oParameters.Add(new DBParametro("@saldoFactura", DbType.Decimal , oAccion.Saldo));
                oParameters.Add(new DBParametro("@montoImputacion", DbType.Decimal, oAccion.MontoImputacion));
               // oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32, oAccion.IdDomicilioAlternativo));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, InsertComplementario", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Accion de la tabla dbo.TBL_Accion
        /// </summary>
        /// <param name="oAccion"></param>
        /// <returns></returns>
        public List<Accion> GetAllAccionsByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Accion_SELECT_ByIdFacturaIdClienteFechaVenc";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, idFactura));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, fechaVenc));
                List<Accion> accions = AbstractFindAll(oParameters);

                return accions;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, getAccions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

       


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Accion de la tabla dbo.TBL_Accion
        /// </summary>
        /// <param name="oAccion"></param>
        /// <returns></returns>
        public List<Accion> GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Accion_SELECT_ByIdFacturaIdClienteFechaVencIdEstado";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, idFactura));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, fechaVenc));
                oParameters.Add(new DBParametro("@idestado", DbType.Int32, idEstado));
                List<Accion> accions = AbstractFindAll(oParameters);

                return accions;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, getAccions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Accion> GetAllAccions()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Accion_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Accion> accions = AbstractFindAll(oParameters);

                return accions;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, getAccions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Accion de la tabla dbo.TBL_Accion
        /// </summary>
        /// <param name="oAccion"></param>
        /// <returns></returns>
        public override Accion DoLoad(IDataReader registros)
        {
            try
            {
                Accion accion = new Accion();
                accion.IdAccion = registros.GetInt32(0);
                accion.Usuario = registros.IsDBNull(1) != true ? registros.GetString(1) : "";
                accion.FechaAccion = registros.GetDateTime(2);
                accion.IdEstado = registros.GetInt32(3);
                accion.Observacion = registros.IsDBNull(4) != true ? registros.GetString(4) : "";
                accion.InformacionComplementaria =  registros.IsDBNull(5) != true ? registros.GetString(5) : "";
                accion.IdFactura = registros.GetInt32(6);
                accion.IdDeudor = registros.GetInt32(7);
                accion.IdCliente = registros.GetInt32(8);
                accion.FechaVencimiento = registros.GetDateTime(9);
                try
                {
                    accion.IdDomicilioAlternativo = registros.GetInt32(10);
                }
                catch (Exception ex) { }

                return accion;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAccion, getAccions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Accion DoLoad(IDataReader registros, Accion ent)
        {
            throw new NotImplementedException();
        }
    }
}
