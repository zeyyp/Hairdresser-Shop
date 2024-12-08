//using Microsoft.EntityFrameworkCore;

//namespace Hairdresser.Context
//{

//    public static class SeedData
//    {
//        public static void Initialize(IApplicationBuilder app)
//        {
//            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<ApplicationDbContext>();

//            if (context != null)
//            {
//                if(context.Database.GetPendingMigrations().Any())
//                {
//                    context.Database.Migrate();
//                }

//                // Eğer veriler zaten varsa, eklemeyin
//                if (!context.salons.Any())
//                {
//                    context.salons.AddRange(
//                        new Entities.Salon
//                        {
//                            salonName = "HairDresser",
//                            salonType = "Kuaför",
//                            workingHours = "09:00-18:00",
//                            salonAddress = "Istanbul, Turkey"
//                        }

//                    );
//                }

//                if (!context.expertises.Any())
//                {
//                    context.expertises.AddRange(
//                        new Entities.Expertise { expertiseName = "Saç Kesimi" }

//                    );
//                }

//                if (!context.personnels.Any())
//                {
//                    context.personnels.AddRange(
//                        new Entities.Personnel
//                        {
//                            personnelName = "Seda Yıldız",
//                            personnelPassword = "password123",
//                            personnelEmail = "seda@example.com",
//                            availableHours = "09:00-12:00",
//                            salonID = 1, // Yaratılmış bir salon ID'si
//                            ExpertiseID = 1 // Yaratılmış bir uzmanlık alanı ID'si
//                        }

//                    );
//                }

//                if (!context.services.Any())
//                {
//                    context.services.AddRange(
//                        new Entities.Service
//                        {
//                            serviceName = "Saç Kesimi",
//                            serviceDuration = 30,
//                            servicePrice = 100,
//                            salonID = 1
//                        }
//                    );
//                }

//                // Değişiklikleri kaydet
//                context.SaveChanges();
//            }
//        }
//    }
//}
