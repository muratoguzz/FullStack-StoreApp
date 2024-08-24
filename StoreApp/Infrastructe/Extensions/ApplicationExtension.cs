using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>(); //İhtiyaç duyulan servis uygulama üzerinden alındı

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate(); //dotnet ef database update yazmamıza gerek kalmadı
            }
        }

        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            // UserManager, kullanıcıları kaydetmek için
            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            // RoleManager, kullanıcılara rol vermek için
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "muratouz95@gmail.com",
                    PhoneNumber = "5062048309",
                    UserName = adminUser,
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                    throw new Exception("Admin user could not been created.");

                var roleResult = await userManager.AddToRolesAsync(user, //bütün roller admin kullanıcısına aktarıldı, roller config dosyasından geldi
                    roleManager
                        .Roles
                        .Select(r => r.Name)
                        .ToList()
                );

                if (!roleResult.Succeeded)
                    throw new Exception("System have problems");
            }
        }
    }
}