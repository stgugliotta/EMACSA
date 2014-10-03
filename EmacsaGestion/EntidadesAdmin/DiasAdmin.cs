using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Dias 
    /// </summary>
    public class DiasAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Dias 
        /// </summary>
        /// <param name="idDia"></param>		
        /// <returns></returns>
        public Dias Load(int idDia)
        {
            Dias oReturn = new Dias();
            try
            {
                using (DALDias dalDias = new DALDias())
                {
                    oReturn = dalDias.Load(idDia);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Dias
        /// </summary>
        /// <param name="oDias"></param>
        public void Delete(Dias oDias)
        {
            try
            {
                using (DALDias dalDias = new DALDias())
                {
                    dalDias.Delete(oDias);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Dias 
        /// </summary>
        /// <param name="oDias"></param>
        public void Update(Dias oDias)
        {
            try
            {
                using (DALDias dalDias = new DALDias())
                {
                    dalDias.Update(oDias);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Dias 
        /// </summary>
        /// <param name="oDias"></param>
        public void Insert(Dias oDias)
        {
            try
            {
                using (DALDias dalDias = new DALDias())
                {
                    dalDias.Insert(oDias);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Dias 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idDia"></param>  
        /// <returns></returns>
        public Dias GetDias(int idDia)
        {
            Dias oReturn = new Dias();
            try
            {
                using (DALDias dalDias = new DALDias())
                {
                    oReturn = dalDias.Load(idDia);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Dias
        /// de la tabla dbo.TBL_Dias
        /// </summary>
        /// <returns></returns>
        public List<Dias> GetAllDiass()
        {
            List<Dias> lstDias = new List<Dias>();
            try
            {
                using (DALDias dalDias = new DALDias())
                {
                    lstDias = dalDias.GetAllDiass();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDias;

        }
    }
}
