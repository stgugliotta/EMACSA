using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;

namespace ar.com.telecom.eva.CoreServices.Logging.Listeners
{
    /// <summary>
    /// <para>Representa un TraceListener Base para ser utilizado para guardar guardar las entradas de Log. 
    /// Todos los TraceListeners deben heredar de ésta clase.</para>
    /// <remarks>Es un punto de extensión para agregar mas TraceListeners.</remarks>
    /// </summary>
    public abstract class CustomTraceListener : TraceListener, IConfigurable
    {
        private string name;

        /// <summary>
        /// Nombre de la instancia, es clave identificatoria. Se obtiene de la configuración.
        /// </summary>
        public new string Name
        {
            get { return name; }
        }

        private string initializeData;
        /// <summary>
        /// Datos de inicialización. Se obtiene de la configuración. Es opcional según la implementación del TraceListener.
        /// </summary>
        public string InitializeData
        {
            get { return initializeData; }
        }

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="name">Nombre de la instancia.</param>
        public CustomTraceListener(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="name">Nombre de la instancia.</param>
        /// <param name="initializeData">Datos adicionales de inicialización.</param>
        /// <remarks>Este constructor se llama solo en el caso que se haya especificado el valor para <paramref name="initializeData"/>
        /// en la configuración.</remarks>
        public CustomTraceListener(string name, string initializeData)
        {
            this.name = name;
            this.initializeData = initializeData;
        }

        /// <summary>
        /// Graba el la entrada de log.
        /// Debe ser implementado en la clase que hereda.
        /// </summary>
        /// <param name="log">Entrada de log a grabar.</param>
        public abstract void Write(LogEntry log);

        /// <summary>
        /// Escribe un mensaje.
        /// <remarks> Este método no debe ser llamado.</remarks>
        /// </summary>
        /// <param name="message">Mensaje a grabar.</param>
        public override void Write(string message)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Escribe un mensaje.
        /// <remarks> Este método no debe ser llamado.</remarks>
        /// </summary>
        /// <param name="message">Mensaje a grabar.</param>
        public override void WriteLine(string message)
        {
            throw new NotImplementedException();
        }



        #region IConfigurable Members

        /// <summary>
        /// Entrega al objeto su elemento de configuración.
        /// </summary>
        /// <param name="element">Elemento de configuración para el objeto.</param>
        public abstract void Configure(ConfigurationElement element);

        #endregion

        /// <summary>
        /// Compara las instancias por su nombre (clave identificatoria.)
        /// </summary>
        /// <param name="obj">objeto a comparar.</param>
        /// <returns>True si los objetos son iguales</returns>
        public override bool Equals(object obj)
        {
            if (obj is CustomTraceListener)
                return this.name.Equals(((CustomTraceListener) obj).name);
            return base.Equals(obj);
        }

        /// <summary>
        /// Retorna el código hash identificador de la instancia. 
        /// </summary>
        /// <returns> código hash identificador de la instancia</returns>
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }
}
