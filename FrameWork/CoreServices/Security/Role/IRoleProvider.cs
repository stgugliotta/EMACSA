using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace Gobbi.CoreServices.Security.Role
{
    /// <summary>
    /// Interface con los que implementa un proveedor de roles.
    /// </summary>
    public interface IRoleProvider
    {

        /// <summary>
        /// Busca los los roles que tiene el usuario.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <returns>Una lista de roles en los cuales está incluido el usuario</returns>
        string[] GetRoles(IPrincipal principal);


        /// <summary>
        /// Busca los los roles que tiene el usuario.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="module">Nombre del modulo / aplicacion</param>
        /// <returns>Una lista de roles en los cuales está incluido el usuario</returns>
        string[] GetRoles(IPrincipal principal, string module);


        /// <summary>
        /// Verifica que el usuario esté tenga alguno de los roles
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="roles">Roles a verificar</param>
        /// <returns>True si se encuentra en algún rol</returns>
        bool IsInRole(IPrincipal principal, string[] roles);


        /// <summary>
        /// Verifica que el usuario esté tenga alguno de los roles
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="roles">Roles a verificar</param>
        /// <param name="module">Nombre del modulo/aplicación</param>
        /// <returns>True si se encuentra en algún rol</returns>
        bool IsInRole(IPrincipal principal, string[] roles, string module);


        /// <summary>
        /// Busca los roles que tiene el usuario dentro un subgrupo.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="roles">Roles a verificar</param>
        /// <returns>Una lista de roles en los cuales está incluido el usuario</returns>
        string[] CheckRoles(IPrincipal principal, string[] roles);
 

        /// <summary>
        /// Busca los roles que tiene el usuario dentro un subgrupo.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="roles">Roles a verificar</param>
        /// <param name="module">Nombre del modulo/aplicación</param>
        /// <returns>Una lista de roles en los cuales está incluido el usuario</returns>
        string[] CheckRoles(IPrincipal principal, string[] roles, string module);

        
        /*
         * Se agrega un nuevo método que permita discernir si el usuario consultado
         * pertenece al ROL que esta marcado como Administrador Funcional del modulo
         * que se indica.
         * 
         * Autor: Cristian A. Ponce <caponce@ta.telecom.com.ar
         * Fecha: 07/10/2008
         */
        /// <summary>
        /// Verifica si el usuario en cuestion pertenece al rol de Administrador Funcional
        /// del modulo indicado.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="module">Nombre del modulo/aplicación</param>
        /// <returns>True si verdaderamente el usuario tiene el rol.</returns>
        bool IsInRoleFunctionalAdmin(IPrincipal principal, string module);
    }
}
