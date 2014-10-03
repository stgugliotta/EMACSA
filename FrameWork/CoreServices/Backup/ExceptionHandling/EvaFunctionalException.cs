using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.ExceptionHandling
{
    ///<summary>
    /// <para>Es una excepción adaptada para que el programador agregue información de contexto y un mensaje,
    /// para utilizar arrojando excepciones de negocio. </para>
    ///</summary>
    public class EvaFunctionalException : EvaException
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
        public EvaFunctionalException(string message, IDictionary<string, object> context)
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
        public EvaFunctionalException(string message)
            :
    base(message, null, null)
        {

        }
    }
}
