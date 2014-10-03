using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Analista 
    /// </summary>
    public class AnalistaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Analista 
        /// </summary>

        /// <returns></returns>
        public Analista Load()
        {
            Analista oReturn = new Analista();
            try
            {
                using (DALAnalista dalAnalista = new DALAnalista())
                {
                    oReturn = dalAnalista.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Analista
        /// </summary>
        /// <param name="oAnalista"></param>
        public void Delete(Analista oAnalista)
        {
            try
            {
                using (DALAnalista dalAnalista = new DALAnalista())
                {
                    dalAnalista.Delete(oAnalista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Analista 
        /// </summary>
        /// <param name="oAnalista"></param>
        public void Update(Analista oAnalista)
        {
            try
            {
                using (DALAnalista dalAnalista = new DALAnalista())
                {
                    dalAnalista.Update(oAnalista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Analista 
        /// </summary>
        /// <param name="oAnalista"></param>
        public void Insert(Analista oAnalista)
        {
            try
            {
                using (DALAnalista dalAnalista = new DALAnalista())
                {
                    dalAnalista.Insert(oAnalista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Analista 
        /// se deja por compatibilidad con Standares
        /// </summary>

        /// <returns></returns>
        public Analista GetAnalista()
        {
            Analista oReturn = new Analista();
            try
            {
                using (DALAnalista dalAnalista = new DALAnalista())
                {
                    oReturn = dalAnalista.Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Analista
        /// de la tabla dbo.MTR_Analista
        /// </summary>
        /// <returns></returns>
        public List<Analista> GetAllAnalistas()
        {
            List<Analista> lstAnalista = new List<Analista>();
            try
            {
                using (DALAnalista dalAnalista = new DALAnalista())
                {
                    lstAnalista = dalAnalista.GetAllAnalistas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAnalista;

        }
    }
}
