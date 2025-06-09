using System.ComponentModel.DataAnnotations;
using BroasterWebApp.Entities;

namespace BroasterWebApp.DTOs
{
    public class SessionDTO
    {
        public string Username {get; set;}
        public string RoleName {get; set;}
        public string Token {get; set;}
    }
}