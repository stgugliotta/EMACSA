using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.ExceptionHandling
{
    ///<summary>
    /// <para>Es una excepción adaptada para que el programador agregue información de contexto </para>
    ///</summary>
    public abstract class EvaException : Exception
    {
        private IDictionary<string, object> context;
        private Guid instanceId ;
        /// <summary>
        /// Contructor para los difentes tipos de excepciones. 
        /// </summary>
        /// <param name="message">Mensaje descriptivo de la falla.</param>
        /// <param name="context">Items con información adicional de la falla.</param>
        /// <param name="innerException">Excepción original contenida en la excepción del banco.</param>
        protected EvaException(string message, IDictionary<string, object> context, Exception innerException) :
            base(message, innerException)
        {
            EvaException e;
            if (innerException != null && (e = innerException as EvaException) != null && e.HandlingInstanceID != Guid.Empty)
                this.instanceId = e.instanceId;
            else
                this.instanceId = Guid.NewGuid();
            if (context != null)
                this.context = context;
            else
                this.context = new Dictionary<string, object>();
        }

        /// <summary>
        ///  ID de instancia de manejo de la excepción.
        /// </summary>
        public Guid HandlingInstanceID
        {
            get
            {
                return this.instanceId;
            }
        }

        /// <summary>
        /// Contiene información de contexto adicional de la falla que agrega el programador.
        /// </summary>
        public IDictionary<string, object> Context
        {
            get { return context; }
        }
    }
}
