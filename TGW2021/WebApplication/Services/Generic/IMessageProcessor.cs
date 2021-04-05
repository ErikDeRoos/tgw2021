using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services.Generic
{
    public interface IMessageProcessor
    {
    }

    public interface IMessageProcessor<T1> : IMessageProcessor where T1 : IQueueMessage
    {
        Task Handle(T1 message);
    }
}
