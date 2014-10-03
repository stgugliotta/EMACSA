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
    /// Creado		: 2010-02-08
    /// Accion		: Implementacion de la Interface de la Entidad Remision
    /// Objeto		: EMACSA_NUCLEO.dbo.mtr_Remision
    /// Descripcion	: 
    /// </summary>
    public class RemisionService : IRemisionService
    {


        #region IRemisionService Members

        public RemisionDataContracts Load(int idRemision)
        {
            try
            {
                RemisionAdmin remisionAdmin = new RemisionAdmin();
                return (RemisionDataContracts)remisionAdmin.Load(idRemision);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: RemisionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void Delete(RemisionDataContracts oRemision)
        {
            throw new NotImplementedException();
        }

        public void Update(RemisionDataContracts oRemision)
        {
            RemisionAdmin remisionAdmin = new RemisionAdmin();



           remisionAdmin.Update((Remision)oRemision);
        }

        public int Insert(RemisionDataContracts oRemision)
        {
            try
            {


                RemisionAdmin remisionAdmin = new RemisionAdmin();



                return remisionAdmin.Insert((Remision)oRemision);


            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : RemisionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public int InsertCabecera(RemisionDataContracts oRemision)
        {
            try
            {


                RemisionAdmin remisionAdmin = new RemisionAdmin();



                return remisionAdmin.InsertCabecera((Remision)oRemision);


                             

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  InsertCabecera : RemisionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public RemisionDataContracts GetRemision(int id)
        {
            try
            {
                RemisionAdmin remisionAdmin = new RemisionAdmin();
                return (RemisionDataContracts)remisionAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: RemisionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<RemisionDataContracts> GetAllRemisions()
        {
            throw new NotImplementedException();
        }

        public List<RemisionDataContracts> GetAllRemisionsBlocked()
        {
            try
            {


                RemisionAdmin remisionAdmin = new RemisionAdmin();
                                
                List<Remision> resultList = remisionAdmin.GetAllRemisionsBlocked();
               
                return resultList.ConvertAll<RemisionDataContracts>(
                    delegate(Remision tempRemision) { return (RemisionDataContracts)tempRemision; });




            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetAllRemisionsBlocked : RemisionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        #endregion
    



        public void  UpdateReciboEnRemision(RemisionDataContracts oRemision)
        {
         try
            {
                       

             RemisionAdmin remisionAdmin = new RemisionAdmin();

             remisionAdmin.UpdateReciboEnRemision((Remision)oRemision);

           }
         catch (GobbiTechnicalException ex)
         {
             Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetAllRemisionsBlocked : RemisionService", ex.ToString(), "TechnicalException");

              throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
         }
}

        public void UpdateReciboEnRemision(RemisionDataContracts oRemision, ReciboDataContracts oRecibo)
        {
            try
            {


                RemisionAdmin remisionAdmin = new RemisionAdmin();

                remisionAdmin.UpdateReciboEnRemision((Remision)oRemision,(Recibo)oRecibo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                       "Excepci?n T?cnica Gobbi  GetAllRemisionsBlocked : RemisionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                      string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void UpdateReciboEnRemisionParaEdicion(RemisionDataContracts nuevaRemision, ReciboDataContracts nuevoRecibo)
        {
            try
            {


                RemisionAdmin remisionAdmin = new RemisionAdmin();

                remisionAdmin.UpdateReciboEnRemisionParaEdicion((Remision)nuevaRemision, (Recibo)nuevoRecibo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                       "Excepci?n T?cnica Gobbi  GetAllRemisionsBlocked : RemisionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                      string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
    }
}