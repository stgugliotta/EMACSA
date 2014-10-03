using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Cambio
    /// </summary>
    public class DALCambio : AbstractMapper<Cambio>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALCambio()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

       

        /// <summary>
        /// M?todo que retorna solo un objeto  Cambio
        /// </summary>
        /// <param name="idCambio"></param>        
        /// <returns></returns>
        public Cambio Load(int idMoneda)
        {
            try
            {
                Cambio oReturn = null;
                CommandText = "PA_MG_FRONT_Cambio_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idMoneda", DbType.Int32, idMoneda));

                List<Cambio> cambios = AbstractFindAll(oParameters);
                if (cambios.Count > 0)
                {
                    oReturn = cambios[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCambio, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Cambio
        /// </summary>
        /// <param name="oCambio"></param>
        /// <returns></returns>
        public void Delete(Cambio oCambio)
        {
           
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Cambio
        /// </summary>
        /// <param name="oCambio"></param>
        /// <returns></returns>
        public void Update(Cambio oCambio)
        {
          
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Cambio
        /// </summary>
        /// <param name="oCambio"></param>
        /// <returns></returns>
        public void Insert(Cambio oCambio)
        {
           
        }




      
        public List<Cambio> GetAllCambios()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Cambio_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Cambio> cambios = AbstractFindAll(oParameters);

                return cambios;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCambio, getCambios", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Cambio de la tabla dbo.TBL_Cambio
        /// </summary>
        /// <param name="oCambio"></param>
        /// <returns></returns>
        public override Cambio DoLoad(IDataReader registros)
        {
            try
            {
                Cambio cambio = new Cambio();
                cambio.IdCambio = registros.GetInt32(0);
                cambio.Nombre = registros.IsDBNull(1) != true ? registros.GetString(1) : "";
                cambio.ValorCambio=Double.Parse(registros.GetDecimal(2).ToString());
                cambio.FechaVigencia = registros.GetDateTime(3);
                cambio.IdMoneda = registros.GetInt32(4);
                return cambio;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCambio, getCambios", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Cambio DoLoad(IDataReader registros, Cambio ent)
        {
            throw new NotImplementedException();
        }
    }
}
