using Hairdresser.Context;
using Hairdresser.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PersonelController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PersonelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          
            var model = _context.personnels
                               .Include(p => p.expertises) // Navigasyon özelliğini dahil et
                               .ToList();
            return View(model);
            
        }

        [HttpGet]
        public IActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  PersonelEkle(Personnel p)
        {
            if (ModelState.IsValid) 
            {
               
                var salon = await _context.salons.FirstOrDefaultAsync(s => s.salonID == 1);        

                if (salon == null)
                {
                    // Hata mesajı, salon bulunamadı
                    ModelState.AddModelError("salonID", "Geçerli bir salon seçmediniz.");
                    return View(p);
                }

                Personnel personel = new Personnel()
                {
                    personnelName = p.personnelName,
                    personnelEmail = p.personnelEmail,
                    personnelPassword = p.personnelPassword,
                   availableHours = p.availableHours,
                   ExpertiseID = p.ExpertiseID,
                   salonID = 1

                };

                _context.personnels.Add(personel); // Yeni personel ekle
                await _context.SaveChangesAsync(); // Değişiklikleri kaydet
               
                return RedirectToAction("Index", "Personel", new { area = "Admin" });

            }


            return View(p);
            
                
        }

        [HttpGet]
        public IActionResult DeletePer(int id)
        {
            
            var personel = _context.personnels.Find(id);

            if (personel != null) 
            {
                _context.personnels.Remove(personel); // Sil
                _context.SaveChanges(); // Veritabanında değişiklikleri kaydet
                return RedirectToAction("Index"); 
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdatePer(int id)
        {
            var personel = await _context.personnels.FirstOrDefaultAsync(p => p.personnelID == id); // ID'ye göre personel bul

            if (personel == null)
            {
                return RedirectToAction("Index"); // Personel bulunamazsa listeye yönlendir
            }
            return View(personel); // Bulunan personel bilgilerini View'e gönder
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePer(Personnel p)
        {
            if (ModelState.IsValid) // Form verileri geçerli mi?
            {
                var personel = await _context.personnels.FirstOrDefaultAsync(per => per.personnelID == p.personnelID); // Eski kaydı bul
                
                if (personel != null)
                {
                    // Alanları güncelle
                    personel.personnelName = p.personnelName;
                    personel.personnelID = p.personnelID;
                    personel.availableHours = p.availableHours;
                    personel.personnelEmail = p.personnelEmail;
                    personel.personnelPassword = p.personnelPassword;
                    personel.ExpertiseID = p.ExpertiseID;
                    personel.salonID = 1;

                    _context.personnels.Update(personel);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction("Index"); // Başarılı olursa listeye dön
                }
            }
            return View(p); // Hatalıysa aynı sayfayı yeniden yükle
        }


    }
}
