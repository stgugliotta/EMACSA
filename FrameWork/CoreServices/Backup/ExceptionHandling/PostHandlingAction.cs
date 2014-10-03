

namespace ar.com.telecom.eva.CoreServices.ExceptionHandling
{
    /// <summary>
    /// Determina que acción debe ocurrir luego de que la excepción es manejada. 
    /// </summary>
    public enum PostHandlingAction
    {
        /// <summary>
        /// Indica que no debe volver a arrojarse.
        /// </summary>
        None = 0,
        /// <summary>
        /// Nitifica al llamante que se recomienda volver a arrojarla.
        /// </summary>
        NotifyRethrow = 1,
        /// <summary>
        /// Arroja la excepción luego que la excepción fue manejada.
        /// </summary>
        ThrowNewException = 2
    }
}
