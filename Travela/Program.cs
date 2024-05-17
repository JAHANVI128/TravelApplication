using System.Configuration;
using Travela.Common;
using Travela.IService.Service;
using Travela.Services.Service;
IConfigurationRoot Configuration;

var builder = WebApplication.CreateBuilder(args);

DapperConnection.isDevlopment = true;
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
Configuration = config.Build();
DapperConnection.connectionString = Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ISourceService, SourceService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
