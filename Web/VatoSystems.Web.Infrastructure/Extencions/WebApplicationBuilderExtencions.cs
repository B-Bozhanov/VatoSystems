namespace VatoSystems.Web.Infrastructure.Extencions
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    using static VatoSystems.Common.Exceptions.Services;

    public static class WebApplicationBuilderExtencions
    {
        public static void AutoRegisterServices(this IServiceCollection services, Type[] serviceTypes)
        {
            foreach (var serviceType in serviceTypes)
            {
                var serviceAssembly = Assembly.GetAssembly(serviceType);

                if (serviceAssembly == null)
                {
                    throw new InvalidOperationException(InvalidService);
                }

                var currentServiceTypes = serviceAssembly
                     .GetTypes()
                     .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                     .ToArray();

                foreach (var implementationType in currentServiceTypes)
                {
                    var interfaceType = implementationType.GetInterface($"I{implementationType.Name}");

                    if (interfaceType == null)
                    {
                        throw new InvalidOperationException(InvalidInterface);
                    }

                    services.AddScoped(interfaceType, implementationType);
                }
            }
        }
    }
}
