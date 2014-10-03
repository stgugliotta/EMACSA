using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ar.com.telecom.eva.CoreServices.Properties;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Caching.CacheItemExpirations
{
    /// <summary>
    /// Este proveedor verifica si un item ha expirado usando formato extendido.
    /// </summary>
    [Serializable]
    [ComVisible(false)]
    public class ExtendedFormatTime : ICacheItemExpiration
    {
        private string extendedFormat;
        private DateTime lastUsedTime;

        /// <summary>
        /// Convierte la entrada de formato de fecha y hora a formato extendido.
        /// </summary>
        /// <param name="timeFormat">
        /// Contiene la información de expiración.
        /// </param>
        public ExtendedFormatTime(string timeFormat)
        {
            // check arguments
            if (string.IsNullOrEmpty(timeFormat))
            {
                throw new EvaTechnicalException("", new  ArgumentException(Resources.ERROR_EXTENDEDFORMATNULLTIMEFORMAT, "timeFormat"));
            }

            ExtendedFormat.Validate(timeFormat);

            // Get the modified extended format
            this.extendedFormat = timeFormat;

            // Convert to UTC in order to compensate for time zones		
            this.lastUsedTime = DateTime.Now.ToUniversalTime();
        }

        /// <summary>
        /// Obtiene la fecha y hora en formato extendido.
        /// </summary>
        /// <value>
        /// La fecha y hora en formato extendido.
        /// </value>
        public string TimeFormat
        {
            get { return extendedFormat; }
        }

        /// <summary>
        /// Especifica si el ítem ha expirado o no.
        /// </summary>
        /// <returns>
        /// Devuelve true is ha expirado, de lo contrario falso.
        /// </returns>
        public bool HasExpired()
        {
            // Convert to UTC in order to compensate for time zones		
            DateTime nowDateTime = DateTime.Now.ToUniversalTime();

            ExtendedFormat format = new ExtendedFormat(extendedFormat);
            // Check expiration
            if (format.IsExpired(lastUsedTime, nowDateTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Notifica que el ítem fue usado recientemente.
        /// </summary>
        public void Notify()
        {
        }

        /// <summary>
        /// No usado.
        /// </summary>
        /// <param name="owningCacheItem">No usado.</param>
        public void Initialize(CacheItem owningCacheItem)
        {
        }
    }
}
