using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto DomicilioDeudor 
    /// </summary>
  	public class DomicilioDeudorAlternativoAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto DomicilioDeudor 
        /// </summary>
        /// <param name="idDeudor"></param>		
		/// <returns></returns>
		 public DomicilioDeudorAlternativo Load(int idDeudor)
			{
                DomicilioDeudorAlternativo oReturn = new DomicilioDeudorAlternativo();
				try
				{
                    using (DALDomicilioDeudorAlternativo dalDomicilioDeudorAlternativo = new DALDomicilioDeudorAlternativo())
                	{
                        oReturn = dalDomicilioDeudorAlternativo.Load(idDeudor);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto DomicilioDeudor
        /// </summary>
        /// <param name="oDomicilioDeudor"></param>
         public void Delete(DomicilioDeudorAlternativo oDomicilioDeudor)
			{
				try
				{
                    using (DALDomicilioDeudorAlternativo dalDomicilioDeudorAlternativo = new DALDomicilioDeudorAlternativo())
					{
                        dalDomicilioDeudorAlternativo.Delete(oDomicilioDeudor);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto DomicilioDeudor 
		/// </summary>
        /// <param name="oDomicilioDeudor"></param>
         public void Update(DomicilioDeudorAlternativo oDomicilioDeudor)
			{
				try
				{
                    using (DALDomicilioDeudorAlternativo dalDomicilioDeudorAlternativo = new DALDomicilioDeudorAlternativo())
					{
                        dalDomicilioDeudorAlternativo.Update(oDomicilioDeudor);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto DomicilioDeudor 
		/// </summary>
        /// <param name="oDomicilioDeudor"></param>
         public void Insert(DomicilioDeudorAlternativo oDomicilioDeudor)
		{
				try
				{
                    using (DALDomicilioDeudorAlternativo dalDomicilioDeudorAlternativo = new DALDomicilioDeudorAlternativo())
					{
                        dalDomicilioDeudorAlternativo.Insert(oDomicilioDeudor);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto DomicilioDeudor 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idDeudor"></param>           
		/// <returns></returns>
         public DomicilioDeudorAlternativo GetDomicilioDeudor(int idDeudor)
			{
				DomicilioDeudorAlternativo oReturn = new DomicilioDeudorAlternativo();
				try
				{
                    using (DALDomicilioDeudorAlternativo dalDomicilioDeudorAlternativo = new DALDomicilioDeudorAlternativo())
                	{
                        oReturn = dalDomicilioDeudorAlternativo.Load(idDeudor);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos DomicilioDeudor
		/// de la tabla dbo.TBL_Domicilio_Deudor
        /// </summary>
        /// <returns></returns>
         public List<DomicilioDeudorAlternativo> GetAllDomicilioDeudorsAlternativo()
		{
            List<DomicilioDeudorAlternativo> lstDomicilioDeudor = new List<DomicilioDeudorAlternativo>();
            try
            {
                using (DALDomicilioDeudorAlternativo dalDomicilioDeudor = new DALDomicilioDeudorAlternativo())
                {
                    lstDomicilioDeudor = dalDomicilioDeudor.GetAllDomicilioDeudorsAlternativo();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDomicilioDeudor;
			
		}

         public List<DomicilioDeudorAlternativo> GetAllDomicilioDeudorsAlternativoPorIdDeudor(int idDeudor)
         {
             List<DomicilioDeudorAlternativo> lstDomicilioDeudor = new List<DomicilioDeudorAlternativo>();
             try
             {
                 using (DALDomicilioDeudorAlternativo dalDomicilioDeudor = new DALDomicilioDeudorAlternativo())
                 {
                     lstDomicilioDeudor = dalDomicilioDeudor.GetAllDomicilioDeudorsAlternativo(idDeudor);
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return lstDomicilioDeudor;

         }

    }
}
