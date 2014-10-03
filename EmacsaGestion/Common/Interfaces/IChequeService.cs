using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad ChequeDataContracts(EMACSA_NUCLEO.dbo.MTR_Cheque)
    /// </summary>
    public interface IChequeService
    {
        /// <summary>
        /// Interface para retornar un objeto ChequeDataContracts
        /// </summary>
        /// <value>ChequeDataContracts</value>
        ChequeDataContracts Load(int idCheque);

        /// <summary>
        /// interface para eliminar un ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(ChequeDataContracts oCheque);

        /// <summary>
        /// Interface para actualiza un objeto ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(ChequeDataContracts oCheque);

        /// <summary>
        /// Inteface para Insertar un objeto ChequeDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(ChequeDataContracts oCheque);

        /// <summary>
        /// Interface para  rertornar objeto ChequeDataContracts
        /// </summary>
        /// <value>ChequeDataContracts</value>
        ChequeDataContracts GetCheque(int idCheque);

        /// <summary>
        /// Interface para  rertornar objeto ChequeDataContracts
        /// </summary>
        /// <value>ChequeDataContracts</value>
        ChequeDataContracts GetChequeByCuit(string cuit);



        /// <summary>
        /// Interface para  rertornar una lista de objeto ChequeDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<ChequeDataContracts>]]></value>
        List<ChequeDataContracts> GetAllCheques();
    }
}
