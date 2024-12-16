using System.Diagnostics;
using Hairdresser.Context;
using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var salon = _context.salons.FirstOrDefault();
            return View(salon);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
