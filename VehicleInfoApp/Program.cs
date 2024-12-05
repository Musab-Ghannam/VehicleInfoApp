using VehicleInfoApp.Abstraction;
using VehicleInfoApp.IntegrationUtilities;
using VehicleInfoApp.Models;
using VehicleService.Abstraction;
using VehicleService.DTO;
using VehicleService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<VehicleSetting>(builder.Configuration.GetSection("VehicleSetting"));
builder.Services.AddScoped<IVehicleService, VehicleServices>();
builder.Services.AddHttpClient();
//builder.Services.AddScoped(typeof(IHttpclientCallers<>), typeof(HttpClientCallers<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
