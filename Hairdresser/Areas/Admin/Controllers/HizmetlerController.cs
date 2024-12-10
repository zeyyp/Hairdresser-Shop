using Hairdresser.Context;
using Hairdresser.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HizmetlerController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HizmetlerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.services
                               .ToList();
            return View(model);
        }


        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(Service p)
        {
            if (ModelState.IsValid)
            {

            
                Service service = new Service()
                {
                    serviceName = p.serviceName,
                    serviceDuration = p.serviceDuration,
                    servicePrice = p.servicePrice,
                    
                    salonID = 1

                };

                _context.services.Add(service); // Yeni personel ekle
                await _context.SaveChangesAsync(); // Değişiklikleri kaydet

                return RedirectToAction("Index", "Hizmetler", new { area = "Admin" });

            }


            return View(p);


        }

        [HttpGet]
        public IActionResult DeleteService(int id)
        {

            var service = _context.services.Find(id);

            if (service != null)
            {
                _context.services.Remove(service); // Sil
                _context.SaveChanges(); // Veritabanında değişiklikleri kaydet
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await _context.services.FirstOrDefaultAsync(p => p.serviceID == id); // ID'ye göre personel bul

            if (service == null)
            {
                return RedirectToAction("Index"); // Personel bulunamazsa listeye yönlendir
            }
            return View(service); // Bulunan personel bilgilerini View'e gönder
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(Service p)
        {
            if (ModelState.IsValid) // Form verileri geçerli mi?
            {
                var service = await _context.services.FirstOrDefaultAsync(per => per.serviceID == p.serviceID); // Eski kaydı bul

                if (service != null)
                {
                    // Alanları güncelle
                    service.serviceName = p.serviceName;
                    service.serviceDuration = p.serviceDuration;
                    service.servicePrice = p.servicePrice;
                    
                    service.salonID = 1;

                    _context.services.Update(service);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index"); // Başarılı olursa listeye dön
                }
            }
            return View(p); // Hatalıysa aynı sayfayı yeniden yükle
        }


    }
}

