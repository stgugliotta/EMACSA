using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Data.Databases
{
    /// <summary>
    ///  <para> Este proveedor es una implementación de la clase Database para el Host.</para>
    /// </summary>
    public class HostDatabase : Database
    {
        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        ///  <param name="databaseName">Nombre de la base de datos en la configuración.</param>
        public HostDatabase(string databaseName)
            :base(databaseName)
        {
            
        }

        ///<summary>
        /// Genera una conexión a la base de datos para poder realizar operaciones transaccionales 
        /// controladas por el usuario.
        ///</summary>
        ///<returns>
        /// Devuelve una conexión a la base de datos
        /// </returns>
        public override DbConnection CreateConnection()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        public override object ExecuteScalar(DbCommand command)
        {
            throw new NotImplementedException();
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
        /// <seealso cref="IDbCommand.ExecuteScalar"/>
        public override int ExecuteNonQuery(DbCommand command)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        /// <remarks> La ejecución se hace en una transacción propia.</remarks>
        public override int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand,
                                          DbCommand updateCommand, DbCommand deleteCommand)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        /// <para> El valor del parametro</para>
        /// </param>
        public override void AddInParameter(DbCommand command, string name, DbType dbType, object value)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        ///<summary>
        /// <para>Descubre los parámetros para un <see cref="DbCommand"/>.</para>
        ///</summary>
        ///<param name="command">
        /// <para> El <see cref="DbCommand"/> a descubrir los parámetros.</para>
        /// </param>
        public override void DiscoverParameters(DbCommand command)
        {
            throw new NotImplementedException();
        }

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
        public override void AddParameter(DbCommand command, string name, DbType dbType, int size,
                                          ParameterDirection direction, bool nullable, byte precision, byte scale,
                                          string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            throw new NotImplementedException();
        }
    }
}
