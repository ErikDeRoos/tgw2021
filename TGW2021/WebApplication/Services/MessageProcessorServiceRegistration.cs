using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApplication.Services.Generic;

namespace WebApplication.Services
{
    public static class MessageProcessorServiceRegistration
    {
        public static void AddMessageProcessors(this IServiceCollection services)
        {
            var handlers = ProcessorRegistrationHelpers.GetHandlers<IMessageProcessor>(Assembly.GetExecutingAssembly())  // Get them from different assemblies, if needed
                .ToList();

            services.AddSingleton(new MessageProcessorHandlersWrapper(handlers));
            services.RegisterHandlersTransient<IMessageProcessor>(handlers);
        }
    }

    public class MessageProcessorHandlersWrapper
    {
        public MessageProcessorHandlersWrapper(List<(Type RequestType, Type HandleType)> allHanders)
        {
            AllHanders = allHanders;
        }

        public List<(Type RequestType, Type HandleType)> AllHanders { get; }
    }
}
