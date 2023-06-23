using CoolEvents.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoolEvents.Data;

public static class ContainerRegistrations
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
    }
}
