using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.ExceptionHandling.Instrumentation
{
    internal static class InstrumentationProvider
    {
        static ExceptionHandlingPerformanceCounterManager pcm;
        static InstrumentationProvider()
        {
            pcm = ExceptionHandlingPerformanceCounterManager.Instance;
            
        }

        public static void ExceptionHandled()
        {
            pcm.IncrementExceptionHandledCounter();
        }


        public static void ExceptionHandlerExecuted()
        {
            pcm.IncrementExceptionHandlerExecutedCounter();
        }


        public static void ExceptionHandlingErrorOccurredInvalidConfiguration()
        {
            pcm.IncrementExceptionHandlingErrorOccurredInvalidConfigurationCounter();
        }
    }
}
