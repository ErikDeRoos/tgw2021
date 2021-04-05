using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services.Generic;

namespace WebApplication.Services.MessagingService
{
    /// <summary>
    /// Singleton reference to simulate persistent message queue
    /// </summary>
    public class MessageQueue
    {
        private ConcurrentQueue<IQueueMessage> _queue = new ConcurrentQueue<IQueueMessage>();

        public void Enqueue(IQueueMessage message)
        {
            _queue.Enqueue(message);
        }

        public bool TryDequeue(out IQueueMessage message)
        {
            return _queue.TryDequeue(out message);
        }
    }
}
