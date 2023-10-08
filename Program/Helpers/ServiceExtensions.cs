using Microsoft.Extensions.DependencyInjection;

namespace Program.Helpers
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
