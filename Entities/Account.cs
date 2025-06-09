using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_account")]
        public int IdAccount { get; set; }

        [Required]
        [Column("id_employee")]
        public int IdEmployee { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("passwordhash")]
        public string PasswordHash { get; set; }
        [Column("last_password_update")]
        public DateTime? LastPasswordUpdate { get; set; }

        [ForeignKey("IdEmployee")] 
        public Employee Employee { get; set; }

        public Account()
        {
            
        }
    }
}