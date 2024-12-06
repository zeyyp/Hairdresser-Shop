//using Hairdresser.Context;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//namespace Hairdresser.Models
//{
//    public static class IdentitySeedData
//    {
//        private const string adminUser = "Admin";
//        private const string adminPassword = "Admin_123";

//        public static async void IdentityTestUser(IApplicationBuilder app)
//        {
//            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityDbContext>();

//            if (context.Database.GetPendingMigrations().Any())
//            {
//                context.Database.Migrate();
//            }

//            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < UserManager<IdentityUser>>();
        
//            var user = await userManager.FindByNameAsync(adminUser);

//            if (user == null)
//            {
//                user = new IdentityUser
//                {
//                    UserName = adminUser,
//                    Email = "g221210069@sakarya.edu.tr"
//                };

//                await userManager.CreateAsync(user, adminPassword);
//            }
        
//        }
//    }
//}
