using Hairdresser.Context;
using Hairdresser.Entities;
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
        public IActionResult PersonelEkle(Personnel p)
        {
            if (ModelState.IsValid) 
            {
                _context.personnels.Add(p); // Yeni personel ekle
                _context.SaveChanges(); // Değişiklikleri kaydet
                return RedirectToAction("Index","Personel"); 
            }

            return View(p);
           
        }

        [HttpPost]
        public IActionResult PersonelSil(int id)
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


        //[HttpGet]
        //public IActionResult PersonelGuncelle(int id)
        //{
        //    var personel = _context.personnels.Find(id); // ID'ye göre personel bul
            
        //    if (personel == null)
        //    {
        //        return RedirectToAction("Index"); // Personel bulunamazsa listeye yönlendir
        //    }
        //    return View(personel); // Bulunan personel bilgilerini View'e gönder
        //}

        //[HttpPost]
        //public IActionResult PersonelGuncelle(Personnel p)
        //{
        //    if (ModelState.IsValid) // Form verileri geçerli mi?
        //    {
        //        var personel = _context.personnels.Find(p.personnelID); // Eski kaydı bul
        //        if (personel != null)
        //        {
        //            // Alanları güncelle
        //            personel.personnelName = p.personnelName;
        //            personel.personnelID = p.personnelID;
        //            personel.availableHours = p.availableHours;
        //            personel.personnelEmail = p.personnelEmail;
        //            personel.personnelPassword = p.personnelPassword;

        //            _context.SaveChanges(); // Değişiklikleri veritabanına kaydet
        //            return RedirectToAction("Index"); // Başarılı olursa listeye dön
        //        }
        //    }
        //    return View(p); // Hatalıysa aynı sayfayı yeniden yükle
        //}


    }
}
