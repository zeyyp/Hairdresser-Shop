using Hairdresser.Context;
using Hairdresser.Entities;
using Hairdresser.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Hairdresser.Controllers
{
    
    [Authorize]
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
            var personels = _context.personnels?.ToList() ?? new List<Personnel>();


            // Hizmetleri View'a gönder
            ViewBag.Services = services;
            ViewBag.Personels = personels;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAppointment(AppointmentViewModel model)
        {

            if (ModelState.IsValid)
            {
                var service = await _context.services.FirstOrDefaultAsync(s => s.serviceID == int.Parse(model.service));
                var personel = await _context.personnels.FirstOrDefaultAsync(s => s.personnelID == int.Parse(model.personnel));

                if (service == null || personel == null)
                {
                    //  ModelState.AddModelError("service", "Geçersiz hizmet seçimi.");
                    return View(model);
                }


                // Seçilen personel ve tarih bilgilerini al
            //    var selectedDateTime = DateTime.SpecifyKind(model.date, DateTimeKind.Local).ToUniversalTime();
                var selectedDate = model.date; // model.date'in sadece tarih kısmı
                selectedDate = selectedDate.ToUniversalTime();
              

                var appointHour = model.saat;
                var selectedPersonnelId = int.Parse(model.personnel);

               


                // Mevcut randevuları kontrol et
                var existingAppointments = await _context.appointments
                    .Where(a => a.personnelID == selectedPersonnelId &&
                                a.appointmentDate.Date == selectedDate.Date && // Aynı tarihteki randevular
                                a.appointmentHour == appointHour) // Aynı saatteki randevular
                    .ToListAsync();


                if (existingAppointments.Any())
                {
                    // Çakışma var, kullanıcıya hata mesajı göster
                    ModelState.AddModelError(string.Empty, "Seçtiğiniz saatte bu personel için bir randevu bulunmaktadır. Lütfen başka bir saat seçiniz.");
                    // Eğer model geçerli değilse tekrar formu ve hizmetleri yükle
                    ViewBag.Services = _context.services.ToList();
                    ViewBag.Personels = _context.personnels.ToList();
                    return View(model);
                }





                

                // Veritabanına kaydedilecek Appointment entity'sini oluştur
                var _appointmentDate = DateTime.SpecifyKind(model.date, DateTimeKind.Local).ToUniversalTime();
                
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kullanıcı kimliğini al


                var appointment = new Appointment
                {
                    customerName = model.adSoyad,
                    serviceID = int.Parse(model.service), // `service` string olduğu için dönüştürülmeli
                    serviceName = service.serviceName, // Burada dolduruluyor
                    appointmentDate = _appointmentDate,
                    appointmentHour = model.saat,
                    phone = model.PhoneNumber,
                    notes = model.Notes,

                    IsConfirmed = false,
                    personnelID = int.Parse(model.personnel),
                    customerID = int.Parse(userId),

                };

                await _context.appointments.AddAsync(appointment);
                await _context.SaveChangesAsync();



                // Başarılı işlem sonrası yönlendirme
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Eğer model geçerli değilse tekrar formu ve hizmetleri yükle
                ViewBag.Services = _context.services.ToList();
                ViewBag.Personels = _context.personnels.ToList();
                return View(model);
            }

        }










    }
}
