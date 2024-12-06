using Hairdresser.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Controllers
{


    public class UsersController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users);
        }


        //[HttpPost]
        //    public async IActionResult personelEkle(Personnel personel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new IdentityUser { UserName = personel.personnelName, Email = personel.personnelEmail };

        //      IdentityResult result= await  _userManager.CreateAsync(user,personel.personnelPassword);
        //     }
        //    if ()
        //    {

        //    }

        //    return View(personel);
        //}
    }
}
