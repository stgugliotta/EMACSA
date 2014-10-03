using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Gobbi.CoreServices.Data;

namespace EntidadesDAL
{
    /// <summary>
    ///  DBConnection
    /// </summary>
    public class DBConnection
    {
        #region A  T T R I B U T E S
        
        /// <summary>
        ///  Propiedad Db
        /// </summary>
        private Database db;
        
        /// <summary>
        /// Propieadad ObjConnection
        /// </summary>
        private DbConnection objConnection;
        
        /// <summary>
        /// Propiedad ObjCommand 
        /// </summary>
        private DbCommand objCommand;
        
        /// <summary>
        ///  Propiedad commnadType 
        /// </summary>
        private CommandType commandType = CommandType.StoredProcedure;
        #endregion

        /// <summary>
        ///  Db
        /// </summary>
        /// <value>db</value>
        public Database Db
        {
            get { return this.db; }
            set { this.db = value; }
        }

        /// <summary>
        ///  objeto Connection
        /// </summary>
        /// <value>ObjConnection</value>
        public DbConnection ObjConnection
        {
            get { return this.objConnection; }
            set { this.objConnection = value; }
        }
        
        /// <summary>
        /// Objeto Command
        /// </summary>
        /// <value>ObjCommand</value>
        public DbCommand ObjCommand
        {
            get { return this.objCommand; }
            set { this.objCommand = value; }
        }

        /// <summary>
        ///   objeto CommandType
        /// </summary>
        /// <value>CommandType</value>
        public CommandType CommandType
        {
            get { return this.commandType; }
        }


       

        #region Singleton
        /// <summary>
        /// Instancia para ser usada en el Singleton
        /// </summary>
        private static DBConnection instancia;
        
        /// <summary>
        /// Objeto para ser utilizado cuando se realiza el lock del objeto instancia
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// Constructor 
        /// </summary>
        private DBConnection()
        {
        }

        /// <summary>
        /// Método que retorna una Instancia de DBConnection, tiene que ser la misma que esta instanciada.
        /// </summary>
        /// <value>Instancia</value>
        public static DBConnection Instancia
        {
            get
            {
                lock (lockObject)
                {
                   ////if (_instancia.Db == null) // || (_instancia.ObjConnection == null) || (_instancia.ObjConnection.ConnectionString == string.Empty))
                    //// {
                        instancia = new DBConnection();
                        instancia.Db = DatabaseFactory.CreateDatabase("Gobbi");
                        instancia.ObjConnection = instancia.db.CreateConnection();
                        instancia.ObjCommand = instancia.ObjConnection.CreateCommand();
                        instancia.ObjCommand.Connection = instancia.ObjConnection;
                    
                    //// }
                }
                return instancia;
            }
        }
        #endregion
    }


}
