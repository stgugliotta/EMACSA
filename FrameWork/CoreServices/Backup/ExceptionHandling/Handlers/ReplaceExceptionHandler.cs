using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ar.com.telecom.eva.CoreServices.Configuration;

namespace ar.com.telecom.eva.CoreServices.ExceptionHandling.Handlers
{
    
    /// <summary>
    /// Reemplaza la excepcion con otra nueva.
    /// </summary>
    public class ReplaceExceptionHandler : IExceptionHandler
    {
        private string exceptionMessage;
        private Type replaceExceptionType;

        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public ReplaceExceptionHandler()
        {

        }


        /// <summary>
        /// Método que deben implementar todos los manejadores de excepciones.
        /// Entrega la excepción para hacer las operaciones.
        /// </summary>
        /// <param name="ex">La <see cref="EvaException"/> a procesar.</param>
        /// <returns>Una <see cref="EvaException"/>.</returns>
        public EvaException HandleException(EvaException ex)
        {
            object[] parameters = {this.exceptionMessage, ex.Context};
            return (EvaException) Activator.CreateInstance(this.replaceExceptionType, parameters);
        }

        /// <summary>
        /// Entrega al objeto su elemento de configuración.
        /// </summary>
        /// <param name="element">Elemento de configuración para el objeto.</param>
        public void Configure(ConfigurationElement element)
        {
            DynamicConfigurationElement dce = (DynamicConfigurationElement)element;
            this.exceptionMessage = dce.GetPropertyValue("exceptionMessage");
            this.replaceExceptionType = Type.GetType(dce.GetPropertyValue("replaceExceptionType"));


        }
    }
}
