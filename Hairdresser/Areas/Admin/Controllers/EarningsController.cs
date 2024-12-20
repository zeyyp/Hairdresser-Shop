using Hairdresser.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EarningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EarningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.earnings
                               .Include(p => p.Personnel) // Navigasyon özelliğini dahil et
                               .ToList();
            return View(model);
        }






    }
}
