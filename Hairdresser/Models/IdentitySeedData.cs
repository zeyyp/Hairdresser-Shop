using Hairdresser.Context;
using Hairdresser.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = await userManager.FindByNameAsync(adminUser);

            if (user == null)
            {
                user = new AppUser
                {
                    UserName = adminUser,
                    Email = "g221210069@sakarya.edu.tr",
                    PhoneNumber ="5554443322",
                    adSoyad="Zeynep Uysal"
                };

               var result= await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                {
                    // Hata yönetimi
                    throw new Exception("Kullanıcı oluşturulamadı: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }

            }

        }
    }
}
