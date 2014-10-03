using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Caching.Scavenging
{
    internal interface IQueueMessage
    {
        void Run();
    }
}
