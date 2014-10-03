using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DatosEdicionReciboDataContracts(EMACSA_NUCLEO.dbo.DatosEdicionRecibo)
    /// </summary>
    public interface IDatosEdicionReciboService
    {
        /// <summary>
        /// Interface para retornar un objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>DatosEdicionReciboDataContracts</value>
        DatosEdicionReciboDataContracts Load();

        /// <summary>
        /// interface para eliminar un DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(DatosEdicionReciboDataContracts oDatosEdicionRecibo);

        /// <summary>
        /// Interface para actualiza un objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(DatosEdicionReciboDataContracts oDatosEdicionRecibo);

        /// <summary>
        /// Inteface para Insertar un objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(DatosEdicionReciboDataContracts oDatosEdicionRecibo);

        /// <summary>
        /// Interface para  rertornar objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>DatosEdicionReciboDataContracts</value>
        DatosEdicionReciboDataContracts GetDatosEdicionRecibo();

        /// <summary>
        /// Interface para  rertornar una lista de objeto DatosEdicionReciboDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DatosEdicionReciboDataContracts>]]></value>
        List<DatosEdicionReciboDataContracts> GetAllDatosEdicionRecibos();

        List<DatosEdicionReciboDataContracts> GetAllDatosEdicionRecibosPorNumeroRemision(int idRemision);

        List<DatosEdicionReciboDataContracts> GetAllDatosEdicionRecibosPorNumeroRecibo(string numRecibo);
    }
}
