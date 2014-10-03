using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ClienteDeudor 
    /// </summary>
  	public class ClienteDeudorAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto ClienteDeudor 
        /// </summary>
        /// <param name="idCliente"></param>/// <param name="idDeudor"></param>		
		/// <returns></returns>
		 public ClienteDeudor Load(int idCliente,int idDeudor)
			{
				ClienteDeudor oReturn = new ClienteDeudor();
				try
				{
					using (DALClienteDeudor dalClienteDeudor = new DALClienteDeudor())
                	{
						oReturn = dalClienteDeudor.Load( idCliente, idDeudor);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto ClienteDeudor
        /// </summary>
        /// <param name="oClienteDeudor"></param>
      	public void Delete(ClienteDeudor oClienteDeudor)
			{
				try
				{
					using (DALClienteDeudor dalClienteDeudor = new DALClienteDeudor())
					{
						dalClienteDeudor.Delete(oClienteDeudor);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto ClienteDeudor 
		/// </summary>
        /// <param name="oClienteDeudor"></param>
     	public void Update(ClienteDeudor oClienteDeudor)
			{
				try
				{
					using (DALClienteDeudor dalClienteDeudor = new DALClienteDeudor())
					{
						dalClienteDeudor.Update(oClienteDeudor);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto ClienteDeudor 
		/// </summary>
        /// <param name="oClienteDeudor"></param>
     	public void Insert(ClienteDeudor oClienteDeudor)
		{
				try
				{
					using (DALClienteDeudor dalClienteDeudor = new DALClienteDeudor())
					{
						dalClienteDeudor.Insert(oClienteDeudor);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto ClienteDeudor 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idCliente"></param> /// <param name="idDeudor"></param>  
		/// <returns></returns>
		public ClienteDeudor GetClienteDeudor(int idCliente,int idDeudor)
			{
				ClienteDeudor oReturn = new ClienteDeudor();
				try
				{
					using (DALClienteDeudor dalClienteDeudor = new DALClienteDeudor())
                	{
						oReturn = dalClienteDeudor.Load( idCliente, idDeudor);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ClienteDeudor
		/// de la tabla dbo.TBL_Cliente_Deudor
        /// </summary>
        /// <returns></returns>
       	public List<ClienteDeudor> GetAllClienteDeudors()
		{
			List<ClienteDeudor> lstClienteDeudor = new List<ClienteDeudor>();
            try
            {
                using (DALClienteDeudor dalClienteDeudor = new DALClienteDeudor())
                {
                    lstClienteDeudor = dalClienteDeudor.GetAllClienteDeudors();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstClienteDeudor;
			
			}

        	 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ClienteDeudor
		/// de la tabla dbo.TBL_Cliente_Deudor
        /// </summary>
        /// <returns></returns>
       	public List<ClienteDeudor> GetAllClienteDeudorsByIdDeudor( int idDeudor )
		{
			List<ClienteDeudor> lstClienteDeudor = new List<ClienteDeudor>();
            try
            {
                using (DALClienteDeudor dalClienteDeudor = new DALClienteDeudor())
                {
                    lstClienteDeudor = dalClienteDeudor.GetAllClienteDeudorsByIdDeudor(idDeudor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstClienteDeudor;
			
			}

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ClienteDeudor
        /// de la tabla dbo.TBL_Cliente_Deudor
        /// </summary>
        /// <returns></returns>
        public ClienteDeudor GetClienteAlfanumDelCliente(int idCliente, string alfanumDelCliente)
        {
            ClienteDeudor oClienteDeudor = null;
            try
            {
                using (DALClienteDeudor dalClienteDeudor = new DALClienteDeudor())
                {
                    oClienteDeudor = dalClienteDeudor.GetClienteAlfanumDelCliente(idCliente,alfanumDelCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oClienteDeudor;

        }
	
	}

    
	
}
