using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Configuration
{
    /// <summary>
    /// Está interfaz es implementada por objetos que se configuran a través de elementos almacenados en la configuración de la
    /// aplicación.
    /// </summary>
    public interface IConfigurable 
    {
        /// <summary>
        /// Entrega al objeto su elemento de configuración.
        /// </summary>
        /// <param name="element">Elemento de configuración para el objeto.</param>
        void Configure(ConfigurationElement element);
    }
}
