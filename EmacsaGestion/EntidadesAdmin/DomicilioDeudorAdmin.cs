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
  	public class DomicilioDeudorAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto DomicilioDeudor 
        /// </summary>
        /// <param name="idDeudor"></param>		
		/// <returns></returns>
		 public DomicilioDeudor Load(int idDeudor)
			{
				DomicilioDeudor oReturn = new DomicilioDeudor();
				try
				{
					using (DALDomicilioDeudor dalDomicilioDeudor = new DALDomicilioDeudor())
                	{
						oReturn = dalDomicilioDeudor.Load(idDeudor);
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
      	public void Delete(DomicilioDeudor oDomicilioDeudor)
			{
				try
				{
					using (DALDomicilioDeudor dalDomicilioDeudor = new DALDomicilioDeudor())
					{
						dalDomicilioDeudor.Delete(oDomicilioDeudor);
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
     	public void Update(DomicilioDeudor oDomicilioDeudor)
			{
				try
				{
					using (DALDomicilioDeudor dalDomicilioDeudor = new DALDomicilioDeudor())
					{
						dalDomicilioDeudor.Update(oDomicilioDeudor);
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
     	public void Insert(DomicilioDeudor oDomicilioDeudor)
		{
				try
				{
					using (DALDomicilioDeudor dalDomicilioDeudor = new DALDomicilioDeudor())
					{
						dalDomicilioDeudor.Insert(oDomicilioDeudor);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        public void InsertNuevo(DomicilioDeudor oDomicilioDeudor)
        {
            try
            {
                using (DALDomicilioDeudor dalDomicilioDeudor = new DALDomicilioDeudor())
                {
                    dalDomicilioDeudor.InsertNuevo(oDomicilioDeudor);
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
		public DomicilioDeudor GetDomicilioDeudor(int idDeudor)
			{
				DomicilioDeudor oReturn = new DomicilioDeudor();
				try
				{
					using (DALDomicilioDeudor dalDomicilioDeudor = new DALDomicilioDeudor())
                	{
						oReturn = dalDomicilioDeudor.Load( idDeudor);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}


        public DomicilioDeudor GetDomicilioDeudorByIdDeudorIdHoja(int idDeudor, int idHoja)
        {
            DomicilioDeudor oReturn = new DomicilioDeudor();
            try
            {
                using (DALDomicilioDeudor dalDomicilioDeudor = new DALDomicilioDeudor())
                {
                    oReturn = dalDomicilioDeudor.GetDomicilioByIdDeudorIdHoja(idDeudor, idHoja);
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
       	public List<DomicilioDeudor> GetAllDomicilioDeudors()
		{
			List<DomicilioDeudor> lstDomicilioDeudor = new List<DomicilioDeudor>();
            try
            {
                using (DALDomicilioDeudor dalDomicilioDeudor = new DALDomicilioDeudor())
                {
                    lstDomicilioDeudor = dalDomicilioDeudor.GetAllDomicilioDeudors();
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
