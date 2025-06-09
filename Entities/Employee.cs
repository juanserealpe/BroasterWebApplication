using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

    public class Employee
    {
        [Key]
        [Column("id_employee")]
        public int IdEmployee { get; set; }
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        [Range(1, 3, ErrorMessage = "Rol inválido")]
        [Column("id_role")]
        public int IdRole { get; set; }

        public Role Role { get; set; }

        public Account Account { get; set; }

        public Employee()
        {
            
        }
    }
}