using Microsoft.Extensions.DependencyInjection;

namespace CoolEvents.Service;

public static class ContainerRegistrations
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IEventsService, EventsService>();
        services.AddTransient<IUsersService, UsersService>();
        services.AddTransient<ITicketsService, TicketsService>();
    }
}
