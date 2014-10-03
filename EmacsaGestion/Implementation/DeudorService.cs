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
    /// Creado		: 2009-12-31
    /// Accion		: Implementacion de la Interface de la Entidad Deudor
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_deudor
    /// Descripcion	: 
    /// </summary>
    public class DeudorService : IDeudorService
    {
        #region IDeudorService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto DeudorDataContracts
        /// </summary>
        /// <value>DeudorDataContracts</value>
        public DeudorDataContracts Load(int idDeudor)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                return (DeudorDataContracts)deudorAdmin.Load(idDeudor);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un DeudorDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(DeudorDataContracts oDeudor)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                deudorAdmin.Delete((Deudor)oDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto DeudorDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(DeudorDataContracts oDeudor)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                deudorAdmin.Update((Deudor)oDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto DeudorDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(DeudorDataContracts oDeudor)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                deudorAdmin.Insert((Deudor)oDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public int Insert2(DeudorDataContracts oDeudor)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                return deudorAdmin.Insert2((Deudor)oDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto DeudorDataContracts
        /// </summary>
        /// <value>void</value>
        public DeudorDataContracts GetDeudor(int idDeudor)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                return (DeudorDataContracts)deudorAdmin.Load(idDeudor);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDeudor : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public DeudorDataContracts GetLastId()
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                return (DeudorDataContracts)deudorAdmin.GetLastId();
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetLastId: DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos DeudorDataContracts
        /// </summary>
        /// <value>void</value>
        public List<DeudorDataContracts> GetAllDeudors()
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudors();

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudors : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorDataContracts> GetAllLocalidadCp()
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllLocalidadCp();

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllLocalidadCp : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorDataContracts> GetAllLocalidadPorCriterioIdZona(int id)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllLocalidadPorCriterioIdZona(id);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllLocalidadCp : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<DeudorDataContracts> GetAllLocalidadCp_PorCp(string Cp)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllLocalidadCp_PorCp(Cp);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllLocalidadCp_PorCp : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorDataContracts> GetAllLocalidadCp_PorLocalidad(string Localidad)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllLocalidadCp_PorLocalidad(Localidad);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllLocalidadCp_PorLocalidad : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto DeudorDataContracts
        /// </summary>
        /// <value>DeudorDataContracts</value>
        public DeudorDataContracts getDeudorByCuit(string cuit)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                return (DeudorDataContracts)deudorAdmin.getDeudorByCuit(cuit);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - getDeudorByCuit: DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        #endregion

        #region IDeudorService Members


        public List<DeudorDataContracts> GetAllDeudorsPorCriterioDeudor(string nombre)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsPorCriterioDeudor(nombre);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioDeudor : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorDataContracts> GetAllDeudorsPorCriterioCliente(string cliente, int idFiltro)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsPorCriterioCliente(cliente,idFiltro);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioCliente : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorDataContracts> GetAllDeudorsPorCriterioCliente(int cliente)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsPorCriterioCliente(cliente);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioCliente : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

  

        public List<DeudorDataContracts> GetAllDeudorsPorCriterioZona(int idZona)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsPorCriterioZona(idZona);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioZona : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<DeudorDataContracts> GetAllDeudorsPorCriterioClienteFecha(string cliente, DateTime vencimientoDesde, DateTime vencimientoHasta)
        {
            //throw new NotImplementedException();
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsPorCriterioClienteFecha(cliente, vencimientoDesde, vencimientoHasta);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation("Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioClienteFecha : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<DeudorDataContracts> GetAllDeudorsPorAlfaNum(string alfaNum)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsPorAlfaNum(alfaNum);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioAnalista : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorDataContracts> GetAllDeudorsPorAlfaNumAndIdCliente(string alfaNum, int idCliente)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsPorAlfaNumAndIdCliente(alfaNum, idCliente);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorAlfaNumAndIdCliente : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        
        public List<DeudorDataContracts> GetAllDeudorsPorCriterioAnalista(string analista)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsPorCriterioAnalista(analista);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioAnalista : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<DeudorDataContracts> GetAllDeudorsGestionAnalista(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsGestionAnalista(analista, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, proximaGestion);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsGestionAnalista : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<DeudorDataContracts> GetAllDeudorsGestionAnalistaConFiltroFechaReclamo(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion, DateTime fechaFiltroFechaReclamo)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsGestionAnalistaConFiltroFechaReclamo(analista, todos, aVencer, cantDias, incluyeVencidas, validarFechaReclamo, idCliente, proximaGestion, fechaFiltroFechaReclamo);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsGestionAnalista : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
       
        public List<DeudorDataContracts> GetAllDeudorsByClienteYAnalista(int idCliente,string analista)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsByClienteYAnalista(idCliente,analista);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsPorCriterioAnalista : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void AsignarAnalista(int idDeudor, int idAnalista)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                deudorAdmin.AsignarAnalista(idDeudor, idAnalista);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  AsignarAnalista : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void AsignarAnalista_Cliente(int idCliente, int idDeudor, int idAnalista)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                deudorAdmin.AsignarAnalista_Cliente(idCliente, idDeudor, idAnalista);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  AsignarAnalista : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void EliminarAnalista(int idDeudor, int idAnalista)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                deudorAdmin.EliminarAnalista(idDeudor, idAnalista);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  EliminarAnalista : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void DesactivarPorId(int idDeudor)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                deudorAdmin.DesactivarPorId(idDeudor);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  DesactivarPorId : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion

        #region IDeudorService Members


        public DeudorDataContracts GetDeudorConDireccionCompleta(int idDeudor)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                return (DeudorDataContracts)deudorAdmin.GetDeudorConDireccionCompleta(idDeudor);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDeudorConDireccionCompleta : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion



        #region IDeudorService Members


        public List<DeudorDataContracts> GetAllDeudorsOpt(string ids)
        {
            try
            {
                DeudorAdmin deudorAdmin = new DeudorAdmin();
                List<Deudor> resultList = deudorAdmin.GetAllDeudorsOpt(ids);

                return resultList.ConvertAll<DeudorDataContracts>(
                    delegate(Deudor tempDeudor) { return (DeudorDataContracts)tempDeudor; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDeudorsOpt : DeudorService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}