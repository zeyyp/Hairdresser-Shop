using Hairdresser.Context;
using Hairdresser.Entities;
using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        
        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult NewAppointment()
        {
            // Veritabanından hizmetleri çek
            var services = _context.services?.ToList() ?? new List<Service>();


            // Hizmetleri View'a gönder
            ViewBag.Services = services;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAppointment(AppointmentViewModel model)
        {

            if (ModelState.IsValid)
            {
                // serviceID'ye karşılık gelen hizmeti al
              //  var service = await _context.services.FindAsync(model.service);
               
                var service = await _context.services.FirstOrDefaultAsync(s => s.serviceID == int.Parse(model.service));
                if (service == null)
                {
                  //  ModelState.AddModelError("service", "Geçersiz hizmet seçimi.");
                    return View(model);
                }

                // Veritabanına kaydedilecek Appointment entity'sini oluştur
                var _appointmentDate = DateTime.SpecifyKind(model.date, DateTimeKind.Local).ToUniversalTime();
               

                var appointment = new Appointment
                {
                    customerName = model.adSoyad,
                    serviceID = int.Parse(model.service), // `service` string olduğu için dönüştürülmeli
                    serviceName = service.serviceName, // Burada dolduruluyor
                    appointmentDate = _appointmentDate,
                    appointmentHour = model.saat,
                    phone = model.PhoneNumber,
                    notes = model.Notes,

                    IsConfirmed = true,
                    personnelID = 1,
                    customerID = 2,

                };

                await _context.appointments.AddAsync(appointment);
                await _context.SaveChangesAsync();



                // Başarılı işlem sonrası yönlendirme
                return RedirectToAction("GirisYap", "Login");
            }
            else
            {
                // Eğer model geçerli değilse tekrar formu ve hizmetleri yükle
                ViewBag.Services = _context.services.ToList();
                return View(model);
            }

        }










    }
}
