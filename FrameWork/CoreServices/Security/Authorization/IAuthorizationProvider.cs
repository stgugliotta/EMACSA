using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Gobbi.CoreServices.Security.Authorization
{          
    ///<summary>
    /// <para> Interface con los métodos que implementa un proveedor de Autorización de la arquitectura EVA2. </para>
    ///</summary>
    public interface IAuthorizationProvider
    {
        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        string Name { get;}

        ///<summary>
        /// <para> Verifica los permisos de un <see cref="IPrincipal"/> para acceder a unos recursos <paramref name="resources"/> </para>
        ///</summary>
        ///<param name="principal">Objeto Principal que representa al usuario que intenta acceder a los recursos</param>
        ///<param name="resources">Recursos pedidos.</param>
        ///<returns>Recursos autorizados</returns>
        EvaResource[] Authorize(IPrincipal principal, string[] resourceID);

        /// <summary>
        /// <para> Verifica los permisos de un <see cref="IPrincipal"/> para acceder a unos recursos <paramref name="resources"/> </para>
        /// </summary>
        ///<param name="principal">Objeto Principal que representa al usuario que intenta acceder a los recursos</param>
        ///<param name="resources">Recursos pedidos.</param>
        /// <param name="levels">Niveles en el arbol de recursos</param>
        ///<returns>Recursos autorizados</returns>
        EvaResource[] Authorize(IPrincipal principal, string[] resourceID, int levels);

        /// <summary>
        /// <para> Verifica los permisos de un <see cref="IPrincipal"/> para acceder a unos recursos <paramref name="resources"/> </para>
        /// </summary>
        ///<param name="principal">Objeto Principal que representa al usuario que intenta acceder a los recursos</param>
        ///<param name="resources">Recurso pedido</param>
        ///<returns>Recurso autorizado</returns>
        EvaResource GetAuthorizedResource(IPrincipal principal, string resource);


        /// <summary>
        /// <para> Verifica los permisos de un <see cref="IPrincipal"/> para acceder a unos recursos <paramref name="resources"/> </para>
        /// </summary>
        ///<param name="principal">Objeto Principal que representa al usuario que intenta acceder a los recursos</param>
        ///<param name="resources">Recurso pedido</param>
        ///<returns>Recurso autorizado</returns>
        List<GobbiResource> GetAllAuthorizedResource(IPrincipal principal);



    }
}
