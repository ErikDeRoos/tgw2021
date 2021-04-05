using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services.Generic;

namespace WebApplication.Services.MessagingService
{
    /// <summary>
    /// Normally you would want this to connect to a service bus or queue.
    /// (Current implementation lives as long as a webservice: that can be killed any time)
    /// </summary>
    public class MessagingService
    {
        private readonly MessageQueue _messageQueue;

        public MessagingService (
            MessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public void SendMessage(IQueueMessage message)
        {
            _messageQueue.Enqueue(message);
        }
    }
}
