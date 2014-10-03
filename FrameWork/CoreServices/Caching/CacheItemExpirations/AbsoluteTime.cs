using System;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Caching.CacheItemExpirations
{
    /// <summary>
    /// Esta clase prueba si un ítem con datos ha expirado usando el esquema de tiempo absoluto.
    /// </summary>
    [Serializable]
    public class AbsoluteTime : ICacheItemExpiration
    {
        private DateTime absoluteExpirationTime;

        /// <summary>
        /// Crea una instancia de la clase con una fecha y hora como valor de entrada 
        /// y la convierte a UTC.
        /// </summary>
        /// <param name="absoluteTime">
        /// La fecha y hora a ser verificada para la expiración.
        /// </param>
        public AbsoluteTime(DateTime absoluteTime)
        {
            if (absoluteTime > DateTime.Now)
            {
                // Convierte a UTC para compensar zonas horarias.
                this.absoluteExpirationTime = absoluteTime.ToUniversalTime();
            }
            else
            {
                throw new GobbiTechnicalException("",new ArgumentOutOfRangeException("absoluteTime", Resources.ERROR_ABSOLUTETIMERANGE));
            }
        }

        /// <summary>
        /// Obtiene la fecha y hora de expiración absoluta.
        /// </summary>
        /// <value>
        /// Fecha y hora de expiración absoluta
        /// </value>
        public DateTime AbsoluteExpirationTime
        {
            get { return absoluteExpirationTime; }
        }

        /// <summary>
        /// Crea una instancia basada en un intervalo de tiempo empezando desde la creación de la instancia.
        /// </summary>
        /// <param name="timeFromNow">Intervalo de tiempo desde la creación de la instancia.</param>
        public AbsoluteTime(TimeSpan timeFromNow)
            : this(DateTime.Now + timeFromNow)
        {
        }

        /// <summary>
        ///	Indica si el ítem ha expirado o no.
        /// </summary>
        /// <remarks>
        ///	bool isExpired = ICacheItemExpiration.HasExpired();
        /// </remarks>
        /// <returns>
        ///	"True", si el CacheItem ha expirado o "false", si el CacheItem no ha expirado.
        /// </returns>
        public bool HasExpired() //ICacheItemExpiration
        {
            //Convierte a UTC para compensar por zonas horarias.
            DateTime nowDateTime = DateTime.Now.ToUniversalTime();

            // verifica la expiración.
            return nowDateTime.Ticks >= this.absoluteExpirationTime.Ticks;
        }

        /// <summary>
        /// Llamada para notificar al objeto que el CacheItem dueño de está expiración fue tocado por la acción del usuario.
        /// </summary>
        public void Notify()
        {
        }

        /// <summary>
        /// Llamada para dar a este objeto la oportunidad de inicializarse a si mismo a partir de los datos del CacheItem
        /// </summary>
        /// <param name="owningCacheItem">CacheItem provisto para leer la información de inicialización. Nunca es nulo.</param>
        public void Initialize(CacheItem owningCacheItem)
        {
        }
    }
}
