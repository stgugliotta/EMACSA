using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ResultadoCambioGestor 
    /// </summary>
    public class ResultadoCambioGestorAdmin
    {


        public List<ResultadoCambioGestor> GetAllResultadoCambioGestorPorCriterio(string mostrar, string tipoCaso, DateTime fechaEnvDesde, DateTime fechaEnvHasta)
        {
            List<ResultadoCambioGestor> lstResultado = new List<ResultadoCambioGestor>();
            try
            {
                using (DALResultadoCambioGestor dalResultado = new DALResultadoCambioGestor())
                {
                    lstResultado = dalResultado.GetAllResultadoCambioGestorPorCriterio(mostrar, tipoCaso, fechaEnvDesde, fechaEnvHasta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultado;

        }


        public void SetCambioGestorPorCaso(List<string> listaCasos)
        {
            try
            {
                using (DALResultadoCambioGestor dalResultado = new DALResultadoCambioGestor())
                {
                    foreach (string nroCaso in listaCasos)
                    {
                        dalResultado.SetCambioGestorPorCaso(nroCaso);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        

    }
}
