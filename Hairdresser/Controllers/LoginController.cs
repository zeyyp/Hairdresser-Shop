using Hairdresser.Entities;
using Hairdresser.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hairdresser.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(KullaniciKayitViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                adSoyad = p.adSoyad,
                Email = p.Email,
                UserName = p.userName,

            };
            if (p.sifre == p.sifreTekrar)
            {
                var result = await _userManager.CreateAsync(appUser, p.sifre);

                if (result.Succeeded)
                {
                    return RedirectToAction("GirisYap");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(GirisYapViewModel p)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(p.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Bu e-posta ile kayıtlı bir kullanıcı bulunamadı.");
                    return View(p);
                }

                var result = await _signInManager.PasswordSignInAsync(user, p.sifre, false, false);

                if (result.Succeeded)
                {
                    // Kullanıcı giriş işlemi başarılı
                    return RedirectToAction("KayitOl", "Login");
                }
                else
                {
                    // Hatalı giriş
                    ModelState.AddModelError("", "E-posta veya şifre hatalı. Lütfen bilgilerinizi kontrol edin.");
                    return View(p);
                }
               
            }

            return View(p);
        }
    }
}
