using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad TipoPagoRaroDataContracts(EMACSA_NUCLEO.dbo.MTR_TipoPagoRaro)
    /// </summary>
    public interface ITipoPagoRaroService
    {
        /// <summary>
        /// Interface para retornar un objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>TipoPagoRaroDataContracts</value>
        TipoPagoRaroDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un TipoPagoRaroDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(TipoPagoRaroDataContracts oTipoPagoRaro);

        /// <summary>
        /// Interface para actualiza un objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(TipoPagoRaroDataContracts oTipoPagoRaro);

        /// <summary>
        /// Inteface para Insertar un objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(TipoPagoRaroDataContracts oTipoPagoRaro);

        /// <summary>
        /// Interface para  rertornar objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>TipoPagoRaroDataContracts</value>
        TipoPagoRaroDataContracts GetTipoPagoRaro(int id);

        /// <summary>
        /// Interface para  rertornar una lista de objeto TipoPagoRaroDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<TipoPagoRaroDataContracts>]]></value>
        List<TipoPagoRaroDataContracts> GetAllTipoPagoRaros();
    }
}
