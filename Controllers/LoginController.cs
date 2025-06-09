using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using BroasterWebApp.DTOs;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BroasterWebApp.Controllers
{

    [Route("account")]
    public class LoginController : Controller
    {
        private readonly IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet("signin")]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            var user = await authService.IsLoginValidAsync(username, password);
            if (user == null) return Redirect("/login?error=1"); 
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdEmployee.ToString()),
                new Claim(ClaimTypes.Role, user.Role.RoleType.TypeRole)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Redirect("/");
        }
    }
}