using CoolEvents.Data.Repositories;
using CoolEvents.Data.Seed;
using Microsoft.Extensions.DependencyInjection;

namespace CoolEvents.Data;

public static class ContainerRegistrations
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
    }
}
