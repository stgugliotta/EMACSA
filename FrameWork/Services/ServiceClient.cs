using System;
using System.Collections.Generic;
using System.Text;
using Gobbi.CoreServices.ExceptionHandling;
using System.Configuration;

namespace Gobbi.services
{
    ///<summary>
    /// Se encarga de instanciar servicios mediante la interfaz correspondiente.
    /// Es la principal pieza de invocación de la arquitectura. La capa de presentación accede a los servicios 
    /// a través del ServiceClient. Este mecanismo permite invocar un servicio, abstrayendo al cliente de dónde 
    /// este se encuentra alojado y del canal de invocación.
    /// Esta clase obtiene la información del catálogo de servicios y retornando la interfaz 
    /// del servicio, permite que el cliente intercambie los DataContracts definidos con el mismo.
    /// ServiceClient accede al catálogo de servicios, obteniendo los assemblies correspondientes, 
    /// y los ejecuta dinámicamente.
    /// </summary>
    /// <typeparam name="T">Interface que tiene que implementar el servicio</typeparam>
    public static class ServiceClient<T> where T : class
    {           
        /// <summary>
        /// El atributo serviceDict es un diccionario cuyos elementos poseen las instancias
        /// de los proxies a los servicios.
        /// </summary>
        private static Dictionary<string, Object> serviceDict = new Dictionary<string, Object>();
        private static string serviceFile =  ConfigurationManager.AppSettings["ServiceFilePath"];

        /// <summary>
        /// Este atributo devuelve la ruta del archivo xml con el repositorio de servicios
        /// </summary>
        public static string ServiceFile
        {
            get { return ServiceClient<T>.serviceFile; }
        }
        /// <summary>
        /// Metodo que entrega al cliente un proxy transparente de la interfaces de servicio. 
        /// Esto permite hacer intercepciones a las llamadas, tomar registro de las ejecuciones 
        /// y otras tareas.
        /// </summary>
        /// <exception cref="GobbiFunctionalException">Representa errores inesperados del código, o fallas en dispositivos o entidades externas</exception>
        /// <exception cref="GobbiTechnicalException">Representa a los errores funcionales de los servicios, es decir, los errores que están directamente relacionados con la lógica de negocio.</exception>
        /// <param name="serviceName">Nombre del servicio que se desea instanciar</param>
        /// <returns>Proxy transparente del servicio que implementa la interface</returns>
        /// <example>
        /// <remarks>
        /// En el siguiente ejemplo se invoca al proxy del servicio EjService que implementa la interface
        /// IEjService
        /// </remarks>
        /// <code>
        /// //Invocacion al proxy del servicio EjService que implemente la interface IEjService
        /// IEjService ejsrv = ServiceClient&lt;IEjService&gt;.GetService("EjService");
        /// </code>
        /// <c>Notese que la llamada se realiza en modo estatico</c>
        /// </example>
        public static T GetService(string serviceName)
        {
           
            try
            {

                string pathXmlServices = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");

                ServiceCatalog.Instance.ServiceFilePath = pathXmlServices + serviceFile;

                //ServiceCatalog.Instance.ServiceFilePath = serviceFile;
                if (string.IsNullOrEmpty(serviceName))
                    throw new GobbiFunctionalException("");
                string typeName = ServiceCatalog.Instance.GetServiceType<T>(serviceName);
                if (string.IsNullOrEmpty(typeName))
                    throw new GobbiFunctionalException("");
                Object serviceInstance;
                if (!serviceDict.TryGetValue(typeName, out serviceInstance))
                {
                    TransparentProxy<T> transparentProxy = new TransparentProxy<T>(typeName);
                    serviceInstance = transparentProxy.CreateProxy();
                    serviceDict[typeName] = serviceInstance;                  
                }
                return serviceInstance as T;
            }
            catch (GobbiFunctionalException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new GobbiTechnicalException("",e);
            }
        }

    }
}
