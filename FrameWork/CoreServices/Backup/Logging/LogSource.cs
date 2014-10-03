using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ar.com.telecom.eva.CoreServices.Logging.Listeners;

namespace ar.com.telecom.eva.CoreServices.Logging
{
    /// <summary>
    /// Asocia las categorías con los TraceListener indicados.
    /// </summary>
    public class LogSource
    {
        private string categoryName;
        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        public string CategoryName
        {
            get { return categoryName; }

        }
        private IList<CustomTraceListener> listeners;

        /// <summary>
        /// TraceListeners asociados.
        /// </summary>
        public IList<CustomTraceListener> Listeners
        {
            get { return listeners; }

        }
        private SourceLevels level;

        /// <summary>
        /// Uno de los valores de <see cref="SourceLevels"/>.
        /// </summary>
        public SourceLevels Level
        {
            get { return level; }

        }

        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        /// <param name="categoryName">Nombre de la categoría.</param>
        /// <param name="listeners">TraceListeners asociados.</param>
        /// <param name="level">/// Uno de los valores de <see cref="SourceLevels"/>.</param>
        public LogSource(string categoryName, IList<CustomTraceListener> listeners, SourceLevels level)
        {
            this.categoryName = categoryName;
            this.listeners = listeners;
            this.level = level;
        }


        internal static List<CustomTraceListener> GetListeners(ICollection<string> categories, TraceEventType eventType)
        {
            List<CustomTraceListener> customTraceListeners = new List<CustomTraceListener>();
            foreach(string category in categories)
            {
                if (LogSourceFactory.LogSources.ContainsKey(category))
                {
                    LogSource logSource = LogSourceFactory.LogSources[category];
                    if (ShouldTrace(logSource.level, eventType))
                    {
                        foreach (CustomTraceListener ctl in logSource.Listeners)
                        {
                            if (!customTraceListeners.Contains(ctl))
                            {
                                customTraceListeners.Add(ctl);
                            }
                        }
                    }
                }
                
            }
            return customTraceListeners;
        }

        private static bool ShouldTrace(SourceLevels level, TraceEventType eventType)
        {
            return ((((TraceEventType)level) & eventType) != (TraceEventType)0);
        }
    }
}
