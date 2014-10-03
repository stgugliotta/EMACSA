using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text;
using Gobbi.CoreServices.Logging.Configuration;
using Gobbi.CoreServices.Logging.Instrumentation;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Logging
{
    ///<summary>
    /// <para> Representa una clase de traza de performance. Para registrar los métodos y la duración.</para>
    ///</summary>
    /// <remarks>
    /// <para>El tiempo de vida de la instancia determina el principio y fin de la traza.
    /// El mensaje de la traza va a incluir, métodos siendo trazados, tiempo de inicio y final. </para>
    /// <para>Los mensajes de la traza serán grabados en la categoría con el mismo nombre de la operación de traza 
    /// realizada.
    /// Se debe configurar la operación para cada catergoría o de forma general.</para>
    /// </remarks>
    public class Tracer : IDisposable
    {


        private bool tracerDisposed = false;
        private bool tracingAvailable = false;

        ///<summary>
        /// <para>Incializa una instancia de la clase <see cref="Tracer"/> con el nombre de operación lógica dado. </para>
        ///</summary>
        /// <remarks>
        /// Si ya fue asignado un ID de actividad, se mantiene. De lo contrario, un nuevo ID de actividad será creado.
        /// </remarks>
        ///<param name="operation">
        /// <para> La operación para el <see cref="Tracer"/>.</para>
        /// <para> </para>
        /// </param>
        public Tracer(string operation)
        {
            if (CheckTracingAvailable())
            {
                if (GetActivityId().Equals(Guid.Empty))
                {
                    SetActivityId(Guid.NewGuid());
                }
                StartLogicalOperation(operation);

                WriteTraceStartMessage(Constants.TracerStartTitle);
            }
        }

        private static void StartLogicalOperation(string operation)
        {
            Trace.CorrelationManager.StartLogicalOperation(operation);
        }

        private void WriteTraceStartMessage(string entryTitle)
        {
            string methodName = GetExecutingMethodName();
            string message = string.Format(Resources.Culture, Resources.TRACER_STARTMESSAGEFORMAT, GetActivityId(), methodName);

            WriteTraceMessage(message, entryTitle, TraceEventType.Start);
        }

        private void WriteTraceMessage(string message, string entryTitle, TraceEventType eventType)
        {
            LogEntry log = new LogEntry();
            log.Message = message;
            log.Categories.Add(PeekLogicalOperationStack() as string);
            log.Priority = Constants.TracerPriority;
            log.EventId = Constants.TracerEventId;
            log.Severity = eventType;
            log.Title = entryTitle;
            Logger.Write(log);

        }

        private static object PeekLogicalOperationStack()
        {
            return Trace.CorrelationManager.LogicalOperationStack.Peek();
        }

        private string GetExecutingMethodName()
        {
            string result = "Unknown";
            StackTrace trace = new StackTrace(false);

            for (int index = 0; index < trace.FrameCount; ++index)
            {
                StackFrame frame = trace.GetFrame(index);
                MethodBase method = frame.GetMethod();
                if (method.DeclaringType != GetType())
                {
                    result = string.Concat(method.DeclaringType.FullName, ".", method.Name);
                    break;
                }
            }

            return result;
        }

        private static Guid GetActivityId()
        {
            return Trace.CorrelationManager.ActivityId;
        }

        private static Guid SetActivityId(Guid activityId)
        {
            return Trace.CorrelationManager.ActivityId = activityId;
        }

        ///<summary>
        /// <para> Indica si el tracing está habilitado.</para>
        ///</summary>
        ///<returns>True cuando está habilitado.</returns>
        public static bool IsTracingEnabled
        {
            get
            {
                try
                {
                    LoggingConfigurationSection lcs = LoggingConfigurationSection.GetInstance();
                    return lcs.TracingEnabled;
                }
                catch 
                {
                    InstrumentationProvider.ConfigurationFailure();
                    return false;
                }
            }
        }

        private bool CheckTracingAvailable()
        {
            tracingAvailable = IsTracingAvailable();

            return tracingAvailable;
        }

        ///<summary>
        /// <para> Produce el mensaje de cierre de la traza.</para>
        ///</summary>
        /// <remarks>Se dispara al finalizar la sección using.</remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Registra el final de la traza.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true"/> si está descargando; de lo contrario, <see langword="false"/>.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !tracerDisposed)
            {
                if (tracingAvailable)
                {
                    try
                    {
                        if (IsTracingEnabled) WriteTraceEndMessage(Constants.TracerEndTitle);
                    }
                    finally
                    {
                        try
                        {
                            StopLogicalOperation();
                        }
                        catch (SecurityException)
                        {
                        }
                    }
                }

                this.tracerDisposed = true;
            }
        }

        private static void StopLogicalOperation()
        {
            Trace.CorrelationManager.StopLogicalOperation();
        }

        private void WriteTraceEndMessage(string entryTitle)
        {

            string methodName = GetExecutingMethodName();
            string message = string.Format(Resources.Culture, Resources.TRACER_ENDMESSAGEFORMAT, GetActivityId(), methodName);
            WriteTraceMessage(message, entryTitle, TraceEventType.Stop);

        }

        internal static bool IsTracingAvailable()
        {
            bool tracingAvailable = false;

            try
            {
                tracingAvailable = SecurityManager.IsGranted(new SecurityPermission(SecurityPermissionFlag.UnmanagedCode));
            }
            catch (SecurityException)
            { }

            return tracingAvailable;
        }

        internal static void AddTracingCategories(LogEntry log)
        {
            if (Tracer.IsTracingAvailable())
                DoAddTracingCategories(log);
  
            
        }

        private static void DoAddTracingCategories(LogEntry log)
        {
            Stack logicalOperationStack = GetLogicalOperationStack();
            foreach (object logicalOperation in logicalOperationStack)
            {
                // ignore non string objects in the stack
                string category = logicalOperation as string;
                if (category != null)
                {
                    if (!log.Categories.Contains(category))
                    {
                        log.Categories.Add(category);
                    }
                }
            }
        }

        private static Stack GetLogicalOperationStack()
        {
            return Trace.CorrelationManager.LogicalOperationStack;
        }
    }
}
