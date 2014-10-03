using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Cobrador
    /// </summary>
  	public class CobradorAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Cobrador
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Cobrador Load(int id)
			{
				Cobrador oReturn = new Cobrador();
				try
				{
					using (DALCobrador dalCobrador = new DALCobrador())
                	{
						oReturn = dalCobrador.Load(id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Cobrador
        /// </summary>
        /// <param name="oCobrador"></param>
      	public void Delete(Cobrador oCobrador)
			{
				try
				{
					using (DALCobrador dalCobrador = new DALCobrador())
					{
						dalCobrador.Delete(oCobrador);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Cobrador
		/// </summary>
        /// <param name="oCobrador"></param>
     	public void Update(Cobrador oCobrador)
			{
				try
				{
					using (DALCobrador dalCobrador = new DALCobrador())
					{
						dalCobrador.Update(oCobrador);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Cobrador
		/// </summary>
        /// <param name="oCobrador"></param>
     	public void Insert(Cobrador oCobrador)
		{
				try
				{
					using (DALCobrador dalCobrador = new DALCobrador())
					{
						dalCobrador.Insert(oCobrador);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


		/// <summary>
        /// M?todo de lectura de objeto Cobrador 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>           
		/// <returns></returns>
		public Cobrador GetCobrador(int id)
			{
				Cobrador oReturn = new Cobrador();
				try
				{
					using (DALCobrador dalCobrador = new DALCobrador())
                	{
						oReturn = dalCobrador.Load(id);
					}					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Cobrador
		/// de la tabla dbo.MTR_Cobrador
        /// </summary>
        /// <returns></returns>
       	public List<Cobrador> GetAllCobrador()
		{
			List<Cobrador> lstCobrador = new List<Cobrador>();
            try
            {
                using (DALCobrador dalCobrador = new DALCobrador())
                {
                    lstCobrador = dalCobrador.GetAllCobrador();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCobrador;
			
		}

        public List<Cobrador> GetAllCobradorPorZonaAsignada(int idZona)
        {
            List<Cobrador> lstCobrador = new List<Cobrador>();
            try
            {
                using (DALCobrador dalCobrador = new DALCobrador())
                {
                    lstCobrador = dalCobrador.GetAllCobradorPorZonaAsignada(idZona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCobrador;

        }
	    
    }
}
