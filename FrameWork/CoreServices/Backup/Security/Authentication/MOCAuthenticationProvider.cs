using System;
using System.Collections.Generic;
using System.Text;
using ar.com.telecom.eva.CoreServices.Security.Authentication;
using ar.com.telecom.eva.CoreServices.Configuration;
using ar.com.telecom.eva.CoreServices.Security.Principal;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;
using System.DirectoryServices;

namespace ar.com.telecom.eva.CoreServices.Security.Authentication.Provider
{
    class MOCAuthenticationProvider : IAuthenticationProvider, IConfigurable
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


        /// <summary>
        ///  Servidor de aplcacion
        /// </summary>
        string IAuthenticationProvider.DefaultServer
        {
            get
            {
                throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
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
        public MOCAuthenticationProvider(string ProviderType) { }
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

        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity Validate(string user, string domain, string password)
        {
            EvaIdentity id = null;
            if (user == password)
            {
                id = new EvaIdentity(user, user);
            }
            return id;
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
    }

}

