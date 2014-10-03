using System;
using System.Collections.Generic;
using System.Text;
using Gobbi.CoreServices.Configuration;

namespace Gobbi.CoreServices.Caching.Scavenging
{
    /// <summary>
    /// Representa un basurero de la cache.
    /// </summary>
    public interface ICacheScavenger
    {
        /// <summary>
        /// Comienza el proceso de limpieza.
        /// </summary>
        void StartScavenging();
    }
}
