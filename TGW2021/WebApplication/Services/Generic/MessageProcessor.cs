using System.Threading.Tasks;

namespace WebApplication.Services.Generic
{
    public abstract class MessageProcessor<T1> : IMessageProcessor, IMessageProcessor<T1> where T1 : IQueueMessage
    {
        public abstract Task Handle(T1 message);
    }
}
