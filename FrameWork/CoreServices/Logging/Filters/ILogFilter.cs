using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.Logging.Filters
{
    /// <summary>
    /// Debe ser implementada por todos los filtros.
    /// </summary>
    public interface ILogFilter
    {
        /// <summary>
        /// Verifica que el <see cref="LogEntry"/> verifico con el criterio del filtro. 
        /// </summary>
        /// <param name="log">Entrada de log a evaluar.</param>
        /// <returns><b>true</b>si el mensaje de almacenarse.</returns>
        bool Filter(LogEntry log);

        /// <summary>
        /// Obtiene el nombre del filtro.
        /// </summary>
        string Name { get; }
    }
}
