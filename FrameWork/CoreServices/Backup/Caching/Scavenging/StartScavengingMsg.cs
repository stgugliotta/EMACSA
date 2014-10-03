using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Caching.Scavenging
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
