using EF.Contracts;
using EF.QueryServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF
{
    public class DependencyInjection
    {
        public static void RegisterEFServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetSection("SQLServer:Connectionstring").Value), ServiceLifetime.Transient);
            services.AddTransient<IAlphabetQueryService, AlphabetQueryService>();
        }
    }
}