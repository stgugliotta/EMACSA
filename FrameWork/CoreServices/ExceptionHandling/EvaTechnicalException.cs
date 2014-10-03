using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.ExceptionHandling
{
    ///<summary>
    /// <para>Es una excepción adaptada para que el programador agregue información de contexto,
    /// para arrojar en Excepciones técnicas.
    ///  </para>
    ///</summary>
    public class GobbiTechnicalException : EvaException
    {
       
        ///<summary>
        /// Inicializa la instancia.
        ///</summary>
        /// <param name="message">Mensaje descriptivo de la excepción.</param>
        /// <param name="context">Datos de contexto</param>
        ///<param name="innerException">Excepción  producida</param>        
        public GobbiTechnicalException(string message, IDictionary<string, object> context, Exception innerException)
            : base(message, context, innerException)
        {
            
        }

        /// <summary>
        /// Inicializa la instancia. 
        /// </summary>
        /// <param name="message">Mensaje descriptivo de la excepción.</param>
        ///<param name="innerException">Excepción  producida</param>  
        public GobbiTechnicalException(string message, Exception innerException)
            : base(message, null, innerException)
        {

        }
    }
}
