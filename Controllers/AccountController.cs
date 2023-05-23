using LumiaMvc.AccountViewModel;
using LumiaMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LumiaMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager; 
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            AppUser user =new AppUser();
            {
                user.Email = registerVM.Email;
                user.Surname = registerVM.Surname;
                user.Name = registerVM.Name;
            }
            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password); 

            if (!result.Succeeded) 
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("Login");
        }
    }
}
