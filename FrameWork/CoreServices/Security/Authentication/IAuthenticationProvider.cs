using System;
using System.Collections.Generic;
using System.Text;
using Gobbi.CoreServices.Security.Principal;
using System.DirectoryServices;


namespace Gobbi.CoreServices.Security
{
    ///<summary>
    /// <para> Interfaz con los métodos que implementa un proveedor de autenticación de la arquitectura Gobbi</para>
    ///</summary>
    public interface IAuthenticationProvider
    {

        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        string Name { get;}

        /// <summary>
        /// Dominio por defecto a autenticar
        /// </summary>
        string DefaultDomain { get;}

        /// <summary>
        ///  Servidor de aplcacion
        /// </summary>
        string DefaultServer { get;}

        /// <summary>
        /// Tipo de autenticacion
        /// </summary>
        AuthenticationTypes AuthType { get;}
        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario. El proveedor utilizará el dominio por defecto que esté configurado"</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity ValidateUser(string user, string password);
    
        GobbiIdentity ValidateUserGobbi(string user, string password);

        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity ValidateUser(string user, string domain, string password);
            
        ///<summary>
        /// Crea un nuevo usuario con los datos provistos. El proveedor utilizará el dominio por defecto que esté configurado
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
        void CreateUser(string user, string password, string email);


        /// <summary>
        /// Crea un nuevo usuario con los datos provistos
        /// </summary>
        /// <param name="user">Nombre de usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <param name="email">E-mail del usuario</param>
        void CreateUser(string user, string domain, string password, string email);


        ///<summary>
        /// Elimina un usario. El proveedor utilizará el dominio por defecto que esté configurado
        ///</summary>
        ///<param name="user">
        /// Nombre de usuario a eliminar
        /// </param>
        void DeleteUser(string user);


        /// <summary>
        /// Elimina un usario
        /// </summary>
        /// <param name="user">Nombre de usuario a eliminar</param>
        /// <param name="domain">Dominio</param>
        void DeleteUser(string user, string domain);
    }
}
