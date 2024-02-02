using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RabbitMQExelCreat_WEB.APP.Models;

namespace RabbitMQExelCreat_WEB.APP.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel u)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(u.username, u.password, false, true);//this false is for remember me , true is for lockout , if you want to use lockout you should add lockoutOnFailure: true to the PasswordSignInAsync method
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }
    }
}
