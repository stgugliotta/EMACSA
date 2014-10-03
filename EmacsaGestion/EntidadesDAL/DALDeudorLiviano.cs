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
    public class DALDeudorLiviano : AbstractMapper<DeudorLiviano>
    {
           public DALDeudorLiviano()
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
        ~DALDeudorLiviano()
        {
            ObjConnection.Dispose();
        }

        public DeudorLiviano Load(int idDeudor)
        {
            try
            {
                DeudorLiviano oReturn = null;
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_deudor", DbType.Int32, idDeudor));

                List<DeudorLiviano> deudors = AbstractFindAll(oParameters);
                if (deudors.Count > 0)
                {
                    oReturn = deudors[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorLiviano, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public override DeudorLiviano DoLoad(IDataReader registros)
        {
            try
            {
                DeudorLiviano deudor = new DeudorLiviano();
                deudor.IdDeudor = registros.GetInt32(0);
                deudor.Nombre = registros.IsDBNull(1) != true ? registros.GetString(1) : string.Empty;
                try
                {
                    deudor.AlfaNumDelCliente = registros.IsDBNull(2) != true ? registros.GetString(2) : string.Empty;
                }
                catch (Exception)
                {

                    deudor.AlfaNumDelCliente = string.Empty;
                }
                
                return deudor;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorLiviano, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public override DeudorLiviano DoLoad(IDataReader registros, DeudorLiviano ent)
        {
            throw new NotImplementedException();
        }

        //tocar
        public List<DeudorLiviano> GetAllDeudorsLivianoPorAnalista(string analista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_LivianoPorAnalista";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@nombre", DbType.String, analista));


                List<DeudorLiviano> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorLiviano, GetAllDeudorsLivianoPorCriterioAnalista", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        //tocar
       public List<DeudorLiviano> GetAllDeudorsLivianoGestionAnalista(string analista, bool todos, bool aVencer, int cantDias, bool incluyeVencidas, bool validarFechaReclamo, int idCliente, bool proximaGestion)
       {
           try
           {
               CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_LivianoGestion";
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
               else
               {
                   oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
               }
               oParameters.Add(new DBParametro("@proxima_gestion", DbType.Boolean, proximaGestion));

               List<DeudorLiviano> deudors = AbstractFindAll(oParameters);

               return deudors;
           }
           catch (Exception ex)
           {
               Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, GetAllDeudorsGestionAnalista", ex.Message);

               throw new GobbiTechnicalException(
                   string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
           }
        }

        //tocar
       public List<DeudorLiviano> GetAllDeudorsLivianoGestionAnalistaConFiltroFechaReclamo(string analista, bool todos, bool aVencer, int cantDias, bool incluyeVencidas, bool validarFechaReclamo, int idCliente, bool proximaGestion, DateTime fechaReclamo)
       {
           try
           {
               CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_LivianoGestion_FechaReclamo";
               CommandType = CommandType.StoredProcedure;
               ArrayList oParameters = new ArrayList();
               oParameters.Add(new DBParametro("@nombre_analista", DbType.String, analista));
               oParameters.Add(new DBParametro("@todos", DbType.Boolean, todos));
               oParameters.Add(new DBParametro("@a_vencer", DbType.Boolean, aVencer));
               oParameters.Add(new DBParametro("@cant_dias", DbType.Int16, cantDias));
               oParameters.Add(new DBParametro("@incluye_vencidas", DbType.Boolean, incluyeVencidas));
               oParameters.Add(new DBParametro("@validar_fecha_reclamo", DbType.Boolean, validarFechaReclamo));
               oParameters.Add(new DBParametro("@proxima_gestion", DbType.Boolean, proximaGestion));
               if (idCliente < 0)
               {
                   oParameters.Add(new DBParametro("@idCliente", DbType.Int32, DBNull.Value));
               }
               else
               {
                   oParameters.Add(new DBParametro("@idCliente", DbType.Int32, idCliente));
               }
               oParameters.Add(new DBParametro("@proxima_gestion", DbType.Boolean, proximaGestion));
               oParameters.Add(new DBParametro("@filtroFechaReclamo", DbType.DateTime, fechaReclamo));
               List<DeudorLiviano> deudors = AbstractFindAll(oParameters);

               return deudors;
           }
           catch (Exception ex)
           {
               Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, GetAllDeudorsGestionAnalista", ex.Message);

               throw new GobbiTechnicalException(
                   string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
           }
        }




        public List<DeudorLiviano> GetAllDeudorsLivianoPorCriterioAnalista(string cliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_LivianoPorCriterioAnalista";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@nombre", DbType.String, cliente));


                List<DeudorLiviano> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudorLiviano, GetAllDeudorsLivianoPorCriterioAnalista", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public List<DeudorLiviano> GetAllDeudorsLivianoPorCriterioCliente(int idCliente)
        {
            try
            {
                CommandText = "PA_MG_FRONT_MTR_Deudor_SELECT_LivianoPorCriterioIdCliente";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idCliente", DbType.Int16, idCliente));


                List<DeudorLiviano> deudors = AbstractFindAll(oParameters);

                return deudors;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDeudor, getDeudors", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }



    }
}
