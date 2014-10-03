using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DeudorDataContracts(EMACSA_NUCLEO.dbo.MTR_Deudor)
    /// </summary>
    public interface IDeudorLivianoService
    {
       List<DeudorLivianoDataContracts> GetAllDeudorsLivianoPorCriterioCliente(int cliente);

       List<DeudorLivianoDataContracts> GetAllDeudorsLivianoPorCriterioAnalista(string cliente);

       List<DeudorLivianoDataContracts> GetAllDeudorsLivianoPorAnalista(string analista);

       List<DeudorLivianoDataContracts> GetAllDeudorsLivianoGestionAnalista(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion);

       List<DeudorLivianoDataContracts> GetAllDeudorsLivianoGestionAnalistaConFiltroFechaReclamo(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion, DateTime fechaFiltroFechaReclamo);

    }



}
