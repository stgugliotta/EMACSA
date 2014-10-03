using System;
using System.Collections.Generic;
using System.Text;

namespace Gobbi.CoreServices.Caching.Scavenging
{
    internal class StartScavengingMsg : IQueueMessage
    {
        private BackgroundScavenger callback;

        public StartScavengingMsg(BackgroundScavenger callback)
        {
            this.callback = callback;
        }

        public void Run()
        {
            callback.DoStartScavenging();
        }
    }
}
