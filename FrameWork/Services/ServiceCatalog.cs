using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Web.Caching;
using System.Web;
using System.Threading;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.services
{
    /// <summary>
    /// Clase que administra un catálogo de servicios.
    /// El catalogo de servicios es un repositorio XML donde se listan los 
    /// diferentes servicios con la informacion necesaria para su invocacion.
    /// Se utilizara el cache de la infraestructura de ASP.NET.
    /// </summary>
    internal class ServiceCatalog
    {

        #region "Private vars"
        /// <summary>
        /// Constante con la clave 
        /// </summary>
        private const string CACHE_KEY = "serviceInfoCol";
        private string _serviceFilePath;
        #endregion

        #region "Public properties"

        /// <summary>
        /// Ruta del archivo xml que contiene el repositorio de servicios.
        /// </summary>
        public string ServiceFilePath
        {
            get { return _serviceFilePath; }
            set { _serviceFilePath = value; }
        }
        #endregion

        #region "ASP.NET Cache"
        private static HttpRuntime _httpRuntime;
        /// <summary>
        /// Propiedad que encapsula el acceso a la cache de ASP.NET.
        /// </summary>
        private static Cache Cache
        {
            get
            {
                EnsureHttpRuntime();
                return HttpRuntime.Cache;
            }
        }

        /// <summary>
        /// Este metodo se fija si ya existe httpruntime, si no es asi crea uno nuevo.
        /// Es necesario que exista previamente para poder utilizar la cache de asp.net
        /// </summary>
        private static void EnsureHttpRuntime()
        {
            if (null == _httpRuntime)
            {
                try
                {
                    Monitor.Enter(typeof(ServiceCatalog));
                    if (null == _httpRuntime)
                    {
                        _httpRuntime = new HttpRuntime();
                    }
                }
                finally
                {
                    Monitor.Exit(typeof(ServiceCatalog));
                }
            }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor estatico que cumple con el patron singleton.
        /// </summary>
        static readonly ServiceCatalog instance = new ServiceCatalog();

        /// <summary>
        /// Propiedad estatica que devuelve la instancia unica de ServiceCatalog.
        /// </summary>
        public static ServiceCatalog Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Constructor, es privado porque solo se puede instanciar una vez, usando la propiedad <see cref="Instance"/>.
        /// </summary>
        private ServiceCatalog()
        {
        }
        #endregion

        #region "Private Methods"
        /// <summary>
        /// Carga el repositorio de servicios del archivo XML en memoria.
        /// </summary>
        /// <returns>Devuelve una estructura ServiceInfoCollection con la informacion obtenida del archivo XML.</returns>
        private ServiceInfoCollection LoadXmlFile()
        {
            ServiceInfoCollection col = new ServiceInfoCollection();
            ServiceInfo serviceInfo = null;
            XmlTextReader reader = new XmlTextReader(ServiceFilePath);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "service":
                            serviceInfo = new ServiceInfo();
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "name")
                                    serviceInfo.ServiceName = reader.Value;
                                if (reader.Name == "type")
                                    serviceInfo.ServiceType = reader.Value;                                
                            }
                            break;
                        case "endpoint":
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "name")
                                    serviceInfo.EndPointName.Add(reader.Value);
                            }                            
                            break;                            
                    }
                }
                else
                    {
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "service")
                        {
                            col.Add(serviceInfo);
                        }
                    }                    
            }
            reader.Close();
            return col;
        }
        #endregion

        #region "Public Methods"
        /// <summary>
        /// Metodo generico que busca un servicio, retornando su tipo, que es la informacion necesaria para su posterior invocacion.
        /// Si el repositorio de servicios no esta en la memoria cache, usando el metodo LoadXmlFile, lo carga en esta.
        /// </summary>
        /// <remarks>En el siguiente ejemplo se muestra como funciona este metodo</remarks>
        /// <example>
        /// <code>
        /// // logica de negocio
        /// string typeName = ServiceCatalog.Instance.GetServiceType&lt;IExample&gt;(serviceName);
        /// // invocacion del servicio
        /// </code>
        /// </example>
        /// <param name="serviceName">Servicio en el que se va a efectuar la busqueda</param>
        /// <typeparam name="T">Es la interfaz que tiene que implementar el servicio</typeparam>
        /// <returns>Un string con el tipo del servicio</returns>
        public string GetServiceType<T>(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                throw new GobbiFunctionalException("Service name cant be null or empty");
            }
            ServiceInfoCollection cachedServiceInfoCol;

            cachedServiceInfoCol = (ServiceInfoCollection)Cache[CACHE_KEY];
            if (cachedServiceInfoCol == null)
            {
                cachedServiceInfoCol = LoadXmlFile();          
                Cache.Insert(CACHE_KEY, cachedServiceInfoCol, new CacheDependency(ServiceFilePath), DateTime.MaxValue, Cache.NoSlidingExpiration);
            }   
            string _endpoint = typeof(T).FullName;
            foreach (ServiceInfo s in cachedServiceInfoCol)
            {
                if (s.ServiceName == serviceName && s.EndPointName.Contains(_endpoint))
                    return s.ServiceType;
            }
            throw new GobbiFunctionalException("Service not found");
        }
        #endregion
    }
}