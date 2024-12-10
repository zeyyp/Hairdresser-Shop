using Hairdresser.Context;
using Hairdresser.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalonController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.salons
                               .ToList();
            return View(model);

           
        }




        [HttpGet]
        public async Task<IActionResult> UpdateSalon(int id)
        {
            var salon = await _context.salons.FirstOrDefaultAsync(p => p.salonID == id); // ID'ye göre personel bul

            if (salon == null)
            {
                return RedirectToAction("Index"); // Personel bulunamazsa listeye yönlendir
            }
            return View(salon); // Bulunan personel bilgilerini View'e gönder
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSalon(Salon p)
        {
            if (ModelState.IsValid) // Form verileri geçerli mi?
            {
                var salon = await _context.salons.FirstOrDefaultAsync(per => per.salonID == p.salonID); // Eski kaydı bul

                if (salon != null)
                {
                    // Alanları güncelle
                    salon.salonName = p.salonName;
                    salon.salonType = p.salonType;
                    salon.workingHours = p.workingHours;
                    salon.salonAddress = p.salonAddress;
                   
                    _context.salons.Update(salon);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index"); // Başarılı olursa listeye dön
                }
            }
            return View(p); // Hatalıysa aynı sayfayı yeniden yükle
        }
    }
}
