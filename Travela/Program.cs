using System.Configuration;
using Travela.Common;
using Travela.IService.Service;
using Travela.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Configuration
DapperConnection.isDevlopment = true;
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
DapperConnection.connectionString = config.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ISourceService, SourceService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IPackageService, PackageService>();

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