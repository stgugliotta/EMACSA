using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Localidad 
    /// </summary>
  	public class LocalidadAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Localidad 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Localidad Load(int id)
			{
				Localidad oReturn = new Localidad();
				try
				{
					using (DALLocalidad dalLocalidad = new DALLocalidad())
                	{
						oReturn = dalLocalidad.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Localidad
        /// </summary>
        /// <param name="oLocalidad"></param>
      	public void Delete(Localidad oLocalidad)
			{
				try
				{
					using (DALLocalidad dalLocalidad = new DALLocalidad())
					{
						dalLocalidad.Delete(oLocalidad);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Localidad 
		/// </summary>
        /// <param name="oLocalidad"></param>
     	public void Update(Localidad oLocalidad)
			{
				try
				{
					using (DALLocalidad dalLocalidad = new DALLocalidad())
					{
						dalLocalidad.Update(oLocalidad);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Localidad 
		/// </summary>
        /// <param name="oLocalidad"></param>
     	public void Insert(Localidad oLocalidad)
		{
				try
				{
					using (DALLocalidad dalLocalidad = new DALLocalidad())
					{
						dalLocalidad.Insert(oLocalidad);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Localidad 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>   
		/// <returns></returns>
		public Localidad GetLocalidad(int id)
			{
				Localidad oReturn = new Localidad();
				try
				{
					using (DALLocalidad dalLocalidad = new DALLocalidad())
                	{
						oReturn = dalLocalidad.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Localidad
		/// de la tabla dbo.TBL_Localidad
        /// </summary>
        /// <returns></returns>
       	public List<Localidad> GetAllLocalidads()
		{
			List<Localidad> lstLocalidad = new List<Localidad>();
            try
            {
                using (DALLocalidad dalLocalidad = new DALLocalidad())
                {
                    lstLocalidad = dalLocalidad.GetAllLocalidads();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLocalidad;
			
		}

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Localidad
        /// de la tabla dbo.TBL_Localidad
        /// </summary>
        /// <returns></returns>
        public List<Localidad> GetAllLocalidadsByDepartamento(int idDepartamento)
        {
            List<Localidad> lstLocalidad = new List<Localidad>();
            try
            {
                using (DALLocalidad dalLocalidad = new DALLocalidad())
                {
                    lstLocalidad = dalLocalidad.GetAllLocalidadsByDepartamento(idDepartamento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLocalidad;

        }
	}
}
