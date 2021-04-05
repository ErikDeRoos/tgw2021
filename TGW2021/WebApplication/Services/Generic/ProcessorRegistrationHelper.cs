using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WebApplication.Services.Generic
{
    public static class ProcessorRegistrationHelpers
    {
        public static IServiceCollection RegisterHandlersTransient<ForInterface>(this IServiceCollection services, Assembly assembly)
        {
            var requestHandler = typeof(ForInterface);

            var types = assembly.GetTypes();
            foreach (var handlerType in types.Where(t => requestHandler.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract))
            {
                services.AddTransient(handlerType);
            }

            return services;
        }

        public static IEnumerable<(Type RequestType, Type HandlerType)> GetHandlers<ForInterface>(Assembly assembly)
        {
            var types = assembly.GetTypes();
            var requestHandler = typeof(ForInterface);

            foreach (var handlerType in types.Where(t => requestHandler.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract))
            {
                var handlerInterface = handlerType.GetInterfaces().FirstOrDefault(i => i.IsGenericType);
                if (handlerInterface != null)
                {
                    var requestType = handlerInterface.GetGenericArguments().FirstOrDefault();
                    if (requestType != null)
                    {
                        yield return (requestType, handlerType);
                    }
                }
            }
        }

        public static IServiceCollection RegisterHandlersTransient<ForInterface>(this IServiceCollection services, IEnumerable<(Type RequestType, Type HandlerType)> handlers)
        {
            var requestHandler = typeof(ForInterface);

            foreach (var handler in handlers.Where(t => t.HandlerType != requestHandler).Select(h => h.HandlerType))
            {
                services.AddTransient(handler);
            }

            return services;
        }
    }
}
