using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.ExceptionHandling
{
    ///<summary>
    /// <para>Es una excepción adaptada para que el programador agregue información de contexto y un mensaje,
    /// para utilizar arrojando excepciones de negocio. </para>
    ///</summary>
    public class GobbiFunctionalException : EvaException
    {
        ///<summary>
        /// <para>Inicializa la excepción.</para>
        ///</summary>
        ///<param name="message">
        /// <para>Mensaje descriptivo de la excepción.</para>
        /// </param>
        ///<param name="context">
        /// <para>Datos de contexto</para>
        /// </param>
        public GobbiFunctionalException(string message, IDictionary<string, object> context)
            :
            base( message, context, null)
        {
            
        }

        /// <summary>
        /// Inicializa la excepción.
        /// </summary>
        /// <param name="message">
        /// <para>Mensaje descriptivo de la excepción.</para>
        /// </param>
        public GobbiFunctionalException(string message)
            :
    base(message, null, null)
        {

        }
    }
}
