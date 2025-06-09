using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using BroasterWebApp.DTOs;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BroasterWebApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserDomainService _userDomainService;

        public AuthController(ITokenService tokenService, IUserDomainService userDomainService)
        {
            _tokenService = tokenService;
            _userDomainService = userDomainService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var user = await _userDomainService.IsLoginValid(login.Username, login.Password);
            if (user == null)
                return Unauthorized("Credenciales inválidas");

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Role, user.Role.RoleType.TypeRole)
        };

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("Cookies", principal); 
            return Ok("Autenticado");
        }
    }
}