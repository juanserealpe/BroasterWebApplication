using System.Security.Claims;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BroasterWebApp.services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SignInAsync(Employee prmEmployee, bool isPersistent = false)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, prmEmployee.IdRole.ToString()),
            new Claim(ClaimTypes.Role, prmEmployee.Role.RoleType.TypeRole),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = isPersistent, // Cookie persistente (opcional)
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30), // Tiempo de expiración
                AllowRefresh = true // Permite refrescar la sesión
            };

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );
        }
    
    }
}