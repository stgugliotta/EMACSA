using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ClienteCuenta 
    /// </summary>
    public class ClienteCuentaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto ClienteCuenta 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public ClienteCuenta Load(int id)
        {
            ClienteCuenta oReturn = new ClienteCuenta();
            try
            {
                using (DALClienteCuenta dalClienteCuenta = new DALClienteCuenta())
                {
                    oReturn = dalClienteCuenta.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto ClienteCuenta
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        public void Delete(ClienteCuenta oClienteCuenta)
        {
            try
            {
                using (DALClienteCuenta dalClienteCuenta = new DALClienteCuenta())
                {
                    dalClienteCuenta.Delete(oClienteCuenta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto ClienteCuenta 
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        public void Update(ClienteCuenta oClienteCuenta)
        {
            try
            {
                using (DALClienteCuenta dalClienteCuenta = new DALClienteCuenta())
                {
                    dalClienteCuenta.Update(oClienteCuenta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto ClienteCuenta 
        /// </summary>
        /// <param name="oClienteCuenta"></param>
        public void Insert(ClienteCuenta oClienteCuenta)
        {
            try
            {
                using (DALClienteCuenta dalClienteCuenta = new DALClienteCuenta())
                {
                    dalClienteCuenta.Insert(oClienteCuenta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto ClienteCuenta 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>     
        /// <returns></returns>
        public ClienteCuenta GetClienteCuenta(int id)
        {
            ClienteCuenta oReturn = new ClienteCuenta();
            try
            {
                using (DALClienteCuenta dalClienteCuenta = new DALClienteCuenta())
                {
                    oReturn = dalClienteCuenta.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ClienteCuenta
        /// de la tabla dbo.TBL_Cliente_Cuenta
        /// </summary>
        /// <returns></returns>
        public List<ClienteCuenta> GetAllClienteCuentas()
        {
            List<ClienteCuenta> lstClienteCuenta = new List<ClienteCuenta>();
            try
            {
                using (DALClienteCuenta dalClienteCuenta = new DALClienteCuenta())
                {
                    lstClienteCuenta = dalClienteCuenta.GetAllClienteCuentas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstClienteCuenta;

        }

        
        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ClienteCuenta
        /// de la tabla dbo.TBL_Cliente_Cuenta
        /// </summary>
        /// <returns></returns>
        public List<ClienteCuenta> GetAllClienteCuentasByIdCliente(int idCliente)
        {
            List<ClienteCuenta> lstClienteCuenta = new List<ClienteCuenta>();
            try
            {
                using (DALClienteCuenta dalClienteCuenta = new DALClienteCuenta())
                {
                    lstClienteCuenta = dalClienteCuenta.GetAllClienteCuentasByIdCliente(idCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstClienteCuenta;

        }

    }
}
