using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ar.com.telecom.eva.CoreServices.Data;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;
using Entidades;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.tbl_Resultado_GestionEstadoDocumento
    /// </summary>
    public class DALResultadoCambioGestor : AbstractMapper<ResultadoCambioGestor>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALResultadoCambioGestor()
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
        ~DALResultadoCambioGestor()
        {
            ObjConnection.Dispose();
        }

        public List<ResultadoCambioGestor> GetAllResultadoCambioGestorPorCriterio(string mostrar, string tipoCaso, DateTime fechaEnvDesde, DateTime fechaEnvHasta)
        {
            try
            {
                CommandText = "PA_MG_RESULTADO_ResultadoCambioGestor_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@MOSTRAR", DbType.String, mostrar));
                oParameters.Add(new DBParametro("@TIPO_CASO", DbType.String, tipoCaso));
                oParameters.Add(new DBParametro("@FECHA_ENV_CLP_DESDE", DbType.DateTime, fechaEnvDesde));
                oParameters.Add(new DBParametro("@FECHA_ENV_CLP_HASTA", DbType.DateTime, fechaEnvHasta));



                List<ResultadoCambioGestor> resultadoCambioGestor = AbstractFindAll(oParameters);

                return resultadoCambioGestor;
            }
            catch (Exception ex)
            {
                ar.com.telecom.eva.CoreServices.Logging.Logger.WriteError("Clase: DALResultadoEstadoDocumento, getResultadoEstadoDocumentos", ex.Message);

                throw new EvaTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// Seteo de Cambio de Gestor
        /// </summary>
        /// <param name="NroCaso"></param>
        /// <returns>void</returns>
        public void SetCambioGestorPorCaso(string NroCaso)
        {
            try
            {

                CommandText = "PA_MG_FRONT_MarcarPorEnvioDeimos_Update";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@NroCaso", DbType.String, NroCaso));

                ExecuteNonQuery(oParameters);

            }
            catch (Exception ex)
            {
                ar.com.telecom.eva.CoreServices.Logging.Logger.WriteError("Clase: DALResultadoEstadoDocumento, getResultadoEstadoDocumentos", ex.Message);

                throw new Exception(
                    string.Format("Error Generando Envio a Deimos para Nro de Caso: {0}", NroCaso));
            }
        }

        /// <summary>
        /// M?todo que crea un objeto ResultadoEstadoDocumento de la tabla dbo.tbl_Resultado_GestionEstadoDocumento
        /// </summary>
        /// <param name="oResultadoEstadoDocumento"></param>
        /// <returns></returns>
        public override ResultadoCambioGestor DoLoad(IDataReader registros)
        {
            try
            {

                ResultadoCambioGestor resultado = new ResultadoCambioGestor();
                resultado.NroCaso = registros[0].ToString();
                resultado.TipoCaso = registros[1].ToString();
                resultado.NroCliente = registros[2].ToString();
                resultado.NroTramite = registros[3].ToString();
                resultado.NroAcuerdo = registros[4].ToString();
                resultado.GestorActual = registros[5].ToString();
                resultado.FechaCbioGestor = Convert.ToDateTime(registros[6].ToString() == "" ? DateTime.MinValue.ToShortTimeString() : registros[6].ToString());

                return resultado;
            }
            catch (Exception ex)
            {
                ar.com.telecom.eva.CoreServices.Logging.Logger.WriteError("Clase: DALResultadoEstadoDocumento, getResultadoEstadoDocumentos", ex.Message);

                throw new EvaTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

    }
}
