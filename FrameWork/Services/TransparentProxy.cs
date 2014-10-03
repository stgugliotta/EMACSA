
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;

namespace Gobbi.services
{
    /// <summary>
    /// Provee la funcionalidad basica para proxies transparentes.
    /// Esta clase que se construye dentro de la arquitectura dinámicamente y permite hacer 
    /// intercepciones a las llamadas realizando operaciones antes, o después de la invocación 
    /// a los servicios. Técnicamente el objetivo de este patrón de arquitectura es conservar 
    /// el control de las ejecuciones en un modelo inproc.
    /// </summary>
    /// <typeparam name="T">Interface que tiene que instanciar el transparent proxy</typeparam>
    internal class TransparentProxy<T> : RealProxy where T:class
    {

        #region Private Vars

        /// <summary>
        /// Nombre del servicio al que se invocara en la intercepcion
        /// </summary>
        private string _serviceName;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase TransparentProxy.
        /// </summary>
        /// <example>
        /// <remarks>En el siguiente ejemplo se instancia un transparent proxy a una clase que implementa la interfaz IExample.</remarks>
        /// <code>
        ///  TransparentProxy&lt;IExample&gt; transparentProxy = new TransparentProxy&lt;T&gt;(ExampleTypeName);
        ///  instance = transparentProxy.CreateProxy() as IExample;
        /// </code>
        /// </example>
        /// <param name="serviceName">Nombre del servicio al que se invocara en la intercepcion.</param>
        public TransparentProxy( string serviceName ) : base( typeof( T ) )
        {                    
            _serviceName = serviceName;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Crea un transparent proxy al servicio.
        /// </summary>
        /// <returns>Devuelve un transparent proxy del servicio requerido</returns>
        public T CreateProxy( )
        {
            return base.GetTransparentProxy( ) as T;
        }

        /// <summary>
        /// Permite realizar la intercepcion en donde se invoca al servicio real, sobrecargando este metodo.
        /// </summary>
        /// <param name="msg">El mensaje con los datos del metodo a interceptar.</param>
        /// <returns>Un mensaje con la respuesta de la intercepcion.</returns>
        public override IMessage Invoke(IMessage msg)
        {
            //Console.WriteLine("Invocación interceptada");
            object result = null;

            //Si es un llamada a un metodo lo intercepto 
            IMethodCallMessage call = msg as IMethodCallMessage;

            if (call != null)
            {
                try
                {
                    Type t = Type.GetType(_serviceName);
                    object instance = Activator.CreateInstance(t, true);
                    MethodInfo theMethod = t.GetMethod(call.MethodName, (Type[])call.MethodSignature);
                    result = theMethod.Invoke(instance, call.Args);
                }
                catch (TargetInvocationException e)
                {
                    throw e.InnerException;
                }
            }

            //Devuelvo el resultado de la invocacion del servicio 
            return new ReturnMessage(result, null, 0, null, call);
        } 

    
        #endregion
 
    }
}
