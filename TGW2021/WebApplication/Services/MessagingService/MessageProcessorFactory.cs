using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Services.Generic;

namespace WebApplication.Services.MessagingService
{
    public class MessageProcessorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<Type, Type> _messageProcessors = new Dictionary<Type, Type>();

        public MessageProcessorFactory(IServiceProvider serviceProvider, MessageProcessorHandlersWrapper messageProcessorHandlersWrapper)
        {
            _serviceProvider = serviceProvider;
            foreach((Type RequestType, Type HandleType) in messageProcessorHandlersWrapper.AllHanders)
            {
                _messageProcessors.Add(RequestType, HandleType);
            }
        }

        public Func<Task> GetHandleMethod(IQueueMessage message)
        {
            try
            {
                var messageType = message.GetType();
                if (!_messageProcessors.TryGetValue(messageType, out var handlerServiceType))
                {
                    return null;
                }

                var scope = _serviceProvider.CreateScope();
                var handerService = scope.ServiceProvider.GetService(handlerServiceType);
                if (handerService == null)
                {
                    scope.Dispose();
                    return null;
                }

                var method = handerService.GetType().GetMethod("Handle");

                return async () =>
                {
                    var handleTask = method?.Invoke(handerService, new object[] { message });

                    if (handleTask is Task response)
                    {
                        await response;
                    }
                    scope.Dispose();
                };
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public void RegisterSet(Type messageType, Type hasProcessor)
        {
            _messageProcessors.Add(messageType, hasProcessor);
        }
    }
}
