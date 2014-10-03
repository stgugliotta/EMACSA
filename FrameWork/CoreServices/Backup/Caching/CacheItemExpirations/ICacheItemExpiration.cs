using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Caching.CacheItemExpirations
{
    /// <summary>
    /// Es el contrato que deben cumplir los elementos de expiration. 
    /// <remarks> Permite agregar nuevos tipos de expiraciones de ítems.</remarks>
    /// </summary>
    public interface ICacheItemExpiration
    {
        /// <summary>
        /// Especifíca si el ítem ha expirado o no.
        /// </summary>
        /// <returns>Devuelte true si el item ha expirado, de lo contrario false.</returns>
        bool HasExpired();

        /// <summary>
        /// Llamado para notificar que el CacheItem al cual ésta expiración pertenece ha sido usado por el usuario.
        /// </summary>
        void Notify();

        /// <summary>
        /// Llamado para dar la oportunidad de inicializar a la expiración a partir de la información contenida en el CacheItem.
        /// </summary>
        /// <param name="owningCacheItem">CacheItem dueña del objeto de expiración actual.</param>
        void Initialize(CacheItem owningCacheItem);
    }
}
