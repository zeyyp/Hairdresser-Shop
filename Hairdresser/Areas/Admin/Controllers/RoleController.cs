using Hairdresser.Areas.Admin.Models;
using Hairdresser.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace Hairdresser.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var roller = _roleManager.Roles.ToList();
            return View(roller);
        }

        public IActionResult RoleEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> RoleEkle(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {

                Role role = new Role()
                {
                    Name= model.name
                };

                var result = await  _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }

            }
            return View(model);

        }

        [HttpGet]
        public async Task< IActionResult> DeleteRole(int id)
        {

            var role = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
           

            return View();
        }

        [HttpGet]

        public  IActionResult UserRoleList()
        {

             var values = _userManager.Users.ToList();

            return View(values);
        }

        [HttpGet]
        public async Task< IActionResult> RoleAta(int id)
        {

            var user =  _userManager.Users.FirstOrDefault(x=>x.Id==id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAtaViewModel> model = new List<RoleAtaViewModel>();
            foreach (var role in roles)
            {
                RoleAtaViewModel r = new RoleAtaViewModel();

                r.RoleId = role.Id;
                r.rolAdi = role.Name;
                r.roleSahipMi = userRoles.Contains(role.Name);
                model.Add(r);

               
               
            }
            ViewBag.Userid = id;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> RoleAta(List<RoleAtaViewModel> model)
        {

            var userId =(int) TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==userId);

            foreach (var item in model)
            {
                if (item.roleSahipMi)
                {
                    await _userManager.AddToRoleAsync(user,item.rolAdi);
                }
                else
                {
                 //   await _userManager.RemoveFromRoleAsync(user, item.rolAdi);
                }
            }
            
           
            return View("UserRoleList");
        }

    }
}
