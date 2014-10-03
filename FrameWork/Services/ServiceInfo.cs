using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.services
{
    /// <summary>
    /// Clase sin comportamiento que contiene en sus propiedades la informacion necesaria para instanciar clases de servicios.
    /// Encapsula la información necesaria para que el ServiceClient pueda realizar la invocación a un servicio dado.
    /// </summary>
    /// <seealso cref="ServiceCatalog"/>
    /// <seealso cref="ServiceInfoCollection"/>
    internal class ServiceInfo
    {
        #region "Private vars"
        private string _serviceType;
        private string _serviceName;
        private List<string> _endPointName = new List<string>();
        #endregion

        #region "Constructors"
        /// <summary>
        ///  Constructor sin parametros
        /// </summary>
        public ServiceInfo()
        {
        }

        /// <summary>
        /// Constructor que recibe como parametros el nombre de servicio, y su tipo.
        /// </summary>
        /// <param name="srvName">Nombre del servicio</param>
        /// <param name="srvType">Informacion necesaria para la invocacion</param>
        public ServiceInfo(string srvName, string srvType) 
        {
            _serviceType = srvType;
            _serviceName = srvName;
        }
        #endregion

        #region "Public properties"
        /// <summary>
        /// String que contiene la informacion necesaria para realizar la invocacion.
        /// </summary>
        public string ServiceType
        {
            get { return _serviceType; }
            set { _serviceType = value;}
        }
        /// <summary>
        /// String con el nombre del servicio.
        /// </summary>
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        /// <summary>
        /// Lista de endpoints, los cuales identifican las interfaces que implementa el servicio.
        /// </summary>
        public List<string> EndPointName
        {
            get { return _endPointName; }
            set { _endPointName = value; }
        }
        #endregion

        #region "Public methods"
        /// <summary>
        /// Sobrecarga que devuelve un string con la informacion de invocacion para el servicio.
        /// </summary>
        /// <returns>String con el tipo de servicio, o sea la informacion para la invocacion del mismo.</returns>
        public override string ToString()
        {
            return _serviceType;
        }
        #endregion
    }
}
