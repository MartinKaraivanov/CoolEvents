using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace CoolEvents.Data.EF.SqlServer.Design;

// to create initial migration use package manager console to run:
// add-migration -Name CreateCoolEventsSchemaMigration -Context CoolEventsDbContext -StartupProject CoolEvents.Data.EF.SqlServer.Design -Project CoolEvents.Data.EF.SqlServer
//
// to apply migrations to a database
// dotnet ef database update --project CoolEvents.WebApp --context CoolEventsDbContext

public class ApplicationDbContextDesignTimeFactory : IDesignTimeDbContextFactory<CoolEventsDbContext>
{
    public CoolEventsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CoolEventsDbContext>();
        optionsBuilder.UseSqlServer(
            "dummy connection string",
            x => x.MigrationsAssembly(typeof(CoolEvents.Data.EF.SqlServer.DummyClass).Assembly.GetName().Name));

        return new CoolEventsDbContext(optionsBuilder.Options);
    }
}