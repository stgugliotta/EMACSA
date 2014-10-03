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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Descuento
    /// </summary>
    public class DALDescuento : AbstractMapper<Descuento>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALDescuento()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

        /// <summary>
        /// Destructor Standard
        /// </summary>
        ~DALDescuento()
        {
           // ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Descuento
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        public Descuento Load(int id)
        {
            try
            {
                Descuento oReturn = null;
                CommandText = "PA_MG_FRONT_Descuento_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<Descuento> descuentos = AbstractFindAll(oParameters);
                if (descuentos.Count > 0)
                {
                    oReturn = descuentos[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDescuento, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Descuento
        /// </summary>
        /// <param name="oDescuento"></param>
        /// <returns></returns>
        public void Delete(Descuento oDescuento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Descuento_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oDescuento.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDescuento, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Descuento
        /// </summary>
        /// <param name="oDescuento"></param>
        /// <returns></returns>
        public void Update(Descuento oDescuento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Descuento_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oDescuento.Id));
                oParameters.Add(new DBParametro("@concepto", DbType.String, oDescuento.Concepto));
                oParameters.Add(new DBParametro("@porcentajedeaplicacion", DbType.Int32, oDescuento.PorcentajeDeAplicacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDescuento, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Descuento
        /// </summary>
        /// <param name="oDescuento"></param>
        /// <returns></returns>
        public void Insert(Descuento oDescuento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Descuento_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oDescuento.Id));
                oParameters.Add(new DBParametro("@concepto", DbType.String, oDescuento.Concepto));
                oParameters.Add(new DBParametro("@porcentajedeaplicacion", DbType.Int32, oDescuento.PorcentajeDeAplicacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDescuento, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Descuento de la tabla dbo.TBL_Descuento
        /// </summary>
        /// <param name="oDescuento"></param>
        /// <returns></returns>
        public List<Descuento> GetAllDescuentos()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Descuento_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Descuento> descuentos = AbstractFindAll(oParameters);

                return descuentos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDescuento, getDescuentos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto Descuento de la tabla dbo.TBL_Descuento
        /// </summary>
        /// <param name="oDescuento"></param>
        /// <returns></returns>
        public override Descuento DoLoad(IDataReader registros)
        {
            try
            {
                Descuento descuento = new Descuento();
                descuento.Id = registros.GetInt32(0);
                descuento.Concepto = registros.GetString(1);
                descuento.PorcentajeDeAplicacion = registros.GetInt32(2);

                return descuento;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDescuento, getDescuentos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Descuento DoLoad(IDataReader registros, Descuento ent)
        {
            throw new NotImplementedException();
        }
    }
}
