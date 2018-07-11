using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity01.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity01.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            var estaAutenticado = HttpContext.User.Identity.IsAuthenticated;
            
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, usuario.Username));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Username));


            var claimsIdentity = new ClaimsIdentity(
                                    claims, 
                                    CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                            claimsPrincipal);

            var estaAutenticado = HttpContext.User.Identity.IsAuthenticated;

            return Redirect("/");
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
           
            return Redirect("/Account/Login");
        }
    }
}