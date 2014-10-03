using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.Caching.BackingStorages
{
    /// <summary>
    /// <P>Esta interface define el contrato que deben implementar todos los almacenamientos de respaldo.
    /// Cada implementación debe interactuar con un mecanismo de persistencia para almacenar y recuparar CacheItems.
    /// La implementación debe funcionar de forma transaccional de forma que si se produce un error los datos siempre
    /// queden consistentes.</P>
    /// </summary>
    public interface IBackingStore : IDisposable
    {
        /// <summary>
        /// Número de objetos almacenados en el almacenamiento de resguardo.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// <p>
        /// Este método es responsable de agregar CacheItem al BackingStorage. Este método debe ser existoso inclusive si un
        /// ítem con la misma clave ya existe. Si el método falla no debe agregarse el ítem.
        /// </p>
        /// </summary>
        /// <param name="newCacheItem">CacheItem a ser agregado</param>
        void Add(CacheItem newCacheItem);

        /// <summary>
        /// Elimina un ítem con la clave dada del almacenamiento de resguardo.
        /// </summary>
        /// <param name="key">Clave a eliminar. No puede ser null.</param>
        void Remove(string key);

        /// <summary>
        /// Actualiza la fecha y hora del último acceso para el ítem de cache.
        /// </summary>
        /// <param name="key">Clave a actualizar.</param>
        /// <param name="timestamp">Fecha y hora a la cual el ítem es actualizdo.</param>
        void UpdateLastAccessedTime(string key, DateTime timestamp);

        /// <summary>
        /// Limpia todos los CacheItems del almacenamiento de resguardo.
        /// </summary>
        void Flush();

        /// <summary>
        /// Carga todos los CacheItems desde el almacenamiento de resguardo.
        /// </summary>
        /// <returns>Hashtable conteniendo todos los CacheItems existentes.</returns>
        Hashtable Load();
    }
}
