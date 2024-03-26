using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Users;

namespace SeyfBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdUser> userManager;
        private readonly SignInManager<IdUser> signInManager;

        public AuthController(UserManager<IdUser> userManager, SignInManager<IdUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginViewModel.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginViewModel.Password, userLoginViewModel.RememberMe, false);
                    if(result.Succeeded) 
                    {
                        return RedirectToAction("Index", "Home", new {Area = "Admin"});
                    }
                    else
                    {
                        ModelState.AddModelError("", "Eposta adresiniz veya şifreniz yanlış");
                        return View();
                    }
                   
                }
                if(user == null)
                {
                    ModelState.AddModelError("", "Eposta veya şifreniz yanlış");
                    return View();
                }

            }
            else
            {
                return View();
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home",new {Area = ""});   
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

    }
}
