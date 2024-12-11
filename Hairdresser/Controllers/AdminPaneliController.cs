using Hairdresser.Context;
using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class AdminPaneliController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminPaneliController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonelList()
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
