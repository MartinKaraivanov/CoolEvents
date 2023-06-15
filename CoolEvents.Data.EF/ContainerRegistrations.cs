using CoolEvents.Data.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoolEvents.Data.EF;

public static class ContainerRegistrations
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
    }
}
