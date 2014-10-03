using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using ar.com.telecom.eva.CoreServices.Security.Principal;
using System.Collections.Specialized;

namespace ar.com.telecom.eva.CoreServices.Context
{
    /// <summary>
    /// Clase que permite transmitir información fuera de banda entre la aplicación cliente y los servicios
    /// Esta información se pierde luego de cada requerimiento completado que realiza el cliente
    /// </summary>
    public class EvaContext
    {
        /// <summary>
        /// Objeto de sincronización de acceso al callcontext 
        /// </summary>
        private static object sync = new object();
                
        /// <summary>
        /// Agrega información fuera en el contexto de ejecución que puede ser obtenida por los servicios
        /// </summary>
        /// <param name="key">Clave del objeto</param>
        /// <param name="data">Objeto a transmitir en el contexto de ejecución</param>
        public static void SetData(string key, object data)
        {
            lock (sync)
            {
                HybridDictionary dict;
                if (CallContext.GetData("ContextData") == null)
                {
                    dict = new HybridDictionary();
                    CallContext.SetData("ContextData", dict);
                }
                else
                {
                    dict = (HybridDictionary)CallContext.GetData("ContextData");
                }
                dict.Add(key, data);
            }
        }

        /// <summary>
        /// Agrega el principal en el contexto de ejecución que puede ser obtenida por los servicios
        /// </summary>
        /// <param name="data">Objeto principal a transmitir en el contexto de ejecución</param>
        public static void SetPrincipal(EvaPrincipal principal)
        {
            CallContext.SetData("EvaPrincipal", principal);
        }

        /// <summary>
        /// Obtiene información del contexto de ejecución
        /// </summary>
        /// <param name="key">Clave del objeto</param>
        /// <returns>Objeto almacenado en el contexto de ejecución</returns>
        public static object GetData(string key)
        {
            HybridDictionary dict;
            object reValue = null;
            if (CallContext.GetData("ContextData") != null)
            {
                dict = (HybridDictionary)CallContext.GetData("ContextData");
                reValue = dict[key];
            }
            return reValue;
        }

        /// <summary>
        /// Obtiene el principal del contexto de ejecución
        /// </summary>
        /// <returns>Objeto Principal del usuario que está ejecutando el servicio</returns>
        public static EvaPrincipal GetPrincipal()
        {
            object oPrincipal = CallContext.GetData( "EvaPrincipal" );
            EvaPrincipal principal = null;
            if (oPrincipal != null)
            {
                principal = (EvaPrincipal)oPrincipal;
            }
            return principal;
        }

        /// <summary>
        ///Borra el contenido del contexto de ejecución
        /// </summary>
        public static void Cleardata()
        {
            lock (sync)
            {
                CallContext.SetData("EvaPrincipal", null);
                CallContext.SetData("ContextData", null);
            }
        }
    }
}
