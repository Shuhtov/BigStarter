using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BigStarter.Presentation.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BigStarter.Presentation.Controllers
{
    public class AccountManagementController : Controller
    {
        List<UserSoc> userList = new List<UserSoc>();
        private readonly IAuthenticationSchemeProvider authenticationSchemeProvider;
        public AccountManagementController(IAuthenticationSchemeProvider authenticationSchemeProvider)
        {
            this.authenticationSchemeProvider = authenticationSchemeProvider;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult StartProject()
        {
            return View();
        }
        public IActionResult MyProject()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }


        public IActionResult SignInSocial(String provider)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/Home/Index" }, provider);
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}