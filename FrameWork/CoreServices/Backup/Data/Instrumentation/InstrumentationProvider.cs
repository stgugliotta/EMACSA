using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Data.Instrumentation
{
    internal static class InstrumentationProvider
    {
        static DataPerformanceCountersManager pcm;
        static InstrumentationProvider()
        {
            pcm = DataPerformanceCountersManager.Instance;
                
        }
        public static void CommandExecuted(DateTime startTime)
        {
            TimeSpan ts = DateTime.Now.Subtract(startTime);
            pcm.IncrementCommandExecutedCounter(ts.Ticks);
        }

        public static void CommandFailed()
        {
            pcm.IncrementCommandFailedCounter();
        }

        public static void ConnectionOpened()
        {
            pcm.IncrementConnectionOpenedCounter();
        }

        public static void ConnectionFailed()
        {
            pcm.IncrementConnectionFailedCounter();
        }
    }
}
