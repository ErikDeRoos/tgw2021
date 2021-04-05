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
    }
}
