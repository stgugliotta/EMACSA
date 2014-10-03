using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using System.Transactions;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Data
{
    ///<summary>
    /// Representa una base de datos y las operaciones que se pueden hacer contra ella.
    ///</summary>
    /// <example>
    /// Genera una instancia de la base de datos predeterminada y retorna un <see cref="DataSet"/>
    /// con el resultado de la ejecución.
    /// <code>
    ///public DataSet ObtenerDS()
    ///{
    ///    Database db = DatabaseFactory.CreateDatabase();
    ///    DbCommand command = db.GetCommand("GetVendors");
    ///    return db.ExecuteDataSet(command);
    ///}
    /// </code>
    /// </example>
    /// <example>
    /// Ejecuta la actualización de los cambios realizados en una <see cref="DataTable"/> 
    ///  del <see cref="DataSet"/>.
    /// <code>
    ///         public int ActualizarDB(DataSet ds)
    ///{
    ///    Database db = DatabaseFactory.CreateDatabase();
    ///    
    ///    DbCommand cmdInsert = db.GetCommand("InsVendor");
    ///    db.AddInParameter(cmdInsert, "Name", DbType.String, "Name");
    ///    db.AddInParameter(cmdInsert, "email", DbType.String, "email");
    ///
    ///    DbCommand cmdUpdate = db.GetCommand("UpdVendor");
    ///    db.AddInParameter(cmdUpdate, "IdVendor", DbType.Int32, "IdClient");
    ///    db.AddInParameter(cmdUpdate, "Name", DbType.String, "Name");
    ///    db.AddInParameter(cmdUpdate, "email", DbType.String, "email");
    ///
    ///    DbCommand cmdDelete = db.GetCommand("DelVendor");
    ///    db.AddInParameter(cmdDelete, "IdVendor", DbType.Int32, "IdClient");
    ///
    ///    return db.UpdateDataSet(ds, ds.Tables[0].TableName, cmdInsert, cmdUpdate, cmdDelete);
    ///}
    /// </code>
    /// </example>

    public abstract class Database
    {
        private string databaseName;

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="databaseName">Nombre de la base de datos en la configuración.</param>
        protected Database(string databaseName)
        {
            if (string.IsNullOrEmpty(databaseName))
                throw new EvaTechnicalException ("", new  ArgumentNullException());
            //guardar database name
            this.databaseName = databaseName;
        }

        /// <summary>
        /// El nombre de la base de datos en la configuración.
        /// </summary>
        public string DatabaseName
        {
            get { return databaseName; }
        }

        ///<summary>
        /// Genera una conexión a la base de datos para poder realizar operaciones transaccionales 
        /// controladas por el usuario.
        ///</summary>
        ///<returns>
        /// Devuelve una conexión a la base de datos
        /// </returns>
        public abstract DbConnection CreateConnection();

        /// <summary>
        /// <para>Crea un <see cref="DbCommand"/> para un procedimiento almacenado 
        /// u otro comando del proveedor.</para>
        /// </summary>
        ///<param name="procedureName">
        /// Nombre del procedimiento a ejecutar.
        /// </param>
        ///<returns>El <see cref="DbCommand"/> para la ejecución.</returns>
        public abstract DbCommand GetCommand(string procedureName);

        ///<summary>
        /// <para>Ejecuta el <paramref name="command"/> y devuelve el resultado en un nuevo <see cref="DataSet"/>.</para>
        ///</summary>
        ///<param name="command">
        /// <para>El <see cref="DbCommand"/> a ejecutar.</para>
        /// </param>
        ///<returns>
        /// Un <see cref="DataSet"/> con los resultados de el <paramref name="command"/>.
        /// </returns>
        public abstract DataSet ExecuteDataSet(DbCommand command);

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
        public abstract object ExecuteScalar(DbCommand command);

        ///<summary>
        /// <para>Ejecuta el <paramref name="command"/> y devuelve el numero de filas afectadas.</para>
        ///</summary>
        ///<param name="command">
        /// <para>El <see cref="DbCommand"/> a ejecutar.</para>
        /// </param>
        ///<returns>
        /// <para>El número de filas afectadas</para>
        /// </returns>
        public abstract int ExecuteNonQuery(DbCommand command);


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
        public abstract IDataReader ExecuteReader(DbCommand command);

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
        public abstract int UpdateDataSet(DataSet dataSet, string tableName,
                                          DbCommand insertCommand, DbCommand updateCommand,
                                          DbCommand deleteCommand);


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
        public abstract void AddOutParameter(DbCommand command, string name, DbType dbType, int size);

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
        public abstract void AddInParameter(DbCommand command, string name, DbType dbType, object value);

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
        public abstract void AddInParameter(DbCommand command, string name, DbType dbType);

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
        public abstract void AddInParameterFromSourceColumn(DbCommand command, string name, DbType dbType, string sourceColumn);
        
        ///<summary>
        /// <para> Asigna un valor a un parámetro</para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> con el parámetro.</para>
        /// </param>
        ///<param name="parameterName">
        /// <para> El nombre del parámetro</para>
        /// </param>
        ///<param name="value">
        /// <para>El valor del parámetro.</para>
        /// </param>
        public virtual void SetParameterValue(DbCommand command, string parameterName, object value)
        {
            command.Parameters[BuildParameterName(parameterName)].Value = (value == null) ? DBNull.Value : value;
        }

        ///<summary>
        /// <para> Obtiene el valor de un parámetro.</para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> que contiene el parámetro.</para>
        /// </param>
        ///<param name="name">
        /// <para> El nombre del parámetro.</para>
        /// </param>
        ///<returns>
        /// <para>El valor del parámetro.</para>
        /// </returns>
        public virtual object GetParameterValue(DbCommand command, string name)
        {
            return command.Parameters[BuildParameterName(name)].Value;
        }


        ///<summary>
        /// <para>Descubre los parámetros para un <see cref="DbCommand"/>.</para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> a descubrir los parámetros.</para>
        /// </param>
        public abstract void DiscoverParameters(DbCommand command);


        /// <summary>
        /// Agrega un nuevo objeto <see cref="DbParameter"/> al objeto <paramref name="command"/> dado.
        /// </summary>
        /// <param name="command">El <see cref="DbCommand"/> a agregar el parametro.</param>
        /// <param name="name"><para>El nombre del parámetro.</para></param>
        /// <param name="dbType"><para>Un de los valores de  <see cref="DbType"/>.</para></param>
        /// <param name="size"><para>El tamaño máximo de los datos contenidos en la columna.</para></param>
        /// <param name="direction"><para>Uno de los valores de <see cref="ParameterDirection"/>.</para></param>
        /// <param name="nullable"><para>Indica si el parámetro acepta valores <see langword="null"/>.</para></param>
        /// <param name="precision"><para>La máxima cantidad de número de digitos utilizado para representar el <paramref name="value"/>.</para></param>
        /// <param name="scale"><para>El número de cifras con que se representa el <paramref name="value"/>.</para></param>
        /// <param name="sourceColumn"><para>El nombre de la columna mapeada al <see cref="DataSet"/> utilizada para resolver el <paramref name="value"/>.</para></param>
        /// <param name="sourceVersion"><para>Uno de los valores de <see cref="DataRowVersion"/>.</para></param>
        /// <param name="value"><para>El valor del parámetro.</para></param>       
        public abstract void AddParameter(DbCommand command, string name, DbType dbType, int size,
                                         ParameterDirection direction, bool nullable, byte precision, byte scale,
                                         string sourceColumn, DataRowVersion sourceVersion, object value);

        /// <summary>
        /// Genera el nombre de parámetro para el proveedor de base de datos actual.
        /// </summary>
        /// <param name="name">El nombre del parámetro.</param>
        /// <returns>El nombre del parámetro adaptado para la base de datos actual.</returns>
        public virtual string BuildParameterName(string name)
        {
            return name;
        }

    }
}
