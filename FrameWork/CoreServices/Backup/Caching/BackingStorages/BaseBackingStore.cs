using System;
using System.Collections;

namespace ar.com.telecom.eva.CoreServices.Caching.BackingStorages
{
    /// <summary>
    /// Clase base para almacenamientos de respaldo. Contiene la implementación de políticas comunes y rutinas
    /// útiles para todos los los almacenamientos de respaldo.
    /// </summary>
    public abstract class BaseBackingStore : IBackingStore, IDisposable
    {
        /// <summary>
        /// Incializa una nueva instancia.
        /// </summary>
        public BaseBackingStore()
        {

        }

        /// <summary>
        /// Destructor para BaseBackingStore
        /// </summary>
        ~BaseBackingStore()
        {
            Dispose(false);
        }

        /// <summary>
        /// Esta implementación es suficiente para cualquier clase que no necesita comportamiento en su destructor.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Método usado para la descarga del objeto.
        /// </summary>
        /// <param name="disposing">True si es llamado durante la descarga. False si fue llamado desde el destructor.</param>
        protected virtual void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// Cantidad de objetos almacenados en el almacenamiento de resguardo.
        /// </summary>
        public abstract int Count { get; }

        /// <summary>
        /// Elimina un ítem con la clave dada del almacenamiento de respaldo.
        /// </summary>
        /// <param name="key">Clave a eliminar. No puede ser null.</param>
        public void Remove(string key)
        {
            Remove(key.GetHashCode());
        }

        /// <summary>
        /// Elimina un ítem con la clave de almacenamiento dada del almacenamiento de respaldo.
        /// </summary>
        /// <param name="storageKey">Clave única para el ítem de cache a ser eliminado</param>
        protected abstract void Remove(int storageKey);

        /// <summary>
        /// Actualiza la fecha y hora de último acceso para el ítem de cache.
        /// </summary>
        /// <param name="key">Clave a actualizar</param>
        /// <param name="timestamp">Hora a la cual el ítem fue actualizado.</param>
        public void UpdateLastAccessedTime(string key, DateTime timestamp)
        {
            UpdateLastAccessedTime(key.GetHashCode(), timestamp);
        }

        /// <summary>
        /// Actualiza la fecha y hora de último acceso para el ítem de cache referido por ésta clave de identificación única.
        /// </summary>
        /// <param name="storageKey">Clave única de almacenamiento para el ítem de cache.</param>
        /// <param name="timestamp">Hora a la cual el ítem fue actualizado.</param>
        protected abstract void UpdateLastAccessedTime(int storageKey, DateTime timestamp);

        /// <summary>
        /// Limpia todos los ítems de cache desde el almacenamiento de respaldo. 
        /// </summary>
        public abstract void Flush();

        /// <summary>
        /// <p>
        /// Este método es responsable de agregar a ítem de cache al almacenamiento de respaldo. Este metodo debe ser 
        /// exitoso aun cuando existe un ítem con la misma clave.
        /// </p> 
        /// </summary>
        /// <param name="newCacheItem">Item de cache a ser agregado.</param>
        public virtual void Add(CacheItem newCacheItem)
        {
            try
            {
                RemoveOldItem(newCacheItem.Key.GetHashCode());
                AddNewItem(newCacheItem.Key.GetHashCode(), newCacheItem);
            }
            catch
            {
                Remove(newCacheItem.Key.GetHashCode());
                throw;
            }
        }

        /// <summary>
        /// Carga todos los ítems de cache del mecanismo de persistencia implementado.
        /// </summary>
        /// <returns>Hashtable conteniento todos los ítems de cache existentes.</returns>
        public virtual Hashtable Load()
        {
            return LoadDataFromStore();
        }

        /// <summary>
        /// Elimina un ítem existente almacenado en un medio de persistencia almacenado con la misma clave que un nuevo ítem.
        /// </summary>
        /// <param name="storageKey">Clave única para el ítem de cache.</param>
        protected abstract void RemoveOldItem(int storageKey);

        /// <summary>
        /// Agrega un nuevo ítem al almacenamiento de persistenca.
        /// </summary>
        /// <param name="storageKey">Clave única para el ítem de cache.</param>
        /// <param name="newItem">Item a ser agregado al cache. debería no ser null.</param>
        protected abstract void AddNewItem(int storageKey, CacheItem newItem);

        /// <summary>
        /// Responsable por cargar los ítems del medio de persistencia. Este método no debería hacer
        /// filtro para eliminar ítems expirados.
        /// </summary>
        /// <returns>Hashtable de todos los ítems cargados del medio de persistencia.</returns>
        protected abstract Hashtable LoadDataFromStore();
    }
}
