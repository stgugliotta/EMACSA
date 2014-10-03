using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto EstadoHoja 
    /// </summary>
  	public class EstadoHojaAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto EstadoHoja 
        /// </summary>
        /// <param name="idEstado"></param>		
		/// <returns></returns>
		 public EstadoHoja Load(short idEstado)
			{
				EstadoHoja oReturn = new EstadoHoja();
				try
				{
					using (DALEstadoHoja dalEstadoHoja = new DALEstadoHoja())
                	{
						oReturn = dalEstadoHoja.Load( idEstado);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto EstadoHoja
        /// </summary>
        /// <param name="oEstadoHoja"></param>
      	public void Delete(EstadoHoja oEstadoHoja)
			{
				try
				{
					using (DALEstadoHoja dalEstadoHoja = new DALEstadoHoja())
					{
						dalEstadoHoja.Delete(oEstadoHoja);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto EstadoHoja 
		/// </summary>
        /// <param name="oEstadoHoja"></param>
     	public void Update(EstadoHoja oEstadoHoja)
			{
				try
				{
					using (DALEstadoHoja dalEstadoHoja = new DALEstadoHoja())
					{
						dalEstadoHoja.Update(oEstadoHoja);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto EstadoHoja 
		/// </summary>
        /// <param name="oEstadoHoja"></param>
     	public void Insert(EstadoHoja oEstadoHoja)
		{
				try
				{
					using (DALEstadoHoja dalEstadoHoja = new DALEstadoHoja())
					{
						dalEstadoHoja.Insert(oEstadoHoja);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto EstadoHoja 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idEstado"></param>   
		/// <returns></returns>
		public EstadoHoja GetEstadoHoja(short idEstado)
			{
				EstadoHoja oReturn = new EstadoHoja();
				try
				{
					using (DALEstadoHoja dalEstadoHoja = new DALEstadoHoja())
                	{
						oReturn = dalEstadoHoja.Load( idEstado);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos EstadoHoja
		/// de la tabla dbo.TBL_Estado_Hoja
        /// </summary>
        /// <returns></returns>
       	public List<EstadoHoja> GetAllEstadoHojas()
		{
			List<EstadoHoja> lstEstadoHoja = new List<EstadoHoja>();
            try
            {
                using (DALEstadoHoja dalEstadoHoja = new DALEstadoHoja())
                {
                    lstEstadoHoja = dalEstadoHoja.GetAllEstadoHojas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEstadoHoja;
			
			}
	}
}
