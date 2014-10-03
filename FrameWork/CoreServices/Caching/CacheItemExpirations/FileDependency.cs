using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Caching.CacheItemExpirations
{
    /// <summary>
    /// Esta clase verifica cambios para una dependencia a archivo.
    /// </summary>
    [Serializable]
    [ComVisible(false)]
    public class FileDependency : ICacheItemExpiration
    {
        private readonly string dependencyFileName;

        private DateTime lastModifiedTime;

        /// <summary>
        ///	Inicializa la clase con el nombre del archivo.
        /// </summary>
        /// <param name="fullFileName">
        ///	Indica el nombre del archivo.
        /// </param>
        public FileDependency(string fullFileName)
        {
            if (string.IsNullOrEmpty(fullFileName))
            {
                throw new GobbiTechnicalException("", new  ArgumentException(Resources.ERROR_NULLFILENAME, "fullFileName"));
            }

            dependencyFileName = Path.GetFullPath(fullFileName);
            EnsureTargetFileAccessible();

            if (!File.Exists(dependencyFileName))
            {
                throw new GobbiTechnicalException("", new  ArgumentException(string.Format(Resources.ERROR_INVALIDFILENAME, fullFileName), "fullFileName"));
            }

            this.lastModifiedTime = File.GetLastWriteTime(fullFileName);
        }

        /// <summary>
        /// Obtiene el nombre del archivo dependiente.
        /// </summary>
        /// <value>
        /// El nombre del archivo dependiente.
        /// </value>
        public string FileName
        {
            get { return dependencyFileName; }
        }

        /// <summary>
        /// Obtiene la fecha de última modificación del archivo.
        /// </summary>
        /// <value>
        /// la fecha de última modificación del archivo.
        /// </value>
        public DateTime LastModifiedTime
        {
            get { return lastModifiedTime; }
        }

        /// <summary>
        /// Especifica si el ítem ha expirado o no.
        /// </summary>
        /// <returns>Devuelve true si el ítem ha expiredo, de lo contrario false.</returns>
        public bool HasExpired()
        {
            EnsureTargetFileAccessible();

            if (File.Exists(this.dependencyFileName) == false)
            {
                return true;
            }

            DateTime currentModifiedTime = File.GetLastWriteTime(dependencyFileName);
            if (DateTime.Compare(lastModifiedTime, currentModifiedTime) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Notifica que el ítem fue usado recientemente.
        /// </summary>
        public void Notify()
        {
        }

        /// <summary>
        /// No usado.
        /// </summary>
        /// <param name="owningCacheItem">No usado.</param>
        public void Initialize(CacheItem owningCacheItem)
        {
        }

        private void EnsureTargetFileAccessible()
        {
            // keep from changing during demand
            string file = dependencyFileName;
            FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Read, file);
            permission.Demand();
        }
    }
}
