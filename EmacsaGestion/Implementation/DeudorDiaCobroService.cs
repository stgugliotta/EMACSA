using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
    /// <summary>
    /// Creado		: 2010-07-17
    /// Accion		: Implementacion de la Interface de la Entidad DeudorDiaCobro
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_deudor_dia_cobro
    /// Descripcion	: 
    /// </summary>
    public class DeudorDiaCobroService : IDeudorDiaCobroService
    {
        #region IDeudorDiaCobroService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>DeudorDiaCobroDataContracts</value>
        public DeudorDiaCobroDataContracts Load(int idDiaCobro)
        {
            try
            {
                DeudorDiaCobroAdmin deudordiacobroAdmin = new DeudorDiaCobroAdmin();
                return (DeudorDiaCobroDataContracts)deudordiacobroAdmin.Load(idDiaCobro);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DeudorDiaCobroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(DeudorDiaCobroDataContracts oDeudorDiaCobro)
        {
            try
            {
                DeudorDiaCobroAdmin deudordiacobroAdmin = new DeudorDiaCobroAdmin();
                deudordiacobroAdmin.Delete((DeudorDiaCobro)oDeudorDiaCobro);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DeudorDiaCobroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(DeudorDiaCobroDataContracts oDeudorDiaCobro)
        {
            try
            {
                DeudorDiaCobroAdmin deudordiacobroAdmin = new DeudorDiaCobroAdmin();
                deudordiacobroAdmin.Update((DeudorDiaCobro)oDeudorDiaCobro);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DeudorDiaCobroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(DeudorDiaCobroDataContracts oDeudorDiaCobro)
        {
            try
            {
                DeudorDiaCobroAdmin deudordiacobroAdmin = new DeudorDiaCobroAdmin();
                deudordiacobroAdmin.Insert((DeudorDiaCobro)oDeudorDiaCobro);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DeudorDiaCobroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>void</value>
        public DeudorDiaCobroDataContracts GetDeudorDiaCobro(int idDiaCobro)
        {
            try
            {
                DeudorDiaCobroAdmin deudordiacobroAdmin = new DeudorDiaCobroAdmin();
                return (DeudorDiaCobroDataContracts)deudordiacobroAdmin.Load(idDiaCobro);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDeudorDiaCobro : DeudorDiaCobroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos DeudorDiaCobroDataContracts
        /// </summary>
        /// <value>void</value>
        public List<DeudorDiaCobroDataContracts> GetAllDeudorDiaCobros()
        {
            try
            {
                DeudorDiaCobroAdmin deudordiacobroAdmin = new DeudorDiaCobroAdmin();
                List<DeudorDiaCobro> resultList = deudordiacobroAdmin.GetAllDeudorDiaCobros();

                return resultList.ConvertAll<DeudorDiaCobroDataContracts>(
                    delegate(DeudorDiaCobro tempDeudorDiaCobro) { return (DeudorDiaCobroDataContracts)tempDeudorDiaCobro; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorDiaCobros : DeudorDiaCobroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorDiaCobroDataContracts> GetAllDeudorDiaCobrosPorIdDeudor(int id_deudor)
        {
            try
            {
                DeudorDiaCobroAdmin deudordiacobroAdmin = new DeudorDiaCobroAdmin();
                List<DeudorDiaCobro> resultList = deudordiacobroAdmin.GetAllDeudorDiaCobrosPorIdDeudor(id_deudor);

                return resultList.ConvertAll<DeudorDiaCobroDataContracts>(
                    delegate(DeudorDiaCobro tempDeudorDiaCobro) { return (DeudorDiaCobroDataContracts)tempDeudorDiaCobro; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorDiaCobros : DeudorDiaCobroService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}