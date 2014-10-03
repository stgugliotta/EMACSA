using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Pais 
    /// </summary>
  	public class PaisAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Pais 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Pais Load(int id)
			{
				Pais oReturn = new Pais();
				try
				{
					using (DALPais dalPais = new DALPais())
                	{
						oReturn = dalPais.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Pais
        /// </summary>
        /// <param name="oPais"></param>
      	public void Delete(Pais oPais)
			{
				try
				{
					using (DALPais dalPais = new DALPais())
					{
						dalPais.Delete(oPais);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Pais 
		/// </summary>
        /// <param name="oPais"></param>
     	public void Update(Pais oPais)
			{
				try
				{
					using (DALPais dalPais = new DALPais())
					{
						dalPais.Update(oPais);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Pais 
		/// </summary>
        /// <param name="oPais"></param>
     	public void Insert(Pais oPais)
		{
				try
				{
					using (DALPais dalPais = new DALPais())
					{
						dalPais.Insert(oPais);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Pais 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
		/// <returns></returns>
		public Pais GetPais(int id)
			{
				Pais oReturn = new Pais();
				try
				{
					using (DALPais dalPais = new DALPais())
                	{
						oReturn = dalPais.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Pais
		/// de la tabla dbo.TBL_Pais
        /// </summary>
        /// <returns></returns>
       	public List<Pais> GetAllPaiss()
		{
			List<Pais> lstPais = new List<Pais>();
            try
            {
                using (DALPais dalPais = new DALPais())
                {
                    lstPais = dalPais.GetAllPaiss();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPais;
			
			}
	}
}
