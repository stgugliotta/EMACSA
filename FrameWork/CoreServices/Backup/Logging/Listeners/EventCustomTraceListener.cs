using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using ar.com.telecom.eva.CoreServices.Configuration;
using ar.com.telecom.eva.CoreServices.Logging.Instrumentation;
using ar.com.telecom.eva.CoreServices.Properties;

namespace ar.com.telecom.eva.CoreServices.Logging.Listeners
{
    class EventCustomTraceListener : CustomTraceListener
    {
        private string sourceName = string.Empty;
        public string SourceName
        {
            get { return sourceName; }
        }

        public EventCustomTraceListener(string name)
            :base(name)
        {
        }

        public override void Write(LogEntry log)
        {
            try
            {
                string source = this.SourceName;
                if (string.IsNullOrEmpty(source))
                    source = log.ProcessName;
                EventLog.WriteEntry(source, CreateMessage(log), DefineEntryType(log), log.EventId);
                InstrumentationProvider.TraceListenerEntryWritten();
            }
            catch 
            {
                InstrumentationProvider.FailureLoggingError();
                throw;
            }
        }

        private static EventLogEntryType DefineEntryType(LogEntry log)
        {
           switch (log.Severity)
           {
               case TraceEventType.Error:
                   return EventLogEntryType.Error;
               case TraceEventType.Warning:
                   return EventLogEntryType.Warning;
               default:
                   return EventLogEntryType.Information;
           }
                   
        }

        private static string CreateMessage(LogEntry log)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Resources.LOG_ACTIVITYID + Constants.Separator + log.ActivityId);
            if (!string.IsNullOrEmpty(log.AppDomainName))
            sb.AppendLine(Resources.LOG_APPDOMAIN + Constants.Separator + log.AppDomainName);
            sb.AppendLine(Resources.LOG_CATEGORIES + Constants.Separator + String.Join(",",log.Categories.ToArray()));
            sb.AppendLine(Resources.LOG_ERRORMESSAGES + Constants.Separator + log.ErrorMessages);
            sb.AppendLine(Resources.LOG_EVENTID + Constants.Separator + log.EventId);
            if (!string.IsNullOrEmpty(log.MachineName))
            sb.AppendLine(Resources.LOG_MACHINENAME + Constants.Separator + log.MachineName);
        if (!string.IsNullOrEmpty(log.ManagedThreadName))
            sb.AppendLine(Resources.LOG_MANAGERTHREADNAME + Constants.Separator + log.ManagedThreadName);
            sb.AppendLine(Resources.LOG_MESSAGE + Constants.Separator + log.Message);
            sb.AppendLine(Resources.LOG_PRIORITY + Constants.Separator + log.Priority);
            if (!string.IsNullOrEmpty(log.ProcessId))
            sb.AppendLine(Resources.LOG_PROCESSID + Constants.Separator + log.ProcessId);
            if (log.RelatedActivityId.HasValue)
            sb.AppendLine(Resources.LOG_RELATEDACTIVITYID + Constants.Separator + log.RelatedActivityId);
            sb.AppendLine(Resources.LOG_SEVERITY + Constants.Separator + log.Severity);
            sb.AppendLine(Resources.LOG_TIMESTAMP + Constants.Separator + log.TimeStampString);
            sb.AppendLine(Resources.LOG_TITLE + Constants.Separator + log.Title);
            if (!string.IsNullOrEmpty(log.Win32ThreadId))
            sb.AppendLine(Resources.LOG_WIN32THREADID + Constants.Separator + log.Win32ThreadId);
        if (log.ExtendedProperties.Count > 0)
            sb.AppendLine(Resources.LOG_EXTENDEDPROPERTIES + Constants.Separator + SerializeExtendedProperties(log));

            return sb.ToString();
    }

        static string SerializeExtendedProperties(LogEntry log)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableDictionary<string, object>));

            serializer.Serialize(writer, log.ExtendedProperties);

            return writer.GetStringBuilder().ToString();
        }

        public override void Configure(System.Configuration.ConfigurationElement element)
        {
            DynamicConfigurationElement dce = (DynamicConfigurationElement)element;
            this.sourceName = dce.GetPropertyValue("sourceName");
        }
    }
}
