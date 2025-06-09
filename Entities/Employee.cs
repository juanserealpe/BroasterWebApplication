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
        [MaxLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }
        [Column("hire_date")]
        public DateTime? HireDate { get; set; }

        [Required]
        [Column("id_role")]
        public int IdRole { get; set; }

        [ForeignKey("IdRole")]
        public Role Role { get; set; }

        public virtual Account Account { get; set; }
    }
}