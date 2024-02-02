using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RabbitMQExelCreat_WEB.APP.Models;

namespace RabbitMQExelCreat_WEB.APP.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;//injecting usermanager

        public RegisterController(UserManager<AppUser> userManager)//injecting usermanager
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //bir kullanıcı kaydı gerçekleştir AppUser sınıfını UserRegisterViewModel sınıfına dönüştür
        [HttpPost]
        public IActionResult Index(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
       
        
        
       
        
        
    }
}
