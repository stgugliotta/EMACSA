using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad DeudorDataContracts(EMACSA_NUCLEO.dbo.MTR_Deudor)
    /// </summary>
    public interface IDeudorService
    {
        /// <summary>
        /// Interface para retornar un objeto DeudorDataContracts
        /// </summary>
        /// <value>DeudorDataContracts</value>
        DeudorDataContracts Load(int idDeudor);

        /// <summary>
        /// interface para eliminar un DeudorDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(DeudorDataContracts oDeudor);

        /// <summary>
        /// Interface para actualiza un objeto DeudorDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(DeudorDataContracts oDeudor);

        /// <summary>
        /// Inteface para Insertar un objeto DeudorDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(DeudorDataContracts oDeudor);

        int Insert2(DeudorDataContracts oDeudor);

        /// <summary>
        /// Interface para  rertornar objeto DeudorDataContracts
        /// </summary>
        /// <value>DeudorDataContracts</value>
        DeudorDataContracts GetDeudor(int idDeudor);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudors();
        List<DeudorDataContracts> GetAllDeudorsOpt(string ids);
        DeudorDataContracts GetLastId();
        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudorsPorCriterioDeudor(string nombre);
        DeudorDataContracts GetDeudorConDireccionCompleta(int idDeudor);
        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudorsPorCriterioCliente(string cliente, int idFiltro);
        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudorsPorCriterioCliente(int IdCliente);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudorsPorCriterioZona(int idZona);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudorsPorCriterioClienteFecha(string cliente, DateTime vencimientoDesde, DateTime vencimientoHasta);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudorsPorCriterioAnalista(string analista);
        List<DeudorDataContracts> GetAllDeudorsPorAlfaNum(string alfaNum);
        List<DeudorDataContracts> GetAllDeudorsPorAlfaNumAndIdCliente(string alfaNum, int idCliente);
        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudorsGestionAnalista(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion);

        List<DeudorDataContracts> GetAllDeudorsGestionAnalistaConFiltroFechaReclamo(string analista, Boolean todos, Boolean aVencer, int cantDias, Boolean incluyeVencidas, Boolean validarFechaReclamo, Int32 idCliente, Boolean proximaGestion, DateTime fechaFiltroFechaReclamo);

        /// <summary>
        /// Interface para  rertornar una lista de objeto DeudorDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<DeudorDataContracts>]]></value>
        List<DeudorDataContracts> GetAllDeudorsByClienteYAnalista(int idDeudor,string analista);

        /// <summary>
        /// Interface para asignar un analista a un deudor.
        /// </summary>
        /// <param name="idDeudor">Identificador del deudor.</param>
        /// <param name="idAnalista">Identificador del analista.</param>
        void AsignarAnalista(int idDeudor, int idAnalista);


        /// <summary>
        /// Interface para asignar un analista a un deudor.
        /// </summary>
        /// <param name="idCliente">Identificador del cliente.</param>
        /// <param name="idDeudor">Identificador del deudor.</param>
        /// <param name="idAnalista">Identificador del analista.</param>
        void AsignarAnalista_Cliente(int idCliente, int idDeudor, int idAnalista);

        
        /// <summary>
        /// Interface para eliminar un analista del deudor.
        /// </summary>
        /// <param name="idDeudor">Identificador del deudor.</param>
        /// <param name="idAnalista">Identificador del analista.</param>
        void EliminarAnalista(int idDeudor, int idAnalista);

        List<DeudorDataContracts> GetAllLocalidadCp();

        List<DeudorDataContracts> GetAllLocalidadCp_PorCp(string Cp);

        List<DeudorDataContracts> GetAllLocalidadCp_PorLocalidad(string Localidad);

        /// <summary>
        /// Interface para eliminar de forma lógica a un deudor.
        /// </summary>
        /// <param name="idDeudor">Identificador del deudor.</param>
        /// 
        void DesactivarPorId(int idDeudor);


        /// <summary>
        /// Interface para retornar un objeto DeudorDataContracts
        /// </summary>
        /// <value>DeudorDataContracts</value>
        DeudorDataContracts getDeudorByCuit(string cuit);

        List<DeudorDataContracts> GetAllLocalidadPorCriterioIdZona(int id);
    }



}
