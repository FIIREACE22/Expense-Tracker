using Microsoft.EntityFrameworkCore;
using tracker.Models;

var builder = WebApplication.CreateBuilder(args);
//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBPh8sVXJyS0d+X1RPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9nSXdScEVrWH1aeHBSQ2I=");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//DI
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
