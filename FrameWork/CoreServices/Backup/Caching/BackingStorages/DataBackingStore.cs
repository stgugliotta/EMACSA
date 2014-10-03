using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using ar.com.telecom.eva.CoreServices.Caching.CacheItemExpirations;
using ar.com.telecom.eva.CoreServices.Caching.CacheManagers;
using ar.com.telecom.eva.CoreServices.Properties;

namespace ar.com.telecom.eva.CoreServices.Caching.BackingStorages
{
    /// <summary>
    /// Implementación de un BackingSotre para permitir a los ítems de cache ser almacenados a través del bloque de Data.
    /// Es usado por <see cref="SQLCacheManager"/>.
    /// </summary>
    public class DataBackingStore : BaseBackingStore
    {
        private Data.Database database;
        private string partitionName;

        /// <summary>
        /// Inicializa el almacenamiento de resguardo en la base de datos.
        /// </summary>
        /// <param name="database">Database para usar para persistencia.</param>
        /// <param name="databasePartitionName">Nombre de la partición en la base de datos.</param>
        internal DataBackingStore(Data.Database database, string databasePartitionName)
        {
            this.database = database;
            this.partitionName = databasePartitionName;
        }

        /// <summary>
        /// Retorna el número de ítems almacenados en base de datos.
        /// </summary>
        public override int Count
        {
            get
            {
                DbCommand query = database.GetCommand("EvaCaching_GetItemCount");
                database.AddInParameter(query, "@partitionName", DbType.String, partitionName);
                return (int)database.ExecuteScalar(query);
            }
        }

        /// <summary>
        /// Elimina el ítem indentificado por la clave de la base de datos.
        /// </summary>
        /// <param name="storageKey">Clave de CacheItem a eliminar.</param>
        protected override void Remove(int storageKey)
        {
            DbCommand deleteCommand = database.GetCommand("EvaCaching_RemoveItem");
            database.AddInParameter(deleteCommand, "@partitionName", DbType.String, partitionName);
            database.AddInParameter(deleteCommand, "@storageKey", DbType.Int32, storageKey);

            database.ExecuteNonQuery(deleteCommand);
        }

        /// <summary>
        /// Actualiza la fecha y hora de último acceso para el CacheItem identificado por la clave.
        /// </summary>
        /// <param name="storageKey">Clave única del ítem a actualizar.</param>
        /// <param name="lastAccessedTime">Nueva fecha y hora para el ítem actualizado.</param>
        protected override void UpdateLastAccessedTime(int storageKey, DateTime lastAccessedTime)
        {
            DbCommand updateCommand = database.GetCommand("EvaCaching_UpdateLastAccessedTime");
            database.AddInParameter(updateCommand, "@partitionName", DbType.String, partitionName);
            database.AddInParameter(updateCommand, "@lastAccessedTime", DbType.DateTime, lastAccessedTime);
            database.AddInParameter(updateCommand, "@storageKey", DbType.Int32, storageKey);

            database.ExecuteNonQuery(updateCommand);
        }

        /// <summary>
        /// Limpia todos los CacheItems de la base de datos. Si se produce algún error la base de datos queda sin modificar.
        /// </summary>
        public override void Flush()
        {
            DbCommand flushCommand = database.GetCommand("EvaCaching_Flush");
            database.AddInParameter(flushCommand, "@partitionName", DbType.String, partitionName);
            database.ExecuteNonQuery(flushCommand);
        }

        /// <summary>
        /// Carga los datos de la base de datos.
        /// </summary>
        /// <returns>Hastable sin filtrar de los ítems de cahce cargadados.</returns>
        protected override Hashtable LoadDataFromStore()
        {
            DbCommand loadDataCommand = database.GetCommand("EvaCaching_LoadItems");
            database.AddInParameter(loadDataCommand, "@partitionName", DbType.String, partitionName);
            DataSet dataToLoad = database.ExecuteDataSet(loadDataCommand);

            Hashtable dataToReturn = new Hashtable();
            foreach (DataRow row in dataToLoad.Tables[0].Rows)
            {
                CacheItem cacheItem = CreateCacheItem(row);
                dataToReturn.Add(cacheItem.Key, cacheItem);
            }
            return dataToReturn;
        }

        private CacheItem CreateCacheItem(DataRow dataToLoad)
        {
            string key = (string)dataToLoad["Key"];
            object value = DeserializeValue(dataToLoad);

            CacheItemPriority scavengingPriority = (CacheItemPriority)dataToLoad["ScavengingPriority"];
            object expirations = SerializationUtility.ToObject((byte[])dataToLoad["Expirations"]);
            object timestamp = (DateTime)dataToLoad["LastAccessedTime"];

            CacheItem cacheItem = new CacheItem((DateTime)timestamp, key, value, scavengingPriority, (ICacheItemExpiration[])expirations);

            return cacheItem;
        }

        /// <summary>
        /// Elimina un ítem existente almacenado en la base de datos con la misma clave que un nuevo ítem.
        /// </summary>
        /// <param name="storageKey">Item a eliminar del cache.</param>
        protected override void RemoveOldItem(int storageKey)
        {
            Remove(storageKey);
        }

        /// <summary>
        /// Agrega un nuevo ítem la base de datos.
        /// </summary>
        /// <param name="storageKey">Clave única del ítem a actualizar.</param>
        /// <param name="newItem">Item a ser agregado en la base de datos. No debería ser nulo.</param>
        protected override void AddNewItem(int storageKey, CacheItem newItem)
        {
            string key = newItem.Key;
            byte[] valueBytes = SerializationUtility.ToBytes(newItem.Value);

            byte[] expirationBytes = SerializationUtility.ToBytes(newItem.GetExpirations());
            CacheItemPriority scavengingPriority = newItem.ScavengingPriority;
            DateTime lastAccessedTime = newItem.LastAccessedTime;

            DbCommand insertCommand = database.GetCommand("EvaCaching_AddItem");
            database.AddInParameter(insertCommand, "@partitionName", DbType.String, partitionName);
            database.AddInParameter(insertCommand, "@storageKey", DbType.Int32, storageKey);
            database.AddInParameter(insertCommand, "@key", DbType.String, key);
            database.AddInParameter(insertCommand, "@value", DbType.Binary, valueBytes);
            database.AddInParameter(insertCommand, "@expirations", DbType.Binary, expirationBytes);
            database.AddInParameter(insertCommand, "@scavengingPriority", DbType.Int32, scavengingPriority);
            database.AddInParameter(insertCommand, "@lastAccessedTime", DbType.DateTime, lastAccessedTime);

            database.ExecuteNonQuery(insertCommand);
        }

        private object DeserializeValue(DataRow dataToLoad)
        {
            object value = dataToLoad["Value"];

            if (value == DBNull.Value)
            {
                value = null;
            }
            else
            {
                byte[] valueBytes = (byte[])value;
                value = SerializationUtility.ToObject(valueBytes);
            }
            return value;
        }

    }
}
