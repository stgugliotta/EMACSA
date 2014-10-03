using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Provincia 
    /// </summary>
  	public class ProvinciaAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Provincia 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Provincia Load(int id)
			{
				Provincia oReturn = new Provincia();
				try
				{
					using (DALProvincia dalProvincia = new DALProvincia())
                	{
						oReturn = dalProvincia.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Provincia
        /// </summary>
        /// <param name="oProvincia"></param>
      	public void Delete(Provincia oProvincia)
			{
				try
				{
					using (DALProvincia dalProvincia = new DALProvincia())
					{
						dalProvincia.Delete(oProvincia);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Provincia 
		/// </summary>
        /// <param name="oProvincia"></param>
     	public void Update(Provincia oProvincia)
			{
				try
				{
					using (DALProvincia dalProvincia = new DALProvincia())
					{
						dalProvincia.Update(oProvincia);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Provincia 
		/// </summary>
        /// <param name="oProvincia"></param>
     	public void Insert(Provincia oProvincia)
		{
				try
				{
					using (DALProvincia dalProvincia = new DALProvincia())
					{
						dalProvincia.Insert(oProvincia);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Provincia 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
		/// <returns></returns>
		public Provincia GetProvincia(int id)
			{
				Provincia oReturn = new Provincia();
				try
				{
					using (DALProvincia dalProvincia = new DALProvincia())
                	{
						oReturn = dalProvincia.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		/// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Provincia
		/// de la tabla dbo.TBL_Provincia
        /// </summary>
        /// <returns></returns>
       	public List<Provincia> GetAllProvincias()
		{
			List<Provincia> lstProvincia = new List<Provincia>();
            try
            {
                using (DALProvincia dalProvincia = new DALProvincia())
                {
                    lstProvincia = dalProvincia.GetAllProvincias();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProvincia;
			
		}

        /// <summary>
        /// Metodo para traer una lista de la totalidad de los objetos Provincia por Pais
        /// de la tabla dbo.TBL_Provincia
        /// </summary>
        /// <returns></returns>
        public List<Provincia> GetAllProvinciasByPais(int idPais)
        {
            List<Provincia> lstProvincia = new List<Provincia>();
            try
            {
                using (DALProvincia dalProvincia = new DALProvincia())
                {
                    lstProvincia = dalProvincia.GetAllProvinciasByPais(idPais);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProvincia;

        }

	}
}
