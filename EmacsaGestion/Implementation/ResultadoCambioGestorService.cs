using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
    /// <summary>
    /// Creado		: 2009-11-30
    /// Accion		: Implementacion de la Interface de la Entidad ResultadoCambioGestor
    /// Objeto		: 
    /// Descripcion	: 
    /// </summary>
    public class ResultadoCambioGestorService : IResultadoCambioGestorService
    {
        #region IResultadoCambioGestorService   M E M B E R S

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ResultadoCambioGestorDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ResultadoCambioGestorDataContracts> GetAllResultadoCambioGestorPorCriterio(string mostrar, string tipoCaso, DateTime fechaEnvDesde, DateTime fechaEnvHasta)
        {
            try
            {
                ResultadoCambioGestorAdmin resultadoADM = new ResultadoCambioGestorAdmin();

                List<ResultadoCambioGestor> resultList = resultadoADM.GetAllResultadoCambioGestorPorCriterio(mostrar, tipoCaso, fechaEnvDesde, fechaEnvHasta);

                return resultList.ConvertAll<ResultadoCambioGestorDataContracts>(
                    delegate(ResultadoCambioGestor tempResultadoCbioGestor) { return (ResultadoCambioGestorDataContracts)tempResultadoCbioGestor; });
            }
            catch (Exception ex)
            {
                ar.com.telecom.eva.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Eva - GetAllResultadoCambioGestor : ResultadoCambioGestorService", ex.ToString(), "TechnicalException");

                throw new Exception(
                    ex.Message
                                                );
            }
        }


        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos ResultadoCambioGestorDataContracts
        /// </summary>
        /// <value>void</value>
        public void SetCambioGestorPorCaso(List<string> listaCasos)
        {
            try
            {
                ResultadoCambioGestorAdmin resultadoADM = new ResultadoCambioGestorAdmin();
                resultadoADM.SetCambioGestorPorCaso(listaCasos);
            }
            catch (EvaTechnicalException ex)
            {
                ar.com.telecom.eva.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Eva - GetAllResultadoCambioGestor : ResultadoCambioGestorService", ex.ToString(), "TechnicalException");

                throw new EvaFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}