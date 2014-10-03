using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Accion		: Implementacion de la Interface de la Entidad Accion
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_accion
    /// Descripcion	: 
    /// </summary>
    public class CambioService : ICambioService
    {
   
        #region ICambioService Members

        public CambioDataContracts Load(int idCambio)
        {
            try
            {
                CambioAdmin cambioAdmin = new CambioAdmin();
                return (CambioDataContracts)cambioAdmin.Load(idCambio);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: CambioService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void Delete(CambioDataContracts oCambio)
        {
            throw new NotImplementedException();
        }

        public void Update(CambioDataContracts oCambio)
        {
            throw new NotImplementedException();
        }

        public void Insert(CambioDataContracts oCambio)
        {
            throw new NotImplementedException();
        }

        public CambioDataContracts GetCambio(int idCambio)
        {
            throw new NotImplementedException();
        }

        public List<CambioDataContracts> GetAllCambio()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}