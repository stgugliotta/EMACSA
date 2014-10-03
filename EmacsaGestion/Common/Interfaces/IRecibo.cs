using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ReciboDataContracts(EMACSA_NUCLEO.dbo.TBL_Recibo)
    /// </summary>
    public interface IReciboService
    {
        /// <summary>
        /// Interface para retornar un objeto ReciboDataContracts
        /// </summary>
        /// <value>ReciboDataContracts</value>
        ReciboDataContracts Load(int idRecibo);

        /// <summary>
        /// Interface para retornar un objeto ReciboDataContracts
        /// </summary>
        /// <value>ReciboDataContracts</value>
        ReciboDataContracts Load(ReciboDataContracts  oRecibo);

        /// <summary>
        /// Interface para retornar un objeto ReciboDataContracts
        /// </summary>
        /// <value>ReciboDataContracts</value>
        ReciboDataContracts Load(ReciboDataContracts oRecibo, int idCliente);

        /// <summary>
        /// interface para eliminar un ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ReciboDataContracts oRecibo);

        void Delete(ReciboDataContracts oRecibo, int idCliente);

        /// <summary>
        /// Interface para actualiza un objeto ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ReciboDataContracts oRecibo);

        /// <summary>
        /// Inteface para Insertar un objeto ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ReciboDataContracts oRecibo);

        /// <summary>
        /// Interface para  rertornar objeto ReciboDataContracts
        /// </summary>
        /// <value>ReciboDataContracts</value>
        ReciboDataContracts GetRecibo(int idRecibo);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ReciboDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ReciboDataContracts>]]></value>
        List<ReciboDataContracts> GetAllRecibos();

        /// <summary>
        /// Interface para  rertornar una lista de objeto ReciboDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ReciboDataContracts>]]></value>
        List<ReciboDataContracts> GetAllRecibosByIdRemision(int idRemision);

        /// <summary>
        /// Interface para  rertornar una lista de objeto ReciboDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ReciboDataContracts>]]></value>
        List<ReciboDataContracts> GetAllRecibosByIdCliente(int idCliente);

        List<ReciboDataContracts> GetAllRecibosByIdClienteSinUsar(int idCliente);

        ReciboDataContracts GetReciboByNumReciboIdDeudorIdCliente(string pszNumRecibo, int IdDeudor, int IdCliente);


        ReciboDataContracts GetReciboByNumReciboIdCliente(string pszNumRecibo, int IdCliente);

        /// <summary>
        /// Inteface para Insertar un objeto ReciboDataContracts
        /// </summary>
        /// <value>void</value>
        void InsertRelacion(int idRecibo, int idRemision);
    
    }
}
