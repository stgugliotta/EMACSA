using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Gobbi.CoreServices.Configuration
{
    ///<summary>
    /// <para> La interface debe ser implementado por todo fuente de configuración.</para>
    ///</summary>
    public interface IConfigurationSource : IConfigurable
    {
        /// <summary>
        /// <para> Dado el nombre de la sección retorna la sección de configuración correspondiente. </para>
        /// </summary>
        /// <param name="sectionName">Nombre de la sección.</param>
        /// <returns>La sección de configuración pedida.</returns>
        object GetSection(string sectionName);
    }
}
