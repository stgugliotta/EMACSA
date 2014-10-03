using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;
using System.Data.SqlClient;
namespace EntidadesDAL
{
    /// <summary>
    /// Clase Abtracta para ser utilizara desde los Data
    /// </summary>
    /// <typeparam name="TEntidad"></typeparam>
    public abstract class AbstractMapper<TEntidad> : IDisposable
    {
        #region P R I V A T E   A T T R I B U T E S
        /// <summary>
        /// Variable interna db
        /// </summary>
        private Database intdb;
        
        /// <summary>
        /// Variable interna ObjConnection
        /// </summary>
        private DbConnection intObjConnection;
        
        /// <summary>
        /// Variable Interna intObjCommand
        /// </summary>
        private DbCommand intObjCommand;
        
        /// <summary>
        ///  Variable interna intCommandType
        /// </summary>
        private CommandType intCommandType = CommandType.StoredProcedure;
        
        /// <summary>
        /// Variable interna intCommandText
        /// </summary>
        private string intCommandText;

        /// <summary>
        /// Variable de base de datos para utilizar en la conexion
        /// </summary>
        /// <value>db</value>
        protected Database Db
        {
            get { return this.intdb; }
            set { this.intdb = value; }
        }

        /// <summary>
        /// Variable ObjConnection 
        /// </summary>
        /// <value>ObjConnection</value>
        protected DbConnection ObjConnection
        {
            get { return this.intObjConnection; }
            set { this.intObjConnection = value; }
        }

        /// <summary>
        /// Objeto Command
        /// </summary>
        /// <value>ObjCommand</value>
        protected DbCommand ObjCommand
        {
            get { return this.intObjCommand; }
            set { this.intObjCommand = value; }
        }

        /// <summary>
        /// Tipo de Objeto por omisión 
        /// </summary>
        /// <value>CommandType</value>
        protected CommandType CommandType
        {
            get { return this.intCommandType; }
            set { this.intCommandType = value; }
        }
        
        /// <summary>
        /// Commando a ser ejecutada en la base de datos 
        /// </summary>
        /// <value>CommandText</value>
        protected string CommandText
        {
            get { return this.intCommandText; }
            set { this.intCommandText = value; }
        }
        #endregion

        /// <summary>
        /// Método de destruccion de labase de datos. 
        /// </summary>
        public void Dispose()
        {
            this.intObjConnection.Close();
            this.intObjConnection.Dispose();
            this.intdb = null;
            this.intObjCommand.Dispose();
            GC.Collect();
        }

        /// <summary>
        ///  abstractFindAll
        /// </summary>
        /// <param name="oParameters"></param>
        /// <returns></returns>
        protected List<TEntidad> AbstractFindAll(ArrayList oParameters)
        {
            IDataReader dataReader;
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();
                }

                this.intObjCommand.CommandType = this.intCommandType;
                this.ObjCommand.CommandText = this.CommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.Db.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                dataReader = this.Db.ExecuteReader(this.intObjCommand);
                List<TEntidad> oReturn = this.LoadAll(dataReader);

                dataReader.Close();
                this.intObjConnection.Close(); 

                return oReturn;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
        }

        /// <summary>
        /// abstractFind
        /// </summary>
        /// <param name="oParameters"></param>
        /// <returns></returns>
        protected TEntidad AbstractFind(ArrayList oParameters)
        {
            IDataReader dataReader;
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open(); 
                }

                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                TEntidad oReturn;
                dataReader = this.intdb.ExecuteReader(this.intObjCommand);
                if (dataReader.Read())
                {
                    oReturn = this.DoLoad(dataReader);
                }
                else
                {
                    oReturn =  default(TEntidad);
                }
                dataReader.Close();
                this.intObjConnection.Close();

