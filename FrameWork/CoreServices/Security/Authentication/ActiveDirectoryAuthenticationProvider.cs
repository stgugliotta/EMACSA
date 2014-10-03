using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using Gobbi.CoreServices.Security.Authentication;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Security.Authentication.Provider
{
    class ActiveDirectoryAuthenticationProvider : IAuthenticationProvider, IConfigurable
    {

        #region Campos privados
        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        string providerName;
        /// <summary>
        /// Dominio por defecto
        /// </summary>
        string defaultDomain;
        #endregion Campos privados

        #region Getters & Setters
        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        string IAuthenticationProvider.Name
        {
            get
            {
                return providerName;
            }
        }

        /// <summary>
        /// Dominio por defecto
        /// </summary>
        string IAuthenticationProvider.DefaultDomain
        {
            get
            {
                return defaultDomain;
            }
        }
        AuthenticationTypes IAuthenticationProvider.AuthType
        {
            get
            {
                throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
            }
        }
        #endregion Getters & Setters

        #region Constructor
        /// <summary>
        /// Constructor por defecto para permitir ser instanciado dinamicamente
        /// </summary>
        /// <param name="ProviderType"></param>
        public ActiveDirectoryAuthenticationProvider(string ProviderType) { }
        #endregion Constructor

        #region Metodos de la interfaz



        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario. El proveedor utilizará el dominio por defecto que esté configurado"</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity IAuthenticationProvider.ValidateUser(string user, string password)
        {
            return this.Validate(user, this.defaultDomain, password);
        }

       
        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity IAuthenticationProvider.ValidateUser(string user, string domain, string password)
        {
            return this.Validate(user, domain, password);
        }


        GobbiIdentity IAuthenticationProvider.ValidateUserGobbi(string user, string password)
        {
            return this.ValidateGobbi(user, password);
        }

        GobbiIdentity ValidateGobbi(string user, string password)
        {

            return new GobbiIdentity();
        }
        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity Validate(string user, string domain, string password)
        {
            try
            {
                // Realiza un split del dominio para pasarlo a formato "DC=,..."
                string[] splittedDomain = domain.Split('.');
                StringBuilder sb = new StringBuilder("LDAP://DC=");
                sb.Append(splittedDomain[0]);
                for (int x = 1; x < splittedDomain.Length; x++)
                {
                    sb.Append(",DC=");
                    sb.Append(splittedDomain[x]);
                }
                // Obtiene la entrada autenticada
                DirectoryEntry entry = new DirectoryEntry(sb.ToString(), user, password);

                // Realiza el bind al objeto AdsObject nativo para asegurar la autenticación 			
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + user + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    // Obtiene del servicio de directorio la entrada completa

                    DirectoryEntry de = result.GetDirectoryEntry();
                    // Extrae los valores de la entrada de AD para construir el objeto EvaIdentity
                    string fullName = de.InvokeGet("FullName") as string;
                    // Extraer mas valores de AD de TECO para completar el Identity

                    // Construye y retorna el objeto EvaIdentity
                    EvaIdentity evaid = new EvaIdentity(user, fullName);
                    return evaid;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new GobbiTechnicalException("Error al autenticar usuario", e);
            }
        }


        ///<summary>
        /// Crea un nuevo usuario con los datos provistos. El proveedor utilizará el dominio por defecto que esté configurado. Este proveedor no implementa la funcionalidad de crear usuarios
        ///</summary>
        ///<param name="user">
        /// Nombre de usuario
        /// </param>
        ///<param name="password">
        /// Contraseña
        /// </param>
        ///<param name="email">
        ///E-mail del usuario
        /// </param>
        void IAuthenticationProvider.CreateUser(string user, string password, string email)
        {
            throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
        }

        /// <summary>
        /// Crea un nuevo usuario con los datos provistos. Este proveedor no implementa la funcionalidad de crear usuarios
        /// </summary>
        /// <param name="user">Nombre de usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <param name="email">E-mail del usuario</param>
        void IAuthenticationProvider.CreateUser(string user, string domain, string password, string email)
        {
            throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
        }

        ///<summary>
        /// Elimina un usario. El proveedor utilizará el dominio por defecto que esté configurado. Este proveedor no implementa la funcionalidad de eliminar usuarios
        ///</summary>
        ///<param name="user">
        /// Nombre de usuario a eliminar
        /// </param>
        void IAuthenticationProvider.DeleteUser(string user)
        {
            throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
        }

        /// <summary>
        /// Elimina un usario. Este proveedor no implementa la funcionalidad de eliminar usuarios
        /// </summary>
        /// <param name="user">Nombre de usuario a eliminar</param>
        /// <param name="domain">Dominio</param>
        void IAuthenticationProvider.DeleteUser(string user, string domain)
        {
            throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
        }
        #endregion Metodos de la interfaz

        #region IConfigurable Members

        void IConfigurable.Configure(System.Configuration.ConfigurationElement element)
        {
            AuthenticationManagerConfiguration config = element as AuthenticationManagerConfiguration;
            this.defaultDomain = config.DefaultDomain;
        }

        #endregion

        #region IAuthenticationProvider Members


        string IAuthenticationProvider.DefaultServer
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}






