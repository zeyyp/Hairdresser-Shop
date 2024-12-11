using Hairdresser.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class PersonnelController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PersonnelController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.personnels.ToList();
            return View(model);
        }

        public IActionResult PersonelEkle()
        {
            return View();
        }
    }
}
