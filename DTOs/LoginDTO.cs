using System.ComponentModel.DataAnnotations;
using BroasterWebApp.Entities;

namespace BroasterWebApp.DTOs
{

    public class LoginDTO
    {
        public string Username {get; set;}
        public string Password {get; set;}
    }

}