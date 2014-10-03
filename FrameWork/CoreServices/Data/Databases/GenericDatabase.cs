using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Transactions;
using Gobbi.CoreServices.Data.Instrumentation;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Data.Databases
{
    /// <summary>
    /// <para> Este proveedor es una implementación de la clase Database para proveedores genéricos de base de datos.</para>
    /// </summary>
    public class GenericDatabase : Database
    {
        #region Private Fields
        /// <summary>
        /// Indica si la instrumentacion fallo
        /// </summary>
        protected static bool counterFails = false;

        private ConnectionString connectionString;
        private static System.Configuration.ConnectionStringsSection connectionStringsSection;

        private DbProviderFactory dbProviderFactory;
        private string providerName;

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene la cadena de conexión a la base de datos.
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString.ToString(); }
        }

        /// <summary>
        /// Obtiene el nombre del proveedor usado para la conexión.
        /// </summary>
        public string ProviderName
        {
            get { return providerName; }
        }

        /// <summary>
        /// <para>Obtiene la cadenea de conexión sin usuario y contraseña.</para>
        /// </summary>
        /// <value>
        /// <para>la cadenea de conexión sin usuario y contraseña.</para>
        /// </value>
        /// <seealso cref="ConnectionString"/>
        protected string ConnectionStringNoCredentials
        {
            get
            {
                return connectionString.ToStringNoCredentials();
            }
        }

        #endregion

        #region ctor.

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="databaseName">Nombre de la base de datos en la configuración.</param>
        public GenericDatabase(string databaseName)
            : base(databaseName)
        {
            LoadConnectionStringSettings(databaseName);

            // guardar el factory ()
            dbProviderFactory = DbProviderFactories.GetFactory(providerName);


            //exponer connstring, provider string, databaseName.
        }


        internal GenericDatabase(string databaseName, string providerName, string connectionString)
            : base(databaseName)
        {
            if (string.IsNullOrEmpty(providerName) || string.IsNullOrEmpty(connectionString))
                throw new GobbiTechnicalException ("", new ArgumentNullException());
            this.providerName = providerName;
            this.connectionString = new ConnectionString(connectionString);
            this.dbProviderFactory = DbProviderFactories.GetFactory(providerName);
        }

        private void LoadConnectionStringSettings(string databaseName)
        {
            // sacar el connection string, con el configurationManager.
            System.Configuration.ConnectionStringSettings connectionStringSetting =
                GetConnectionStringSettings(databaseName);
            if (connectionStringSetting == null)
                throw new GobbiTechnicalException ("", new  System.Configuration.ConfigurationErrorsException(string.Format(Resources.ERROR_CONNECTIONSTRINGSETTINGS_NULL,databaseName)));

            this.providerName = connectionStringSetting.ProviderName;

            this.connectionString = new ConnectionString(connectionStringSetting.ConnectionString);
        }

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="databaseName">Nombre de la base de datos en la configuración.</param>
        /// <param name="dbProviderFactory">Creador de objeto para el proveedor especificado.</param>
        /// <param name="providerName">Nombre del proveedor de la base de datos.</param>
        protected GenericDatabase(string databaseName, DbProviderFactory dbProviderFactory, string providerName)
            : base(databaseName)
        {

            LoadConnectionStringSettings(databaseName);
            this.dbProviderFactory = dbProviderFactory;
            this.providerName = providerName;
        }

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="databaseName">Nombre de la base de datos en la configuración.</param>
        /// <param name="dbProviderFactory">Creador de objeto para el proveedor especificado.</param>
        /// <param name="providerName">Nombre del proveedor de la base de datos.</param>
        /// <param name="connectionString">cadena de conexión a la base de datos.</param>
        protected GenericDatabase(string databaseName, DbProviderFactory dbProviderFactory, string providerName,
            string connectionString)
            : base(databaseName)
        {
            this.providerName = providerName;
            this.connectionString = new ConnectionString(connectionString);
            this.dbProviderFactory = dbProviderFactory;
        }


        #endregion

        #region Private Methods

        private static System.Configuration.ConnectionStringSettings GetConnectionStringSettings(string databaseName)
        {
            if (connectionStringsSection == null)
                connectionStringsSection =
                    (System.Configuration.ConnectionStringsSection) ConfigurationManager.GetSection("connectionStrings");
            if (connectionStringsSection == null)
                throw new System.Configuration.ConfigurationErrorsException(
                    Resources.ERROR_CONNECTIONSTRINGSSECTION_NULL);
            return connectionStringsSection.ConnectionStrings[databaseName];
        }

         internal DbConnectionWrapper CreateConnectionWrapper()
        {
            return CreateConnectionWrapper(true);
        }

        internal DbConnectionWrapper CreateConnectionWrapper(bool disposeInnerConnection)
        {
            DbConnection connection = TransactionScopeConnections.GetConnection(this);
            if (connection != null)
                return new DbConnectionWrapper(connection, false);

            return new DbConnectionWrapper(GetNewOpenConnection(), disposeInnerConnection);
        }

        #endregion

        internal DbConnection GetNewOpenConnection()
        {
            DbConnection connection = null;
            try
            {
                try
                {
                    connection = CreateConnection();
                    
                    connection.Open();
                }
                catch
                {

                    if (!counterFails)
                    {
                        try
                        {
                            InstrumentationProvider.ConnectionFailed();
                        }
                        catch
                        {
                            counterFails = true;
                            Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                        }
                    }
                    //InstrumentationProvider.ConnectionFailed();
                    //throw;
                }
                if (!counterFails)
                {
                    try
                    {
                        InstrumentationProvider.ConnectionOpened();
                    }
                    catch
                    {
                        counterFails = true;
                        Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                    }
                }
                
            }

            catch
            {
                if (connection != null)
                    connection.Close();

                throw;
            }

            return connection;
        }

        ///<summary>
        /// Genera una conexión a la base de datos.
        ///</summary>
        ///<returns>
        /// Devuelve una conexión a la base de datos
        /// </returns>
        public override DbConnection CreateConnection()
        {
            DbConnection newDbConnection = dbProviderFactory.CreateConnection();
            newDbConnection.ConnectionString = ConnectionString;

            return newDbConnection;
        }

        /// <summary>
        /// <para>Crea un <see cref="DbCommand"/> para un procedimiento almacenado 
        /// u otro comando del proveedor.</para>
        /// </summary>
        ///<param name="procedureName">
        /// Nombre del procedimiento a ejecutar.
        /// </param>
        ///<returns>El <see cref="DbCommand"/> para la ejecución.</returns>
        public override DbCommand GetCommand(string procedureName)
        {
            if (string.IsNullOrEmpty(procedureName))
                throw new GobbiTechnicalException ("", new ArgumentException());
            DbCommand cmd = dbProviderFactory.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            return cmd;
        }

        ///<summary>
        /// <para>Ejecuta el <paramref name="command"/> y devuelve el resultado en un nuevo <see cref="DataSet"/>.</para>
        ///</summary>
        ///<param name="command">
        /// <para>El <see cref="DbCommand"/> a ejecutar.</para>
        /// </param>
        ///<returns>
        /// Un <see cref="DataSet"/> con los resultados de el <paramref name="command"/>.
        /// </returns>
        public override DataSet ExecuteDataSet(DbCommand command)
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            LoadDataSet(command, dataSet, "Table");
            return dataSet;
        }

        ///<summary>
        /// <para>Ejecuta el <paramref name="command"/> y devuelve la primer columna de la primer fila en el resultado 
        /// devuelto por la consulta. </para>
        ///</summary>
        ///<param name="command">
        /// <para>El <see cref="DbCommand"/> a ejecutar.</para>
        /// </param>
        ///<returns>
        /// <para>La primer columna de la primer fila en el resultado.</para>
        /// </returns>
        /// <seealso cref="IDbCommand.ExecuteScalar"/>
        public override object ExecuteScalar(DbCommand command)
        {
            if (command == null) throw new GobbiTechnicalException ("", new  ArgumentNullException("command"));

            using (DbConnectionWrapper connection = CreateConnectionWrapper())
            {
                command.Connection = connection.Connection;
                return DoExecuteScalar(command);
            }
        }

        ///<summary>
        /// <para>Ejecuta el <paramref name="command"/> y devuelve el numero de filas afectadas.</para>
        ///</summary>
        ///<param name="command">
        /// <para>El <see cref="DbCommand"/> a ejecutar.</para>
        /// </param>
        ///<returns>
        /// <para>El número de filas afectadas</para>
        /// </returns>
        public override int ExecuteNonQuery(DbCommand command)
        {
            using (DbConnectionWrapper connection = CreateConnectionWrapper())
            {
                command.Connection = connection.Connection;
                return DoExecuteNonQuery(command);
            }
        }

        ///<summary>
        /// <para>Ejecuta el <paramref name="command"/> y devuelve un <see cref="IDataReader"></see> a través del cual 
        /// el resultado puede ser leido. Es responsabilidad de llamante cerrar la conexión y el lector de datos.</para>
        ///</summary>
        ///<param name="command">
        /// <para>El <see cref="DbCommand"/> a ejecutar.</para>
        /// </param>
        ///<returns>
        /// <para>Un <see cref="IDataReader"/>.</para>
        /// </returns>
        public override IDataReader ExecuteReader(DbCommand command)
        {
            DbConnectionWrapper connection = CreateConnectionWrapper(false);

            try
            {
                command.Connection = connection.Connection;
                //
                // If there is a current transaction, we'll be using a shared connection, so we don't
                // want to close the connection when we're done with the reader.
                //
                if (Transaction.Current != null)
                    return DoExecuteReader(command, CommandBehavior.Default);
                else
                    return DoExecuteReader(command, CommandBehavior.CloseConnection);
            }
            catch
            {
                connection.Connection.Close();
                throw;
            }
        }

        ///<summary>
        /// <para> Realiza una ejecución batch de los cambios hechos en el <see cref="DataSet"/>. </para>
        /// <para>LLama el comando respectivo por cada fila insertada, modificada, o eliminada .</para>
        ///</summary>
        ///<param name="dataSet">
        /// <para>El <see cref="DataSet"/> utilizado para actualizar el origen de datos.</para>
        /// </param>
        ///<param name="tableName">
        /// <para>El nombre de la tabla a usar para el mapeo.</para>
        /// </param>
        ///<param name="insertCommand">
        /// <para>El <see cref="DbCommand"/> ejecutado cuando <see cref="DataRowState"/> es <seealso cref="DataRowState.Added"/></para>
        /// </param>
        ///<param name="updateCommand">
        /// <para>El <see cref="DbCommand"/> ejecutado cuando <see cref="DataRowState"/> es <seealso cref="DataRowState.Modified"/></para>
        /// </param>
        ///<param name="deleteCommand">
        /// <para>El <see cref="DbCommand"/> ejecutado cuando <see cref="DataRowState"/> es <seealso cref="DataRowState.Deleted"/></para>
        /// </param>
        ///<returns>
        /// <para> Número de filas afectadas </para>
        /// </returns>
        /// <remarks> La ejecución se hace dentro del <see cref="TransactionScope"/>.</remarks>
        public override int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand, DbCommand updateCommand, DbCommand deleteCommand)
        {
            using (DbConnectionWrapper wrapper = CreateConnectionWrapper())
            {
                if (insertCommand != null)
                {
                    insertCommand.Connection = wrapper.Connection;
                }
                if (updateCommand != null)
                {
                    updateCommand.Connection = wrapper.Connection;
                }
                if (deleteCommand != null)
                {
                    deleteCommand.Connection= wrapper.Connection;
                }

                return DoUpdateDataSet(dataSet, tableName,
                                       insertCommand, updateCommand, deleteCommand);
            }
        }

        ///<summary>
        /// <para> Agrega un nuevo <see cref="DbParameter"/> de salida al <paramref name="command"/> dado. </para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> a agregar el parametro de salida.</para>
        /// </param>
        ///<param name="name">
        /// <para> El nombre del parámetro.</para>
        /// </param>
        ///<param name="dbType">
        /// <para> Uno de los valores de <see cref="DbType"/>.</para>
        /// </param>
        ///<param name="size">
        /// <para> El tamaño máximo de los datos para la columna.</para>
        /// </param>
        public override void AddOutParameter(DbCommand command, string name, DbType dbType, int size)
        {
            AddParameter(command, name, dbType, size, ParameterDirection.Output, true, 0, 0, String.Empty, DataRowVersion.Default, DBNull.Value);


        }

        ///<summary>
        /// <para> Agrega un nuevo <see cref="DbParameter"/> de entrada al <paramref name="command"/> dado. </para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> a agregar el parametro de entrada.</para>
        /// </param>
        ///<param name="name">
        /// <para> El nombre del parámetro.</para>
        /// </param>
        ///<param name="dbType">
        /// <para> Uno de los valores de <see cref="DbType"/>.</para>
        /// </param>
        /// <param name="value">
        /// <para> El valor del parametro.</para>
        /// </param>
        public override void AddInParameter(DbCommand command, string name, DbType dbType, object value)
        {
            AddParameter(command, name, dbType, 0, ParameterDirection.Input, false, 0, 0, String.Empty, DataRowVersion.Default, value);
        }

        public override void AddInParameterCat(DbCommand command, string name, DbType dbType, object value, int scale)
        {
            AddParameter(command, name, dbType, 0, ParameterDirection.Input, false, 0,Convert.ToByte(scale), String.Empty, DataRowVersion.Default, value);
        }
        public override void AddInParameter(DbCommand command, string name, DbType dbType, object value, int scale)
        {
            AddParameter(command, name, dbType, 0, ParameterDirection.Input, false, 0, Convert.ToByte(scale), String.Empty, DataRowVersion.Default, value);
        }

        ///<summary>
        /// <para> Agrega un nuevo <see cref="DbParameter"/> de entrada al <paramref name="command"/> dado 
        /// y asigna un valor. </para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> a agregar el parametro de entrada.</para>
        /// </param>
        ///<param name="name">
        /// <para> El nombre del parámetro.</para>
        /// </param>
        ///<param name="dbType">
        /// <para> Uno de los valores de <see cref="DbType"/>.</para>
        /// </param>
        public override void AddInParameter(DbCommand command, string name, DbType dbType)
        {
            AddParameter(command, name, dbType, 0, ParameterDirection.Input, false, 0, 0, String.Empty, DataRowVersion.Default, null);
        }

        ///<summary>
        /// <para> Agrega un nuevo <see cref="DbParameter"/> de entrada al <paramref name="command"/> dado. </para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> a agregar el parámetro de entrada.</para>
        /// </param>
        ///<param name="name">
        /// <para> El nombre del parámetro.</para>
        /// </param>
        ///<param name="dbType">
        /// <para> Uno de los valores de <see cref="DbType"/>.</para>
        /// </param>
        ///<param name="sourceColumn">
        /// <para> El nombre de la columna mapeada al <see cref="DataSet"/> y usada para cargar y devolver valores. </para>
        /// </param>
        public override void AddInParameterFromSourceColumn(DbCommand command, string name, DbType dbType, string sourceColumn)
        {
            AddParameter(command, name, dbType, 0, ParameterDirection.Input, true, 0, 0, sourceColumn, DataRowVersion.Default, null);
        }

        /// <summary>
        /// Agrega un nuevo objeto <see cref="DbParameter"/> al objeto <paramref name="command"/> dado.
        /// </summary>
        /// <param name="command">El <see cref="DbCommand"/> a agregar el parametro.</param>
        /// <param name="name"><para>El nombre del parámetro.</para></param>
        /// <param name="dbType"><para>Un de los valores de  <see cref="DbType"/>.</para></param>
        /// <param name="size"><para>El tamaño máximo de los datos de la columna.</para></param>
        /// <param name="direction"><para>Uno de los valores de <see cref="ParameterDirection"/>.</para></param>
        /// <param name="nullable"><para>Indica si el parametro acepta valores <see langword="null"/>.</para></param>
        /// <param name="precision"><para>La máxima cantidad de número de digitos utilizado para representar el <paramref name="value"/>.</para></param>
        /// <param name="scale"><para>El número de cifras con que se representa el <paramref name="value"/>.</para></param>
        /// <param name="sourceColumn"><para>El nombre de la columna mapeada al <see cref="DataSet"/> utilizada para resolver el <paramref name="value"/>.</para></param>
        /// <param name="sourceVersion"><para>Uno de los valores de <see cref="DataRowVersion"/>.</para></param>
        /// <param name="value"><para>El valor del parámetro.</para></param>       
        public override void AddParameter(DbCommand command, string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            DbParameter parameter = CreateParameter(name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
            command.Parameters.Add(parameter);

            
            


            
        }

        ///<summary>
        /// <para>Descubre los parámetros para un <see cref="DbCommand"/>.</para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> a descubrir los parámetros.</para>
        /// </param>
        public override void DiscoverParameters(DbCommand command)
        {
            using (DbConnectionWrapper connection = CreateConnectionWrapper())
            {
                using (DbCommand discoveryCommand = this.GetCommand(command.CommandText))
                {
                    discoveryCommand.Connection = connection.Connection;
                    DeriveParameters(discoveryCommand);

                    foreach (IDataParameter parameter in discoveryCommand.Parameters)
                    {
                        IDataParameter cloneParameter = (IDataParameter)((ICloneable)parameter).Clone();
                        command.Parameters.Add(cloneParameter);
                    }
                }
            }
        }


        #region Protected Methods


        /// <summary>
        /// <para>Agrega una nueva instancia de un <see cref="DbParameter"/>.</para>
        /// </summary>
        /// <param name="name"><para>El nombre del parámetro.</para></param>
        /// <param name="dbType"><para>Uno de los valores de <see cref="DbType"/>.</para></param>
        /// <param name="size"><para>El tamaño máximo de los datos contenidos en la columna.</para></param>
        /// <param name="direction"><para>Uno de los valores de <see cref="ParameterDirection"/>.</para></param>
        /// <param name="nullable"><para>Indica si el parámetro acepta valores <see langword="null"/>.</para></param>
        /// <param name="precision"><para>La máxima cantidad de número de digitos utilizado para representar el <paramref name="value"/>.</para></param>
        /// <param name="scale"><para>El número de cifras con que se representa el <paramref name="value"/>.</para></param>
        /// <param name="sourceColumn"><para>El nombre de la columna mapeada al <see cref="DataSet"/> utilizada para resolver el <paramref name="value"/>.</para></param>
        /// <param name="sourceVersion"><para>Uno de los valores de <see cref="DataRowVersion"/>.</para></param>
        /// <param name="value"><para>El valor del parámetro.</para></param>   
        /// <returns>Una nueva instancia de  <see cref="DbParameter"/> inicializada con los parametros.</returns>
        protected DbParameter CreateParameter(string name, DbType dbType, int size, ParameterDirection direction, bool nullable, 
            byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            DbParameter param = CreateParameter(name);
            
            
            ConfigureParameter(param, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
            return param;
        }


        protected DbParameter CreateParameterCat(string name, DbType dbType, int size, ParameterDirection direction, bool nullable,
           byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            DbParameter param = dbProviderFactory.CreateParameter();
            ConfigureParameter(param, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
            return param;
        }


        /// <summary>
        /// <para>Agrega una nueva instancia de un <see cref="DbParameter"/>.</para>
        /// </summary>
        /// <param name="name"><para>El nombre del parámetro.</para></param>
        /// <returns>Una nueva instancia de <see cref="DbParameter"/> sin configurar.</returns>
        protected DbParameter CreateParameter(string name)
        {
            DbParameter param = dbProviderFactory.CreateParameter();
            param.ParameterName = BuildParameterName(name);

            return param;
        }

        /// <summary>
        /// Configura el <see cref="DbParameter"/> dado.
        /// </summary>
        /// <param name="param">El <see cref="DbParameter"/> a configurar.</param>
        /// <param name="name"><para>El nombre del parámetro.</para></param>
        /// <param name="dbType"><para>Uno de los valores de <see cref="DbType"/>.</para></param>
        /// <param name="size"><para>El tamaño máximo de los datos contenidos en la columna.</para></param>
        /// <param name="direction"><para>Uno de los valores de <see cref="ParameterDirection"/>.</para></param>
        /// <param name="nullable"><para>Indica si el parámetro acepta valores <see langword="null"/>.</para></param>
        /// <param name="precision"><para>La máxima cantidad de número de digitos utilizado para representar el <paramref name="value"/>.</para></param>
        /// <param name="scale"><para>El número de cifras con que se representa el <paramref name="value"/>.</para></param>
        /// <param name="sourceColumn"><para>El nombre de la columna mapeada al <see cref="DataSet"/> utilizada para resolver el <paramref name="value"/>.</para></param>
        /// <param name="sourceVersion"><para>Uno de los valores de <see cref="DataRowVersion"/>.</para></param>
        /// <param name="value"><para>El valor del parámetro.</para></param>   
        protected virtual void ConfigureParameter(DbParameter param, string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {

            

            
            param.DbType = dbType;
            param.Size = size;
            param.Value = (value == null) ? DBNull.Value : value;
            param.Direction = direction;
            param.IsNullable = nullable;
            param.SourceColumn = sourceColumn;
            param.SourceVersion = sourceVersion;
           
            
            
        }


        private int DoUpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand,
                          DbCommand updateCommand, DbCommand deleteCommand)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentException(Resources.ERROR_GENERICDATABASE_TABLENAMENULLOREMPTY, "tableName");
            if (dataSet == null) throw new ArgumentNullException("dataSet");

            if (insertCommand == null && updateCommand == null && deleteCommand == null)
            {
                throw new ArgumentNullException(Resources.ERROR_GENERICDATABASE_INVALIDCOMMANDS);
            }

            using (DbDataAdapter adapter = GetDataAdapter())
            {
                IDbDataAdapter explicitAdapter = adapter;
                if (insertCommand != null)
                {
                    explicitAdapter.InsertCommand = insertCommand;
                }
                if (updateCommand != null)
                {
                    explicitAdapter.UpdateCommand = updateCommand;
                }
                if (deleteCommand != null)
                {
                    explicitAdapter.DeleteCommand = deleteCommand;
                }
                try
                {
                    DateTime startTime = DateTime.Now;
                    int rows = adapter.Update(dataSet.Tables[tableName]);
                    
                    if (!counterFails)
                    {
                        try
                        {
                            InstrumentationProvider.CommandExecuted(startTime);
                        }
                        catch
                        {
                            counterFails = true;
                            Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                        }
                    }
                    return rows;
                }
                catch 
                {
                    if (!counterFails)
                    {
                        try
                        {
                            InstrumentationProvider.ConnectionFailed();
                        }
                        catch
                        {
                            counterFails = true;
                            Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                        }
                    }
                    throw;
                }
            }
        }

        /// <summary>
        /// Realiza la ejecución del Lector de Datos.
        /// </summary>
        /// <param name="command">El <see cref="DbCommand"/> a ejecutar.</param>
        /// <param name="cmdBehavior">Uno de los valores de <see cref="CommandBehavior"/></param>
        /// <returns>Un <see cref="IDataReader"/> con los datos.</returns>
        protected IDataReader DoExecuteReader(DbCommand command, CommandBehavior cmdBehavior)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                IDataReader reader = command.ExecuteReader(cmdBehavior);
                if (!counterFails)
                {
                    try
                    {
                        InstrumentationProvider.CommandExecuted(startTime);
                    }
                    catch
                    {
                        counterFails = true;
                        Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                    }
                }
                return reader;
            }
            catch 
            {
                if (!counterFails)
                {
                    try
                    {
                        InstrumentationProvider.CommandFailed();
                    }
                    catch
                    {
                        counterFails = true;
                        Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                    }
                }
                
                throw;
            }
        }

        /// <summary>
        /// Ejecuta la consulta para el <paramref name="command"/>.
        /// </summary>
        /// <param name="command">El <see cref="DbCommand"/> que representa la consulta a ejecutar.</param>
        /// <returns>La cantidad de filas afectadas.</returns>
        protected int DoExecuteNonQuery(DbCommand command)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                int rowsAffected = command.ExecuteNonQuery();
                if (!counterFails)
                {
                    try
                    {
                        InstrumentationProvider.CommandExecuted(startTime);
                    }
                    catch
                    {
                        counterFails = true;
                        Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                    }
                }
                return rowsAffected;
            }
            catch 
            {
                if (!counterFails)
                {
                    try
                    {
                        InstrumentationProvider.CommandFailed();
                    }
                    catch
                    {
                        counterFails = true;
                        Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                    }
                }
                throw;
            }
        }

        private object DoExecuteScalar(DbCommand command)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                object returnValue = command.ExecuteScalar();

                if (!counterFails)
                {
                    try
                    {
                        InstrumentationProvider.CommandExecuted(startTime);
                    }
                    catch
                    {
                        counterFails = true;
                        Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                    }
                }

                return returnValue;
            }
            catch 
            {
                if (!counterFails)
                {
                    try
                    {
                        InstrumentationProvider.CommandFailed();
                    }
                    catch
                    {
                        counterFails = true;
                        Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                    }
                }
                throw;
            }
        }

        /// <summary>
        /// <para>Carga un <see cref="DataSet"/> dede el <see cref="DbCommand"/>.</para>
        /// </summary>
        /// <param name="command">
        /// <para>El  <see cref="DbCommand"/> a ejectuar para llenar el <see cref="DataSet"/>.</para>
        /// </param>
        /// <param name="dataSet">
        /// <para>El <see cref="DataSet"/> a llenar.</para>
        /// </param>
        /// <param name="tableName">
        /// <para>El de nombre de tabla para el <see cref="DataSet"/>.</para>
        /// </param>
        protected void LoadDataSet(DbCommand command, DataSet dataSet, string tableName)
        {
            LoadDataSet(command, dataSet, new string[] {tableName});
        }

        /// <summary>
        /// <para>Carga un <see cref="DataSet"/> dede el <see cref="DbCommand"/>, carga multiples tablas.</para>
        /// </summary>
        /// <param name="command">
        /// <para>El  <see cref="DbCommand"/> a ejectuar para llenar el <see cref="DataSet"/>.</para>
        /// </param>
        /// <param name="dataSet">
        /// <para>El <see cref="DataSet"/> a llenar.</para>
        /// </param>
        /// <param name="tableNames">
        /// <para>Un arreglo de nombres de tablas para el <see cref="DataSet"/>.</para>
        /// </param>
        protected void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames)
        {
            using (DbConnectionWrapper connection = CreateConnectionWrapper())
            {
                command.Connection = connection.Connection;
                DoLoadDataSet(command, dataSet, tableNames);
            }
        }

        private void DoLoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames)
        {
            if (tableNames == null) throw new ArgumentNullException("tableNames");
            if (tableNames.Length == 0)
            {
                throw new ArgumentException(Resources.ERROR_GENERICDATABASE_TABLENAMEARRAYEMPTY, "tableNames");
            }
            for (int i = 0; i < tableNames.Length; i++)
            {
                if (string.IsNullOrEmpty(tableNames[i]))
                    throw new ArgumentException(Resources.ERROR_GENERICDATABASE_TABLENAMENULLOREMPTY,
                                                string.Concat("tableNames[", i, "]"));
            }

            using (DbDataAdapter adapter = GetDataAdapter())
            {
                ((IDbDataAdapter) adapter).SelectCommand = command;

                try
                {
                    DateTime startTime = DateTime.Now;
                    string systemCreatedTableNameRoot = "Table";
                    for (int i = 0; i < tableNames.Length; i++)
                    {
                        string systemCreatedTableName = (i == 0)
                                                            ? systemCreatedTableNameRoot
                                                            : systemCreatedTableNameRoot + i;

                        adapter.TableMappings.Add(systemCreatedTableName, tableNames[i]);
                    }
                    adapter.Fill(dataSet);
                    if (!counterFails)
                    {
                        try
                        {
                            InstrumentationProvider.CommandExecuted(startTime);
                        }
                        catch
                        {
                            counterFails = true;
                            Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                        }
                    }
                    

                }
                                
                catch 
                {
                    if (!counterFails)
                    {
                        try
                        {
                            InstrumentationProvider.CommandFailed();
                        }
                        catch
                        {
                            counterFails = true;
                            Gobbi.CoreServices.Logging.Logger.WriteInformation("Error en performance Counter", "Error en performance Counter", "ApplicationsGeneral");
                        }
                    }
                    throw;
                }
            }
        }

        /// <summary>
        /// Obtiene un Adaptador de Datos para la base de datos.
        /// </summary>     
        /// <returns>un <see cref="DbDataAdapter"/>.</returns>
        /// <seealso cref="DbDataAdapter"/>
        protected DbDataAdapter GetDataAdapter()
        {
            DbDataAdapter adapter = dbProviderFactory.CreateDataAdapter();
            return adapter;
        }

        /// <summary>
        /// Obtiene información de parametros para el comando especificado en el <see cref="DbCommand"/> 
        /// completa la colección de parámetros. 
        /// </summary>
        /// <param name="discoveryCommand">El <see cref="DbCommand"/> a realizar el descubrimiento.</param>
        protected virtual void DeriveParameters(DbCommand discoveryCommand)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}