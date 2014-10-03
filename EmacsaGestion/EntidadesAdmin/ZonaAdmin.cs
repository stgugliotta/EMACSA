using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Zona
    /// </summary>
  	public class ZonaAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Zona 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Zona Load(int id)
			{
				Zona oReturn = new Zona();
				try
				{
					using (DALZona dalZona = new DALZona())
                	{
						oReturn = dalZona.Load(id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Zona
        /// </summary>
        /// <param name="oZona"></param>
      	public void Delete(Zona oZona)
			{
				try
				{
					using (DALZona dalZona = new DALZona())
					{
						dalZona.Delete(oZona);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Zona
		/// </summary>
        /// <param name="oZona"></param>
     	public void Update(Zona oZona)
			{
				try
				{
					using (DALZona dalZona = new DALZona())
					{
						dalZona.Update(oZona);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Zona
		/// </summary>
        /// <param name="oZona"></param>
     	public void Insert(Zona oZona)
		{
				try
				{
					using (DALZona dalZona = new DALZona())
					{
						dalZona.Insert(oZona);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


		/// <summary>
        /// M?todo de lectura de objeto Zona 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>           
		/// <returns></returns>
		public Zona GetZona(int id)
			{
				Zona oReturn = new Zona();
				try
				{
					using (DALZona dalZona = new DALZona())
                	{
						oReturn = dalZona.Load(id);
					}					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Zona
		/// de la tabla dbo.MTR_Zona
        /// </summary>
        /// <returns></returns>
       	public List<Zona> GetAllZona()
		{
			List<Zona> lstZona = new List<Zona>();
            try
            {
                using (DALZona dalZona = new DALZona())
                {
                    lstZona = dalZona.GetAllZona();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstZona;
			
		}

        public List<Zona> GetZonasByCobrador(int id_cobrador)
        {
            List<Zona> lstZona = new List<Zona>();
            try
            {
                using (DALZona dalZona = new DALZona())
                {
                    lstZona = dalZona.GetZonasByCobrador(id_cobrador);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstZona;

        }


        public void AsociarCobrador(int id_cobrador,int id_zona)
        {
            try
            {
                using (DALZona dalZona = new DALZona())
                {
                    dalZona.AsociarCobrador(id_cobrador, id_zona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

	    
    }
}
