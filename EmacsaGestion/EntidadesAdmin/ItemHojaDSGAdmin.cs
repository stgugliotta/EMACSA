using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto ItemHojaDSG 
    /// </summary>
    public class ItemHojaDSGAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto ItemHojaDSG 
        /// </summary>
        /// <param name="idHoja"></param>/// <param name="nroItem"></param>		
        /// <returns></returns>
        public ItemHojaDSG Load(decimal idHoja, int nroItem)
        {
            ItemHojaDSG oReturn = new ItemHojaDSG();
            try
            {
                using (DALItemHojaDSG dalItemHojaDSG = new DALItemHojaDSG())
                {
                    oReturn = dalItemHojaDSG.Load(idHoja, nroItem);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto ItemHojaDSG
        /// </summary>
        /// <param name="oItemHojaDSG"></param>
        public void Delete(ItemHojaDSG oItemHojaDSG)
        {
            try
            {
                using (DALItemHojaDSG dalItemHojaDSG = new DALItemHojaDSG())
                {
                    dalItemHojaDSG.Delete(oItemHojaDSG);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto ItemHojaDSG 
        /// </summary>
        /// <param name="oItemHojaDSG"></param>
        public void Update(ItemHojaDSG oItemHojaDSG)
        {
            try
            {
                using (DALItemHojaDSG dalItemHojaDSG = new DALItemHojaDSG())
                {
                    dalItemHojaDSG.Update(oItemHojaDSG);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto ItemHojaDSG 
        /// </summary>
        /// <param name="oItemHojaDSG"></param>
        public void Insert(ItemHojaDSG oItemHojaDSG)
        {
            try
            {
                using (DALItemHojaDSG dalItemHojaDSG = new DALItemHojaDSG())
                {
                    dalItemHojaDSG.Insert(oItemHojaDSG);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto ItemHojaDSG 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idHoja"></param> /// <param name="nroItem"></param>             
        /// <returns></returns>
        public ItemHojaDSG GetItemHojaDSG(decimal idHoja, int nroItem)
        {
            ItemHojaDSG oReturn = new ItemHojaDSG();
            try
            {
                using (DALItemHojaDSG dalItemHojaDSG = new DALItemHojaDSG())
                {
                    oReturn = dalItemHojaDSG.Load(idHoja, nroItem);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ItemHojaDSG
        /// de la tabla dbo.MTR_Item_Hoja_DSG
        /// </summary>
        /// <returns></returns>
        public List<ItemHojaDSG> GetAllItemHojaDSGs()
        {
            List<ItemHojaDSG> lstItemHojaDSG = new List<ItemHojaDSG>();
            try
            {
                using (DALItemHojaDSG dalItemHojaDSG = new DALItemHojaDSG())
                {
                    lstItemHojaDSG = dalItemHojaDSG.GetAllItemHojaDSGs();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstItemHojaDSG;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos ItemHojaDSG
        /// de la tabla dbo.MTR_Item_Hoja_DSG según el idHoja
        /// </summary>
        /// <returns></returns>
        public List<ItemHojaDSG> GetAllItemHojaDSGsByIdHoja(int idHoja)
        {
            List<ItemHojaDSG> lstItemHojaDSG = new List<ItemHojaDSG>();
            try
            {
                using (DALItemHojaDSG dalItemHojaDSG = new DALItemHojaDSG())
                {
                    lstItemHojaDSG = dalItemHojaDSG.GetAllItemHojaDSGsByIdHoja(idHoja);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstItemHojaDSG;

        }
    }



}
