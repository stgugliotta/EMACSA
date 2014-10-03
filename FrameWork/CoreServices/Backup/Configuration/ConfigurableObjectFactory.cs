using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Configuration
{
    /// <summary>
    /// Provee los métodos para construir objetos y cargar su configuración.
    /// </summary>
    public static class ConfigurableObjectFactory
    {
        /// <summary>
        /// Instancia un nuevo objeto con los parámetros indicados y lo configura si implementa <see cref="IConfigurable"/>.
        /// </summary>
        /// <param name="type">Tipo de objeto a instanciar.</param>
        /// <param name="element">Elemento de configuración a usar para configurarlo.</param>
        /// <param name="args">parametros a usar para el constructor.</param>
        /// <returns>Una nueva instancia del tipo indicado en <paramref name="type"/>.</returns>
        public static object Create(Type type, ConfigurationElement element, object[] args)
        {
            object obj = Activator.CreateInstance(type, args);
            IConfigurable iconfigurable = obj as IConfigurable;
            if (iconfigurable != null)
                iconfigurable.Configure(element);
            return obj;
        }

        /// <summary>
        /// Instancia un nuevo objeto del Tipo pasado por parámetro y lo inicializa si implementa <see cref="IConfigurable"/>.
        /// </summary>
        /// <param name="type">El tipo de objeto a instanciar.</param>
        /// <param name="element">Elemento de configuración a usar para configurarlo.</param>
        /// <returns>Una nueva instancia del tipo indicado en <paramref name="type"/>.</returns>
        public static object Create(Type type, ConfigurationElement element)
        {
            return Create(type, element, null);
        }


    }
}
