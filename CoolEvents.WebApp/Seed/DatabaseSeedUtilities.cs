using CoolEvents.Data.Seed;

namespace CoolEvents.WebApp.Seed;

public static class DatabaseSeedUtilities
{
    public static void SeedDatabase(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();

        var dbSeeder = serviceScope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();

        dbSeeder.SeedRoles("Admin", "User");
    }
}