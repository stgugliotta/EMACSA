using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Logging.Instrumentation
{
    internal static class InstrumentationProvider
    {
        static LoggingPerformanceCounterManager pcm;
        static InstrumentationProvider()
        {
            pcm = LoggingPerformanceCounterManager.Instance;
        }

        public static void TraceListenerEntryWritten()
        {
            pcm.IncrementTraceListenerEntryWrittenCounter();
        }

        public static void FailureLoggingError()
        {
            pcm.IncrementFailureLoggingErrorCounter();
        }

        public static void ConfigurationFailure()
        {
            pcm.IncrementConfigurationFailureCounter();

        }

        public static void LogEventRaised()
        {
            pcm.IncrementLogEventRaisedCounter();
        }

        public static void ThreadWriterStatusError()
        {
            pcm.IncrementThreadWriterStatusErrorCounter();
        }
    }
}
