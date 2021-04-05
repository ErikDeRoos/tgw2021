using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebApplication.Services.Generic;

namespace WebApplication.Services
{
    public static class CQRSProcessorServiceRegistration
    {
        public static void AddProcessors(this IServiceCollection services)
        {
            services.RegisterHandlersTransient<ICQRSProcessor>(Assembly.GetExecutingAssembly()); // Get them from different assemblies, if needed
        }
    }
}
