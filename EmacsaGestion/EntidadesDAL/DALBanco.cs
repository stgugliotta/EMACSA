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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Banco
    /// </summary>
    public class DALBanco : AbstractMapper<Banco>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALBanco()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

       

        /// <summary>
        /// M?todo que retorna solo un objeto  Banco
        /// </summary>
        /// <param name="idBanco"></param>        
        /// <returns></returns>
        public Banco Load(int idBanco)
        {
            try
            {
                Banco oReturn = null;
                CommandText = "PA_MG_FRONT_Banco_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idbanco", DbType.Int32, idBanco));

                List<Banco> bancos = AbstractFindAll(oParameters);
                if (bancos.Count > 0)
                {
                    oReturn = bancos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALBanco, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Banco
        /// </summary>
        /// <param name="oBanco"></param>
        /// <returns></returns>
        public void Delete(Banco oBanco)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Banco_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idbanco", DbType.Int32, oBanco.IdBanco));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALBanco, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Banco
        /// </summary>
        /// <param name="oBanco"></param>
        /// <returns></returns>
        public void Update(Banco oBanco)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Banco_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALBanco, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Banco
        /// </summary>
        /// <param name="oBanco"></param>
        /// <returns></returns>
        public void Insert(Banco oBanco)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Banco_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                //oParameters.Add(new DBParametro("@idbanco", DbType.Int32, oBanco.IdBanco));
                //oParameters.Add(new DBParametro("@usuario", DbType.String, oBanco.Usuario));
                //oParameters.Add(new DBParametro("@fechabanco", DbType.DateTime, oBanco.FechaBanco));
                //oParameters.Add(new DBParametro("@idestado", DbType.Int32, oBanco.IdEstado));
                //oParameters.Add(new DBParametro("@observacion", DbType.String, oBanco.Observacion));
                //oParameters.Add(new DBParametro("@informacioncomplementaria", DbType.String, oBanco.InformacionComplementaria));
                //oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oBanco.IdFactura));
                //oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oBanco.IdDeudor));
                //oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oBanco.IdCliente));
                //oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oBanco.FechaVencimiento));
                //oParameters.Add(new DBParametro("@proxima_gestion", DbType.DateTime, oBanco.ProximaGestion));
                //if (oBanco.IdDomicilioAlternativo == 0)
                //{
                //    oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32, null));
                //}
                //else
                //{
                //    oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32, oBanco.IdDomicilioAlternativo));
                //}

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALBanco, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

      

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Banco de la tabla dbo.TBL_Banco
        /// </summary>
        /// <param name="oBanco"></param>
        /// <returns></returns>
        public List<Banco> GetAllBancosByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Banco_SELECT_ByIdFacturaIdClienteFechaVencIdEstado";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, idFactura));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, fechaVenc));
                oParameters.Add(new DBParametro("@idestado", DbType.Int32, idEstado));
                List<Banco> bancos = AbstractFindAll(oParameters);

                return bancos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALBanco, getBancos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Banco> GetAllBancos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Banco_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Banco> bancos = AbstractFindAll(oParameters);

                return bancos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALBanco, getBancos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Banco de la tabla dbo.TBL_Banco
        /// </summary>
        /// <param name="oBanco"></param>
        /// <returns></returns>
        public override Banco DoLoad(IDataReader registros)
        {
            try
            {
                Banco banco = new Banco();
                banco.IdBanco = registros.GetInt32(0);
                banco.Codigo = registros.GetString(1);
                banco.Descripcion  = registros.IsDBNull(2) != true ? registros.GetString(2) : "";
                
                return banco;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALBanco, getBancos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Banco DoLoad(IDataReader registros, Banco ent)
        {
            throw new NotImplementedException();
        }
    }
}
