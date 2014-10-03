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
    /// Creado		: 2010-01-13
    /// Accion		: Implementacion de la Interface de la Entidad InterfazFactura
    /// Objeto		: GOBBI_NUCLEO.dbo.cfg_application
    /// Descripcion	: 
    /// </summary>
    public class InterfazFacturaService : IInterfazFacturaService
    {
        #region IInterfazFacturaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>InterfazFacturaDataContracts</value>
        public InterfazFacturaDataContracts Load(short idInterfazFactura)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                return (InterfazFacturaDataContracts)interfazFacturaAdmin.Load(idInterfazFactura);
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - Load: InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(InterfazFacturaDataContracts oInterfazFactura)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                interfazFacturaAdmin.Delete((InterfazFactura)oInterfazFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  Delete : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(InterfazFacturaDataContracts oInterfazFactura)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                interfazFacturaAdmin.Update((InterfazFactura)oInterfazFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  Update : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(InterfazFacturaDataContracts oInterfazFactura)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                interfazFacturaAdmin.Insert((InterfazFactura)oInterfazFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  Insert : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void InsertPreview(InterfazFacturaDataContracts oInterfazFactura)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                interfazFacturaAdmin.InsertPreview((InterfazFactura)oInterfazFactura);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  Insert : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public InterfazFacturaDataContracts GetInterfazFactura(short idInterfazFactura)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                return (InterfazFacturaDataContracts)interfazFacturaAdmin.Load(idInterfazFactura);
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  GetInterfazFactura : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<InterfazFacturaDataContracts> GetAllInterfazFacturas()
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<InterfazFactura> resultList = interfazFacturaAdmin.GetAllInterfazFacturas();

                return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - GetAllInterfazFacturas : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<InterfazFacturaDataContracts> GetAllInterfazFacturasByCliente(int idCliente)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<InterfazFactura> resultList = interfazFacturaAdmin.GetAllInterfazFacturasByIdCliente(idCliente);

                return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - GetAllInterfazFacturasByCliente : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<InterfazFacturaDataContracts> GetAllInterfazFacturasByClienteFechaProcesoPreview(int idCliente, DateTime fechaProceso)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<InterfazFactura> resultList = interfazFacturaAdmin.GetAllInterfazFacturasByClienteFechaProcesoPreview(idCliente,fechaProceso);

                return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - GetAllInterfazFacturasByCliente : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<InterfazFacturaDataContracts> GetAllInterfazFacturasByClienteFechaProceso(int idCliente, DateTime fechaProceso)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<InterfazFactura> resultList = interfazFacturaAdmin.GetAllInterfazFacturasByClienteFechaProceso(idCliente,fechaProceso);

                return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - GetAllInterfazFacturasByCliente : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<InterfazFacturaDataContracts> GetAllFacturasBajaPorInterfazByCliente(int idCliente)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<InterfazFactura> resultList = interfazFacturaAdmin.GetAllFacturasBajaPorInterfazByCliente(idCliente);

                return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - GetAllFacturasBajaPorInterfazByCliente : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
        
        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ImportacionFacturaDataContracts> ProcessInterfazFacturasByCliente(int idCliente, string idUsuario)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<ImportacionFacturaDataContracts> result = interfazFacturaAdmin.ProcessInterfazFacturasByCliente(idCliente, idUsuario);

                return result;
                /*return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });*/
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - ProcessInterfazFacturasByCliente : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<ImportacionFacturaDataContracts> ProcessInterfazFacturasByClientePreview(int idCliente, string idUsuario)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<ImportacionFacturaDataContracts> result = interfazFacturaAdmin.ProcessInterfazFacturasByClientePreview(idCliente, idUsuario);

                return result;
                /*return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });*/
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - ProcessInterfazFacturasByClientePreview : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }



        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos InterfazFacturaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturas()
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<ImportacionFacturaDataContracts> result = interfazFacturaAdmin.getProcessResultInterfazFacturas();

                return result;
                /*return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });*/
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - getProcessResultInterfazFacturas : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion


        #region IInterfazFacturaService Members


        public List<InterfazFacturaDataContracts> GetAllFacturasBajaPorInterfazByClienteFechaProceso(int idCliente, DateTime fechaProceso)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<InterfazFactura> resultList = interfazFacturaAdmin.GetAllFacturasBajaPorInterfazByClienteFechaProceso(idCliente, fechaProceso);

                return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - GetAllInterfazFacturasByCliente : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }



        public List<InterfazFacturaDataContracts> GetAllFacturasBajaPorInterfazByClienteFechaProcesoPreview(int idCliente, DateTime fechaProceso)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<InterfazFactura> resultList = interfazFacturaAdmin.GetAllFacturasBajaPorInterfazByClienteFechaProcesoPreview(idCliente, fechaProceso);

                return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - GetAllInterfazFacturasByCliente : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion

        #region IInterfazFacturaService Members


        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFecha(DateTime fecha)
        {

            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<ImportacionFacturaDataContracts> result = interfazFacturaAdmin.getProcessResultInterfazFacturasPorFecha(fecha);

                return result;
                /*return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });*/
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - getProcessResultInterfazFacturas : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFechaPreview(DateTime fecha)
        {

            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<ImportacionFacturaDataContracts> result = interfazFacturaAdmin.getProcessResultInterfazFacturasPorFechaPreview(fecha);

                return result;
                /*return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });*/
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - getProcessResultInterfazFacturas : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<ImportacionFacturaDataContracts> getProcessResultInterfazFacturasPorFechaPreview(int idCliente, DateTime fecha)
        {

            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                List<ImportacionFacturaDataContracts> result = interfazFacturaAdmin.getProcessResultInterfazFacturasPorFechaPreview(idCliente, fecha);

                return result;
                /*return resultList.ConvertAll<InterfazFacturaDataContracts>(
                    delegate(InterfazFactura tempInterfazFactura) { return (InterfazFacturaDataContracts)tempInterfazFactura; });*/
            }
            catch (GobbiTechnicalException ex)
            {
                Herramientas.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi - getProcessResultInterfazFacturas : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }



        #endregion

        #region IInterfazFacturaService Members


        public void TruncateTablePreview()
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                interfazFacturaAdmin.TruncateTablePreview();

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  TruncateTablePreview : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void DeleteLastImportPreview(int idCliente)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                interfazFacturaAdmin.DeleteLastImportPreview(idCliente);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  DeleteLastImportPreview : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void DeleteLastImport(int idCliente)
        {
            try
            {
                InterfazFacturaAdmin interfazFacturaAdmin = new InterfazFacturaAdmin();
                interfazFacturaAdmin.DeleteLastImport(idCliente);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepcion Tecnica Gobbi  DeleteLastImport : InterfazFacturaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}