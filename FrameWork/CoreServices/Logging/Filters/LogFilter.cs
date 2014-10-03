using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Gobbi.CoreServices.Configuration;

namespace Gobbi.CoreServices.Logging.Filters
{
    /// <summary>
    /// Implementación abstracta de la interface <see cref="ILogFilter"/>.
    /// </summary>
    public abstract class LogFilter  : ILogFilter, IConfigurable
    {
        private string name;

        /// <summary>
        /// Verifica que el <see cref="LogEntry"/> verifica con el criterio del filtro. 
        /// </summary>
        /// <param name="log">Entrada de log a evaluar.</param>
        /// <returns><b>true</b>si el mensaje de almacenarse.</returns>
        public abstract bool Filter(LogEntry log);

        /// <summary>
        /// Nombre del filtro.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Entrega al objeto su elemento de configuración.
        /// </summary>
        /// <param name="element">Elemento de configuración para el objeto.</param>
        public virtual void Configure(ConfigurationElement element)
        {
            this.name = ((ConfigurationNamedElement)element).Name;
        }

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="name">nombre de la instancia.</param>
        public LogFilter(string name)
        {
            this.name = name;
        }
    }
}
