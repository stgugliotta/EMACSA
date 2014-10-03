using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Hoja 
    /// </summary>
    public class HojaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Hoja 
        /// </summary>
        /// <param name="idHoja"></param>		
        /// <returns></returns>
        public Hoja Load(decimal idHoja)
        {
            Hoja oReturn = new Hoja();
            try
            {
                using (DALHoja dalHoja = new DALHoja())
                {
                    oReturn = dalHoja.Load(idHoja);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Hoja
        /// </summary>
        /// <param name="oHoja"></param>
        public void Delete(Hoja oHoja)
        {
            try
            {
                using (DALHoja dalHoja = new DALHoja())
                {
                    dalHoja.Delete(oHoja);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Hoja 
        /// </summary>
        /// <param name="oHoja"></param>
        public void Update(Hoja oHoja)
        {
            try
            {
                using (DALHoja dalHoja = new DALHoja())
                {
                    dalHoja.Update(oHoja);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Hoja 
        /// </summary>
        /// <param name="oHoja"></param>
        public void Insert(Hoja oHoja)
        {
            try
            {
                List<Hoja> hojasRecientes = this.GetAllHojasEntreFechas(oHoja.FechaCreacion.AddDays(-1), oHoja.FechaCreacion.AddDays(1));
                foreach (Hoja h in hojasRecientes) {
                    if (h.FechaCreacion.Equals(oHoja.FechaCreacion)) {

                        throw new Exception("Ya existe una hoja de ruta cargada para este día. El nro de hoja de ruta para esta fecha es: "+ h.IdHoja);
                    }
                }

                using (DALHoja dalHoja = new DALHoja())
                {
                    dalHoja.Insert(oHoja);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Hoja 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idHoja"></param>    
        /// <returns></returns>
        public Hoja GetHoja(decimal idHoja)
        {
            Hoja oReturn = new Hoja();
            try
            {
                using (DALHoja dalHoja = new DALHoja())
                {
                    oReturn = dalHoja.Load(idHoja);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Hoja
        /// de la tabla dbo.MTR_Hoja
        /// </summary>
        /// <returns></returns>
        public List<Hoja> GetAllHojas()
        {
            List<Hoja> lstHoja = new List<Hoja>();
            try
            {
                using (DALHoja dalHoja = new DALHoja())
                {
                    lstHoja = dalHoja.GetAllHojas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstHoja;

        }

        public List<Hoja> GetAllHojasEntreFechas(DateTime fechaCreacionDesde, DateTime fechaCreacionHasta)
        {
            List<Hoja> lstHoja = new List<Hoja>();
            try
            {
                using (DALHoja dalHoja = new DALHoja())
                {
                    lstHoja = dalHoja.GetAllHojasEntreFechas(fechaCreacionDesde, fechaCreacionHasta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstHoja;

        }
    }
}
