using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using ar.com.telecom.eva.CoreServices.Logging.Configuration;
using ar.com.telecom.eva.CoreServices.Logging.Filters;
using ar.com.telecom.eva.CoreServices.Logging.Instrumentation;
using ar.com.telecom.eva.CoreServices.Logging.Listeners;
using ThreadState = System.Threading.ThreadState;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Logging
{
    ///<summary>
    /// <para> Clase encargada de mandar a escribir las entredas de log a los almacenamientos.</para>
    ///</summary>
    public static class Logger
    {
        private static Thread writerThread = new Thread(WriterProc);
        private static AutoResetEvent writerWaitForJobEvent = new AutoResetEvent(false);
        private static Queue<LogEntry> logEntryQueue = new Queue<LogEntry>();
        private static object syncObject = new object();

        static Logger()
        {
            InitWriterThread();
        }

        ///<summary>
        /// <para> Escribe una nueva entrada de log.</para>
        ///</summary>
        ///<param name="log">Mensaje a registrar.</param>
        /// <example>Ejemplo de como usar el método Write
        /// <code>
        /// LogEntry log = new LogEntry();
        /// log.Category = "MiCategoria1";
        /// log.Message = "Cuerpo del mensaje.";
        /// log.Severity = TraceEventType.Error;
        /// log.Priority = 100;
        /// Logger.Write(log);
        /// </code>
        /// </example>
        public static void Write(LogEntry log)
        {
            if (log == null)
                 throw new EvaTechnicalException ("", new ArgumentNullException("log"));

            if (IsLoggingEnabled)
            {
                bool isUnstarted = (writerThread.ThreadState & ThreadState.Unstarted) == ThreadState.Unstarted;

                if (!isUnstarted && !writerThread.IsAlive)
                {
                    HandleFatalError(null);
                    return;
                }

                lock (syncObject)
                {
                    logEntryQueue.Enqueue(log);
                }
                InstrumentationProvider.LogEventRaised();

                writerWaitForJobEvent.Set();
            }
        }

        /// <summary>
        /// Genera una nueva entrada de información en el log, completando la prioridad con valores por defecto.
        /// </summary>
        /// <param name="title">Título de la entrada.</param>
        /// <param name="message">Mensaje de la entrada.</param>
        public static void WriteInformation(string title, string message)
        {
            WriteInformation(title, message, string.Empty);
        }

        /// <summary>
        /// Genera una nueva entrada de información en el log, completando la prioridad con valores por defecto.
        /// </summary>
        /// <param name="title">Título de la entrada.</param>
        /// <param name="message">Mensaje de la entrada.</param>
        /// <param name="category">Categoría a agregar.</param>
        public static void WriteInformation(string title, string message, string category)
        {
            LogEntry log = CreateLogEntry(title, message, category);
            log.Severity = TraceEventType.Information;
            log.Priority = Constants.InformationPriority;
            Write(log);
        }

        /// <summary>
        /// Genera una nueva entrada de advertencia en el log, completando la prioridad con valores por defecto.
        /// </summary>
        /// <param name="title">Título de la entrada.</param>
        /// <param name="message">Mensaje de la entrada.</param>
        public static void WriteWarning(string title, string message)
        {
            WriteWarning(title, message, string.Empty);
        }

        /// <summary>
        /// Genera una nueva entrada de advertencia. en el log, completando la prioridad con valores por defecto.
        /// </summary>
        /// <param name="title">Título de la entrada.</param>
        /// <param name="message">Mensaje de la entrada.</param>
        /// <param name="category">Categoría a agregar.</param>
        public static void WriteWarning(string title, string message, string category)
        {
            LogEntry log = CreateLogEntry(title, message, category);
            log.Severity = TraceEventType.Warning;
            log.Priority = Constants.WarningPriority;
            Write(log);
        }

        /// <summary>
        /// Genera una nueva entrada de error en el log, completando la prioridad con valores por defecto.
        /// </summary>
        /// <param name="title">Título de la entrada.</param>
        /// <param name="message">Mensaje de la entrada.</param>
        public static void WriteError(string title, string message)
        {
            WriteError(title, message, string.Empty);
        }

        /// <summary>
        /// Genera una nueva entrada de error en el log, completando la prioridad con valores por defecto.
        /// </summary>
        /// <param name="title">Título de la entrada.</param>
        /// <param name="message">Mensaje de la entrada.</param>
        /// <param name="category">Categoría a agregar.</param>
        public static void WriteError(string title, string message, string category)
        {
            LogEntry log = CreateLogEntry(title, message, category);
            log.Severity = TraceEventType.Error;
            log.Priority = Constants.ErrorPriority;
            Write(log);
        }

        private static void InitWriterThread()
        {
            writerThread.IsBackground = true;
            writerThread.Start();
        }

        private static LogEntry CreateLogEntry(string title, string message, string category)
        {
            if (string.IsNullOrEmpty(title))
                 throw new EvaTechnicalException ("", new   ArgumentNullException("title"));
            if (string.IsNullOrEmpty(message))
                 throw new EvaTechnicalException ("", new   ArgumentNullException("message"));
            LogEntry logEntry = new LogEntry();
            logEntry.Title = title;
            logEntry.Message = message;
            if (!string.IsNullOrEmpty(category))
                logEntry.Categories.Add(category);
            return logEntry;
        }

        private static void HandleFatalError(Exception ex)
        {
            try
            {
                string exDesc = string.Empty;
                if (ex != null)
                    exDesc = ex.Message;

                Debug.WriteLine(exDesc);
                EventLog.WriteEntry(Constants.ApplicationSource, Constants.FatalErrorDescription + exDesc,
                                    EventLogEntryType.Error);
            } catch { }
            
            try
            {
                InstrumentationProvider.ThreadWriterStatusError();
            }
            catch { }
        }

        private static void WriterProc()
        {
            while (true)
            {
                writerWaitForJobEvent.WaitOne();

                LogEntry[] logEntries = null;
                lock (syncObject)
                {
                    logEntries = logEntryQueue.ToArray();
                    logEntryQueue.Clear();
                }

                foreach (LogEntry logEntry in logEntries)
                {
                    try
                    {
                        DoWriteAsync(logEntry);
                    }
                    catch (Exception ex)
                    {
                        HandleFatalError(ex);
                    }
                }

            }
        }

        private static void DoWriteAsync(LogEntry log)
        {
            if (log.Categories.Count == 0)
                AddDefaultCategory(log);
            if (Tracer.IsTracingEnabled)
                Tracer.AddTracingCategories(log);
            if (FilterHelper.CheckFilters(log))
            {
                List<CustomTraceListener> listeners = LogSource.GetListeners(log.Categories, log.Severity);

                foreach (CustomTraceListener ctl in listeners)
                {
                    ctl.Write(log);
                }
            }
        }

        private static void AddDefaultCategory(LogEntry log)
        {
            try
            {

                LoggingConfigurationSection lcs = LoggingConfigurationSection.GetInstance();
                log.Categories.Add(lcs.DefaultCategory);
            }
            catch
            {
                InstrumentationProvider.ConfigurationFailure();
                throw;
            }
        }

        /// <summary>
        /// Indica su está activada la función de logging.
        /// </summary>
        public static bool IsLoggingEnabled
        {
            get
            {
                try
                {

                    LoggingConfigurationSection lcs = LoggingConfigurationSection.GetInstance();

                    return lcs.LoggingEnabled;
                }
                catch
                {
                    InstrumentationProvider.ConfigurationFailure();
                    throw;
                }
            }
        }
    }
}