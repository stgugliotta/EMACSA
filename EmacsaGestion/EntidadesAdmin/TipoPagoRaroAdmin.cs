using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{

    /// <summary>
    /// Manejador del objeto TipoPagoRaro 
    /// </summary>
    public class TipoPagoRaroAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto TipoPagoRaro 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public TipoPagoRaro Load(int id)
        {
            TipoPagoRaro oReturn = new TipoPagoRaro();
            try
            {
                using (DALTipoPagoRaro dalTipoPagoRaro = new DALTipoPagoRaro())
                {
                    oReturn = dalTipoPagoRaro.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto TipoPagoRaro
        /// </summary>
        /// <param name="oTipoPagoRaro"></param>
        public void Delete(TipoPagoRaro oTipoPagoRaro)
        {
            try
            {
                using (DALTipoPagoRaro dalTipoPagoRaro = new DALTipoPagoRaro())
                {
                    dalTipoPagoRaro.Delete(oTipoPagoRaro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto TipoPagoRaro 
        /// </summary>
        /// <param name="oTipoPagoRaro"></param>
        public void Update(TipoPagoRaro oTipoPagoRaro)
        {
            try
            {
                using (DALTipoPagoRaro dalTipoPagoRaro = new DALTipoPagoRaro())
                {
                    dalTipoPagoRaro.Update(oTipoPagoRaro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto TipoPagoRaro 
        /// </summary>
        /// <param name="oTipoPagoRaro"></param>
        public void Insert(TipoPagoRaro oTipoPagoRaro)
        {
            try
            {
                using (DALTipoPagoRaro dalTipoPagoRaro = new DALTipoPagoRaro())
                {
                    dalTipoPagoRaro.Insert(oTipoPagoRaro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto TipoPagoRaro 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
        /// <returns></returns>
        public TipoPagoRaro GetTipoPagoRaro(int id)
        {
            TipoPagoRaro oReturn = new TipoPagoRaro();
            try
            {
                using (DALTipoPagoRaro dalTipoPagoRaro = new DALTipoPagoRaro())
                {
                    oReturn = dalTipoPagoRaro.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos TipoPagoRaro
        /// de la tabla dbo.MTR_TipoPagoRaro
        /// </summary>
        /// <returns></returns>
        public List<TipoPagoRaro> GetAllTipoPagoRaros()
        {
            List<TipoPagoRaro> lstTipoPagoRaro = new List<TipoPagoRaro>();
            try
            {
                using (DALTipoPagoRaro dalTipoPagoRaro = new DALTipoPagoRaro())
                {
                    lstTipoPagoRaro = dalTipoPagoRaro.GetAllTipoPagoRaros();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTipoPagoRaro;

        }
    }
}
