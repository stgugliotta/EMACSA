using System;
using System.Collections.Generic;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Caching.Scavenging
{
    internal class ExpirationTimeoutExpiredMsg : IQueueMessage
    {
        private BackgroundScavenger callback;

        public ExpirationTimeoutExpiredMsg(BackgroundScavenger callback)
        {
            this.callback = callback;
        }

        public void Run()
        {
            callback.DoExpirationTimeoutExpired();
        }
    }
}
