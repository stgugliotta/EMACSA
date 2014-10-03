using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ar.com.telecom.eva.CoreServices.Logging.Listeners;

namespace ar.com.telecom.eva.CoreServices.Logging.Filters
{
    class FilterHelper
    {
        internal static bool CheckFilters(LogEntry log)
        {
            bool hasAdvancedSuccessfully = false;
            System.Collections.Generic.List<CustomTraceListener> listeners =
                new System.Collections.Generic.List<CustomTraceListener>();
            IEnumerator iEnumerator = FilterFactory.Filters.GetEnumerator();
            do
            {
                hasAdvancedSuccessfully = iEnumerator.MoveNext();
            } while (hasAdvancedSuccessfully && ((ILogFilter)iEnumerator.Current).Filter(log));
            return !hasAdvancedSuccessfully;
        }
    }
}
