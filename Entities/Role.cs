using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_role")]
        public int IdRole { get; set; }

        [Required]
        [Column("id_role_type")]
        public int IdRoleType { get; set; }

        [ForeignKey("IdRoleType")]
        public RoleType RoleType { get; set; }

    }
}