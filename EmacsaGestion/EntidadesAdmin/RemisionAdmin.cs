using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Remision 
    /// </summary>
    public class RemisionAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Remision 
        /// </summary>
        /// <param name="idRemision"></param>		
        /// <returns></returns>
        public Remision Load(int idRemision)
        {
            Remision oReturn = new Remision();
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    oReturn = dalRemision.Load(idRemision);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para eliminar un objeto Remision
        /// </summary>
        /// <param name="oRemision"></param>
        public void Delete( Remision oRemision)
        {
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    dalRemision.Delete(oRemision);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Remision 
        /// </summary>
        /// <param name="oRemision"></param>
        public void Update(Remision oRemision)
        {
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    dalRemision.Update(oRemision);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Remision 
        /// </summary>
        /// <param name="oRemision"></param>
        public int Insert(Remision oRemision)
        {
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                  return   dalRemision.Insert(oRemision);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertCabecera(Remision oRemision)
        {
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    return dalRemision.InsertCabecera(oRemision);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Remision 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idRemision"></param>        
        /// <returns></returns>
        public Remision GetRemision(int idRemision)
        {
            Remision oReturn = new Remision();
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    oReturn = dalRemision.Load(idRemision);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Remision
        /// de la tabla dbo.TBL_Remision
        /// </summary>
        /// <returns></returns>
        public List<Remision> GetAllRemisions()
        {
            List<Remision> lstRemision = new List<Remision>();
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    lstRemision = dalRemision.GetAllRemisions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRemision;

        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Remision
        /// de la tabla dbo.TBL_Remision
        /// </summary>
        /// <returns></returns>
        public List<Remision> GetAllRemisionsBlocked()
        {
            List<Remision> lstRemision = new List<Remision>();
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    lstRemision = dalRemision.GetAllRemisionsBlocked();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRemision;

        }



        /// <summary>
        //
        /// de la tabla dbo.TBL_Remision
        /// </summary>
        /// <returns></returns>
        public void UpdateReciboEnRemision(Remision oRemision,Recibo oRecibo)
        {
           
            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                   dalRemision.UpdateReciboEnRemision(oRemision,oRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void UpdateReciboEnRemision(Remision oRemision)
        {

            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    dalRemision.UpdateReciboEnRemision(oRemision);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public void UpdateReciboEnRemisionParaEdicion(Remision nuevaRemision, Recibo nuevoRecibo)
        {

            try
            {
                using (DALRemision dalRemision = new DALRemision())
                {
                    dalRemision.UpdateReciboEnRemisionParaEdicion(nuevaRemision, nuevoRecibo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
