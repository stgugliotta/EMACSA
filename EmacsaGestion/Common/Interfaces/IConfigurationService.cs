using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ConfigurationDataContracts(GOBBI_NUCLEO.dbo.CFG_Application)
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Interface para retornar un objeto ConfigurationDataContracts
        /// </summary>
        /// <value>ConfigurationDataContracts</value>
        ConfigurationDataContracts Load(short idConfiguracion);

        /// <summary>
        /// interface para eliminar un ConfigurationDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ConfigurationDataContracts oConfiguration);

        /// <summary>
        /// Interface para actualiza un objeto ConfigurationDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ConfigurationDataContracts oConfiguration);

        /// <summary>
        /// Inteface para Insertar un objeto ConfigurationDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ConfigurationDataContracts oConfiguration);

        /// <summary>
        /// Interface para  rertornar objeto ConfigurationDataContracts
        /// </summary>
        /// <value>ConfigurationDataContracts</value>
        ConfigurationDataContracts GetConfiguration(short idConfiguracion);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ConfigurationDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ConfigurationDataContracts>]]></value>
        List<ConfigurationDataContracts> GetAllConfigurations();
    }
}
