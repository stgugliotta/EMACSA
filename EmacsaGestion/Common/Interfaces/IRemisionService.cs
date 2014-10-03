using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{


    /// <summary>
    /// Interface para manejar la entidad RemisionDataContracts(EMACSA_NUCLEO.dbo.MTR_Remision)
    /// </summary>
    public interface IRemisionService
    {
        /// <summary>
        /// Interface para retornar un objeto RemisionDataContracts
        /// </summary>
        /// <value>RemisionDataContracts</value>
        RemisionDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un RemisionDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(RemisionDataContracts oRemision);

        /// <summary>
        /// Interface para  rertornar una lista de objeto RemisionDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<RemisionDataContracts>]]></value>
        List<RemisionDataContracts> GetAllRemisions();

        /// <summary>
        /// Interface para actualiza un objeto RemisionDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(RemisionDataContracts oRemision);

        /// <summary>
        /// Inteface para Insertar un objeto RemisionDataContracts
        /// </summary>
        /// <value>void</value>
        int Insert(RemisionDataContracts oRemision);
        /// <summary>
        /// Inteface para Insertar un objeto RemisionDataContracts
        /// </summary>
        /// <value>void</value>
        int InsertCabecera(RemisionDataContracts oRemision);

        /// <summary>
        /// Interface para  rertornar objeto RemisionDataContracts
        /// </summary>
        /// <value>RemisionDataContracts</value>
        RemisionDataContracts GetRemision(int idRemision);

        /// <summary>
        /// Interface para  rertornar una lista de objeto RemisionDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<RemisionDataContracts>]]></value>
        List<RemisionDataContracts> GetAllRemisionsBlocked();



        /// <summary>
        /// Metodo que actualiza un recibo para una remision existente
        /// </summary>
        /// <value>ListList<![CDATA[<RemisionDataContracts>]]></value>

        void UpdateReciboEnRemision(RemisionDataContracts oRemision);

        void UpdateReciboEnRemision(RemisionDataContracts oRemision,ReciboDataContracts oRecibo);
        void UpdateReciboEnRemisionParaEdicion(RemisionDataContracts nuevaRemision, ReciboDataContracts nuevoRecibo);
    }
}
