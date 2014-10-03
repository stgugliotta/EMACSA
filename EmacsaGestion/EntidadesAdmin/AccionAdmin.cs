using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Accion 
    /// </summary>
    public class AccionAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Accion 
        /// </summary>
        /// <param name="idAccion"></param>		
        /// <returns></returns>
        public Accion Load(int idAccion)
        {
            Accion oReturn = new Accion();
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    oReturn = dalAccion.Load(idAccion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        public Accion GetLastActionByIdFactura(int idFactura)
        {
            Accion oReturn = new Accion();
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    oReturn = dalAccion.GetLastActionByIdFactura(idFactura);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }
        /// <summary>
        /// M?todo para eliminar un objeto Accion
        /// </summary>
        /// <param name="oAccion"></param>
        public void Delete(Accion oAccion)
        {
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    dalAccion.Delete(oAccion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Accion 
        /// </summary>
        /// <param name="oAccion"></param>
        public void Update(Accion oAccion)
        {
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    dalAccion.Update(oAccion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Accion 
        /// </summary>
        /// <param name="oAccion"></param>
        public void Insert(Accion oAccion)
        {
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    dalAccion.Insert(oAccion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Accion 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idAccion"></param>        
        /// <returns></returns>
        public Accion GetAccion(int idAccion)
        {
            Accion oReturn = new Accion();
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    oReturn = dalAccion.Load(idAccion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Accion
        /// de la tabla dbo.TBL_Accion
        /// </summary>
        /// <returns></returns>
        public List<Accion> GetAllAccions()
        {
            List<Accion> lstAccion = new List<Accion>();
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    lstAccion = dalAccion.GetAllAccions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAccion;

        }
                /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Accion
        /// de la tabla dbo.TBL_Accion
        /// </summary>
        /// <returns></returns>
        public List<Accion> GetAllAccionsByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc)
        {
            List<Accion> lstAccion = new List<Accion>();
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    lstAccion = dalAccion.GetAllAccionsByIdFacturaIdClienteFechaVenc(idFactura, idCliente, fechaVenc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAccion;

        }


        public List<Accion> GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado)
        {
            List<Accion> lstAccion = new List<Accion>();
            try
            {
                using (DALAccion dalAccion = new DALAccion())
                {
                    lstAccion = dalAccion.GetAllAccionsByIdFacturaIdClienteFechaVencIdEstado(idFactura, idCliente, fechaVenc, idEstado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAccion;

        }

        
    }
}
