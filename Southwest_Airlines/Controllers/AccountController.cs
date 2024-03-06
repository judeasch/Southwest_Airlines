using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Southwest_Airlines.Models;

namespace Southwest_Airlines.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new AccountModel { ReturnUrl = returnUrl };
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(AccountModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signManager.PasswordSignInAsync(model.Username,
        //           model.Password, model.RememberMe, false);

        //        if (result.Succeeded)
        //        {
        //            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
        //            {
        //                return Redirect(model.ReturnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //    }
        //    ModelState.AddModelError("", "Invalid login attempt");
        //    return View(model);
        //}

    }
}
