using CoolEvents.Data;
using CoolEvents.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<CoolEventsDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CoolEventsDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(CoolEvents.Service.Mappings.MappingProfile));

CoolEvents.Service.ContainerRegistrations.ConfigureServices(builder.Services);
CoolEvents.Data.ContainerRegistrations.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

//////////////////////////////////////////////////////////////////////////////////
//
// to create initial migration use package manager console to run:
// add-migration -Name CreateCoolEventsSchemaMigration -Context CoolEventsDbContext -StartupProject CoolEvents.WebApp -Project CoolEvents.Data
//
// to apply migrations to a database
// dotnet ef database update --project CoolEvents.WebApp --context CoolEventsDbContext