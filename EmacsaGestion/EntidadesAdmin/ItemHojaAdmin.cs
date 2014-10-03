using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ItemHoja 
    /// </summary>
  	public class ItemHojaAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto ItemHoja 
        /// </summary>
        /// <param name="idHoja"></param>/// <param name="nroItem"></param>		
		/// <returns></returns>
		 public ItemHoja Load(decimal idHoja,int nroItem)
			{
				ItemHoja oReturn = new ItemHoja();
				try
				{
					using (DALItemHoja dalItemHoja = new DALItemHoja())
                	{
						oReturn = dalItemHoja.Load( idHoja, nroItem);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto ItemHoja
        /// </summary>
        /// <param name="oItemHoja"></param>
      	public void Delete(ItemHoja oItemHoja)
			{
				try
				{
					using (DALItemHoja dalItemHoja = new DALItemHoja())
					{
						dalItemHoja.Delete(oItemHoja);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto ItemHoja 
		/// </summary>
        /// <param name="oItemHoja"></param>
     	public void Update(ItemHoja oItemHoja)
			{
				try
				{
					using (DALItemHoja dalItemHoja = new DALItemHoja())
					{
						dalItemHoja.Update(oItemHoja);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto ItemHoja 
		/// </summary>
        /// <param name="oItemHoja"></param>
     	public void Insert(ItemHoja oItemHoja)
		{
				try
				{
					using (DALItemHoja dalItemHoja = new DALItemHoja())
					{
						dalItemHoja.Insert(oItemHoja);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto ItemHoja 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idHoja"></param> /// <param name="nroItem"></param>         
		/// <returns></returns>
		public ItemHoja GetItemHoja(decimal idHoja,int nroItem)
			{
				ItemHoja oReturn = new ItemHoja();
				try
				{
					using (DALItemHoja dalItemHoja = new DALItemHoja())
                	{
						oReturn = dalItemHoja.Load( idHoja, nroItem);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ItemHoja
		/// de la tabla dbo.MTR_Item_Hoja
        /// </summary>
        /// <returns></returns>
       	public List<ItemHoja> GetAllItemHojas()
		{
			List<ItemHoja> lstItemHoja = new List<ItemHoja>();
            try
            {
                using (DALItemHoja dalItemHoja = new DALItemHoja())
                {
                    lstItemHoja = dalItemHoja.GetAllItemHojas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstItemHoja;
			
			}

        public List<ItemHoja> GetItemsHojaByIdHoja(int idHoja)
        {
            List<ItemHoja> lstItemHoja = new List<ItemHoja>();
            try
            {
                using (DALItemHoja dalItemHoja = new DALItemHoja())
                {
                    lstItemHoja = dalItemHoja.GetItemsHojaByIdHoja(idHoja);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstItemHoja;

        }
	}
}
