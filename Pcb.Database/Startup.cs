using Pcb.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pcb.Database
{
    public static class Startup
    {
        public static void AddPcbDatabase(this IServiceCollection services, IConfiguration config)
        {
            var connString = config.GetConnectionString("Default");

            services.AddDbContext<PcbDbContext>(item => item.UseSqlServer(connString));
        }
    }
}
