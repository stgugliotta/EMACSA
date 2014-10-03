using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.Caching.Scavenging
{
    internal interface IQueueMessage
    {
        void Run();
    }
}
