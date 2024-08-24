using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;
using StoreApp.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

app.UseStaticFiles(); //wwwroot klasörü kullanılabilir hale geldi
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();//Bunların routing ile endpoints arasında bulunması gerekiyor !!ÖNEMLİ bilgi, microsoftun önerisi
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(name:"Admin",
        areaName:"Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

    endpoints.MapControllers();
}); 

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();
app.Run();
