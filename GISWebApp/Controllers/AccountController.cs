using GISWebApp.Models;
using GISWebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace GISWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly CompanyContext context;//REposiotyr

        //Register
        //login
        public AccountController(CompanyContext context)
        {
            this.context = context;
        }
        public IActionResult Login() {

            return View("Login");//Usrname & password 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginAccountViewModel UserFromRequest)
        {
            if (ModelState.IsValid)
            {
                UserAccount? UserFromDB=
                    context.Users
                    .FirstOrDefault(a => a.UserName == UserFromRequest.UserName && a.Password == UserFromRequest.Password);
               
                if (UserFromDB != null) {
                    //create cook
                    ClaimsIdentity claims = new (CookieAuthenticationDefaults.AuthenticationScheme);
                    claims.AddClaim(new Claim("ID", UserFromDB.Id.ToString()));
                    claims.AddClaim(new Claim(ClaimTypes.Name, UserFromDB.UserName));
                    if(UserFromDB.UserName=="Ahmed")
                        claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                    
                    ClaimsPrincipal Principles = new ClaimsPrincipal(claims);
                    
                    await HttpContext.SignInAsync(Principles);//create cookie
                    return RedirectToAction("Index", "Employee");

                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login",UserFromRequest);//Usrname & password 
        }

        public async Task<IActionResult> Logout()
        {
            await  HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");
        }
    }
}
