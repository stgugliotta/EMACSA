using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.services
{
    /// <summary>
    /// Es la estructura en memoria que representa la colección de todos los servicios. 
    /// Se obtiene a partir de un XML. En cada uno de sus elementos posee la informacion 
    /// necesaria para invocar de manera inproc, a cada uno de los servicios.
    /// </summary>
    /// <seealso cref="ServiceInfo"/>
    /// <seealso cref="ServiceCatalog"/>
    internal class ServiceInfoCollection:List<ServiceInfo>
    {
    }
}