                return oReturn;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
        }


        protected List<TEntidad> AbstractFindAll(ArrayList oParameters, TEntidad ent)
        {
            IDataReader dataReader;
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();
                }

                this.intObjCommand.CommandType = this.intCommandType;
                this.ObjCommand.CommandText = this.CommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.Db.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                dataReader = this.Db.ExecuteReader(this.intObjCommand);
                List<TEntidad> oReturn = this.LoadAll(dataReader,ent);

                dataReader.Close();
                this.intObjConnection.Close();

                return oReturn;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
        }
        /// <summary>
        ///  loadAll
        /// </summary>
        /// <param name="registros"></param>
        /// <returns></returns>
        protected List<TEntidad> LoadAll(IDataReader registros)
        {
            List<TEntidad> resultado = new List<TEntidad>();
            while (registros.Read())
            {
                resultado.Add(this.DoLoad(registros));
            }
            return resultado;
        }

        protected List<TEntidad> LoadAll(IDataReader registros, TEntidad ent)
        {
            List<TEntidad> resultado = new List<TEntidad>();
            while (registros.Read())
            {
                resultado.Add(this.DoLoad(registros,ent));
            }
            return resultado;
        }
        /// <summary>
        ///  DoLoad
        /// </summary>
        /// <param name="registros"></param>
        /// <returns></returns>
        public abstract TEntidad DoLoad(IDataReader registros);

        public abstract TEntidad DoLoad(IDataReader registros, TEntidad ent);
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="oParameters"></param>
        public void ExecuteNonQuery(ArrayList oParameters)
        {
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();
                }

                this.intObjCommand.Connection = this.intObjConnection;
                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                
                this.intObjCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="oParameters"></param>
        public void ExecuteNonQuery(ArrayList oParameters, int TimeOut)
        {
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();
                }

                this.intObjCommand.Connection = this.intObjConnection;
                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.CommandTimeout = TimeOut;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                this.intObjCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
            finally
            {
                this.intObjConnection.Close();
            }
        }   
        
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="oParameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(ArrayList oParameters)
        {
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();
                }

                this.intObjCommand.Connection = this.intObjConnection;
                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                object oDev = this.intObjCommand.ExecuteScalar();
                return oDev;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
            finally
            {
                this.intObjConnection.Close();
            }
        }


        public object ExecuteScalar(ArrayList oParameters, DbConnection txObjConnection)
        {
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();

                }

                
                this.intObjCommand.Connection = this.intObjConnection;
                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                object oDev = this.intObjCommand.ExecuteScalar();
                return oDev;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
            finally
            {
            }
        }

        public object ExecuteScalarWithScale(ArrayList oParameters, DbConnection txObjConnection)
        {
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();

                }


                this.intObjCommand.Connection = this.intObjConnection;
                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (SqlParameter  oParameter in oParameters)
                {
                    this.intObjCommand.Parameters.Add(oParameter);

//                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor,oParameter.Scale);
                }

                object oDev = this.intObjCommand.ExecuteScalar();
                return oDev;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
            finally
            {
            }
        }
        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="oParameters"></param>
        /// <param name="sNombreCampo"></param>
        /// <returns></returns>
        public string ExecuteReader(ArrayList oParameters, string sNombreCampo)
        {
            string resultado = string.Empty;
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();
                }

                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                IDataReader dataReader;
                dataReader = this.intdb.ExecuteReader(this.intObjCommand);

                if (dataReader.Read())
                {
                    resultado = dataReader[sNombreCampo].ToString().Trim();
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
            finally
            {
                this.intObjConnection.Close();
            }
            return resultado;
        }


        /// </summary>
        /// <param name="oParameters"></param>
        /// <param name="sNombreCampo"></param>
        /// <returns></returns>
        public List<IDictionary<string, string>> ExecuteReader(ArrayList oParameters)
        {
            string resultado = string.Empty;
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();
                }

                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                IDataReader dataReader;
                dataReader = this.intdb.ExecuteReader(this.intObjCommand);
                List<IDictionary<string, string>> resultados = new List<IDictionary<string, string>>();
                IDictionary<string, string> diccionario = null;

                while (dataReader.Read())
                {
                    diccionario = new Dictionary<String, String>();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        KeyValuePair<string, string> keyVP = new KeyValuePair<string, string>(dataReader.GetName(i).ToString(), dataReader.GetValue(i).ToString());
                        diccionario.Add(keyVP);
                        //diccionario.Add(dataReader.GetName(i),  dataReader.GetValue(i));
                    }

                    resultados.Add(diccionario);

                }

                dataReader.Close();

                return resultados;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
            finally
            {
                this.intObjConnection.Close();
            }

            return null;
        }


        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="oParameters"></param>
        /// <param name="sNombreCampo"></param>
        /// <returns></returns>
        public string ExecuteReaderOnlyString(ArrayList oParameters)
        {
            string resultado = string.Empty;
            try
            {
                if (this.intObjConnection.State == ConnectionState.Closed)
                {
                    this.intObjConnection.Open();
                }

                this.intObjCommand.CommandType = this.intCommandType;
                this.intObjCommand.CommandText = this.intCommandText;

                this.intObjCommand.Parameters.Clear();

                foreach (DBParametro oParameter in oParameters)
                {
                    this.intdb.AddInParameter(this.intObjCommand, oParameter.Nombre, oParameter.Tipo, oParameter.Valor);
                }

                IDataReader dataReader;
                dataReader = this.intdb.ExecuteReader(this.intObjCommand);

                if (dataReader.Read())
                {
                    resultado = dataReader[0].ToString();
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException(ex.Message, ex);
            }
            finally
            {
                this.intObjConnection.Close();
            }
            return resultado;
        }


        /// <summary>
        /// FechayyyyMMdd
        /// </summary>
        /// <param name="sFecha"></param>
        /// <returns></returns>
        public string FechayyyyMMdd(string sFecha)
        {
            string fecha = null;
            if (sFecha != null && sFecha.Trim() != string.Empty)
            {
                if (sFecha.Trim().Length.Equals(8) && sFecha.IndexOf("/") == -1 && sFecha.IndexOf("-") == -1)
                {
                    fecha = sFecha;
                }
                else
                {
                    try
                    {
                        DateTime dtFechaTemp = DateTime.Parse(sFecha, Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
                        fecha = dtFechaTemp.ToString("yyyyMMdd");
                    }
                    catch (System.Exception e)
                    {
                        throw e;
                    }
                }
            }
            return fecha;
        }

        #region Transaction Methods

        /// <summary>
        ///  BeginTransaction
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                if (this.ObjConnection.State == ConnectionState.Closed)
                {
                    this.ObjConnection.Open();
                }

                this.ObjCommand.Transaction = this.ObjConnection.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException("An exception of type " + ex.GetType().ToString() + " was encountered while attempting to begin the Candidatos transaction or open the EVAMCInterfaces connection.", ex.InnerException);
            }

        }
        
        /// <summary>
        ///  RollBackTransaction
        /// </summary>
        public void RollBackTransaction()
        {
            try
            {
                this.ObjCommand.Transaction.Rollback();
            }
            catch (DbException exDb)
            {
                throw new GobbiTechnicalException(
                    "An exception of type " + exDb.GetType().ToString() + " was encountered while attempting to roll back the Candidatos transaction.", exDb.InnerException);
            }

        }

        /// <summary>
        ///  CommitTransaction
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                this.ObjCommand.Transaction.Commit();
                this.ObjCommand.Dispose();
                this.ObjConnection.Close();
                this.ObjConnection.Dispose(); 
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException("An exception of type " + ex.GetType().ToString() +
                                 " was encountered while attempting to commit the Candidatos transaction or close the EVAMCInterfaces connection.",
                                 ex.InnerException);

            }

        }

        #endregion
      }
}