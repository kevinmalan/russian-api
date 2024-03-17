using Core.Contracts;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public class DependencyInjection
    {
        public static void RegisterCoreServices(IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IAlphabetService, AlphabetService>();
        }
    }
}