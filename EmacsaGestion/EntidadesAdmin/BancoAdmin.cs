using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Alerta 
    /// </summary>
    public class BancoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Alerta 
        /// </summary>
        /// <param name="idAlerta"></param>		
        /// <returns></returns>
        public Banco Load(int idBanco)
        {
            Banco oReturn = new Banco();
            try
            {
                using (DALBanco dalBanco = new DALBanco())
                {
                    oReturn = dalBanco.Load(idBanco);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Alerta
        /// </summary>
        /// <param name="oAlerta"></param>
        public void Delete(Banco oBanco)
        {
            try
            {
                using (DALBanco dalBanco = new DALBanco())
                {
                    dalBanco.Delete(oBanco);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       

        public List<Banco> GetAllBancos()
        {
            List<Banco> lstBanco = new List<Banco>();
            try
            {
                using (DALBanco dalBanco = new DALBanco())
                {
                    lstBanco = dalBanco.GetAllBancos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstBanco;

        }
    }
}
