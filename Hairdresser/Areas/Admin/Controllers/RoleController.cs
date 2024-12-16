using Hairdresser.Areas.Admin.Models;
using Hairdresser.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace Hairdresser.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
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
        public async Task<IActionResult> RoleAta(int id)
        {
            if(id == null)
            {
                return RedirectToAction("UserRoleList");
            }


            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);


            if (user != null)
            {
                var roles = _roleManager.Roles.ToList();
                var userRoles = await _userManager.GetRolesAsync(user);

                ViewBag.Roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();  // atanabılecek tum roller

                
                    RoleAtaViewModel r = new RoleAtaViewModel();
                    r.Id = user.Id;
                   
                    r.selectedRoles = await _userManager.GetRolesAsync(user);  // kullanıcının var olan rolleri

             
               return View(r);
            }

            return RedirectToAction("UserRoleList");

        }


        [HttpPost]
        public async Task<IActionResult> RoleAta(int id,RoleAtaViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToAction("UserRoleList");
            }

            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    //kullanıcının rolleri kullanıcıdan sılınır
                    await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                    if (model.selectedRoles != null)
                    {   // seçili roller eklenir
                        await _userManager.AddToRolesAsync(user, model.selectedRoles);
                    }
                    
                }
            }
            
 
            return RedirectToAction("UserRoleList");
        }




    }
}
