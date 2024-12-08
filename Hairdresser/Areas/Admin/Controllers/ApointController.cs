using Hairdresser.Context;
using Hairdresser.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hairdresser.Models;

namespace Hairdresser.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ApointController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ApointController(ApplicationDbContext context)
        {
            _context = context;
        }

        public  IActionResult RandevuListesi()
        {
            var randevular =  _context.appointments
                                       .Include(p=>p.personnel).ToList();
                                       
            return View(randevular);
        }


        [HttpGet]
        public IActionResult DeleteAppoint(int id)
        {

            var personel = _context.appointments.Find(id);

            if (personel != null)
            {
                _context.appointments.Remove(personel); // Sil
                _context.SaveChanges(); // Veritabanında değişiklikleri kaydet
                return RedirectToAction("RandevuListesi");
            }

            return RedirectToAction("RandevuListesi");
        }


        [HttpPost]
        public async Task<IActionResult> Onayla(int id)
        {
            var randevu = await _context.appointments.FindAsync(id);

            if (randevu == null)
            {
                return NotFound();
            }

            randevu.IsConfirmed = true;

            await _context.SaveChangesAsync();
          //  return Content("<script>window.location.reload();</script>"); // Sayfayı yeniler

            return RedirectToAction("RandevuListesi");
        }



        [HttpGet]
        public async Task<IActionResult> UpdateAppoint(int id)
        {

            var appointment = await _context.appointments

                                     .Include(a => a.personnel) // Personel bilgilerini de dahil et
                                     .FirstOrDefaultAsync(p => p.appointmentID == id);
            if (appointment == null)
            {
                return RedirectToAction("RandevuListesi"); // Personel bulunamazsa listeye yönlendir
            }

            var services = _context.services?.ToList() ?? new List<Service>();

            ViewBag.Services = services;

            return View(appointment); // Bulunan personel bilgilerini View'e gönder
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAppoint(Appointment p)
        {
            if (ModelState.IsValid) // Form verileri geçerli mi?
            {
                var appointment = await _context.appointments.FirstOrDefaultAsync(per => per.appointmentID == p.appointmentID); // Eski kaydı bul
                
                

                if (appointment != null)
                {
                    // Alanları güncelle
                    
                    appointment.customerName = p.customerName;
                    appointment.customerID = p.customerID;
                    appointment.personnelID = p.personnelID;
                    appointment.serviceID = p.serviceID;
                    appointment.IsConfirmed = p.IsConfirmed;
                    appointment.notes = p.notes;
                    appointment.phone=p.phone;
                    appointment.customerName=p.customerName;
                    appointment.serviceName = p.serviceName;
                    appointment.appointmentDate = p.appointmentDate;
                    appointment.appointmentHour=p.appointmentHour;



                    _context.appointments.Update(appointment);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("RandevuListesi"); // Başarılı olursa listeye dön
                }
            }

            var services = await _context.services.ToListAsync();
            ViewBag.Services = services;

            return View(p); // Hatalıysa aynı sayfayı yeniden yükle
        }







    }


    }
